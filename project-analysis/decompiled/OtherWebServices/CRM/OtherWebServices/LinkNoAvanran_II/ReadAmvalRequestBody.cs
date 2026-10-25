using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadAmvalRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Tabagheh;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Univ;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Auxi;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Part;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Empno;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Name;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Code_Part;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Code_Vahed;

	public ReadAmvalRequestBody()
	{
	}

	public ReadAmvalRequestBody(string Tabagheh, string Univ, string Auxi, string Part, string Empno, string Name, string Code_Part, string Code_Vahed)
	{
		this.Tabagheh = Tabagheh;
		this.Univ = Univ;
		this.Auxi = Auxi;
		this.Part = Part;
		this.Empno = Empno;
		this.Name = Name;
		this.Code_Part = Code_Part;
		this.Code_Vahed = Code_Vahed;
	}
}
