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
    /// 22.3.5.票据交易明细信息查询响应主体
    /// </summary>
    [XmlRoot("CMBSDKPGK")]
    public class RS22_3_5 : CMBBase<RSINFO>, IResponse
    {
        /// <summary>
        /// NTBILDQY
        /// </summary>
        /// <returns></returns>
        public override string GetFUNNAM() => "NTBILDQY";
        /// <summary>
        /// 22.3.5.票据交易明细信息查询响应集合
        /// </summary>
        [XmlElement("NTBILDQYZ1")]
        public List<NTBILDQYZ1> List { get; set; }
    }
    /// <summary>
    /// 22.3.5.票据交易明细信息查询响应内容
    /// </summary>
    public class NTBILDQYZ1
    {
        /// <summary>
        /// 流程实例号	C(10)
        /// </summary>
        public string REQNBR { get; set; }
        /// <summary>
        /// 指令包序列号	C(35)
        /// </summary>
        public string SEQNBR { get; set; }
        /// <summary>
        /// 指令顺序号	C(35)
        /// </summary>
        public string SQRNBR { get; set; }
        /// <summary>
        /// 处理选择类	C(2)
        /// </summary>
        public string TRNTYP { get; set; }
        /// <summary>
        /// 票据号	C(20)
        /// </summary>
        public string BILNBR { get; set; }
        /// <summary>
        /// 票据标示号	C(20)
        /// </summary>
        public string BILSYN { get; set; }
        /// <summary>
        /// 票据种类	C(1)
        /// </summary>
        public string BILTYP { get; set; }
        /// <summary>
        /// 票面金额	M
        /// </summary>
        public decimal BILAMT { get; set; }
        /// <summary>
        /// 币种	C(2)
        /// </summary>
        public string CCYNBR { get; set; }
        /// <summary>
        /// 托管日期	D
        /// </summary>
        public string INPDAT { get; set; }
        /// <summary>
        /// 托管时间	T
        /// </summary>
        public string INPTIM { get; set; }
        /// <summary>
        /// 托管时间 由<see cref="INPDAT"/>和<see cref="INPTIM"/>组成
        /// </summary>
        [XmlIgnore]
        public DateTime? TrusteeshipTime
        {
            get
            {
                if (DateTime.TryParseExact(string.Format("{0}{1}", this.INPDAT, this.INPTIM),
                   new string[] { "yyyyMMdd", "yyyyMMddHHmmss" }, CultureInfo.CurrentCulture, DateTimeStyles.None, out DateTime tmp))
                {
                    return tmp;
                }
                return null;
            }
        }
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
        /// 出票日	D, 对应<see cref="ENDDAT"/>
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
        /// 银票出票人或商票付款人	Z(62)
        /// </summary>
        public string PAYNAM { get; set; }
        /// <summary>
        /// 出票人账号/付款人账号	C(35)
        /// </summary>
        public string PAYACC { get; set; }
        /// <summary>
        /// 付款行行号/付款人开户行行号	C(12)
        /// </summary>
        public string BRDNBR { get; set; }
        /// <summary>
        /// 付款行名称/付款人开户行名称	Z(62)
        /// </summary>
        public string PAYBNK { get; set; }
        /// <summary>
        /// 付款行地址	Z(62)
        /// </summary>
        public string PAYADR { get; set; }
        /// <summary>
        /// 收款人全称	Z(62)
        /// </summary>
        public string RCVNAM { get; set; }
        /// <summary>
        /// 收款人账号	C(35)
        /// </summary>
        public string RCVACC { get; set; }
        /// <summary>
        /// 收款人开户行	Z(62)
        /// </summary>
        public string RCVBNK { get; set; }
        /// <summary>
        /// 持票人名称	Z(62)
        /// </summary>
        public string OWNNAM { get; set; }
        /// <summary>
        /// 持票人账号	C(35)
        /// </summary>
        public string OWNACC { get; set; }
        /// <summary>
        /// 持票人开户行	Z(62)
        /// </summary>
        public string OWNBNK { get; set; }
        /// <summary>
        /// 背书标志	C(1)
        /// </summary>
        public string EDSFLG { get; set; }
        /// <summary>
        /// 背书次数	F(3,0)
        /// </summary>
        public string TRFTMS { get; set; }
        /// <summary>
        /// 交易状态	C(2)
        /// 0：提交成功，等待银行处理
        /// 1：授权成功,等待银行处理（预留）
        /// 2：提交成功，等待授权（预留）
        /// 6：被银行拒绝
        /// 7：指令提交成功，银行待处理
        /// 9：银行正在处理
        /// 15-指令提交成功，银行处理成功
        /// 16-指令提交成功，银行处理失败
        /// 17-指令提交成功，票据已出池
        /// 21 退回提交人修改
        /// </summary>
        public string RLTSTS { get; set; }
        /// <summary>
        /// 托管机构	C(6)	
        /// </summary>
        public string BRNNBR { get; set; }
        /// <summary>
        /// 错误码	C(10)
        /// </summary>
        public string RETCOD { get; set; }
        /// <summary>
        /// 错误描述	Z(192)
        /// </summary>
        public string RETMSG { get; set; }
    }
}
