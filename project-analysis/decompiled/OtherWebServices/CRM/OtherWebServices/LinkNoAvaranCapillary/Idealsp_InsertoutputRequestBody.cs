using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class Idealsp_InsertoutputRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Doc_No;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Seq;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Doc_Date;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Part;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string Out_Quan;

	[DataMember(EmitDefaultValue = false, Order = 7)]
	public string Quan2;

	[DataMember(EmitDefaultValue = false, Order = 8)]
	public string Shop_Code;

	[DataMember(EmitDefaultValue = false, Order = 9)]
	public string Training;

	[DataMember(EmitDefaultValue = false, Order = 10)]
	public string Shahr;

	[DataMember(EmitDefaultValue = false, Order = 11)]
	public string Discount;

	[DataMember(EmitDefaultValue = false, Order = 12)]
	public string Factor_No;

	[DataMember(EmitDefaultValue = false, Order = 13)]
	public string Factor_Dat;

	[DataMember(EmitDefaultValue = false, Order = 14)]
	public string Transport;

	[DataMember(EmitDefaultValue = false, Order = 15)]
	public string Sayer;

	[DataMember(EmitDefaultValue = false, Order = 16)]
	public string Sharh;

	[DataMember(EmitDefaultValue = false, Order = 17)]
	public string Serial;

	[DataMember(EmitDefaultValue = false, Order = 18)]
	public string Factor_C;

	[DataMember(EmitDefaultValue = false, Order = 19)]
	public string Factor_P;

	[DataMember(EmitDefaultValue = false, Order = 20)]
	public string OutCodeVahed;

	[DataMember(EmitDefaultValue = false, Order = 21)]
	public string CodeBarBari;

	[DataMember(EmitDefaultValue = false, Order = 22)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 23)]
	public string Kind;

	public Idealsp_InsertoutputRequestBody()
	{
	}

	public Idealsp_InsertoutputRequestBody(string Doc_No, string Seq, string Doc_Date, string Code, string Store, string Part, string Out_Quan, string Quan2, string Shop_Code, string Training, string Shahr, string Discount, string Factor_No, string Factor_Dat, string Transport, string Sayer, string Sharh, string Serial, string Factor_C, string Factor_P, string OutCodeVahed, string CodeBarBari, string UserId, string Kind)
	{
		this.Doc_No = Doc_No;
		this.Seq = Seq;
		this.Doc_Date = Doc_Date;
		this.Code = Code;
		this.Store = Store;
		this.Part = Part;
		this.Out_Quan = Out_Quan;
		this.Quan2 = Quan2;
		this.Shop_Code = Shop_Code;
		this.Training = Training;
		this.Shahr = Shahr;
		this.Discount = Discount;
		this.Factor_No = Factor_No;
		this.Factor_Dat = Factor_Dat;
		this.Transport = Transport;
		this.Sayer = Sayer;
		this.Sharh = Sharh;
		this.Serial = Serial;
		this.Factor_C = Factor_C;
		this.Factor_P = Factor_P;
		this.OutCodeVahed = OutCodeVahed;
		this.CodeBarBari = CodeBarBari;
		this.UserId = UserId;
		this.Kind = Kind;
	}
}
