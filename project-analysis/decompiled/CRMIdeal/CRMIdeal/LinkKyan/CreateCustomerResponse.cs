using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CreateCustomerResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CreateCustomerResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString CreateCustomerResult;

	public CreateCustomerResponse()
	{
	}

	public CreateCustomerResponse(ResponseDataOfString CreateCustomerResult)
	{
		this.CreateCustomerResult = CreateCustomerResult;
	}
}
