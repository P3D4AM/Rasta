using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertDaryaftDetailRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string ResidNo;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string IdCustomer;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string CheckNo;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string CheckDate;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Mablagh;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Bank;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string CodeShobeh;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Jari;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string Modat;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string NameShobeh;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string Radif;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string SahebCheck;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string FactorNo;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string NDaftar;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string KindSabt;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string IdFactorTasvie;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string KindSabtDis;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string CheckNoKamel;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string ShSayadi;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string KindDis;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string CodeRahgiri;

	public Idealsp_InsertDaryaftDetailRequestBody()
	{
	}

	public Idealsp_InsertDaryaftDetailRequestBody(string ResidNo, string IdCustomer, string CheckNo, string CheckDate, string Mablagh, string Bank, string CodeShobeh, string Jari, string Modat, string NameShobeh, string Radif, string SahebCheck, string FactorNo, string NDaftar, string KindSabt, string IdFactorTasvie, string KindSabtDis, string CheckNoKamel, string ShSayadi, string KindDis, string CodeRahgiri)
	{
		this.ResidNo = ResidNo;
		this.IdCustomer = IdCustomer;
		this.CheckNo = CheckNo;
		this.CheckDate = CheckDate;
		this.Mablagh = Mablagh;
		this.Bank = Bank;
		this.CodeShobeh = CodeShobeh;
		this.Jari = Jari;
		this.Modat = Modat;
		this.NameShobeh = NameShobeh;
		this.Radif = Radif;
		this.SahebCheck = SahebCheck;
		this.FactorNo = FactorNo;
		this.NDaftar = NDaftar;
		this.KindSabt = KindSabt;
		this.IdFactorTasvie = IdFactorTasvie;
		this.KindSabtDis = KindSabtDis;
		this.CheckNoKamel = CheckNoKamel;
		this.ShSayadi = ShSayadi;
		this.KindDis = KindDis;
		this.CodeRahgiri = CodeRahgiri;
	}
}
