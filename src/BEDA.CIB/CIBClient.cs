﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEDA.CIB.Contracts.Requests;
using BEDA.CIB.Contracts.Responses;
using BEDA.Utils;
using RestSharp;

namespace BEDA.CIB
{
    /// <summary>
    /// 兴业银行客户端
    /// </summary>
    public class CIBClient : Client, ICIBClient
    {
        /// <summary>
        /// 兴业银行调用构造,默认调用127.0.0.1:8007
        /// </summary>
        public CIBClient()
            : this("127.0.0.1", 8007)
        {
        }
        /// <summary>
        /// 兴业银行调用构造
        /// </summary>
        /// <param name="host">ip地址或域名</param>
        /// <param name="port">端口号</param>
        /// <param name="scheme">请求协议，默认http</param>
        /// <param name="encoding">数据编码方式，默认gb2312</param>
        public CIBClient(string host, int port, string scheme = "http", string encoding = "gb2312")
            : base(host, port, scheme, encoding)
        {
        }
        /// <summary>
        /// 发起业务请求 注意必定返回响应内容
        /// </summary>
        /// <typeparam name="TRq"></typeparam>
        /// <typeparam name="TRs"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public FOXRS<TRs> Execute<TRq, TRs>(FOXRQ<TRq, TRs> request)
            where TRq : IRequest<TRs>
            where TRs : IResponse, new()
        {
            return this.ExecuteInner<FOXRQ<TRq, TRs>, FOXRS<TRs>>(request);
        }
        /// <summary>
        /// 发起业务请求 注意必定返回响应内容
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public FOXRS Execute(FOXRQ request)
        {
            return this.ExecuteInner<FOXRQ, FOXRS>(request);
        }
        /// <summary>
        /// 发起业务请求 注意必定返回响应内容
        /// </summary>
        /// <typeparam name="TRq"></typeparam>
        /// <typeparam name="TRs"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FOXRS<TRs>> ExecuteAsync<TRq, TRs>(FOXRQ<TRq, TRs> request)
            where TRq : IRequest<TRs>
            where TRs : IResponse, new()
        {
            return await this.ExecuteInnerAsync<FOXRQ<TRq, TRs>, FOXRS<TRs>>(request).ConfigureAwait(false);
        }
        /// <summary>
        /// 发起业务请求 注意必定返回响应内容
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FOXRS> ExecuteAsync(FOXRQ request)
        {
            return await this.ExecuteInnerAsync<FOXRQ, FOXRS>(request).ConfigureAwait(false);
        }
        private TRs ExecuteInner<TRq, TRs>(TRq rq)
            where TRq : FOXRQ
            where TRs : FOXRS, new()
        {
            var restRequest = this.GetRestRequest(rq);
            var restResponse = this.RestClient.Execute(restRequest);
            return this.GetResponse<TRs>(restResponse);
        }
        private async Task<TRs> ExecuteInnerAsync<TRq, TRs>(TRq rq)
            where TRq : FOXRQ
            where TRs : FOXRS, new()
        {
            var restRequest = this.GetRestRequest(rq);
            var restResponse = await this.RestClient.ExecuteTaskAsync(restRequest).ConfigureAwait(false);
            return this.GetResponse<TRs>(restResponse);
        }
        private IRestRequest GetRestRequest<TRq>(TRq request)
            where TRq : FOXRQ
        {
            var xml = XmlHelper.Serializer(request, showDeclaration: false, removeDefaultNameSpace: true);
            request.RequestContent = xml;
            var restRequest = new RestRequest(Method.POST);
            restRequest.AddParameter(new Parameter
            {
                Type = ParameterType.RequestBody,
                DataFormat = DataFormat.None,
                Value = xml,
                Name = ""
            });
            return restRequest;
        }
        private TRs GetResponse<TRs>(IRestResponse response)
            where TRs : FOXRS, new()
        {
            response.SetResponseEncoding();
            var rs = XmlHelper.Deserialize<TRs>(response.Content);
            if (rs == null)
            {
                rs = new TRs();
            }
            rs.ResponseContent = response.Content;
            return rs;
        }
    }
}
