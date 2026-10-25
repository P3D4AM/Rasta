using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CRM.General.Security;

namespace CRM.Models;

public class CRMTabelEntities : DbContext
{
	public DbSet<City> City { get; set; }

	public DbSet<City_Lang> City_Lang { get; set; }

	public DbSet<Country> Country { get; set; }

	public DbSet<Country_Lang> Country_Lang { get; set; }

	public DbSet<CrmAddressing> CrmAddressing { get; set; }

	public DbSet<CrmAddressingType> CrmAddressingType { get; set; }

	public DbSet<CrmBankingAccountType> CrmBankingAccountType { get; set; }

	public DbSet<CrmBankingBanks> CrmBankingBanks { get; set; }

	public DbSet<CrmBankingBranches> CrmBankingBranches { get; set; }

	public DbSet<CrmCallBlackList> CrmCallBlackList { get; set; }

	public DbSet<CrmCallHistory> CrmCallHistory { get; set; }

	public DbSet<CrmCallType> CrmCallType { get; set; }

	public DbSet<CrmCallType_Lang> CrmCallType_Lang { get; set; }

	public DbSet<CrmCmsComments> CrmCmsComments { get; set; }

	public DbSet<CrmCmsComments_Lang> CrmCmsComments_Lang { get; set; }

	public DbSet<CrmCmsFiles> CrmCmsFiles { get; set; }

	public DbSet<CrmCmsFiles_Lang> CrmCmsFiles_Lang { get; set; }

	public DbSet<CrmCmsFooter> CrmCmsFooter { get; set; }

	public DbSet<CrmCmsFooter_Lang> CrmCmsFooter_Lang { get; set; }

	public DbSet<CrmCmsGallery> CrmCmsGallery { get; set; }

	public DbSet<CrmCmsGallery_Lang> CrmCmsGallery_Lang { get; set; }

	public DbSet<CrmCmsGalleryItems> CrmCmsGalleryItems { get; set; }

	public DbSet<CrmCmsGalleryItems_Lang> CrmCmsGalleryItems_Lang { get; set; }

	public DbSet<CrmCmsHomePageSections> CrmCmsHomePageSections { get; set; }

	public DbSet<CrmCmsHomePageSections_Lang> CrmCmsHomePageSections_Lang { get; set; }

	public DbSet<CrmCmsLikes> CrmCmsLikes { get; set; }

	public DbSet<CrmCmsMenus> CrmCmsMenus { get; set; }

	public DbSet<CrmCmsMenus_Lang> CrmCmsMenus_Lang { get; set; }

	public DbSet<CrmCmsNews> CrmCmsNews { get; set; }

	public DbSet<CrmCmsNews_Lang> CrmCmsNews_Lang { get; set; }

	public DbSet<CrmCmsNewsGroups> CrmCmsNewsGroups { get; set; }

	public DbSet<CrmCmsNewsGroups_Lang> CrmCmsNewsGroups_Lang { get; set; }

	public DbSet<CrmCmsObjectTypes> CrmCmsObjectTypes { get; set; }

	public DbSet<CrmCmsPages> CrmCmsPages { get; set; }

	public DbSet<CrmCmsPages_Lang> CrmCmsPages_Lang { get; set; }

	public DbSet<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity { get; set; }

	public DbSet<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany { get; set; }

	public DbSet<CrmCompanyForbiddenDepartment> CrmCompanyForbiddenDepartment { get; set; }

	public DbSet<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup { get; set; }

	public DbSet<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV { get; set; }

	public DbSet<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince { get; set; }

	public DbSet<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup { get; set; }

	public DbSet<CrmCompanyGroups> CrmCompanyGroups { get; set; }

	public DbSet<CrmCompanyGroups_Lang> CrmCompanyGroups_Lang { get; set; }

	public DbSet<CrmCompanyGroupsII> CrmCompanyGroupsII { get; set; }

	public DbSet<CrmCompanyGroupsII_Lang> CrmCompanyGroupsII_Lang { get; set; }

	public DbSet<CrmCompanyGroupsIII> CrmCompanyGroupsIII { get; set; }

	public DbSet<CrmCompanyGroupsIII_Lang> CrmCompanyGroupsIII_Lang { get; set; }

	public DbSet<CrmCompanyGroupsIV> CrmCompanyGroupsIV { get; set; }

	public DbSet<CrmCompanyGroupsIV_Lang> CrmCompanyGroupsIV_Lang { get; set; }

	public DbSet<CrmCompanyGroupsMulti> CrmCompanyGroupsMulti { get; set; }

	public DbSet<CrmCompanyGroupsMulti_Lang> CrmCompanyGroupsMulti_Lang { get; set; }

	public DbSet<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity { get; set; }

	public DbSet<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany { get; set; }

	public DbSet<CrmCompanyJustAccessDepartment> CrmCompanyJustAccessDepartment { get; set; }

	public DbSet<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup { get; set; }

	public DbSet<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV { get; set; }

	public DbSet<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince { get; set; }

	public DbSet<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup { get; set; }

	public DbSet<CrmCompanyLoGo> CrmCompanyLoGo { get; set; }

	public DbSet<CrmCompanyMultiGroups> CrmCompanyMultiGroups { get; set; }

	public DbSet<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public DbSet<CrmCompanyPersons_Lang> CrmCompanyPersons_Lang { get; set; }

	public DbSet<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public DbSet<CrmCompanyPersonsTemplate_Lang> CrmCompanyPersonsTemplate_Lang { get; set; }

	public DbSet<CrmCompanyPictureAlbums> CrmCompanyPictureAlbums { get; set; }

	public DbSet<CrmCompanyPictures> CrmCompanyPictures { get; set; }

	public DbSet<CrmCompanyPresentation> CrmCompanyPresentation { get; set; }

	public DbSet<CrmCompanyPresentation_Lang> CrmCompanyPresentation_Lang { get; set; }

	public DbSet<CrmCompanySubGroups> CrmCompanySubGroups { get; set; }

	public DbSet<CrmCompanySubGroups_Lang> CrmCompanySubGroups_Lang { get; set; }

	public DbSet<CrmCompanyTitle> CrmCompanyTitle { get; set; }

	public DbSet<CrmCompanyTitle_Lang> CrmCompanyTitle_Lang { get; set; }

	public DbSet<CrmCompanyType> CrmCompanyType { get; set; }

	public DbSet<CrmCompanyType_Lang> CrmCompanyType_Lang { get; set; }

	public DbSet<CrmCompanyUserForbidden> CrmCompanyUserForbidden { get; set; }

	public DbSet<CrmConversation> CrmConversation { get; set; }

	public DbSet<CrmConversation_Lang> CrmConversation_Lang { get; set; }

	public DbSet<CrmConversationDefaultContext> CrmConversationDefaultContext { get; set; }

	public DbSet<CrmConversationDefaultContext_Lang> CrmConversationDefaultContext_Lang { get; set; }

	public DbSet<CrmConversationPriority> CrmConversationPriority { get; set; }

	public DbSet<CrmConversationPriority_Lang> CrmConversationPriority_Lang { get; set; }

	public DbSet<CrmConversationReferUsers> CrmConversationReferUsers { get; set; }

