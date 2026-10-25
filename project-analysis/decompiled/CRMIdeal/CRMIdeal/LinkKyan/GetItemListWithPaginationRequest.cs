using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithPagination", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithPaginationRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int RowNoBgin;

	public GetItemListWithPaginationRequest()
	{
	}

	public GetItemListWithPaginationRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int RowNoBgin)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.RowNoBgin = RowNoBgin;
	}
}
