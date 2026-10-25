using System;
using System.ComponentModel.DataAnnotations;
using CRM.Resources;

namespace CRM.Models;

public class CrmCompanyLanguageViewModel
{
	[Key]
	public int CompanyID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpImportDate")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(8, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string ImportDate { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNumber")]
	public int? cmpNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpName")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNameEng")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNameEng { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTitleId")]
	public int? cmpTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFame")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFame { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpActivityType")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpActivityType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupId")]
	public int? cmpGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSubGroupId")]
	public int? cmpSubGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdII")]
	public int? cmpGroupIdII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIII")]
	public int? cmpGroupIdIII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpGroupIdIV")]
	public int? cmpGroupIdIV { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTypeId")]
	public int? cmpTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPresentationId")]
	public int? cmpPresentationId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpTo")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPreTelII")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPreTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelUpToII")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelUpToII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTelIIDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpTelIIDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCountryId")]
	public int? cmpCountryId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpProvinceId")]
	public int? cmpProvinceId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCityId")]
	public int? cmpCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAddressDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAddressDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpZipCodeI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpWebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEmail { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInteresting")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpInteresting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpDescription { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpUserName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpUserName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpPassword")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[DataType(DataType.Password)]
	public string cmpPassword { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFirstRegisterUserId")]
	public int? cmpFirstRegisterUserId { get; set; }

	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int AddType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpRegistrationNumber")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpRegistrationNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpEconomicCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpEconomicCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNationalCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpBuyLimit")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpBuyLimit { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccountNumber")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAccountNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpAccInquiry")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpAccInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpFreight")]
	[MaxLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(200, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpFreight { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpInquiry")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpInquiry { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpReferUserId")]
	[Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorEmpty")]
	public int cmpReferUserId { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSpecialWordForCI")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpSpecialWordForCI { get; set; }

	public string cmpCode { get; set; }

	public string cmpEffectiveDatePersian { get; set; }

	public DateTime? cmpEffectiveDateTime { get; set; }

	public DateTime? ImportDateTime { get; set; }

	public string cmpName_Lang { get; set; }

	public string cmpFame_Lang { get; set; }

	public string cmpActivityType_Lang { get; set; }

	public string cmpTelDesc_Lang { get; set; }

	public string cmpTelIIDesc_Lang { get; set; }

	public string cmpFaxDesc_Lang { get; set; }

	public string cmpAddress_Lang { get; set; }

	public string cmpAddressDesc_Lang { get; set; }

	public string cmpInteresting_Lang { get; set; }

	public string cmpSpecialPoint_Lang { get; set; }

	public string cmpDescription_Lang { get; set; }

	public string cmpSpecialWordForCI_Lang { get; set; }

	public string cmpInquiry_Lang { get; set; }

	public bool? cmpIsDraft { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpKind")]
	public int? cmpKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPersonId")]
	public int? cmpMainPersonId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsLName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsLName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsFName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTitle")]
	public int? prsTitleId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsMobile { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsNationalCode")]
	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsNationalCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string prsEmail { get; set; }

	public string prsLName_Lang { get; set; }

	public string prsFName_Lang { get; set; }

	public string CompanyGroupsMultiIds { get; set; }

	public string cmpCoordinateLatitude { get; set; }

	public string cmpCoordinateLongitude { get; set; }

	public int? cmpCoordinateZoomLevel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpNameOfficial")]
	[MaxLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(300, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpNameOfficial { get; set; }

	public string cmpNameOfficial_Lang { get; set; }

	public string cmpLinkAccCode { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string cmpLinkAccData { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpQuickRegisterDefSettingId")]
	public int? CompanyQuickRegisterDefSettingId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsJob")]
	public int? prsJobId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsType")]
	public int? prsTypeId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsGroup")]
	public int? prsGroupId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsSex")]
	public int? prsSexId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsEducation")]
	public int? prsEducationId { get; set; }

	public int? prsCountryId { get; set; }

	public int? prsProvinceId { get; set; }

	public int? prsCityId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsDepartment")]
	public int? prsDepartmentId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsSpecialPoint")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsSpecialPoint { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsDescription")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsDescription { get; set; }

	public string prsSpecialPoint_Lang { get; set; }

	public string prsDescription_Lang { get; set; }

	public int CompanyPersonID { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsLName")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsLNameI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsFName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFNameI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTitle")]
	public int? prsTitleIdI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsMobile")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsMobileI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsNationalCode")]
	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsNationalCodeI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsEmail")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	[RegularExpression("\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "ErrorInFormat")]
	public string prsEmailI { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsPreTel")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsPreTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTel")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTelUpTo")]
	[MaxLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(10, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelUpTo { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTelDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsTelII")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsTelII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsFax")]
	[MaxLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(15, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFax { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsFaxDesc")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFaxDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsWebSite")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsWebSite { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsStopSendSms")]
	public bool? prsStopSendSms { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsEmailII")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsEmailII { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsAddressDesc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsAddressDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsPostBox")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsPostBox { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsIdentityNumber")]
	[MaxLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(30, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsIdentityNumber { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsFatherName")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsFatherName { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsBirthDate")]
	public string prsBirthDate { get; set; }

	public DateTime? prsBirthDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsBirthPlace")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsBirthPlace { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsIsMarried")]
	public bool? prsIsMarried { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsMarriageDate")]
	public string prsMarriageDate { get; set; }

	public DateTime? prsMarriageDateTime { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsEducationField")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsEducationField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsStudyField")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsStudyField { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsSkill")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsSkill { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpMainPrsInteresting")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string prsInteresting { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSuppUserId")]
	public int? cmpSuppUserId { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpSuppUserId")]
	public string cmpSuppUser { get; set; }

	public string prsTelDesc_Lang { get; set; }

	public string prsFaxDesc_Lang { get; set; }

	public string prsAddress_Lang { get; set; }

	public string prsAddressDesc_Lang { get; set; }

	public string prsEducationField_Lang { get; set; }

	public string prsSkill_Lang { get; set; }

	public string prsStudyField_Lang { get; set; }

	public string prsFatherName_Lang { get; set; }

	public string prsInteresting_Lang { get; set; }

	public string prsBirthPlace_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpCampaignIds")]
	public string cmpCampaignIds { get; set; }

	public string cmpCampaignIdsList { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialAddress")]
	[MaxLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(250, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpOfficialAddress { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialZipCode")]
	[MaxLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(50, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpOfficialZipCode { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialDesc")]
	[MaxLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(500, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpOfficialDesc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialTel")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string cmpOfficialTel { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialKind")]
	public int? cmpOfficialKind { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpOfficialCityId")]
	public int? cmpOfficialCityId { get; set; }

	public int? cmpOfficialCountryId { get; set; }

	public int? cmpOfficialProvinceId { get; set; }

	public string cmpOfficialAddress_Lang { get; set; }

	public string cmpOfficialDesc_Lang { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTspCmpTob")]
	public int? TspCmpTob { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTspCmpBbc")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspCmpBbc { get; set; }

	[Display(ResourceType = typeof(Labels), Name = "cmpTspCmpBpn")]
	[MaxLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceeded")]
	[StringLength(100, ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "LimitExceededNumber")]
	public string TspCmpBpn { get; set; }

	public string cmpCIds { get; set; }

	public string cmpCentersNames { get; set; }

	public string prsCIds { get; set; }
}