	public DbSet<CrmConversationTopics> CrmConversationTopics { get; set; }

	public DbSet<CrmConversationTopics_Lang> CrmConversationTopics_Lang { get; set; }

	public DbSet<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public DbSet<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public DbSet<CrmDyFormFieldTypes> CrmDyFormFieldTypes { get; set; }

	public DbSet<CrmDyFormFieldTypes_Lang> CrmDyFormFieldTypes_Lang { get; set; }

	public DbSet<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public DbSet<CrmDyFormFieldValues_Lang> CrmDyFormFieldValues_Lang { get; set; }

	public DbSet<CrmDyFormRegularExpressions> CrmDyFormRegularExpressions { get; set; }

	public DbSet<CrmDyFormRegularExpressions_Lang> CrmDyFormRegularExpressions_Lang { get; set; }

	public DbSet<CrmDyForms> CrmDyForms { get; set; }

	public DbSet<CrmDyForms_Lang> CrmDyForms_Lang { get; set; }

	public DbSet<CrmDyFormUserAccess> CrmDyFormUserAccess { get; set; }

	public DbSet<CrmDyFormWorkflows> CrmDyFormWorkflows { get; set; }

	public DbSet<CrmDyFormWorkflows_Lang> CrmDyFormWorkflows_Lang { get; set; }

	public DbSet<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public DbSet<CrmDyFormWorkflowSteps_Lang> CrmDyFormWorkflowSteps_Lang { get; set; }

	public DbSet<CrmFileDirectoryType> CrmFileDirectoryType { get; set; }

	public DbSet<CrmFileDirectoryType_Lang> CrmFileDirectoryType_Lang { get; set; }

	public DbSet<CrmFileDirectoryTypeOpr> CrmFileDirectoryTypeOpr { get; set; }

	public DbSet<CrmFileDirectoryTypeOpr_Lang> CrmFileDirectoryTypeOpr_Lang { get; set; }

	public DbSet<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public DbSet<CrmFilesDirectory_Lang> CrmFilesDirectory_Lang { get; set; }

	public DbSet<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate { get; set; }

	public DbSet<CrmFilesDirectoryTemplateType> CrmFilesDirectoryTemplateType { get; set; }

	public DbSet<CrmFund> CrmFund { get; set; }

	public DbSet<CrmFund_Lang> CrmFund_Lang { get; set; }

	public DbSet<CrmFundGroups> CrmFundGroups { get; set; }

	public DbSet<CrmFundGroups_Lang> CrmFundGroups_Lang { get; set; }

	public DbSet<CrmImportFromExcelFields> CrmImportFromExcelFields { get; set; }

	public DbSet<CrmImportFromExcelFields_Lang> CrmImportFromExcelFields_Lang { get; set; }

	public DbSet<CrmInternalMessage> CrmInternalMessage { get; set; }

	public DbSet<CrmInternalMessage_Lang> CrmInternalMessage_Lang { get; set; }

	public DbSet<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext { get; set; }

	public DbSet<CrmInternalMessageDefaultContext_Lang> CrmInternalMessageDefaultContext_Lang { get; set; }

	public DbSet<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public DbSet<CrmInternalMessageGroup> CrmInternalMessageGroup { get; set; }

	public DbSet<CrmInternalMessageGroup_Lang> CrmInternalMessageGroup_Lang { get; set; }

	public DbSet<CrmInternalMessagePriority> CrmInternalMessagePriority { get; set; }

	public DbSet<CrmInternalMessagePriority_Lang> CrmInternalMessagePriority_Lang { get; set; }

	public DbSet<CrmInternalMessageSelectReceiver> CrmInternalMessageSelectReceiver { get; set; }

	public DbSet<CrmInternalMessageTreeType> CrmInternalMessageTreeType { get; set; }

	public DbSet<CrmInternalMessageTreeType_Lang> CrmInternalMessageTreeType_Lang { get; set; }

	public DbSet<CrmInternalMessageType> CrmInternalMessageType { get; set; }

	public DbSet<CrmInternalMessageType_Lang> CrmInternalMessageType_Lang { get; set; }

	public DbSet<CrmKnowledgeTank> CrmKnowledgeTank { get; set; }

	public DbSet<CrmKnowledgeTank_Lang> CrmKnowledgeTank_Lang { get; set; }

	public DbSet<CrmKnowledgeTankGroup> CrmKnowledgeTankGroup { get; set; }

	public DbSet<CrmKnowledgeTankGroup_Lang> CrmKnowledgeTankGroup_Lang { get; set; }

	public DbSet<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission { get; set; }

	public DbSet<CrmKnowledgeTankPriority> CrmKnowledgeTankPriority { get; set; }

	public DbSet<CrmKnowledgeTankPriority_Lang> CrmKnowledgeTankPriority_Lang { get; set; }

	public DbSet<CrmLeave> CrmLeave { get; set; }

	public DbSet<CrmLeaveKinds> CrmLeaveKinds { get; set; }

	public DbSet<CrmLeaveStatus> CrmLeaveStatus { get; set; }

	public DbSet<CrmLeaveStayType> CrmLeaveStayType { get; set; }

	public DbSet<CrmLeaveType> CrmLeaveType { get; set; }

	public DbSet<CrmLeaveVehicleType> CrmLeaveVehicleType { get; set; }

	public DbSet<CrmLinkAccErrorLogs> CrmLinkAccErrorLogs { get; set; }

	public DbSet<CrmLinkAccHolooSetting> CrmLinkAccHolooSetting { get; set; }

	public DbSet<CrmLinkAccHolooSetting_Lang> CrmLinkAccHolooSetting_Lang { get; set; }

	public DbSet<CrmLinkAccHolooSettingDetails> CrmLinkAccHolooSettingDetails { get; set; }

	public DbSet<CrmLinkAccHolooSettingDetails_Lang> CrmLinkAccHolooSettingDetails_Lang { get; set; }

	public DbSet<CrmLinkAccKyanSetting> CrmLinkAccKyanSetting { get; set; }

	public DbSet<CrmLinkAccKyanSetting_Lang> CrmLinkAccKyanSetting_Lang { get; set; }

	public DbSet<CrmLinkAccNoAvSetting> CrmLinkAccNoAvSetting { get; set; }

	public DbSet<CrmLinkAccNoAvSetting_Lang> CrmLinkAccNoAvSetting_Lang { get; set; }

	public DbSet<CrmLinkAccNoAvSettingDetails> CrmLinkAccNoAvSettingDetails { get; set; }

	public DbSet<CrmLinkAccNoAvSettingDetails_Lang> CrmLinkAccNoAvSettingDetails_Lang { get; set; }

	public DbSet<CrmLinkAccPayvastSetting> CrmLinkAccPayvastSetting { get; set; }

	public DbSet<CrmLinkAccPayvastSetting_Lang> CrmLinkAccPayvastSetting_Lang { get; set; }

	public DbSet<CrmLinkAccSetting> CrmLinkAccSetting { get; set; }

	public DbSet<CrmLinkAccSetting_Lang> CrmLinkAccSetting_Lang { get; set; }

	public DbSet<CrmLinkAccSettingDetails> CrmLinkAccSettingDetails { get; set; }

