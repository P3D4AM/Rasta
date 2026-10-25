using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRM.OtherWebServices.LinkNoAvanran_II;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(IsWrapped = false)]
public class InsertEditIntoShopKharidResponse
{
	[MessageBodyMember(Name = "InsertEditIntoShopKharidResponse", Namespace = "http://tempuri.org/", Order = 0)]
	public InsertEditIntoShopKharidResponseBody Body;

	public InsertEditIntoShopKharidResponse()
	{
	}

	public InsertEditIntoShopKharidResponse(InsertEditIntoShopKharidResponseBody Body)
	{
		this.Body = Body;
	}
}
