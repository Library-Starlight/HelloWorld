// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: proto/deviceService.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace AlarmCenterGrpcServiceLibrary {
  public static partial class DeviceContract
  {
    static readonly string __ServiceName = "AlarmCenterGrpcServiceLibrary.DeviceContract";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo> __Marshaller_AlarmCenterGrpcServiceLibrary_DeviceDllInfo = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo.Parser));
    static readonly grpc::Marshaller<global::AlarmCenterGrpcServiceLibrary.StringResult> __Marshaller_AlarmCenterGrpcServiceLibrary_StringResult = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::AlarmCenterGrpcServiceLibrary.StringResult.Parser));

    static readonly grpc::Method<global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo, global::AlarmCenterGrpcServiceLibrary.StringResult> __Method_UploadDeviceDll = new grpc::Method<global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo, global::AlarmCenterGrpcServiceLibrary.StringResult>(
        grpc::MethodType.Unary,
        __ServiceName,
        "UploadDeviceDll",
        __Marshaller_AlarmCenterGrpcServiceLibrary_DeviceDllInfo,
        __Marshaller_AlarmCenterGrpcServiceLibrary_StringResult);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::AlarmCenterGrpcServiceLibrary.DeviceServiceReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of DeviceContract</summary>
    [grpc::BindServiceMethod(typeof(DeviceContract), "BindService")]
    public abstract partial class DeviceContractBase
    {
      public virtual global::System.Threading.Tasks.Task<global::AlarmCenterGrpcServiceLibrary.StringResult> UploadDeviceDll(global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for DeviceContract</summary>
    public partial class DeviceContractClient : grpc::ClientBase<DeviceContractClient>
    {
      /// <summary>Creates a new client for DeviceContract</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public DeviceContractClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for DeviceContract that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public DeviceContractClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected DeviceContractClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected DeviceContractClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::AlarmCenterGrpcServiceLibrary.StringResult UploadDeviceDll(global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadDeviceDll(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::AlarmCenterGrpcServiceLibrary.StringResult UploadDeviceDll(global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_UploadDeviceDll, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::AlarmCenterGrpcServiceLibrary.StringResult> UploadDeviceDllAsync(global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return UploadDeviceDllAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::AlarmCenterGrpcServiceLibrary.StringResult> UploadDeviceDllAsync(global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_UploadDeviceDll, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override DeviceContractClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new DeviceContractClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(DeviceContractBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_UploadDeviceDll, serviceImpl.UploadDeviceDll).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, DeviceContractBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_UploadDeviceDll, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::AlarmCenterGrpcServiceLibrary.DeviceDllInfo, global::AlarmCenterGrpcServiceLibrary.StringResult>(serviceImpl.UploadDeviceDll));
    }

  }
}
#endregion
