using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ReturnWholesaleResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ReturnWholesaleResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ReturnWholeSaleReultMode ReturnWholesaleResult;

	public ReturnWholesaleResponse()
	{
	}

	public ReturnWholesaleResponse(ReturnWholeSaleReultMode ReturnWholesaleResult)
	{
		this.ReturnWholesaleResult = ReturnWholesaleResult;
	}
}
