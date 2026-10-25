using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ItemReceivingResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ItemReceivingResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfString ItemReceivingResult;

	public ItemReceivingResponse()
	{
	}

	public ItemReceivingResponse(ResponseDataOfString ItemReceivingResult)
	{
		this.ItemReceivingResult = ItemReceivingResult;
	}
}
