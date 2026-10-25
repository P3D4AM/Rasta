using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTemplateItemInfo", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTemplateItemInfoRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string Barcode;

	public GetTemplateItemInfoRequest()
	{
	}

	public GetTemplateItemInfoRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.Barcode = Barcode;
	}
}
