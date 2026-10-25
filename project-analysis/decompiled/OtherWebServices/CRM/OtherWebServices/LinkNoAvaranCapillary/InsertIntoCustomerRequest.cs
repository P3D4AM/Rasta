using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class InsertIntoCustomerRequest
{
	[MessageBodyMember(Name = "InsertIntoCustomer", Namespace = "http://tempuri.org/", Order = 0)]
	public InsertIntoCustomerRequestBody Body;

	public InsertIntoCustomerRequest()
	{
	}

	public InsertIntoCustomerRequest(InsertIntoCustomerRequestBody Body)
	{
		this.Body = Body;
	}
}
