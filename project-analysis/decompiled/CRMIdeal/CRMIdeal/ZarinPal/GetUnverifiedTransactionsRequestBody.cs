using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.ZarinPal;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[DataContract(Namespace = "http://zarinpal.com/")]
public class GetUnverifiedTransactionsRequestBody
{
	[DataMember(EmitDefaultValue = false, Order = 0)]
	public string MerchantID;

	public GetUnverifiedTransactionsRequestBody()
	{
	}

	public GetUnverifiedTransactionsRequestBody(string MerchantID)
	{
		this.MerchantID = MerchantID;
	}
}