	public DbSet<CrmLinkAccSettingDetails_Lang> CrmLinkAccSettingDetails_Lang { get; set; }

	public DbSet<CrmLinkAccShygunSetting> CrmLinkAccShygunSetting { get; set; }

	public DbSet<CrmLinkAccShygunSetting_Lang> CrmLinkAccShygunSetting_Lang { get; set; }

	public DbSet<CrmLinkAccSystems> CrmLinkAccSystems { get; set; }

	public DbSet<CrmLinkAccTarazSetting> CrmLinkAccTarazSetting { get; set; }

	public DbSet<CrmLinkAccTarazSetting_Lang> CrmLinkAccTarazSetting_Lang { get; set; }

	public DbSet<CrmLinkAccTarazSettingDetails> CrmLinkAccTarazSettingDetails { get; set; }

	public DbSet<CrmLinkAccTarazSettingDetails_Lang> CrmLinkAccTarazSettingDetails_Lang { get; set; }

	public DbSet<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public DbSet<CrmLinkedType> CrmLinkedType { get; set; }

	public DbSet<CrmLinkedType_Lang> CrmLinkedType_Lang { get; set; }

	public DbSet<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public DbSet<CrmLinkedUsers> CrmLinkedUsers { get; set; }

	public DbSet<CrmNumRefSetting> CrmNumRefSetting { get; set; }

	public DbSet<CrmOperationsType> CrmOperationsType { get; set; }

	public DbSet<CrmOperationsType_Lang> CrmOperationsType_Lang { get; set; }

	public DbSet<CrmPersonDepartments> CrmPersonDepartments { get; set; }

	public DbSet<CrmPersonDepartments_Lang> CrmPersonDepartments_Lang { get; set; }

	public DbSet<CrmPersonGroups> CrmPersonGroups { get; set; }

	public DbSet<CrmPersonGroups_Lang> CrmPersonGroups_Lang { get; set; }

	public DbSet<CrmPersonJobs> CrmPersonJobs { get; set; }

	public DbSet<CrmPersonJobs_Lang> CrmPersonJobs_Lang { get; set; }

	public DbSet<CrmPersonPicture> CrmPersonPicture { get; set; }

	public DbSet<CrmPersonTitle> CrmPersonTitle { get; set; }

	public DbSet<CrmPersonTitle_Lang> CrmPersonTitle_Lang { get; set; }

	public DbSet<CrmPersonType> CrmPersonType { get; set; }

	public DbSet<CrmPersonType_Lang> CrmPersonType_Lang { get; set; }

	public DbSet<CrmProjectCategory> CrmProjectCategory { get; set; }

	public DbSet<CrmProjectCategory_Lang> CrmProjectCategory_Lang { get; set; }

	public DbSet<CrmProjectDefualtValue> CrmProjectDefualtValue { get; set; }

	public DbSet<CrmProjectDefualtValue_Lang> CrmProjectDefualtValue_Lang { get; set; }

	public DbSet<CrmProjectFieldTitle> CrmProjectFieldTitle { get; set; }

	public DbSet<CrmProjectFieldTitle_Lang> CrmProjectFieldTitle_Lang { get; set; }

	public DbSet<CrmProjectFieldValueType> CrmProjectFieldValueType { get; set; }

	public DbSet<CrmProjectGrade> CrmProjectGrade { get; set; }

	public DbSet<CrmProjectGrade_Lang> CrmProjectGrade_Lang { get; set; }

	public DbSet<CrmProjectGroups> CrmProjectGroups { get; set; }

	public DbSet<CrmProjectGroups_Lang> CrmProjectGroups_Lang { get; set; }

	public DbSet<CrmProjectGroupsMulti> CrmProjectGroupsMulti { get; set; }

	public DbSet<CrmProjectGroupsMulti_Lang> CrmProjectGroupsMulti_Lang { get; set; }

	public DbSet<CrmProjectGroupsMultiI> CrmProjectGroupsMultiI { get; set; }

	public DbSet<CrmProjectGroupsMultiI_Lang> CrmProjectGroupsMultiI_Lang { get; set; }

	public DbSet<CrmProjectInformations> CrmProjectInformations { get; set; }

	public DbSet<CrmProjectInformations_Lang> CrmProjectInformations_Lang { get; set; }

	public DbSet<CrmProjectMultiGroups> CrmProjectMultiGroups { get; set; }

	public DbSet<CrmProjectMultiIGroups> CrmProjectMultiIGroups { get; set; }

	public DbSet<CrmProjectPriority> CrmProjectPriority { get; set; }

	public DbSet<CrmProjectPriority_Lang> CrmProjectPriority_Lang { get; set; }

	public DbSet<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser { get; set; }

	public DbSet<CrmProjectsForbiddenForUser_Lang> CrmProjectsForbiddenForUser_Lang { get; set; }

	public DbSet<CrmShowTableFieldInFO> CrmShowTableFieldInFO { get; set; }

	public DbSet<CrmSurvey> CrmSurvey { get; set; }

	public DbSet<CrmSurvey_Lang> CrmSurvey_Lang { get; set; }

	public DbSet<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory { get; set; }

	public DbSet<CrmSurveyAnswerCategory_Lang> CrmSurveyAnswerCategory_Lang { get; set; }

	public DbSet<CrmSurveyAnswerCategoryDetails> CrmSurveyAnswerCategoryDetails { get; set; }

	public DbSet<CrmSurveyAnswerCategoryDetails_Lang> CrmSurveyAnswerCategoryDetails_Lang { get; set; }

	public DbSet<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public DbSet<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public DbSet<CrmSurveyAnswers_Lang> CrmSurveyAnswers_Lang { get; set; }

	public DbSet<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public DbSet<CrmSurveyAnswerValue_Lang> CrmSurveyAnswerValue_Lang { get; set; }

	public DbSet<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public DbSet<CrmSurveyQuestions> CrmSurveyQuestions { get; set; }

	public DbSet<CrmSurveyQuestions_Lang> CrmSurveyQuestions_Lang { get; set; }

	public DbSet<CrmSurveySendSetting> CrmSurveySendSetting { get; set; }

	public DbSet<CrmSurveySendSetting_Lang> CrmSurveySendSetting_Lang { get; set; }

	public DbSet<CrmsysCIDeviceType> CrmsysCIDeviceType { get; set; }

	public DbSet<CrmsysCIPopUpSetting> CrmsysCIPopUpSetting { get; set; }

	public DbSet<CrmsysCISetting> CrmsysCISetting { get; set; }

	public DbSet<CrmsysDBObjects> CrmsysDBObjects { get; set; }

	public DbSet<CrmsysDBObjects_Lang> CrmsysDBObjects_Lang { get; set; }

	public DbSet<CrmsysDBTempInfo> CrmsysDBTempInfo { get; set; }

	public DbSet<CrmsysDBTempInfoType> CrmsysDBTempInfoType { get; set; }

	public DbSet<CrmsysFormActions> CrmsysFormActions { get; set; }

	public DbSet<CrmsysFormActions_Lang> CrmsysFormActions_Lang { get; set; }

	public DbSet<CrmsysFormObjectProperties> CrmsysFormObjectProperties { get; set; }

