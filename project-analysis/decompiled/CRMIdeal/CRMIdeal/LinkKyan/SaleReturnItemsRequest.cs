using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "SaleReturnItems", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class SaleReturnItemsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public string RecieptBarcodeSale;

	public SaleReturnItemsRequest()
	{
	}

	public SaleReturnItemsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcodeSale)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.RecieptBarcodeSale = RecieptBarcodeSale;
	}
}
