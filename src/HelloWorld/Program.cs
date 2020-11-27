using AlarmCenterGrpcServiceLibrary;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelloWorld.DI.FrameworkDI;

namespace HelloWorld
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await LoginAsync();
        }

        /// <summary>
        /// 登录
        /// </summary>
        static async Task LoginAsync()
        {
            using var channel = new GrpcChannel("127.0.0.1:4000", ChannelCredentials.Insecure);

            var helloRequest = new HelloRequest
            {
                Name = "Hello World!",
            };

            var helloReply = await GreeterClient.SayHelloAsync(helloRequest);
            Console.WriteLine(helloReply.Message);
        }

        /// <summary>
        /// 设备
        /// </summary>
        static void Equip()
        {

        }

        /// <summary>
        /// 表
        /// </summary>
        static void Table()
        {

        }
    }
}
