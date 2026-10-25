using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "QuickExternalTransferInResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class QuickExternalTransferInResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfQuickTransferResult QuickExternalTransferInResult;

	public QuickExternalTransferInResponse()
	{
	}

	public QuickExternalTransferInResponse(ResponseDataOfQuickTransferResult QuickExternalTransferInResult)
	{
		this.QuickExternalTransferInResult = QuickExternalTransferInResult;
	}
}
