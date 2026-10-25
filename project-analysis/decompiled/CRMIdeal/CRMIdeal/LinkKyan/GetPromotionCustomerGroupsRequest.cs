using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetPromotionCustomerGroups", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetPromotionCustomerGroupsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public int retialStore;

	public GetPromotionCustomerGroupsRequest()
	{
	}

	public GetPromotionCustomerGroupsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retialStore)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.retialStore = retialStore;
	}
}
