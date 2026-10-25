using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_UpdateAmount123ResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_UpdateAmount123Result;

	public Idealsp_UpdateAmount123ResponseBody()
	{
	}

	public Idealsp_UpdateAmount123ResponseBody(string Idealsp_UpdateAmount123Result)
	{
		this.Idealsp_UpdateAmount123Result = Idealsp_UpdateAmount123Result;
	}
}
