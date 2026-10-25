using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetMatrixAttributeResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetMatrixAttributeResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfAttribute GetMatrixAttributeResult;

	public GetMatrixAttributeResponse()
	{
	}

	public GetMatrixAttributeResponse(ResponseDataOfAttribute GetMatrixAttributeResult)
	{
		this.GetMatrixAttributeResult = GetMatrixAttributeResult;
	}
}
