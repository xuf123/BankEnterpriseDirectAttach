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
    /// 预付卡备付金其他代付明细查询请求内容
    /// </summary>
    [XmlRoot("stream")]
    public class RQ_DLAGJFQY : RqBase<RS_DLAGJFQY>
    {
        /// <summary>
        /// 业务对应请求代码
        /// </summary>
        [XmlElement("action")]
        public override string Action { get => "DLAGJFQY"; set { } }
        /// <summary>
        /// 客户流水号char(20)
        /// </summary>
        [XmlElement("clientID")]
        public string ClientID { get; set; }
    }
}
