using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CustomerCreditOperations", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CustomerCreditOperationsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int customerID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public decimal credit;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public OperationCredit operationCredit;

	public CustomerCreditOperationsRequest()
	{
	}

	public CustomerCreditOperationsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID, decimal credit, OperationCredit operationCredit)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.customerID = customerID;
		this.credit = credit;
		this.operationCredit = operationCredit;
	}
}
