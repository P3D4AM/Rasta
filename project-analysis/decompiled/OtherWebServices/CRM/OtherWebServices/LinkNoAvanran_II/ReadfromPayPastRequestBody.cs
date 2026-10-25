using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadfromPayPastRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Sal;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Mah;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string PersonelyNo;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string CodeMeli;

	public ReadfromPayPastRequestBody()
	{
	}

	public ReadfromPayPastRequestBody(string Sal, string Mah, string PersonelyNo, string CodeMeli)
	{
		this.Sal = Sal;
		this.Mah = Mah;
		this.PersonelyNo = PersonelyNo;
		this.CodeMeli = CodeMeli;
	}
}
