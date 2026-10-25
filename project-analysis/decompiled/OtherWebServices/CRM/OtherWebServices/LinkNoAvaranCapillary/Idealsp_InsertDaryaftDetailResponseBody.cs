using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertDaryaftDetailResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertDaryaftDetailResult;

	public Idealsp_InsertDaryaftDetailResponseBody()
	{
	}

	public Idealsp_InsertDaryaftDetailResponseBody(string Idealsp_InsertDaryaftDetailResult)
	{
		this.Idealsp_InsertDaryaftDetailResult = Idealsp_InsertDaryaftDetailResult;
	}
}
