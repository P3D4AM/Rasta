using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UsersMetadata))]
public class Users
{
	public int UserId { get; set; }

	public int? Row { get; set; }

	public string FName { get; set; }

	public string LName { get; set; }

	public string PersCode { get; set; }

	public string UserName { get; set; }

	public string Password { get; set; }

	public string IsAdmin { get; set; }

	public bool? IsActive { get; set; }

	public string Description { get; set; }

	public int? UserId1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string IPAddress { get; set; }

	public string Tel { get; set; }

	public string TelDesc { get; set; }

	public int? PositionId { get; set; }

	public int? SignatureId { get; set; }

	public string DepartmentInfo { get; set; }

	public int? ResponsibleUserId { get; set; }

	public string ComputerName { get; set; }

	public Guid? GUId { get; set; }

	public bool? CallreIdDeActive { get; set; }

	public string CallreIdDeActiveLines { get; set; }

	public bool? DisableInternalMessageAllarmVoice { get; set; }

	public bool? DisableReceiveCNVSInfoAllarm { get; set; }

	public string EmailAttachFileLocation { get; set; }

	public string AppType { get; set; }

	public bool? CanSetFree { get; set; }

	public string UserCIPatternFormulaPopUp { get; set; }

	public bool? UseClientNameForNetworking { get; set; }

	public int? LanguageID { get; set; }

