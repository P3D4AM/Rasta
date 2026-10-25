using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsInformationWithInventoryIDandBarcodesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsInformationWithInventoryIDandBarcodesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm GetItemsInformationWithInventoryIDandBarcodesResult;

	public GetItemsInformationWithInventoryIDandBarcodesResponse()
	{
	}

	public GetItemsInformationWithInventoryIDandBarcodesResponse(ResponseDataOfitm GetItemsInformationWithInventoryIDandBarcodesResult)
	{
		this.GetItemsInformationWithInventoryIDandBarcodesResult = GetItemsInformationWithInventoryIDandBarcodesResult;
	}
}
