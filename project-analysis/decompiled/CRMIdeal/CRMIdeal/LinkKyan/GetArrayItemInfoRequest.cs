using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetArrayItemInfo", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetArrayItemInfoRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string[] barcodes;

	public GetArrayItemInfoRequest()
	{
	}

	public GetArrayItemInfoRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcodes)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.barcodes = barcodes;
	}
}
