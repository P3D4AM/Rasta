using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsQuantityAllInventoryWithBarcodeResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsQuantityAllInventoryWithBarcodeResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfItemStock GetItemsQuantityAllInventoryWithBarcodeResult;

	public GetItemsQuantityAllInventoryWithBarcodeResponse()
	{
	}

	public GetItemsQuantityAllInventoryWithBarcodeResponse(ResponseDataOfItemStock GetItemsQuantityAllInventoryWithBarcodeResult)
	{
		this.GetItemsQuantityAllInventoryWithBarcodeResult = GetItemsQuantityAllInventoryWithBarcodeResult;
	}
}
