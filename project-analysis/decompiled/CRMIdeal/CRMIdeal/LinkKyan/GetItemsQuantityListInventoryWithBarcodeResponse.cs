using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsQuantityListInventoryWithBarcodeResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsQuantityListInventoryWithBarcodeResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfItemStock2 GetItemsQuantityListInventoryWithBarcodeResult;

	public GetItemsQuantityListInventoryWithBarcodeResponse()
	{
	}

	public GetItemsQuantityListInventoryWithBarcodeResponse(ResponseDataOfItemStock2 GetItemsQuantityListInventoryWithBarcodeResult)
	{
		this.GetItemsQuantityListInventoryWithBarcodeResult = GetItemsQuantityListInventoryWithBarcodeResult;
	}
}
