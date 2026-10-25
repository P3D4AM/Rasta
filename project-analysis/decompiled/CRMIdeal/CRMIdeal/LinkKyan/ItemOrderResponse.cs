using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ItemOrderResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ItemOrderResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString ItemOrderResult;

	public ItemOrderResponse()
	{
	}

	public ItemOrderResponse(ResponseDataOfString ItemOrderResult)
	{
		this.ItemOrderResult = ItemOrderResult;
	}
}
