using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetCustomerTransactionResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerTransactionResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfCustomerTransaction GetCustomerTransactionResult;

	public GetCustomerTransactionResponse()
	{
	}

	public GetCustomerTransactionResponse(ResponseDataOfCustomerTransaction GetCustomerTransactionResult)
	{
		this.GetCustomerTransactionResult = GetCustomerTransactionResult;
	}
}
