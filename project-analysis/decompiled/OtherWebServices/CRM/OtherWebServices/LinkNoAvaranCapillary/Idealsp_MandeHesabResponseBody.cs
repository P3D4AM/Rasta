using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_MandeHesabResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_MandeHesabResult;

	public Idealsp_MandeHesabResponseBody()
	{
	}

	public Idealsp_MandeHesabResponseBody(string Idealsp_MandeHesabResult)
	{
		this.Idealsp_MandeHesabResult = Idealsp_MandeHesabResult;
	}
}
