using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 医疗文档信息列表
    /// </summary>
    [System.Serializable]
    public class MedDocList : List<MedDocInfo>
    {
        /// <summary>
        /// 对列表按内部方法进行排序
        /// </summary>
        new public void Sort()
        {
            base.Sort(new Comparison<MedDocInfo>(this.Compare));
        }

        /// <summary>
        /// 对列表按内部方法进行排序
        /// </summary>
        public void SortByTime(bool isDesc)
        {
            if (!isDesc)
                base.Sort(new Comparison<MedDocInfo>(this.CompareTimeAsc));
            else
                base.Sort(new Comparison<MedDocInfo>(this.CompareTimeDesc));
        }
        /// <summary>
        /// 对列表内按照文档类型进行排序
        /// </summary>
        public void SortByDocType()
        {
            base.Sort(new Comparison<MedDocInfo>(this.CompareDocType));
        }
        /// <summary>
        /// 对指定的两个文档信息对象进行排序
        /// </summary>
        /// <param name="docInfo1">文档信息对象1</param>
        /// <param name="docInfo2">文档信息对象2</param>
        /// <returns>int</returns>
        private int CompareDocType(MedDocInfo docInfo1, MedDocInfo docInfo2)
        {
            if (docInfo1 == null && docInfo2 != null)
                return -1;
            if (docInfo1 != null && docInfo2 == null)
                return 1;
            if (docInfo1 == null && docInfo2 == null)
                return 0;
            string szDocType1 = docInfo1.DOC_TYPE;
            string szDcoType2 = docInfo2.DOC_TYPE;
            return szDocType1.CompareTo(szDcoType2);
        }
        /// <summary>
        /// 对指定的两个文档信息对象进行排序
        /// </summary>
        /// <param name="docInfo1">文档信息对象1</param>
        /// <param name="docInfo2">文档信息对象2</param>
        /// <returns>int</returns>
        public int Compare(MedDocInfo docInfo1, MedDocInfo docInfo2)
        {
            if (docInfo1 == null && docInfo2 != null)
                return -1;
            if (docInfo1 != null && docInfo2 == null)
                return 1;
            if (docInfo1 == null && docInfo2 == null)
                return 0;
            DateTime dtRecordTime1 = docInfo1.RECORD_TIME;
            DateTime dtRecordTime2 = docInfo2.RECORD_TIME;
            if (dtRecordTime1 == docInfo1.DefaultTime)
                dtRecordTime1 = docInfo1.DOC_TIME;
            if (dtRecordTime2 == docInfo2.DefaultTime)
                dtRecordTime2 = docInfo2.DOC_TIME;
            if (docInfo1.ORDER_VALUE >= 0 || docInfo2.ORDER_VALUE >= 0)
                return docInfo1.ORDER_VALUE - docInfo2.ORDER_VALUE;
            return dtRecordTime1.CompareTo(dtRecordTime2);
        }

        /// <summary>
        /// 对指定的两个文档信息对象进行排序
        /// </summary>
        /// <param name="docInfo1">文档信息对象1</param>
        /// <param name="docInfo2">文档信息对象2</param>
        /// <returns>int</returns>
        public int CompareTimeAsc(MedDocInfo docInfo1, MedDocInfo docInfo2)
        {
            if (docInfo1 == null && docInfo2 != null)
                return -1;
            if (docInfo1 != null && docInfo2 == null)
                return 1;
            if (docInfo1 == null && docInfo2 == null)
                return 0;
            DateTime dtRecordTime1 = docInfo1.RECORD_TIME;
            DateTime dtRecordTime2 = docInfo2.RECORD_TIME;
            if (dtRecordTime1 == docInfo1.DefaultTime)
                dtRecordTime1 = docInfo1.DOC_TIME;
            if (dtRecordTime2 == docInfo2.DefaultTime)
                dtRecordTime2 = docInfo2.DOC_TIME;
            return docInfo1.DOC_TIME.CompareTo(docInfo2.DOC_TIME);
            //return dtRecordTime1.CompareTo(dtRecordTime2);
        }

        /// <summary>
        /// 对指定的两个文档信息对象进行排序
        /// </summary>
        /// <param name="docInfo1">文档信息对象1</param>
        /// <param name="docInfo2">文档信息对象2</param>
        /// <returns>int</returns>
        public int CompareTimeDesc(MedDocInfo docInfo1, MedDocInfo docInfo2)
        {
            return this.CompareTimeAsc(docInfo2, docInfo1);
        }
    }
}
