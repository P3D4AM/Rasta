using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ViewOutputRequest
{
	[MessageBodyMember(Name = "ViewOutput", Namespace = "http://tempuri.org/", Order = 0)]
	public ViewOutputRequestBody Body;

	public ViewOutputRequest()
	{
	}

	public ViewOutputRequest(ViewOutputRequestBody Body)
	{
		this.Body = Body;
	}
}
