using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsQuantityAllInventoryWithBarcode", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsQuantityAllInventoryWithBarcodeRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int[] retailStores;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string[] barcodes;

	public GetItemsQuantityAllInventoryWithBarcodeRequest()
	{
	}

	public GetItemsQuantityAllInventoryWithBarcodeRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] retailStores, string[] barcodes)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.retailStores = retailStores;
		this.barcodes = barcodes;
	}
}
