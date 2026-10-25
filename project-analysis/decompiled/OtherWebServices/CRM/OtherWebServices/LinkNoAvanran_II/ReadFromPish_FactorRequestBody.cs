using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromPish_FactorRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Doc_No;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string UserId;

	public ReadFromPish_FactorRequestBody()
	{
	}

	public ReadFromPish_FactorRequestBody(string Store, string Doc_No, string UserId)
	{
		this.Store = Store;
		this.Doc_No = Doc_No;
		this.UserId = UserId;
	}
}
