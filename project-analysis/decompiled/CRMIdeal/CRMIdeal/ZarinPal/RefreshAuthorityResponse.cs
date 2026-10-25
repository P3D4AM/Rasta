using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class RefreshAuthorityResponse
{
	[MessageBodyMember(Name = "RefreshAuthorityResponse", Namespace = "http://zarinpal.com/", Order = 0)]
	public RefreshAuthorityResponseBody Body;

	public RefreshAuthorityResponse()
	{
	}

	public RefreshAuthorityResponse(RefreshAuthorityResponseBody Body)
	{
		this.Body = Body;
	}
}
