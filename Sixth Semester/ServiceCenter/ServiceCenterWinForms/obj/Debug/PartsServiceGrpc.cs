// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: PartsService.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

public static partial class PartsService
{
  static readonly string __ServiceName = "PartsService";

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static class __Helper_MessageCache<T>
  {
    public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
  }

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
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

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Marshaller<global::PartRequest> __Marshaller_PartRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PartRequest.Parser));
  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Marshaller<global::PartResponse> __Marshaller_PartResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::PartResponse.Parser));

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::PartRequest, global::PartResponse> __Method_AddPart = new grpc::Method<global::PartRequest, global::PartResponse>(
      grpc::MethodType.Unary,
      __ServiceName,
      "AddPart",
      __Marshaller_PartRequest,
      __Marshaller_PartResponse);

  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  static readonly grpc::Method<global::PartRequest, global::PartResponse> __Method_UpdatePart = new grpc::Method<global::PartRequest, global::PartResponse>(
      grpc::MethodType.Unary,
      __ServiceName,
      "UpdatePart",
      __Marshaller_PartRequest,
      __Marshaller_PartResponse);

  /// <summary>Service descriptor</summary>
  public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
  {
    get { return global::PartsServiceReflection.Descriptor.Services[0]; }
  }

  /// <summary>Base class for server-side implementations of PartsService</summary>
  [grpc::BindServiceMethod(typeof(PartsService), "BindService")]
  public abstract partial class PartsServiceBase
  {
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::System.Threading.Tasks.Task<global::PartResponse> AddPart(global::PartRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::System.Threading.Tasks.Task<global::PartResponse> UpdatePart(global::PartRequest request, grpc::ServerCallContext context)
    {
      throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
    }

  }

  /// <summary>Client for PartsService</summary>
  public partial class PartsServiceClient : grpc::ClientBase<PartsServiceClient>
  {
    /// <summary>Creates a new client for PartsService</summary>
    /// <param name="channel">The channel to use to make remote calls.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public PartsServiceClient(grpc::ChannelBase channel) : base(channel)
    {
    }
    /// <summary>Creates a new client for PartsService that uses a custom <c>CallInvoker</c>.</summary>
    /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public PartsServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
    {
    }
    /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected PartsServiceClient() : base()
    {
    }
    /// <summary>Protected constructor to allow creation of configured clients.</summary>
    /// <param name="configuration">The client configuration.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected PartsServiceClient(ClientBaseConfiguration configuration) : base(configuration)
    {
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::PartResponse AddPart(global::PartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return AddPart(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::PartResponse AddPart(global::PartRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_AddPart, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::PartResponse> AddPartAsync(global::PartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return AddPartAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::PartResponse> AddPartAsync(global::PartRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_AddPart, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::PartResponse UpdatePart(global::PartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return UpdatePart(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual global::PartResponse UpdatePart(global::PartRequest request, grpc::CallOptions options)
    {
      return CallInvoker.BlockingUnaryCall(__Method_UpdatePart, null, options, request);
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::PartResponse> UpdatePartAsync(global::PartRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
    {
      return UpdatePartAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
    }
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public virtual grpc::AsyncUnaryCall<global::PartResponse> UpdatePartAsync(global::PartRequest request, grpc::CallOptions options)
    {
      return CallInvoker.AsyncUnaryCall(__Method_UpdatePart, null, options, request);
    }
    /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    protected override PartsServiceClient NewInstance(ClientBaseConfiguration configuration)
    {
      return new PartsServiceClient(configuration);
    }
  }

  /// <summary>Creates service definition that can be registered with a server</summary>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  public static grpc::ServerServiceDefinition BindService(PartsServiceBase serviceImpl)
  {
    return grpc::ServerServiceDefinition.CreateBuilder()
        .AddMethod(__Method_AddPart, serviceImpl.AddPart)
        .AddMethod(__Method_UpdatePart, serviceImpl.UpdatePart).Build();
  }

  /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
  /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
  /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
  /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
  [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
  public static void BindService(grpc::ServiceBinderBase serviceBinder, PartsServiceBase serviceImpl)
  {
    serviceBinder.AddMethod(__Method_AddPart, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PartRequest, global::PartResponse>(serviceImpl.AddPart));
    serviceBinder.AddMethod(__Method_UpdatePart, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::PartRequest, global::PartResponse>(serviceImpl.UpdatePart));
  }

}
#endregion
