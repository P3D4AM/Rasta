using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTaxChargeAmount", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTaxChargeAmountRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	public GetTaxChargeAmountRequest()
	{
	}

	public GetTaxChargeAmountRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
	}
}
