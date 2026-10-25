using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromBazaryabanRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Part;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string UserId;

	public ReadFromBazaryabanRequestBody()
	{
	}

	public ReadFromBazaryabanRequestBody(string Part, string UserId)
	{
		this.Part = Part;
		this.UserId = UserId;
	}
}
