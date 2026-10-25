using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "BuycustomersResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class BuycustomersResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfBuycustomersModel BuycustomersResult;

	public BuycustomersResponse()
	{
	}

	public BuycustomersResponse(ResponseDataOfBuycustomersModel BuycustomersResult)
	{
		this.BuycustomersResult = BuycustomersResult;
	}
}