	public bool? AllowCopyOtherLanguage { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public bool? UserIsActiveInWinApp { get; set; }

	public bool? UserIsActiveInWebApp { get; set; }

	public bool? UserIsActiveInMobApp { get; set; }

	public string CoordinateLatitude { get; set; }

	public string CoordinateLongitude { get; set; }

	public DateTime? CoordinateLastDate { get; set; }

	public string CoordinateLastDatePersian { get; set; }

	public bool? MobAppBaseInfoNeedUpdate { get; set; }

	public bool? UserIsActiveInFOSetting { get; set; }

	public bool? UserAccessDailyChrtAllUsers { get; set; }

	public bool? UserAccessSaleChrtAllUsers { get; set; }

	public string MobAppBaseInfoNeedUpdateDetail { get; set; }

	public int? MaxNumberCmpDraft { get; set; }

	public string Mobile { get; set; }

	public string MobileII { get; set; }

	public string Address { get; set; }

	public string FatherName { get; set; }

	public string NationalCode { get; set; }

	public string IdentityNumber { get; set; }

	public string InsuranceCode { get; set; }

	public DateTime? StartDate { get; set; }

	public string StartDatePersian { get; set; }

	public DateTime? ExpireDate { get; set; }

	public string ExpireDatePersian { get; set; }

	public int? UserGroupId { get; set; }

	public string UserExtensions { get; set; }

	public string LinkAccUserIdStr { get; set; }

	public string LinkAccUserCode { get; set; }

	public bool? MobDeActiveAccessToLocation { get; set; }

	public DateTime? MobAppBaseInfoLastUpdate { get; set; }

	public string Nickname { get; set; }

	public bool? DeActiveSmartTimeAttendance { get; set; }

	public string MobImeiCode { get; set; }

	public bool? UserIsActiveInHRM { get; set; }

	public string MobHRMImeiCode { get; set; }

	public string AlternativeUserIds { get; set; }

	public bool? ActiveMobMovementTracking { get; set; }

	public double? MobMovementTrackingDistanceInterval { get; set; }

	public int? MobMovementTrackingTimeInterval { get; set; }

	public string DefCmpPrjTitle { get; set; }

	public bool? MobDeActiveScreenshot { get; set; }

	public bool? MobCallerIdDeActive { get; set; }

	public string MobAppDevSetting { get; set; }

	public int? MobUserAppUseCnt { get; set; }

	public int? MobHRMUserAppUseCnt { get; set; }

	public bool? UserIsActiveInCIC { get; set; }

	public int? MobCICUserAppUseCnt { get; set; }

	public bool? CallerIdDeActiveFromMobile { get; set; }

	public string ActiveDirectoryUser { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public string UserCIds { get; set; }

	public int? UserLastCId { get; set; }

	public int? MobHRMLoginMode { get; set; }

	public int? UserLoginCheckLocationType { get; set; }

	public string UserLoginCheckLocations { get; set; }

	public int? UserCId { get; set; }

	public int? ShiftWorkingId { get; set; }

	public bool? DeActiveLoginWithoutShift { get; set; }

	public bool? AppLocationRequired { get; set; }

	public bool? CrmNotifDeactivInHrm { get; set; }

	public DateTime? LastCheckEmailDate { get; set; }

	public string CallPreNumber { get; set; }

	public virtual ICollection<Centers> Centers { get; set; }

	public virtual ICollection<Centers> Centers1 { get; set; }

	public virtual Centers Centers2 { get; set; }

	public virtual Centers Centers3 { get; set; }

	public virtual ICollection<City> City { get; set; }

	public virtual ICollection<City> City1 { get; set; }

	public virtual ICollection<City> City2 { get; set; }

	public virtual ICollection<City> City3 { get; set; }

	public virtual ICollection<Country> Country { get; set; }

	public virtual ICollection<Country> Country1 { get; set; }

	public virtual ICollection<Country> Country2 { get; set; }

	public virtual ICollection<CrmAddressing> CrmAddressing { get; set; }

	public virtual ICollection<CrmAddressing> CrmAddressing1 { get; set; }

	public virtual ICollection<CrmAddressingType> CrmAddressingType { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts1 { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts2 { get; set; }

	public virtual ICollection<CrmBankingAccountType> CrmBankingAccountType { get; set; }

	public virtual ICollection<CrmBankingAccountType> CrmBankingAccountType1 { get; set; }

	public virtual ICollection<CrmBankingBanks> CrmBankingBanks { get; set; }

	public virtual ICollection<CrmBankingBanks> CrmBankingBanks1 { get; set; }

	public virtual ICollection<CrmBankingBranches> CrmBankingBranches { get; set; }

	public virtual ICollection<CrmBankingBranches> CrmBankingBranches1 { get; set; }

	public virtual ICollection<CrmCallBlackList> CrmCallBlackList { get; set; }

	public virtual ICollection<CrmCallBlackList> CrmCallBlackList1 { get; set; }

	public virtual ICollection<CrmCallBlackList> CrmCallBlackList2 { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory1 { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory2 { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory3 { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory4 { get; set; }

	public virtual ICollection<CrmCallType> CrmCallType { get; set; }

	public virtual ICollection<CrmCallType> CrmCallType1 { get; set; }

	public virtual ICollection<CrmCallType> CrmCallType2 { get; set; }

	public virtual ICollection<CrmCashes> CrmCashes { get; set; }

	public virtual ICollection<CrmCashes> CrmCashes1 { get; set; }

	public virtual ICollection<CrmCmsComments> CrmCmsComments { get; set; }

	public virtual ICollection<CrmCmsComments> CrmCmsComments1 { get; set; }

	public virtual ICollection<CrmCmsComments> CrmCmsComments2 { get; set; }

	public virtual ICollection<CrmCmsFiles> CrmCmsFiles { get; set; }

	public virtual ICollection<CrmCmsFiles> CrmCmsFiles1 { get; set; }

	public virtual ICollection<CrmCmsFooter> CrmCmsFooter { get; set; }

	public virtual ICollection<CrmCmsFooter> CrmCmsFooter1 { get; set; }

	public virtual ICollection<CrmCmsGallery> CrmCmsGallery { get; set; }

	public virtual ICollection<CrmCmsGallery> CrmCmsGallery1 { get; set; }

	public virtual ICollection<CrmCmsGalleryItems> CrmCmsGalleryItems { get; set; }

	public virtual ICollection<CrmCmsGalleryItems> CrmCmsGalleryItems1 { get; set; }

	public virtual ICollection<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems { get; set; }

	public virtual ICollection<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems1 { get; set; }

	public virtual ICollection<CrmCmsHomePageSections> CrmCmsHomePageSections { get; set; }

	public virtual ICollection<CrmCmsHomePageSections> CrmCmsHomePageSections1 { get; set; }

	public virtual ICollection<CrmCmsLikes> CrmCmsLikes { get; set; }

	public virtual ICollection<CrmCmsLikes> CrmCmsLikes1 { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus1 { get; set; }

	public virtual ICollection<CrmCmsNews> CrmCmsNews { get; set; }

	public virtual ICollection<CrmCmsNews> CrmCmsNews1 { get; set; }

	public virtual ICollection<CrmCmsNews> CrmCmsNews2 { get; set; }

	public virtual ICollection<CrmCmsNewsGroups> CrmCmsNewsGroups { get; set; }

	public virtual ICollection<CrmCmsNewsGroups> CrmCmsNewsGroups1 { get; set; }

	public virtual ICollection<CrmCmsObjectTypes> CrmCmsObjectTypes { get; set; }

	public virtual ICollection<CrmCmsObjectTypes> CrmCmsObjectTypes1 { get; set; }

	public virtual ICollection<CrmCmsPages> CrmCmsPages { get; set; }

	public virtual ICollection<CrmCmsPages> CrmCmsPages1 { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups> CrmCmsWidgetGroups { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups> CrmCmsWidgetGroups1 { get; set; }

	public virtual ICollection<CrmCmsWidgets> CrmCmsWidgets { get; set; }

	public virtual ICollection<CrmCmsWidgets> CrmCmsWidgets1 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany1 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany2 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany3 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany4 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany5 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany6 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany7 { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany8 { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses1 { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses2 { get; set; }

	public virtual ICollection<CrmCompanyAddressType> CrmCompanyAddressType { get; set; }

	public virtual ICollection<CrmCompanyAddressType> CrmCompanyAddressType1 { get; set; }

	public virtual ICollection<CrmCompanyCampaign> CrmCompanyCampaign { get; set; }

	public virtual ICollection<CrmCompanyCampaign> CrmCompanyCampaign1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenDepartment> CrmCompanyForbiddenDepartment { get; set; }

	public virtual ICollection<CrmCompanyForbiddenDepartment> CrmCompanyForbiddenDepartment1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenDepartment> CrmCompanyForbiddenDepartment2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince2 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup1 { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup2 { get; set; }

	public virtual ICollection<CrmCompanyGroups> CrmCompanyGroups { get; set; }

	public virtual ICollection<CrmCompanyGroups> CrmCompanyGroups1 { get; set; }

	public virtual ICollection<CrmCompanyGroups> CrmCompanyGroups2 { get; set; }

	public virtual ICollection<CrmCompanyGroupsII> CrmCompanyGroupsII { get; set; }

	public virtual ICollection<CrmCompanyGroupsII> CrmCompanyGroupsII1 { get; set; }

	public virtual ICollection<CrmCompanyGroupsII> CrmCompanyGroupsII2 { get; set; }

	public virtual ICollection<CrmCompanyGroupsIII> CrmCompanyGroupsIII { get; set; }

	public virtual ICollection<CrmCompanyGroupsIII> CrmCompanyGroupsIII1 { get; set; }

	public virtual ICollection<CrmCompanyGroupsIII> CrmCompanyGroupsIII2 { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV> CrmCompanyGroupsIV { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV> CrmCompanyGroupsIV1 { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV> CrmCompanyGroupsIV2 { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti> CrmCompanyGroupsMulti { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti> CrmCompanyGroupsMulti1 { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti> CrmCompanyGroupsMulti2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessDepartment> CrmCompanyJustAccessDepartment { get; set; }

	public virtual ICollection<CrmCompanyJustAccessDepartment> CrmCompanyJustAccessDepartment1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessDepartment> CrmCompanyJustAccessDepartment2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince2 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup1 { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup2 { get; set; }

	public virtual ICollection<CrmCompanyLoGo> CrmCompanyLoGo { get; set; }

	public virtual ICollection<CrmCompanyLoGo> CrmCompanyLoGo1 { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag1 { get; set; }

	public virtual ICollection<CrmCompanyMultiGroups> CrmCompanyMultiGroups { get; set; }

	public virtual ICollection<CrmCompanyMultiGroups> CrmCompanyMultiGroups1 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons1 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons2 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons3 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons4 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons5 { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons6 { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate1 { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate2 { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate3 { get; set; }

	public virtual ICollection<CrmCompanyPictureAlbums> CrmCompanyPictureAlbums { get; set; }

	public virtual ICollection<CrmCompanyPictureAlbums> CrmCompanyPictureAlbums1 { get; set; }

	public virtual ICollection<CrmCompanyPictures> CrmCompanyPictures { get; set; }

	public virtual ICollection<CrmCompanyPictures> CrmCompanyPictures1 { get; set; }

	public virtual ICollection<CrmCompanyPresentation> CrmCompanyPresentation { get; set; }

	public virtual ICollection<CrmCompanyPresentation> CrmCompanyPresentation1 { get; set; }

	public virtual ICollection<CrmCompanyPresentation> CrmCompanyPresentation2 { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting1 { get; set; }

	public virtual ICollection<CrmCompanySubGroups> CrmCompanySubGroups { get; set; }

	public virtual ICollection<CrmCompanySubGroups> CrmCompanySubGroups1 { get; set; }

	public virtual ICollection<CrmCompanySubGroups> CrmCompanySubGroups2 { get; set; }

	public virtual ICollection<CrmCompanyTitle> CrmCompanyTitle { get; set; }

	public virtual ICollection<CrmCompanyTitle> CrmCompanyTitle1 { get; set; }

	public virtual ICollection<CrmCompanyTitle> CrmCompanyTitle2 { get; set; }

	public virtual ICollection<CrmCompanyType> CrmCompanyType { get; set; }

	public virtual ICollection<CrmCompanyType> CrmCompanyType1 { get; set; }

	public virtual ICollection<CrmCompanyType> CrmCompanyType2 { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden1 { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden2 { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation1 { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation2 { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation3 { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation4 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext1 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext2 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext3 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext4 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext5 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext6 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext7 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext8 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext9 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext10 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext11 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext12 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext13 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext14 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext15 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext16 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext17 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext18 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext19 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext20 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext21 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext22 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext23 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext24 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext25 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext26 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext27 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext28 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext29 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext30 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext31 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext32 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext33 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext34 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext35 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext36 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext37 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext38 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext39 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext40 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext41 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext42 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext43 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext44 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext45 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext46 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext47 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext48 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext49 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext50 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext51 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext52 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext53 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext54 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext55 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext56 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext57 { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext58 { get; set; }

	public virtual ICollection<CrmConversationPriority> CrmConversationPriority { get; set; }

	public virtual ICollection<CrmConversationPriority> CrmConversationPriority1 { get; set; }

	public virtual ICollection<CrmConversationPriority> CrmConversationPriority2 { get; set; }

	public virtual ICollection<CrmConversationReferUsers> CrmConversationReferUsers { get; set; }

	public virtual ICollection<CrmConversationReferUsers> CrmConversationReferUsers1 { get; set; }

	public virtual ICollection<CrmConversationReferUsers> CrmConversationReferUsers2 { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus1 { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus2 { get; set; }

	public virtual ICollection<CrmConversationStatusGroups> CrmConversationStatusGroups { get; set; }

	public virtual ICollection<CrmConversationStatusGroups> CrmConversationStatusGroups1 { get; set; }

	public virtual ICollection<CrmConversationStatusGroups> CrmConversationStatusGroups2 { get; set; }

	public virtual ICollection<CrmConversationStatusGroups> CrmConversationStatusGroups3 { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult1 { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult2 { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy1 { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps> CrmConversationStatusSalesFunnelSteps { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps> CrmConversationStatusSalesFunnelSteps1 { get; set; }

	public virtual ICollection<CrmConversationTopics> CrmConversationTopics { get; set; }

	public virtual ICollection<CrmConversationTopics> CrmConversationTopics1 { get; set; }

	public virtual ICollection<CrmConversationTopics> CrmConversationTopics2 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails1 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails2 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails3 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues1 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues2 { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues3 { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields1 { get; set; }

	public virtual ICollection<CrmDyFormFieldTypes> CrmDyFormFieldTypes { get; set; }

	public virtual ICollection<CrmDyFormFieldTypes> CrmDyFormFieldTypes1 { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions> CrmDyFormRegularExpressions { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions> CrmDyFormRegularExpressions1 { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms1 { get; set; }

	public virtual ICollection<CrmDyFormUserAccess> CrmDyFormUserAccess { get; set; }

	public virtual ICollection<CrmDyFormUserAccess> CrmDyFormUserAccess1 { get; set; }

	public virtual ICollection<CrmDyFormUserAccess> CrmDyFormUserAccess2 { get; set; }

	public virtual ICollection<CrmDyFormWorkflows> CrmDyFormWorkflows { get; set; }

	public virtual ICollection<CrmDyFormWorkflows> CrmDyFormWorkflows1 { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps1 { get; set; }

	public virtual ICollection<CrmFileDirectoryType> CrmFileDirectoryType { get; set; }

	public virtual ICollection<CrmFileDirectoryType> CrmFileDirectoryType1 { get; set; }

	public virtual ICollection<CrmFileDirectoryType> CrmFileDirectoryType2 { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr> CrmFileDirectoryTypeOpr { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr> CrmFileDirectoryTypeOpr1 { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr> CrmFileDirectoryTypeOpr2 { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory1 { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory2 { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate1 { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate2 { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplateType> CrmFilesDirectoryTemplateType { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting2 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting3 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting4 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting5 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting6 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting7 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting8 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting9 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting10 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting11 { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting12 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister1 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister2 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister3 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister4 { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister5 { get; set; }

	public virtual ICollection<CrmFund> CrmFund { get; set; }

	public virtual ICollection<CrmFund> CrmFund1 { get; set; }

	public virtual ICollection<CrmFund> CrmFund2 { get; set; }

	public virtual ICollection<CrmFund> CrmFund3 { get; set; }

	public virtual ICollection<CrmFund> CrmFund4 { get; set; }

	public virtual ICollection<CrmFundGroups> CrmFundGroups { get; set; }

	public virtual ICollection<CrmFundGroups> CrmFundGroups1 { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage1 { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage2 { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage3 { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext1 { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext2 { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext3 { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails1 { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails2 { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails3 { get; set; }

	public virtual ICollection<CrmInternalMessageGroup> CrmInternalMessageGroup { get; set; }

	public virtual ICollection<CrmInternalMessageGroup> CrmInternalMessageGroup1 { get; set; }

	public virtual ICollection<CrmInternalMessageGroup> CrmInternalMessageGroup2 { get; set; }

	public virtual ICollection<CrmInternalMessagePriority> CrmInternalMessagePriority { get; set; }

	public virtual ICollection<CrmInternalMessagePriority> CrmInternalMessagePriority1 { get; set; }

	public virtual ICollection<CrmInternalMessagePriority> CrmInternalMessagePriority2 { get; set; }

	public virtual ICollection<CrmInternalMessageSelectReceiver> CrmInternalMessageSelectReceiver { get; set; }

	public virtual ICollection<CrmInternalMessageSelectReceiver> CrmInternalMessageSelectReceiver1 { get; set; }

	public virtual ICollection<CrmInternalMessageTreeType> CrmInternalMessageTreeType { get; set; }

	public virtual ICollection<CrmInternalMessageTreeType> CrmInternalMessageTreeType1 { get; set; }

	public virtual ICollection<CrmInternalMessageTreeType> CrmInternalMessageTreeType2 { get; set; }

	public virtual ICollection<CrmInternalMessageType> CrmInternalMessageType { get; set; }

	public virtual ICollection<CrmInternalMessageType> CrmInternalMessageType1 { get; set; }

	public virtual ICollection<CrmInternalMessageType> CrmInternalMessageType2 { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank1 { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank2 { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup> CrmKnowledgeTankGroup { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup> CrmKnowledgeTankGroup1 { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup> CrmKnowledgeTankGroup2 { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission1 { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority> CrmKnowledgeTankPriority { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority> CrmKnowledgeTankPriority1 { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority> CrmKnowledgeTankPriority2 { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave1 { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave2 { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave3 { get; set; }

	public virtual ICollection<CrmLeaveKinds> CrmLeaveKinds { get; set; }

	public virtual ICollection<CrmLeaveStatus> CrmLeaveStatus { get; set; }

	public virtual ICollection<CrmLeaveStayType> CrmLeaveStayType { get; set; }

	public virtual ICollection<CrmLeaveType> CrmLeaveType { get; set; }

	public virtual ICollection<CrmLeaveVehicleType> CrmLeaveVehicleType { get; set; }

	public virtual ICollection<CrmLinkAccArpaSetting> CrmLinkAccArpaSetting { get; set; }

	public virtual ICollection<CrmLinkAccArpaSetting> CrmLinkAccArpaSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccByViewSetting> CrmLinkAccByViewSetting { get; set; }

	public virtual ICollection<CrmLinkAccByViewSetting> CrmLinkAccByViewSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccChamberCommerceSetting> CrmLinkAccChamberCommerceSetting { get; set; }

	public virtual ICollection<CrmLinkAccChamberCommerceSetting> CrmLinkAccChamberCommerceSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccErrorLogs> CrmLinkAccErrorLogs { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSetting> CrmLinkAccHamrahanSetting { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSetting> CrmLinkAccHamrahanSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSettingDetails> CrmLinkAccHamrahanSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSettingDetails> CrmLinkAccHamrahanSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccHolooSetting> CrmLinkAccHolooSetting { get; set; }

	public virtual ICollection<CrmLinkAccHolooSetting> CrmLinkAccHolooSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccHolooSettingDetails> CrmLinkAccHolooSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccHolooSettingDetails> CrmLinkAccHolooSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccKyanSetting> CrmLinkAccKyanSetting { get; set; }

	public virtual ICollection<CrmLinkAccKyanSetting> CrmLinkAccKyanSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccNoAvIISetting> CrmLinkAccNoAvIISetting { get; set; }

	public virtual ICollection<CrmLinkAccNoAvIISetting> CrmLinkAccNoAvIISetting1 { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSetting> CrmLinkAccNoAvSetting { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSetting> CrmLinkAccNoAvSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSettingDetails> CrmLinkAccNoAvSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSettingDetails> CrmLinkAccNoAvSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSetting> CrmLinkAccPayvastSetting { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSetting> CrmLinkAccPayvastSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSettingDetails> CrmLinkAccPayvastSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSettingDetails> CrmLinkAccPayvastSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccSetting> CrmLinkAccSetting { get; set; }

	public virtual ICollection<CrmLinkAccSetting> CrmLinkAccSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails> CrmLinkAccSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails> CrmLinkAccSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccShomaranSetting> CrmLinkAccShomaranSetting { get; set; }

	public virtual ICollection<CrmLinkAccShomaranSetting> CrmLinkAccShomaranSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISetting> CrmLinkAccShygunIISetting { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISetting> CrmLinkAccShygunIISetting1 { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISettingDetails> CrmLinkAccShygunIISettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISettingDetails> CrmLinkAccShygunIISettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccShygunSetting> CrmLinkAccShygunSetting { get; set; }

	public virtual ICollection<CrmLinkAccShygunSetting> CrmLinkAccShygunSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccShygunSettingDetails> CrmLinkAccShygunSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccShygunSettingDetails> CrmLinkAccShygunSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkAccSystems> CrmLinkAccSystems { get; set; }

	public virtual ICollection<CrmLinkAccSystems> CrmLinkAccSystems1 { get; set; }

	public virtual ICollection<CrmLinkAccTarazSetting> CrmLinkAccTarazSetting { get; set; }

	public virtual ICollection<CrmLinkAccTarazSetting> CrmLinkAccTarazSetting1 { get; set; }

	public virtual ICollection<CrmLinkAccTarazSettingDetails> CrmLinkAccTarazSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccTarazSettingDetails> CrmLinkAccTarazSettingDetails1 { get; set; }

	public virtual ICollection<CrmLinkedCompany> CrmLinkedCompany { get; set; }

	public virtual ICollection<CrmLinkedCompany> CrmLinkedCompany1 { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls1 { get; set; }

	public virtual ICollection<CrmLinkedType> CrmLinkedType { get; set; }

	public virtual ICollection<CrmLinkedType> CrmLinkedType1 { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions1 { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers1 { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers2 { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers3 { get; set; }

	public virtual ICollection<CrmMenuModel> CrmMenuModel { get; set; }

	public virtual ICollection<CrmMenuModel> CrmMenuModel1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting1 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting2 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting3 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting4 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting5 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting6 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting7 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting8 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting9 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting10 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting11 { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting12 { get; set; }

	public virtual ICollection<CrmNumRefSetting> CrmNumRefSetting { get; set; }

	public virtual ICollection<CrmNumRefSetting> CrmNumRefSetting1 { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo1 { get; set; }

	public virtual ICollection<CrmOperationsType> CrmOperationsType { get; set; }

	public virtual ICollection<CrmOperationsType> CrmOperationsType1 { get; set; }

	public virtual ICollection<CrmPersonDepartments> CrmPersonDepartments { get; set; }

	public virtual ICollection<CrmPersonDepartments> CrmPersonDepartments1 { get; set; }

	public virtual ICollection<CrmPersonDepartments> CrmPersonDepartments2 { get; set; }

	public virtual ICollection<CrmPersonGroups> CrmPersonGroups { get; set; }

	public virtual ICollection<CrmPersonGroups> CrmPersonGroups1 { get; set; }

	public virtual ICollection<CrmPersonGroups> CrmPersonGroups2 { get; set; }

	public virtual ICollection<CrmPersonJobs> CrmPersonJobs { get; set; }

	public virtual ICollection<CrmPersonJobs> CrmPersonJobs1 { get; set; }

	public virtual ICollection<CrmPersonJobs> CrmPersonJobs2 { get; set; }

	public virtual ICollection<CrmPersonPicture> CrmPersonPicture { get; set; }

	public virtual ICollection<CrmPersonPicture> CrmPersonPicture1 { get; set; }

	public virtual ICollection<CrmPersonTitle> CrmPersonTitle { get; set; }

	public virtual ICollection<CrmPersonTitle> CrmPersonTitle1 { get; set; }

	public virtual ICollection<CrmPersonTitle> CrmPersonTitle2 { get; set; }

	public virtual ICollection<CrmPersonType> CrmPersonType { get; set; }

	public virtual ICollection<CrmPersonType> CrmPersonType1 { get; set; }

	public virtual ICollection<CrmPersonType> CrmPersonType2 { get; set; }

	public virtual ICollection<CrmProjectCategory> CrmProjectCategory { get; set; }

	public virtual ICollection<CrmProjectCategory> CrmProjectCategory1 { get; set; }

	public virtual ICollection<CrmProjectDefualtValue> CrmProjectDefualtValue { get; set; }

	public virtual ICollection<CrmProjectDefualtValue> CrmProjectDefualtValue1 { get; set; }

	public virtual ICollection<CrmProjectDefualtValue> CrmProjectDefualtValue2 { get; set; }

	public virtual ICollection<CrmProjectFieldTitle> CrmProjectFieldTitle { get; set; }

	public virtual ICollection<CrmProjectFieldTitle> CrmProjectFieldTitle1 { get; set; }

	public virtual ICollection<CrmProjectFieldTitle> CrmProjectFieldTitle2 { get; set; }

	public virtual ICollection<CrmProjectGrade> CrmProjectGrade { get; set; }

	public virtual ICollection<CrmProjectGrade> CrmProjectGrade1 { get; set; }

	public virtual ICollection<CrmProjectGrade> CrmProjectGrade2 { get; set; }

	public virtual ICollection<CrmProjectGroups> CrmProjectGroups { get; set; }

	public virtual ICollection<CrmProjectGroups> CrmProjectGroups1 { get; set; }

	public virtual ICollection<CrmProjectGroups> CrmProjectGroups2 { get; set; }

	public virtual ICollection<CrmProjectGroupsMulti> CrmProjectGroupsMulti { get; set; }

	public virtual ICollection<CrmProjectGroupsMulti> CrmProjectGroupsMulti1 { get; set; }

	public virtual ICollection<CrmProjectGroupsMulti> CrmProjectGroupsMulti2 { get; set; }

	public virtual ICollection<CrmProjectGroupsMultiI> CrmProjectGroupsMultiI { get; set; }

	public virtual ICollection<CrmProjectGroupsMultiI> CrmProjectGroupsMultiI1 { get; set; }

	public virtual ICollection<CrmProjectGroupsMultiI> CrmProjectGroupsMultiI2 { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations1 { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations2 { get; set; }

	public virtual ICollection<CrmProjectMultiGroups> CrmProjectMultiGroups { get; set; }

	public virtual ICollection<CrmProjectMultiGroups> CrmProjectMultiGroups1 { get; set; }

	public virtual ICollection<CrmProjectMultiGroups> CrmProjectMultiGroups2 { get; set; }

	public virtual ICollection<CrmProjectMultiIGroups> CrmProjectMultiIGroups { get; set; }

	public virtual ICollection<CrmProjectMultiIGroups> CrmProjectMultiIGroups1 { get; set; }

	public virtual ICollection<CrmProjectMultiIGroups> CrmProjectMultiIGroups2 { get; set; }

	public virtual ICollection<CrmProjectPriority> CrmProjectPriority { get; set; }

	public virtual ICollection<CrmProjectPriority> CrmProjectPriority1 { get; set; }

	public virtual ICollection<CrmProjectPriority> CrmProjectPriority2 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects1 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects2 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects3 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects4 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects5 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects6 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects7 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects8 { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects9 { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser1 { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser2 { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser3 { get; set; }

	public virtual ICollection<CrmProjectTitleGroups> CrmProjectTitleGroups { get; set; }

	public virtual ICollection<CrmProjectTitleGroups> CrmProjectTitleGroups1 { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles1 { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles2 { get; set; }

	public virtual ICollection<CrmShowTableFieldInFO> CrmShowTableFieldInFO { get; set; }

	public virtual ICollection<CrmShowTableFieldInFO> CrmShowTableFieldInFO1 { get; set; }

	public virtual ICollection<CrmSurvey> CrmSurvey { get; set; }

	public virtual ICollection<CrmSurvey> CrmSurvey1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails> CrmSurveyAnswerCategoryDetails { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails> CrmSurveyAnswerCategoryDetails1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues1 { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue1 { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue2 { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory1 { get; set; }

	public virtual ICollection<CrmSurveyQuestions> CrmSurveyQuestions { get; set; }

	public virtual ICollection<CrmSurveyQuestions> CrmSurveyQuestions1 { get; set; }

	public virtual ICollection<CrmSurveySendSetting> CrmSurveySendSetting { get; set; }

	public virtual ICollection<CrmSurveySendSetting> CrmSurveySendSetting1 { get; set; }

	public virtual ICollection<CrmsysCIDeviceType> CrmsysCIDeviceType { get; set; }

	public virtual ICollection<CrmsysCIPopUpSetting> CrmsysCIPopUpSetting { get; set; }

	public virtual ICollection<CrmsysCIPopUpSetting> CrmsysCIPopUpSetting1 { get; set; }

	public virtual ICollection<CrmsysCIPopUpSetting> CrmsysCIPopUpSetting2 { get; set; }

	public virtual ICollection<CrmsysCISetting> CrmsysCISetting { get; set; }

	public virtual ICollection<CrmsysDBObjects> CrmsysDBObjects { get; set; }

	public virtual ICollection<CrmsysDBTempInfo> CrmsysDBTempInfo { get; set; }

	public virtual ICollection<CrmsysDBTempInfo> CrmsysDBTempInfo1 { get; set; }

	public virtual ICollection<CrmsysDBTempInfoType> CrmsysDBTempInfoType { get; set; }

	public virtual ICollection<CrmsysFormActions> CrmsysFormActions { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties> CrmsysFormObjectProperties { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties> CrmsysFormObjectProperties1 { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties> CrmsysFormObjectProperties2 { get; set; }

	public virtual ICollection<CrmsysForms> CrmsysForms { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual ICollection<CrmsysRolls> CrmsysRolls { get; set; }

	public virtual ICollection<CrmsysRolls> CrmsysRolls1 { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting1 { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting2 { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting3 { get; set; }

	public virtual ICollection<CrmSystemParts> CrmSystemParts { get; set; }

	public virtual ICollection<CrmSystemParts> CrmSystemParts1 { get; set; }

	public virtual ICollection<CrmTelegBotChatMessage> CrmTelegBotChatMessage { get; set; }

	public virtual ICollection<CrmTelegBotContacts> CrmTelegBotContacts { get; set; }

	public virtual ICollection<CrmTelegBotContacts> CrmTelegBotContacts1 { get; set; }

	public virtual ICollection<CrmTelegBotSetting> CrmTelegBotSetting { get; set; }

	public virtual ICollection<CrmTelegBotSetting> CrmTelegBotSetting1 { get; set; }

	public virtual ICollection<CrmTelegChatMessage> CrmTelegChatMessage { get; set; }

	public virtual ICollection<CrmTelegContacts> CrmTelegContacts { get; set; }

	public virtual ICollection<CrmTelegContacts> CrmTelegContacts1 { get; set; }

	public virtual ICollection<CrmTelegSetting> CrmTelegSetting { get; set; }

	public virtual ICollection<CrmTelegSetting> CrmTelegSetting1 { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails1 { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails2 { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance1 { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance2 { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance3 { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance4 { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance5 { get; set; }

	public virtual ICollection<CrmTimeAttendanceBase> CrmTimeAttendanceBase { get; set; }

	public virtual ICollection<CrmTimeAttendanceBase> CrmTimeAttendanceBase1 { get; set; }

	public virtual ICollection<CrmTimeAttendanceBase> CrmTimeAttendanceBase2 { get; set; }

	public virtual ICollection<CrmTimeAttendanceLog> CrmTimeAttendanceLog { get; set; }

	public virtual ICollection<CrmTimeAttendanceLog> CrmTimeAttendanceLog1 { get; set; }

	public virtual ICollection<CrmTimeAttendanceLog> CrmTimeAttendanceLog2 { get; set; }

	public virtual ICollection<CrmTimeAttendanceLog> CrmTimeAttendanceLog3 { get; set; }

	public virtual ICollection<CRMtmpManageTellNumber> CRMtmpManageTellNumber { get; set; }

	public virtual ICollection<CRMtmpManageTellNumber> CRMtmpManageTellNumber1 { get; set; }

	public virtual ICollection<CrmUserNotes> CrmUserNotes { get; set; }

	public virtual ICollection<CrmUserNotes> CrmUserNotes1 { get; set; }

	public virtual ICollection<CrmUserReportFilter> CrmUserReportFilter { get; set; }

	public virtual ICollection<CrmUserReportFilter> CrmUserReportFilter1 { get; set; }

	public virtual ICollection<CrmUserTaskGroups> CrmUserTaskGroups { get; set; }

	public virtual ICollection<CrmUserTaskGroups> CrmUserTaskGroups1 { get; set; }

	public virtual ICollection<CrmUserTaskGroups> CrmUserTaskGroups2 { get; set; }

	public virtual ICollection<CrmUserTaskPriorities> CrmUserTaskPriorities { get; set; }

	public virtual ICollection<CrmUserTaskPriorities> CrmUserTaskPriorities1 { get; set; }

	public virtual ICollection<CrmUserTaskPriorities> CrmUserTaskPriorities2 { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks1 { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks2 { get; set; }

	public virtual ICollection<CrmVersions> CrmVersions { get; set; }

	public virtual ICollection<CrmVersionUpgrade> CrmVersionUpgrade { get; set; }

	public virtual ICollection<CrmVersionUpgradeDetails> CrmVersionUpgradeDetails { get; set; }

	public virtual ICollection<CrmWebSetting> CrmWebSetting { get; set; }

	public virtual ICollection<CrmWebSetting> CrmWebSetting1 { get; set; }

	public virtual ICollection<Education> Education { get; set; }

	public virtual ICollection<Education> Education1 { get; set; }

	public virtual ICollection<Education> Education2 { get; set; }

	public virtual ICollection<EmailDefaultBodyText> EmailDefaultBodyText { get; set; }

	public virtual ICollection<EmailDefaultBodyText> EmailDefaultBodyText1 { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive1 { get; set; }

	public virtual ICollection<EmailReceiveAttachments> EmailReceiveAttachments { get; set; }

	public virtual ICollection<EmailReceiveAttachments> EmailReceiveAttachments1 { get; set; }

	public virtual ICollection<EmailReceiveFolders> EmailReceiveFolders { get; set; }

	public virtual ICollection<EmailReceiveFolders> EmailReceiveFolders1 { get; set; }

	public virtual ICollection<EmailSendAttachment> EmailSendAttachment { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader1 { get; set; }

	public virtual ICollection<EmailSetting> EmailSetting { get; set; }

	public virtual ICollection<EmailSetting> EmailSetting1 { get; set; }

	public virtual ICollection<EmailUserDefaultSetting> EmailUserDefaultSetting { get; set; }

	public virtual ICollection<EmailUserDefaultSetting> EmailUserDefaultSetting1 { get; set; }

	public virtual ICollection<EmailUserDefaultSetting> EmailUserDefaultSetting2 { get; set; }

	public virtual ICollection<EmailUsersInfo> EmailUsersInfo { get; set; }

	public virtual ICollection<EmailUsersInfo> EmailUsersInfo1 { get; set; }

	public virtual ICollection<EmailUsersInfo> EmailUsersInfo2 { get; set; }

	public virtual ICollection<EmailUsersInfo> EmailUsersInfo3 { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank1 { get; set; }

	public virtual ICollection<Languages> Languages { get; set; }

	public virtual ICollection<Languages> Languages1 { get; set; }

	public virtual ICollection<Languages> Languages2 { get; set; }

	public virtual Languages Languages3 { get; set; }

	public virtual ICollection<PayRollItems> PayRollItems { get; set; }

	public virtual ICollection<PayRollItems> PayRollItems1 { get; set; }

	public virtual ICollection<PayRollItemTypes> PayRollItemTypes { get; set; }

	public virtual ICollection<PayRollItemTypes> PayRollItemTypes1 { get; set; }

	public virtual ICollection<PayRollList> PayRollList { get; set; }

	public virtual ICollection<PayRollList> PayRollList1 { get; set; }

	public virtual ICollection<PayRollListGroups> PayRollListGroups { get; set; }

	public virtual ICollection<PayRollListGroups> PayRollListGroups1 { get; set; }

	public virtual ICollection<PayRollListItems> PayRollListItems { get; set; }

	public virtual ICollection<PayRollListItems> PayRollListItems1 { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle1 { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle2 { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle3 { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues1 { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues2 { get; set; }

	public virtual ICollection<PayRollUserDefaultItems> PayRollUserDefaultItems { get; set; }

	public virtual ICollection<PayRollUserDefaultItems> PayRollUserDefaultItems1 { get; set; }

	public virtual ICollection<PayRollUserDefaultItems> PayRollUserDefaultItems2 { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments1 { get; set; }

	public virtual ICollection<PayRollUserPaymentTypes> PayRollUserPaymentTypes { get; set; }

	public virtual ICollection<PayRollUserPaymentTypes> PayRollUserPaymentTypes1 { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat1 { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat2 { get; set; }

	public virtual ICollection<PrintFormatType> PrintFormatType { get; set; }

	public virtual ICollection<PrintFormatType> PrintFormatType1 { get; set; }

	public virtual ICollection<PrintFormatType> PrintFormatType2 { get; set; }

	public virtual ICollection<Projects> Projects { get; set; }

	public virtual ICollection<Projects> Projects1 { get; set; }

	public virtual ICollection<Province> Province { get; set; }

	public virtual ICollection<Province> Province1 { get; set; }

	public virtual ICollection<Province> Province2 { get; set; }

	public virtual ICollection<ScoreRules> ScoreRules { get; set; }

	public virtual ICollection<ScoreRules> ScoreRules1 { get; set; }

	public virtual ICollection<ScoreRulesSetting> ScoreRulesSetting { get; set; }

	public virtual ICollection<ScoreRulesSetting> ScoreRulesSetting1 { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual ICollection<Scores> Scores1 { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings1 { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings2 { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings3 { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings4 { get; set; }

	public virtual ICollection<SecLetterNumberCounter> SecLetterNumberCounter { get; set; }

	public virtual ICollection<SecLetterNumberCounter> SecLetterNumberCounter1 { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<SecLetters> SecLetters1 { get; set; }

	public virtual ICollection<SecLetters> SecLetters2 { get; set; }

	public virtual ICollection<SecLetters> SecLetters3 { get; set; }

	public virtual ICollection<SecLetters> SecLetters4 { get; set; }

	public virtual ICollection<SecLetterType> SecLetterType { get; set; }

	public virtual ICollection<SecLetterType> SecLetterType1 { get; set; }

	public virtual ICollection<SecLetterType> SecLetterType2 { get; set; }

	public virtual ICollection<Sex> Sex { get; set; }

	public virtual ICollection<Sex> Sex1 { get; set; }

	public virtual ICollection<SmsDefaultBodyText> SmsDefaultBodyText { get; set; }

	public virtual ICollection<SmsDefaultBodyText> SmsDefaultBodyText1 { get; set; }

	public virtual ICollection<SmsDefaultBodyTextGroups> SmsDefaultBodyTextGroups { get; set; }

	public virtual ICollection<SmsDefaultBodyTextGroups> SmsDefaultBodyTextGroups1 { get; set; }

	public virtual ICollection<SmsDeliveryStatus> SmsDeliveryStatus { get; set; }

	public virtual ICollection<SmsGSMModemDelivery> SmsGSMModemDelivery { get; set; }

	public virtual ICollection<SmsGSMModemSetting> SmsGSMModemSetting { get; set; }

	public virtual ICollection<SmsGSMModemSetting> SmsGSMModemSetting1 { get; set; }

	public virtual ICollection<SmsGSMReceives> SmsGSMReceives { get; set; }

	public virtual ICollection<SmsGSMSendingTank> SmsGSMSendingTank { get; set; }

	public virtual ICollection<SmsProviders> SmsProviders { get; set; }

	public virtual ICollection<SmsProviders> SmsProviders1 { get; set; }

	public virtual ICollection<SmsReceive> SmsReceive { get; set; }

	public virtual ICollection<SmsReceive> SmsReceive1 { get; set; }

	public virtual ICollection<SmsReceiveFromWSDL> SmsReceiveFromWSDL { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail1 { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail2 { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader1 { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader2 { get; set; }

	public virtual ICollection<SmsSendType> SmsSendType { get; set; }

	public virtual ICollection<SmsSetting> SmsSetting { get; set; }

	public virtual ICollection<SmsSetting> SmsSetting1 { get; set; }

	public virtual ICollection<SmsTempMobileNumbers> SmsTempMobileNumbers { get; set; }

	public virtual ICollection<SmsTempMobileNumbers> SmsTempMobileNumbers1 { get; set; }

	public virtual ICollection<SmsUserSendCredit> SmsUserSendCredit { get; set; }

	public virtual ICollection<SmsUserSendCredit> SmsUserSendCredit1 { get; set; }

	public virtual ICollection<SmsUserSendCredit> SmsUserSendCredit2 { get; set; }

	public virtual ICollection<TspSetting> TspSetting { get; set; }

	public virtual ICollection<TspSetting> TspSetting1 { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments1 { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments2 { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments3 { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers1 { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers2 { get; set; }

	public virtual ICollection<UserGroups> UserGroups { get; set; }

	public virtual ICollection<UserGroups> UserGroups1 { get; set; }

	public virtual UserGroups UserGroups2 { get; set; }

	public virtual ICollection<UserLanguages> UserLanguages { get; set; }

	public virtual ICollection<UserLanguages> UserLanguages1 { get; set; }

	public virtual ICollection<UserLanguages> UserLanguages2 { get; set; }

	public virtual ICollection<UserLoginAllowedTimes> UserLoginAllowedTimes { get; set; }

	public virtual ICollection<UserLoginAllowedTimes> UserLoginAllowedTimes1 { get; set; }

	public virtual ICollection<UserLoginAllowedTimes> UserLoginAllowedTimes2 { get; set; }

	public virtual ICollection<UserLoginAllowedTimes> UserLoginAllowedTimes3 { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag1 { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag2 { get; set; }

	public virtual ICollection<UserPictures> UserPictures { get; set; }

	public virtual ICollection<UserPictures> UserPictures1 { get; set; }

	public virtual ICollection<UserPictures> UserPictures2 { get; set; }

	public virtual ICollection<UserPositions> UserPositions { get; set; }

	public virtual ICollection<UserPositions> UserPositions1 { get; set; }

	public virtual UserPositions UserPositions2 { get; set; }

	public virtual ICollection<Users_Lang> Users_Lang { get; set; }

	public virtual ICollection<Users> Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual ICollection<Users> Users11 { get; set; }

	public virtual Users Users3 { get; set; }

	public virtual ICollection<Users> Users12 { get; set; }

	public virtual Users Users4 { get; set; }

	public virtual ICollection<Users> Users13 { get; set; }

	public virtual Users Users5 { get; set; }

	public virtual ICollection<UserSignature> UserSignature { get; set; }

	public virtual ICollection<UserSignature> UserSignature1 { get; set; }

	public virtual ICollection<UserSignature> UserSignature2 { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission1 { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission2 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder1 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder2 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder3 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder4 { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder5 { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting2 { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems1 { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials1 { get; set; }

	public virtual ICollection<WSBuyOrderOpr> WSBuyOrderOpr { get; set; }

	public virtual ICollection<WSBuyOrderOpr> WSBuyOrderOpr1 { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments1 { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments2 { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments3 { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments4 { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes> WSBuyOrderPaymentTypes { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes> WSBuyOrderPaymentTypes1 { get; set; }

	public virtual ICollection<WSBuyOrderStatus> WSBuyOrderStatus { get; set; }

	public virtual ICollection<WSBuyOrderStatus> WSBuyOrderStatus1 { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups> WSCostSheetDyFieldGroups { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups> WSCostSheetDyFieldGroups1 { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues1 { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems1 { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts1 { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets1 { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets2 { get; set; }

	public virtual ICollection<WSCreditDuration> WSCreditDuration { get; set; }

	public virtual ICollection<WSCreditDuration> WSCreditDuration1 { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate1 { get; set; }

	public virtual ICollection<WSCurrencyUnits> WSCurrencyUnits { get; set; }

	public virtual ICollection<WSCurrencyUnits> WSCurrencyUnits1 { get; set; }

	public virtual ICollection<WSDeliverySchedule> WSDeliverySchedule { get; set; }

	public virtual ICollection<WSDeliverySchedule> WSDeliverySchedule1 { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept> WSDeliveryScheduleExcept { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept> WSDeliveryScheduleExcept1 { get; set; }

	public virtual ICollection<WSDeliveryTerms> WSDeliveryTerms { get; set; }

	public virtual ICollection<WSDeliveryTerms> WSDeliveryTerms1 { get; set; }

	public virtual ICollection<WSDeliveryTime> WSDeliveryTime { get; set; }

	public virtual ICollection<WSDeliveryTime> WSDeliveryTime1 { get; set; }

	public virtual ICollection<WSDiscountCode> WSDiscountCode { get; set; }

	public virtual ICollection<WSDiscountCode> WSDiscountCode1 { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory1 { get; set; }

	public virtual ICollection<WSDiscountStrategy> WSDiscountStrategy { get; set; }

	public virtual ICollection<WSDiscountStrategy> WSDiscountStrategy1 { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSDoc> WSDoc1 { get; set; }

	public virtual ICollection<WSDoc> WSDoc2 { get; set; }

	public virtual ICollection<WSDoc> WSDoc3 { get; set; }

	public virtual ICollection<WSDoc> WSDoc4 { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems1 { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials1 { get; set; }

	public virtual ICollection<WSDocOpr> WSDocOpr { get; set; }

	public virtual ICollection<WSDocOpr> WSDocOpr1 { get; set; }

	public virtual ICollection<WSFinancialPeriod> WSFinancialPeriod { get; set; }

	public virtual ICollection<WSFinancialPeriod> WSFinancialPeriod1 { get; set; }

	public virtual ICollection<WSGuaranty> WSGuaranty { get; set; }

	public virtual ICollection<WSGuaranty> WSGuaranty1 { get; set; }

	public virtual ICollection<WSLinkedProducts> WSLinkedProducts { get; set; }

	public virtual ICollection<WSLinkedProducts> WSLinkedProducts1 { get; set; }

	public virtual ICollection<WSLogo> WSLogo { get; set; }

	public virtual ICollection<WSLogo> WSLogo1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrder> WSOrder1 { get; set; }

	public virtual ICollection<WSOrder> WSOrder2 { get; set; }

	public virtual ICollection<WSOrder> WSOrder3 { get; set; }

	public virtual ICollection<WSOrder> WSOrder4 { get; set; }

	public virtual ICollection<WSOrder> WSOrder5 { get; set; }

	public virtual ICollection<WSOrder> WSOrder6 { get; set; }

	public virtual ICollection<WSOrder> WSOrder7 { get; set; }

	public virtual ICollection<WSOrderCommissionPayTypes> WSOrderCommissionPayTypes { get; set; }

	public virtual ICollection<WSOrderCommissionPayTypes> WSOrderCommissionPayTypes1 { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions1 { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions2 { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions3 { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions4 { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions5 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting2 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting3 { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting4 { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts1 { get; set; }

	public virtual ICollection<WSOrderGroups> WSOrderGroups { get; set; }

	public virtual ICollection<WSOrderGroups> WSOrderGroups1 { get; set; }

	public virtual ICollection<WSOrderImportFromExcelFields> WSOrderImportFromExcelFields { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems1 { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems2 { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems3 { get; set; }

	public virtual ICollection<WSOrderItemSerials> WSOrderItemSerials { get; set; }

	public virtual ICollection<WSOrderItemSerials> WSOrderItemSerials1 { get; set; }

	public virtual ICollection<WSOrderOpr> WSOrderOpr { get; set; }

	public virtual ICollection<WSOrderOpr> WSOrderOpr1 { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsI> WSOrderPaymentGroupsI { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsI> WSOrderPaymentGroupsI1 { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII> WSOrderPaymentGroupsII { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII> WSOrderPaymentGroupsII1 { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments1 { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments2 { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments3 { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments4 { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments5 { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes1 { get; set; }

	public virtual ICollection<WSOrderStatus> WSOrderStatus { get; set; }

	public virtual ICollection<WSOrderStatus> WSOrderStatus1 { get; set; }

	public virtual ICollection<WSPayCondition> WSPayCondition { get; set; }

	public virtual ICollection<WSPayCondition> WSPayCondition1 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder1 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder2 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder3 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder4 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder5 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder6 { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder7 { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions1 { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions2 { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions3 { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions4 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting1 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting2 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting3 { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting4 { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts1 { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems1 { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems2 { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification1 { get; set; }

	public virtual ICollection<WSPreOrderOpr> WSPreOrderOpr { get; set; }

	public virtual ICollection<WSPreOrderOpr> WSPreOrderOpr1 { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments1 { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments2 { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments3 { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments4 { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons1 { get; set; }

	public virtual ICollection<WSPreOrderStatus> WSPreOrderStatus { get; set; }

	public virtual ICollection<WSPreOrderStatus> WSPreOrderStatus1 { get; set; }

	public virtual ICollection<WSPreOrderTypes> WSPreOrderTypes { get; set; }

	public virtual ICollection<WSPreOrderTypes> WSPreOrderTypes1 { get; set; }

	public virtual ICollection<WSProductColor> WSProductColor { get; set; }

	public virtual ICollection<WSProductColor> WSProductColor1 { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost1 { get; set; }

	public virtual ICollection<WSProductCostGroup> WSProductCostGroup { get; set; }

	public virtual ICollection<WSProductCostGroup> WSProductCostGroup1 { get; set; }

	public virtual ICollection<WSProductFirstGroup> WSProductFirstGroup { get; set; }

	public virtual ICollection<WSProductFirstGroup> WSProductFirstGroup1 { get; set; }

	public virtual ICollection<WSProductGallery> WSProductGallery { get; set; }

	public virtual ICollection<WSProductGallery> WSProductGallery1 { get; set; }

	public virtual ICollection<WSProductGroupPicture> WSProductGroupPicture { get; set; }

	public virtual ICollection<WSProductGroupPicture> WSProductGroupPicture1 { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel1 { get; set; }

	public virtual ICollection<WSProductImportFromExcelFields> WSProductImportFromExcelFields { get; set; }

	public virtual ICollection<WSProductPicture> WSProductPicture { get; set; }

	public virtual ICollection<WSProductPicture> WSProductPicture1 { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice1 { get; set; }

	public virtual ICollection<WSProductPriceGroup> WSProductPriceGroup { get; set; }

	public virtual ICollection<WSProductPriceGroup> WSProductPriceGroup1 { get; set; }

	public virtual ICollection<WSProductRelationLimit> WSProductRelationLimit { get; set; }

	public virtual ICollection<WSProductRelationLimit> WSProductRelationLimit1 { get; set; }

	public virtual ICollection<WSProductRelationType> WSProductRelationType { get; set; }

	public virtual ICollection<WSProductRelationType> WSProductRelationType1 { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProducts> WSProducts1 { get; set; }

	public virtual ICollection<WSProductSecondGroup> WSProductSecondGroup { get; set; }

	public virtual ICollection<WSProductSecondGroup> WSProductSecondGroup1 { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException1 { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes> WSProductShpStockManageTypes { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes> WSProductShpStockManageTypes1 { get; set; }

	public virtual ICollection<WSProductSpecification> WSProductSpecification { get; set; }

	public virtual ICollection<WSProductSpecification> WSProductSpecification1 { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups1 { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields1 { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes> WSProductSpecificationFieldTypes { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes> WSProductSpecificationFieldTypes1 { get; set; }

	public virtual ICollection<WSProductsRate> WSProductsRate { get; set; }

	public virtual ICollection<WSProductsRate> WSProductsRate1 { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount1 { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount2 { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount3 { get; set; }

	public virtual ICollection<WSProductUnits> WSProductUnits { get; set; }

	public virtual ICollection<WSProductUnits> WSProductUnits1 { get; set; }

	public virtual ICollection<WSRegisterBarCode> WSRegisterBarCode { get; set; }

	public virtual ICollection<WSSaleAreas> WSSaleAreas { get; set; }

	public virtual ICollection<WSSaleAreas> WSSaleAreas1 { get; set; }

	public virtual ICollection<WSSaleCenters> WSSaleCenters { get; set; }

	public virtual ICollection<WSSaleCenters> WSSaleCenters1 { get; set; }

	public virtual ICollection<WSSaleCenters> WSSaleCenters2 { get; set; }

	public virtual ICollection<WSSettlementType> WSSettlementType { get; set; }

	public virtual ICollection<WSSettlementType> WSSettlementType1 { get; set; }

	public virtual ICollection<WSSignature> WSSignature { get; set; }

	public virtual ICollection<WSSignature> WSSignature1 { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply1 { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply2 { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply3 { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply4 { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems1 { get; set; }

	public virtual ICollection<WSTmpEnterBarcodeOperation> WSTmpEnterBarcodeOperation { get; set; }

	public virtual ICollection<WSTmpEnterDocPrdWithBarcode> WSTmpEnterDocPrdWithBarcode { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy1 { get; set; }

	public virtual ICollection<WSUserFavproductItems> WSUserFavproductItems { get; set; }

	public virtual ICollection<WSUserFavproductItems> WSUserFavproductItems1 { get; set; }

	public virtual ICollection<WSUserFavproducts> WSUserFavproducts { get; set; }

	public virtual ICollection<WSUserFavproducts> WSUserFavproducts1 { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails1 { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails2 { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests1 { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests2 { get; set; }

	public virtual ICollection<WSVerificationWorkFlows> WSVerificationWorkFlows { get; set; }

	public virtual ICollection<WSVerificationWorkFlows> WSVerificationWorkFlows1 { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps1 { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps2 { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps3 { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse1 { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse2 { get; set; }

	public virtual ICollection<WSWareHouseUserPermissions> WSWareHouseUserPermissions { get; set; }

	public virtual ICollection<WSWareHouseUserPermissions> WSWareHouseUserPermissions1 { get; set; }

	public virtual ICollection<WSWareHouseUserPermissions> WSWareHouseUserPermissions2 { get; set; }

	public Users()
	{
		Centers = (ICollection<Centers>)new HashSet<Centers>();
		Centers1 = (ICollection<Centers>)new HashSet<Centers>();
		City = (ICollection<City>)new HashSet<City>();
		City1 = (ICollection<City>)new HashSet<City>();
		City2 = (ICollection<City>)new HashSet<City>();
		City3 = (ICollection<City>)new HashSet<City>();
		Country = (ICollection<Country>)new HashSet<Country>();
		Country1 = (ICollection<Country>)new HashSet<Country>();
		Country2 = (ICollection<Country>)new HashSet<Country>();
		CrmAddressing = (ICollection<CrmAddressing>)new HashSet<CrmAddressing>();
		CrmAddressing1 = (ICollection<CrmAddressing>)new HashSet<CrmAddressing>();
		CrmAddressingType = (ICollection<CrmAddressingType>)new HashSet<CrmAddressingType>();
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		CrmBankingAccounts1 = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		CrmBankingAccounts2 = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		CrmBankingAccountType = (ICollection<CrmBankingAccountType>)new HashSet<CrmBankingAccountType>();
		CrmBankingAccountType1 = (ICollection<CrmBankingAccountType>)new HashSet<CrmBankingAccountType>();
		CrmBankingBanks = (ICollection<CrmBankingBanks>)new HashSet<CrmBankingBanks>();
		CrmBankingBanks1 = (ICollection<CrmBankingBanks>)new HashSet<CrmBankingBanks>();
		CrmBankingBranches = (ICollection<CrmBankingBranches>)new HashSet<CrmBankingBranches>();
		CrmBankingBranches1 = (ICollection<CrmBankingBranches>)new HashSet<CrmBankingBranches>();
		CrmCallBlackList = (ICollection<CrmCallBlackList>)new HashSet<CrmCallBlackList>();
		CrmCallBlackList1 = (ICollection<CrmCallBlackList>)new HashSet<CrmCallBlackList>();
		CrmCallBlackList2 = (ICollection<CrmCallBlackList>)new HashSet<CrmCallBlackList>();
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallHistory1 = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallHistory2 = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallHistory3 = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallHistory4 = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallType = (ICollection<CrmCallType>)new HashSet<CrmCallType>();
		CrmCallType1 = (ICollection<CrmCallType>)new HashSet<CrmCallType>();
		CrmCallType2 = (ICollection<CrmCallType>)new HashSet<CrmCallType>();
		CrmCashes = (ICollection<CrmCashes>)new HashSet<CrmCashes>();
		CrmCashes1 = (ICollection<CrmCashes>)new HashSet<CrmCashes>();
		CrmCmsComments = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsComments1 = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsComments2 = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsFiles = (ICollection<CrmCmsFiles>)new HashSet<CrmCmsFiles>();
		CrmCmsFiles1 = (ICollection<CrmCmsFiles>)new HashSet<CrmCmsFiles>();
		CrmCmsFooter = (ICollection<CrmCmsFooter>)new HashSet<CrmCmsFooter>();
		CrmCmsFooter1 = (ICollection<CrmCmsFooter>)new HashSet<CrmCmsFooter>();
		CrmCmsGallery = (ICollection<CrmCmsGallery>)new HashSet<CrmCmsGallery>();
		CrmCmsGallery1 = (ICollection<CrmCmsGallery>)new HashSet<CrmCmsGallery>();
		CrmCmsGalleryItems = (ICollection<CrmCmsGalleryItems>)new HashSet<CrmCmsGalleryItems>();
		CrmCmsGalleryItems1 = (ICollection<CrmCmsGalleryItems>)new HashSet<CrmCmsGalleryItems>();
		CrmCmsHomePageSectionItems = (ICollection<CrmCmsHomePageSectionItems>)new HashSet<CrmCmsHomePageSectionItems>();
		CrmCmsHomePageSectionItems1 = (ICollection<CrmCmsHomePageSectionItems>)new HashSet<CrmCmsHomePageSectionItems>();
		CrmCmsHomePageSections = (ICollection<CrmCmsHomePageSections>)new HashSet<CrmCmsHomePageSections>();
		CrmCmsHomePageSections1 = (ICollection<CrmCmsHomePageSections>)new HashSet<CrmCmsHomePageSections>();
		CrmCmsLikes = (ICollection<CrmCmsLikes>)new HashSet<CrmCmsLikes>();
		CrmCmsLikes1 = (ICollection<CrmCmsLikes>)new HashSet<CrmCmsLikes>();
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsMenus1 = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsNews = (ICollection<CrmCmsNews>)new HashSet<CrmCmsNews>();
		CrmCmsNews1 = (ICollection<CrmCmsNews>)new HashSet<CrmCmsNews>();
		CrmCmsNews2 = (ICollection<CrmCmsNews>)new HashSet<CrmCmsNews>();
		CrmCmsNewsGroups = (ICollection<CrmCmsNewsGroups>)new HashSet<CrmCmsNewsGroups>();
		CrmCmsNewsGroups1 = (ICollection<CrmCmsNewsGroups>)new HashSet<CrmCmsNewsGroups>();
		CrmCmsObjectTypes = (ICollection<CrmCmsObjectTypes>)new HashSet<CrmCmsObjectTypes>();
		CrmCmsObjectTypes1 = (ICollection<CrmCmsObjectTypes>)new HashSet<CrmCmsObjectTypes>();
		CrmCmsPages = (ICollection<CrmCmsPages>)new HashSet<CrmCmsPages>();
		CrmCmsPages1 = (ICollection<CrmCmsPages>)new HashSet<CrmCmsPages>();
		CrmCmsWidgetGroups = (ICollection<CrmCmsWidgetGroups>)new HashSet<CrmCmsWidgetGroups>();
		CrmCmsWidgetGroups1 = (ICollection<CrmCmsWidgetGroups>)new HashSet<CrmCmsWidgetGroups>();
		CrmCmsWidgets = (ICollection<CrmCmsWidgets>)new HashSet<CrmCmsWidgets>();
		CrmCmsWidgets1 = (ICollection<CrmCmsWidgets>)new HashSet<CrmCmsWidgets>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany1 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany2 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany3 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany4 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany5 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany6 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany7 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany8 = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompanyAddresses = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyAddresses1 = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyAddresses2 = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyAddressType = (ICollection<CrmCompanyAddressType>)new HashSet<CrmCompanyAddressType>();
		CrmCompanyAddressType1 = (ICollection<CrmCompanyAddressType>)new HashSet<CrmCompanyAddressType>();
		CrmCompanyCampaign = (ICollection<CrmCompanyCampaign>)new HashSet<CrmCompanyCampaign>();
		CrmCompanyCampaign1 = (ICollection<CrmCompanyCampaign>)new HashSet<CrmCompanyCampaign>();
		CrmCompanyForbiddenCity = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyForbiddenCity1 = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyForbiddenCity2 = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyForbiddenCompany = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyForbiddenCompany1 = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyForbiddenCompany2 = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyForbiddenDepartment = (ICollection<CrmCompanyForbiddenDepartment>)new HashSet<CrmCompanyForbiddenDepartment>();
		CrmCompanyForbiddenDepartment1 = (ICollection<CrmCompanyForbiddenDepartment>)new HashSet<CrmCompanyForbiddenDepartment>();
		CrmCompanyForbiddenDepartment2 = (ICollection<CrmCompanyForbiddenDepartment>)new HashSet<CrmCompanyForbiddenDepartment>();
		CrmCompanyForbiddenGroup = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyForbiddenGroup1 = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyForbiddenGroup2 = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyForbiddenGroupIV = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyForbiddenGroupIV1 = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyForbiddenGroupIV2 = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyForbiddenProvince = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyForbiddenProvince1 = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyForbiddenProvince2 = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyForbiddenSubGroup = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyForbiddenSubGroup1 = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyForbiddenSubGroup2 = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyGroups = (ICollection<CrmCompanyGroups>)new HashSet<CrmCompanyGroups>();
		CrmCompanyGroups1 = (ICollection<CrmCompanyGroups>)new HashSet<CrmCompanyGroups>();
		CrmCompanyGroups2 = (ICollection<CrmCompanyGroups>)new HashSet<CrmCompanyGroups>();
		CrmCompanyGroupsII = (ICollection<CrmCompanyGroupsII>)new HashSet<CrmCompanyGroupsII>();
		CrmCompanyGroupsII1 = (ICollection<CrmCompanyGroupsII>)new HashSet<CrmCompanyGroupsII>();
		CrmCompanyGroupsII2 = (ICollection<CrmCompanyGroupsII>)new HashSet<CrmCompanyGroupsII>();
		CrmCompanyGroupsIII = (ICollection<CrmCompanyGroupsIII>)new HashSet<CrmCompanyGroupsIII>();
		CrmCompanyGroupsIII1 = (ICollection<CrmCompanyGroupsIII>)new HashSet<CrmCompanyGroupsIII>();
		CrmCompanyGroupsIII2 = (ICollection<CrmCompanyGroupsIII>)new HashSet<CrmCompanyGroupsIII>();
		CrmCompanyGroupsIV = (ICollection<CrmCompanyGroupsIV>)new HashSet<CrmCompanyGroupsIV>();
		CrmCompanyGroupsIV1 = (ICollection<CrmCompanyGroupsIV>)new HashSet<CrmCompanyGroupsIV>();
		CrmCompanyGroupsIV2 = (ICollection<CrmCompanyGroupsIV>)new HashSet<CrmCompanyGroupsIV>();
		CrmCompanyGroupsMulti = (ICollection<CrmCompanyGroupsMulti>)new HashSet<CrmCompanyGroupsMulti>();
		CrmCompanyGroupsMulti1 = (ICollection<CrmCompanyGroupsMulti>)new HashSet<CrmCompanyGroupsMulti>();
		CrmCompanyGroupsMulti2 = (ICollection<CrmCompanyGroupsMulti>)new HashSet<CrmCompanyGroupsMulti>();
		CrmCompanyJustAccessCity = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyJustAccessCity1 = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyJustAccessCity2 = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyJustAccessCompany = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyJustAccessCompany1 = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyJustAccessCompany2 = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyJustAccessDepartment = (ICollection<CrmCompanyJustAccessDepartment>)new HashSet<CrmCompanyJustAccessDepartment>();
		CrmCompanyJustAccessDepartment1 = (ICollection<CrmCompanyJustAccessDepartment>)new HashSet<CrmCompanyJustAccessDepartment>();
		CrmCompanyJustAccessDepartment2 = (ICollection<CrmCompanyJustAccessDepartment>)new HashSet<CrmCompanyJustAccessDepartment>();
		CrmCompanyJustAccessGroup = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanyJustAccessGroup1 = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanyJustAccessGroup2 = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanyJustAccessGroupIV = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompanyJustAccessGroupIV1 = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompanyJustAccessGroupIV2 = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompanyJustAccessProvince = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyJustAccessProvince1 = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyJustAccessProvince2 = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyJustAccessSubGroup = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmCompanyJustAccessSubGroup1 = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmCompanyJustAccessSubGroup2 = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmCompanyLoGo = (ICollection<CrmCompanyLoGo>)new HashSet<CrmCompanyLoGo>();
		CrmCompanyLoGo1 = (ICollection<CrmCompanyLoGo>)new HashSet<CrmCompanyLoGo>();
		CrmCompanyMoneyBag = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		CrmCompanyMoneyBag1 = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		CrmCompanyMultiGroups = (ICollection<CrmCompanyMultiGroups>)new HashSet<CrmCompanyMultiGroups>();
		CrmCompanyMultiGroups1 = (ICollection<CrmCompanyMultiGroups>)new HashSet<CrmCompanyMultiGroups>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons1 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons2 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons3 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons4 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons5 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons6 = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyPersonsTemplate1 = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyPersonsTemplate2 = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyPersonsTemplate3 = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyPictureAlbums = (ICollection<CrmCompanyPictureAlbums>)new HashSet<CrmCompanyPictureAlbums>();
		CrmCompanyPictureAlbums1 = (ICollection<CrmCompanyPictureAlbums>)new HashSet<CrmCompanyPictureAlbums>();
		CrmCompanyPictures = (ICollection<CrmCompanyPictures>)new HashSet<CrmCompanyPictures>();
		CrmCompanyPictures1 = (ICollection<CrmCompanyPictures>)new HashSet<CrmCompanyPictures>();
		CrmCompanyPresentation = (ICollection<CrmCompanyPresentation>)new HashSet<CrmCompanyPresentation>();
		CrmCompanyPresentation1 = (ICollection<CrmCompanyPresentation>)new HashSet<CrmCompanyPresentation>();
		CrmCompanyPresentation2 = (ICollection<CrmCompanyPresentation>)new HashSet<CrmCompanyPresentation>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
		CrmCompanyQuickRegisterDefSetting1 = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
		CrmCompanySubGroups = (ICollection<CrmCompanySubGroups>)new HashSet<CrmCompanySubGroups>();
		CrmCompanySubGroups1 = (ICollection<CrmCompanySubGroups>)new HashSet<CrmCompanySubGroups>();
		CrmCompanySubGroups2 = (ICollection<CrmCompanySubGroups>)new HashSet<CrmCompanySubGroups>();
		CrmCompanyTitle = (ICollection<CrmCompanyTitle>)new HashSet<CrmCompanyTitle>();
		CrmCompanyTitle1 = (ICollection<CrmCompanyTitle>)new HashSet<CrmCompanyTitle>();
		CrmCompanyTitle2 = (ICollection<CrmCompanyTitle>)new HashSet<CrmCompanyTitle>();
		CrmCompanyType = (ICollection<CrmCompanyType>)new HashSet<CrmCompanyType>();
		CrmCompanyType1 = (ICollection<CrmCompanyType>)new HashSet<CrmCompanyType>();
		CrmCompanyType2 = (ICollection<CrmCompanyType>)new HashSet<CrmCompanyType>();
		CrmCompanyUserForbidden = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmCompanyUserForbidden1 = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmCompanyUserForbidden2 = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversation1 = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversation2 = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversation3 = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversation4 = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversationDefaultContext = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext1 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext2 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext3 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext4 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext5 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext6 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext7 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext8 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext9 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext10 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext11 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext12 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext13 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext14 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext15 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext16 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext17 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext18 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext19 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext20 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext21 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext22 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext23 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext24 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext25 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext26 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext27 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext28 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext29 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext30 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext31 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext32 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext33 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext34 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext35 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext36 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext37 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext38 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext39 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext40 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext41 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext42 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext43 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext44 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext45 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext46 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext47 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext48 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext49 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext50 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext51 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext52 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext53 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext54 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext55 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext56 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext57 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext58 = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationPriority = (ICollection<CrmConversationPriority>)new HashSet<CrmConversationPriority>();
		CrmConversationPriority1 = (ICollection<CrmConversationPriority>)new HashSet<CrmConversationPriority>();
		CrmConversationPriority2 = (ICollection<CrmConversationPriority>)new HashSet<CrmConversationPriority>();
		CrmConversationReferUsers = (ICollection<CrmConversationReferUsers>)new HashSet<CrmConversationReferUsers>();
		CrmConversationReferUsers1 = (ICollection<CrmConversationReferUsers>)new HashSet<CrmConversationReferUsers>();
		CrmConversationReferUsers2 = (ICollection<CrmConversationReferUsers>)new HashSet<CrmConversationReferUsers>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatus1 = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatus2 = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatusGroups = (ICollection<CrmConversationStatusGroups>)new HashSet<CrmConversationStatusGroups>();
		CrmConversationStatusGroups1 = (ICollection<CrmConversationStatusGroups>)new HashSet<CrmConversationStatusGroups>();
		CrmConversationStatusGroups2 = (ICollection<CrmConversationStatusGroups>)new HashSet<CrmConversationStatusGroups>();
		CrmConversationStatusGroups3 = (ICollection<CrmConversationStatusGroups>)new HashSet<CrmConversationStatusGroups>();
		CrmConversationStatusResult = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResult1 = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResult2 = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResultEventPolicy = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		CrmConversationStatusResultEventPolicy1 = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		CrmConversationStatusSalesFunnelSteps = (ICollection<CrmConversationStatusSalesFunnelSteps>)new HashSet<CrmConversationStatusSalesFunnelSteps>();
		CrmConversationStatusSalesFunnelSteps1 = (ICollection<CrmConversationStatusSalesFunnelSteps>)new HashSet<CrmConversationStatusSalesFunnelSteps>();
		CrmConversationTopics = (ICollection<CrmConversationTopics>)new HashSet<CrmConversationTopics>();
		CrmConversationTopics1 = (ICollection<CrmConversationTopics>)new HashSet<CrmConversationTopics>();
		CrmConversationTopics2 = (ICollection<CrmConversationTopics>)new HashSet<CrmConversationTopics>();
		CrmDyFormFieldMasterValueDetails = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValueDetails1 = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValueDetails2 = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValueDetails3 = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldMasterValues1 = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldMasterValues2 = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldMasterValues3 = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
		CrmDyFormFields1 = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
		CrmDyFormFieldTypes = (ICollection<CrmDyFormFieldTypes>)new HashSet<CrmDyFormFieldTypes>();
		CrmDyFormFieldTypes1 = (ICollection<CrmDyFormFieldTypes>)new HashSet<CrmDyFormFieldTypes>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
		CrmDyFormRegularExpressions = (ICollection<CrmDyFormRegularExpressions>)new HashSet<CrmDyFormRegularExpressions>();
		CrmDyFormRegularExpressions1 = (ICollection<CrmDyFormRegularExpressions>)new HashSet<CrmDyFormRegularExpressions>();
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyForms1 = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyFormUserAccess = (ICollection<CrmDyFormUserAccess>)new HashSet<CrmDyFormUserAccess>();
		CrmDyFormUserAccess1 = (ICollection<CrmDyFormUserAccess>)new HashSet<CrmDyFormUserAccess>();
		CrmDyFormUserAccess2 = (ICollection<CrmDyFormUserAccess>)new HashSet<CrmDyFormUserAccess>();
		CrmDyFormWorkflows = (ICollection<CrmDyFormWorkflows>)new HashSet<CrmDyFormWorkflows>();
		CrmDyFormWorkflows1 = (ICollection<CrmDyFormWorkflows>)new HashSet<CrmDyFormWorkflows>();
		CrmDyFormWorkflowSteps = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
		CrmDyFormWorkflowSteps1 = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
		CrmFileDirectoryType = (ICollection<CrmFileDirectoryType>)new HashSet<CrmFileDirectoryType>();
		CrmFileDirectoryType1 = (ICollection<CrmFileDirectoryType>)new HashSet<CrmFileDirectoryType>();
		CrmFileDirectoryType2 = (ICollection<CrmFileDirectoryType>)new HashSet<CrmFileDirectoryType>();
		CrmFileDirectoryTypeOpr = (ICollection<CrmFileDirectoryTypeOpr>)new HashSet<CrmFileDirectoryTypeOpr>();
		CrmFileDirectoryTypeOpr1 = (ICollection<CrmFileDirectoryTypeOpr>)new HashSet<CrmFileDirectoryTypeOpr>();
		CrmFileDirectoryTypeOpr2 = (ICollection<CrmFileDirectoryTypeOpr>)new HashSet<CrmFileDirectoryTypeOpr>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmFilesDirectory1 = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmFilesDirectory2 = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmFilesDirectoryTemplate = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
		CrmFilesDirectoryTemplate1 = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
		CrmFilesDirectoryTemplate2 = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
		CrmFilesDirectoryTemplateType = (ICollection<CrmFilesDirectoryTemplateType>)new HashSet<CrmFilesDirectoryTemplateType>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting2 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting3 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting4 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting5 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting6 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting7 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting8 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting9 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting10 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting11 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting12 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister1 = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister2 = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister3 = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister4 = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister5 = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFund = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFund1 = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFund2 = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFund3 = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFund4 = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFundGroups = (ICollection<CrmFundGroups>)new HashSet<CrmFundGroups>();
		CrmFundGroups1 = (ICollection<CrmFundGroups>)new HashSet<CrmFundGroups>();
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessage1 = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessage2 = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessage3 = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessageDefaultContext = (ICollection<CrmInternalMessageDefaultContext>)new HashSet<CrmInternalMessageDefaultContext>();
		CrmInternalMessageDefaultContext1 = (ICollection<CrmInternalMessageDefaultContext>)new HashSet<CrmInternalMessageDefaultContext>();
		CrmInternalMessageDefaultContext2 = (ICollection<CrmInternalMessageDefaultContext>)new HashSet<CrmInternalMessageDefaultContext>();
		CrmInternalMessageDefaultContext3 = (ICollection<CrmInternalMessageDefaultContext>)new HashSet<CrmInternalMessageDefaultContext>();
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageDetails1 = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageDetails2 = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageDetails3 = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageGroup = (ICollection<CrmInternalMessageGroup>)new HashSet<CrmInternalMessageGroup>();
		CrmInternalMessageGroup1 = (ICollection<CrmInternalMessageGroup>)new HashSet<CrmInternalMessageGroup>();
		CrmInternalMessageGroup2 = (ICollection<CrmInternalMessageGroup>)new HashSet<CrmInternalMessageGroup>();
		CrmInternalMessagePriority = (ICollection<CrmInternalMessagePriority>)new HashSet<CrmInternalMessagePriority>();
		CrmInternalMessagePriority1 = (ICollection<CrmInternalMessagePriority>)new HashSet<CrmInternalMessagePriority>();
		CrmInternalMessagePriority2 = (ICollection<CrmInternalMessagePriority>)new HashSet<CrmInternalMessagePriority>();
		CrmInternalMessageSelectReceiver = (ICollection<CrmInternalMessageSelectReceiver>)new HashSet<CrmInternalMessageSelectReceiver>();
		CrmInternalMessageSelectReceiver1 = (ICollection<CrmInternalMessageSelectReceiver>)new HashSet<CrmInternalMessageSelectReceiver>();
		CrmInternalMessageTreeType = (ICollection<CrmInternalMessageTreeType>)new HashSet<CrmInternalMessageTreeType>();
		CrmInternalMessageTreeType1 = (ICollection<CrmInternalMessageTreeType>)new HashSet<CrmInternalMessageTreeType>();
		CrmInternalMessageTreeType2 = (ICollection<CrmInternalMessageTreeType>)new HashSet<CrmInternalMessageTreeType>();
		CrmInternalMessageType = (ICollection<CrmInternalMessageType>)new HashSet<CrmInternalMessageType>();
		CrmInternalMessageType1 = (ICollection<CrmInternalMessageType>)new HashSet<CrmInternalMessageType>();
		CrmInternalMessageType2 = (ICollection<CrmInternalMessageType>)new HashSet<CrmInternalMessageType>();
		CrmKnowledgeTank = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTank1 = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTank2 = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTankGroup = (ICollection<CrmKnowledgeTankGroup>)new HashSet<CrmKnowledgeTankGroup>();
		CrmKnowledgeTankGroup1 = (ICollection<CrmKnowledgeTankGroup>)new HashSet<CrmKnowledgeTankGroup>();
		CrmKnowledgeTankGroup2 = (ICollection<CrmKnowledgeTankGroup>)new HashSet<CrmKnowledgeTankGroup>();
		CrmKnowledgeTankGroupPermission = (ICollection<CrmKnowledgeTankGroupPermission>)new HashSet<CrmKnowledgeTankGroupPermission>();
		CrmKnowledgeTankGroupPermission1 = (ICollection<CrmKnowledgeTankGroupPermission>)new HashSet<CrmKnowledgeTankGroupPermission>();
		CrmKnowledgeTankPriority = (ICollection<CrmKnowledgeTankPriority>)new HashSet<CrmKnowledgeTankPriority>();
		CrmKnowledgeTankPriority1 = (ICollection<CrmKnowledgeTankPriority>)new HashSet<CrmKnowledgeTankPriority>();
		CrmKnowledgeTankPriority2 = (ICollection<CrmKnowledgeTankPriority>)new HashSet<CrmKnowledgeTankPriority>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeave1 = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeave2 = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeave3 = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeaveKinds = (ICollection<CrmLeaveKinds>)new HashSet<CrmLeaveKinds>();
		CrmLeaveStatus = (ICollection<CrmLeaveStatus>)new HashSet<CrmLeaveStatus>();
		CrmLeaveStayType = (ICollection<CrmLeaveStayType>)new HashSet<CrmLeaveStayType>();
		CrmLeaveType = (ICollection<CrmLeaveType>)new HashSet<CrmLeaveType>();
		CrmLeaveVehicleType = (ICollection<CrmLeaveVehicleType>)new HashSet<CrmLeaveVehicleType>();
		CrmLinkAccArpaSetting = (ICollection<CrmLinkAccArpaSetting>)new HashSet<CrmLinkAccArpaSetting>();
		CrmLinkAccArpaSetting1 = (ICollection<CrmLinkAccArpaSetting>)new HashSet<CrmLinkAccArpaSetting>();
		CrmLinkAccByViewSetting = (ICollection<CrmLinkAccByViewSetting>)new HashSet<CrmLinkAccByViewSetting>();
		CrmLinkAccByViewSetting1 = (ICollection<CrmLinkAccByViewSetting>)new HashSet<CrmLinkAccByViewSetting>();
		CrmLinkAccChamberCommerceSetting = (ICollection<CrmLinkAccChamberCommerceSetting>)new HashSet<CrmLinkAccChamberCommerceSetting>();
		CrmLinkAccChamberCommerceSetting1 = (ICollection<CrmLinkAccChamberCommerceSetting>)new HashSet<CrmLinkAccChamberCommerceSetting>();
		CrmLinkAccErrorLogs = (ICollection<CrmLinkAccErrorLogs>)new HashSet<CrmLinkAccErrorLogs>();
		CrmLinkAccHamrahanSetting = (ICollection<CrmLinkAccHamrahanSetting>)new HashSet<CrmLinkAccHamrahanSetting>();
		CrmLinkAccHamrahanSetting1 = (ICollection<CrmLinkAccHamrahanSetting>)new HashSet<CrmLinkAccHamrahanSetting>();
		CrmLinkAccHamrahanSettingDetails = (ICollection<CrmLinkAccHamrahanSettingDetails>)new HashSet<CrmLinkAccHamrahanSettingDetails>();
		CrmLinkAccHamrahanSettingDetails1 = (ICollection<CrmLinkAccHamrahanSettingDetails>)new HashSet<CrmLinkAccHamrahanSettingDetails>();
		CrmLinkAccHolooSetting = (ICollection<CrmLinkAccHolooSetting>)new HashSet<CrmLinkAccHolooSetting>();
		CrmLinkAccHolooSetting1 = (ICollection<CrmLinkAccHolooSetting>)new HashSet<CrmLinkAccHolooSetting>();
		CrmLinkAccHolooSettingDetails = (ICollection<CrmLinkAccHolooSettingDetails>)new HashSet<CrmLinkAccHolooSettingDetails>();
		CrmLinkAccHolooSettingDetails1 = (ICollection<CrmLinkAccHolooSettingDetails>)new HashSet<CrmLinkAccHolooSettingDetails>();
		CrmLinkAccKyanSetting = (ICollection<CrmLinkAccKyanSetting>)new HashSet<CrmLinkAccKyanSetting>();
		CrmLinkAccKyanSetting1 = (ICollection<CrmLinkAccKyanSetting>)new HashSet<CrmLinkAccKyanSetting>();
		CrmLinkAccNoAvIISetting = (ICollection<CrmLinkAccNoAvIISetting>)new HashSet<CrmLinkAccNoAvIISetting>();
		CrmLinkAccNoAvIISetting1 = (ICollection<CrmLinkAccNoAvIISetting>)new HashSet<CrmLinkAccNoAvIISetting>();
		CrmLinkAccNoAvSetting = (ICollection<CrmLinkAccNoAvSetting>)new HashSet<CrmLinkAccNoAvSetting>();
		CrmLinkAccNoAvSetting1 = (ICollection<CrmLinkAccNoAvSetting>)new HashSet<CrmLinkAccNoAvSetting>();
		CrmLinkAccNoAvSettingDetails = (ICollection<CrmLinkAccNoAvSettingDetails>)new HashSet<CrmLinkAccNoAvSettingDetails>();
		CrmLinkAccNoAvSettingDetails1 = (ICollection<CrmLinkAccNoAvSettingDetails>)new HashSet<CrmLinkAccNoAvSettingDetails>();
		CrmLinkAccPayvastSetting = (ICollection<CrmLinkAccPayvastSetting>)new HashSet<CrmLinkAccPayvastSetting>();
		CrmLinkAccPayvastSetting1 = (ICollection<CrmLinkAccPayvastSetting>)new HashSet<CrmLinkAccPayvastSetting>();
		CrmLinkAccPayvastSettingDetails = (ICollection<CrmLinkAccPayvastSettingDetails>)new HashSet<CrmLinkAccPayvastSettingDetails>();
		CrmLinkAccPayvastSettingDetails1 = (ICollection<CrmLinkAccPayvastSettingDetails>)new HashSet<CrmLinkAccPayvastSettingDetails>();
		CrmLinkAccSetting = (ICollection<CrmLinkAccSetting>)new HashSet<CrmLinkAccSetting>();
		CrmLinkAccSetting1 = (ICollection<CrmLinkAccSetting>)new HashSet<CrmLinkAccSetting>();
		CrmLinkAccSettingDetails = (ICollection<CrmLinkAccSettingDetails>)new HashSet<CrmLinkAccSettingDetails>();
		CrmLinkAccSettingDetails1 = (ICollection<CrmLinkAccSettingDetails>)new HashSet<CrmLinkAccSettingDetails>();
		CrmLinkAccShomaranSetting = (ICollection<CrmLinkAccShomaranSetting>)new HashSet<CrmLinkAccShomaranSetting>();
		CrmLinkAccShomaranSetting1 = (ICollection<CrmLinkAccShomaranSetting>)new HashSet<CrmLinkAccShomaranSetting>();
		CrmLinkAccShygunIISetting = (ICollection<CrmLinkAccShygunIISetting>)new HashSet<CrmLinkAccShygunIISetting>();
		CrmLinkAccShygunIISetting1 = (ICollection<CrmLinkAccShygunIISetting>)new HashSet<CrmLinkAccShygunIISetting>();
		CrmLinkAccShygunIISettingDetails = (ICollection<CrmLinkAccShygunIISettingDetails>)new HashSet<CrmLinkAccShygunIISettingDetails>();
		CrmLinkAccShygunIISettingDetails1 = (ICollection<CrmLinkAccShygunIISettingDetails>)new HashSet<CrmLinkAccShygunIISettingDetails>();
		CrmLinkAccShygunSetting = (ICollection<CrmLinkAccShygunSetting>)new HashSet<CrmLinkAccShygunSetting>();
		CrmLinkAccShygunSetting1 = (ICollection<CrmLinkAccShygunSetting>)new HashSet<CrmLinkAccShygunSetting>();
		CrmLinkAccShygunSettingDetails = (ICollection<CrmLinkAccShygunSettingDetails>)new HashSet<CrmLinkAccShygunSettingDetails>();
		CrmLinkAccShygunSettingDetails1 = (ICollection<CrmLinkAccShygunSettingDetails>)new HashSet<CrmLinkAccShygunSettingDetails>();
		CrmLinkAccSystems = (ICollection<CrmLinkAccSystems>)new HashSet<CrmLinkAccSystems>();
		CrmLinkAccSystems1 = (ICollection<CrmLinkAccSystems>)new HashSet<CrmLinkAccSystems>();
		CrmLinkAccTarazSetting = (ICollection<CrmLinkAccTarazSetting>)new HashSet<CrmLinkAccTarazSetting>();
		CrmLinkAccTarazSetting1 = (ICollection<CrmLinkAccTarazSetting>)new HashSet<CrmLinkAccTarazSetting>();
		CrmLinkAccTarazSettingDetails = (ICollection<CrmLinkAccTarazSettingDetails>)new HashSet<CrmLinkAccTarazSettingDetails>();
		CrmLinkAccTarazSettingDetails1 = (ICollection<CrmLinkAccTarazSettingDetails>)new HashSet<CrmLinkAccTarazSettingDetails>();
		CrmLinkedCompany = (ICollection<CrmLinkedCompany>)new HashSet<CrmLinkedCompany>();
		CrmLinkedCompany1 = (ICollection<CrmLinkedCompany>)new HashSet<CrmLinkedCompany>();
		CrmLinkedRolls = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedRolls1 = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedType = (ICollection<CrmLinkedType>)new HashSet<CrmLinkedType>();
		CrmLinkedType1 = (ICollection<CrmLinkedType>)new HashSet<CrmLinkedType>();
		CrmLinkedUserPositions = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmLinkedUserPositions1 = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmLinkedUsers = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmLinkedUsers1 = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmLinkedUsers2 = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmLinkedUsers3 = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmMenuModel = (ICollection<CrmMenuModel>)new HashSet<CrmMenuModel>();
		CrmMenuModel1 = (ICollection<CrmMenuModel>)new HashSet<CrmMenuModel>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting1 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting2 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting3 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting4 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting5 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting6 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting7 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting8 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting9 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting10 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting11 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmMobSetting12 = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		CrmNumRefSetting = (ICollection<CrmNumRefSetting>)new HashSet<CrmNumRefSetting>();
		CrmNumRefSetting1 = (ICollection<CrmNumRefSetting>)new HashSet<CrmNumRefSetting>();
		CrmOnlinePayBankInfo = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		CrmOnlinePayBankInfo1 = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		CrmOperationsType = (ICollection<CrmOperationsType>)new HashSet<CrmOperationsType>();
		CrmOperationsType1 = (ICollection<CrmOperationsType>)new HashSet<CrmOperationsType>();
		CrmPersonDepartments = (ICollection<CrmPersonDepartments>)new HashSet<CrmPersonDepartments>();
		CrmPersonDepartments1 = (ICollection<CrmPersonDepartments>)new HashSet<CrmPersonDepartments>();
		CrmPersonDepartments2 = (ICollection<CrmPersonDepartments>)new HashSet<CrmPersonDepartments>();
		CrmPersonGroups = (ICollection<CrmPersonGroups>)new HashSet<CrmPersonGroups>();
		CrmPersonGroups1 = (ICollection<CrmPersonGroups>)new HashSet<CrmPersonGroups>();
		CrmPersonGroups2 = (ICollection<CrmPersonGroups>)new HashSet<CrmPersonGroups>();
		CrmPersonJobs = (ICollection<CrmPersonJobs>)new HashSet<CrmPersonJobs>();
		CrmPersonJobs1 = (ICollection<CrmPersonJobs>)new HashSet<CrmPersonJobs>();
		CrmPersonJobs2 = (ICollection<CrmPersonJobs>)new HashSet<CrmPersonJobs>();
		CrmPersonPicture = (ICollection<CrmPersonPicture>)new HashSet<CrmPersonPicture>();
		CrmPersonPicture1 = (ICollection<CrmPersonPicture>)new HashSet<CrmPersonPicture>();
		CrmPersonTitle = (ICollection<CrmPersonTitle>)new HashSet<CrmPersonTitle>();
		CrmPersonTitle1 = (ICollection<CrmPersonTitle>)new HashSet<CrmPersonTitle>();
		CrmPersonTitle2 = (ICollection<CrmPersonTitle>)new HashSet<CrmPersonTitle>();
		CrmPersonType = (ICollection<CrmPersonType>)new HashSet<CrmPersonType>();
		CrmPersonType1 = (ICollection<CrmPersonType>)new HashSet<CrmPersonType>();
		CrmPersonType2 = (ICollection<CrmPersonType>)new HashSet<CrmPersonType>();
		CrmProjectCategory = (ICollection<CrmProjectCategory>)new HashSet<CrmProjectCategory>();
		CrmProjectCategory1 = (ICollection<CrmProjectCategory>)new HashSet<CrmProjectCategory>();
		CrmProjectDefualtValue = (ICollection<CrmProjectDefualtValue>)new HashSet<CrmProjectDefualtValue>();
		CrmProjectDefualtValue1 = (ICollection<CrmProjectDefualtValue>)new HashSet<CrmProjectDefualtValue>();
		CrmProjectDefualtValue2 = (ICollection<CrmProjectDefualtValue>)new HashSet<CrmProjectDefualtValue>();
		CrmProjectFieldTitle = (ICollection<CrmProjectFieldTitle>)new HashSet<CrmProjectFieldTitle>();
		CrmProjectFieldTitle1 = (ICollection<CrmProjectFieldTitle>)new HashSet<CrmProjectFieldTitle>();
		CrmProjectFieldTitle2 = (ICollection<CrmProjectFieldTitle>)new HashSet<CrmProjectFieldTitle>();
		CrmProjectGrade = (ICollection<CrmProjectGrade>)new HashSet<CrmProjectGrade>();
		CrmProjectGrade1 = (ICollection<CrmProjectGrade>)new HashSet<CrmProjectGrade>();
		CrmProjectGrade2 = (ICollection<CrmProjectGrade>)new HashSet<CrmProjectGrade>();
		CrmProjectGroups = (ICollection<CrmProjectGroups>)new HashSet<CrmProjectGroups>();
		CrmProjectGroups1 = (ICollection<CrmProjectGroups>)new HashSet<CrmProjectGroups>();
		CrmProjectGroups2 = (ICollection<CrmProjectGroups>)new HashSet<CrmProjectGroups>();
		CrmProjectGroupsMulti = (ICollection<CrmProjectGroupsMulti>)new HashSet<CrmProjectGroupsMulti>();
		CrmProjectGroupsMulti1 = (ICollection<CrmProjectGroupsMulti>)new HashSet<CrmProjectGroupsMulti>();
		CrmProjectGroupsMulti2 = (ICollection<CrmProjectGroupsMulti>)new HashSet<CrmProjectGroupsMulti>();
		CrmProjectGroupsMultiI = (ICollection<CrmProjectGroupsMultiI>)new HashSet<CrmProjectGroupsMultiI>();
		CrmProjectGroupsMultiI1 = (ICollection<CrmProjectGroupsMultiI>)new HashSet<CrmProjectGroupsMultiI>();
		CrmProjectGroupsMultiI2 = (ICollection<CrmProjectGroupsMultiI>)new HashSet<CrmProjectGroupsMultiI>();
		CrmProjectInformations = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
		CrmProjectInformations1 = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
		CrmProjectInformations2 = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
		CrmProjectMultiGroups = (ICollection<CrmProjectMultiGroups>)new HashSet<CrmProjectMultiGroups>();
		CrmProjectMultiGroups1 = (ICollection<CrmProjectMultiGroups>)new HashSet<CrmProjectMultiGroups>();
		CrmProjectMultiGroups2 = (ICollection<CrmProjectMultiGroups>)new HashSet<CrmProjectMultiGroups>();
		CrmProjectMultiIGroups = (ICollection<CrmProjectMultiIGroups>)new HashSet<CrmProjectMultiIGroups>();
		CrmProjectMultiIGroups1 = (ICollection<CrmProjectMultiIGroups>)new HashSet<CrmProjectMultiIGroups>();
		CrmProjectMultiIGroups2 = (ICollection<CrmProjectMultiIGroups>)new HashSet<CrmProjectMultiIGroups>();
		CrmProjectPriority = (ICollection<CrmProjectPriority>)new HashSet<CrmProjectPriority>();
		CrmProjectPriority1 = (ICollection<CrmProjectPriority>)new HashSet<CrmProjectPriority>();
		CrmProjectPriority2 = (ICollection<CrmProjectPriority>)new HashSet<CrmProjectPriority>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects1 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects2 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects3 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects4 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects5 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects6 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects7 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects8 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjects9 = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		CrmProjectsForbiddenForUser = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmProjectsForbiddenForUser1 = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmProjectsForbiddenForUser2 = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmProjectsForbiddenForUser3 = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmProjectTitleGroups = (ICollection<CrmProjectTitleGroups>)new HashSet<CrmProjectTitleGroups>();
		CrmProjectTitleGroups1 = (ICollection<CrmProjectTitleGroups>)new HashSet<CrmProjectTitleGroups>();
		CrmProjectTitles = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmProjectTitles1 = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmProjectTitles2 = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmShowTableFieldInFO = (ICollection<CrmShowTableFieldInFO>)new HashSet<CrmShowTableFieldInFO>();
		CrmShowTableFieldInFO1 = (ICollection<CrmShowTableFieldInFO>)new HashSet<CrmShowTableFieldInFO>();
		CrmSurvey = (ICollection<CrmSurvey>)new HashSet<CrmSurvey>();
		CrmSurvey1 = (ICollection<CrmSurvey>)new HashSet<CrmSurvey>();
		CrmSurveyAnswerCategory = (ICollection<CrmSurveyAnswerCategory>)new HashSet<CrmSurveyAnswerCategory>();
		CrmSurveyAnswerCategory1 = (ICollection<CrmSurveyAnswerCategory>)new HashSet<CrmSurveyAnswerCategory>();
		CrmSurveyAnswerCategoryDetails = (ICollection<CrmSurveyAnswerCategoryDetails>)new HashSet<CrmSurveyAnswerCategoryDetails>();
		CrmSurveyAnswerCategoryDetails1 = (ICollection<CrmSurveyAnswerCategoryDetails>)new HashSet<CrmSurveyAnswerCategoryDetails>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
		CrmSurveyAnswerCategoryDetailValues1 = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
		CrmSurveyAnswers = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
		CrmSurveyAnswers1 = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyAnswerValue1 = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyAnswerValue2 = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSurveyHistory1 = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSurveyQuestions = (ICollection<CrmSurveyQuestions>)new HashSet<CrmSurveyQuestions>();
		CrmSurveyQuestions1 = (ICollection<CrmSurveyQuestions>)new HashSet<CrmSurveyQuestions>();
		CrmSurveySendSetting = (ICollection<CrmSurveySendSetting>)new HashSet<CrmSurveySendSetting>();
		CrmSurveySendSetting1 = (ICollection<CrmSurveySendSetting>)new HashSet<CrmSurveySendSetting>();
		CrmsysCIDeviceType = (ICollection<CrmsysCIDeviceType>)new HashSet<CrmsysCIDeviceType>();
		CrmsysCIPopUpSetting = (ICollection<CrmsysCIPopUpSetting>)new HashSet<CrmsysCIPopUpSetting>();
		CrmsysCIPopUpSetting1 = (ICollection<CrmsysCIPopUpSetting>)new HashSet<CrmsysCIPopUpSetting>();
		CrmsysCIPopUpSetting2 = (ICollection<CrmsysCIPopUpSetting>)new HashSet<CrmsysCIPopUpSetting>();
		CrmsysCISetting = (ICollection<CrmsysCISetting>)new HashSet<CrmsysCISetting>();
		CrmsysDBObjects = (ICollection<CrmsysDBObjects>)new HashSet<CrmsysDBObjects>();
		CrmsysDBTempInfo = (ICollection<CrmsysDBTempInfo>)new HashSet<CrmsysDBTempInfo>();
		CrmsysDBTempInfo1 = (ICollection<CrmsysDBTempInfo>)new HashSet<CrmsysDBTempInfo>();
		CrmsysDBTempInfoType = (ICollection<CrmsysDBTempInfoType>)new HashSet<CrmsysDBTempInfoType>();
		CrmsysFormActions = (ICollection<CrmsysFormActions>)new HashSet<CrmsysFormActions>();
		CrmsysFormObjectProperties = (ICollection<CrmsysFormObjectProperties>)new HashSet<CrmsysFormObjectProperties>();
		CrmsysFormObjectProperties1 = (ICollection<CrmsysFormObjectProperties>)new HashSet<CrmsysFormObjectProperties>();
		CrmsysFormObjectProperties2 = (ICollection<CrmsysFormObjectProperties>)new HashSet<CrmsysFormObjectProperties>();
		CrmsysForms = (ICollection<CrmsysForms>)new HashSet<CrmsysForms>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
		CrmsysRolls = (ICollection<CrmsysRolls>)new HashSet<CrmsysRolls>();
		CrmsysRolls1 = (ICollection<CrmsysRolls>)new HashSet<CrmsysRolls>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmsysSetting1 = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmsysSetting2 = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmsysSetting3 = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmSystemParts = (ICollection<CrmSystemParts>)new HashSet<CrmSystemParts>();
		CrmSystemParts1 = (ICollection<CrmSystemParts>)new HashSet<CrmSystemParts>();
		CrmTelegBotChatMessage = (ICollection<CrmTelegBotChatMessage>)new HashSet<CrmTelegBotChatMessage>();
		CrmTelegBotContacts = (ICollection<CrmTelegBotContacts>)new HashSet<CrmTelegBotContacts>();
		CrmTelegBotContacts1 = (ICollection<CrmTelegBotContacts>)new HashSet<CrmTelegBotContacts>();
		CrmTelegBotSetting = (ICollection<CrmTelegBotSetting>)new HashSet<CrmTelegBotSetting>();
		CrmTelegBotSetting1 = (ICollection<CrmTelegBotSetting>)new HashSet<CrmTelegBotSetting>();
		CrmTelegChatMessage = (ICollection<CrmTelegChatMessage>)new HashSet<CrmTelegChatMessage>();
		CrmTelegContacts = (ICollection<CrmTelegContacts>)new HashSet<CrmTelegContacts>();
		CrmTelegContacts1 = (ICollection<CrmTelegContacts>)new HashSet<CrmTelegContacts>();
		CrmTelegSetting = (ICollection<CrmTelegSetting>)new HashSet<CrmTelegSetting>();
		CrmTelegSetting1 = (ICollection<CrmTelegSetting>)new HashSet<CrmTelegSetting>();
		CrmTempEmails = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		CrmTempEmails1 = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		CrmTempEmails2 = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		CrmTimeAttendance = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendance1 = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendance2 = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendance3 = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendance4 = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendance5 = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		CrmTimeAttendanceBase = (ICollection<CrmTimeAttendanceBase>)new HashSet<CrmTimeAttendanceBase>();
		CrmTimeAttendanceBase1 = (ICollection<CrmTimeAttendanceBase>)new HashSet<CrmTimeAttendanceBase>();
		CrmTimeAttendanceBase2 = (ICollection<CrmTimeAttendanceBase>)new HashSet<CrmTimeAttendanceBase>();
		CrmTimeAttendanceLog = (ICollection<CrmTimeAttendanceLog>)new HashSet<CrmTimeAttendanceLog>();
		CrmTimeAttendanceLog1 = (ICollection<CrmTimeAttendanceLog>)new HashSet<CrmTimeAttendanceLog>();
		CrmTimeAttendanceLog2 = (ICollection<CrmTimeAttendanceLog>)new HashSet<CrmTimeAttendanceLog>();
		CrmTimeAttendanceLog3 = (ICollection<CrmTimeAttendanceLog>)new HashSet<CrmTimeAttendanceLog>();
		CRMtmpManageTellNumber = (ICollection<CRMtmpManageTellNumber>)new HashSet<CRMtmpManageTellNumber>();
		CRMtmpManageTellNumber1 = (ICollection<CRMtmpManageTellNumber>)new HashSet<CRMtmpManageTellNumber>();
		CrmUserNotes = (ICollection<CrmUserNotes>)new HashSet<CrmUserNotes>();
		CrmUserNotes1 = (ICollection<CrmUserNotes>)new HashSet<CrmUserNotes>();
		CrmUserReportFilter = (ICollection<CrmUserReportFilter>)new HashSet<CrmUserReportFilter>();
		CrmUserReportFilter1 = (ICollection<CrmUserReportFilter>)new HashSet<CrmUserReportFilter>();
		CrmUserTaskGroups = (ICollection<CrmUserTaskGroups>)new HashSet<CrmUserTaskGroups>();
		CrmUserTaskGroups1 = (ICollection<CrmUserTaskGroups>)new HashSet<CrmUserTaskGroups>();
		CrmUserTaskGroups2 = (ICollection<CrmUserTaskGroups>)new HashSet<CrmUserTaskGroups>();
		CrmUserTaskPriorities = (ICollection<CrmUserTaskPriorities>)new HashSet<CrmUserTaskPriorities>();
		CrmUserTaskPriorities1 = (ICollection<CrmUserTaskPriorities>)new HashSet<CrmUserTaskPriorities>();
		CrmUserTaskPriorities2 = (ICollection<CrmUserTaskPriorities>)new HashSet<CrmUserTaskPriorities>();
		CrmUserTasks = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
		CrmUserTasks1 = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
		CrmUserTasks2 = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
		CrmVersions = (ICollection<CrmVersions>)new HashSet<CrmVersions>();
		CrmVersionUpgrade = (ICollection<CrmVersionUpgrade>)new HashSet<CrmVersionUpgrade>();
		CrmVersionUpgradeDetails = (ICollection<CrmVersionUpgradeDetails>)new HashSet<CrmVersionUpgradeDetails>();
		CrmWebSetting = (ICollection<CrmWebSetting>)new HashSet<CrmWebSetting>();
		CrmWebSetting1 = (ICollection<CrmWebSetting>)new HashSet<CrmWebSetting>();
		Education = (ICollection<Education>)new HashSet<Education>();
		Education1 = (ICollection<Education>)new HashSet<Education>();
		Education2 = (ICollection<Education>)new HashSet<Education>();
		EmailDefaultBodyText = (ICollection<EmailDefaultBodyText>)new HashSet<EmailDefaultBodyText>();
		EmailDefaultBodyText1 = (ICollection<EmailDefaultBodyText>)new HashSet<EmailDefaultBodyText>();
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceive1 = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceiveAttachments = (ICollection<EmailReceiveAttachments>)new HashSet<EmailReceiveAttachments>();
		EmailReceiveAttachments1 = (ICollection<EmailReceiveAttachments>)new HashSet<EmailReceiveAttachments>();
		EmailReceiveFolders = (ICollection<EmailReceiveFolders>)new HashSet<EmailReceiveFolders>();
		EmailReceiveFolders1 = (ICollection<EmailReceiveFolders>)new HashSet<EmailReceiveFolders>();
		EmailSendAttachment = (ICollection<EmailSendAttachment>)new HashSet<EmailSendAttachment>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
		EmailSendHeader = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		EmailSendHeader1 = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		EmailSetting = (ICollection<EmailSetting>)new HashSet<EmailSetting>();
		EmailSetting1 = (ICollection<EmailSetting>)new HashSet<EmailSetting>();
		EmailUserDefaultSetting = (ICollection<EmailUserDefaultSetting>)new HashSet<EmailUserDefaultSetting>();
		EmailUserDefaultSetting1 = (ICollection<EmailUserDefaultSetting>)new HashSet<EmailUserDefaultSetting>();
		EmailUserDefaultSetting2 = (ICollection<EmailUserDefaultSetting>)new HashSet<EmailUserDefaultSetting>();
		EmailUsersInfo = (ICollection<EmailUsersInfo>)new HashSet<EmailUsersInfo>();
		EmailUsersInfo1 = (ICollection<EmailUsersInfo>)new HashSet<EmailUsersInfo>();
		EmailUsersInfo2 = (ICollection<EmailUsersInfo>)new HashSet<EmailUsersInfo>();
		EmailUsersInfo3 = (ICollection<EmailUsersInfo>)new HashSet<EmailUsersInfo>();
		EmailUserTempTank = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		EmailUserTempTank1 = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		Languages = (ICollection<Languages>)new HashSet<Languages>();
		Languages1 = (ICollection<Languages>)new HashSet<Languages>();
		Languages2 = (ICollection<Languages>)new HashSet<Languages>();
		PayRollItems = (ICollection<PayRollItems>)new HashSet<PayRollItems>();
		PayRollItems1 = (ICollection<PayRollItems>)new HashSet<PayRollItems>();
		PayRollItemTypes = (ICollection<PayRollItemTypes>)new HashSet<PayRollItemTypes>();
		PayRollItemTypes1 = (ICollection<PayRollItemTypes>)new HashSet<PayRollItemTypes>();
		PayRollList = (ICollection<PayRollList>)new HashSet<PayRollList>();
		PayRollList1 = (ICollection<PayRollList>)new HashSet<PayRollList>();
		PayRollListGroups = (ICollection<PayRollListGroups>)new HashSet<PayRollListGroups>();
		PayRollListGroups1 = (ICollection<PayRollListGroups>)new HashSet<PayRollListGroups>();
		PayRollListItems = (ICollection<PayRollListItems>)new HashSet<PayRollListItems>();
		PayRollListItems1 = (ICollection<PayRollListItems>)new HashSet<PayRollListItems>();
		PayRollUserCycle = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserCycle1 = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserCycle2 = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserCycle3 = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserCycleItemValues = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserCycleItemValues1 = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserCycleItemValues2 = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserDefaultItems = (ICollection<PayRollUserDefaultItems>)new HashSet<PayRollUserDefaultItems>();
		PayRollUserDefaultItems1 = (ICollection<PayRollUserDefaultItems>)new HashSet<PayRollUserDefaultItems>();
		PayRollUserDefaultItems2 = (ICollection<PayRollUserDefaultItems>)new HashSet<PayRollUserDefaultItems>();
		PayRollUserPayments = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		PayRollUserPayments1 = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		PayRollUserPaymentTypes = (ICollection<PayRollUserPaymentTypes>)new HashSet<PayRollUserPaymentTypes>();
		PayRollUserPaymentTypes1 = (ICollection<PayRollUserPaymentTypes>)new HashSet<PayRollUserPaymentTypes>();
		PrintFormat = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		PrintFormat1 = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		PrintFormat2 = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		PrintFormatType = (ICollection<PrintFormatType>)new HashSet<PrintFormatType>();
		PrintFormatType1 = (ICollection<PrintFormatType>)new HashSet<PrintFormatType>();
		PrintFormatType2 = (ICollection<PrintFormatType>)new HashSet<PrintFormatType>();
		Projects = (ICollection<Projects>)new HashSet<Projects>();
		Projects1 = (ICollection<Projects>)new HashSet<Projects>();
		Province = (ICollection<Province>)new HashSet<Province>();
		Province1 = (ICollection<Province>)new HashSet<Province>();
		Province2 = (ICollection<Province>)new HashSet<Province>();
		ScoreRules = (ICollection<ScoreRules>)new HashSet<ScoreRules>();
		ScoreRules1 = (ICollection<ScoreRules>)new HashSet<ScoreRules>();
		ScoreRulesSetting = (ICollection<ScoreRulesSetting>)new HashSet<ScoreRulesSetting>();
		ScoreRulesSetting1 = (ICollection<ScoreRulesSetting>)new HashSet<ScoreRulesSetting>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
		Scores1 = (ICollection<Scores>)new HashSet<Scores>();
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterDefaultSettings1 = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterDefaultSettings2 = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterDefaultSettings3 = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterDefaultSettings4 = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetterNumberCounter = (ICollection<SecLetterNumberCounter>)new HashSet<SecLetterNumberCounter>();
		SecLetterNumberCounter1 = (ICollection<SecLetterNumberCounter>)new HashSet<SecLetterNumberCounter>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetters1 = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetters2 = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetters3 = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetters4 = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetterType = (ICollection<SecLetterType>)new HashSet<SecLetterType>();
		SecLetterType1 = (ICollection<SecLetterType>)new HashSet<SecLetterType>();
		SecLetterType2 = (ICollection<SecLetterType>)new HashSet<SecLetterType>();
		Sex = (ICollection<Sex>)new HashSet<Sex>();
		Sex1 = (ICollection<Sex>)new HashSet<Sex>();
		SmsDefaultBodyText = (ICollection<SmsDefaultBodyText>)new HashSet<SmsDefaultBodyText>();
		SmsDefaultBodyText1 = (ICollection<SmsDefaultBodyText>)new HashSet<SmsDefaultBodyText>();
		SmsDefaultBodyTextGroups = (ICollection<SmsDefaultBodyTextGroups>)new HashSet<SmsDefaultBodyTextGroups>();
		SmsDefaultBodyTextGroups1 = (ICollection<SmsDefaultBodyTextGroups>)new HashSet<SmsDefaultBodyTextGroups>();
		SmsDeliveryStatus = (ICollection<SmsDeliveryStatus>)new HashSet<SmsDeliveryStatus>();
		SmsGSMModemDelivery = (ICollection<SmsGSMModemDelivery>)new HashSet<SmsGSMModemDelivery>();
		SmsGSMModemSetting = (ICollection<SmsGSMModemSetting>)new HashSet<SmsGSMModemSetting>();
		SmsGSMModemSetting1 = (ICollection<SmsGSMModemSetting>)new HashSet<SmsGSMModemSetting>();
		SmsGSMReceives = (ICollection<SmsGSMReceives>)new HashSet<SmsGSMReceives>();
		SmsGSMSendingTank = (ICollection<SmsGSMSendingTank>)new HashSet<SmsGSMSendingTank>();
		SmsProviders = (ICollection<SmsProviders>)new HashSet<SmsProviders>();
		SmsProviders1 = (ICollection<SmsProviders>)new HashSet<SmsProviders>();
		SmsReceive = (ICollection<SmsReceive>)new HashSet<SmsReceive>();
		SmsReceive1 = (ICollection<SmsReceive>)new HashSet<SmsReceive>();
		SmsReceiveFromWSDL = (ICollection<SmsReceiveFromWSDL>)new HashSet<SmsReceiveFromWSDL>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		SmsSendDetail1 = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		SmsSendDetail2 = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		SmsSendHeader = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		SmsSendHeader1 = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		SmsSendHeader2 = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		SmsSendType = (ICollection<SmsSendType>)new HashSet<SmsSendType>();
		SmsSetting = (ICollection<SmsSetting>)new HashSet<SmsSetting>();
		SmsSetting1 = (ICollection<SmsSetting>)new HashSet<SmsSetting>();
		SmsTempMobileNumbers = (ICollection<SmsTempMobileNumbers>)new HashSet<SmsTempMobileNumbers>();
		SmsTempMobileNumbers1 = (ICollection<SmsTempMobileNumbers>)new HashSet<SmsTempMobileNumbers>();
		SmsUserSendCredit = (ICollection<SmsUserSendCredit>)new HashSet<SmsUserSendCredit>();
		SmsUserSendCredit1 = (ICollection<SmsUserSendCredit>)new HashSet<SmsUserSendCredit>();
		SmsUserSendCredit2 = (ICollection<SmsUserSendCredit>)new HashSet<SmsUserSendCredit>();
		TspSetting = (ICollection<TspSetting>)new HashSet<TspSetting>();
		TspSetting1 = (ICollection<TspSetting>)new HashSet<TspSetting>();
		UserDepartments = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartments1 = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartments2 = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartments3 = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartmentTicketReferUsers = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		UserDepartmentTicketReferUsers1 = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		UserDepartmentTicketReferUsers2 = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		UserGroups = (ICollection<UserGroups>)new HashSet<UserGroups>();
		UserGroups1 = (ICollection<UserGroups>)new HashSet<UserGroups>();
		UserLanguages = (ICollection<UserLanguages>)new HashSet<UserLanguages>();
		UserLanguages1 = (ICollection<UserLanguages>)new HashSet<UserLanguages>();
		UserLanguages2 = (ICollection<UserLanguages>)new HashSet<UserLanguages>();
		UserLoginAllowedTimes = (ICollection<UserLoginAllowedTimes>)new HashSet<UserLoginAllowedTimes>();
		UserLoginAllowedTimes1 = (ICollection<UserLoginAllowedTimes>)new HashSet<UserLoginAllowedTimes>();
		UserLoginAllowedTimes2 = (ICollection<UserLoginAllowedTimes>)new HashSet<UserLoginAllowedTimes>();
		UserLoginAllowedTimes3 = (ICollection<UserLoginAllowedTimes>)new HashSet<UserLoginAllowedTimes>();
		UserMoneyBag = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		UserMoneyBag1 = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		UserMoneyBag2 = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		UserPictures = (ICollection<UserPictures>)new HashSet<UserPictures>();
		UserPictures1 = (ICollection<UserPictures>)new HashSet<UserPictures>();
		UserPictures2 = (ICollection<UserPictures>)new HashSet<UserPictures>();
		UserPositions = (ICollection<UserPositions>)new HashSet<UserPositions>();
		UserPositions1 = (ICollection<UserPositions>)new HashSet<UserPositions>();
		Users_Lang = (ICollection<Users_Lang>)new HashSet<Users_Lang>();
		Users1 = (ICollection<Users>)new HashSet<Users>();
		Users11 = (ICollection<Users>)new HashSet<Users>();
		Users12 = (ICollection<Users>)new HashSet<Users>();
		Users13 = (ICollection<Users>)new HashSet<Users>();
		UserSignature = (ICollection<UserSignature>)new HashSet<UserSignature>();
		UserSignature1 = (ICollection<UserSignature>)new HashSet<UserSignature>();
		UserSignature2 = (ICollection<UserSignature>)new HashSet<UserSignature>();
		UsersPermission = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		UsersPermission1 = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		UsersPermission2 = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder1 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder2 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder3 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder4 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrder5 = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSBuyOrderDefaultSetting1 = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSBuyOrderDefaultSetting2 = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItems1 = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItemSerials = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSBuyOrderItemSerials1 = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSBuyOrderOpr = (ICollection<WSBuyOrderOpr>)new HashSet<WSBuyOrderOpr>();
		WSBuyOrderOpr1 = (ICollection<WSBuyOrderOpr>)new HashSet<WSBuyOrderOpr>();
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPayments1 = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPayments2 = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPayments3 = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPayments4 = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPaymentTypes = (ICollection<WSBuyOrderPaymentTypes>)new HashSet<WSBuyOrderPaymentTypes>();
		WSBuyOrderPaymentTypes1 = (ICollection<WSBuyOrderPaymentTypes>)new HashSet<WSBuyOrderPaymentTypes>();
		WSBuyOrderStatus = (ICollection<WSBuyOrderStatus>)new HashSet<WSBuyOrderStatus>();
		WSBuyOrderStatus1 = (ICollection<WSBuyOrderStatus>)new HashSet<WSBuyOrderStatus>();
		WSCostSheetDyFieldGroups = (ICollection<WSCostSheetDyFieldGroups>)new HashSet<WSCostSheetDyFieldGroups>();
		WSCostSheetDyFieldGroups1 = (ICollection<WSCostSheetDyFieldGroups>)new HashSet<WSCostSheetDyFieldGroups>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetDyFieldValues1 = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheetItems1 = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheetProducts = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSCostSheetProducts1 = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCostSheets1 = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCostSheets2 = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCreditDuration = (ICollection<WSCreditDuration>)new HashSet<WSCreditDuration>();
		WSCreditDuration1 = (ICollection<WSCreditDuration>)new HashSet<WSCreditDuration>();
		WSCurrencyUnitRate = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSCurrencyUnitRate1 = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSCurrencyUnits = (ICollection<WSCurrencyUnits>)new HashSet<WSCurrencyUnits>();
		WSCurrencyUnits1 = (ICollection<WSCurrencyUnits>)new HashSet<WSCurrencyUnits>();
		WSDeliverySchedule = (ICollection<WSDeliverySchedule>)new HashSet<WSDeliverySchedule>();
		WSDeliverySchedule1 = (ICollection<WSDeliverySchedule>)new HashSet<WSDeliverySchedule>();
		WSDeliveryScheduleExcept = (ICollection<WSDeliveryScheduleExcept>)new HashSet<WSDeliveryScheduleExcept>();
		WSDeliveryScheduleExcept1 = (ICollection<WSDeliveryScheduleExcept>)new HashSet<WSDeliveryScheduleExcept>();
		WSDeliveryTerms = (ICollection<WSDeliveryTerms>)new HashSet<WSDeliveryTerms>();
		WSDeliveryTerms1 = (ICollection<WSDeliveryTerms>)new HashSet<WSDeliveryTerms>();
		WSDeliveryTime = (ICollection<WSDeliveryTime>)new HashSet<WSDeliveryTime>();
		WSDeliveryTime1 = (ICollection<WSDeliveryTime>)new HashSet<WSDeliveryTime>();
		WSDiscountCode = (ICollection<WSDiscountCode>)new HashSet<WSDiscountCode>();
		WSDiscountCode1 = (ICollection<WSDiscountCode>)new HashSet<WSDiscountCode>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSDiscountCodeHistory1 = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSDiscountStrategy = (ICollection<WSDiscountStrategy>)new HashSet<WSDiscountStrategy>();
		WSDiscountStrategy1 = (ICollection<WSDiscountStrategy>)new HashSet<WSDiscountStrategy>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDoc1 = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDoc2 = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDoc3 = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDoc4 = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItems1 = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItemSerials = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
		WSDocItemSerials1 = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
		WSDocOpr = (ICollection<WSDocOpr>)new HashSet<WSDocOpr>();
		WSDocOpr1 = (ICollection<WSDocOpr>)new HashSet<WSDocOpr>();
		WSFinancialPeriod = (ICollection<WSFinancialPeriod>)new HashSet<WSFinancialPeriod>();
		WSFinancialPeriod1 = (ICollection<WSFinancialPeriod>)new HashSet<WSFinancialPeriod>();
		WSGuaranty = (ICollection<WSGuaranty>)new HashSet<WSGuaranty>();
		WSGuaranty1 = (ICollection<WSGuaranty>)new HashSet<WSGuaranty>();
		WSLinkedProducts = (ICollection<WSLinkedProducts>)new HashSet<WSLinkedProducts>();
		WSLinkedProducts1 = (ICollection<WSLinkedProducts>)new HashSet<WSLinkedProducts>();
		WSLogo = (ICollection<WSLogo>)new HashSet<WSLogo>();
		WSLogo1 = (ICollection<WSLogo>)new HashSet<WSLogo>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder1 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder2 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder3 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder4 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder5 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder6 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrder7 = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderCommissionPayTypes = (ICollection<WSOrderCommissionPayTypes>)new HashSet<WSOrderCommissionPayTypes>();
		WSOrderCommissionPayTypes1 = (ICollection<WSOrderCommissionPayTypes>)new HashSet<WSOrderCommissionPayTypes>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions1 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions2 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions3 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions4 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderCommissions5 = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting1 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting2 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting3 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDefaultSetting4 = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSOrderDiscounts1 = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSOrderGroups = (ICollection<WSOrderGroups>)new HashSet<WSOrderGroups>();
		WSOrderGroups1 = (ICollection<WSOrderGroups>)new HashSet<WSOrderGroups>();
		WSOrderImportFromExcelFields = (ICollection<WSOrderImportFromExcelFields>)new HashSet<WSOrderImportFromExcelFields>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItems1 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItems2 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItems3 = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItemSerials = (ICollection<WSOrderItemSerials>)new HashSet<WSOrderItemSerials>();
		WSOrderItemSerials1 = (ICollection<WSOrderItemSerials>)new HashSet<WSOrderItemSerials>();
		WSOrderOpr = (ICollection<WSOrderOpr>)new HashSet<WSOrderOpr>();
		WSOrderOpr1 = (ICollection<WSOrderOpr>)new HashSet<WSOrderOpr>();
		WSOrderPaymentGroupsI = (ICollection<WSOrderPaymentGroupsI>)new HashSet<WSOrderPaymentGroupsI>();
		WSOrderPaymentGroupsI1 = (ICollection<WSOrderPaymentGroupsI>)new HashSet<WSOrderPaymentGroupsI>();
		WSOrderPaymentGroupsII = (ICollection<WSOrderPaymentGroupsII>)new HashSet<WSOrderPaymentGroupsII>();
		WSOrderPaymentGroupsII1 = (ICollection<WSOrderPaymentGroupsII>)new HashSet<WSOrderPaymentGroupsII>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPayments1 = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPayments2 = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPayments3 = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPayments4 = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPayments5 = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSOrderPaymentTypes1 = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSOrderStatus = (ICollection<WSOrderStatus>)new HashSet<WSOrderStatus>();
		WSOrderStatus1 = (ICollection<WSOrderStatus>)new HashSet<WSOrderStatus>();
		WSPayCondition = (ICollection<WSPayCondition>)new HashSet<WSPayCondition>();
		WSPayCondition1 = (ICollection<WSPayCondition>)new HashSet<WSPayCondition>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder1 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder2 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder3 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder4 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder5 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder6 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrder7 = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderCommissions1 = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderCommissions2 = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderCommissions3 = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderCommissions4 = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting1 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting2 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting3 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDefaultSetting4 = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		WSPreOrderDiscounts1 = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSPreOrderItems1 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSPreOrderItems2 = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSPreOrderItemSpecification = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSPreOrderItemSpecification1 = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSPreOrderOpr = (ICollection<WSPreOrderOpr>)new HashSet<WSPreOrderOpr>();
		WSPreOrderOpr1 = (ICollection<WSPreOrderOpr>)new HashSet<WSPreOrderOpr>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPayments1 = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPayments2 = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPayments3 = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPayments4 = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSPreOrderPrdGroupMustExistReasons1 = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSPreOrderStatus = (ICollection<WSPreOrderStatus>)new HashSet<WSPreOrderStatus>();
		WSPreOrderStatus1 = (ICollection<WSPreOrderStatus>)new HashSet<WSPreOrderStatus>();
		WSPreOrderTypes = (ICollection<WSPreOrderTypes>)new HashSet<WSPreOrderTypes>();
		WSPreOrderTypes1 = (ICollection<WSPreOrderTypes>)new HashSet<WSPreOrderTypes>();
		WSProductColor = (ICollection<WSProductColor>)new HashSet<WSProductColor>();
		WSProductColor1 = (ICollection<WSProductColor>)new HashSet<WSProductColor>();
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductCost1 = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductCostGroup = (ICollection<WSProductCostGroup>)new HashSet<WSProductCostGroup>();
		WSProductCostGroup1 = (ICollection<WSProductCostGroup>)new HashSet<WSProductCostGroup>();
		WSProductFirstGroup = (ICollection<WSProductFirstGroup>)new HashSet<WSProductFirstGroup>();
		WSProductFirstGroup1 = (ICollection<WSProductFirstGroup>)new HashSet<WSProductFirstGroup>();
		WSProductGallery = (ICollection<WSProductGallery>)new HashSet<WSProductGallery>();
		WSProductGallery1 = (ICollection<WSProductGallery>)new HashSet<WSProductGallery>();
		WSProductGroupPicture = (ICollection<WSProductGroupPicture>)new HashSet<WSProductGroupPicture>();
		WSProductGroupPicture1 = (ICollection<WSProductGroupPicture>)new HashSet<WSProductGroupPicture>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSProductImportFromExcel1 = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		WSProductImportFromExcelFields = (ICollection<WSProductImportFromExcelFields>)new HashSet<WSProductImportFromExcelFields>();
		WSProductPicture = (ICollection<WSProductPicture>)new HashSet<WSProductPicture>();
		WSProductPicture1 = (ICollection<WSProductPicture>)new HashSet<WSProductPicture>();
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSProductPrice1 = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSProductPriceGroup = (ICollection<WSProductPriceGroup>)new HashSet<WSProductPriceGroup>();
		WSProductPriceGroup1 = (ICollection<WSProductPriceGroup>)new HashSet<WSProductPriceGroup>();
		WSProductRelationLimit = (ICollection<WSProductRelationLimit>)new HashSet<WSProductRelationLimit>();
		WSProductRelationLimit1 = (ICollection<WSProductRelationLimit>)new HashSet<WSProductRelationLimit>();
		WSProductRelationType = (ICollection<WSProductRelationType>)new HashSet<WSProductRelationType>();
		WSProductRelationType1 = (ICollection<WSProductRelationType>)new HashSet<WSProductRelationType>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProducts1 = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProductSecondGroup = (ICollection<WSProductSecondGroup>)new HashSet<WSProductSecondGroup>();
		WSProductSecondGroup1 = (ICollection<WSProductSecondGroup>)new HashSet<WSProductSecondGroup>();
		WSProductShpException = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		WSProductShpException1 = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		WSProductShpStockManageTypes = (ICollection<WSProductShpStockManageTypes>)new HashSet<WSProductShpStockManageTypes>();
		WSProductShpStockManageTypes1 = (ICollection<WSProductShpStockManageTypes>)new HashSet<WSProductShpStockManageTypes>();
		WSProductSpecification = (ICollection<WSProductSpecification>)new HashSet<WSProductSpecification>();
		WSProductSpecification1 = (ICollection<WSProductSpecification>)new HashSet<WSProductSpecification>();
		WSProductSpecificationFieldGroups = (ICollection<WSProductSpecificationFieldGroups>)new HashSet<WSProductSpecificationFieldGroups>();
		WSProductSpecificationFieldGroups1 = (ICollection<WSProductSpecificationFieldGroups>)new HashSet<WSProductSpecificationFieldGroups>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
		WSProductSpecificationFields1 = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
		WSProductSpecificationFieldTypes = (ICollection<WSProductSpecificationFieldTypes>)new HashSet<WSProductSpecificationFieldTypes>();
		WSProductSpecificationFieldTypes1 = (ICollection<WSProductSpecificationFieldTypes>)new HashSet<WSProductSpecificationFieldTypes>();
		WSProductsRate = (ICollection<WSProductsRate>)new HashSet<WSProductsRate>();
		WSProductsRate1 = (ICollection<WSProductsRate>)new HashSet<WSProductsRate>();
		WSProductsUserDiscount = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProductsUserDiscount1 = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProductsUserDiscount2 = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProductsUserDiscount3 = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProductUnits = (ICollection<WSProductUnits>)new HashSet<WSProductUnits>();
		WSProductUnits1 = (ICollection<WSProductUnits>)new HashSet<WSProductUnits>();
		WSRegisterBarCode = (ICollection<WSRegisterBarCode>)new HashSet<WSRegisterBarCode>();
		WSSaleAreas = (ICollection<WSSaleAreas>)new HashSet<WSSaleAreas>();
		WSSaleAreas1 = (ICollection<WSSaleAreas>)new HashSet<WSSaleAreas>();
		WSSaleCenters = (ICollection<WSSaleCenters>)new HashSet<WSSaleCenters>();
		WSSaleCenters1 = (ICollection<WSSaleCenters>)new HashSet<WSSaleCenters>();
		WSSaleCenters2 = (ICollection<WSSaleCenters>)new HashSet<WSSaleCenters>();
		WSSettlementType = (ICollection<WSSettlementType>)new HashSet<WSSettlementType>();
		WSSettlementType1 = (ICollection<WSSettlementType>)new HashSet<WSSettlementType>();
		WSSignature = (ICollection<WSSignature>)new HashSet<WSSignature>();
		WSSignature1 = (ICollection<WSSignature>)new HashSet<WSSignature>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupply1 = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupply2 = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupply3 = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupply4 = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSStockSupplyItems1 = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSTmpEnterBarcodeOperation = (ICollection<WSTmpEnterBarcodeOperation>)new HashSet<WSTmpEnterBarcodeOperation>();
		WSTmpEnterDocPrdWithBarcode = (ICollection<WSTmpEnterDocPrdWithBarcode>)new HashSet<WSTmpEnterDocPrdWithBarcode>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSTmpUserItemCopy1 = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		WSUserFavproductItems = (ICollection<WSUserFavproductItems>)new HashSet<WSUserFavproductItems>();
		WSUserFavproductItems1 = (ICollection<WSUserFavproductItems>)new HashSet<WSUserFavproductItems>();
		WSUserFavproducts = (ICollection<WSUserFavproducts>)new HashSet<WSUserFavproducts>();
		WSUserFavproducts1 = (ICollection<WSUserFavproducts>)new HashSet<WSUserFavproducts>();
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequestDetails1 = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequestDetails2 = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequests = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationRequests1 = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationRequests2 = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationWorkFlows = (ICollection<WSVerificationWorkFlows>)new HashSet<WSVerificationWorkFlows>();
		WSVerificationWorkFlows1 = (ICollection<WSVerificationWorkFlows>)new HashSet<WSVerificationWorkFlows>();
		WSVerificationWorkFlowSteps = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WSVerificationWorkFlowSteps1 = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WSVerificationWorkFlowSteps2 = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WSVerificationWorkFlowSteps3 = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WsWareHouse = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		WsWareHouse1 = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		WsWareHouse2 = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		WSWareHouseUserPermissions = (ICollection<WSWareHouseUserPermissions>)new HashSet<WSWareHouseUserPermissions>();
		WSWareHouseUserPermissions1 = (ICollection<WSWareHouseUserPermissions>)new HashSet<WSWareHouseUserPermissions>();
		WSWareHouseUserPermissions2 = (ICollection<WSWareHouseUserPermissions>)new HashSet<WSWareHouseUserPermissions>();
	}
}
