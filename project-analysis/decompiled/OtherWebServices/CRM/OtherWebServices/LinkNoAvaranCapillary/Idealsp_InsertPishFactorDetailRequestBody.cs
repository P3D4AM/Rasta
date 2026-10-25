using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertPishFactorDetailRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string IdMaterial;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Amount;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string AmountKindBag;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Olaviat;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Desc;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Price;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Cost;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string DarsadKasr;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string AmountKasr;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string DarsadEzaf;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string AmountEzaf;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string CostPardakht;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string Weight;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string Avarez;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string Malyat;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string Haml;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string ModatPardakht;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string SerialKala;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string DateEngheza;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string Dategaranti;

	[DataMember(EmitDefaultValue = false, Order = 21)]
	public string IdpishFactor;

	[DataMember(EmitDefaultValue = false, Order = 22)]
	public string CodeKala;

	public Idealsp_InsertPishFactorDetailRequestBody()
	{
	}

	public Idealsp_InsertPishFactorDetailRequestBody(string IdMaterial, string Amount, string AmountKindBag, string Olaviat, string Desc, string Price, string Cost, string DarsadKasr, string AmountKasr, string DarsadEzaf, string AmountEzaf, string CostPardakht, string Weight, string Avarez, string Malyat, string Haml, string Store, string ModatPardakht, string SerialKala, string DateEngheza, string Dategaranti, string IdpishFactor, string CodeKala)
	{
		this.IdMaterial = IdMaterial;
		this.Amount = Amount;
		this.AmountKindBag = AmountKindBag;
		this.Olaviat = Olaviat;
		this.Desc = Desc;
		this.Price = Price;
		this.Cost = Cost;
		this.DarsadKasr = DarsadKasr;
		this.AmountKasr = AmountKasr;
		this.DarsadEzaf = DarsadEzaf;
		this.AmountEzaf = AmountEzaf;
		this.CostPardakht = CostPardakht;
		this.Weight = Weight;
		this.Avarez = Avarez;
		this.Malyat = Malyat;
		this.Haml = Haml;
		this.Store = Store;
		this.ModatPardakht = ModatPardakht;
		this.SerialKala = SerialKala;
		this.DateEngheza = DateEngheza;
		this.Dategaranti = Dategaranti;
		this.IdpishFactor = IdpishFactor;
		this.CodeKala = CodeKala;
	}
}
