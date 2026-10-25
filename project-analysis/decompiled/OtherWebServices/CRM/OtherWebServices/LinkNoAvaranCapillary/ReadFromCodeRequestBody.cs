using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromCodeRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string KindKala;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string UDate;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string UDate2;

	public ReadFromCodeRequestBody()
	{
	}

	public ReadFromCodeRequestBody(string UserId, string KindKala, string UDate, string UDate2)
	{
		this.UserId = UserId;
		this.KindKala = KindKala;
		this.UDate = UDate;
		this.UDate2 = UDate2;
	}
}
