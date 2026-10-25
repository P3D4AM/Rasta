using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ReturnWholesale", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ReturnWholesaleRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public WholeSaleModel[] lstWholeSaleItms;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public int CustomerID;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public string Description;

	public ReturnWholesaleRequest()
	{
	}

	public ReturnWholesaleRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.lstWholeSaleItms = lstWholeSaleItms;
		this.CustomerID = CustomerID;
		this.Description = Description;
	}
}
