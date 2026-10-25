using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithInventoryIDPlusJet", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithInventoryIDPlusJetRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int inventoryID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int RowNoBgin;

	public GetItemInfoWithInventoryIDPlusJetRequest()
	{
	}

	public GetItemInfoWithInventoryIDPlusJetRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryID, int RowNoBgin)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.inventoryID = inventoryID;
		this.RowNoBgin = RowNoBgin;
	}
}
