using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Mobile.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "SendSmsResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class SendSmsResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	public int SendSmsResult;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 1)]
	public long[] recId;

	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 2)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] status;

	public SendSmsResponse()
	{
	}

	public SendSmsResponse(int SendSmsResult, long[] recId, byte[] status)
	{
		this.SendSmsResult = SendSmsResult;
		this.recId = recId;
		this.status = status;
	}
}
