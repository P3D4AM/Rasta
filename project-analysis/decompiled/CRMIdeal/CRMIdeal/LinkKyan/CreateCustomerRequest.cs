using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CreateCustomer", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CreateCustomerRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public Customer NewCustomer;

	public CreateCustomerRequest()
	{
	}

	public CreateCustomerRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.NewCustomer = NewCustomer;
	}
}
