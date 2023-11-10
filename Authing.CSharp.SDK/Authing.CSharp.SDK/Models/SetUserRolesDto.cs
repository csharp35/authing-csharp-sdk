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
    /// SetUserRolesDto 的模型
    /// </summary>
    public partial class SetUserRolesDto
    {
        /// <summary>
        ///  角色 IDs
        /// </summary>
        [JsonProperty("roleIds")]
        public List<string>  RoleIds {get;set;}
        /// <summary>
        ///  用户的唯一标志，可以是用户 ID、用户名、邮箱、手机号、externalId、在外部身份源的 ID，详情见 userIdType 字段的说明。默认为用户 id 。
        /// </summary>
        [JsonProperty("userId")]
        public string  UserId {get;set;}
    }
}