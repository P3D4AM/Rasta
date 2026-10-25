using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class GetDaryaftRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Date1;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Date2;

	public GetDaryaftRequestBody()
	{
	}

	public GetDaryaftRequestBody(string Date1, string Date2)
	{
		this.Date1 = Date1;
		this.Date2 = Date2;
	}
}
