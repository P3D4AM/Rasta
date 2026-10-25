using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkPayvast;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetFiscalPeriodIdResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetFiscalPeriodIdResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	[XmlElement(IsNullable = true)]
	public int? GetFiscalPeriodIdResult;

	public GetFiscalPeriodIdResponse()
	{
	}

	public GetFiscalPeriodIdResponse(int? GetFiscalPeriodIdResult)
	{
		this.GetFiscalPeriodIdResult = GetFiscalPeriodIdResult;
	}
}
