using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertPishFactorResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertPishFactorResult;

	public Idealsp_InsertPishFactorResponseBody()
	{
	}

	public Idealsp_InsertPishFactorResponseBody(string Idealsp_InsertPishFactorResult)
	{
		this.Idealsp_InsertPishFactorResult = Idealsp_InsertPishFactorResult;
	}
}
