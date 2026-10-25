using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithInventoryIDPlusJetResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithInventoryIDPlusJetResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfgoodDetail GetItemInfoWithInventoryIDPlusJetResult;

	public GetItemInfoWithInventoryIDPlusJetResponse()
	{
	}

	public GetItemInfoWithInventoryIDPlusJetResponse(ResponseDataOfgoodDetail GetItemInfoWithInventoryIDPlusJetResult)
	{
		this.GetItemInfoWithInventoryIDPlusJetResult = GetItemInfoWithInventoryIDPlusJetResult;
	}
}
