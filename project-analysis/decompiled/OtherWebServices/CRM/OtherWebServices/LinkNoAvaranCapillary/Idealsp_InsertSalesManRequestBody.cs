using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertSalesManRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string FirstName;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string LastName;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Address;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Code_e;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string CodePosti;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string CodeMeli;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Tel;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string Mobile;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string UserName;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string uDate;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string uTime;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string Email;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string WebSayt;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string Fax;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string idGroupSalesMan;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string idKindSalesMan;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string idCompany;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string supervisor;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string mahiat;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string personCode;

	[DataMember(EmitDefaultValue = false, Order = 21)]
	public string UserId;

	public Idealsp_InsertSalesManRequestBody()
	{
	}

	public Idealsp_InsertSalesManRequestBody(string Code, string FirstName, string LastName, string Address, string Code_e, string CodePosti, string CodeMeli, string Tel, string Mobile, string UserName, string uDate, string uTime, string Email, string WebSayt, string Fax, string idGroupSalesMan, string idKindSalesMan, string idCompany, string supervisor, string mahiat, string personCode, string UserId)
	{
		this.Code = Code;
		this.FirstName = FirstName;
		this.LastName = LastName;
		this.Address = Address;
		this.Code_e = Code_e;
		this.CodePosti = CodePosti;
		this.CodeMeli = CodeMeli;
		this.Tel = Tel;
		this.Mobile = Mobile;
		this.UserName = UserName;
		this.uDate = uDate;
		this.uTime = uTime;
		this.Email = Email;
		this.WebSayt = WebSayt;
		this.Fax = Fax;
		this.idGroupSalesMan = idGroupSalesMan;
		this.idKindSalesMan = idKindSalesMan;
		this.idCompany = idCompany;
		this.supervisor = supervisor;
		this.mahiat = mahiat;
		this.personCode = personCode;
		this.UserId = UserId;
	}
}
