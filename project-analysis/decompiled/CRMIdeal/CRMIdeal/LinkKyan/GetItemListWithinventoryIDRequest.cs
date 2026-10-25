using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithinventoryID", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithinventoryIDRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int inventory;

	public GetItemListWithinventoryIDRequest()
	{
	}

	public GetItemListWithinventoryIDRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventory)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.inventory = inventory;
	}
}
