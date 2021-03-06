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
    /// 代保管票据托收维护申请响应内容
    /// </summary>
    [XmlRoot("stream")]
    public class RS_DLBDTWSQ : RsBase
    {
        /// <summary>
        /// 批次号varchar(8)
        /// </summary>
        [XmlElement("batNo")]
        public string BatNo { get; set; }
    }
}
