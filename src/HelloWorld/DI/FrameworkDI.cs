using AlarmCenterGrpc.Core;
using AlarmCenterGrpc.Core.Interfaces.Services;
using AlarmCenterGrpc.Core.Services;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlarmCenterGrpcServiceLibrary.AlarmCenter;

namespace HelloWorld.DI
{
    public static class FrameworkDI
    {
        /// <summary>
        /// 服务集合
        /// </summary>
        public static ServiceCollection Services { get; set; }

        /// <summary>
        /// 服务提供
        /// </summary>
        public static IServiceProvider IoTServiceProvider { get; set; }

        #region 代理

        /// <summary>
        /// Hello World
        /// </summary>
        public static IGreetService GreetService => IoTServiceProvider.GetService<IGreetService>();

        /// <summary>
        /// 连接服务
        /// </summary>
        public static IConnectService ConnectService => IoTServiceProvider.GetService<IConnectService>();

        /// <summary>
        /// 消息接收服务
        /// </summary>
        public static MessageReceiverPool MessagePool => IoTServiceProvider.GetService<MessageReceiverPool>();

        /// <summary>
        /// 数据库访问服务
        /// </summary>
        public static IAlarmCenterDatabaseService DatabaseService => IoTServiceProvider.GetService<IAlarmCenterDatabaseService>();

        /// <summary>
        /// 缓存
        /// </summary>
        public static IMemoryCacheService MemoryCacheService => IoTServiceProvider.GetService<IMemoryCacheService>();

        #endregion

        #region 客户端

        /// <summary>
        /// Grpc信道
        /// </summary>
        public static GrpcChannel Channel => GrpcChannel.ForAddress("http://localhost:4000");

        /// <summary>
        /// 客户端
        /// </summary>
        public static AlarmCenterClient AlarmCenterClient => new AlarmCenterClient(Channel);

        #endregion
    }
}
