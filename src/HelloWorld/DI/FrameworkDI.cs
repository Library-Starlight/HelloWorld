using AlarmCenterGrpcServiceLibrary;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.DI
{
    public static class FrameworkDI
    {
        /// <summary>
        /// 通道
        /// </summary>
        public static Channel Channel => new Channel("127.0.0.1:4000", ChannelCredentials.Insecure);

        /// <summary>
        /// 欢迎
        /// </summary>
        public static Greeter.GreeterClient GreeterClient => new Greeter.GreeterClient(Channel);

        /// <summary>
        /// AlarmCenter客户端
        /// </summary>
        public static AlarmCenter.AlarmCenterClient AlarmCenterClient => new AlarmCenter.AlarmCenterClient(Channel);

        /// <summary>
        /// 数据库客户端
        /// </summary>
        public static AlarmCenterDatabase.AlarmCenterDatabaseClient AlarmCenterDatabaseClient => new AlarmCenterDatabase.AlarmCenterDatabaseClient(Channel);
    }
}
