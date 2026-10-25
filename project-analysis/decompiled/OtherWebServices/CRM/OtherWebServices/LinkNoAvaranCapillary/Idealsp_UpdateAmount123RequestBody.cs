using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_UpdateAmount123RequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string CodeKala;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string KindAmount;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Price;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string UserId;

	public Idealsp_UpdateAmount123RequestBody()
	{
	}

	public Idealsp_UpdateAmount123RequestBody(string CodeKala, string Store, string KindAmount, string Price, string UserId)
	{
		this.CodeKala = CodeKala;
		this.Store = Store;
		this.KindAmount = KindAmount;
		this.Price = Price;
		this.UserId = UserId;
	}
}
