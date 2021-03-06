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
    /// 现金池参数查询请求内容
    /// </summary>
    [XmlRoot("stream")]
    public class RQ_CMPLPMQY : RqBase<RS_CMPLPMQY>
    {
        /// <summary>
        /// 业务对应请求代码
        /// </summary>
        [XmlElement("action")]
        public override string Action { get => "CMPLPMQY"; set { } }
        /// <summary>
        /// 核心账号char(19)
        /// </summary>
        [XmlElement("coreAccountNo")]
        public string CoreAccountNo { get; set; }
        /// <summary>
        /// 成员单位账号char(19)
        /// </summary>
        [XmlElement("accountNo")]
        public string AccountNo { get; set; }
    }
}