	public DbSet<CrmsysFormObjectProperties_Lang> CrmsysFormObjectProperties_Lang { get; set; }

	public DbSet<CrmsysForms> CrmsysForms { get; set; }

	public DbSet<CrmsysForms_Lang> CrmsysForms_Lang { get; set; }

	public DbSet<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public DbSet<CrmsysRolls> CrmsysRolls { get; set; }

	public DbSet<CrmsysRolls_Lang> CrmsysRolls_Lang { get; set; }

	public DbSet<CrmSystemParts> CrmSystemParts { get; set; }

	public DbSet<CrmSystemParts_Lang> CrmSystemParts_Lang { get; set; }

	public DbSet<CrmTelegBotChatMessage> CrmTelegBotChatMessage { get; set; }

	public DbSet<CrmTelegBotContacts> CrmTelegBotContacts { get; set; }

	public DbSet<CrmTelegBotMessageType> CrmTelegBotMessageType { get; set; }

	public DbSet<CrmTelegBotSetting> CrmTelegBotSetting { get; set; }

	public DbSet<CrmTelegChatMessage> CrmTelegChatMessage { get; set; }

	public DbSet<CrmTelegContacts> CrmTelegContacts { get; set; }

	public DbSet<CrmTelegMessageType> CrmTelegMessageType { get; set; }

	public DbSet<CrmTempEmails> CrmTempEmails { get; set; }

	public DbSet<CrmTimeAttendanceBase> CrmTimeAttendanceBase { get; set; }

	public DbSet<CrmTimeAttendanceLog> CrmTimeAttendanceLog { get; set; }

	public DbSet<CRMtmpManageTellNumber> CRMtmpManageTellNumber { get; set; }

	public DbSet<CrmUserNotes> CrmUserNotes { get; set; }

	public DbSet<CrmUserTaskGroups> CrmUserTaskGroups { get; set; }

	public DbSet<CrmUserTaskGroups_Lang> CrmUserTaskGroups_Lang { get; set; }

	public DbSet<CrmUserTaskPriorities> CrmUserTaskPriorities { get; set; }

	public DbSet<CrmUserTaskPriorities_Lang> CrmUserTaskPriorities_Lang { get; set; }

	public DbSet<CrmVersions> CrmVersions { get; set; }

	public DbSet<CrmVersionUpgrade> CrmVersionUpgrade { get; set; }

	public DbSet<CrmVersionUpgradeDetails> CrmVersionUpgradeDetails { get; set; }

	public DbSet<CrmWebSetting> CrmWebSetting { get; set; }

	public DbSet<Education> Education { get; set; }

	public DbSet<Education_Lang> Education_Lang { get; set; }

	public DbSet<EmailDefaultBodyText> EmailDefaultBodyText { get; set; }

	public DbSet<EmailDefaultBodyText_Lang> EmailDefaultBodyText_Lang { get; set; }

	public DbSet<EmailReceive> EmailReceive { get; set; }

	public DbSet<EmailReceiveAttachments> EmailReceiveAttachments { get; set; }

	public DbSet<EmailReceiveFolders> EmailReceiveFolders { get; set; }

	public DbSet<EmailSendAttachment> EmailSendAttachment { get; set; }

	public DbSet<EmailSendDetail> EmailSendDetail { get; set; }

	public DbSet<EmailSendHeader> EmailSendHeader { get; set; }

	public DbSet<EmailSetting> EmailSetting { get; set; }

	public DbSet<EmailUserDefaultSetting> EmailUserDefaultSetting { get; set; }

	public DbSet<EmailUserTempTank> EmailUserTempTank { get; set; }

	public DbSet<Languages> Languages { get; set; }

	public DbSet<PayRollItemTypes> PayRollItemTypes { get; set; }

	public DbSet<PayRollItemTypes_Lang> PayRollItemTypes_Lang { get; set; }

	public DbSet<PayRollUserCycle> PayRollUserCycle { get; set; }

	public DbSet<PayRollUserCycle_Lang> PayRollUserCycle_Lang { get; set; }

	public DbSet<PayRollUserCycleItemValues> PayRollUserCycleItemValues { get; set; }

	public DbSet<PayRollUserDefaultItems> PayRollUserDefaultItems { get; set; }

	public DbSet<PayRollUserPayments> PayRollUserPayments { get; set; }

	public DbSet<PayRollUserPayments_Lang> PayRollUserPayments_Lang { get; set; }

	public DbSet<PayRollUserPaymentTypes> PayRollUserPaymentTypes { get; set; }

	public DbSet<PayRollUserPaymentTypes_Lang> PayRollUserPaymentTypes_Lang { get; set; }

	public DbSet<PrintFormat> PrintFormat { get; set; }

	public DbSet<PrintFormat_Lang> PrintFormat_Lang { get; set; }

	public DbSet<PrintFormatType> PrintFormatType { get; set; }

	public DbSet<PrintFormatType_Lang> PrintFormatType_Lang { get; set; }

	public DbSet<Projects> Projects { get; set; }

	public DbSet<Projects_Lang> Projects_Lang { get; set; }

	public DbSet<Province> Province { get; set; }

	public DbSet<Province_Lang> Province_Lang { get; set; }

	public DbSet<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public DbSet<SecLetterDefaultSettings_Lang> SecLetterDefaultSettings_Lang { get; set; }

	public DbSet<SecLetters> SecLetters { get; set; }

	public DbSet<SecLetters_Lang> SecLetters_Lang { get; set; }

	public DbSet<SecLetterType> SecLetterType { get; set; }

	public DbSet<SecLetterType_Lang> SecLetterType_Lang { get; set; }

	public DbSet<Sex> Sex { get; set; }

	public DbSet<Sex_Lang> Sex_Lang { get; set; }

	public DbSet<SmsDefaultBodyText> SmsDefaultBodyText { get; set; }

	public DbSet<SmsDefaultBodyText_Lang> SmsDefaultBodyText_Lang { get; set; }

	public DbSet<SmsDefaultBodyTextGroups> SmsDefaultBodyTextGroups { get; set; }

	public DbSet<SmsDefaultBodyTextGroups_Lang> SmsDefaultBodyTextGroups_Lang { get; set; }

	public DbSet<SmsDeliveryStatus> SmsDeliveryStatus { get; set; }

	public DbSet<SmsDeliveryStatus_Lang> SmsDeliveryStatus_Lang { get; set; }

	public DbSet<SmsGSMModemDelivery> SmsGSMModemDelivery { get; set; }

	public DbSet<SmsGSMModemSetting> SmsGSMModemSetting { get; set; }

	public DbSet<SmsGSMReceives> SmsGSMReceives { get; set; }

	public DbSet<SmsGSMSendingTank> SmsGSMSendingTank { get; set; }

	public DbSet<SmsProviders> SmsProviders { get; set; }

	public DbSet<SmsReceive> SmsReceive { get; set; }

	public DbSet<SmsReceiveFromWSDL> SmsReceiveFromWSDL { get; set; }

	public DbSet<SmsSendHeader> SmsSendHeader { get; set; }

	public DbSet<SmsSendType> SmsSendType { get; set; }

	public DbSet<SmsSendType_Lang> SmsSendType_Lang { get; set; }

