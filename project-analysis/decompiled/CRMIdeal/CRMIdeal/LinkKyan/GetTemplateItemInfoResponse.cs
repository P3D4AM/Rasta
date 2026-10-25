using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTemplateItemInfoResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTemplateItemInfoResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfTemplateItem GetTemplateItemInfoResult;

	public GetTemplateItemInfoResponse()
	{
	}

	public GetTemplateItemInfoResponse(ResponseDataOfTemplateItem GetTemplateItemInfoResult)
	{
		this.GetTemplateItemInfoResult = GetTemplateItemInfoResult;
	}
}
