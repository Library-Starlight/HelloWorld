using AlarmCenterGrpc.Core;
using Grpc.Net.Client;
using HelloWorld.Model;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static HelloWorld.DI.FrameworkDI;
using static HelloWorld.Model.Consts;

#region Proto

// 登录
var loginClient = AlarmCenterClient;
var user = UserId;
var passHash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(Password));
var pass = BitConverter.ToString(passHash).Replace("-", "").ToLower();
var result = ConnectService.Login(user, pass, GWDataCenter.ClientType.Dll);
var loginResult = loginClient.Login(new AlarmCenterGrpcServiceLibrary.LoginModel { User = user, Pwd = pass, CT = AlarmCenterGrpcServiceLibrary.ClientType.Dll });
Console.WriteLine(loginResult.Result);

//var client = new AlarmCenterGrpcServiceLibrary.AlarmCenterDatabase.AlarmCenterDatabaseClient(channel);
//var table = client.GetDataTableFromSQL(new AlarmCenterGrpcServiceLibrary.StringRequest
//{
//    StrSQL = "SELECT 1"
//});
//Console.WriteLine(table.Data);

//var equips = client.GetDataTableOfEquip(new Google.Protobuf.WellKnownTypes.Empty());
//Console.WriteLine(equips.Data);

//var client = new AlarmCenterGrpcServiceLibrary.AlarmCenter.AlarmCenterClient(channel);
//var i = client.GetYCPListStr(new AlarmCenterGrpcServiceLibrary.IntegerDefine { Result = 1 });

//Console.WriteLine(i.Result);
//Console.WriteLine(i.Description);
//Console.WriteLine(i.Code);
//Console.WriteLine(i);
//return;

#endregion

#region 代理
/*
try
{
    // 测试
    await GreetService.GreetAsync();

    // 登录
    var user = UserId;
    var passHash = SHA512.Create().ComputeHash(Encoding.UTF8.GetBytes(Password));
    var pass = BitConverter.ToString(passHash).Replace("-", "").ToLower();
    var result = ConnectService.Login(user, pass, GWDataCenter.ClientType.Dll);
    Console.WriteLine($"登录结果：{result}");

    var loginInfo = JsonConvert.DeserializeObject<LoginInfo>(result);
    var loginResult = JsonConvert.DeserializeObject<LoginResult>(loginInfo.result);

    MemoryCacheService.Set("accessToken", loginResult.Token, DateTime.Now.AddDays(1.0D));
    return;

    result = ConnectService.Listen();
    Console.WriteLine($"监听结果：{result}");

    // 订阅消息
    SubscribeMessage();

    // 数据库访问
    await DatabaseAccessAsync();

    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
*/
#endregion

#region 私有方法

/// <summary>
/// 订阅消息
/// </summary>
void SubscribeMessage()
{
    MessagePool.OnMessageReceived += (sender, e) =>
    {
        Console.WriteLine($"Received a message! [TIME] {e.ReceiveTime:yyyy-MM-dd HH:mm:ss} [MSG] {e.Message}");
    };
    MessagePool.OnError += (sender, e) =>
    {
        Console.WriteLine($"Received a error!   [TIME] {e.ReceiveTime:yyyy-MM-dd HH:mm:ss} [MSG] {e.Message}");
    };
}

/// <summary>
/// 数据库访问
/// </summary>
Task DatabaseAccessAsync()
    => Task.Factory.StartNew(() =>
    {
        var table = DatabaseService.GetDataTableOfYCP(1, 1);
        Console.WriteLine($"{table?.Rows.Count}");
    });

#endregion