	public DbSet<SmsSetting> SmsSetting { get; set; }

	public DbSet<SmsTempMobileNumbers> SmsTempMobileNumbers { get; set; }

	public DbSet<SmsUserSendCredit> SmsUserSendCredit { get; set; }

	public DbSet<SmsUserSendCredit_Lang> SmsUserSendCredit_Lang { get; set; }

	public DbSet<UserDepartments> UserDepartments { get; set; }

	public DbSet<UserDepartments_Lang> UserDepartments_Lang { get; set; }

	public DbSet<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers { get; set; }

	public DbSet<UserGroups> UserGroups { get; set; }

	public DbSet<UserGroups_Lang> UserGroups_Lang { get; set; }

	public DbSet<UserLanguages> UserLanguages { get; set; }

	public DbSet<UserLoginAllowedTimes> UserLoginAllowedTimes { get; set; }

	public DbSet<UserPictures> UserPictures { get; set; }

	public DbSet<UserPositions> UserPositions { get; set; }

	public DbSet<UserPositions_Lang> UserPositions_Lang { get; set; }

	public DbSet<UserSignature> UserSignature { get; set; }

	public DbSet<UsersPermission> UsersPermission { get; set; }

	public DbSet<UsersPermission_Lang> UsersPermission_Lang { get; set; }

	public DbSet<WSBuyOrder> WSBuyOrder { get; set; }

	public DbSet<WSBuyOrder_Lang> WSBuyOrder_Lang { get; set; }

	public DbSet<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public DbSet<WSBuyOrderItems_Lang> WSBuyOrderItems_Lang { get; set; }

	public DbSet<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public DbSet<WSBuyOrderItemSerials_Lang> WSBuyOrderItemSerials_Lang { get; set; }

	public DbSet<WSBuyOrderOpr> WSBuyOrderOpr { get; set; }

	public DbSet<WSBuyOrderOpr_Lang> WSBuyOrderOpr_Lang { get; set; }

	public DbSet<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public DbSet<WSBuyOrderPayments_Lang> WSBuyOrderPayments_Lang { get; set; }

	public DbSet<WSBuyOrderPaymentTypes> WSBuyOrderPaymentTypes { get; set; }

	public DbSet<WSBuyOrderPaymentTypes_Lang> WSBuyOrderPaymentTypes_Lang { get; set; }

	public DbSet<WSBuyOrderStatus> WSBuyOrderStatus { get; set; }

	public DbSet<WSBuyOrderStatus_Lang> WSBuyOrderStatus_Lang { get; set; }

	public DbSet<WSCostSheetDyFieldGroups> WSCostSheetDyFieldGroups { get; set; }

	public DbSet<WSCostSheetDyFieldGroups_Lang> WSCostSheetDyFieldGroups_Lang { get; set; }

	public DbSet<WSCostSheetDyFieldTitle> WSCostSheetDyFieldTitle { get; set; }

	public DbSet<WSCostSheetDyFieldTitle_Lang> WSCostSheetDyFieldTitle_Lang { get; set; }

	public DbSet<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public DbSet<WSCostSheetItems> WSCostSheetItems { get; set; }

	public DbSet<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public DbSet<WSCostSheetProducts_Lang> WSCostSheetProducts_Lang { get; set; }

	public DbSet<WSCostSheets> WSCostSheets { get; set; }

	public DbSet<WSCostSheets_Lang> WSCostSheets_Lang { get; set; }

	public DbSet<WSCreditDuration> WSCreditDuration { get; set; }

	public DbSet<WSCreditDuration_Lang> WSCreditDuration_Lang { get; set; }

	public DbSet<WSCurrencyUnitRate> WSCurrencyUnitRate { get; set; }

	public DbSet<WSCurrencyUnits> WSCurrencyUnits { get; set; }

	public DbSet<WSCurrencyUnits_Lang> WSCurrencyUnits_Lang { get; set; }

	public DbSet<WSDeliverySchedule_Lang> WSDeliverySchedule_Lang { get; set; }

	public DbSet<WSDeliveryScheduleExcept> WSDeliveryScheduleExcept { get; set; }

	public DbSet<WSDeliveryScheduleExcept_Lang> WSDeliveryScheduleExcept_Lang { get; set; }

	public DbSet<WSDeliveryTime> WSDeliveryTime { get; set; }

	public DbSet<WSDeliveryTime_Lang> WSDeliveryTime_Lang { get; set; }

	public DbSet<WSDiscountCode> WSDiscountCode { get; set; }

	public DbSet<WSDiscountCode_Lang> WSDiscountCode_Lang { get; set; }

	public DbSet<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public DbSet<WSDocOpr> WSDocOpr { get; set; }

	public DbSet<WSDocOpr_Lang> WSDocOpr_Lang { get; set; }

	public DbSet<WSFinancialPeriod> WSFinancialPeriod { get; set; }

	public DbSet<WSGuaranty> WSGuaranty { get; set; }

	public DbSet<WSGuaranty_Lang> WSGuaranty_Lang { get; set; }

	public DbSet<WSLinkedProducts> WSLinkedProducts { get; set; }

	public DbSet<WSLogo> WSLogo { get; set; }

	public DbSet<WSLogo_Lang> WSLogo_Lang { get; set; }

	public DbSet<WSOrderCommissionPayTypes> WSOrderCommissionPayTypes { get; set; }

	public DbSet<WSOrderCommissionPayTypes_Lang> WSOrderCommissionPayTypes_Lang { get; set; }

	public DbSet<WSOrderDefaultSetting_Lang> WSOrderDefaultSetting_Lang { get; set; }

	public DbSet<WSOrderImportFromExcel> WSOrderImportFromExcel { get; set; }

	public DbSet<WSOrderImportFromExcelFields> WSOrderImportFromExcelFields { get; set; }

	public DbSet<WSOrderImportFromExcelFields_Lang> WSOrderImportFromExcelFields_Lang { get; set; }

	public DbSet<WSOrderItemSerials> WSOrderItemSerials { get; set; }

	public DbSet<WSOrderItemSerials_Lang> WSOrderItemSerials_Lang { get; set; }

	public DbSet<WSOrderOpr> WSOrderOpr { get; set; }

	public DbSet<WSOrderOpr_Lang> WSOrderOpr_Lang { get; set; }

	public DbSet<WSOrderPaymentTypes_Lang> WSOrderPaymentTypes_Lang { get; set; }

	public DbSet<WSOrderStatus> WSOrderStatus { get; set; }

	public DbSet<WSOrderStatus_Lang> WSOrderStatus_Lang { get; set; }

	public DbSet<WSPayCondition> WSPayCondition { get; set; }

	public DbSet<WSPayCondition_Lang> WSPayCondition_Lang { get; set; }

	public DbSet<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public DbSet<WSPreOrderCommissions_Lang> WSPreOrderCommissions_Lang { get; set; }

	public DbSet<WSPreOrderDefaultSetting_Lang> WSPreOrderDefaultSetting_Lang { get; set; }

	public DbSet<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public DbSet<WSPreOrderItemSpecification_Lang> WSPreOrderItemSpecification_Lang { get; set; }

