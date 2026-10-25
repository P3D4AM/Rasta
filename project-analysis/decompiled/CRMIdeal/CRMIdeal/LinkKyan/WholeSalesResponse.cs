using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "WholeSalesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class WholeSalesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfWholeSaleReult WholeSalesResult;

	public WholeSalesResponse()
	{
	}

	public WholeSalesResponse(ResponseDataOfWholeSaleReult WholeSalesResult)
	{
		this.WholeSalesResult = WholeSalesResult;
	}
}
