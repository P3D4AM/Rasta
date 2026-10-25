using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertoutputResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertoutputResult;

	public Idealsp_InsertoutputResponseBody()
	{
	}

	public Idealsp_InsertoutputResponseBody(string Idealsp_InsertoutputResult)
	{
		this.Idealsp_InsertoutputResult = Idealsp_InsertoutputResult;
	}
}
