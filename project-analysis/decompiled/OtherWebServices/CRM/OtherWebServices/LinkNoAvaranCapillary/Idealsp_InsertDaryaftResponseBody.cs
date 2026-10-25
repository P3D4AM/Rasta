using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertDaryaftResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertDaryaftResult;

	public Idealsp_InsertDaryaftResponseBody()
	{
	}

	public Idealsp_InsertDaryaftResponseBody(string Idealsp_InsertDaryaftResult)
	{
		this.Idealsp_InsertDaryaftResult = Idealsp_InsertDaryaftResult;
	}
}
