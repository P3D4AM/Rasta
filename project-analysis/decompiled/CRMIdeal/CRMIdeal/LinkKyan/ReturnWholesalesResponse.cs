using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ReturnWholesalesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ReturnWholesalesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfReturnWholeSaleReult ReturnWholesalesResult;

	public ReturnWholesalesResponse()
	{
	}

	public ReturnWholesalesResponse(ResponseDataOfReturnWholeSaleReult ReturnWholesalesResult)
	{
		this.ReturnWholesalesResult = ReturnWholesalesResult;
	}
}
