using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Mobile.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSms2", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSms2Request
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public string username;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public string password;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	public string[] to;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public string from;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 4)]
	public string text;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 5)]
	public bool isflash;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 6)]
	public string udh;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 7)]
	public long[] recId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 8)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] status;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 9)]
	public int filterId;

	public SendSms2Request()
	{
	}

	public SendSms2Request(string username, string password, string[] to, string from, string text, bool isflash, string udh, long[] recId, byte[] status, int filterId)
	{
		this.username = username;
		this.password = password;
		this.to = to;
		this.from = from;
		this.text = text;
		this.isflash = isflash;
		this.udh = udh;
		this.recId = recId;
		this.status = status;
		this.filterId = filterId;
	}
}
