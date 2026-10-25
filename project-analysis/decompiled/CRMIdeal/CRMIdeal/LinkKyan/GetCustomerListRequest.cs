using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerList", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerListRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string EndDate;

	public GetCustomerListRequest()
	{
	}

	public GetCustomerListRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
	}
}
