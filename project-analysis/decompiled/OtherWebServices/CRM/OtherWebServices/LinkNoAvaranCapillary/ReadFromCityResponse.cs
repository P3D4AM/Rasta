using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromCityResponse
{
	[MessageBodyMember(Name = "ReadFromCityResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromCityResponseBody Body;

	public ReadFromCityResponse()
	{
	}

	public ReadFromCityResponse(ReadFromCityResponseBody Body)
	{
		this.Body = Body;
	}
}
