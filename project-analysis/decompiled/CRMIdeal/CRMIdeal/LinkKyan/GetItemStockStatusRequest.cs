using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemStockStatus", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemStockStatusRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string Barcode;

	public GetItemStockStatusRequest()
	{
	}

	public GetItemStockStatusRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.Barcode = Barcode;
	}
}
