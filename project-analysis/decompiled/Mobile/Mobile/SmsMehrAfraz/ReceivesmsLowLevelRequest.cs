using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace Mobile.SmsMehrAfraz;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "ReceivesmsLowLevel", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class ReceivesmsLowLevelRequest
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string cUserName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string cPassword;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public bool lReceiveAllmsg;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public string cDomainName;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public string cFromnumber;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 5)]
	public string[] aBody;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 6)]
	public string[] aMobileno;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 7)]
	public long[] aMessageid;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 8)]
	public string[] aReceivedate;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 9)]
	public string[] afromnumber;

	public ReceivesmsLowLevelRequest()
	{
	}

	public ReceivesmsLowLevelRequest(string cUserName, string cPassword, bool lReceiveAllmsg, string cDomainName, string cFromnumber, string[] aBody, string[] aMobileno, long[] aMessageid, string[] aReceivedate, string[] afromnumber)
	{
		this.cUserName = cUserName;
		this.cPassword = cPassword;
		this.lReceiveAllmsg = lReceiveAllmsg;
		this.cDomainName = cDomainName;
		this.cFromnumber = cFromnumber;
		this.aBody = aBody;
		this.aMobileno = aMobileno;
		this.aMessageid = aMessageid;
		this.aReceivedate = aReceivedate;
		this.afromnumber = afromnumber;
	}
}
