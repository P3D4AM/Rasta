using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CRMspMainSearchViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	public string cmpNameWithTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumberVm")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public string cmpTitle { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFame")]
	public string cmpFame { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public string cmpGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public string cmpSubGroup { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public string cmpGroupII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public string cmpType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public string cmpPresentation { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cSearchcmpPreTel")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpTo")]
	public string cmpTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cSearchcmpPreTel")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpToII")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CcmpMobile")]
	public string cmpMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public string Country { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public string Province { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public string City { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	public int? cmpReferUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	public string ReferUser { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsLName")]
	public string prsLName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsFName")]
	public string prsFName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "PrsNameVM")]
	public string PrsName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTel")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelDesc")]
	public string prsTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prsTelII")]
	public string prsTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CprsMobile")]
	public string prsMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "CprsFax")]
	public string prsFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsSubject")]
	public string cnvsSubject { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsTopicId")]
	public string cnvsTopic { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cnvsDesc")]
	public string cnvsDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "prjTitle")]
	public string PrjTitle { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	public int? cmpCountryId { get; set; }

	public int? cmpProvinceId { get; set; }

	public int? cmpCityId { get; set; }

	public int? prsId { get; set; }

	public int? prjId { get; set; }

	public int? ConversationID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MainSearchCmpUserName")]
	public string cmpUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "MainSearchCmpCode")]
	public string cmpCode { get; set; }
}
