using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTransactionByRetailStoreIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTransactionByRetailStoreIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfReceiptDsInfModel GetTransactionByRetailStoreIDResult;

	public GetTransactionByRetailStoreIDResponse()
	{
	}

	public GetTransactionByRetailStoreIDResponse(ResponseDataOfReceiptDsInfModel GetTransactionByRetailStoreIDResult)
	{
		this.GetTransactionByRetailStoreIDResult = GetTransactionByRetailStoreIDResult;
	}
}
