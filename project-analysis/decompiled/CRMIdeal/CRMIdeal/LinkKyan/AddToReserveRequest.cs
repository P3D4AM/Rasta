using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "AddToReserve", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class AddToReserveRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ItemStock[] ItemsID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public bool CancelReservation;

	public AddToReserveRequest()
	{
	}

	public AddToReserveRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] ItemsID, bool CancelReservation)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.ItemsID = ItemsID;
		this.CancelReservation = CancelReservation;
	}
}
