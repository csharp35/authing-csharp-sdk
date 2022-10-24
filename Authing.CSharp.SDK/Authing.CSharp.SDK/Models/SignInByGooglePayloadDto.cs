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
/// SignInByGooglePayloadDto 的模型
/// </summary>
public partial class SignInByGooglePayloadDto
{
    /// <summary>
    ///  Google 移动端社会化登录获取到的 code
    /// </summary>
    [JsonProperty("code")]
    public string  Code {get;set;}
}
}