using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CreateCustomerToRSResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CreateCustomerToRSResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString CreateCustomerToRSResult;

	public CreateCustomerToRSResponse()
	{
	}

	public CreateCustomerToRSResponse(ResponseDataOfString CreateCustomerToRSResult)
	{
		this.CreateCustomerToRSResult = CreateCustomerToRSResult;
	}
}
