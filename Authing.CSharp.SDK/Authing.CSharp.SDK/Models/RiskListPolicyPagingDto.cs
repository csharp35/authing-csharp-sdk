using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Authing.CSharp.SDK.Models
{
    /// <summary>
    /// RiskListPolicyPagingDto 的模型
    /// </summary>
    public partial class RiskListPolicyPagingDto
    {
        /// <summary>
        ///  记录总数
        /// </summary>
        [JsonProperty("totalCount")]
        public long  TotalCount {get;set;}
        /// <summary>
        ///  数据列表
        /// </summary>
        [JsonProperty("list")]
        public List<RiskListPolicyRespDto>  List {get;set;}
    }
}