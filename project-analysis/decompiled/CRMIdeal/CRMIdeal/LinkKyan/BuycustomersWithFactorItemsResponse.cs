using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "BuycustomersWithFactorItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class BuycustomersWithFactorItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfBuycustomersWithFactorItemsModel BuycustomersWithFactorItemsResult;

	public BuycustomersWithFactorItemsResponse()
	{
	}

	public BuycustomersWithFactorItemsResponse(ResponseDataOfBuycustomersWithFactorItemsModel BuycustomersWithFactorItemsResult)
	{
		this.BuycustomersWithFactorItemsResult = BuycustomersWithFactorItemsResult;
	}
}
