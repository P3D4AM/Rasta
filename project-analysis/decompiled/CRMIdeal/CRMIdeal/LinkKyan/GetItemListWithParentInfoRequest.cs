using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemListWithParentInfo", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemListWithParentInfoRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public string EndDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public bool Active;

	public GetItemListWithParentInfoRequest()
	{
	}

	public GetItemListWithParentInfoRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, bool Active)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
		this.Active = Active;
	}
}
