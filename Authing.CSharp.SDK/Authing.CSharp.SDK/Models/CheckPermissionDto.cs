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
    /// CheckPermissionDto 的模型
    /// </summary>
    public partial class CheckPermissionDto
    {
        /// <summary>
        ///  数据资源路径列表,
        /// </summary>
        [JsonProperty("resources")]
        public List<string>  Resources {get;set;}
        /// <summary>
        ///  数据资源权限操作, read、get、write 等动作
        /// </summary>
        [JsonProperty("action")]
        public string  Action {get;set;}
        /// <summary>
        ///  用户 ID
        /// </summary>
        [JsonProperty("userId")]
        public string  UserId {get;set;}
        /// <summary>
        ///  权限空间 Code
        /// </summary>
        [JsonProperty("namespaceCode")]
        public string  NamespaceCode {get;set;}
    }
}