using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsMehrAfraz;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ReceivesmsLowLevelResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class ReceivesmsLowLevelResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string[] aBody;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string[] aMobileno;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public long[] aMessageid;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public string[] aReceivedate;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public string[] afromnumber;

	public ReceivesmsLowLevelResponse()
	{
	}

	public ReceivesmsLowLevelResponse(string[] aBody, string[] aMobileno, long[] aMessageid, string[] aReceivedate, string[] afromnumber)
	{
		this.aBody = aBody;
		this.aMobileno = aMobileno;
		this.aMessageid = aMessageid;
		this.aReceivedate = aReceivedate;
		this.afromnumber = afromnumber;
	}
}
