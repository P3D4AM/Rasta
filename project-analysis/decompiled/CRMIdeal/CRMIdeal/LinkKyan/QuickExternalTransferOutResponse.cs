using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "QuickExternalTransferOutResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class QuickExternalTransferOutResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfQuickTransferResult QuickExternalTransferOutResult;

	public QuickExternalTransferOutResponse()
	{
	}

	public QuickExternalTransferOutResponse(ResponseDataOfQuickTransferResult QuickExternalTransferOutResult)
	{
		this.QuickExternalTransferOutResult = QuickExternalTransferOutResult;
	}
}
