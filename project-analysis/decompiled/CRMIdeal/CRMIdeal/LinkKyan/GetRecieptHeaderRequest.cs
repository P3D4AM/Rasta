using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetRecieptHeader", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetRecieptHeaderRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string RecieptBarcode;

	public GetRecieptHeaderRequest()
	{
	}

	public GetRecieptHeaderRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcode)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.RecieptBarcode = RecieptBarcode;
	}
}
