using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class RefreshAuthorityRequest
{
	[MessageBodyMember(Name = "RefreshAuthority", Namespace = "http://zarinpal.com/", Order = 0)]
	public RefreshAuthorityRequestBody Body;

	public RefreshAuthorityRequest()
	{
	}

	public RefreshAuthorityRequest(RefreshAuthorityRequestBody Body)
	{
		this.Body = Body;
	}
}
