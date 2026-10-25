using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "AddToReserveResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class AddToReserveResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfResult AddToReserveResult;

	public AddToReserveResponse()
	{
	}

	public AddToReserveResponse(ResponseDataOfResult AddToReserveResult)
	{
		this.AddToReserveResult = AddToReserveResult;
	}
}
