using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WholesaleResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class WholesaleResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public WholeSaleReultModel WholesaleResult;

	public WholesaleResponse()
	{
	}

	public WholesaleResponse(WholeSaleReultModel WholesaleResult)
	{
		this.WholesaleResult = WholesaleResult;
	}
}
