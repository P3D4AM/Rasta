using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertPishFactorRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string PishFactorNo;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string PishFactorDate;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string DateEtebar;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string IdSalesMan;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string IdCustomer;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string AddressDaftar;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string AddressTahvil;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string IdKindSale;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string IdCompany;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string IdKindMaterial;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string Olaviat;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string KindFactor;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string Desc;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string UserName;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string UDate;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string UTime;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string IdSalesMan2;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string IdSalesMan3;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string MablaghPish;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string UserID;

	[DataMember(EmitDefaultValue = false, Order = 21)]
	public string IdPart;

	[DataMember(EmitDefaultValue = false, Order = 22)]
	public string DateTasvie;

	[DataMember(EmitDefaultValue = false, Order = 23)]
	public string IDpishfactor;

	public Idealsp_InsertPishFactorRequestBody()
	{
	}

	public Idealsp_InsertPishFactorRequestBody(string PishFactorNo, string PishFactorDate, string DateEtebar, string IdSalesMan, string IdCustomer, string AddressDaftar, string AddressTahvil, string IdKindSale, string IdCompany, string IdKindMaterial, string Olaviat, string KindFactor, string Desc, string UserName, string UDate, string UTime, string Store, string IdSalesMan2, string IdSalesMan3, string MablaghPish, string UserID, string IdPart, string DateTasvie, string IDpishfactor)
	{
		this.PishFactorNo = PishFactorNo;
		this.PishFactorDate = PishFactorDate;
		this.DateEtebar = DateEtebar;
		this.IdSalesMan = IdSalesMan;
		this.IdCustomer = IdCustomer;
		this.AddressDaftar = AddressDaftar;
		this.AddressTahvil = AddressTahvil;
		this.IdKindSale = IdKindSale;
		this.IdCompany = IdCompany;
		this.IdKindMaterial = IdKindMaterial;
		this.Olaviat = Olaviat;
		this.KindFactor = KindFactor;
		this.Desc = Desc;
		this.UserName = UserName;
		this.UDate = UDate;
		this.UTime = UTime;
		this.Store = Store;
		this.IdSalesMan2 = IdSalesMan2;
		this.IdSalesMan3 = IdSalesMan3;
		this.MablaghPish = MablaghPish;
		this.UserID = UserID;
		this.IdPart = IdPart;
		this.DateTasvie = DateTasvie;
		this.IDpishfactor = IDpishfactor;
	}
}
