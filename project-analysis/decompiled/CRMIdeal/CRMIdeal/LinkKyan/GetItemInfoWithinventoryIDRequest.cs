using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithinventoryID", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithinventoryIDRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int[] inventories;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public string EndDate;

	public GetItemInfoWithinventoryIDRequest()
	{
	}

	public GetItemInfoWithinventoryIDRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string StartDate, string EndDate)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.inventories = inventories;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
	}
}
