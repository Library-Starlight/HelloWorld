using AlarmCenterGrpcServiceLibrary;
using Grpc.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        private static string _id;

        private static Metadata _headers;

        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine($"登录");
                await LoginAsync();

                Console.WriteLine();
                Console.WriteLine($"数据库操作：");
                await OperateDatabaseAsync();

                //Console.WriteLine();
                //Console.WriteLine($"设备操作：");
                //await GetEquipAsync();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        static async Task LoginAsync()
        {
            // 测试
            var channel = new Channel("127.0.0.1:4000", ChannelCredentials.Insecure);
            var greeterClient = new Greeter.GreeterClient(channel);
            var helloRequest = new HelloRequest
            {
                Name = "WebServer",
            };
            var helloReply = await greeterClient.SayHelloAsync(helloRequest);
            _id = helloReply.Message;
            _headers = new Metadata { { "connectId", helloReply.Message } };

            // 登录
            var loginClient = new AlarmCenter.AlarmCenterClient(channel);
            var loginRequest = new LoginModel
            {
                User = "ganwei",
                Pwd = "4209e92ed8bfe928c6abcc7592fbd7c1f1d6c59b182a47f376033bef54363567fb61708d83e57b8ae59f184d2866403eff0443538a832753c0476b550a72f24c",
                CT = ClientType.Dll,
            };

            var reply = await loginClient.LoginAsync(loginRequest, _headers);
            Console.WriteLine($"登录结果：{reply.Code}");

            var msg = JObject.Parse(reply.Result);
            _headers.Add("Authorization", $"Bearer {msg["token"]}");
        }

        /// <summary>
        /// 表
        /// </summary>
        static async Task OperateDatabaseAsync()
        {
            var channel = new Channel("127.0.0.1:4000", ChannelCredentials.Insecure);
            var databaseClient = new AlarmCenterDatabase.AlarmCenterDatabaseClient(channel);

            //// 查询语句
            //var reply1 = await databaseClient.GetDataTableFromSQLAsync(new StringRequest { StrSQL = "SELECT 1", }, _headers);
            //Console.WriteLine(reply1.Data);

            // 执行语句
            var reply2 = await databaseClient.ExecuteSQLAsync(new StringRequest { StrSQL = "UPDATE Equip SET sta_no = 0" }, _headers);
            Console.WriteLine(reply2.Result);

            //// 设备表
            //var result1 = await databaseClient.GetDataTableOfEquipAsync(new Google.Protobuf.WellKnownTypes.Empty(), _headers);
            //Console.WriteLine(result1.Data);

            //// 遥测表
            //var result2 = await databaseClient.GetDataTableOfYCPAsync(new EquipStaRequest(), _headers);
            //Console.WriteLine(result2.Data);

            //// 遥信表
            //var result3 = await databaseClient.GetDataTableOfYXPAsync(new EquipStaRequest(), _headers);
            //Console.WriteLine(result3.Data);

            // 设置表
            //var result4 = await databaseClient.GetDataTableOfSetParmAsync(new EquipStaRequest(), _headers);
            //Console.WriteLine(result4.Data);
        }

        /// <summary>
        /// 设备
        /// </summary>
        static async Task GetEquipAsync()
        {
            var channel = new Channel("127.0.0.1:4000", ChannelCredentials.Insecure);
            var alarmCenterClient = new AlarmCenter.AlarmCenterClient(channel);

            //// 获取遥测值
            var result1 = await alarmCenterClient.GetYCValueAsync(new GetYCAlarmStateRequest { IEquipNo = 11122, IYcpNo = 1, });
            var result2 = await alarmCenterClient.GetYCValueAsync(new GetYCAlarmStateRequest { IEquipNo = 11122, IYcpNo = 4, });
            var result3 = await alarmCenterClient.GetYCValueAsync(new GetYCAlarmStateRequest { IEquipNo = 11127, IYcpNo = 5, });
            var result4 = await alarmCenterClient.GetYXValueAsync(new GetYXValueRequest { IEquipNo = 11122, IYxpNo = 1, });
            var result5 = await alarmCenterClient.GetYXValueAsync(new GetYXValueRequest { IEquipNo = 11122, IYxpNo = 2, });
            Console.WriteLine(result1.Result);
            Console.WriteLine(result2.Result);
            Console.WriteLine(result3.Result);
            Console.WriteLine(result4.Result);
            Console.WriteLine(result5.Result);

            // 获取设备列表
            var equipListReply = await alarmCenterClient.GetEquipListStrAsync(new Google.Protobuf.WellKnownTypes.Empty(), _headers);
            Console.WriteLine(equipListReply.Result);
        }
    }
}
