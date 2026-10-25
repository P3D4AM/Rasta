using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.SmsNimadd;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "payRequestResponse", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class payRequestResponse
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string result;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public int pay_id;

	[MessageBodyMember(Namespace = "", Order = 2)]
	public string url;

	public payRequestResponse()
	{
	}

	public payRequestResponse(string result, int pay_id, string url)
	{
		this.result = result;
		this.pay_id = pay_id;
		this.url = url;
	}
}
