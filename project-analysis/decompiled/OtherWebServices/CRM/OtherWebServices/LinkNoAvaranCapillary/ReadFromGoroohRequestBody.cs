using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromGoroohRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string UserId;

	public ReadFromGoroohRequestBody()
	{
	}

	public ReadFromGoroohRequestBody(string UserId)
	{
		this.UserId = UserId;
	}
}
