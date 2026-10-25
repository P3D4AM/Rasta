using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetAllTemplateItemsResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetAllTemplateItemsResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfTemplateItem GetAllTemplateItemsResult;

	public GetAllTemplateItemsResponse()
	{
	}

	public GetAllTemplateItemsResponse(ResponseDataOfTemplateItem GetAllTemplateItemsResult)
	{
		this.GetAllTemplateItemsResult = GetAllTemplateItemsResult;
	}
}
