using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetAllTemplateItems", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetAllTemplateItemsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	public GetAllTemplateItemsRequest()
	{
	}

	public GetAllTemplateItemsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
	}
}
