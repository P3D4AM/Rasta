using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CreateCustomerToRS", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CreateCustomerToRSRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public Customer NewCustomer;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int RetailStoreID;

	public CreateCustomerToRSRequest()
	{
	}

	public CreateCustomerToRSRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer, int RetailStoreID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.NewCustomer = NewCustomer;
		this.RetailStoreID = RetailStoreID;
	}
}
