using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://zarinpal.com/")]
public class RefreshAuthorityResponseBody
{
	[DataMember(Order = 0)]
	public int Status;

	public RefreshAuthorityResponseBody()
	{
	}

	public RefreshAuthorityResponseBody(int Status)
	{
		this.Status = Status;
	}
}
