using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromCustomerRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Name;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string CodeMeli;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string SabtDate;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string SabtDate2;

	public ReadFromCustomerRequestBody()
	{
	}

	public ReadFromCustomerRequestBody(string Code, string UserId, string Name, string CodeMeli, string SabtDate, string SabtDate2)
	{
		this.Code = Code;
		this.UserId = UserId;
		this.Name = Name;
		this.CodeMeli = CodeMeli;
		this.SabtDate = SabtDate;
		this.SabtDate2 = SabtDate2;
	}
}
