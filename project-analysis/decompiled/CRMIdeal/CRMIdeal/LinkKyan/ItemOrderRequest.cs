using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ItemOrder", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ItemOrderRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public OrderHeader orderHeader;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public OrderDetails[] orderLineItem;

	public ItemOrderRequest()
	{
	}

	public ItemOrderRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, OrderHeader orderHeader, OrderDetails[] orderLineItem)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.orderHeader = orderHeader;
		this.orderLineItem = orderLineItem;
	}
}
