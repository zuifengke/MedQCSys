/***************************************************************
 * @FileName   : DataReaderHandler.cs
 * @Description: 封装DataReader对象的缓存管理,提高数据读取效率
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2016-12-9 14:09:10
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
****************************************************************/
using System;
using System.Text;
using System.Data;
using System.Timers;
using System.Collections.Generic;

namespace EMRDBLib.DbAccess
{
    internal class DataReaderHandler
    {
        private static DataReaderHandler m_instance = null;
        /// <summary>
        /// 本类单实例运行
        /// </summary>
        public static DataReaderHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new DataReaderHandler();
                return m_instance;
            }
        }

        private Timer m_timer = null;
        private Dictionary<string, SafeDataReader> m_readers = null;
        private DataReaderHandler()
        {
            this.m_timer = new Timer();
            this.m_timer.Interval = 3 * 60 * 1000;//3分钟
            this.m_timer.Elapsed += delegate
            {
                this.CleanDataReaders();
            };
            this.m_readers = new Dictionary<string, SafeDataReader>();
        }

        public void CleanDataReaders()
        {
            if (this.m_readers.Count <= 0)
            {
                if (this.m_timer.Enabled)
                    this.m_timer.Stop();
                return;
            }
            string[] keyArray = new string[this.m_readers.Count];
            this.m_readers.Keys.CopyTo(keyArray, 0);
            foreach (string key in keyArray)
            {
                if (!this.m_readers.ContainsKey(key))
                    continue;
                SafeDataReader readerInfo = this.m_readers[key];
                if (!readerInfo.IsValid())
                {
                    readerInfo.Close();
                    this.m_readers.Remove(key);
                }
            }
            if (this.m_readers.Count <= 0 && this.m_timer.Enabled)
                this.m_timer.Stop();
        }

        public SafeDataReader Add(string id, string sql, IDataReader reader)
        {
            if (string.IsNullOrEmpty(id) || reader == null)
                return null;

            SafeDataReader safeDataReader = null;
            if (this.m_readers.ContainsKey(id))
            {
                safeDataReader = this.m_readers[id];
                safeDataReader.UpdateDataReader(sql, reader);
            }
            else
            {
                if (this.m_readers.Count >= 100)
                    this.CloseOlderDataReader();
                safeDataReader = new SafeDataReader(id, sql, reader);
                this.m_readers.Add(id, safeDataReader);
            }
            if (!this.m_timer.Enabled)
                this.m_timer.Start();
            return safeDataReader;
        }

        public SafeDataReader GetDataReader(string id)
        {
            if (string.IsNullOrEmpty(id) || !this.m_readers.ContainsKey(id))
                return null;

            SafeDataReader safeDataReader = this.m_readers[id];
            if (!safeDataReader.IsValid())
            {
                safeDataReader.Close();
                this.m_readers.Remove(id);
                if (this.m_readers.Count <= 0 && this.m_timer.Enabled)
                    this.m_timer.Stop();
                return null;
            }
            safeDataReader.UpdateLastAccessTime();
            return safeDataReader;
        }

        public void CloseDataReader(string id)
        {
            if (string.IsNullOrEmpty(id) || !this.m_readers.ContainsKey(id))
                return;

            this.m_readers[id].Close();
            this.m_readers.Remove(id);
            if (this.m_readers.Count <= 0 && this.m_timer.Enabled)
                this.m_timer.Stop();
        }

        private void CloseOlderDataReader()
        {
            string id = null;
            DateTime lastAccessTime = DateTime.Now;
            foreach (KeyValuePair<string, SafeDataReader> reader in this.m_readers)
            {
                if (reader.Value.LastAccessTime < lastAccessTime)
                    id = reader.Key;
                lastAccessTime = reader.Value.LastAccessTime;
            }
            this.CloseDataReader(id);
        }
    }
}
