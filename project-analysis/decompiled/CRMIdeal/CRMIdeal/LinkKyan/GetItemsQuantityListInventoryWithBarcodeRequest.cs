using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsQuantityListInventoryWithBarcode", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsQuantityListInventoryWithBarcodeRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int[] Inventories;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string[] barcodes;

	public GetItemsQuantityListInventoryWithBarcodeRequest()
	{
	}

	public GetItemsQuantityListInventoryWithBarcodeRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] Inventories, string[] barcodes)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.Inventories = Inventories;
		this.barcodes = barcodes;
	}
}
