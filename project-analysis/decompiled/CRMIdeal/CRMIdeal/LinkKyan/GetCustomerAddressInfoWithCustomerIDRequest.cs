using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerAddressInfoWithCustomerID", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerAddressInfoWithCustomerIDRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int customerID;

	public GetCustomerAddressInfoWithCustomerIDRequest()
	{
	}

	public GetCustomerAddressInfoWithCustomerIDRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.customerID = customerID;
	}
}
