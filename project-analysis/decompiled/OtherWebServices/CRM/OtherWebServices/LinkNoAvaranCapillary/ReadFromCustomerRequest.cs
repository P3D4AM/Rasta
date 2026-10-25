using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvaranCapillary;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class ReadFromCustomerRequest
{
	[MessageBodyMember(Name = "ReadFromCustomer", Namespace = "http://tempuri.org/", Order = 0)]
	public ReadFromCustomerRequestBody Body;

	public ReadFromCustomerRequest()
	{
	}

	public ReadFromCustomerRequest(ReadFromCustomerRequestBody Body)
	{
		this.Body = Body;
	}
}
