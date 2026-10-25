using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertDaryaftRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string IdCustomer;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Date;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string DateFirst;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string DateRas;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string IdCompany;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string UserName;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string UDate;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string Time;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string Babat;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string IdFactorTasvie;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string IdSalesMan1;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string IdSalesMan2;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string IdSalesMan3;

	public Idealsp_InsertDaryaftRequestBody()
	{
	}

	public Idealsp_InsertDaryaftRequestBody(string Code, string IdCustomer, string Date, string DateFirst, string DateRas, string IdCompany, string UserName, string UDate, string Time, string Babat, string IdFactorTasvie, string IdSalesMan1, string IdSalesMan2, string IdSalesMan3)
	{
		this.Code = Code;
		this.IdCustomer = IdCustomer;
		this.Date = Date;
		this.DateFirst = DateFirst;
		this.DateRas = DateRas;
		this.IdCompany = IdCompany;
		this.UserName = UserName;
		this.UDate = UDate;
		this.Time = Time;
		this.Babat = Babat;
		this.IdFactorTasvie = IdFactorTasvie;
		this.IdSalesMan1 = IdSalesMan1;
		this.IdSalesMan2 = IdSalesMan2;
		this.IdSalesMan3 = IdSalesMan3;
	}
}
