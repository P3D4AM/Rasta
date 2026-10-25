using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetInventoriesListResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetInventoriesListResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfInventory GetInventoriesListResult;

	public GetInventoriesListResponse()
	{
	}

	public GetInventoriesListResponse(ResponseDataOfInventory GetInventoriesListResult)
	{
		this.GetInventoriesListResult = GetInventoriesListResult;
	}
}
