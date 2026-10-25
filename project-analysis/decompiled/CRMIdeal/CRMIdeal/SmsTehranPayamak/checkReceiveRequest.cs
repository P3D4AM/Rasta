using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "checkReceive", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class checkReceiveRequest
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string mobile_no;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public string text;

	[MessageBodyMember(Namespace = "", Order = 2)]
	public string line_number;

	[MessageBodyMember(Namespace = "", Order = 3)]
	public string domain;

	[MessageBodyMember(Namespace = "", Order = 4)]
	public string username;

	[MessageBodyMember(Namespace = "", Order = 5)]
	public string password;

	public checkReceiveRequest()
	{
	}

	public checkReceiveRequest(string mobile_no, string text, string line_number, string domain, string username, string password)
	{
		this.mobile_no = mobile_no;
		this.text = text;
		this.line_number = line_number;
		this.domain = domain;
		this.username = username;
		this.password = password;
	}
}
