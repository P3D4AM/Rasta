using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetTemplateAttributesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTemplateAttributesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfAttribute GetTemplateAttributesResult;

	public GetTemplateAttributesResponse()
	{
	}

	public GetTemplateAttributesResponse(ResponseDataOfAttribute GetTemplateAttributesResult)
	{
		this.GetTemplateAttributesResult = GetTemplateAttributesResult;
	}
}
