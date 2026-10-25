using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Xml.Serialization;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[EditorBrowsable(EditorBrowsableState.Advanced)]
[MessageContract(WrapperName = "ReturnItems", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class ReturnItemsRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	public ReturnItemObject[] ReturnItems;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	[XmlElement(IsNullable = true)]
	public int? customerID;

	public ReturnItemsRequest()
	{
	}

	public ReturnItemsRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReturnItemObject[] ReturnItems, int? customerID)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.ReturnItems = ReturnItems;
		this.customerID = customerID;
	}
}
