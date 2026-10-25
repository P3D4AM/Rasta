using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkPayvast;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetFiscalPeriodId", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetFiscalPeriodIdRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	[XmlElement(IsNullable = true)]
	public DateTime? date;

	public GetFiscalPeriodIdRequest()
	{
	}

	public GetFiscalPeriodIdRequest(DateTime? date)
	{
		this.date = date;
	}
}
