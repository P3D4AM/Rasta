using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.SmsTehranPayamak;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[MessageContract(WrapperName = "getCreditPriceResponse", WrapperNamespace = "urn:SMSwsdl", IsWrapped = true)]
public class getCreditPriceResponse
{
	[MessageBodyMember(Namespace = "", Order = 0)]
	public string result;

	[MessageBodyMember(Namespace = "", Order = 1)]
	public int price;

	public getCreditPriceResponse()
	{
	}

	public getCreditPriceResponse(string result, int price)
	{
		this.result = result;
		this.price = price;
	}
}
