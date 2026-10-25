using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithinventoryIDandBarcodes", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithinventoryIDandBarcodesRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int[] inventories;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string[] barcodes;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public string StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 3)]
	public string EndDate;

	public GetItemInfoWithinventoryIDandBarcodesRequest()
	{
	}

	public GetItemInfoWithinventoryIDandBarcodesRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string[] barcodes, string StartDate, string EndDate)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.inventories = inventories;
		this.barcodes = barcodes;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
	}
}
