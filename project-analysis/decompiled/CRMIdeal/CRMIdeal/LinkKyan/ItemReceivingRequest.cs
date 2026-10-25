using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ItemReceiving", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ItemReceivingRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ReceiveHeader receiveHeader;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public OrderDetails[] orderLineItem;

	public ItemReceivingRequest()
	{
	}

	public ItemReceivingRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReceiveHeader receiveHeader, OrderDetails[] orderLineItem)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.receiveHeader = receiveHeader;
		this.orderLineItem = orderLineItem;
	}
}
