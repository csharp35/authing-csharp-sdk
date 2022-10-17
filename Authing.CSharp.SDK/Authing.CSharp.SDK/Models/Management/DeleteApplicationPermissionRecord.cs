using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Authing.CSharp.SDK.Models.Management;

   namespace Authing.CSharp.SDK.Models.Management
{
/// <summary>
/// DeleteApplicationPermissionRecord 的模型
/// </summary>
public partial class DeleteApplicationPermissionRecord
{
    /// <summary>
    ///  授权主体列表，最多 10 条
    /// </summary>
    [JsonProperty("list")]
    public List<DeleteApplicationPermissionRecordItem>  List {get;set;}
    /// <summary>
    ///  应用 ID
    /// </summary>
    [JsonProperty("appId")]
    public string  AppId {get;set;}
}
}