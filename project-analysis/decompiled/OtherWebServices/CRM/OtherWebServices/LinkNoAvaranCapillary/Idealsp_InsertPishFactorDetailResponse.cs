using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class Idealsp_InsertPishFactorDetailResponse
{
	[MessageBodyMember(Name = "Idealsp_InsertPishFactorDetailResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public Idealsp_InsertPishFactorDetailResponseBody Body;

	public Idealsp_InsertPishFactorDetailResponse()
	{
	}

	public Idealsp_InsertPishFactorDetailResponse(Idealsp_InsertPishFactorDetailResponseBody Body)
	{
		this.Body = Body;
	}
}
