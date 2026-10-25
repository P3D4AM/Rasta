using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "AuthenticationUser", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class AuthenticationUserRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	public AuthenticationUserRequest()
	{
	}

	public AuthenticationUserRequest(AuthUser AuthUser)
	{
		this.AuthUser = AuthUser;
	}
}
