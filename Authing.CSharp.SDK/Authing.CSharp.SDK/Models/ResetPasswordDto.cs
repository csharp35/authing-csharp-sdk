using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Authing.CSharp.SDK.Models;

   namespace Authing.CSharp.SDK.Models
{
/// <summary>
/// ResetPasswordDto 的模型
/// </summary>
public partial class ResetPasswordDto
{
    /// <summary>
    ///  密码
    /// </summary>
    [JsonProperty("password")]
    public string  Password {get;set;}
    /// <summary>
    ///  重置密码的 token
    /// </summary>
    [JsonProperty("passwordResetToken")]
    public string  PasswordResetToken {get;set;}
    /// <summary>
    ///  密码加密类型，支持 sm2 和 rsa。默认可以不加密。
/// - `none`: 不对密码进行加密，使用明文进行传输。
/// - `rsa`: 使用 RSA256 算法对密码进行加密，需要使用 Authing 服务的 RSA 公钥进行加密，请阅读**介绍**部分了解如何获取 Authing 服务的 RSA256 公钥。
/// - `sm2`: 使用 [国密 SM2 算法](https://baike.baidu.com/item/SM2/15081831) 对密码进行加密，需要使用 Authing 服务的 SM2 公钥进行加密，请阅读**介绍**部分了解如何获取 Authing 服务的 SM2 公钥。
/// 
    /// </summary>
    [JsonProperty("passwordEncryptType")]
    public passwordEncryptType  PasswordEncryptType {get;set;}
}
public partial class ResetPasswordDto
 {
    /// <summary>
    ///  密码加密类型，支持 sm2 和 rsa。默认可以不加密。
/// - `none`: 不对密码进行加密，使用明文进行传输。
/// - `rsa`: 使用 RSA256 算法对密码进行加密，需要使用 Authing 服务的 RSA 公钥进行加密，请阅读**介绍**部分了解如何获取 Authing 服务的 RSA256 公钥。
/// - `sm2`: 使用 [国密 SM2 算法](https://baike.baidu.com/item/SM2/15081831) 对密码进行加密，需要使用 Authing 服务的 SM2 公钥进行加密，请阅读**介绍**部分了解如何获取 Authing 服务的 SM2 公钥。
/// 
    /// </summary>
    public enum passwordEncryptType
     {
         [EnumMember(Value="sm2")]
        SM2,
         [EnumMember(Value="rsa")]
        RSA,
         [EnumMember(Value="none")]
        NONE,
    }
}
}