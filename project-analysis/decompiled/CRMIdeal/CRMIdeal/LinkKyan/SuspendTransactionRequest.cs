using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SuspendTransaction", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SuspendTransactionRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public SaleItemObject[] lstSuspendItms;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	[XmlElement(IsNullable = true)]
	public int? CustomerID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public int SourceRetailStoreID;

	public SuspendTransactionRequest()
	{
	}

	public SuspendTransactionRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSuspendItms, int? CustomerID, int SourceRetailStoreID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.lstSuspendItms = lstSuspendItms;
		this.CustomerID = CustomerID;
		this.SourceRetailStoreID = SourceRetailStoreID;
	}
}
