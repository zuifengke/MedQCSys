using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.Core
{
    public class RightResource 
    {
        /// <summary>
        /// 模块属于产品的标识
        /// </summary>
        public static string PRODUCT_MEDQC = "MedQC";
        /// <summary>
        /// 用户管理模块使用权限点
        /// </summary>
        public static string MedQC_Hdp_Role = "MedQC.Hdp.Role";
        /// <summary>
        /// 用户管理模块使用权限点
        /// </summary>
        public static string MedQC_Hdp_User = "MedQC.Hdp.User";
        /// <summary>
        /// 用户管理模块使用权限点
        /// </summary>
        public static string MedQC_Hdp_Product = "MedQC.Hdp.Product";
        /// <summary>
        /// 用户管理模块使用权限点
        /// </summary>
        public static string MedQC_Hdp_UIConfig = "MedQC.Hdp.UIConfig";


        /// <summary>
        /// 模块属于产品的标识
        /// </summary>
        public static string PRODUCT_MED_RECORD = "MedRecord";
        /// <summary>
        /// 纸质病历批次查询
        /// </summary>
        public static string MedRecord_RecMrBatch = "MedRecord.RecMrBatch";
        /// <summary>
        /// 纸质病历逐份接收
        /// </summary>
        public static string MedRecord_ReceiveInOrder = "MedRecord_ReceiveInOrder";
        /// <summary>
        /// 纸质病历批量提交
        /// </summary>
        public static string MedRecord_RecMrBatchSend = "MedRecord_RecMrBatchSend";
        /// <summary>
        /// 病历浏览审核
        /// </summary>
        public static string MedRecord_RecBrowseRequest = "MedRecord_RecBrowseRequest";


        #region AbstractRight 成员

        public static RightPoint[] GetRightPoints(string szProduct)
        {
            if (szProduct == PRODUCT_MEDQC)
            {
                RightPoint[] rightPoint = new RightPoint[]{
                  new RightPoint(MedQC_Hdp_Role,"角色管理","角色管理"),
                  new RightPoint(MedQC_Hdp_User,"用户管理","用户管理"),
                  new RightPoint(MedQC_Hdp_Product,"产品管理","产品管理"),
                  new RightPoint(MedQC_Hdp_UIConfig,"菜单管理","菜单管理"),
                };
                return rightPoint;
            }
            else if (szProduct == PRODUCT_MED_RECORD)
            {
                RightPoint[] rightPoint = new RightPoint[]{
                  new RightPoint(PRODUCT_MED_RECORD,"病案管理系统",""),
                  new RightPoint(MedRecord_RecMrBatch,"纸质病历批次查询","纸质病历批次查询"),
                  new RightPoint(MedRecord_ReceiveInOrder,"纸质病历逐份接收","纸质病历逐份接收"),
                  new RightPoint(MedRecord_RecMrBatchSend,"纸质病历批量提交","纸质病历批量提交"),
                  new RightPoint(MedRecord_RecBrowseRequest,"病历浏览审核","病历浏览审核")
                };
                return rightPoint;
            }
            return null;
        }

        public static string[] GetModuleResources(string szProduct)
        {
            return new string[] { PRODUCT_MEDQC};
        }
        #endregion
    }
}
