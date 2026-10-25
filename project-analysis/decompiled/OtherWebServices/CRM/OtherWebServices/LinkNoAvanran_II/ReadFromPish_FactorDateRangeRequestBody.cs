using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromPish_FactorDateRangeRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string FromDate;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string ToDate;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string Store;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string UserId;

	public ReadFromPish_FactorDateRangeRequestBody()
	{
	}

	public ReadFromPish_FactorDateRangeRequestBody(string FromDate, string ToDate, string Store, string UserId)
	{
		this.FromDate = FromDate;
		this.ToDate = ToDate;
		this.Store = Store;
		this.UserId = UserId;
	}
}
