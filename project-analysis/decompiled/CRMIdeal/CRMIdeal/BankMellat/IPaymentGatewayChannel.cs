using System;
using System.CodeDom.Compiler;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace CRMIdeal.BankMellat;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public interface IPaymentGatewayChannel : IPaymentGateway, IClientChannel, IContextChannel, IChannel, ICommunicationObject, IExtensibleObject<IContextChannel>, IDisposable
{
}
