using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ApproveDocumentResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ApproveDocumentResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public QuickTransferReultModel ApproveDocumentResult;

	public ApproveDocumentResponse()
	{
	}

	public ApproveDocumentResponse(QuickTransferReultModel ApproveDocumentResult)
	{
		this.ApproveDocumentResult = ApproveDocumentResult;
	}
}
