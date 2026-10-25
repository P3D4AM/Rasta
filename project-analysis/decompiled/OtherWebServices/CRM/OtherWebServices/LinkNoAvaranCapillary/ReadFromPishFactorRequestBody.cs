using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromPishFactorRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string FromDate;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string ToDate;

	[DataMember(EmitDefaultValue = false, Order = 3)]
	public string PishFactorNo;

	public ReadFromPishFactorRequestBody()
	{
	}

	public ReadFromPishFactorRequestBody(string UserId, string FromDate, string ToDate, string PishFactorNo)
	{
		this.UserId = UserId;
		this.FromDate = FromDate;
		this.ToDate = ToDate;
		this.PishFactorNo = PishFactorNo;
	}
}
