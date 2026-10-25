using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SaleItems", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SaleItemsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public SaleItemObject[] lstSaleItms;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	[XmlElement(IsNullable = true)]
	public int? CustomerID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public int SourceRetailStoreID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 3)]
	public TenderPrice[] listTenderPrice;

	public SaleItemsRequest()
	{
	}

	public SaleItemsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, int SourceRetailStoreID, TenderPrice[] listTenderPrice)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.lstSaleItms = lstSaleItms;
		this.CustomerID = CustomerID;
		this.SourceRetailStoreID = SourceRetailStoreID;
		this.listTenderPrice = listTenderPrice;
	}
}
