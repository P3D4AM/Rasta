using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetPromotionCustomerGroupsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetPromotionCustomerGroupsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfPromotionCustomerGroupModel GetPromotionCustomerGroupsResult;

	public GetPromotionCustomerGroupsResponse()
	{
	}

	public GetPromotionCustomerGroupsResponse(ResponseDataOfPromotionCustomerGroupModel GetPromotionCustomerGroupsResult)
	{
		this.GetPromotionCustomerGroupsResult = GetPromotionCustomerGroupsResult;
	}
}
