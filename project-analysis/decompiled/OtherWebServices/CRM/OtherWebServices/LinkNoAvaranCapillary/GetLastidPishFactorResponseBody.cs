using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class GetLastidPishFactorResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string GetLastidPishFactorResult;

	public GetLastidPishFactorResponseBody()
	{
	}

	public GetLastidPishFactorResponseBody(string GetLastidPishFactorResult)
	{
		this.GetLastidPishFactorResult = GetLastidPishFactorResult;
	}
}
