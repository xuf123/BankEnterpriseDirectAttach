﻿using BEDA.CITIC.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CITIC.Contracts.Requests
{
    /// <summary>
    /// 提示付款经办请求内容
    /// </summary>
    [XmlRoot("stream")]
    public class RQ_DLTSFKSQ : RqBase<RS_DLTSFKSQ>
    {
        /// <summary>
        /// 业务对应请求代码
        /// </summary>
        [XmlElement("action")]
        public override string Action { get => "DLTSFKSQ"; set { } }
        /// <summary>
        /// 客户流水号 varchar (20)
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }
        /// <summary>
        /// 签约账号 char(19)
        /// </summary>
        [XmlElement("accountNo")]
        public string AccountNo { get; set; }
        /// <summary>
        /// 电子票据序列号 char(30)
        /// </summary>
        [XmlElement("billNo")]
        public string BillNo { get; set; }
        /// <summary>
        /// 提示付款类型 char(2) 01正常，02逾期
        /// </summary>
        [XmlElement("bussType")]
        public string BussType { get; set; }
        /// <summary>
        /// 逾期说明 varchar(60)，逾期时必须输入
        /// </summary>
        [XmlElement("overdueRsn")]
        public string OverdueRsn { get; set; }
        /// <summary>
        /// 经办备注 varchar(256)，可空
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }
        /// <summary>
        /// 预约支付标志 0：非预约1：预约 char(1)
        /// </summary>
        [XmlElement("preFlg")]
        public int PreFlg { get; set; }
        /// <summary>
        /// 预约支付时间
        /// </summary>
        [XmlIgnore]
        public DateTime? AppointmentTime { get; set; }
        /// <summary>
        /// 预约支付日期 预约时非空 char(8) 格式YYYYMMDD
        /// </summary>
        [XmlElement("preDate")]
        public string PreDateStr
        {
            get
            {
                return this.AppointmentTime?.ToString("yyyyMMdd");
            }
            set { }
        }
        /// <summary>
        /// 资金划扣方式 char(1)，可空，0：银行划扣；1：客户划扣
        /// </summary>
        [XmlElement("payMthd")]
        public int? PayMthd { get; set; }
    }
}