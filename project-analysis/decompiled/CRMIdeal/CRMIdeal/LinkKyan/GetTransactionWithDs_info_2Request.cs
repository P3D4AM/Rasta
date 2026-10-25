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
[MessageContract(WrapperName = "GetTransactionWithDs_info_2", WrapperNamespace = "KyanOnlineSaleService", IsWrapped = true)]
public class GetTransactionWithDs_info_2Request
{
	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public ValidationSoapHeader ValidationSoapHeader;

	[MessageHeader(Namespace = "KyanOnlineSaleService")]
	public AuthUser AuthUser;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 0)]
	[XmlElement(IsNullable = true)]
	public int? RS;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 1)]
	public DateTime StartDate;

	[MessageBodyMember(Namespace = "KyanOnlineSaleService", Order = 2)]
	public DateTime EndDate;

	public GetTransactionWithDs_info_2Request()
	{
	}

	public GetTransactionWithDs_info_2Request(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int? RS, DateTime StartDate, DateTime EndDate)
	{
		this.ValidationSoapHeader = ValidationSoapHeader;
		this.AuthUser = AuthUser;
		this.RS = RS;
		this.StartDate = StartDate;
		this.EndDate = EndDate;
	}
}
