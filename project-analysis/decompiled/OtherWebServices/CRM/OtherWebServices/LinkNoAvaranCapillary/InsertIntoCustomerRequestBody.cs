using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class InsertIntoCustomerRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Name;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string KindCustomer;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string FirstName;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string LastName;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string CodeMeli;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Sh_Sabt;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Code_E;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string CodePosti;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string AddressDaftar;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string AddressTahvil;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string IdCountry;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string IdProvince;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string IdCity;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string Zone;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string Tel;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string Fax;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string WebSayt;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string Email;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string Mobile;

	[DataMember(EmitDefaultValue = false, Order = 21)]
	public string KolBed;

	[DataMember(EmitDefaultValue = false, Order = 22)]
	public string MoeenBed;

	[DataMember(EmitDefaultValue = false, Order = 23)]
	public string Taf1Bed;

	[DataMember(EmitDefaultValue = false, Order = 24)]
	public string Taf2Bed;

	[DataMember(EmitDefaultValue = false, Order = 25)]
	public string KindAct;

	[DataMember(EmitDefaultValue = false, Order = 26)]
	public string PeriodActiveYear;

	[DataMember(EmitDefaultValue = false, Order = 27)]
	public string PeriodActiveMonth;

	[DataMember(EmitDefaultValue = false, Order = 28)]
	public string KindBuyer;

	[DataMember(EmitDefaultValue = false, Order = 29)]
	public string DateSabt;

	[DataMember(EmitDefaultValue = false, Order = 30)]
	public string MandeHesab;

	[DataMember(EmitDefaultValue = false, Order = 31)]
	public string MandeCheck;

	[DataMember(EmitDefaultValue = false, Order = 32)]
	public string UserName;

	[DataMember(EmitDefaultValue = false, Order = 33)]
	public string uDate;

	[DataMember(EmitDefaultValue = false, Order = 34)]
	public string uTime;

	[DataMember(EmitDefaultValue = false, Order = 35)]
	public string TejariName;

	[DataMember(EmitDefaultValue = false, Order = 36)]
	public string PishCode;

	[DataMember(EmitDefaultValue = false, Order = 37)]
	public string darsadtakhfif;

	[DataMember(EmitDefaultValue = false, Order = 38)]
	public string KindFactor;

	[DataMember(EmitDefaultValue = false, Order = 39)]
	public string personCode;

	[DataMember(EmitDefaultValue = false, Order = 40)]
	public string ShenaseMeli;

	[DataMember(EmitDefaultValue = false, Order = 41)]
	public string ModatPardakht;

	[DataMember(EmitDefaultValue = false, Order = 42)]
	public string EtebarMazad;

	[DataMember(EmitDefaultValue = false, Order = 43)]
	public string Password;

	[DataMember(EmitDefaultValue = false, Order = 44)]
	public string MEnterToCmp;

	[DataMember(EmitDefaultValue = false, Order = 45)]
	public string IdZone;

	[DataMember(EmitDefaultValue = false, Order = 46)]
	public string IdRoute;

	[DataMember(EmitDefaultValue = false, Order = 47)]
	public string Longitude;

	[DataMember(EmitDefaultValue = false, Order = 48)]
	public string Latitude;

	[DataMember(EmitDefaultValue = false, Order = 49)]
	public string TypeCustomer;

	[DataMember(EmitDefaultValue = false, Order = 50)]
	public string IdCompany;

	[DataMember(EmitDefaultValue = false, Order = 51)]
	public string DescCustomer;

	public InsertIntoCustomerRequestBody()
	{
	}

	public InsertIntoCustomerRequestBody(string Code, string Name, string KindCustomer, string FirstName, string LastName, string CodeMeli, string Sh_Sabt, string Code_E, string CodePosti, string AddressDaftar, string AddressTahvil, string UserId, string IdCountry, string IdProvince, string IdCity, string Zone, string Tel, string Fax, string WebSayt, string Email, string Mobile, string KolBed, string MoeenBed, string Taf1Bed, string Taf2Bed, string KindAct, string PeriodActiveYear, string PeriodActiveMonth, string KindBuyer, string DateSabt, string MandeHesab, string MandeCheck, string UserName, string uDate, string uTime, string TejariName, string PishCode, string darsadtakhfif, string KindFactor, string personCode, string ShenaseMeli, string ModatPardakht, string EtebarMazad, string Password, string MEnterToCmp, string IdZone, string IdRoute, string Longitude, string Latitude, string TypeCustomer, string IdCompany, string DescCustomer)
	{
		this.Code = Code;
		this.Name = Name;
		this.KindCustomer = KindCustomer;
		this.FirstName = FirstName;
		this.LastName = LastName;
		this.CodeMeli = CodeMeli;
		this.Sh_Sabt = Sh_Sabt;
		this.Code_E = Code_E;
		this.CodePosti = CodePosti;
		this.AddressDaftar = AddressDaftar;
		this.AddressTahvil = AddressTahvil;
		this.UserId = UserId;
		this.IdCountry = IdCountry;
		this.IdProvince = IdProvince;
		this.IdCity = IdCity;
		this.Zone = Zone;
		this.Tel = Tel;
		this.Fax = Fax;
		this.WebSayt = WebSayt;
		this.Email = Email;
		this.Mobile = Mobile;
		this.KolBed = KolBed;
		this.MoeenBed = MoeenBed;
		this.Taf1Bed = Taf1Bed;
		this.Taf2Bed = Taf2Bed;
		this.KindAct = KindAct;
		this.PeriodActiveYear = PeriodActiveYear;
		this.PeriodActiveMonth = PeriodActiveMonth;
		this.KindBuyer = KindBuyer;
		this.DateSabt = DateSabt;
		this.MandeHesab = MandeHesab;
		this.MandeCheck = MandeCheck;
		this.UserName = UserName;
		this.uDate = uDate;
		this.uTime = uTime;
		this.TejariName = TejariName;
		this.PishCode = PishCode;
		this.darsadtakhfif = darsadtakhfif;
		this.KindFactor = KindFactor;
		this.personCode = personCode;
		this.ShenaseMeli = ShenaseMeli;
		this.ModatPardakht = ModatPardakht;
		this.EtebarMazad = EtebarMazad;
		this.Password = Password;
		this.MEnterToCmp = MEnterToCmp;
		this.IdZone = IdZone;
		this.IdRoute = IdRoute;
		this.Longitude = Longitude;
		this.Latitude = Latitude;
		this.TypeCustomer = TypeCustomer;
		this.IdCompany = IdCompany;
		this.DescCustomer = DescCustomer;
	}
}
