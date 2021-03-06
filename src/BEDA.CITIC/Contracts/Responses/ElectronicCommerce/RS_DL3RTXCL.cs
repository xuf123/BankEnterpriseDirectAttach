﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CITIC.Contracts.Responses
{
    /// <summary>
    /// 第三方商户提现汇总查询响应内容
    /// </summary>
    [XmlRoot("stream")]
    public class RS_DL3RTXCL : RsBase
    {
        /// <summary>
        /// 中信银行集合列表
        /// </summary>
        [XmlArray("list")]
        [XmlArrayItem("row")]
        public List<ThirdPartyCashSummary> List { get; set; }
    }
    /// <summary>
    /// 第三方商户提现汇总
    /// </summary>
    public class ThirdPartyCashSummary
    {
        /// <summary>
        /// 批次号 varchar(8)
        /// </summary>
        [XmlElement("batNo")]
        public string BatNo { get; set; }
        /// <summary>
        /// 客户流水号 varchar(20)
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }
        /// <summary>
        /// 成功总笔数 int
        /// </summary>
        [XmlElement("succTotal")]
        public int SuccTotal { get; set; }
        /// <summary>
        /// 成功总金额 decimal(15,2)
        /// </summary>
        [XmlElement("succAmt")]
        public decimal SuccAmt { get; set; }
        /// <summary>
        /// 失败总笔数 int
        /// </summary>
        [XmlElement("failTotal")]
        public int FailTotal { get; set; }
        /// <summary>
        /// 失败总金额 decimal(15,2)
        /// </summary>
        [XmlElement("failAmt")]
        public decimal FailAmt { get; set; }
        /// <summary>
        /// 总笔数 int
        /// </summary>
        [XmlElement("totalNum")]
        public int TotalNum { get; set; }
        /// <summary>
        /// 总金额 decimal(15,2)
        /// </summary>
        [XmlElement("totalAmt")]
        public decimal TotalAmt { get; set; }
        /// <summary>
        /// 批次受理状态 varchar(2)，值域见附录4.2
        /// </summary>
        [XmlElement("stt")]
        public string Stt { get; set; }
        /// <summary>
        /// 提现日期char(8) 格式YYYYMMDD
        /// </summary>
        [XmlElement("tranDate")]
        public string TranDate { get; set; }
        /// <summary>
        /// 提现时间char(6) 格式hhmmss
        /// </summary>
        [XmlElement("tranTime")]
        public string TranTime { get; set; }
        /// <summary>
        /// 提现时间 由<see cref="TranDate"/>和<see cref="TranTime"/>组成
        /// </summary>
        [XmlIgnore]
        public DateTime? TransactionTime
        {
            get
            {
                if (DateTime.TryParseExact(string.Format("{0}{1}", this.TranDate, this.TranTime),
                   new string[] { "yyyyMMdd", "yyyyMMddHHmmss" }, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    return tmp;
                }
                return null;
            }
        }
    }
}
