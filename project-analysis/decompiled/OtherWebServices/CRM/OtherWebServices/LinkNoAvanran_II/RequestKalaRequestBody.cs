using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class RequestKalaRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string Quan;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string Doc_No;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string Doc_Date;

	[DataMember(EmitDefaultValue = false, Order = 5)]
	public string Sharh;

	[DataMember(EmitDefaultValue = false, Order = 6)]
	public string UserId;

	public RequestKalaRequestBody()
	{
	}

	public RequestKalaRequestBody(string Store, string Quan, string Code, string Doc_No, string Doc_Date, string Sharh, string UserId)
	{
		this.Store = Store;
		this.Quan = Quan;
		this.Code = Code;
		this.Doc_No = Doc_No;
		this.Doc_Date = Doc_Date;
		this.Sharh = Sharh;
		this.UserId = UserId;
	}
}
