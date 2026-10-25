using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "QuickExternalTransfer", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class QuickExternalTransferRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ItemStock[] LstTransfer;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int DestinationRsID;

	public QuickExternalTransferRequest()
	{
	}

	public QuickExternalTransferRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int DestinationRsID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.LstTransfer = LstTransfer;
		this.DestinationRsID = DestinationRsID;
	}
}
