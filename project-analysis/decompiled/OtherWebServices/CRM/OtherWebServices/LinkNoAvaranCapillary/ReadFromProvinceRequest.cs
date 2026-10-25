using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromProvinceRequest
{
	[MessageBodyMember(Name = "ReadFromProvince", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromProvinceRequestBody Body;

	public ReadFromProvinceRequest()
	{
	}

	public ReadFromProvinceRequest(ReadFromProvinceRequestBody Body)
	{
		this.Body = Body;
	}
}
