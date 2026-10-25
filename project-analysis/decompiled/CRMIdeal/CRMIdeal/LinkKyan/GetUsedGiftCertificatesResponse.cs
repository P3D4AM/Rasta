using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "GetUsedGiftCertificatesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetUsedGiftCertificatesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfUsedGiftCertificate GetUsedGiftCertificatesResult;

	public GetUsedGiftCertificatesResponse()
	{
	}

	public GetUsedGiftCertificatesResponse(ResponseDataOfUsedGiftCertificate GetUsedGiftCertificatesResult)
	{
		this.GetUsedGiftCertificatesResult = GetUsedGiftCertificatesResult;
	}
}
