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
    /// 12.9.1.结售汇分拆名单查询响应主体
    /// </summary>
    [XmlRoot("CMBSDKPGK")]
    public class RS12_9_1 : CMBBase<RSINFO>, IResponse
    {
        /// <summary>
        /// NTCTRQBK
        /// </summary>
        /// <returns></returns>
        public override string GetFUNNAM() => "NTCTRQBK";
        /// <summary>
        /// 12.9.1.结售汇分拆名单查询响应内容
        /// </summary>
        public NTCRTQBKZ NTCRTQBKZ { get; set; }
    }
    /// <summary>
    /// 12.9.1.结售汇分拆名单查询响应内容
    /// </summary>
    public class NTCRTQBKZ
    {
        /// <summary>
        /// 证件签发国家	C(3)	A.8国家地区代码表
        /// </summary>
        public string CNRCOD { get; set; }
        /// <summary>
        /// 证件类型	C(3)
        /// P01 居民身份证
        /// P02 学生证 
        /// P03 临时居民身份证
        /// P04 军人证 
        /// P08 武警证 
        /// P16 居民户口簿
        /// P18 通行证（废止）
        /// P19 回乡证（废止）
        /// P20 港澳居民来往内地通行证
        /// P21 回乡台湾居民来往大陆通行证
        /// P22 监护人证件
        /// P23 居住证
        /// P24 暂住证 
        /// P31 护照
        /// P99 个人其他证件
        /// </summary>
        public string CTFTYP { get; set; }
        /// <summary>
        /// 证件号码   	Z(30)
        /// </summary>
        public string CTFIDC { get; set; }
        /// <summary>
        /// 结汇分拆标志	C(1)	Y:黑名单 N: 非黑名单
        /// </summary>
        public string BLKFLG { get; set; }
        /// <summary>
        /// 售汇分拆标志	C(1)	Y:黑名单 N: 非黑名单
        /// </summary>
        public string BLKFL2 { get; set; }
    }
}
