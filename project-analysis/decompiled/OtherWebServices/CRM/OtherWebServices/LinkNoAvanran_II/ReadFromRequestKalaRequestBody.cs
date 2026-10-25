using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromRequestKalaRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string FromDate;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string ToDate;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string DocNumber;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string StoreID;

	[DataMember(EmitDefaultValue = false, Order = 4)]
	public string UserId;

	public ReadFromRequestKalaRequestBody()
	{
	}

	public ReadFromRequestKalaRequestBody(string FromDate, string ToDate, string DocNumber, string StoreID, string UserId)
	{
		this.FromDate = FromDate;
		this.ToDate = ToDate;
		this.DocNumber = DocNumber;
		this.StoreID = StoreID;
		this.UserId = UserId;
	}
}
