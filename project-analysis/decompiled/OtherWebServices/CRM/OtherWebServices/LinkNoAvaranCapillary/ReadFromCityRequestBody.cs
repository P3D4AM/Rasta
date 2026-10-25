using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[DataContract(Namespace = "http://tempuri.org/")]
public class ReadFromCityRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string Code;

	[DataMember(EmitDefaultValue = false, Order = 1)]
	public string UserId;

	[DataMember(EmitDefaultValue = false, Order = 2)]
	public string IdProvince;

	public ReadFromCityRequestBody()
	{
	}

	public ReadFromCityRequestBody(string Code, string UserId, string IdProvince)
	{
		this.Code = Code;
		this.UserId = UserId;
		this.IdProvince = IdProvince;
	}
}
