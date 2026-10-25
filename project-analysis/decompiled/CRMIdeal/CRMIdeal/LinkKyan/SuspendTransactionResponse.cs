using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SuspendTransactionResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SuspendTransactionResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString SuspendTransactionResult;

	public SuspendTransactionResponse()
	{
	}

	public SuspendTransactionResponse(ResponseDataOfString SuspendTransactionResult)
	{
		this.SuspendTransactionResult = SuspendTransactionResult;
	}
}