	public DbSet<WSPreOrderOpr> WSPreOrderOpr { get; set; }

	public DbSet<WSPreOrderOpr_Lang> WSPreOrderOpr_Lang { get; set; }

	public DbSet<WSPreOrderPrdGroupMustExistReasonGroups> WSPreOrderPrdGroupMustExistReasonGroups { get; set; }

	public DbSet<WSPreOrderPrdGroupMustExistReasonGroups_Lang> WSPreOrderPrdGroupMustExistReasonGroups_Lang { get; set; }

	public DbSet<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public DbSet<WSPreOrderPrdGroupMustExistReasons_Lang> WSPreOrderPrdGroupMustExistReasons_Lang { get; set; }

	public DbSet<WSPreOrderStatus> WSPreOrderStatus { get; set; }

	public DbSet<WSPreOrderStatus_Lang> WSPreOrderStatus_Lang { get; set; }

	public DbSet<WSPreOrderTypes> WSPreOrderTypes { get; set; }

	public DbSet<WSPreOrderTypes_Lang> WSPreOrderTypes_Lang { get; set; }

	public DbSet<WSProductColor> WSProductColor { get; set; }

	public DbSet<WSProductColor_Lang> WSProductColor_Lang { get; set; }

	public DbSet<WSProductCost> WSProductCost { get; set; }

	public DbSet<WSProductCost_Lang> WSProductCost_Lang { get; set; }

	public DbSet<WSProductCostGroup> WSProductCostGroup { get; set; }

	public DbSet<WSProductCostGroup_Lang> WSProductCostGroup_Lang { get; set; }

	public DbSet<WSProductFirstGroup> WSProductFirstGroup { get; set; }

	public DbSet<WSProductFirstGroup_Lang> WSProductFirstGroup_Lang { get; set; }

	public DbSet<WSProductGallery> WSProductGallery { get; set; }

	public DbSet<WSProductGroupPicture> WSProductGroupPicture { get; set; }

	public DbSet<WSProductImportFromExcelFields> WSProductImportFromExcelFields { get; set; }

	public DbSet<WSProductImportFromExcelFields_Lang> WSProductImportFromExcelFields_Lang { get; set; }

	public DbSet<WSProductPicture> WSProductPicture { get; set; }

	public DbSet<WSProductPicture_Lang> WSProductPicture_Lang { get; set; }

	public DbSet<WSProductPrice> WSProductPrice { get; set; }

	public DbSet<WSProductPrice_Lang> WSProductPrice_Lang { get; set; }

	public DbSet<WSProductPriceGroup> WSProductPriceGroup { get; set; }

	public DbSet<WSProductPriceGroup_Lang> WSProductPriceGroup_Lang { get; set; }

	public DbSet<WSProductRelationLimit> WSProductRelationLimit { get; set; }

	public DbSet<WSProductRelationType> WSProductRelationType { get; set; }

	public DbSet<WSProductRelationType_Lang> WSProductRelationType_Lang { get; set; }

	public DbSet<WSProductSecondGroup> WSProductSecondGroup { get; set; }

	public DbSet<WSProductSecondGroup_Lang> WSProductSecondGroup_Lang { get; set; }

	public DbSet<WSProductShpStockManageTypes> WSProductShpStockManageTypes { get; set; }

	public DbSet<WSProductShpStockManageTypes_Lang> WSProductShpStockManageTypes_Lang { get; set; }

	public DbSet<WSProductSpecification> WSProductSpecification { get; set; }

	public DbSet<WSProductSpecification_Lang> WSProductSpecification_Lang { get; set; }

	public DbSet<WSProductsRate> WSProductsRate { get; set; }

	public DbSet<WSProductsUserDiscount> WSProductsUserDiscount { get; set; }

	public DbSet<WSProductsUserDiscount_Lang> WSProductsUserDiscount_Lang { get; set; }

	public DbSet<WSProductUnits> WSProductUnits { get; set; }

	public DbSet<WSProductUnits_Lang> WSProductUnits_Lang { get; set; }

	public DbSet<WSRegisterBarCode> WSRegisterBarCode { get; set; }

	public DbSet<WSSaleCenters> WSSaleCenters { get; set; }

	public DbSet<WSSaleCenters_Lang> WSSaleCenters_Lang { get; set; }

	public DbSet<WSSettlementType> WSSettlementType { get; set; }

	public DbSet<WSSettlementType_Lang> WSSettlementType_Lang { get; set; }

	public DbSet<WSSignature> WSSignature { get; set; }

	public DbSet<WSTmpEnterBarcodeOperation> WSTmpEnterBarcodeOperation { get; set; }

	public DbSet<WSTmpEnterDocPrdWithBarcode> WSTmpEnterDocPrdWithBarcode { get; set; }

	public DbSet<WSUserFavproductItems> WSUserFavproductItems { get; set; }

	public DbSet<WSUserFavproductItems_Lang> WSUserFavproductItems_Lang { get; set; }

	public DbSet<WSUserFavproducts> WSUserFavproducts { get; set; }

	public DbSet<WSUserFavproducts_Lang> WSUserFavproducts_Lang { get; set; }

	public DbSet<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public DbSet<WSVerificationRequestDetails_Lang> WSVerificationRequestDetails_Lang { get; set; }

	public DbSet<WSVerificationRequests> WSVerificationRequests { get; set; }

	public DbSet<WSVerificationRequests_Lang> WSVerificationRequests_Lang { get; set; }

	public DbSet<WSVerificationWorkFlows> WSVerificationWorkFlows { get; set; }

	public DbSet<WSVerificationWorkFlows_Lang> WSVerificationWorkFlows_Lang { get; set; }

	public DbSet<WsWareHouse> WsWareHouse { get; set; }

	public DbSet<WsWareHouse_Lang> WsWareHouse_Lang { get; set; }

	public DbSet<WSWareHouseUserPermissions> WSWareHouseUserPermissions { get; set; }

	public DbSet<CrmLinkAccShygunSettingDetails> CrmLinkAccShygunSettingDetails { get; set; }

	public DbSet<CrmLinkAccShygunSettingDetails_Lang> CrmLinkAccShygunSettingDetails_Lang { get; set; }

	public DbSet<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public DbSet<CrmCompanyAddresses_Lang> CrmCompanyAddresses_Lang { get; set; }

	public DbSet<CrmLinkAccPayvastSettingDetails> CrmLinkAccPayvastSettingDetails { get; set; }

	public DbSet<CrmLinkAccPayvastSettingDetails_Lang> CrmLinkAccPayvastSettingDetails_Lang { get; set; }

	public DbSet<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo { get; set; }

	public DbSet<CrmOnlinePayBankInfo_Lang> CrmOnlinePayBankInfo_Lang { get; set; }

	public DbSet<EmailUsersInfo> EmailUsersInfo { get; set; }

	public DbSet<CrmLinkAccNoAvIISetting> CrmLinkAccNoAvIISetting { get; set; }

	public DbSet<CrmLinkAccNoAvIISetting_Lang> CrmLinkAccNoAvIISetting_Lang { get; set; }

	public DbSet<CrmLinkAccShygunIISetting> CrmLinkAccShygunIISetting { get; set; }

