using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "AuthenticationUserResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class AuthenticationUserResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public AuthenticationResult AuthenticationUserResult;

	public AuthenticationUserResponse()
	{
	}

	public AuthenticationUserResponse(AuthenticationResult AuthenticationUserResult)
	{
		this.AuthenticationUserResult = AuthenticationUserResult;
	}
}
