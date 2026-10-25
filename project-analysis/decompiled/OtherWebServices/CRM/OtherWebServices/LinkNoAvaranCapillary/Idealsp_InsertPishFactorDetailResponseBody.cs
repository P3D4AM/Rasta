using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertPishFactorDetailResponseBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Idealsp_InsertPishFactorDetailResult;

	public Idealsp_InsertPishFactorDetailResponseBody()
	{
	}

	public Idealsp_InsertPishFactorDetailResponseBody(string Idealsp_InsertPishFactorDetailResult)
	{
		this.Idealsp_InsertPishFactorDetailResult = Idealsp_InsertPishFactorDetailResult;
	}
}
