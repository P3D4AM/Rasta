using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemsInformationWithInventoryIDandBarcodes", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemsInformationWithInventoryIDandBarcodesRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int inventoryId;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string[] barcodes;

	public GetItemsInformationWithInventoryIDandBarcodesRequest()
	{
	}

	public GetItemsInformationWithInventoryIDandBarcodesRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryId, string[] barcodes)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.inventoryId = inventoryId;
		this.barcodes = barcodes;
	}
}
