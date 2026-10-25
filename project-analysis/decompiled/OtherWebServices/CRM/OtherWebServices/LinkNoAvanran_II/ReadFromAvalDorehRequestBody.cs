using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromAvalDorehRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string UserId;

	public ReadFromAvalDorehRequestBody()
	{
	}

	public ReadFromAvalDorehRequestBody(string Store, string Code, string UserId)
	{
		this.Store = Store;
		this.Code = Code;
		this.UserId = UserId;
	}
}
