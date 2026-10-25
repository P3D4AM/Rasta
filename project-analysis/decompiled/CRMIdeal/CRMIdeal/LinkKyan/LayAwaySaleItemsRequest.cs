using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "LayAwaySaleItems", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class LayAwaySaleItemsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public SaleItemObject[] lstSaleItms;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int CustomerID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public int SourceRetailStoreID;

	public LayAwaySaleItemsRequest()
	{
	}

	public LayAwaySaleItemsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int CustomerID, int SourceRetailStoreID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.lstSaleItms = lstSaleItms;
		this.CustomerID = CustomerID;
		this.SourceRetailStoreID = SourceRetailStoreID;
	}
}
