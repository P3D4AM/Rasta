using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromCodeResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string ReadFromCodeResult;

	public ReadFromCodeResponseBody()
	{
	}

	public ReadFromCodeResponseBody(string ReadFromCodeResult)
	{
		this.ReadFromCodeResult = ReadFromCodeResult;
	}
}
