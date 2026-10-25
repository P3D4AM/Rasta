using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetRecieptHeaderResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetRecieptHeaderResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfRecieptsHeader GetRecieptHeaderResult;

	public GetRecieptHeaderResponse()
	{
	}

	public GetRecieptHeaderResponse(ResponseDataOfRecieptsHeader GetRecieptHeaderResult)
	{
		this.GetRecieptHeaderResult = GetRecieptHeaderResult;
	}
}
