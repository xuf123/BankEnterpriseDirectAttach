﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CIB.Contracts.Responses
{
    /// <summary>
    /// 3.10.5跨行账户他行账户收款响应主体
    /// </summary>
    public class V1_CRSGATHERTRNRS : IResponse
    {
        /// <summary>
        /// 3.10.5跨行账户他行账户收款响应主体
        /// </summary>
        public CRSGATHERTRNRS CRSGATHERTRNRS { get; set; }
    }
    /// <summary>
    /// 3.10.5跨行账户他行账户收款响应主体
    /// </summary>
    public class CRSGATHERTRNRS : BIZRSBASE
    {
        /// <summary>
        /// 3.10.5跨行账户他行账户收款响应内容
        /// </summary>
        [XmlElement(Order = 2)]
        public CRSGATHERTRN_RSBODY RSBODY { get; set; }
    }
    /// <summary>
    /// 3.10.5跨行账户他行账户收款响应内容
    /// </summary>
    public class CRSGATHERTRN_RSBODY
    {
        /// <summary>
        /// 付款账户信息
        /// </summary>
        [XmlElement(Order = 0)]
        public CORRELATEACCT ACCTFROM { get; set; }
        /// <summary>
        /// 收款账户信息
        /// </summary>
        [XmlElement(Order = 1)]
        public ACCT ACCTTO { get; set; }
        /// <summary>
        /// 业务种类编码 见附录《他行核心业务种类代码类型》
        /// 00100  电费
        /// 00200  水暖费
        /// 00300  煤气费
        /// 00400  电话费
        /// 00500  通讯费
        /// 00600  保险费
        /// 00700  房屋管理费
        /// 00800  代理服务费
        /// 00900  学教费
        /// 01000  有线电视费
        /// 01100  企业管理费用
        /// 01200  薪金报酬
        /// 02025  贷款还款房贷类	
        /// 02026  贷款还款车贷类
        /// 02027  贷款还款信用卡类
        /// 09001  其他
        /// </summary>
        [XmlElement(Order = 2)]
        public string BUSINESSTYPE { get; set; }
        /// <summary>
        /// 交易金额，decimal(15,2) 即整数位最长13位，小数位2位
        /// </summary>
        [XmlElement(Order = 3)]
        public decimal TRNAMT { get; set; }
        /// <summary>
        /// 用途,60位
        /// </summary>
        [XmlElement(Order = 4)]
        public string PURPOSE { get; set; }
        /// <summary>
        /// 交易日期，格式yyyy-MM-dd 必输
        /// </summary>
        [XmlIgnore]
        public DateTime DTTRN { get; set; }
        /// <summary>
        /// 交易日期，格式yyyy-MM-dd ,对应<see cref="DTTRN"/> 必输
        /// </summary>
        [XmlElement("DTTRN", Order = 5)]
        public string DTTRNStr
        {
            get
            {
                return this.DTTRN.ToString("yyyy-MM-dd");
            }
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    this.DTTRN = tmp;
                }
            }
        }
        /// <summary>
        /// 指令处理状态
        /// </summary>
        [XmlElement(Order = 6)]
        public XFERPRCSTS XFERPRCSTS { get; set; }
    }
}
