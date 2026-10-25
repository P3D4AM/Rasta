using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "QuickExternalTransferResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class QuickExternalTransferResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public QuickTransferReultModel QuickExternalTransferResult;

	public QuickExternalTransferResponse()
	{
	}

	public QuickExternalTransferResponse(QuickTransferReultModel QuickExternalTransferResult)
	{
		this.QuickExternalTransferResult = QuickExternalTransferResult;
	}
}
