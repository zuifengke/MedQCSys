using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 自动核查缺陷规则信息
    /// </summary>
    public class QcCheckPoint : DbTypeBase
    {
        /// <summary>
        /// 事件名
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 事件ID
        /// </summary>
        public string EventID { get; set; }
        /// <summary>
        /// 核查缺陷点ID
        /// </summary>
        public string CheckPointID { get; set; }
        /// <summary>
        /// 核查内容
        /// </summary>
        public string CheckPointContent { get; set; }
        /// <summary>
        /// 处理命令
        /// </summary>
        public string HandlerCommand { get; set; }
        /// <summary>
        /// 质检问题模板代码
        /// </summary>
        public string MsgDictCode { get; set; }
        /// <summary>
        /// 质检问题描述
        /// </summary>
        public string MsgDictMessage { get; set; }
        /// <summary>
        /// 文书类型ID
        /// </summary>
        public string DocTypeID { get; set; }
        /// <summary>
        /// 文书类型标题
        /// </summary>
        public string DocTypeName { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        public string QaEventType { get; set; }
        /// <summary>
        /// 计算表达式
        /// </summary>
        public string Expression { get; set; }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        /// <summary>
        /// 是否循环
        /// </summary>
        public bool IsRepeat { get; set; }
        /// <summary>
        /// 分值
        /// </summary>
        public float Score { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderValue { get; set; }
        /// <summary>
        /// 获取或设置最晚完成时间，如：24H表示，开始书写时间后24小时内。
        /// </summary>
        public string WrittenPeriod { get; set; }
        /// <summary>
        /// 检查类型：时效性 完整性 一致性 合理性
        /// </summary>
        public string CheckType { get; set; }
        public string ScriptID { get; set; }
        public string ScriptName { get; set; }
        public string MakeCheckPointID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("P{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }

    }
}
