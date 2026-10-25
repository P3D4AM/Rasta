using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(CentersMetadata))]
public class Centers
{
	public int CenterID { get; set; }

	public string CenterName { get; set; }

	public string CenterDesc { get; set; }

	public bool? CenterInActive { get; set; }

	public int? OrderView { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public byte[] CenterPicture { get; set; }

	public int? ParentId { get; set; }

	public string CenterCode { get; set; }

	public string LinkAccCenterIdStr { get; set; }

	public string LinkAccCenterCode { get; set; }

	public DateTime? LinkAccFirstTransferDate { get; set; }

	public DateTime? LinkAccLastTransferDate { get; set; }

	public string LinkAccData { get; set; }

	public string CenterSeoTitle { get; set; }

	public string CenterSeoDescription { get; set; }

	public string CenterSeoHttpEquiv { get; set; }

	public string CenterSeoExpires { get; set; }

	public bool? CenterSeoGoogleNotranslate { get; set; }

	public string CenterSeoDistribution { get; set; }

	public string CenterSeoRobots { get; set; }

	public string CenterSeoRating { get; set; }

	public string CenterSeoAuthor { get; set; }

	public bool? CenterSeoIsUseSocialNetwork { get; set; }

	public int? CenterSeoMobileOptimized { get; set; }

	public string CenterSeoCopyright { get; set; }

	public bool? CenterSeoUseDefault { get; set; }

	public string CenterSeoKeywords { get; set; }

	public string CenterSeoFAQ { get; set; }

	public bool? CenterSeoIsActive { get; set; }

	public virtual ICollection<Centers_Lang> Centers_Lang { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSOrderItemSerials> WSOrderItemSerials { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks { get; set; }

	public virtual ICollection<WSProductSpecification> WSProductSpecification { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmLinkedCompany> CrmLinkedCompany { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmCmsHomePageSections> CrmCmsHomePageSections { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials { get; set; }

	public virtual ICollection<ScoreRules> ScoreRules { get; set; }

	public virtual ICollection<ScoreRulesSetting> ScoreRulesSetting { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual ICollection<Users> Users2 { get; set; }

	public virtual ICollection<Users> Users3 { get; set; }

	public Centers()
	{
		Centers_Lang = (ICollection<Centers_Lang>)new HashSet<Centers_Lang>();
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmLinkedUsers = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
		UsersPermission = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItemSerials = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSOrderItemSerials = (ICollection<WSOrderItemSerials>)new HashSet<WSOrderItemSerials>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSPreOrderItemSpecification = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		CrmCompanyForbiddenCity = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyForbiddenCompany = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyForbiddenGroup = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyForbiddenGroupIV = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyForbiddenProvince = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyForbiddenSubGroup = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyJustAccessCity = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyJustAccessCompany = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyJustAccessGroup = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanyJustAccessGroupIV = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompanyJustAccessProvince = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyJustAccessSubGroup = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmLinkedRolls = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedUserPositions = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmProjectsForbiddenForUser = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmUserTasks = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
		WSProductSpecification = (ICollection<WSProductSpecification>)new HashSet<WSProductSpecification>();
		WSProductSpecificationFieldGroups = (ICollection<WSProductSpecificationFieldGroups>)new HashSet<WSProductSpecificationFieldGroups>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
		CrmCompanyMoneyBag = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
		EmailSendHeader = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		SmsSendHeader = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		CrmCompanyUserForbidden = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmLinkedCompany = (ICollection<CrmLinkedCompany>)new HashSet<CrmLinkedCompany>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		UserDepartmentTicketReferUsers = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmCmsHomePageSections = (ICollection<CrmCmsHomePageSections>)new HashSet<CrmCmsHomePageSections>();
		CrmDyFormFieldMasterValueDetails = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
		WSProductShpException = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		PrintFormat = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		WsWareHouse = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		UserDepartments = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItemSerials = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
		ScoreRules = (ICollection<ScoreRules>)new HashSet<ScoreRules>();
		ScoreRulesSetting = (ICollection<ScoreRulesSetting>)new HashSet<ScoreRulesSetting>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		Users2 = (ICollection<Users>)new HashSet<Users>();
		Users3 = (ICollection<Users>)new HashSet<Users>();
	}
}
