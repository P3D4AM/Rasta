using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsMehrAfraz;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ApikeyReceivesmsLowLevel", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class ApikeyReceivesmsLowLevelRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string cApikey;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public bool lReceiveAllmsg;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public string cFromnumber;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public string[] aBody;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public string[] aMobileno;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 5)]
	public long[] aMessageid;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 6)]
	public string[] aReceivedate;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 7)]
	public string[] afromnumber;

	public ApikeyReceivesmsLowLevelRequest()
	{
	}

	public ApikeyReceivesmsLowLevelRequest(string cApikey, bool lReceiveAllmsg, string cFromnumber, string[] aBody, string[] aMobileno, long[] aMessageid, string[] aReceivedate, string[] afromnumber)
	{
		this.cApikey = cApikey;
		this.lReceiveAllmsg = lReceiveAllmsg;
		this.cFromnumber = cFromnumber;
		this.aBody = aBody;
		this.aMobileno = aMobileno;
		this.aMessageid = aMessageid;
		this.aReceivedate = aReceivedate;
		this.afromnumber = afromnumber;
	}
}
