using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ValidateGiftCertificatesResponse", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ValidateGiftCertificatesResponse
{
	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ResponseDataOfGiftCertificate ValidateGiftCertificatesResult;

	public ValidateGiftCertificatesResponse()
	{
	}

	public ValidateGiftCertificatesResponse(ResponseDataOfGiftCertificate ValidateGiftCertificatesResult)
	{
		this.ValidateGiftCertificatesResult = ValidateGiftCertificatesResult;
	}
}