	public DbSet<CrmLinkAccShygunIISetting_Lang> CrmLinkAccShygunIISetting_Lang { get; set; }

	public DbSet<CrmLinkAccShygunIISettingDetails> CrmLinkAccShygunIISettingDetails { get; set; }

	public DbSet<CrmLinkAccShygunIISettingDetails_Lang> CrmLinkAccShygunIISettingDetails_Lang { get; set; }

	public DbSet<CrmLinkAccChamberCommerceSetting> CrmLinkAccChamberCommerceSetting { get; set; }

	public DbSet<CrmLinkAccChamberCommerceSetting_Lang> CrmLinkAccChamberCommerceSetting_Lang { get; set; }

	public DbSet<CrmMenuModel> CrmMenuModel { get; set; }

	public DbSet<CrmMenuModel_Lang> CrmMenuModel_Lang { get; set; }

	public DbSet<SecLetterNumberCounter> SecLetterNumberCounter { get; set; }

	public DbSet<SecLetterNumberCounter_Lang> SecLetterNumberCounter_Lang { get; set; }

	public DbSet<CrmProjects_Lang> CrmProjects_Lang { get; set; }

	public DbSet<CrmLinkedCompany> CrmLinkedCompany { get; set; }

	public DbSet<CrmCompanyCampaign> CrmCompanyCampaign { get; set; }

	public DbSet<CrmCompanyCampaign_Lang> CrmCompanyCampaign_Lang { get; set; }

	public DbSet<CrmProjectTitleGroups> CrmProjectTitleGroups { get; set; }

	public DbSet<CrmProjectTitleGroups_Lang> CrmProjectTitleGroups_Lang { get; set; }

	public DbSet<CrmDyFormFields> CrmDyFormFields { get; set; }

	public DbSet<CrmDyFormFields_Lang> CrmDyFormFields_Lang { get; set; }

	public DbSet<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public DbSet<CrmCompanyMoneyBag_Lang> CrmCompanyMoneyBag_Lang { get; set; }

	public DbSet<WSOrderPayments> WSOrderPayments { get; set; }

	public DbSet<WSOrderPayments_Lang> WSOrderPayments_Lang { get; set; }

	public DbSet<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public DbSet<WSPreOrderPayments_Lang> WSPreOrderPayments_Lang { get; set; }

	public DbSet<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public DbSet<CrmConversationStatusResultEventPolicy_Lang> CrmConversationStatusResultEventPolicy_Lang { get; set; }

	public DbSet<CrmConversationStatusGroups> CrmConversationStatusGroups { get; set; }

	public DbSet<CrmConversationStatusGroups_Lang> CrmConversationStatusGroups_Lang { get; set; }

	public DbSet<CrmCompanyAddressType> CrmCompanyAddressType { get; set; }

	public DbSet<CrmCompanyAddressType_Lang> CrmCompanyAddressType_Lang { get; set; }

	public DbSet<CrmBankingAccountType_Lang> CrmBankingAccountType_Lang { get; set; }

	public DbSet<CrmBankingBanks_Lang> CrmBankingBanks_Lang { get; set; }

	public DbSet<CrmBankingBranches_Lang> CrmBankingBranches_Lang { get; set; }

	public DbSet<PayRollList> PayRollList { get; set; }

	public DbSet<PayRollList_Lang> PayRollList_Lang { get; set; }

	public DbSet<PayRollListGroups> PayRollListGroups { get; set; }

	public DbSet<PayRollListGroups_Lang> PayRollListGroups_Lang { get; set; }

	public DbSet<PayRollListItems> PayRollListItems { get; set; }

	public DbSet<CrmLeaveKinds_Lang> CrmLeaveKinds_Lang { get; set; }

	public DbSet<CrmLeaveStayType_Lang> CrmLeaveStayType_Lang { get; set; }

	public DbSet<CrmLeaveVehicleType_Lang> CrmLeaveVehicleType_Lang { get; set; }

	public DbSet<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public DbSet<CrmBankingAccounts_Lang> CrmBankingAccounts_Lang { get; set; }

	public DbSet<WSPreOrder> WSPreOrder { get; set; }

	public DbSet<TspSetting> TspSetting { get; set; }

	public DbSet<TspSetting_Lang> TspSetting_Lang { get; set; }

	public DbSet<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public DbSet<WSDeliverySchedule> WSDeliverySchedule { get; set; }

	public DbSet<CrmLinkAccShomaranSetting> CrmLinkAccShomaranSetting { get; set; }

	public DbSet<CrmLinkAccShomaranSetting_Lang> CrmLinkAccShomaranSetting_Lang { get; set; }

	public DbSet<CrmCompanyQuickRegisterDefSetting_Lang> CrmCompanyQuickRegisterDefSetting_Lang { get; set; }

	public DbSet<WSOrderItems> WSOrderItems { get; set; }

	public DbSet<WSOrderItems_Lang> WSOrderItems_Lang { get; set; }

	public DbSet<WSPreOrderItems> WSPreOrderItems { get; set; }

	public DbSet<WSPreOrderItems_Lang> WSPreOrderItems_Lang { get; set; }

	public DbSet<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public DbSet<CrmProjectTitles> CrmProjectTitles { get; set; }

	public DbSet<CrmProjectTitles_Lang> CrmProjectTitles_Lang { get; set; }

	public DbSet<CrmsysSetting> CrmsysSetting { get; set; }

	public DbSet<CrmsysSetting_Lang> CrmsysSetting_Lang { get; set; }

	public DbSet<CrmLinkAccArpaSetting> CrmLinkAccArpaSetting { get; set; }

	public DbSet<CrmLinkAccArpaSetting_Lang> CrmLinkAccArpaSetting_Lang { get; set; }

	public DbSet<CrmCompany> CrmCompany { get; set; }

	public DbSet<CrmCompany_Lang> CrmCompany_Lang { get; set; }

	public DbSet<WSDeliveryTerms> WSDeliveryTerms { get; set; }

	public DbSet<WSDeliveryTerms_Lang> WSDeliveryTerms_Lang { get; set; }

	public DbSet<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public DbSet<WSBuyOrderDefaultSetting_Lang> WSBuyOrderDefaultSetting_Lang { get; set; }

	public DbSet<WSStockSupply> WSStockSupply { get; set; }

	public DbSet<WSStockSupply_Lang> WSStockSupply_Lang { get; set; }

	public DbSet<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public DbSet<WSStockSupplyItems_Lang> WSStockSupplyItems_Lang { get; set; }

	public DbSet<CrmConversationStatusSalesFunnelSteps> CrmConversationStatusSalesFunnelSteps { get; set; }

	public DbSet<CrmConversationStatusSalesFunnelSteps_Lang> CrmConversationStatusSalesFunnelSteps_Lang { get; set; }

	public DbSet<UserMoneyBag> UserMoneyBag { get; set; }

	public DbSet<UserMoneyBag_Lang> UserMoneyBag_Lang { get; set; }

	public DbSet<WSDiscountStrategy> WSDiscountStrategy { get; set; }

	public DbSet<WSDiscountStrategy_Lang> WSDiscountStrategy_Lang { get; set; }

	public DbSet<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public DbSet<WSOrderDiscounts_Lang> WSOrderDiscounts_Lang { get; set; }

