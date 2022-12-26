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
    /// CreateAsaAccountDto 的模型
    /// </summary>
    public partial class CreateAsaAccountDto
    {
        /// <summary>
        ///  账号信息，一般为包含 "account", "password" key 的键值对
        /// </summary>
        [JsonProperty("accountInfo")]
        public object  AccountInfo {get;set;}
        /// <summary>
        ///  所属应用 ID
        /// </summary>
        [JsonProperty("appId")]
        public string  AppId {get;set;}
    }
}