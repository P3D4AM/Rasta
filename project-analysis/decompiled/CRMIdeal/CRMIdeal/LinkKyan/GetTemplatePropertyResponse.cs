using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTemplatePropertyResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTemplatePropertyResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfTemplate GetTemplatePropertyResult;

	public GetTemplatePropertyResponse()
	{
	}

	public GetTemplatePropertyResponse(ResponseDataOfTemplate GetTemplatePropertyResult)
	{
		this.GetTemplatePropertyResult = GetTemplatePropertyResult;
	}
}
