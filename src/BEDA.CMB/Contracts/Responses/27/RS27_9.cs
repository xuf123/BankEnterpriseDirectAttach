﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CMB.Contracts.Responses
{
    /// <summary>
    /// 27.9.维护/终止内部户限额响应主体
    /// </summary>
    [XmlRoot("CMBSDKPGK")]
    public class RS27_9 : CMBBase<RSINFO>, IResponse
    {
        /// <summary>
        /// NTILMMNT
        /// </summary>
        /// <returns></returns>
        public override string GetFUNNAM() => "NTILMMNT";
        /// <summary>
        /// 27.9.维护/终止内部户限额响应内容
        /// </summary>
        public NTOPRRTNZ NTOPRRTNZ { get; set; }
    }
}
