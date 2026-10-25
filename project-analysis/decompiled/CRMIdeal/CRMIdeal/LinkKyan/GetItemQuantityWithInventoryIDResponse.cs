using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemQuantityWithInventoryIDResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemQuantityWithInventoryIDResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfBarCodeStock GetItemQuantityWithInventoryIDResult;

	public GetItemQuantityWithInventoryIDResponse()
	{
	}

	public GetItemQuantityWithInventoryIDResponse(ResponseDataOfBarCodeStock GetItemQuantityWithInventoryIDResult)
	{
		this.GetItemQuantityWithInventoryIDResult = GetItemQuantityWithInventoryIDResult;
	}
}
