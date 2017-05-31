using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        ///  病历审签状态
        /// </summary>
        public struct SignState
        {
            /// <summary>
            /// 住院医师保存未提交
            /// </summary>
            public const string CREATOR_SAVE = "CS";
            /// <summary>
            /// 住院医师签名提交
            /// </summary>
            public const string CREATOR_COMMIT = "CC";
            /// <summary>
            /// 住院医师保存未提交
            /// </summary>
            public const string CREATOR_SAVE_CH = "草稿";
            /// <summary>
            /// 住院医师签名提交
            /// </summary>
            public const string CREATOR_COMMIT_CH = "已提交";

            /// <summary>
            /// 上级医师保存未提交
            /// </summary>
            public const string PARENT_SAVE = "PS";
            /// <summary>
            /// 上级医师签名提交
            /// </summary>
            public const string PARENT_COMMIT = "PC";
            /// <summary>
            /// 上级医师回退病历
            /// </summary>
            public const string PARENT_ROLLBACK = "PR";
            /// <summary>
            /// 上级医师保存未提交
            /// </summary>
            public const string PARENT_SAVE_CH = "上级修改";
            /// <summary>
            /// 上级医师签名提交
            /// </summary>
            public const string PARENT_COMMIT_CH = "上级已签";
            /// <summary>
            /// 上级医师回退病历
            /// </summary>
            public const string PARENT_ROLLBACK_CH = "上级退回";

            /// <summary>
            /// 主任医师保存未提交
            /// </summary>
            public const string SUPER_SAVE = "SS";
            /// <summary>
            /// 主任医师签名提交
            /// </summary>
            public const string SUPER_COMMIT = "SC";
            /// <summary>
            /// 主任医师回退病历
            /// </summary>
            public const string SUPER_ROLLBACK = "SR";
            /// <summary>
            /// 主任医师保存未提交
            /// </summary>
            public const string SUPER_SAVE_CH = "主任修改";
            /// <summary>
            /// 主任医师签名提交
            /// </summary>
            public const string SUPER_COMMIT_CH = "主任已签";
            /// <summary>
            /// 主任医师回退病历
            /// </summary>
            public const string SUPER_ROLLBACK_CH = "主任退回";

            /// <summary>
            /// 质控人员退回病历
            /// </summary>
            public const string QC_ROLLBACK = "QR";
            /// <summary>
            /// 质控人员退回病历
            /// </summary>
            public const string QC_ROLLBACK_CH = "质控退回";
        }
    }
}
