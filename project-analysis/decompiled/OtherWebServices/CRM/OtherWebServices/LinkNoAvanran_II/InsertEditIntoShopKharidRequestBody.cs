using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class InsertEditIntoShopKharidRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Shop_Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Shop_Name;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Name;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Family;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Address;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Comm_No;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Tel;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Mobile;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string ProvinceID;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string CityID;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string Kol;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string Moeen;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string Tafsili1;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string Tafsili2;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string CodeMeli;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string UserId;

	public InsertEditIntoShopKharidRequestBody()
	{
	}

	public InsertEditIntoShopKharidRequestBody(string Shop_Code, string Shop_Name, string Name, string Family, string Address, string Comm_No, string Tel, string Mobile, string ProvinceID, string CityID, string Kol, string Moeen, string Tafsili1, string Tafsili2, string CodeMeli, string UserId)
	{
		this.Shop_Code = Shop_Code;
		this.Shop_Name = Shop_Name;
		this.Name = Name;
		this.Family = Family;
		this.Address = Address;
		this.Comm_No = Comm_No;
		this.Tel = Tel;
		this.Mobile = Mobile;
		this.ProvinceID = ProvinceID;
		this.CityID = CityID;
		this.Kol = Kol;
		this.Moeen = Moeen;
		this.Tafsili1 = Tafsili1;
		this.Tafsili2 = Tafsili2;
		this.CodeMeli = CodeMeli;
		this.UserId = UserId;
	}
}
