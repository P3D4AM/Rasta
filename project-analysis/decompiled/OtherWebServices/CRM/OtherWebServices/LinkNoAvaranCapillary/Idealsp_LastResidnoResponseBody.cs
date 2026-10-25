using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_LastResidnoResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_LastResidnoResult;

	public Idealsp_LastResidnoResponseBody()
	{
	}

	public Idealsp_LastResidnoResponseBody(string Idealsp_LastResidnoResult)
	{
		this.Idealsp_LastResidnoResult = Idealsp_LastResidnoResult;
	}
}
