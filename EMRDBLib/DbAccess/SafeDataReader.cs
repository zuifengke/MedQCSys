/********************************************************
 * @FileName   : SafeDataReader.cs
 * @Description: 自定义的安全的DataReader对象
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2016-12-10 9:11:55
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using System;
using System.Text;
using System.Data;

namespace EMRDBLib.DbAccess
{
    public class SafeDataReader : IDataReader
    {
        private string m_id = null;
        /// <summary>
        /// 获取当前DataReader的唯一ID号
        /// </summary>
        public string ID
        {
            get { return this.m_id; }
        }

        private string m_sql = null;
        /// <summary>
        /// 获取当前DataReader关联的SQL
        /// </summary>
        public string SQL
        {
            get { return this.m_sql; }
        }

        private int m_currentIndex = -1;
        /// <summary>
        /// 获取当前DataReader的记录索引
        /// </summary>
        public int CurrentIndex
        {
            get { return this.m_currentIndex; }
        }

        private IDataReader m_reader = null;
        /// <summary>
        /// 获取当前关联的原始DataReader
        /// </summary>
        internal IDataReader DataReader
        {
            get { return this.m_reader; }
        }

        private DateTime m_lastAccessTime = DateTime.Now;
        /// <summary>
        /// 获取当前DataReader的最后访问时间
        /// </summary>
        internal DateTime LastAccessTime
        {
            get { return this.m_lastAccessTime; }
        }

        public SafeDataReader()
        {
        }

        public SafeDataReader(string id, string sql, IDataReader reader)
        {
            this.m_id = id;
            this.m_sql = sql;
            this.m_reader = reader;
        }

        public bool IsValid()
        {
            if (this.m_reader == null || this.m_reader.IsClosed
                || this.m_lastAccessTime.AddMinutes(60) < DateTime.Now)
                return false;
            return true;
        }

        internal void UpdateLastAccessTime()
        {
            this.m_lastAccessTime = DateTime.Now;
        }

        internal void UpdateDataReader(string sql, IDataReader reader)
        {
            this.Close();
            this.m_sql = sql;
            this.m_reader = reader;
            this.m_currentIndex = -1;
            this.m_lastAccessTime = DateTime.Now;
        }

        public DataSet Read(int start, int end)
        {
            if (start < 0 || end < start)
                return null;

            if (!this.Read())
            {
                DataReaderHandler.Instance.CloseDataReader(this.m_id);
                return null;
            }

            int count = end - start + 1;
            DataSet result = new DataSet();
            DataTable table = result.Tables.Add();
            object[] rowData = new object[this.FieldCount];
            do
            {
                if (this.m_currentIndex < start)
                    continue;
                if (start++ < this.m_currentIndex)
                    continue;

                int index = 0;
                while (index < rowData.Length)
                {
                    if (this.IsDBNull(index))
                        rowData[index] = DBNull.Value;
                    else
                        rowData[index] = this.GetValue(index);
                    if (table.Columns.Count < rowData.Length)
                        table.Columns.Add(index.ToString(), this.GetFieldType(index));
                    index++;
                }
                table.Rows.Add(rowData);
            } while (this.m_currentIndex < end && this.Read());

            if (table.Rows.Count < count)
                DataReaderHandler.Instance.CloseDataReader(this.m_id);
            return result;
        }

        #region IDisposable Members
        public void Dispose()
        {
            this.m_reader.Dispose();
        }
        #endregion

        #region IDataReader Members
        public int Depth
        {
            get
            {
                if (this.m_reader == null)
                    return 0;
                return this.m_reader.Depth;
            }
        }

        public bool IsClosed
        {
            get
            {
                if (this.m_reader == null)
                    return true;
                return this.m_reader.IsClosed;
            }
        }

        public int RecordsAffected
        {
            get { return this.m_reader.RecordsAffected; }
        }

        public DataTable GetSchemaTable()
        {
            if (this.m_reader == null)
                return null;
            return this.m_reader.GetSchemaTable();
        }

        public void Close()
        {
            this.m_currentIndex = -1;
            if (this.m_reader == null)
                return;
            if (!this.m_reader.IsClosed)
            {
                this.m_reader.Close();
                this.m_reader.Dispose();
            }
            this.m_reader = null;
        }

        public bool Read()
        {
            if (this.m_reader == null)
                return false;
            this.m_currentIndex++;
            return this.m_reader.Read();
        }

        public bool NextResult()
        {
            return this.m_reader.NextResult();
        }
        #endregion

        #region IDataRecord Members
        public object this[string name]
        {
            get { return this.m_reader[name]; }
        }

        public object this[int i]
        {
            get { return this.m_reader[i]; }
        }

        public int FieldCount
        {
            get { return this.m_reader.FieldCount; }
        }

        public bool IsDBNull(int i)
        {
            return this.m_reader.IsDBNull(i);
        }

        public bool GetBoolean(int i)
        {
            return this.m_reader.GetBoolean(i);
        }

        public IDataReader GetData(int i)
        {
            return this.m_reader.GetData(i);
        }

        public string GetDataTypeName(int i)
        {
            return this.m_reader.GetDataTypeName(i);
        }

        public DateTime GetDateTime(int i)
        {
            return this.m_reader.GetDateTime(i);
        }

        public decimal GetDecimal(int i)
        {
            return this.m_reader.GetDecimal(i);
        }

        public double GetDouble(int i)
        {
            return this.m_reader.GetDouble(i);
        }

        public Type GetFieldType(int i)
        {
            return this.m_reader.GetFieldType(i);
        }

        public float GetFloat(int i)
        {
            return this.m_reader.GetFloat(i);
        }

        public Guid GetGuid(int i)
        {
            return this.m_reader.GetGuid(i);
        }

        public short GetInt16(int i)
        {
            return this.m_reader.GetInt16(i);
        }

        public int GetInt32(int i)
        {
            return this.m_reader.GetInt32(i);
        }

        public long GetInt64(int i)
        {
            return this.m_reader.GetInt64(i);
        }

        public string GetName(int i)
        {
            return this.m_reader.GetName(i);
        }

        public int GetOrdinal(string name)
        {
            return this.m_reader.GetOrdinal(name);
        }

        public string GetString(int i)
        {
            return this.m_reader.GetString(i);
        }

        public object GetValue(int i)
        {
            return this.m_reader.GetValue(i);
        }

        public int GetValues(object[] values)
        {
            return this.m_reader.GetValues(values);
        }

        public byte GetByte(int i)
        {
            return this.m_reader.GetByte(i);
        }

        public long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
        {
            return this.m_reader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

        public char GetChar(int i)
        {
            return this.m_reader.GetChar(i);
        }

        public long GetChars(int i, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            return this.m_reader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }
        #endregion
    }
}
