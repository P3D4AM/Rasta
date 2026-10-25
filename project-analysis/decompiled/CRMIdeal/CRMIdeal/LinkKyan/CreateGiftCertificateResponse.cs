using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "CreateGiftCertificateResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class CreateGiftCertificateResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfResult CreateGiftCertificateResult;

	public CreateGiftCertificateResponse()
	{
	}

	public CreateGiftCertificateResponse(ResponseDataOfResult CreateGiftCertificateResult)
	{
		this.CreateGiftCertificateResult = CreateGiftCertificateResult;
	}
}
