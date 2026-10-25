using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetItemInfoWithinventoryIDandBarcodesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetItemInfoWithinventoryIDandBarcodesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfitm3 GetItemInfoWithinventoryIDandBarcodesResult;

	public GetItemInfoWithinventoryIDandBarcodesResponse()
	{
	}

	public GetItemInfoWithinventoryIDandBarcodesResponse(ResponseDataOfitm3 GetItemInfoWithinventoryIDandBarcodesResult)
	{
		this.GetItemInfoWithinventoryIDandBarcodesResult = GetItemInfoWithinventoryIDandBarcodesResult;
	}
}
