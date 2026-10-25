using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromComanyRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string NameCmp;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string UserId;

	public ReadFromComanyRequestBody()
	{
	}

	public ReadFromComanyRequestBody(string Code, string NameCmp, string UserId)
	{
		this.Code = Code;
		this.NameCmp = NameCmp;
		this.UserId = UserId;
	}
}
