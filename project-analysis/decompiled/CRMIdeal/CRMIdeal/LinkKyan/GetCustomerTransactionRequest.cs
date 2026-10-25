using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerTransaction", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerTransactionRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string EndDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public string customerID;

	public GetCustomerTransactionRequest()
	{
	}

	public GetCustomerTransactionRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, string customerID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
		this.customerID = customerID;
	}
}
