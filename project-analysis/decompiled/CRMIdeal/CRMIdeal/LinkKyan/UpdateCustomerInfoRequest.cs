using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "UpdateCustomerInfo", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class UpdateCustomerInfoRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public Customer UpdattedCustomer;

	public UpdateCustomerInfoRequest()
	{
	}

	public UpdateCustomerInfoRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer UpdattedCustomer)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.UpdattedCustomer = UpdattedCustomer;
	}
}
