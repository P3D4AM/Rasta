using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ApproveDocument", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ApproveDocumentRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ItemStock[] LstTransfer;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int SourceRsID;

	public ApproveDocumentRequest()
	{
	}

	public ApproveDocumentRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int SourceRsID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.LstTransfer = LstTransfer;
		this.SourceRsID = SourceRsID;
	}
}
