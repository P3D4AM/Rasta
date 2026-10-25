using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SaleItemsDate", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SaleItemsDateRequest
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
	public TenderPrice[] listTenderPrice;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 3)]
	public DateTime bussinessDay;

	public SaleItemsDateRequest()
	{
	}

	public SaleItemsDateRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, TenderPrice[] listTenderPrice, DateTime bussinessDay)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.lstSaleItms = lstSaleItms;
		this.CustomerID = CustomerID;
		this.listTenderPrice = listTenderPrice;
		this.bussinessDay = bussinessDay;
	}
}
