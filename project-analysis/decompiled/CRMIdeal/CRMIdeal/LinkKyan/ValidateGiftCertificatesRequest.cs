using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ValidateGiftCertificates", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ValidateGiftCertificatesRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string[] barcode;

	public ValidateGiftCertificatesRequest()
	{
	}

	public ValidateGiftCertificatesRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcode)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.barcode = barcode;
	}
}