	public DbSet<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public DbSet<WSPreOrderDiscounts_Lang> WSPreOrderDiscounts_Lang { get; set; }

	public DbSet<CrmUserTasks> CrmUserTasks { get; set; }

	public DbSet<CrmUserTasks_Lang> CrmUserTasks_Lang { get; set; }

	public DbSet<CrmTelegSetting> CrmTelegSetting { get; set; }

	public DbSet<WSOrderCommissions> WSOrderCommissions { get; set; }

	public DbSet<WSOrderCommissions_Lang> WSOrderCommissions_Lang { get; set; }

	public DbSet<CrmCmsWidgetGroups> CrmCmsWidgetGroups { get; set; }

	public DbSet<CrmCmsWidgetGroups_Lang> CrmCmsWidgetGroups_Lang { get; set; }

	public DbSet<CrmCmsWidgets> CrmCmsWidgets { get; set; }

	public DbSet<CrmCmsWidgets_Lang> CrmCmsWidgets_Lang { get; set; }

	public DbSet<CrmLinkAccByViewSetting> CrmLinkAccByViewSetting { get; set; }

	public DbSet<CrmLinkAccByViewSetting_Lang> CrmLinkAccByViewSetting_Lang { get; set; }

	public DbSet<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps { get; set; }

	public DbSet<WSVerificationWorkFlowSteps_Lang> WSVerificationWorkFlowSteps_Lang { get; set; }

	public DbSet<WSOrder> WSOrder { get; set; }

	public DbSet<WSOrder_Lang> WSOrder_Lang { get; set; }

	public DbSet<CrmLinkAccHamrahanSetting> CrmLinkAccHamrahanSetting { get; set; }

	public DbSet<CrmLinkAccHamrahanSetting_Lang> CrmLinkAccHamrahanSetting_Lang { get; set; }

	public DbSet<CrmFoSetting> CrmFoSetting { get; set; }

	public DbSet<CrmFoSetting_Lang> CrmFoSetting_Lang { get; set; }

	public DbSet<PayRollItems> PayRollItems { get; set; }

	public DbSet<PayRollItems_Lang> PayRollItems_Lang { get; set; }

	public DbSet<CrmLinkAccHamrahanSettingDetails> CrmLinkAccHamrahanSettingDetails { get; set; }

	public DbSet<CrmLinkAccHamrahanSettingDetails_Lang> CrmLinkAccHamrahanSettingDetails_Lang { get; set; }

	public DbSet<CrmMobSetting> CrmMobSetting { get; set; }

	public DbSet<WSOrderGroups> WSOrderGroups { get; set; }

	public DbSet<WSOrderGroups_Lang> WSOrderGroups_Lang { get; set; }

	public DbSet<CrmUserReportFilter> CrmUserReportFilter { get; set; }

	public DbSet<CrmUserReportFilter_Lang> CrmUserReportFilter_Lang { get; set; }

	public DbSet<Centers> Centers { get; set; }

	public DbSet<Centers_Lang> Centers_Lang { get; set; }

	public DbSet<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups { get; set; }

	public DbSet<WSProductSpecificationFieldGroups_Lang> WSProductSpecificationFieldGroups_Lang { get; set; }

	public DbSet<WSProductSpecificationFieldTypes> WSProductSpecificationFieldTypes { get; set; }

	public DbSet<WSProductSpecificationFieldTypes_Lang> WSProductSpecificationFieldTypes_Lang { get; set; }

	public DbSet<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public DbSet<WSProductSpecificationFields_Lang> WSProductSpecificationFields_Lang { get; set; }

	public DbSet<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems { get; set; }

	public DbSet<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public DbSet<CrmFoSettingRegister_Lang> CrmFoSettingRegister_Lang { get; set; }

	public DbSet<WSProductShpException> WSProductShpException { get; set; }

	public DbSet<WSProductShpException_Lang> WSProductShpException_Lang { get; set; }

	public DbSet<WSSaleAreas> WSSaleAreas { get; set; }

	public DbSet<WSSaleAreas_Lang> WSSaleAreas_Lang { get; set; }

	public DbSet<WSPreOrder_Lang> WSPreOrder_Lang { get; set; }

	public DbSet<CrmConversationStatusResult> CrmConversationStatusResult { get; set; }

	public DbSet<CrmConversationStatusResult_Lang> CrmConversationStatusResult_Lang { get; set; }

	public DbSet<CrmCashes> CrmCashes { get; set; }

	public DbSet<CrmCashes_Lang> CrmCashes_Lang { get; set; }

	public DbSet<WSOrderPaymentGroupsI> WSOrderPaymentGroupsI { get; set; }

	public DbSet<WSOrderPaymentGroupsI_Lang> WSOrderPaymentGroupsI_Lang { get; set; }

	public DbSet<WSOrderPaymentGroupsII> WSOrderPaymentGroupsII { get; set; }

	public DbSet<WSOrderPaymentGroupsII_Lang> WSOrderPaymentGroupsII_Lang { get; set; }

	public DbSet<SmsSendDetail> SmsSendDetail { get; set; }

	public DbSet<WSProducts_Lang> WSProducts_Lang { get; set; }

	public DbSet<WSProducts> WSProducts { get; set; }

	public DbSet<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public DbSet<CrmConversationStatus> CrmConversationStatus { get; set; }

	public DbSet<CrmConversationStatus_Lang> CrmConversationStatus_Lang { get; set; }

	public DbSet<CrmTimeAttendance> CrmTimeAttendance { get; set; }

	public DbSet<CrmImportFromExcel> CrmImportFromExcel { get; set; }

	public DbSet<WSDoc> WSDoc { get; set; }

	public DbSet<WSDoc_Lang> WSDoc_Lang { get; set; }

	public DbSet<WSDocItems> WSDocItems { get; set; }

	public DbSet<WSDocItems_Lang> WSDocItems_Lang { get; set; }

	public DbSet<WSDocItemSerials> WSDocItemSerials { get; set; }

	public DbSet<WSDocItemSerials_Lang> WSDocItemSerials_Lang { get; set; }

	public DbSet<ScoreRules> ScoreRules { get; set; }

	public DbSet<ScoreRules_Lang> ScoreRules_Lang { get; set; }

	public DbSet<ScoreRulesSetting> ScoreRulesSetting { get; set; }

	public DbSet<Scores> Scores { get; set; }

	public DbSet<Scores_Lang> Scores_Lang { get; set; }

	public DbSet<CrmProjects> CrmProjects { get; set; }

	public DbSet<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public DbSet<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public DbSet<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public DbSet<Users> Users { get; set; }

	public DbSet<Users_Lang> Users_Lang { get; set; }

	public CRMTabelEntities()
		: base("name=CRMTabelEntities")
	{
		string connectionString = base.Database.Connection.ConnectionString;
		connectionString = connectionString.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		connectionString = connectionString.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		connectionString = connectionString.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		connectionString = connectionString.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		base.Database.Connection.ConnectionString = connectionString;
		((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 180;
	}

	protected override void OnModelCreating(DbModelBuilder modelBuilder)
	{
		throw new UnintentionalCodeFirstException();
	}
}
