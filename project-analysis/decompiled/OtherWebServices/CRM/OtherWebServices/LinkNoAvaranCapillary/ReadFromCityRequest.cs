using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromCityRequest
{
	[MessageBodyMember(Name = "ReadFromCity", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromCityRequestBody Body;

	public ReadFromCityRequest()
	{
	}

	public ReadFromCityRequest(ReadFromCityRequestBody Body)
	{
		this.Body = Body;
	}
}
