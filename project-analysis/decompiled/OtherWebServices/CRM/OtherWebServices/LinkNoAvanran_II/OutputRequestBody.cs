using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class OutputRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Shop_Code;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Quan;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Cost;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Price;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Doc_No;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Doc_Date;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string Sharh;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string Discount;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string Discount2;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string UserId;

	public OutputRequestBody()
	{
	}

	public OutputRequestBody(string Store, string Shop_Code, string Quan, string Code, string Cost, string Price, string Doc_No, string Doc_Date, string Sharh, string Discount, string Discount2, string UserId)
	{
		this.Store = Store;
		this.Shop_Code = Shop_Code;
		this.Quan = Quan;
		this.Code = Code;
		this.Cost = Cost;
		this.Price = Price;
		this.Doc_No = Doc_No;
		this.Doc_Date = Doc_Date;
		this.Sharh = Sharh;
		this.Discount = Discount;
		this.Discount2 = Discount2;
		this.UserId = UserId;
	}
}
