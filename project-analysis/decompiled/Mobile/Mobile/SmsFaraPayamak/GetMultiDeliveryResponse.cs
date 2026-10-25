using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Mobile.SmsFaraPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetMultiDeliveryResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
public class GetMultiDeliveryResponse
{
	[MessageBodyMember(Namespace = "http://tempuri.org/", Order = 0)]
	[XmlElement(DataType = "base64Binary")]
	public byte[] GetMultiDeliveryResult;

	public GetMultiDeliveryResponse()
	{
	}

	public GetMultiDeliveryResponse(byte[] GetMultiDeliveryResult)
	{
		this.GetMultiDeliveryResult = GetMultiDeliveryResult;
	}
}
