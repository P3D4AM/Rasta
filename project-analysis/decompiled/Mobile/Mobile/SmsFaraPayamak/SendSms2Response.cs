using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Mobile.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSms2Response", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSms2Response
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int SendSms2Result;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public long[] recId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] status;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 3)]
	public int filterId;

	public SendSms2Response()
	{
	}

	public SendSms2Response(int SendSms2Result, long[] recId, byte[] status, int filterId)
	{
		this.SendSms2Result = SendSms2Result;
		this.recId = recId;
		this.status = status;
		this.filterId = filterId;
	}
}
