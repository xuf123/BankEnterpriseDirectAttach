﻿using BEDA.CMB.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BEDA.CMB.Contracts.Requests
{
    /// <summary>
    /// 22.1.1.票据挂失止付查询请求主体
    /// </summary>
    [XmlRoot("CMBSDKPGK")]
    public class RQ22_1_1 : CMBBase<RQINFO>, IRequest<RS22_1_1>
    {
        /// <summary>
        /// NTBILLQY
        /// </summary>
        /// <returns></returns>
        public override string GetFUNNAM() => "NTBILLQY";
        /// <summary>
        /// 22.1.1.票据挂失止付查询请求内容
        /// </summary>
        public NTBILLQYX1 NTBILLQYX1 { get; set; }
        /// <summary>
        /// 22.1.1.票据挂失止付查询请求集合
        /// </summary>
        [XmlElement("NTBILLQYX2")]
        public List<NTBILLQYX2> List { get; set; }
    }
    /// <summary>
    /// 22.1.1.票据挂失止付查询请求内容
    /// </summary>
    public class NTBILLQYX1
    {
        /// <summary>
        /// 查询账号分行号	C(2)
        /// </summary>
        public string BBKNBR { get; set; }
        /// <summary>
        /// 查询账号	C(35)
        /// </summary>
        public string ACCNBR { get; set; }
    }
    /// <summary>
    /// 22.1.1.票据挂失止付查询请求内容
    /// </summary>
    public class NTBILLQYX2
    {
        /// <summary>
        /// 流水号	C(10)   全数字格式
        /// </summary>
        public string SEQNBR { get; set; }
        /// <summary>
        /// 票据号码	C(20)
        /// </summary>
        public string BILNBR { get; set; }
        /// <summary>
        /// 票据种类	C(3)    新增参数NCBILTYP:‘100’银票‘200’商票
        /// </summary>
        public string BILTYP { get; set; }
        /// <summary>
        /// 票面金额	M
        /// </summary>
        public decimal BILAMT { get; set; }
        /// <summary>
        /// 出票日	D
        /// </summary>
        [XmlIgnore]
        public DateTime OPNDAT { get; set; }
        /// <summary>
        /// 出票日	D, 对应<see cref="OPNDAT"/>
        /// </summary>
        [XmlElement("OPNDAT")]
        public string OPNDATStr
        {
            get
            {
                return this.OPNDAT.ToString("yyyyMMdd");
            }
            set
            {
                if (DateTime.TryParseExact(value, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    this.OPNDAT = tmp;
                }
            }
        }
        /// <summary>
        /// 到期日	D
        /// </summary>
        [XmlIgnore]
        public DateTime ENDDAT { get; set; }
        /// <summary>
        /// 到期日	D, 对应<see cref="ENDDAT"/>
        /// </summary>
        [XmlElement("ENDDAT")]
        public string ENDDATStr
        {
            get
            {
                return this.ENDDAT.ToString("yyyyMMdd");
            }
            set
            {
                if (DateTime.TryParseExact(value, "yyyyMMdd", CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    this.ENDDAT = tmp;
                }
            }
        }
        /// <summary>
        /// 银行码	C(3)    参考ECDS查询联行号取银行列表逻辑
        /// </summary>
        public string BNKNBR { get; set; }
        /// <summary>
        /// 银票付款行行号或商票付款人开户行行号	F(12)   参考ECDS查询联行号取银行列表逻辑
        /// </summary>
        public string BRDNBR { get; set; }
        /// <summary>
        /// 银票承兑行或商票付款人开户行	Z(62)   参考ECDS查询联行号取银行列表逻辑
        /// </summary>
        public string BNKNAM { get; set; }
        /// <summary>
        /// 银票出票人或商票付款人	Z(62)
        /// </summary>
        public string PAYNAM { get; set; }
        /// <summary>
        /// 收款人	Z(62)
        /// </summary>
        public string RCVNAM { get; set; }
        /// <summary>
        /// 付款人客户号	C(10)
        /// </summary>
        public string PAYCLT { get; set; }
        /// <summary>
        /// 付款人企业代码	C(12)
        /// </summary>
        public string CORIDT { get; set; }
        /// <summary>
        /// 付款人账号	C(35)
        /// </summary>
        public string PAYACC { get; set; }
    }
}
