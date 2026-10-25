using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTransactionWithDs_info_2Response", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTransactionWithDs_info_2Response
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfReceiptDsInfModel GetTransactionWithDs_info_2Result;

	public GetTransactionWithDs_info_2Response()
	{
	}

	public GetTransactionWithDs_info_2Response(ResponseDataOfReceiptDsInfModel GetTransactionWithDs_info_2Result)
	{
		this.GetTransactionWithDs_info_2Result = GetTransactionWithDs_info_2Result;
	}
}
