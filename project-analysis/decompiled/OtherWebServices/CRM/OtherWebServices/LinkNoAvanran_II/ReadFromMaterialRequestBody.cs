using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromMaterialRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string KalaName;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string UserId;

	public ReadFromMaterialRequestBody()
	{
	}

	public ReadFromMaterialRequestBody(string KalaName, string Code, string Store, string UserId)
	{
		this.KalaName = KalaName;
		this.Code = Code;
		this.Store = Store;
		this.UserId = UserId;
	}
}
