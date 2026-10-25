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
[MessageContract(WrapperName = "GetCustomerListWithPageRow", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetCustomerListWithPageRowRequest
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	[XmlElement(IsNullable = true)]
	public DateTime? StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	[XmlElement(IsNullable = true)]
	public DateTime? EndDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public int RowNoBgin;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 3)]
	public int PageRow;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 4)]
	public int DefinationLocation;

	public GetCustomerListWithPageRowRequest()
	{
	}

	public GetCustomerListWithPageRowRequest(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, DateTime? StartDate, DateTime? EndDate, int RowNoBgin, int PageRow, int DefinationLocation)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
		this.RowNoBgin = RowNoBgin;
		this.PageRow = PageRow;
		this.DefinationLocation = DefinationLocation;
	}
}
