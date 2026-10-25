using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadRemainFromAccountRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Shop_Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Kol;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Moeen;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Tafsili1;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Tafsili2;

	public ReadRemainFromAccountRequestBody()
	{
	}

	public ReadRemainFromAccountRequestBody(string Shop_Code, string Kol, string Moeen, string Tafsili1, string Tafsili2)
	{
		this.Shop_Code = Shop_Code;
		this.Kol = Kol;
		this.Moeen = Moeen;
		this.Tafsili1 = Tafsili1;
		this.Tafsili2 = Tafsili2;
	}
}
