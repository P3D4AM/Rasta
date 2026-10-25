using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(LanguagesMetadata))]
public class Languages
{
	public int LanguageID { get; set; }

	public string LanguageName { get; set; }

	public string LanguageCollation { get; set; }

	public string LanguageDirection { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public bool? IsActive { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public int? OrderView { get; set; }

	public string WeekendDayNums { get; set; }

	public virtual ICollection<City> City { get; set; }

	public virtual ICollection<City_Lang> City_Lang { get; set; }

	public virtual ICollection<Country> Country { get; set; }

	public virtual ICollection<Country_Lang> Country_Lang { get; set; }

	public virtual ICollection<CrmAddressing> CrmAddressing { get; set; }

	public virtual ICollection<CrmAddressingType> CrmAddressingType { get; set; }

	public virtual ICollection<CrmBankingAccountType> CrmBankingAccountType { get; set; }

	public virtual ICollection<CrmBankingBanks> CrmBankingBanks { get; set; }

	public virtual ICollection<CrmBankingBranches> CrmBankingBranches { get; set; }

	public virtual ICollection<CrmCallBlackList> CrmCallBlackList { get; set; }

	public virtual ICollection<CrmCallHistory> CrmCallHistory { get; set; }

	public virtual ICollection<CrmCallType> CrmCallType { get; set; }

	public virtual ICollection<CrmCallType_Lang> CrmCallType_Lang { get; set; }

	public virtual ICollection<CrmCmsComments> CrmCmsComments { get; set; }

	public virtual ICollection<CrmCmsComments_Lang> CrmCmsComments_Lang { get; set; }

	public virtual ICollection<CrmCmsFiles> CrmCmsFiles { get; set; }

	public virtual ICollection<CrmCmsFiles_Lang> CrmCmsFiles_Lang { get; set; }

	public virtual ICollection<CrmCmsFooter> CrmCmsFooter { get; set; }

	public virtual ICollection<CrmCmsFooter_Lang> CrmCmsFooter_Lang { get; set; }

	public virtual ICollection<CrmCmsGallery> CrmCmsGallery { get; set; }

	public virtual ICollection<CrmCmsGallery_Lang> CrmCmsGallery_Lang { get; set; }

	public virtual ICollection<CrmCmsGalleryItems> CrmCmsGalleryItems { get; set; }

	public virtual ICollection<CrmCmsGalleryItems_Lang> CrmCmsGalleryItems_Lang { get; set; }

	public virtual ICollection<CrmCmsHomePageSections> CrmCmsHomePageSections { get; set; }

	public virtual ICollection<CrmCmsHomePageSections_Lang> CrmCmsHomePageSections_Lang { get; set; }

	public virtual ICollection<CrmCmsLikes> CrmCmsLikes { get; set; }

	public virtual ICollection<CrmCmsMenus> CrmCmsMenus { get; set; }

	public virtual ICollection<CrmCmsMenus_Lang> CrmCmsMenus_Lang { get; set; }

	public virtual ICollection<CrmCmsNews> CrmCmsNews { get; set; }

	public virtual ICollection<CrmCmsNews_Lang> CrmCmsNews_Lang { get; set; }

	public virtual ICollection<CrmCmsNewsGroups> CrmCmsNewsGroups { get; set; }

	public virtual ICollection<CrmCmsNewsGroups_Lang> CrmCmsNewsGroups_Lang { get; set; }

	public virtual ICollection<CrmCmsObjectTypes> CrmCmsObjectTypes { get; set; }

	public virtual ICollection<CrmCmsPages> CrmCmsPages { get; set; }

	public virtual ICollection<CrmCmsPages_Lang> CrmCmsPages_Lang { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCity> CrmCompanyForbiddenCity { get; set; }

	public virtual ICollection<CrmCompanyForbiddenCompany> CrmCompanyForbiddenCompany { get; set; }

	public virtual ICollection<CrmCompanyForbiddenDepartment> CrmCompanyForbiddenDepartment { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroup> CrmCompanyForbiddenGroup { get; set; }

	public virtual ICollection<CrmCompanyForbiddenGroupIV> CrmCompanyForbiddenGroupIV { get; set; }

	public virtual ICollection<CrmCompanyForbiddenProvince> CrmCompanyForbiddenProvince { get; set; }

	public virtual ICollection<CrmCompanyForbiddenSubGroup> CrmCompanyForbiddenSubGroup { get; set; }

	public virtual ICollection<CrmCompanyGroups> CrmCompanyGroups { get; set; }

	public virtual ICollection<CrmCompanyGroups_Lang> CrmCompanyGroups_Lang { get; set; }

	public virtual ICollection<CrmCompanyGroupsII> CrmCompanyGroupsII { get; set; }

	public virtual ICollection<CrmCompanyGroupsII_Lang> CrmCompanyGroupsII_Lang { get; set; }

	public virtual ICollection<CrmCompanyGroupsIII> CrmCompanyGroupsIII { get; set; }

	public virtual ICollection<CrmCompanyGroupsIII_Lang> CrmCompanyGroupsIII_Lang { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV> CrmCompanyGroupsIV { get; set; }

	public virtual ICollection<CrmCompanyGroupsIV_Lang> CrmCompanyGroupsIV_Lang { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti> CrmCompanyGroupsMulti { get; set; }

	public virtual ICollection<CrmCompanyGroupsMulti_Lang> CrmCompanyGroupsMulti_Lang { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCity> CrmCompanyJustAccessCity { get; set; }

	public virtual ICollection<CrmCompanyJustAccessCompany> CrmCompanyJustAccessCompany { get; set; }

	public virtual ICollection<CrmCompanyJustAccessDepartment> CrmCompanyJustAccessDepartment { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroup> CrmCompanyJustAccessGroup { get; set; }

	public virtual ICollection<CrmCompanyJustAccessGroupIV> CrmCompanyJustAccessGroupIV { get; set; }

	public virtual ICollection<CrmCompanyJustAccessProvince> CrmCompanyJustAccessProvince { get; set; }

	public virtual ICollection<CrmCompanyJustAccessSubGroup> CrmCompanyJustAccessSubGroup { get; set; }

	public virtual ICollection<CrmCompanyLoGo> CrmCompanyLoGo { get; set; }

	public virtual ICollection<CrmCompanyMultiGroups> CrmCompanyMultiGroups { get; set; }

	public virtual ICollection<CrmCompanyPersons> CrmCompanyPersons { get; set; }

	public virtual ICollection<CrmCompanyPersons_Lang> CrmCompanyPersons_Lang { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate> CrmCompanyPersonsTemplate { get; set; }

	public virtual ICollection<CrmCompanyPersonsTemplate_Lang> CrmCompanyPersonsTemplate_Lang { get; set; }

	public virtual ICollection<CrmCompanyPictureAlbums> CrmCompanyPictureAlbums { get; set; }

	public virtual ICollection<CrmCompanyPictures> CrmCompanyPictures { get; set; }

	public virtual ICollection<CrmCompanyPresentation> CrmCompanyPresentation { get; set; }

	public virtual ICollection<CrmCompanyPresentation_Lang> CrmCompanyPresentation_Lang { get; set; }

	public virtual ICollection<CrmCompanySubGroups> CrmCompanySubGroups { get; set; }

	public virtual ICollection<CrmCompanySubGroups_Lang> CrmCompanySubGroups_Lang { get; set; }

	public virtual ICollection<CrmCompanyTitle> CrmCompanyTitle { get; set; }

	public virtual ICollection<CrmCompanyTitle_Lang> CrmCompanyTitle_Lang { get; set; }

	public virtual ICollection<CrmCompanyType> CrmCompanyType { get; set; }

	public virtual ICollection<CrmCompanyType_Lang> CrmCompanyType_Lang { get; set; }

	public virtual ICollection<CrmCompanyUserForbidden> CrmCompanyUserForbidden { get; set; }

	public virtual ICollection<CrmConversation> CrmConversation { get; set; }

	public virtual ICollection<CrmConversation_Lang> CrmConversation_Lang { get; set; }

	public virtual ICollection<CrmConversationDefaultContext> CrmConversationDefaultContext { get; set; }

	public virtual ICollection<CrmConversationDefaultContext_Lang> CrmConversationDefaultContext_Lang { get; set; }

	public virtual ICollection<CrmConversationPriority> CrmConversationPriority { get; set; }

	public virtual ICollection<CrmConversationPriority_Lang> CrmConversationPriority_Lang { get; set; }

	public virtual ICollection<CrmConversationReferUsers> CrmConversationReferUsers { get; set; }

	public virtual ICollection<CrmConversationTopics> CrmConversationTopics { get; set; }

	public virtual ICollection<CrmConversationTopics_Lang> CrmConversationTopics_Lang { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValueDetails> CrmDyFormFieldMasterValueDetails { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<CrmDyFormFieldTypes> CrmDyFormFieldTypes { get; set; }

	public virtual ICollection<CrmDyFormFieldTypes_Lang> CrmDyFormFieldTypes_Lang { get; set; }

	public virtual ICollection<CrmDyFormFieldValues> CrmDyFormFieldValues { get; set; }

	public virtual ICollection<CrmDyFormFieldValues_Lang> CrmDyFormFieldValues_Lang { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions> CrmDyFormRegularExpressions { get; set; }

	public virtual ICollection<CrmDyFormRegularExpressions_Lang> CrmDyFormRegularExpressions_Lang { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual ICollection<CrmDyForms_Lang> CrmDyForms_Lang { get; set; }

	public virtual ICollection<CrmDyFormUserAccess> CrmDyFormUserAccess { get; set; }

	public virtual ICollection<CrmDyFormWorkflows> CrmDyFormWorkflows { get; set; }

	public virtual ICollection<CrmDyFormWorkflows_Lang> CrmDyFormWorkflows_Lang { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps> CrmDyFormWorkflowSteps { get; set; }

	public virtual ICollection<CrmDyFormWorkflowSteps_Lang> CrmDyFormWorkflowSteps_Lang { get; set; }

	public virtual ICollection<CrmFileDirectoryType> CrmFileDirectoryType { get; set; }

	public virtual ICollection<CrmFileDirectoryType_Lang> CrmFileDirectoryType_Lang { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr> CrmFileDirectoryTypeOpr { get; set; }

	public virtual ICollection<CrmFileDirectoryTypeOpr_Lang> CrmFileDirectoryTypeOpr_Lang { get; set; }

	public virtual ICollection<CrmFilesDirectory> CrmFilesDirectory { get; set; }

	public virtual ICollection<CrmFilesDirectory_Lang> CrmFilesDirectory_Lang { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplate> CrmFilesDirectoryTemplate { get; set; }

	public virtual ICollection<CrmFilesDirectoryTemplateType> CrmFilesDirectoryTemplateType { get; set; }

	public virtual ICollection<CrmFund> CrmFund { get; set; }

	public virtual ICollection<CrmFund_Lang> CrmFund_Lang { get; set; }

	public virtual ICollection<CrmFundGroups> CrmFundGroups { get; set; }

	public virtual ICollection<CrmFundGroups_Lang> CrmFundGroups_Lang { get; set; }

	public virtual ICollection<CrmImportFromExcelFields_Lang> CrmImportFromExcelFields_Lang { get; set; }

	public virtual ICollection<CrmInternalMessage> CrmInternalMessage { get; set; }

	public virtual ICollection<CrmInternalMessage_Lang> CrmInternalMessage_Lang { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext> CrmInternalMessageDefaultContext { get; set; }

	public virtual ICollection<CrmInternalMessageDefaultContext_Lang> CrmInternalMessageDefaultContext_Lang { get; set; }

	public virtual ICollection<CrmInternalMessageDetails> CrmInternalMessageDetails { get; set; }

	public virtual ICollection<CrmInternalMessageGroup> CrmInternalMessageGroup { get; set; }

	public virtual ICollection<CrmInternalMessageGroup_Lang> CrmInternalMessageGroup_Lang { get; set; }

	public virtual ICollection<CrmInternalMessagePriority> CrmInternalMessagePriority { get; set; }

	public virtual ICollection<CrmInternalMessagePriority_Lang> CrmInternalMessagePriority_Lang { get; set; }

	public virtual ICollection<CrmInternalMessageSelectReceiver> CrmInternalMessageSelectReceiver { get; set; }

	public virtual ICollection<CrmInternalMessageTreeType> CrmInternalMessageTreeType { get; set; }

	public virtual ICollection<CrmInternalMessageTreeType_Lang> CrmInternalMessageTreeType_Lang { get; set; }

	public virtual ICollection<CrmInternalMessageType> CrmInternalMessageType { get; set; }

	public virtual ICollection<CrmInternalMessageType_Lang> CrmInternalMessageType_Lang { get; set; }

	public virtual ICollection<CrmKnowledgeTank> CrmKnowledgeTank { get; set; }

	public virtual ICollection<CrmKnowledgeTank_Lang> CrmKnowledgeTank_Lang { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup> CrmKnowledgeTankGroup { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroup_Lang> CrmKnowledgeTankGroup_Lang { get; set; }

	public virtual ICollection<CrmKnowledgeTankGroupPermission> CrmKnowledgeTankGroupPermission { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority> CrmKnowledgeTankPriority { get; set; }

	public virtual ICollection<CrmKnowledgeTankPriority_Lang> CrmKnowledgeTankPriority_Lang { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmLeaveKinds> CrmLeaveKinds { get; set; }

	public virtual ICollection<CrmLeaveStatus> CrmLeaveStatus { get; set; }

	public virtual ICollection<CrmLeaveStayType> CrmLeaveStayType { get; set; }

	public virtual ICollection<CrmLeaveType> CrmLeaveType { get; set; }

	public virtual ICollection<CrmLeaveVehicleType> CrmLeaveVehicleType { get; set; }

	public virtual ICollection<CrmLinkAccHolooSetting> CrmLinkAccHolooSetting { get; set; }

	public virtual ICollection<CrmLinkAccHolooSetting_Lang> CrmLinkAccHolooSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccHolooSettingDetails> CrmLinkAccHolooSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccHolooSettingDetails_Lang> CrmLinkAccHolooSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmLinkAccKyanSetting> CrmLinkAccKyanSetting { get; set; }

	public virtual ICollection<CrmLinkAccKyanSetting_Lang> CrmLinkAccKyanSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSetting> CrmLinkAccNoAvSetting { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSetting_Lang> CrmLinkAccNoAvSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSettingDetails> CrmLinkAccNoAvSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccNoAvSettingDetails_Lang> CrmLinkAccNoAvSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSetting> CrmLinkAccPayvastSetting { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSetting_Lang> CrmLinkAccPayvastSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccSetting> CrmLinkAccSetting { get; set; }

	public virtual ICollection<CrmLinkAccSetting_Lang> CrmLinkAccSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails> CrmLinkAccSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccSettingDetails_Lang> CrmLinkAccSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmLinkAccShygunSetting> CrmLinkAccShygunSetting { get; set; }

	public virtual ICollection<CrmLinkAccShygunSetting_Lang> CrmLinkAccShygunSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccSystems> CrmLinkAccSystems { get; set; }

	public virtual ICollection<CrmLinkAccTarazSetting> CrmLinkAccTarazSetting { get; set; }

	public virtual ICollection<CrmLinkAccTarazSetting_Lang> CrmLinkAccTarazSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccTarazSettingDetails> CrmLinkAccTarazSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccTarazSettingDetails_Lang> CrmLinkAccTarazSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmLinkedRolls> CrmLinkedRolls { get; set; }

	public virtual ICollection<CrmLinkedType> CrmLinkedType { get; set; }

	public virtual ICollection<CrmLinkedType_Lang> CrmLinkedType_Lang { get; set; }

	public virtual ICollection<CrmLinkedUserPositions> CrmLinkedUserPositions { get; set; }

	public virtual ICollection<CrmLinkedUsers> CrmLinkedUsers { get; set; }

	public virtual ICollection<CrmNumRefSetting> CrmNumRefSetting { get; set; }

	public virtual ICollection<CrmOperationsType> CrmOperationsType { get; set; }

	public virtual ICollection<CrmOperationsType_Lang> CrmOperationsType_Lang { get; set; }

	public virtual ICollection<CrmPersonDepartments> CrmPersonDepartments { get; set; }

	public virtual ICollection<CrmPersonDepartments_Lang> CrmPersonDepartments_Lang { get; set; }

	public virtual ICollection<CrmPersonGroups> CrmPersonGroups { get; set; }

	public virtual ICollection<CrmPersonGroups_Lang> CrmPersonGroups_Lang { get; set; }

	public virtual ICollection<CrmPersonJobs> CrmPersonJobs { get; set; }

	public virtual ICollection<CrmPersonJobs_Lang> CrmPersonJobs_Lang { get; set; }

	public virtual ICollection<CrmPersonPicture> CrmPersonPicture { get; set; }

	public virtual ICollection<CrmPersonTitle> CrmPersonTitle { get; set; }

	public virtual ICollection<CrmPersonTitle_Lang> CrmPersonTitle_Lang { get; set; }

	public virtual ICollection<CrmPersonType> CrmPersonType { get; set; }

	public virtual ICollection<CrmPersonType_Lang> CrmPersonType_Lang { get; set; }

	public virtual ICollection<CrmProjectCategory> CrmProjectCategory { get; set; }

	public virtual ICollection<CrmProjectCategory_Lang> CrmProjectCategory_Lang { get; set; }

	public virtual ICollection<CrmProjectDefualtValue> CrmProjectDefualtValue { get; set; }

	public virtual ICollection<CrmProjectDefualtValue_Lang> CrmProjectDefualtValue_Lang { get; set; }

	public virtual ICollection<CrmProjectFieldTitle> CrmProjectFieldTitle { get; set; }

	public virtual ICollection<CrmProjectFieldTitle_Lang> CrmProjectFieldTitle_Lang { get; set; }

	public virtual ICollection<CrmProjectFieldValueType> CrmProjectFieldValueType { get; set; }

	public virtual ICollection<CrmProjectGrade> CrmProjectGrade { get; set; }

	public virtual ICollection<CrmProjectGrade_Lang> CrmProjectGrade_Lang { get; set; }

	public virtual ICollection<CrmProjectGroups> CrmProjectGroups { get; set; }

	public virtual ICollection<CrmProjectGroups_Lang> CrmProjectGroups_Lang { get; set; }

	public virtual ICollection<CrmProjectGroupsMulti> CrmProjectGroupsMulti { get; set; }

	public virtual ICollection<CrmProjectGroupsMulti_Lang> CrmProjectGroupsMulti_Lang { get; set; }

	public virtual ICollection<CrmProjectGroupsMultiI> CrmProjectGroupsMultiI { get; set; }

	public virtual ICollection<CrmProjectGroupsMultiI_Lang> CrmProjectGroupsMultiI_Lang { get; set; }

	public virtual ICollection<CrmProjectInformations> CrmProjectInformations { get; set; }

	public virtual ICollection<CrmProjectInformations_Lang> CrmProjectInformations_Lang { get; set; }

	public virtual ICollection<CrmProjectMultiGroups> CrmProjectMultiGroups { get; set; }

	public virtual ICollection<CrmProjectMultiIGroups> CrmProjectMultiIGroups { get; set; }

	public virtual ICollection<CrmProjectPriority> CrmProjectPriority { get; set; }

	public virtual ICollection<CrmProjectPriority_Lang> CrmProjectPriority_Lang { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser> CrmProjectsForbiddenForUser { get; set; }

	public virtual ICollection<CrmProjectsForbiddenForUser_Lang> CrmProjectsForbiddenForUser_Lang { get; set; }

	public virtual ICollection<CrmShowTableFieldInFO> CrmShowTableFieldInFO { get; set; }

	public virtual ICollection<CrmSurvey> CrmSurvey { get; set; }

	public virtual ICollection<CrmSurvey_Lang> CrmSurvey_Lang { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory> CrmSurveyAnswerCategory { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategory_Lang> CrmSurveyAnswerCategory_Lang { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails> CrmSurveyAnswerCategoryDetails { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetails_Lang> CrmSurveyAnswerCategoryDetails_Lang { get; set; }

	public virtual ICollection<CrmSurveyAnswerCategoryDetailValues> CrmSurveyAnswerCategoryDetailValues { get; set; }

	public virtual ICollection<CrmSurveyAnswers> CrmSurveyAnswers { get; set; }

	public virtual ICollection<CrmSurveyAnswers_Lang> CrmSurveyAnswers_Lang { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue> CrmSurveyAnswerValue { get; set; }

	public virtual ICollection<CrmSurveyAnswerValue_Lang> CrmSurveyAnswerValue_Lang { get; set; }

	public virtual ICollection<CrmSurveyHistory> CrmSurveyHistory { get; set; }

	public virtual ICollection<CrmSurveyQuestions> CrmSurveyQuestions { get; set; }

	public virtual ICollection<CrmSurveyQuestions_Lang> CrmSurveyQuestions_Lang { get; set; }

	public virtual ICollection<CrmSurveySendSetting> CrmSurveySendSetting { get; set; }

	public virtual ICollection<CrmSurveySendSetting_Lang> CrmSurveySendSetting_Lang { get; set; }

	public virtual ICollection<CrmsysCIDeviceType> CrmsysCIDeviceType { get; set; }

	public virtual ICollection<CrmsysCIPopUpSetting> CrmsysCIPopUpSetting { get; set; }

	public virtual ICollection<CrmsysCISetting> CrmsysCISetting { get; set; }

	public virtual ICollection<CrmsysDBObjects> CrmsysDBObjects { get; set; }

	public virtual ICollection<CrmsysDBObjects_Lang> CrmsysDBObjects_Lang { get; set; }

	public virtual ICollection<CrmsysDBTempInfo> CrmsysDBTempInfo { get; set; }

	public virtual ICollection<CrmsysDBTempInfoType> CrmsysDBTempInfoType { get; set; }

	public virtual ICollection<CrmsysFormActions> CrmsysFormActions { get; set; }

	public virtual ICollection<CrmsysFormActions_Lang> CrmsysFormActions_Lang { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties> CrmsysFormObjectProperties { get; set; }

	public virtual ICollection<CrmsysFormObjectProperties_Lang> CrmsysFormObjectProperties_Lang { get; set; }

	public virtual ICollection<CrmsysForms> CrmsysForms { get; set; }

	public virtual ICollection<CrmsysForms_Lang> CrmsysForms_Lang { get; set; }

	public virtual ICollection<CrmsysRollPermission> CrmsysRollPermission { get; set; }

	public virtual ICollection<CrmsysRolls> CrmsysRolls { get; set; }

	public virtual ICollection<CrmsysRolls_Lang> CrmsysRolls_Lang { get; set; }

	public virtual ICollection<CrmSystemParts> CrmSystemParts { get; set; }

	public virtual ICollection<CrmSystemParts_Lang> CrmSystemParts_Lang { get; set; }

	public virtual ICollection<CrmTelegBotChatMessage> CrmTelegBotChatMessage { get; set; }

	public virtual ICollection<CrmTelegBotContacts> CrmTelegBotContacts { get; set; }

	public virtual ICollection<CrmTelegBotMessageType> CrmTelegBotMessageType { get; set; }

	public virtual ICollection<CrmTelegBotSetting> CrmTelegBotSetting { get; set; }

	public virtual ICollection<CrmTelegChatMessage> CrmTelegChatMessage { get; set; }

	public virtual ICollection<CrmTelegContacts> CrmTelegContacts { get; set; }

	public virtual ICollection<CrmTelegMessageType> CrmTelegMessageType { get; set; }

	public virtual ICollection<CrmTempEmails> CrmTempEmails { get; set; }

	public virtual ICollection<CrmTimeAttendanceBase> CrmTimeAttendanceBase { get; set; }

	public virtual ICollection<CrmTimeAttendanceLog> CrmTimeAttendanceLog { get; set; }

	public virtual ICollection<CRMtmpManageTellNumber> CRMtmpManageTellNumber { get; set; }

	public virtual ICollection<CrmUserNotes> CrmUserNotes { get; set; }

	public virtual ICollection<CrmUserTaskGroups> CrmUserTaskGroups { get; set; }

	public virtual ICollection<CrmUserTaskGroups_Lang> CrmUserTaskGroups_Lang { get; set; }

	public virtual ICollection<CrmUserTaskPriorities> CrmUserTaskPriorities { get; set; }

	public virtual ICollection<CrmUserTaskPriorities_Lang> CrmUserTaskPriorities_Lang { get; set; }

	public virtual ICollection<CrmVersions> CrmVersions { get; set; }

	public virtual ICollection<CrmVersionUpgrade> CrmVersionUpgrade { get; set; }

	public virtual ICollection<CrmVersionUpgradeDetails> CrmVersionUpgradeDetails { get; set; }

	public virtual ICollection<CrmWebSetting> CrmWebSetting { get; set; }

	public virtual ICollection<Education> Education { get; set; }

	public virtual ICollection<Education_Lang> Education_Lang { get; set; }

	public virtual ICollection<EmailDefaultBodyText> EmailDefaultBodyText { get; set; }

	public virtual ICollection<EmailDefaultBodyText_Lang> EmailDefaultBodyText_Lang { get; set; }

	public virtual ICollection<EmailReceive> EmailReceive { get; set; }

	public virtual ICollection<EmailReceiveAttachments> EmailReceiveAttachments { get; set; }

	public virtual ICollection<EmailReceiveFolders> EmailReceiveFolders { get; set; }

	public virtual ICollection<EmailSendAttachment> EmailSendAttachment { get; set; }

	public virtual ICollection<EmailSendDetail> EmailSendDetail { get; set; }

	public virtual ICollection<EmailSendHeader> EmailSendHeader { get; set; }

	public virtual ICollection<EmailSetting> EmailSetting { get; set; }

	public virtual ICollection<EmailUserDefaultSetting> EmailUserDefaultSetting { get; set; }

	public virtual ICollection<EmailUserTempTank> EmailUserTempTank { get; set; }

	public virtual Languages Languages1 { get; set; }

	public virtual Languages Languages2 { get; set; }

	public virtual ICollection<PayRollItemTypes_Lang> PayRollItemTypes_Lang { get; set; }

	public virtual ICollection<PayRollItemTypes> PayRollItemTypes { get; set; }

	public virtual ICollection<PayRollUserCycle_Lang> PayRollUserCycle_Lang { get; set; }

	public virtual ICollection<PayRollUserCycle> PayRollUserCycle { get; set; }

	public virtual ICollection<PayRollUserCycleItemValues> PayRollUserCycleItemValues { get; set; }

	public virtual ICollection<PayRollUserDefaultItems> PayRollUserDefaultItems { get; set; }

	public virtual ICollection<PayRollUserPayments_Lang> PayRollUserPayments_Lang { get; set; }

	public virtual ICollection<PayRollUserPayments> PayRollUserPayments { get; set; }

	public virtual ICollection<PayRollUserPaymentTypes_Lang> PayRollUserPaymentTypes_Lang { get; set; }

	public virtual ICollection<PayRollUserPaymentTypes> PayRollUserPaymentTypes { get; set; }

	public virtual ICollection<PrintFormat_Lang> PrintFormat_Lang { get; set; }

	public virtual ICollection<PrintFormat> PrintFormat { get; set; }

	public virtual ICollection<PrintFormatType_Lang> PrintFormatType_Lang { get; set; }

	public virtual ICollection<PrintFormatType> PrintFormatType { get; set; }

	public virtual ICollection<Projects_Lang> Projects_Lang { get; set; }

	public virtual ICollection<Projects> Projects { get; set; }

	public virtual ICollection<Province_Lang> Province_Lang { get; set; }

	public virtual ICollection<Province> Province { get; set; }

	public virtual ICollection<SecLetterDefaultSettings_Lang> SecLetterDefaultSettings_Lang { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetters_Lang> SecLetters_Lang { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<SecLetterType_Lang> SecLetterType_Lang { get; set; }

	public virtual ICollection<SecLetterType> SecLetterType { get; set; }

	public virtual ICollection<Sex_Lang> Sex_Lang { get; set; }

	public virtual ICollection<Sex> Sex { get; set; }

	public virtual ICollection<SmsDefaultBodyText_Lang> SmsDefaultBodyText_Lang { get; set; }

	public virtual ICollection<SmsDefaultBodyText> SmsDefaultBodyText { get; set; }

	public virtual ICollection<SmsDefaultBodyTextGroups_Lang> SmsDefaultBodyTextGroups_Lang { get; set; }

	public virtual ICollection<SmsDefaultBodyTextGroups> SmsDefaultBodyTextGroups { get; set; }

	public virtual ICollection<SmsDeliveryStatus_Lang> SmsDeliveryStatus_Lang { get; set; }

	public virtual ICollection<SmsDeliveryStatus> SmsDeliveryStatus { get; set; }

	public virtual ICollection<SmsGSMModemDelivery> SmsGSMModemDelivery { get; set; }

	public virtual ICollection<SmsGSMModemSetting> SmsGSMModemSetting { get; set; }

	public virtual ICollection<SmsGSMReceives> SmsGSMReceives { get; set; }

	public virtual ICollection<SmsGSMSendingTank> SmsGSMSendingTank { get; set; }

	public virtual ICollection<SmsProviders> SmsProviders { get; set; }

	public virtual ICollection<SmsReceive> SmsReceive { get; set; }

	public virtual ICollection<SmsReceiveFromWSDL> SmsReceiveFromWSDL { get; set; }

	public virtual ICollection<SmsSendHeader> SmsSendHeader { get; set; }

	public virtual ICollection<SmsSendType_Lang> SmsSendType_Lang { get; set; }

	public virtual ICollection<SmsSendType> SmsSendType { get; set; }

	public virtual ICollection<SmsSetting> SmsSetting { get; set; }

	public virtual ICollection<SmsTempMobileNumbers> SmsTempMobileNumbers { get; set; }

	public virtual ICollection<SmsUserSendCredit_Lang> SmsUserSendCredit_Lang { get; set; }

	public virtual ICollection<SmsUserSendCredit> SmsUserSendCredit { get; set; }

	public virtual ICollection<UserDepartments_Lang> UserDepartments_Lang { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments { get; set; }

	public virtual ICollection<UserDepartmentTicketReferUsers> UserDepartmentTicketReferUsers { get; set; }

	public virtual ICollection<UserGroups_Lang> UserGroups_Lang { get; set; }

	public virtual ICollection<UserGroups> UserGroups { get; set; }

	public virtual ICollection<UserLanguages> UserLanguages { get; set; }

	public virtual ICollection<UserLoginAllowedTimes> UserLoginAllowedTimes { get; set; }

	public virtual ICollection<UserPictures> UserPictures { get; set; }

	public virtual ICollection<UserPositions_Lang> UserPositions_Lang { get; set; }

	public virtual ICollection<UserPositions> UserPositions { get; set; }

	public virtual ICollection<UserSignature> UserSignature { get; set; }

	public virtual ICollection<UsersPermission_Lang> UsersPermission_Lang { get; set; }

	public virtual ICollection<UsersPermission> UsersPermission { get; set; }

	public virtual ICollection<WSBuyOrder_Lang> WSBuyOrder_Lang { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderItems_Lang> WSBuyOrderItems_Lang { get; set; }

	public virtual ICollection<WSBuyOrderItems> WSBuyOrderItems { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials_Lang> WSBuyOrderItemSerials_Lang { get; set; }

	public virtual ICollection<WSBuyOrderItemSerials> WSBuyOrderItemSerials { get; set; }

	public virtual ICollection<WSBuyOrderOpr_Lang> WSBuyOrderOpr_Lang { get; set; }

	public virtual ICollection<WSBuyOrderOpr> WSBuyOrderOpr { get; set; }

	public virtual ICollection<WSBuyOrderPayments_Lang> WSBuyOrderPayments_Lang { get; set; }

	public virtual ICollection<WSBuyOrderPayments> WSBuyOrderPayments { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes_Lang> WSBuyOrderPaymentTypes_Lang { get; set; }

	public virtual ICollection<WSBuyOrderPaymentTypes> WSBuyOrderPaymentTypes { get; set; }

	public virtual ICollection<WSBuyOrderStatus_Lang> WSBuyOrderStatus_Lang { get; set; }

	public virtual ICollection<WSBuyOrderStatus> WSBuyOrderStatus { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups_Lang> WSCostSheetDyFieldGroups_Lang { get; set; }

	public virtual ICollection<WSCostSheetDyFieldGroups> WSCostSheetDyFieldGroups { get; set; }

	public virtual ICollection<WSCostSheetDyFieldTitle_Lang> WSCostSheetDyFieldTitle_Lang { get; set; }

	public virtual ICollection<WSCostSheetDyFieldTitle> WSCostSheetDyFieldTitle { get; set; }

	public virtual ICollection<WSCostSheetDyFieldValues> WSCostSheetDyFieldValues { get; set; }

	public virtual ICollection<WSCostSheetItems> WSCostSheetItems { get; set; }

	public virtual ICollection<WSCostSheetProducts_Lang> WSCostSheetProducts_Lang { get; set; }

	public virtual ICollection<WSCostSheetProducts> WSCostSheetProducts { get; set; }

	public virtual ICollection<WSCostSheets_Lang> WSCostSheets_Lang { get; set; }

	public virtual ICollection<WSCostSheets> WSCostSheets { get; set; }

	public virtual ICollection<WSCreditDuration_Lang> WSCreditDuration_Lang { get; set; }

	public virtual ICollection<WSCreditDuration> WSCreditDuration { get; set; }

	public virtual ICollection<WSCurrencyUnitRate> WSCurrencyUnitRate { get; set; }

	public virtual ICollection<WSCurrencyUnits_Lang> WSCurrencyUnits_Lang { get; set; }

	public virtual ICollection<WSCurrencyUnits> WSCurrencyUnits { get; set; }

	public virtual ICollection<WSDeliverySchedule_Lang> WSDeliverySchedule_Lang { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept_Lang> WSDeliveryScheduleExcept_Lang { get; set; }

	public virtual ICollection<WSDeliveryScheduleExcept> WSDeliveryScheduleExcept { get; set; }

	public virtual ICollection<WSDeliveryTime_Lang> WSDeliveryTime_Lang { get; set; }

	public virtual ICollection<WSDeliveryTime> WSDeliveryTime { get; set; }

	public virtual ICollection<WSDiscountCode_Lang> WSDiscountCode_Lang { get; set; }

	public virtual ICollection<WSDiscountCode> WSDiscountCode { get; set; }

	public virtual ICollection<WSDiscountCodeHistory> WSDiscountCodeHistory { get; set; }

	public virtual ICollection<WSDocOpr_Lang> WSDocOpr_Lang { get; set; }

	public virtual ICollection<WSDocOpr> WSDocOpr { get; set; }

	public virtual ICollection<WSFinancialPeriod> WSFinancialPeriod { get; set; }

	public virtual ICollection<WSGuaranty_Lang> WSGuaranty_Lang { get; set; }

	public virtual ICollection<WSGuaranty> WSGuaranty { get; set; }

	public virtual ICollection<WSLinkedProducts> WSLinkedProducts { get; set; }

	public virtual ICollection<WSLogo_Lang> WSLogo_Lang { get; set; }

	public virtual ICollection<WSLogo> WSLogo { get; set; }

	public virtual ICollection<WSOrderCommissionPayTypes_Lang> WSOrderCommissionPayTypes_Lang { get; set; }

	public virtual ICollection<WSOrderCommissionPayTypes> WSOrderCommissionPayTypes { get; set; }

	public virtual ICollection<WSOrderDefaultSetting_Lang> WSOrderDefaultSetting_Lang { get; set; }

	public virtual ICollection<WSOrderImportFromExcelFields_Lang> WSOrderImportFromExcelFields_Lang { get; set; }

	public virtual ICollection<WSOrderImportFromExcelFields> WSOrderImportFromExcelFields { get; set; }

	public virtual ICollection<WSOrderItemSerials_Lang> WSOrderItemSerials_Lang { get; set; }

	public virtual ICollection<WSOrderItemSerials> WSOrderItemSerials { get; set; }

	public virtual ICollection<WSOrderOpr_Lang> WSOrderOpr_Lang { get; set; }

	public virtual ICollection<WSOrderOpr> WSOrderOpr { get; set; }

	public virtual ICollection<WSOrderPaymentTypes_Lang> WSOrderPaymentTypes_Lang { get; set; }

	public virtual ICollection<WSOrderStatus_Lang> WSOrderStatus_Lang { get; set; }

	public virtual ICollection<WSOrderStatus> WSOrderStatus { get; set; }

	public virtual ICollection<WSPayCondition_Lang> WSPayCondition_Lang { get; set; }

	public virtual ICollection<WSPayCondition> WSPayCondition { get; set; }

	public virtual ICollection<WSPreOrderCommissions_Lang> WSPreOrderCommissions_Lang { get; set; }

	public virtual ICollection<WSPreOrderCommissions> WSPreOrderCommissions { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting_Lang> WSPreOrderDefaultSetting_Lang { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification_Lang> WSPreOrderItemSpecification_Lang { get; set; }

	public virtual ICollection<WSPreOrderItemSpecification> WSPreOrderItemSpecification { get; set; }

	public virtual ICollection<WSPreOrderOpr_Lang> WSPreOrderOpr_Lang { get; set; }

	public virtual ICollection<WSPreOrderOpr> WSPreOrderOpr { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasonGroups_Lang> WSPreOrderPrdGroupMustExistReasonGroups_Lang { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasonGroups> WSPreOrderPrdGroupMustExistReasonGroups { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons_Lang> WSPreOrderPrdGroupMustExistReasons_Lang { get; set; }

	public virtual ICollection<WSPreOrderPrdGroupMustExistReasons> WSPreOrderPrdGroupMustExistReasons { get; set; }

	public virtual ICollection<WSPreOrderStatus_Lang> WSPreOrderStatus_Lang { get; set; }

	public virtual ICollection<WSPreOrderStatus> WSPreOrderStatus { get; set; }

	public virtual ICollection<WSPreOrderTypes_Lang> WSPreOrderTypes_Lang { get; set; }

	public virtual ICollection<WSPreOrderTypes> WSPreOrderTypes { get; set; }

	public virtual ICollection<WSProductColor_Lang> WSProductColor_Lang { get; set; }

	public virtual ICollection<WSProductColor> WSProductColor { get; set; }

	public virtual ICollection<WSProductCost_Lang> WSProductCost_Lang { get; set; }

	public virtual ICollection<WSProductCost> WSProductCost { get; set; }

	public virtual ICollection<WSProductCostGroup_Lang> WSProductCostGroup_Lang { get; set; }

	public virtual ICollection<WSProductCostGroup> WSProductCostGroup { get; set; }

	public virtual ICollection<WSProductFirstGroup_Lang> WSProductFirstGroup_Lang { get; set; }

	public virtual ICollection<WSProductFirstGroup> WSProductFirstGroup { get; set; }

	public virtual ICollection<WSProductGallery> WSProductGallery { get; set; }

	public virtual ICollection<WSProductGroupPicture> WSProductGroupPicture { get; set; }

	public virtual ICollection<WSProductImportFromExcelFields_Lang> WSProductImportFromExcelFields_Lang { get; set; }

	public virtual ICollection<WSProductImportFromExcelFields> WSProductImportFromExcelFields { get; set; }

	public virtual ICollection<WSProductPicture_Lang> WSProductPicture_Lang { get; set; }

	public virtual ICollection<WSProductPicture> WSProductPicture { get; set; }

	public virtual ICollection<WSProductPrice_Lang> WSProductPrice_Lang { get; set; }

	public virtual ICollection<WSProductPrice> WSProductPrice { get; set; }

	public virtual ICollection<WSProductPriceGroup_Lang> WSProductPriceGroup_Lang { get; set; }

	public virtual ICollection<WSProductPriceGroup> WSProductPriceGroup { get; set; }

	public virtual ICollection<WSProductRelationLimit> WSProductRelationLimit { get; set; }

	public virtual ICollection<WSProductRelationType_Lang> WSProductRelationType_Lang { get; set; }

	public virtual ICollection<WSProductRelationType> WSProductRelationType { get; set; }

	public virtual ICollection<WSProductSecondGroup_Lang> WSProductSecondGroup_Lang { get; set; }

	public virtual ICollection<WSProductSecondGroup> WSProductSecondGroup { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes_Lang> WSProductShpStockManageTypes_Lang { get; set; }

	public virtual ICollection<WSProductShpStockManageTypes> WSProductShpStockManageTypes { get; set; }

	public virtual ICollection<WSProductSpecification_Lang> WSProductSpecification_Lang { get; set; }

	public virtual ICollection<WSProductSpecification> WSProductSpecification { get; set; }

	public virtual ICollection<WSProductsRate> WSProductsRate { get; set; }

	public virtual ICollection<WSProductsUserDiscount_Lang> WSProductsUserDiscount_Lang { get; set; }

	public virtual ICollection<WSProductsUserDiscount> WSProductsUserDiscount { get; set; }

	public virtual ICollection<WSProductUnits_Lang> WSProductUnits_Lang { get; set; }

	public virtual ICollection<WSProductUnits> WSProductUnits { get; set; }

	public virtual ICollection<WSRegisterBarCode> WSRegisterBarCode { get; set; }

	public virtual ICollection<WSSaleCenters_Lang> WSSaleCenters_Lang { get; set; }

	public virtual ICollection<WSSaleCenters> WSSaleCenters { get; set; }

	public virtual ICollection<WSSettlementType_Lang> WSSettlementType_Lang { get; set; }

	public virtual ICollection<WSSettlementType> WSSettlementType { get; set; }

	public virtual ICollection<WSSignature> WSSignature { get; set; }

	public virtual ICollection<WSTmpEnterBarcodeOperation> WSTmpEnterBarcodeOperation { get; set; }

	public virtual ICollection<WSTmpEnterDocPrdWithBarcode> WSTmpEnterDocPrdWithBarcode { get; set; }

	public virtual ICollection<WSUserFavproductItems_Lang> WSUserFavproductItems_Lang { get; set; }

	public virtual ICollection<WSUserFavproductItems> WSUserFavproductItems { get; set; }

	public virtual ICollection<WSUserFavproducts_Lang> WSUserFavproducts_Lang { get; set; }

	public virtual ICollection<WSUserFavproducts> WSUserFavproducts { get; set; }

	public virtual ICollection<WSVerificationRequestDetails_Lang> WSVerificationRequestDetails_Lang { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<WSVerificationRequests_Lang> WSVerificationRequests_Lang { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests { get; set; }

	public virtual ICollection<WSVerificationWorkFlows_Lang> WSVerificationWorkFlows_Lang { get; set; }

	public virtual ICollection<WSVerificationWorkFlows> WSVerificationWorkFlows { get; set; }

	public virtual ICollection<WsWareHouse_Lang> WsWareHouse_Lang { get; set; }

	public virtual ICollection<WsWareHouse> WsWareHouse { get; set; }

	public virtual ICollection<WSWareHouseUserPermissions> WSWareHouseUserPermissions { get; set; }

	public virtual ICollection<CrmLinkAccShygunSettingDetails> CrmLinkAccShygunSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccShygunSettingDetails_Lang> CrmLinkAccShygunSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmCompanyAddresses> CrmCompanyAddresses { get; set; }

	public virtual ICollection<CrmCompanyAddresses_Lang> CrmCompanyAddresses_Lang { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSettingDetails> CrmLinkAccPayvastSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccPayvastSettingDetails_Lang> CrmLinkAccPayvastSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo> CrmOnlinePayBankInfo { get; set; }

	public virtual ICollection<CrmOnlinePayBankInfo_Lang> CrmOnlinePayBankInfo_Lang { get; set; }

	public virtual ICollection<EmailUsersInfo> EmailUsersInfo { get; set; }

	public virtual ICollection<CrmLinkAccNoAvIISetting> CrmLinkAccNoAvIISetting { get; set; }

	public virtual ICollection<CrmLinkAccNoAvIISetting_Lang> CrmLinkAccNoAvIISetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISetting> CrmLinkAccShygunIISetting { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISetting_Lang> CrmLinkAccShygunIISetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISettingDetails> CrmLinkAccShygunIISettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccShygunIISettingDetails_Lang> CrmLinkAccShygunIISettingDetails_Lang { get; set; }

	public virtual ICollection<CrmLinkAccChamberCommerceSetting> CrmLinkAccChamberCommerceSetting { get; set; }

	public virtual ICollection<CrmLinkAccChamberCommerceSetting_Lang> CrmLinkAccChamberCommerceSetting_Lang { get; set; }

	public virtual ICollection<CrmMenuModel> CrmMenuModel { get; set; }

	public virtual ICollection<CrmMenuModel_Lang> CrmMenuModel_Lang { get; set; }

	public virtual ICollection<SecLetterNumberCounter_Lang> SecLetterNumberCounter_Lang { get; set; }

	public virtual ICollection<SecLetterNumberCounter> SecLetterNumberCounter { get; set; }

	public virtual ICollection<CrmProjects_Lang> CrmProjects_Lang { get; set; }

	public virtual ICollection<CrmCompanyCampaign> CrmCompanyCampaign { get; set; }

	public virtual ICollection<CrmCompanyCampaign_Lang> CrmCompanyCampaign_Lang { get; set; }

	public virtual ICollection<CrmProjectTitleGroups> CrmProjectTitleGroups { get; set; }

	public virtual ICollection<CrmProjectTitleGroups_Lang> CrmProjectTitleGroups_Lang { get; set; }

	public virtual ICollection<CrmDyFormFields> CrmDyFormFields { get; set; }

	public virtual ICollection<CrmDyFormFields_Lang> CrmDyFormFields_Lang { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag> CrmCompanyMoneyBag { get; set; }

	public virtual ICollection<CrmCompanyMoneyBag_Lang> CrmCompanyMoneyBag_Lang { get; set; }

	public virtual ICollection<WSOrderPayments_Lang> WSOrderPayments_Lang { get; set; }

	public virtual ICollection<WSOrderPayments> WSOrderPayments { get; set; }

	public virtual ICollection<WSPreOrderPayments_Lang> WSPreOrderPayments_Lang { get; set; }

	public virtual ICollection<WSPreOrderPayments> WSPreOrderPayments { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy> CrmConversationStatusResultEventPolicy { get; set; }

	public virtual ICollection<CrmConversationStatusResultEventPolicy_Lang> CrmConversationStatusResultEventPolicy_Lang { get; set; }

	public virtual ICollection<CrmConversationStatusGroups> CrmConversationStatusGroups { get; set; }

	public virtual ICollection<CrmConversationStatusGroups_Lang> CrmConversationStatusGroups_Lang { get; set; }

	public virtual ICollection<CrmCompanyAddressType> CrmCompanyAddressType { get; set; }

	public virtual ICollection<CrmCompanyAddressType_Lang> CrmCompanyAddressType_Lang { get; set; }

	public virtual ICollection<CrmBankingAccountType_Lang> CrmBankingAccountType_Lang { get; set; }

	public virtual ICollection<CrmBankingBanks_Lang> CrmBankingBanks_Lang { get; set; }

	public virtual ICollection<CrmBankingBranches_Lang> CrmBankingBranches_Lang { get; set; }

	public virtual ICollection<PayRollList_Lang> PayRollList_Lang { get; set; }

	public virtual ICollection<PayRollList> PayRollList { get; set; }

	public virtual ICollection<PayRollListGroups_Lang> PayRollListGroups_Lang { get; set; }

	public virtual ICollection<PayRollListGroups> PayRollListGroups { get; set; }

	public virtual ICollection<PayRollListItems> PayRollListItems { get; set; }

	public virtual ICollection<CrmLeaveKinds_Lang> CrmLeaveKinds_Lang { get; set; }

	public virtual ICollection<CrmLeaveStayType_Lang> CrmLeaveStayType_Lang { get; set; }

	public virtual ICollection<CrmLeaveVehicleType_Lang> CrmLeaveVehicleType_Lang { get; set; }

	public virtual ICollection<CrmBankingAccounts> CrmBankingAccounts { get; set; }

	public virtual ICollection<CrmBankingAccounts_Lang> CrmBankingAccounts_Lang { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<TspSetting_Lang> TspSetting_Lang { get; set; }

	public virtual ICollection<TspSetting> TspSetting { get; set; }

	public virtual ICollection<WSOrderPaymentTypes> WSOrderPaymentTypes { get; set; }

	public virtual ICollection<WSDeliverySchedule> WSDeliverySchedule { get; set; }

	public virtual ICollection<CrmLinkAccShomaranSetting> CrmLinkAccShomaranSetting { get; set; }

	public virtual ICollection<CrmLinkAccShomaranSetting_Lang> CrmLinkAccShomaranSetting_Lang { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting_Lang> CrmCompanyQuickRegisterDefSetting_Lang { get; set; }

	public virtual ICollection<WSOrderItems_Lang> WSOrderItems_Lang { get; set; }

	public virtual ICollection<WSOrderItems> WSOrderItems { get; set; }

	public virtual ICollection<WSPreOrderItems_Lang> WSPreOrderItems_Lang { get; set; }

	public virtual ICollection<WSPreOrderItems> WSPreOrderItems { get; set; }

	public virtual ICollection<WSTmpUserItemCopy> WSTmpUserItemCopy { get; set; }

	public virtual ICollection<CrmProjectTitles> CrmProjectTitles { get; set; }

	public virtual ICollection<CrmProjectTitles_Lang> CrmProjectTitles_Lang { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<CrmsysSetting_Lang> CrmsysSetting_Lang { get; set; }

	public virtual ICollection<CrmLinkAccArpaSetting> CrmLinkAccArpaSetting { get; set; }

	public virtual ICollection<CrmLinkAccArpaSetting_Lang> CrmLinkAccArpaSetting_Lang { get; set; }

	public virtual ICollection<CrmCompany> CrmCompany { get; set; }

	public virtual ICollection<CrmCompany_Lang> CrmCompany_Lang { get; set; }

	public virtual ICollection<WSDeliveryTerms_Lang> WSDeliveryTerms_Lang { get; set; }

	public virtual ICollection<WSDeliveryTerms> WSDeliveryTerms { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting_Lang> WSBuyOrderDefaultSetting_Lang { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSStockSupply_Lang> WSStockSupply_Lang { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<WSStockSupplyItems_Lang> WSStockSupplyItems_Lang { get; set; }

	public virtual ICollection<WSStockSupplyItems> WSStockSupplyItems { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps> CrmConversationStatusSalesFunnelSteps { get; set; }

	public virtual ICollection<CrmConversationStatusSalesFunnelSteps_Lang> CrmConversationStatusSalesFunnelSteps_Lang { get; set; }

	public virtual ICollection<UserMoneyBag_Lang> UserMoneyBag_Lang { get; set; }

	public virtual ICollection<UserMoneyBag> UserMoneyBag { get; set; }

	public virtual ICollection<WSDiscountStrategy_Lang> WSDiscountStrategy_Lang { get; set; }

	public virtual ICollection<WSDiscountStrategy> WSDiscountStrategy { get; set; }

	public virtual ICollection<WSOrderDiscounts_Lang> WSOrderDiscounts_Lang { get; set; }

	public virtual ICollection<WSOrderDiscounts> WSOrderDiscounts { get; set; }

	public virtual ICollection<WSPreOrderDiscounts_Lang> WSPreOrderDiscounts_Lang { get; set; }

	public virtual ICollection<WSPreOrderDiscounts> WSPreOrderDiscounts { get; set; }

	public virtual ICollection<CrmUserTasks> CrmUserTasks { get; set; }

	public virtual ICollection<CrmUserTasks_Lang> CrmUserTasks_Lang { get; set; }

	public virtual ICollection<CrmTelegSetting> CrmTelegSetting { get; set; }

	public virtual ICollection<WSOrderCommissions_Lang> WSOrderCommissions_Lang { get; set; }

	public virtual ICollection<WSOrderCommissions> WSOrderCommissions { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups> CrmCmsWidgetGroups { get; set; }

	public virtual ICollection<CrmCmsWidgetGroups_Lang> CrmCmsWidgetGroups_Lang { get; set; }

	public virtual ICollection<CrmCmsWidgets> CrmCmsWidgets { get; set; }

	public virtual ICollection<CrmCmsWidgets_Lang> CrmCmsWidgets_Lang { get; set; }

	public virtual ICollection<CrmLinkAccByViewSetting> CrmLinkAccByViewSetting { get; set; }

	public virtual ICollection<CrmLinkAccByViewSetting_Lang> CrmLinkAccByViewSetting_Lang { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps_Lang> WSVerificationWorkFlowSteps_Lang { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps { get; set; }

	public virtual ICollection<WSOrder_Lang> WSOrder_Lang { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSetting> CrmLinkAccHamrahanSetting { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSetting_Lang> CrmLinkAccHamrahanSetting_Lang { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting_Lang> CrmFoSetting_Lang { get; set; }

	public virtual ICollection<PayRollItems_Lang> PayRollItems_Lang { get; set; }

	public virtual ICollection<PayRollItems> PayRollItems { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSettingDetails> CrmLinkAccHamrahanSettingDetails { get; set; }

	public virtual ICollection<CrmLinkAccHamrahanSettingDetails_Lang> CrmLinkAccHamrahanSettingDetails_Lang { get; set; }

	public virtual ICollection<CrmMobSetting> CrmMobSetting { get; set; }

	public virtual ICollection<WSOrderGroups_Lang> WSOrderGroups_Lang { get; set; }

	public virtual ICollection<WSOrderGroups> WSOrderGroups { get; set; }

	public virtual ICollection<Centers> Centers { get; set; }

	public virtual ICollection<Centers_Lang> Centers_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups_Lang> WSProductSpecificationFieldGroups_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFieldGroups> WSProductSpecificationFieldGroups { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes_Lang> WSProductSpecificationFieldTypes_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFieldTypes> WSProductSpecificationFieldTypes { get; set; }

	public virtual ICollection<WSProductSpecificationFields_Lang> WSProductSpecificationFields_Lang { get; set; }

	public virtual ICollection<WSProductSpecificationFields> WSProductSpecificationFields { get; set; }

	public virtual ICollection<CrmCmsHomePageSectionItems> CrmCmsHomePageSectionItems { get; set; }

	public virtual ICollection<CrmFoSettingRegister> CrmFoSettingRegister { get; set; }

	public virtual ICollection<CrmFoSettingRegister_Lang> CrmFoSettingRegister_Lang { get; set; }

	public virtual ICollection<WSProductShpException_Lang> WSProductShpException_Lang { get; set; }

	public virtual ICollection<WSProductShpException> WSProductShpException { get; set; }

	public virtual ICollection<WSSaleAreas_Lang> WSSaleAreas_Lang { get; set; }

	public virtual ICollection<WSSaleAreas> WSSaleAreas { get; set; }

	public virtual ICollection<WSPreOrder_Lang> WSPreOrder_Lang { get; set; }

	public virtual ICollection<CrmConversationStatusResult> CrmConversationStatusResult { get; set; }

	public virtual ICollection<CrmConversationStatusResult_Lang> CrmConversationStatusResult_Lang { get; set; }

	public virtual ICollection<CrmCashes> CrmCashes { get; set; }

	public virtual ICollection<CrmCashes_Lang> CrmCashes_Lang { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsI_Lang> WSOrderPaymentGroupsI_Lang { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsI> WSOrderPaymentGroupsI { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII_Lang> WSOrderPaymentGroupsII_Lang { get; set; }

	public virtual ICollection<WSOrderPaymentGroupsII> WSOrderPaymentGroupsII { get; set; }

	public virtual ICollection<SmsSendDetail> SmsSendDetail { get; set; }

	public virtual ICollection<WSProducts_Lang> WSProducts_Lang { get; set; }

	public virtual ICollection<WSProducts> WSProducts { get; set; }

	public virtual ICollection<WSProductImportFromExcel> WSProductImportFromExcel { get; set; }

	public virtual ICollection<CrmConversationStatus> CrmConversationStatus { get; set; }

	public virtual ICollection<CrmConversationStatus_Lang> CrmConversationStatus_Lang { get; set; }

	public virtual ICollection<CrmTimeAttendance> CrmTimeAttendance { get; set; }

	public virtual ICollection<WSDoc_Lang> WSDoc_Lang { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSDocItems_Lang> WSDocItems_Lang { get; set; }

	public virtual ICollection<WSDocItems> WSDocItems { get; set; }

	public virtual ICollection<WSDocItemSerials_Lang> WSDocItemSerials_Lang { get; set; }

	public virtual ICollection<WSDocItemSerials> WSDocItemSerials { get; set; }

	public virtual ICollection<ScoreRules_Lang> ScoreRules_Lang { get; set; }

	public virtual ICollection<ScoreRules> ScoreRules { get; set; }

	public virtual ICollection<Scores_Lang> Scores_Lang { get; set; }

	public virtual ICollection<Scores> Scores { get; set; }

	public virtual ICollection<CrmProjects> CrmProjects { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual ICollection<CrmCompanyQuickRegisterDefSetting> CrmCompanyQuickRegisterDefSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual ICollection<Users_Lang> Users_Lang { get; set; }

	public virtual ICollection<Users> Users3 { get; set; }

	public Languages()
	{
		City = (ICollection<City>)new HashSet<City>();
		City_Lang = (ICollection<City_Lang>)new HashSet<City_Lang>();
		Country = (ICollection<Country>)new HashSet<Country>();
		Country_Lang = (ICollection<Country_Lang>)new HashSet<Country_Lang>();
		CrmAddressing = (ICollection<CrmAddressing>)new HashSet<CrmAddressing>();
		CrmAddressingType = (ICollection<CrmAddressingType>)new HashSet<CrmAddressingType>();
		CrmBankingAccountType = (ICollection<CrmBankingAccountType>)new HashSet<CrmBankingAccountType>();
		CrmBankingBanks = (ICollection<CrmBankingBanks>)new HashSet<CrmBankingBanks>();
		CrmBankingBranches = (ICollection<CrmBankingBranches>)new HashSet<CrmBankingBranches>();
		CrmCallBlackList = (ICollection<CrmCallBlackList>)new HashSet<CrmCallBlackList>();
		CrmCallHistory = (ICollection<CrmCallHistory>)new HashSet<CrmCallHistory>();
		CrmCallType = (ICollection<CrmCallType>)new HashSet<CrmCallType>();
		CrmCallType_Lang = (ICollection<CrmCallType_Lang>)new HashSet<CrmCallType_Lang>();
		CrmCmsComments = (ICollection<CrmCmsComments>)new HashSet<CrmCmsComments>();
		CrmCmsComments_Lang = (ICollection<CrmCmsComments_Lang>)new HashSet<CrmCmsComments_Lang>();
		CrmCmsFiles = (ICollection<CrmCmsFiles>)new HashSet<CrmCmsFiles>();
		CrmCmsFiles_Lang = (ICollection<CrmCmsFiles_Lang>)new HashSet<CrmCmsFiles_Lang>();
		CrmCmsFooter = (ICollection<CrmCmsFooter>)new HashSet<CrmCmsFooter>();
		CrmCmsFooter_Lang = (ICollection<CrmCmsFooter_Lang>)new HashSet<CrmCmsFooter_Lang>();
		CrmCmsGallery = (ICollection<CrmCmsGallery>)new HashSet<CrmCmsGallery>();
		CrmCmsGallery_Lang = (ICollection<CrmCmsGallery_Lang>)new HashSet<CrmCmsGallery_Lang>();
		CrmCmsGalleryItems = (ICollection<CrmCmsGalleryItems>)new HashSet<CrmCmsGalleryItems>();
		CrmCmsGalleryItems_Lang = (ICollection<CrmCmsGalleryItems_Lang>)new HashSet<CrmCmsGalleryItems_Lang>();
		CrmCmsHomePageSections = (ICollection<CrmCmsHomePageSections>)new HashSet<CrmCmsHomePageSections>();
		CrmCmsHomePageSections_Lang = (ICollection<CrmCmsHomePageSections_Lang>)new HashSet<CrmCmsHomePageSections_Lang>();
		CrmCmsLikes = (ICollection<CrmCmsLikes>)new HashSet<CrmCmsLikes>();
		CrmCmsMenus = (ICollection<CrmCmsMenus>)new HashSet<CrmCmsMenus>();
		CrmCmsMenus_Lang = (ICollection<CrmCmsMenus_Lang>)new HashSet<CrmCmsMenus_Lang>();
		CrmCmsNews = (ICollection<CrmCmsNews>)new HashSet<CrmCmsNews>();
		CrmCmsNews_Lang = (ICollection<CrmCmsNews_Lang>)new HashSet<CrmCmsNews_Lang>();
		CrmCmsNewsGroups = (ICollection<CrmCmsNewsGroups>)new HashSet<CrmCmsNewsGroups>();
		CrmCmsNewsGroups_Lang = (ICollection<CrmCmsNewsGroups_Lang>)new HashSet<CrmCmsNewsGroups_Lang>();
		CrmCmsObjectTypes = (ICollection<CrmCmsObjectTypes>)new HashSet<CrmCmsObjectTypes>();
		CrmCmsPages = (ICollection<CrmCmsPages>)new HashSet<CrmCmsPages>();
		CrmCmsPages_Lang = (ICollection<CrmCmsPages_Lang>)new HashSet<CrmCmsPages_Lang>();
		CrmCompanyForbiddenCity = (ICollection<CrmCompanyForbiddenCity>)new HashSet<CrmCompanyForbiddenCity>();
		CrmCompanyForbiddenCompany = (ICollection<CrmCompanyForbiddenCompany>)new HashSet<CrmCompanyForbiddenCompany>();
		CrmCompanyForbiddenDepartment = (ICollection<CrmCompanyForbiddenDepartment>)new HashSet<CrmCompanyForbiddenDepartment>();
		CrmCompanyForbiddenGroup = (ICollection<CrmCompanyForbiddenGroup>)new HashSet<CrmCompanyForbiddenGroup>();
		CrmCompanyForbiddenGroupIV = (ICollection<CrmCompanyForbiddenGroupIV>)new HashSet<CrmCompanyForbiddenGroupIV>();
		CrmCompanyForbiddenProvince = (ICollection<CrmCompanyForbiddenProvince>)new HashSet<CrmCompanyForbiddenProvince>();
		CrmCompanyForbiddenSubGroup = (ICollection<CrmCompanyForbiddenSubGroup>)new HashSet<CrmCompanyForbiddenSubGroup>();
		CrmCompanyGroups = (ICollection<CrmCompanyGroups>)new HashSet<CrmCompanyGroups>();
		CrmCompanyGroups_Lang = (ICollection<CrmCompanyGroups_Lang>)new HashSet<CrmCompanyGroups_Lang>();
		CrmCompanyGroupsII = (ICollection<CrmCompanyGroupsII>)new HashSet<CrmCompanyGroupsII>();
		CrmCompanyGroupsII_Lang = (ICollection<CrmCompanyGroupsII_Lang>)new HashSet<CrmCompanyGroupsII_Lang>();
		CrmCompanyGroupsIII = (ICollection<CrmCompanyGroupsIII>)new HashSet<CrmCompanyGroupsIII>();
		CrmCompanyGroupsIII_Lang = (ICollection<CrmCompanyGroupsIII_Lang>)new HashSet<CrmCompanyGroupsIII_Lang>();
		CrmCompanyGroupsIV = (ICollection<CrmCompanyGroupsIV>)new HashSet<CrmCompanyGroupsIV>();
		CrmCompanyGroupsIV_Lang = (ICollection<CrmCompanyGroupsIV_Lang>)new HashSet<CrmCompanyGroupsIV_Lang>();
		CrmCompanyGroupsMulti = (ICollection<CrmCompanyGroupsMulti>)new HashSet<CrmCompanyGroupsMulti>();
		CrmCompanyGroupsMulti_Lang = (ICollection<CrmCompanyGroupsMulti_Lang>)new HashSet<CrmCompanyGroupsMulti_Lang>();
		CrmCompanyJustAccessCity = (ICollection<CrmCompanyJustAccessCity>)new HashSet<CrmCompanyJustAccessCity>();
		CrmCompanyJustAccessCompany = (ICollection<CrmCompanyJustAccessCompany>)new HashSet<CrmCompanyJustAccessCompany>();
		CrmCompanyJustAccessDepartment = (ICollection<CrmCompanyJustAccessDepartment>)new HashSet<CrmCompanyJustAccessDepartment>();
		CrmCompanyJustAccessGroup = (ICollection<CrmCompanyJustAccessGroup>)new HashSet<CrmCompanyJustAccessGroup>();
		CrmCompanyJustAccessGroupIV = (ICollection<CrmCompanyJustAccessGroupIV>)new HashSet<CrmCompanyJustAccessGroupIV>();
		CrmCompanyJustAccessProvince = (ICollection<CrmCompanyJustAccessProvince>)new HashSet<CrmCompanyJustAccessProvince>();
		CrmCompanyJustAccessSubGroup = (ICollection<CrmCompanyJustAccessSubGroup>)new HashSet<CrmCompanyJustAccessSubGroup>();
		CrmCompanyLoGo = (ICollection<CrmCompanyLoGo>)new HashSet<CrmCompanyLoGo>();
		CrmCompanyMultiGroups = (ICollection<CrmCompanyMultiGroups>)new HashSet<CrmCompanyMultiGroups>();
		CrmCompanyPersons = (ICollection<CrmCompanyPersons>)new HashSet<CrmCompanyPersons>();
		CrmCompanyPersons_Lang = (ICollection<CrmCompanyPersons_Lang>)new HashSet<CrmCompanyPersons_Lang>();
		CrmCompanyPersonsTemplate = (ICollection<CrmCompanyPersonsTemplate>)new HashSet<CrmCompanyPersonsTemplate>();
		CrmCompanyPersonsTemplate_Lang = (ICollection<CrmCompanyPersonsTemplate_Lang>)new HashSet<CrmCompanyPersonsTemplate_Lang>();
		CrmCompanyPictureAlbums = (ICollection<CrmCompanyPictureAlbums>)new HashSet<CrmCompanyPictureAlbums>();
		CrmCompanyPictures = (ICollection<CrmCompanyPictures>)new HashSet<CrmCompanyPictures>();
		CrmCompanyPresentation = (ICollection<CrmCompanyPresentation>)new HashSet<CrmCompanyPresentation>();
		CrmCompanyPresentation_Lang = (ICollection<CrmCompanyPresentation_Lang>)new HashSet<CrmCompanyPresentation_Lang>();
		CrmCompanySubGroups = (ICollection<CrmCompanySubGroups>)new HashSet<CrmCompanySubGroups>();
		CrmCompanySubGroups_Lang = (ICollection<CrmCompanySubGroups_Lang>)new HashSet<CrmCompanySubGroups_Lang>();
		CrmCompanyTitle = (ICollection<CrmCompanyTitle>)new HashSet<CrmCompanyTitle>();
		CrmCompanyTitle_Lang = (ICollection<CrmCompanyTitle_Lang>)new HashSet<CrmCompanyTitle_Lang>();
		CrmCompanyType = (ICollection<CrmCompanyType>)new HashSet<CrmCompanyType>();
		CrmCompanyType_Lang = (ICollection<CrmCompanyType_Lang>)new HashSet<CrmCompanyType_Lang>();
		CrmCompanyUserForbidden = (ICollection<CrmCompanyUserForbidden>)new HashSet<CrmCompanyUserForbidden>();
		CrmConversation = (ICollection<CrmConversation>)new HashSet<CrmConversation>();
		CrmConversation_Lang = (ICollection<CrmConversation_Lang>)new HashSet<CrmConversation_Lang>();
		CrmConversationDefaultContext = (ICollection<CrmConversationDefaultContext>)new HashSet<CrmConversationDefaultContext>();
		CrmConversationDefaultContext_Lang = (ICollection<CrmConversationDefaultContext_Lang>)new HashSet<CrmConversationDefaultContext_Lang>();
		CrmConversationPriority = (ICollection<CrmConversationPriority>)new HashSet<CrmConversationPriority>();
		CrmConversationPriority_Lang = (ICollection<CrmConversationPriority_Lang>)new HashSet<CrmConversationPriority_Lang>();
		CrmConversationReferUsers = (ICollection<CrmConversationReferUsers>)new HashSet<CrmConversationReferUsers>();
		CrmConversationTopics = (ICollection<CrmConversationTopics>)new HashSet<CrmConversationTopics>();
		CrmConversationTopics_Lang = (ICollection<CrmConversationTopics_Lang>)new HashSet<CrmConversationTopics_Lang>();
		CrmDyFormFieldMasterValueDetails = (ICollection<CrmDyFormFieldMasterValueDetails>)new HashSet<CrmDyFormFieldMasterValueDetails>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		CrmDyFormFieldTypes = (ICollection<CrmDyFormFieldTypes>)new HashSet<CrmDyFormFieldTypes>();
		CrmDyFormFieldTypes_Lang = (ICollection<CrmDyFormFieldTypes_Lang>)new HashSet<CrmDyFormFieldTypes_Lang>();
		CrmDyFormFieldValues = (ICollection<CrmDyFormFieldValues>)new HashSet<CrmDyFormFieldValues>();
		CrmDyFormFieldValues_Lang = (ICollection<CrmDyFormFieldValues_Lang>)new HashSet<CrmDyFormFieldValues_Lang>();
		CrmDyFormRegularExpressions = (ICollection<CrmDyFormRegularExpressions>)new HashSet<CrmDyFormRegularExpressions>();
		CrmDyFormRegularExpressions_Lang = (ICollection<CrmDyFormRegularExpressions_Lang>)new HashSet<CrmDyFormRegularExpressions_Lang>();
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		CrmDyForms_Lang = (ICollection<CrmDyForms_Lang>)new HashSet<CrmDyForms_Lang>();
		CrmDyFormUserAccess = (ICollection<CrmDyFormUserAccess>)new HashSet<CrmDyFormUserAccess>();
		CrmDyFormWorkflows = (ICollection<CrmDyFormWorkflows>)new HashSet<CrmDyFormWorkflows>();
		CrmDyFormWorkflows_Lang = (ICollection<CrmDyFormWorkflows_Lang>)new HashSet<CrmDyFormWorkflows_Lang>();
		CrmDyFormWorkflowSteps = (ICollection<CrmDyFormWorkflowSteps>)new HashSet<CrmDyFormWorkflowSteps>();
		CrmDyFormWorkflowSteps_Lang = (ICollection<CrmDyFormWorkflowSteps_Lang>)new HashSet<CrmDyFormWorkflowSteps_Lang>();
		CrmFileDirectoryType = (ICollection<CrmFileDirectoryType>)new HashSet<CrmFileDirectoryType>();
		CrmFileDirectoryType_Lang = (ICollection<CrmFileDirectoryType_Lang>)new HashSet<CrmFileDirectoryType_Lang>();
		CrmFileDirectoryTypeOpr = (ICollection<CrmFileDirectoryTypeOpr>)new HashSet<CrmFileDirectoryTypeOpr>();
		CrmFileDirectoryTypeOpr_Lang = (ICollection<CrmFileDirectoryTypeOpr_Lang>)new HashSet<CrmFileDirectoryTypeOpr_Lang>();
		CrmFilesDirectory = (ICollection<CrmFilesDirectory>)new HashSet<CrmFilesDirectory>();
		CrmFilesDirectory_Lang = (ICollection<CrmFilesDirectory_Lang>)new HashSet<CrmFilesDirectory_Lang>();
		CrmFilesDirectoryTemplate = (ICollection<CrmFilesDirectoryTemplate>)new HashSet<CrmFilesDirectoryTemplate>();
		CrmFilesDirectoryTemplateType = (ICollection<CrmFilesDirectoryTemplateType>)new HashSet<CrmFilesDirectoryTemplateType>();
		CrmFund = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFund_Lang = (ICollection<CrmFund_Lang>)new HashSet<CrmFund_Lang>();
		CrmFundGroups = (ICollection<CrmFundGroups>)new HashSet<CrmFundGroups>();
		CrmFundGroups_Lang = (ICollection<CrmFundGroups_Lang>)new HashSet<CrmFundGroups_Lang>();
		CrmImportFromExcelFields_Lang = (ICollection<CrmImportFromExcelFields_Lang>)new HashSet<CrmImportFromExcelFields_Lang>();
		CrmInternalMessage = (ICollection<CrmInternalMessage>)new HashSet<CrmInternalMessage>();
		CrmInternalMessage_Lang = (ICollection<CrmInternalMessage_Lang>)new HashSet<CrmInternalMessage_Lang>();
		CrmInternalMessageDefaultContext = (ICollection<CrmInternalMessageDefaultContext>)new HashSet<CrmInternalMessageDefaultContext>();
		CrmInternalMessageDefaultContext_Lang = (ICollection<CrmInternalMessageDefaultContext_Lang>)new HashSet<CrmInternalMessageDefaultContext_Lang>();
		CrmInternalMessageDetails = (ICollection<CrmInternalMessageDetails>)new HashSet<CrmInternalMessageDetails>();
		CrmInternalMessageGroup = (ICollection<CrmInternalMessageGroup>)new HashSet<CrmInternalMessageGroup>();
		CrmInternalMessageGroup_Lang = (ICollection<CrmInternalMessageGroup_Lang>)new HashSet<CrmInternalMessageGroup_Lang>();
		CrmInternalMessagePriority = (ICollection<CrmInternalMessagePriority>)new HashSet<CrmInternalMessagePriority>();
		CrmInternalMessagePriority_Lang = (ICollection<CrmInternalMessagePriority_Lang>)new HashSet<CrmInternalMessagePriority_Lang>();
		CrmInternalMessageSelectReceiver = (ICollection<CrmInternalMessageSelectReceiver>)new HashSet<CrmInternalMessageSelectReceiver>();
		CrmInternalMessageTreeType = (ICollection<CrmInternalMessageTreeType>)new HashSet<CrmInternalMessageTreeType>();
		CrmInternalMessageTreeType_Lang = (ICollection<CrmInternalMessageTreeType_Lang>)new HashSet<CrmInternalMessageTreeType_Lang>();
		CrmInternalMessageType = (ICollection<CrmInternalMessageType>)new HashSet<CrmInternalMessageType>();
		CrmInternalMessageType_Lang = (ICollection<CrmInternalMessageType_Lang>)new HashSet<CrmInternalMessageType_Lang>();
		CrmKnowledgeTank = (ICollection<CrmKnowledgeTank>)new HashSet<CrmKnowledgeTank>();
		CrmKnowledgeTank_Lang = (ICollection<CrmKnowledgeTank_Lang>)new HashSet<CrmKnowledgeTank_Lang>();
		CrmKnowledgeTankGroup = (ICollection<CrmKnowledgeTankGroup>)new HashSet<CrmKnowledgeTankGroup>();
		CrmKnowledgeTankGroup_Lang = (ICollection<CrmKnowledgeTankGroup_Lang>)new HashSet<CrmKnowledgeTankGroup_Lang>();
		CrmKnowledgeTankGroupPermission = (ICollection<CrmKnowledgeTankGroupPermission>)new HashSet<CrmKnowledgeTankGroupPermission>();
		CrmKnowledgeTankPriority = (ICollection<CrmKnowledgeTankPriority>)new HashSet<CrmKnowledgeTankPriority>();
		CrmKnowledgeTankPriority_Lang = (ICollection<CrmKnowledgeTankPriority_Lang>)new HashSet<CrmKnowledgeTankPriority_Lang>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmLeaveKinds = (ICollection<CrmLeaveKinds>)new HashSet<CrmLeaveKinds>();
		CrmLeaveStatus = (ICollection<CrmLeaveStatus>)new HashSet<CrmLeaveStatus>();
		CrmLeaveStayType = (ICollection<CrmLeaveStayType>)new HashSet<CrmLeaveStayType>();
		CrmLeaveType = (ICollection<CrmLeaveType>)new HashSet<CrmLeaveType>();
		CrmLeaveVehicleType = (ICollection<CrmLeaveVehicleType>)new HashSet<CrmLeaveVehicleType>();
		CrmLinkAccHolooSetting = (ICollection<CrmLinkAccHolooSetting>)new HashSet<CrmLinkAccHolooSetting>();
		CrmLinkAccHolooSetting_Lang = (ICollection<CrmLinkAccHolooSetting_Lang>)new HashSet<CrmLinkAccHolooSetting_Lang>();
		CrmLinkAccHolooSettingDetails = (ICollection<CrmLinkAccHolooSettingDetails>)new HashSet<CrmLinkAccHolooSettingDetails>();
		CrmLinkAccHolooSettingDetails_Lang = (ICollection<CrmLinkAccHolooSettingDetails_Lang>)new HashSet<CrmLinkAccHolooSettingDetails_Lang>();
		CrmLinkAccKyanSetting = (ICollection<CrmLinkAccKyanSetting>)new HashSet<CrmLinkAccKyanSetting>();
		CrmLinkAccKyanSetting_Lang = (ICollection<CrmLinkAccKyanSetting_Lang>)new HashSet<CrmLinkAccKyanSetting_Lang>();
		CrmLinkAccNoAvSetting = (ICollection<CrmLinkAccNoAvSetting>)new HashSet<CrmLinkAccNoAvSetting>();
		CrmLinkAccNoAvSetting_Lang = (ICollection<CrmLinkAccNoAvSetting_Lang>)new HashSet<CrmLinkAccNoAvSetting_Lang>();
		CrmLinkAccNoAvSettingDetails = (ICollection<CrmLinkAccNoAvSettingDetails>)new HashSet<CrmLinkAccNoAvSettingDetails>();
		CrmLinkAccNoAvSettingDetails_Lang = (ICollection<CrmLinkAccNoAvSettingDetails_Lang>)new HashSet<CrmLinkAccNoAvSettingDetails_Lang>();
		CrmLinkAccPayvastSetting = (ICollection<CrmLinkAccPayvastSetting>)new HashSet<CrmLinkAccPayvastSetting>();
		CrmLinkAccPayvastSetting_Lang = (ICollection<CrmLinkAccPayvastSetting_Lang>)new HashSet<CrmLinkAccPayvastSetting_Lang>();
		CrmLinkAccSetting = (ICollection<CrmLinkAccSetting>)new HashSet<CrmLinkAccSetting>();
		CrmLinkAccSetting_Lang = (ICollection<CrmLinkAccSetting_Lang>)new HashSet<CrmLinkAccSetting_Lang>();
		CrmLinkAccSettingDetails = (ICollection<CrmLinkAccSettingDetails>)new HashSet<CrmLinkAccSettingDetails>();
		CrmLinkAccSettingDetails_Lang = (ICollection<CrmLinkAccSettingDetails_Lang>)new HashSet<CrmLinkAccSettingDetails_Lang>();
		CrmLinkAccShygunSetting = (ICollection<CrmLinkAccShygunSetting>)new HashSet<CrmLinkAccShygunSetting>();
		CrmLinkAccShygunSetting_Lang = (ICollection<CrmLinkAccShygunSetting_Lang>)new HashSet<CrmLinkAccShygunSetting_Lang>();
		CrmLinkAccSystems = (ICollection<CrmLinkAccSystems>)new HashSet<CrmLinkAccSystems>();
		CrmLinkAccTarazSetting = (ICollection<CrmLinkAccTarazSetting>)new HashSet<CrmLinkAccTarazSetting>();
		CrmLinkAccTarazSetting_Lang = (ICollection<CrmLinkAccTarazSetting_Lang>)new HashSet<CrmLinkAccTarazSetting_Lang>();
		CrmLinkAccTarazSettingDetails = (ICollection<CrmLinkAccTarazSettingDetails>)new HashSet<CrmLinkAccTarazSettingDetails>();
		CrmLinkAccTarazSettingDetails_Lang = (ICollection<CrmLinkAccTarazSettingDetails_Lang>)new HashSet<CrmLinkAccTarazSettingDetails_Lang>();
		CrmLinkedRolls = (ICollection<CrmLinkedRolls>)new HashSet<CrmLinkedRolls>();
		CrmLinkedType = (ICollection<CrmLinkedType>)new HashSet<CrmLinkedType>();
		CrmLinkedType_Lang = (ICollection<CrmLinkedType_Lang>)new HashSet<CrmLinkedType_Lang>();
		CrmLinkedUserPositions = (ICollection<CrmLinkedUserPositions>)new HashSet<CrmLinkedUserPositions>();
		CrmLinkedUsers = (ICollection<CrmLinkedUsers>)new HashSet<CrmLinkedUsers>();
		CrmNumRefSetting = (ICollection<CrmNumRefSetting>)new HashSet<CrmNumRefSetting>();
		CrmOperationsType = (ICollection<CrmOperationsType>)new HashSet<CrmOperationsType>();
		CrmOperationsType_Lang = (ICollection<CrmOperationsType_Lang>)new HashSet<CrmOperationsType_Lang>();
		CrmPersonDepartments = (ICollection<CrmPersonDepartments>)new HashSet<CrmPersonDepartments>();
		CrmPersonDepartments_Lang = (ICollection<CrmPersonDepartments_Lang>)new HashSet<CrmPersonDepartments_Lang>();
		CrmPersonGroups = (ICollection<CrmPersonGroups>)new HashSet<CrmPersonGroups>();
		CrmPersonGroups_Lang = (ICollection<CrmPersonGroups_Lang>)new HashSet<CrmPersonGroups_Lang>();
		CrmPersonJobs = (ICollection<CrmPersonJobs>)new HashSet<CrmPersonJobs>();
		CrmPersonJobs_Lang = (ICollection<CrmPersonJobs_Lang>)new HashSet<CrmPersonJobs_Lang>();
		CrmPersonPicture = (ICollection<CrmPersonPicture>)new HashSet<CrmPersonPicture>();
		CrmPersonTitle = (ICollection<CrmPersonTitle>)new HashSet<CrmPersonTitle>();
		CrmPersonTitle_Lang = (ICollection<CrmPersonTitle_Lang>)new HashSet<CrmPersonTitle_Lang>();
		CrmPersonType = (ICollection<CrmPersonType>)new HashSet<CrmPersonType>();
		CrmPersonType_Lang = (ICollection<CrmPersonType_Lang>)new HashSet<CrmPersonType_Lang>();
		CrmProjectCategory = (ICollection<CrmProjectCategory>)new HashSet<CrmProjectCategory>();
		CrmProjectCategory_Lang = (ICollection<CrmProjectCategory_Lang>)new HashSet<CrmProjectCategory_Lang>();
		CrmProjectDefualtValue = (ICollection<CrmProjectDefualtValue>)new HashSet<CrmProjectDefualtValue>();
		CrmProjectDefualtValue_Lang = (ICollection<CrmProjectDefualtValue_Lang>)new HashSet<CrmProjectDefualtValue_Lang>();
		CrmProjectFieldTitle = (ICollection<CrmProjectFieldTitle>)new HashSet<CrmProjectFieldTitle>();
		CrmProjectFieldTitle_Lang = (ICollection<CrmProjectFieldTitle_Lang>)new HashSet<CrmProjectFieldTitle_Lang>();
		CrmProjectFieldValueType = (ICollection<CrmProjectFieldValueType>)new HashSet<CrmProjectFieldValueType>();
		CrmProjectGrade = (ICollection<CrmProjectGrade>)new HashSet<CrmProjectGrade>();
		CrmProjectGrade_Lang = (ICollection<CrmProjectGrade_Lang>)new HashSet<CrmProjectGrade_Lang>();
		CrmProjectGroups = (ICollection<CrmProjectGroups>)new HashSet<CrmProjectGroups>();
		CrmProjectGroups_Lang = (ICollection<CrmProjectGroups_Lang>)new HashSet<CrmProjectGroups_Lang>();
		CrmProjectGroupsMulti = (ICollection<CrmProjectGroupsMulti>)new HashSet<CrmProjectGroupsMulti>();
		CrmProjectGroupsMulti_Lang = (ICollection<CrmProjectGroupsMulti_Lang>)new HashSet<CrmProjectGroupsMulti_Lang>();
		CrmProjectGroupsMultiI = (ICollection<CrmProjectGroupsMultiI>)new HashSet<CrmProjectGroupsMultiI>();
		CrmProjectGroupsMultiI_Lang = (ICollection<CrmProjectGroupsMultiI_Lang>)new HashSet<CrmProjectGroupsMultiI_Lang>();
		CrmProjectInformations = (ICollection<CrmProjectInformations>)new HashSet<CrmProjectInformations>();
		CrmProjectInformations_Lang = (ICollection<CrmProjectInformations_Lang>)new HashSet<CrmProjectInformations_Lang>();
		CrmProjectMultiGroups = (ICollection<CrmProjectMultiGroups>)new HashSet<CrmProjectMultiGroups>();
		CrmProjectMultiIGroups = (ICollection<CrmProjectMultiIGroups>)new HashSet<CrmProjectMultiIGroups>();
		CrmProjectPriority = (ICollection<CrmProjectPriority>)new HashSet<CrmProjectPriority>();
		CrmProjectPriority_Lang = (ICollection<CrmProjectPriority_Lang>)new HashSet<CrmProjectPriority_Lang>();
		CrmProjectsForbiddenForUser = (ICollection<CrmProjectsForbiddenForUser>)new HashSet<CrmProjectsForbiddenForUser>();
		CrmProjectsForbiddenForUser_Lang = (ICollection<CrmProjectsForbiddenForUser_Lang>)new HashSet<CrmProjectsForbiddenForUser_Lang>();
		CrmShowTableFieldInFO = (ICollection<CrmShowTableFieldInFO>)new HashSet<CrmShowTableFieldInFO>();
		CrmSurvey = (ICollection<CrmSurvey>)new HashSet<CrmSurvey>();
		CrmSurvey_Lang = (ICollection<CrmSurvey_Lang>)new HashSet<CrmSurvey_Lang>();
		CrmSurveyAnswerCategory = (ICollection<CrmSurveyAnswerCategory>)new HashSet<CrmSurveyAnswerCategory>();
		CrmSurveyAnswerCategory_Lang = (ICollection<CrmSurveyAnswerCategory_Lang>)new HashSet<CrmSurveyAnswerCategory_Lang>();
		CrmSurveyAnswerCategoryDetails = (ICollection<CrmSurveyAnswerCategoryDetails>)new HashSet<CrmSurveyAnswerCategoryDetails>();
		CrmSurveyAnswerCategoryDetails_Lang = (ICollection<CrmSurveyAnswerCategoryDetails_Lang>)new HashSet<CrmSurveyAnswerCategoryDetails_Lang>();
		CrmSurveyAnswerCategoryDetailValues = (ICollection<CrmSurveyAnswerCategoryDetailValues>)new HashSet<CrmSurveyAnswerCategoryDetailValues>();
		CrmSurveyAnswers = (ICollection<CrmSurveyAnswers>)new HashSet<CrmSurveyAnswers>();
		CrmSurveyAnswers_Lang = (ICollection<CrmSurveyAnswers_Lang>)new HashSet<CrmSurveyAnswers_Lang>();
		CrmSurveyAnswerValue = (ICollection<CrmSurveyAnswerValue>)new HashSet<CrmSurveyAnswerValue>();
		CrmSurveyAnswerValue_Lang = (ICollection<CrmSurveyAnswerValue_Lang>)new HashSet<CrmSurveyAnswerValue_Lang>();
		CrmSurveyHistory = (ICollection<CrmSurveyHistory>)new HashSet<CrmSurveyHistory>();
		CrmSurveyQuestions = (ICollection<CrmSurveyQuestions>)new HashSet<CrmSurveyQuestions>();
		CrmSurveyQuestions_Lang = (ICollection<CrmSurveyQuestions_Lang>)new HashSet<CrmSurveyQuestions_Lang>();
		CrmSurveySendSetting = (ICollection<CrmSurveySendSetting>)new HashSet<CrmSurveySendSetting>();
		CrmSurveySendSetting_Lang = (ICollection<CrmSurveySendSetting_Lang>)new HashSet<CrmSurveySendSetting_Lang>();
		CrmsysCIDeviceType = (ICollection<CrmsysCIDeviceType>)new HashSet<CrmsysCIDeviceType>();
		CrmsysCIPopUpSetting = (ICollection<CrmsysCIPopUpSetting>)new HashSet<CrmsysCIPopUpSetting>();
		CrmsysCISetting = (ICollection<CrmsysCISetting>)new HashSet<CrmsysCISetting>();
		CrmsysDBObjects = (ICollection<CrmsysDBObjects>)new HashSet<CrmsysDBObjects>();
		CrmsysDBObjects_Lang = (ICollection<CrmsysDBObjects_Lang>)new HashSet<CrmsysDBObjects_Lang>();
		CrmsysDBTempInfo = (ICollection<CrmsysDBTempInfo>)new HashSet<CrmsysDBTempInfo>();
		CrmsysDBTempInfoType = (ICollection<CrmsysDBTempInfoType>)new HashSet<CrmsysDBTempInfoType>();
		CrmsysFormActions = (ICollection<CrmsysFormActions>)new HashSet<CrmsysFormActions>();
		CrmsysFormActions_Lang = (ICollection<CrmsysFormActions_Lang>)new HashSet<CrmsysFormActions_Lang>();
		CrmsysFormObjectProperties = (ICollection<CrmsysFormObjectProperties>)new HashSet<CrmsysFormObjectProperties>();
		CrmsysFormObjectProperties_Lang = (ICollection<CrmsysFormObjectProperties_Lang>)new HashSet<CrmsysFormObjectProperties_Lang>();
		CrmsysForms = (ICollection<CrmsysForms>)new HashSet<CrmsysForms>();
		CrmsysForms_Lang = (ICollection<CrmsysForms_Lang>)new HashSet<CrmsysForms_Lang>();
		CrmsysRollPermission = (ICollection<CrmsysRollPermission>)new HashSet<CrmsysRollPermission>();
		CrmsysRolls = (ICollection<CrmsysRolls>)new HashSet<CrmsysRolls>();
		CrmsysRolls_Lang = (ICollection<CrmsysRolls_Lang>)new HashSet<CrmsysRolls_Lang>();
		CrmSystemParts = (ICollection<CrmSystemParts>)new HashSet<CrmSystemParts>();
		CrmSystemParts_Lang = (ICollection<CrmSystemParts_Lang>)new HashSet<CrmSystemParts_Lang>();
		CrmTelegBotChatMessage = (ICollection<CrmTelegBotChatMessage>)new HashSet<CrmTelegBotChatMessage>();
		CrmTelegBotContacts = (ICollection<CrmTelegBotContacts>)new HashSet<CrmTelegBotContacts>();
		CrmTelegBotMessageType = (ICollection<CrmTelegBotMessageType>)new HashSet<CrmTelegBotMessageType>();
		CrmTelegBotSetting = (ICollection<CrmTelegBotSetting>)new HashSet<CrmTelegBotSetting>();
		CrmTelegChatMessage = (ICollection<CrmTelegChatMessage>)new HashSet<CrmTelegChatMessage>();
		CrmTelegContacts = (ICollection<CrmTelegContacts>)new HashSet<CrmTelegContacts>();
		CrmTelegMessageType = (ICollection<CrmTelegMessageType>)new HashSet<CrmTelegMessageType>();
		CrmTempEmails = (ICollection<CrmTempEmails>)new HashSet<CrmTempEmails>();
		CrmTimeAttendanceBase = (ICollection<CrmTimeAttendanceBase>)new HashSet<CrmTimeAttendanceBase>();
		CrmTimeAttendanceLog = (ICollection<CrmTimeAttendanceLog>)new HashSet<CrmTimeAttendanceLog>();
		CRMtmpManageTellNumber = (ICollection<CRMtmpManageTellNumber>)new HashSet<CRMtmpManageTellNumber>();
		CrmUserNotes = (ICollection<CrmUserNotes>)new HashSet<CrmUserNotes>();
		CrmUserTaskGroups = (ICollection<CrmUserTaskGroups>)new HashSet<CrmUserTaskGroups>();
		CrmUserTaskGroups_Lang = (ICollection<CrmUserTaskGroups_Lang>)new HashSet<CrmUserTaskGroups_Lang>();
		CrmUserTaskPriorities = (ICollection<CrmUserTaskPriorities>)new HashSet<CrmUserTaskPriorities>();
		CrmUserTaskPriorities_Lang = (ICollection<CrmUserTaskPriorities_Lang>)new HashSet<CrmUserTaskPriorities_Lang>();
		CrmVersions = (ICollection<CrmVersions>)new HashSet<CrmVersions>();
		CrmVersionUpgrade = (ICollection<CrmVersionUpgrade>)new HashSet<CrmVersionUpgrade>();
		CrmVersionUpgradeDetails = (ICollection<CrmVersionUpgradeDetails>)new HashSet<CrmVersionUpgradeDetails>();
		CrmWebSetting = (ICollection<CrmWebSetting>)new HashSet<CrmWebSetting>();
		Education = (ICollection<Education>)new HashSet<Education>();
		Education_Lang = (ICollection<Education_Lang>)new HashSet<Education_Lang>();
		EmailDefaultBodyText = (ICollection<EmailDefaultBodyText>)new HashSet<EmailDefaultBodyText>();
		EmailDefaultBodyText_Lang = (ICollection<EmailDefaultBodyText_Lang>)new HashSet<EmailDefaultBodyText_Lang>();
		EmailReceive = (ICollection<EmailReceive>)new HashSet<EmailReceive>();
		EmailReceiveAttachments = (ICollection<EmailReceiveAttachments>)new HashSet<EmailReceiveAttachments>();
		EmailReceiveFolders = (ICollection<EmailReceiveFolders>)new HashSet<EmailReceiveFolders>();
		EmailSendAttachment = (ICollection<EmailSendAttachment>)new HashSet<EmailSendAttachment>();
		EmailSendDetail = (ICollection<EmailSendDetail>)new HashSet<EmailSendDetail>();
		EmailSendHeader = (ICollection<EmailSendHeader>)new HashSet<EmailSendHeader>();
		EmailSetting = (ICollection<EmailSetting>)new HashSet<EmailSetting>();
		EmailUserDefaultSetting = (ICollection<EmailUserDefaultSetting>)new HashSet<EmailUserDefaultSetting>();
		EmailUserTempTank = (ICollection<EmailUserTempTank>)new HashSet<EmailUserTempTank>();
		PayRollItemTypes_Lang = (ICollection<PayRollItemTypes_Lang>)new HashSet<PayRollItemTypes_Lang>();
		PayRollItemTypes = (ICollection<PayRollItemTypes>)new HashSet<PayRollItemTypes>();
		PayRollUserCycle_Lang = (ICollection<PayRollUserCycle_Lang>)new HashSet<PayRollUserCycle_Lang>();
		PayRollUserCycle = (ICollection<PayRollUserCycle>)new HashSet<PayRollUserCycle>();
		PayRollUserCycleItemValues = (ICollection<PayRollUserCycleItemValues>)new HashSet<PayRollUserCycleItemValues>();
		PayRollUserDefaultItems = (ICollection<PayRollUserDefaultItems>)new HashSet<PayRollUserDefaultItems>();
		PayRollUserPayments_Lang = (ICollection<PayRollUserPayments_Lang>)new HashSet<PayRollUserPayments_Lang>();
		PayRollUserPayments = (ICollection<PayRollUserPayments>)new HashSet<PayRollUserPayments>();
		PayRollUserPaymentTypes_Lang = (ICollection<PayRollUserPaymentTypes_Lang>)new HashSet<PayRollUserPaymentTypes_Lang>();
		PayRollUserPaymentTypes = (ICollection<PayRollUserPaymentTypes>)new HashSet<PayRollUserPaymentTypes>();
		PrintFormat_Lang = (ICollection<PrintFormat_Lang>)new HashSet<PrintFormat_Lang>();
		PrintFormat = (ICollection<PrintFormat>)new HashSet<PrintFormat>();
		PrintFormatType_Lang = (ICollection<PrintFormatType_Lang>)new HashSet<PrintFormatType_Lang>();
		PrintFormatType = (ICollection<PrintFormatType>)new HashSet<PrintFormatType>();
		Projects_Lang = (ICollection<Projects_Lang>)new HashSet<Projects_Lang>();
		Projects = (ICollection<Projects>)new HashSet<Projects>();
		Province_Lang = (ICollection<Province_Lang>)new HashSet<Province_Lang>();
		Province = (ICollection<Province>)new HashSet<Province>();
		SecLetterDefaultSettings_Lang = (ICollection<SecLetterDefaultSettings_Lang>)new HashSet<SecLetterDefaultSettings_Lang>();
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetters_Lang = (ICollection<SecLetters_Lang>)new HashSet<SecLetters_Lang>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		SecLetterType_Lang = (ICollection<SecLetterType_Lang>)new HashSet<SecLetterType_Lang>();
		SecLetterType = (ICollection<SecLetterType>)new HashSet<SecLetterType>();
		Sex_Lang = (ICollection<Sex_Lang>)new HashSet<Sex_Lang>();
		Sex = (ICollection<Sex>)new HashSet<Sex>();
		SmsDefaultBodyText_Lang = (ICollection<SmsDefaultBodyText_Lang>)new HashSet<SmsDefaultBodyText_Lang>();
		SmsDefaultBodyText = (ICollection<SmsDefaultBodyText>)new HashSet<SmsDefaultBodyText>();
		SmsDefaultBodyTextGroups_Lang = (ICollection<SmsDefaultBodyTextGroups_Lang>)new HashSet<SmsDefaultBodyTextGroups_Lang>();
		SmsDefaultBodyTextGroups = (ICollection<SmsDefaultBodyTextGroups>)new HashSet<SmsDefaultBodyTextGroups>();
		SmsDeliveryStatus_Lang = (ICollection<SmsDeliveryStatus_Lang>)new HashSet<SmsDeliveryStatus_Lang>();
		SmsDeliveryStatus = (ICollection<SmsDeliveryStatus>)new HashSet<SmsDeliveryStatus>();
		SmsGSMModemDelivery = (ICollection<SmsGSMModemDelivery>)new HashSet<SmsGSMModemDelivery>();
		SmsGSMModemSetting = (ICollection<SmsGSMModemSetting>)new HashSet<SmsGSMModemSetting>();
		SmsGSMReceives = (ICollection<SmsGSMReceives>)new HashSet<SmsGSMReceives>();
		SmsGSMSendingTank = (ICollection<SmsGSMSendingTank>)new HashSet<SmsGSMSendingTank>();
		SmsProviders = (ICollection<SmsProviders>)new HashSet<SmsProviders>();
		SmsReceive = (ICollection<SmsReceive>)new HashSet<SmsReceive>();
		SmsReceiveFromWSDL = (ICollection<SmsReceiveFromWSDL>)new HashSet<SmsReceiveFromWSDL>();
		SmsSendHeader = (ICollection<SmsSendHeader>)new HashSet<SmsSendHeader>();
		SmsSendType_Lang = (ICollection<SmsSendType_Lang>)new HashSet<SmsSendType_Lang>();
		SmsSendType = (ICollection<SmsSendType>)new HashSet<SmsSendType>();
		SmsSetting = (ICollection<SmsSetting>)new HashSet<SmsSetting>();
		SmsTempMobileNumbers = (ICollection<SmsTempMobileNumbers>)new HashSet<SmsTempMobileNumbers>();
		SmsUserSendCredit_Lang = (ICollection<SmsUserSendCredit_Lang>)new HashSet<SmsUserSendCredit_Lang>();
		SmsUserSendCredit = (ICollection<SmsUserSendCredit>)new HashSet<SmsUserSendCredit>();
		UserDepartments_Lang = (ICollection<UserDepartments_Lang>)new HashSet<UserDepartments_Lang>();
		UserDepartments = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartmentTicketReferUsers = (ICollection<UserDepartmentTicketReferUsers>)new HashSet<UserDepartmentTicketReferUsers>();
		UserGroups_Lang = (ICollection<UserGroups_Lang>)new HashSet<UserGroups_Lang>();
		UserGroups = (ICollection<UserGroups>)new HashSet<UserGroups>();
		UserLanguages = (ICollection<UserLanguages>)new HashSet<UserLanguages>();
		UserLoginAllowedTimes = (ICollection<UserLoginAllowedTimes>)new HashSet<UserLoginAllowedTimes>();
		UserPictures = (ICollection<UserPictures>)new HashSet<UserPictures>();
		UserPositions_Lang = (ICollection<UserPositions_Lang>)new HashSet<UserPositions_Lang>();
		UserPositions = (ICollection<UserPositions>)new HashSet<UserPositions>();
		UserSignature = (ICollection<UserSignature>)new HashSet<UserSignature>();
		UsersPermission_Lang = (ICollection<UsersPermission_Lang>)new HashSet<UsersPermission_Lang>();
		UsersPermission = (ICollection<UsersPermission>)new HashSet<UsersPermission>();
		WSBuyOrder_Lang = (ICollection<WSBuyOrder_Lang>)new HashSet<WSBuyOrder_Lang>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderItems_Lang = (ICollection<WSBuyOrderItems_Lang>)new HashSet<WSBuyOrderItems_Lang>();
		WSBuyOrderItems = (ICollection<WSBuyOrderItems>)new HashSet<WSBuyOrderItems>();
		WSBuyOrderItemSerials_Lang = (ICollection<WSBuyOrderItemSerials_Lang>)new HashSet<WSBuyOrderItemSerials_Lang>();
		WSBuyOrderItemSerials = (ICollection<WSBuyOrderItemSerials>)new HashSet<WSBuyOrderItemSerials>();
		WSBuyOrderOpr_Lang = (ICollection<WSBuyOrderOpr_Lang>)new HashSet<WSBuyOrderOpr_Lang>();
		WSBuyOrderOpr = (ICollection<WSBuyOrderOpr>)new HashSet<WSBuyOrderOpr>();
		WSBuyOrderPayments_Lang = (ICollection<WSBuyOrderPayments_Lang>)new HashSet<WSBuyOrderPayments_Lang>();
		WSBuyOrderPayments = (ICollection<WSBuyOrderPayments>)new HashSet<WSBuyOrderPayments>();
		WSBuyOrderPaymentTypes_Lang = (ICollection<WSBuyOrderPaymentTypes_Lang>)new HashSet<WSBuyOrderPaymentTypes_Lang>();
		WSBuyOrderPaymentTypes = (ICollection<WSBuyOrderPaymentTypes>)new HashSet<WSBuyOrderPaymentTypes>();
		WSBuyOrderStatus_Lang = (ICollection<WSBuyOrderStatus_Lang>)new HashSet<WSBuyOrderStatus_Lang>();
		WSBuyOrderStatus = (ICollection<WSBuyOrderStatus>)new HashSet<WSBuyOrderStatus>();
		WSCostSheetDyFieldGroups_Lang = (ICollection<WSCostSheetDyFieldGroups_Lang>)new HashSet<WSCostSheetDyFieldGroups_Lang>();
		WSCostSheetDyFieldGroups = (ICollection<WSCostSheetDyFieldGroups>)new HashSet<WSCostSheetDyFieldGroups>();
		WSCostSheetDyFieldTitle_Lang = (ICollection<WSCostSheetDyFieldTitle_Lang>)new HashSet<WSCostSheetDyFieldTitle_Lang>();
		WSCostSheetDyFieldTitle = (ICollection<WSCostSheetDyFieldTitle>)new HashSet<WSCostSheetDyFieldTitle>();
		WSCostSheetDyFieldValues = (ICollection<WSCostSheetDyFieldValues>)new HashSet<WSCostSheetDyFieldValues>();
		WSCostSheetItems = (ICollection<WSCostSheetItems>)new HashSet<WSCostSheetItems>();
		WSCostSheetProducts_Lang = (ICollection<WSCostSheetProducts_Lang>)new HashSet<WSCostSheetProducts_Lang>();
		WSCostSheetProducts = (ICollection<WSCostSheetProducts>)new HashSet<WSCostSheetProducts>();
		WSCostSheets_Lang = (ICollection<WSCostSheets_Lang>)new HashSet<WSCostSheets_Lang>();
		WSCostSheets = (ICollection<WSCostSheets>)new HashSet<WSCostSheets>();
		WSCreditDuration_Lang = (ICollection<WSCreditDuration_Lang>)new HashSet<WSCreditDuration_Lang>();
		WSCreditDuration = (ICollection<WSCreditDuration>)new HashSet<WSCreditDuration>();
		WSCurrencyUnitRate = (ICollection<WSCurrencyUnitRate>)new HashSet<WSCurrencyUnitRate>();
		WSCurrencyUnits_Lang = (ICollection<WSCurrencyUnits_Lang>)new HashSet<WSCurrencyUnits_Lang>();
		WSCurrencyUnits = (ICollection<WSCurrencyUnits>)new HashSet<WSCurrencyUnits>();
		WSDeliverySchedule_Lang = (ICollection<WSDeliverySchedule_Lang>)new HashSet<WSDeliverySchedule_Lang>();
		WSDeliveryScheduleExcept_Lang = (ICollection<WSDeliveryScheduleExcept_Lang>)new HashSet<WSDeliveryScheduleExcept_Lang>();
		WSDeliveryScheduleExcept = (ICollection<WSDeliveryScheduleExcept>)new HashSet<WSDeliveryScheduleExcept>();
		WSDeliveryTime_Lang = (ICollection<WSDeliveryTime_Lang>)new HashSet<WSDeliveryTime_Lang>();
		WSDeliveryTime = (ICollection<WSDeliveryTime>)new HashSet<WSDeliveryTime>();
		WSDiscountCode_Lang = (ICollection<WSDiscountCode_Lang>)new HashSet<WSDiscountCode_Lang>();
		WSDiscountCode = (ICollection<WSDiscountCode>)new HashSet<WSDiscountCode>();
		WSDiscountCodeHistory = (ICollection<WSDiscountCodeHistory>)new HashSet<WSDiscountCodeHistory>();
		WSDocOpr_Lang = (ICollection<WSDocOpr_Lang>)new HashSet<WSDocOpr_Lang>();
		WSDocOpr = (ICollection<WSDocOpr>)new HashSet<WSDocOpr>();
		WSFinancialPeriod = (ICollection<WSFinancialPeriod>)new HashSet<WSFinancialPeriod>();
		WSGuaranty_Lang = (ICollection<WSGuaranty_Lang>)new HashSet<WSGuaranty_Lang>();
		WSGuaranty = (ICollection<WSGuaranty>)new HashSet<WSGuaranty>();
		WSLinkedProducts = (ICollection<WSLinkedProducts>)new HashSet<WSLinkedProducts>();
		WSLogo_Lang = (ICollection<WSLogo_Lang>)new HashSet<WSLogo_Lang>();
		WSLogo = (ICollection<WSLogo>)new HashSet<WSLogo>();
		WSOrderCommissionPayTypes_Lang = (ICollection<WSOrderCommissionPayTypes_Lang>)new HashSet<WSOrderCommissionPayTypes_Lang>();
		WSOrderCommissionPayTypes = (ICollection<WSOrderCommissionPayTypes>)new HashSet<WSOrderCommissionPayTypes>();
		WSOrderDefaultSetting_Lang = (ICollection<WSOrderDefaultSetting_Lang>)new HashSet<WSOrderDefaultSetting_Lang>();
		WSOrderImportFromExcelFields_Lang = (ICollection<WSOrderImportFromExcelFields_Lang>)new HashSet<WSOrderImportFromExcelFields_Lang>();
		WSOrderImportFromExcelFields = (ICollection<WSOrderImportFromExcelFields>)new HashSet<WSOrderImportFromExcelFields>();
		WSOrderItemSerials_Lang = (ICollection<WSOrderItemSerials_Lang>)new HashSet<WSOrderItemSerials_Lang>();
		WSOrderItemSerials = (ICollection<WSOrderItemSerials>)new HashSet<WSOrderItemSerials>();
		WSOrderOpr_Lang = (ICollection<WSOrderOpr_Lang>)new HashSet<WSOrderOpr_Lang>();
		WSOrderOpr = (ICollection<WSOrderOpr>)new HashSet<WSOrderOpr>();
		WSOrderPaymentTypes_Lang = (ICollection<WSOrderPaymentTypes_Lang>)new HashSet<WSOrderPaymentTypes_Lang>();
		WSOrderStatus_Lang = (ICollection<WSOrderStatus_Lang>)new HashSet<WSOrderStatus_Lang>();
		WSOrderStatus = (ICollection<WSOrderStatus>)new HashSet<WSOrderStatus>();
		WSPayCondition_Lang = (ICollection<WSPayCondition_Lang>)new HashSet<WSPayCondition_Lang>();
		WSPayCondition = (ICollection<WSPayCondition>)new HashSet<WSPayCondition>();
		WSPreOrderCommissions_Lang = (ICollection<WSPreOrderCommissions_Lang>)new HashSet<WSPreOrderCommissions_Lang>();
		WSPreOrderCommissions = (ICollection<WSPreOrderCommissions>)new HashSet<WSPreOrderCommissions>();
		WSPreOrderDefaultSetting_Lang = (ICollection<WSPreOrderDefaultSetting_Lang>)new HashSet<WSPreOrderDefaultSetting_Lang>();
		WSPreOrderItemSpecification_Lang = (ICollection<WSPreOrderItemSpecification_Lang>)new HashSet<WSPreOrderItemSpecification_Lang>();
		WSPreOrderItemSpecification = (ICollection<WSPreOrderItemSpecification>)new HashSet<WSPreOrderItemSpecification>();
		WSPreOrderOpr_Lang = (ICollection<WSPreOrderOpr_Lang>)new HashSet<WSPreOrderOpr_Lang>();
		WSPreOrderOpr = (ICollection<WSPreOrderOpr>)new HashSet<WSPreOrderOpr>();
		WSPreOrderPrdGroupMustExistReasonGroups_Lang = (ICollection<WSPreOrderPrdGroupMustExistReasonGroups_Lang>)new HashSet<WSPreOrderPrdGroupMustExistReasonGroups_Lang>();
		WSPreOrderPrdGroupMustExistReasonGroups = (ICollection<WSPreOrderPrdGroupMustExistReasonGroups>)new HashSet<WSPreOrderPrdGroupMustExistReasonGroups>();
		WSPreOrderPrdGroupMustExistReasons_Lang = (ICollection<WSPreOrderPrdGroupMustExistReasons_Lang>)new HashSet<WSPreOrderPrdGroupMustExistReasons_Lang>();
		WSPreOrderPrdGroupMustExistReasons = (ICollection<WSPreOrderPrdGroupMustExistReasons>)new HashSet<WSPreOrderPrdGroupMustExistReasons>();
		WSPreOrderStatus_Lang = (ICollection<WSPreOrderStatus_Lang>)new HashSet<WSPreOrderStatus_Lang>();
		WSPreOrderStatus = (ICollection<WSPreOrderStatus>)new HashSet<WSPreOrderStatus>();
		WSPreOrderTypes_Lang = (ICollection<WSPreOrderTypes_Lang>)new HashSet<WSPreOrderTypes_Lang>();
		WSPreOrderTypes = (ICollection<WSPreOrderTypes>)new HashSet<WSPreOrderTypes>();
		WSProductColor_Lang = (ICollection<WSProductColor_Lang>)new HashSet<WSProductColor_Lang>();
		WSProductColor = (ICollection<WSProductColor>)new HashSet<WSProductColor>();
		WSProductCost_Lang = (ICollection<WSProductCost_Lang>)new HashSet<WSProductCost_Lang>();
		WSProductCost = (ICollection<WSProductCost>)new HashSet<WSProductCost>();
		WSProductCostGroup_Lang = (ICollection<WSProductCostGroup_Lang>)new HashSet<WSProductCostGroup_Lang>();
		WSProductCostGroup = (ICollection<WSProductCostGroup>)new HashSet<WSProductCostGroup>();
		WSProductFirstGroup_Lang = (ICollection<WSProductFirstGroup_Lang>)new HashSet<WSProductFirstGroup_Lang>();
		WSProductFirstGroup = (ICollection<WSProductFirstGroup>)new HashSet<WSProductFirstGroup>();
		WSProductGallery = (ICollection<WSProductGallery>)new HashSet<WSProductGallery>();
		WSProductGroupPicture = (ICollection<WSProductGroupPicture>)new HashSet<WSProductGroupPicture>();
		WSProductImportFromExcelFields_Lang = (ICollection<WSProductImportFromExcelFields_Lang>)new HashSet<WSProductImportFromExcelFields_Lang>();
		WSProductImportFromExcelFields = (ICollection<WSProductImportFromExcelFields>)new HashSet<WSProductImportFromExcelFields>();
		WSProductPicture_Lang = (ICollection<WSProductPicture_Lang>)new HashSet<WSProductPicture_Lang>();
		WSProductPicture = (ICollection<WSProductPicture>)new HashSet<WSProductPicture>();
		WSProductPrice_Lang = (ICollection<WSProductPrice_Lang>)new HashSet<WSProductPrice_Lang>();
		WSProductPrice = (ICollection<WSProductPrice>)new HashSet<WSProductPrice>();
		WSProductPriceGroup_Lang = (ICollection<WSProductPriceGroup_Lang>)new HashSet<WSProductPriceGroup_Lang>();
		WSProductPriceGroup = (ICollection<WSProductPriceGroup>)new HashSet<WSProductPriceGroup>();
		WSProductRelationLimit = (ICollection<WSProductRelationLimit>)new HashSet<WSProductRelationLimit>();
		WSProductRelationType_Lang = (ICollection<WSProductRelationType_Lang>)new HashSet<WSProductRelationType_Lang>();
		WSProductRelationType = (ICollection<WSProductRelationType>)new HashSet<WSProductRelationType>();
		WSProductSecondGroup_Lang = (ICollection<WSProductSecondGroup_Lang>)new HashSet<WSProductSecondGroup_Lang>();
		WSProductSecondGroup = (ICollection<WSProductSecondGroup>)new HashSet<WSProductSecondGroup>();
		WSProductShpStockManageTypes_Lang = (ICollection<WSProductShpStockManageTypes_Lang>)new HashSet<WSProductShpStockManageTypes_Lang>();
		WSProductShpStockManageTypes = (ICollection<WSProductShpStockManageTypes>)new HashSet<WSProductShpStockManageTypes>();
		WSProductSpecification_Lang = (ICollection<WSProductSpecification_Lang>)new HashSet<WSProductSpecification_Lang>();
		WSProductSpecification = (ICollection<WSProductSpecification>)new HashSet<WSProductSpecification>();
		WSProductsRate = (ICollection<WSProductsRate>)new HashSet<WSProductsRate>();
		WSProductsUserDiscount_Lang = (ICollection<WSProductsUserDiscount_Lang>)new HashSet<WSProductsUserDiscount_Lang>();
		WSProductsUserDiscount = (ICollection<WSProductsUserDiscount>)new HashSet<WSProductsUserDiscount>();
		WSProductUnits_Lang = (ICollection<WSProductUnits_Lang>)new HashSet<WSProductUnits_Lang>();
		WSProductUnits = (ICollection<WSProductUnits>)new HashSet<WSProductUnits>();
		WSRegisterBarCode = (ICollection<WSRegisterBarCode>)new HashSet<WSRegisterBarCode>();
		WSSaleCenters_Lang = (ICollection<WSSaleCenters_Lang>)new HashSet<WSSaleCenters_Lang>();
		WSSaleCenters = (ICollection<WSSaleCenters>)new HashSet<WSSaleCenters>();
		WSSettlementType_Lang = (ICollection<WSSettlementType_Lang>)new HashSet<WSSettlementType_Lang>();
		WSSettlementType = (ICollection<WSSettlementType>)new HashSet<WSSettlementType>();
		WSSignature = (ICollection<WSSignature>)new HashSet<WSSignature>();
		WSTmpEnterBarcodeOperation = (ICollection<WSTmpEnterBarcodeOperation>)new HashSet<WSTmpEnterBarcodeOperation>();
		WSTmpEnterDocPrdWithBarcode = (ICollection<WSTmpEnterDocPrdWithBarcode>)new HashSet<WSTmpEnterDocPrdWithBarcode>();
		WSUserFavproductItems_Lang = (ICollection<WSUserFavproductItems_Lang>)new HashSet<WSUserFavproductItems_Lang>();
		WSUserFavproductItems = (ICollection<WSUserFavproductItems>)new HashSet<WSUserFavproductItems>();
		WSUserFavproducts_Lang = (ICollection<WSUserFavproducts_Lang>)new HashSet<WSUserFavproducts_Lang>();
		WSUserFavproducts = (ICollection<WSUserFavproducts>)new HashSet<WSUserFavproducts>();
		WSVerificationRequestDetails_Lang = (ICollection<WSVerificationRequestDetails_Lang>)new HashSet<WSVerificationRequestDetails_Lang>();
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequests_Lang = (ICollection<WSVerificationRequests_Lang>)new HashSet<WSVerificationRequests_Lang>();
		WSVerificationRequests = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationWorkFlows_Lang = (ICollection<WSVerificationWorkFlows_Lang>)new HashSet<WSVerificationWorkFlows_Lang>();
		WSVerificationWorkFlows = (ICollection<WSVerificationWorkFlows>)new HashSet<WSVerificationWorkFlows>();
		WsWareHouse_Lang = (ICollection<WsWareHouse_Lang>)new HashSet<WsWareHouse_Lang>();
		WsWareHouse = (ICollection<WsWareHouse>)new HashSet<WsWareHouse>();
		WSWareHouseUserPermissions = (ICollection<WSWareHouseUserPermissions>)new HashSet<WSWareHouseUserPermissions>();
		CrmLinkAccShygunSettingDetails = (ICollection<CrmLinkAccShygunSettingDetails>)new HashSet<CrmLinkAccShygunSettingDetails>();
		CrmLinkAccShygunSettingDetails_Lang = (ICollection<CrmLinkAccShygunSettingDetails_Lang>)new HashSet<CrmLinkAccShygunSettingDetails_Lang>();
		CrmCompanyAddresses = (ICollection<CrmCompanyAddresses>)new HashSet<CrmCompanyAddresses>();
		CrmCompanyAddresses_Lang = (ICollection<CrmCompanyAddresses_Lang>)new HashSet<CrmCompanyAddresses_Lang>();
		CrmLinkAccPayvastSettingDetails = (ICollection<CrmLinkAccPayvastSettingDetails>)new HashSet<CrmLinkAccPayvastSettingDetails>();
		CrmLinkAccPayvastSettingDetails_Lang = (ICollection<CrmLinkAccPayvastSettingDetails_Lang>)new HashSet<CrmLinkAccPayvastSettingDetails_Lang>();
		CrmOnlinePayBankInfo = (ICollection<CrmOnlinePayBankInfo>)new HashSet<CrmOnlinePayBankInfo>();
		CrmOnlinePayBankInfo_Lang = (ICollection<CrmOnlinePayBankInfo_Lang>)new HashSet<CrmOnlinePayBankInfo_Lang>();
		EmailUsersInfo = (ICollection<EmailUsersInfo>)new HashSet<EmailUsersInfo>();
		CrmLinkAccNoAvIISetting = (ICollection<CrmLinkAccNoAvIISetting>)new HashSet<CrmLinkAccNoAvIISetting>();
		CrmLinkAccNoAvIISetting_Lang = (ICollection<CrmLinkAccNoAvIISetting_Lang>)new HashSet<CrmLinkAccNoAvIISetting_Lang>();
		CrmLinkAccShygunIISetting = (ICollection<CrmLinkAccShygunIISetting>)new HashSet<CrmLinkAccShygunIISetting>();
		CrmLinkAccShygunIISetting_Lang = (ICollection<CrmLinkAccShygunIISetting_Lang>)new HashSet<CrmLinkAccShygunIISetting_Lang>();
		CrmLinkAccShygunIISettingDetails = (ICollection<CrmLinkAccShygunIISettingDetails>)new HashSet<CrmLinkAccShygunIISettingDetails>();
		CrmLinkAccShygunIISettingDetails_Lang = (ICollection<CrmLinkAccShygunIISettingDetails_Lang>)new HashSet<CrmLinkAccShygunIISettingDetails_Lang>();
		CrmLinkAccChamberCommerceSetting = (ICollection<CrmLinkAccChamberCommerceSetting>)new HashSet<CrmLinkAccChamberCommerceSetting>();
		CrmLinkAccChamberCommerceSetting_Lang = (ICollection<CrmLinkAccChamberCommerceSetting_Lang>)new HashSet<CrmLinkAccChamberCommerceSetting_Lang>();
		CrmMenuModel = (ICollection<CrmMenuModel>)new HashSet<CrmMenuModel>();
		CrmMenuModel_Lang = (ICollection<CrmMenuModel_Lang>)new HashSet<CrmMenuModel_Lang>();
		SecLetterNumberCounter_Lang = (ICollection<SecLetterNumberCounter_Lang>)new HashSet<SecLetterNumberCounter_Lang>();
		SecLetterNumberCounter = (ICollection<SecLetterNumberCounter>)new HashSet<SecLetterNumberCounter>();
		CrmProjects_Lang = (ICollection<CrmProjects_Lang>)new HashSet<CrmProjects_Lang>();
		CrmCompanyCampaign = (ICollection<CrmCompanyCampaign>)new HashSet<CrmCompanyCampaign>();
		CrmCompanyCampaign_Lang = (ICollection<CrmCompanyCampaign_Lang>)new HashSet<CrmCompanyCampaign_Lang>();
		CrmProjectTitleGroups = (ICollection<CrmProjectTitleGroups>)new HashSet<CrmProjectTitleGroups>();
		CrmProjectTitleGroups_Lang = (ICollection<CrmProjectTitleGroups_Lang>)new HashSet<CrmProjectTitleGroups_Lang>();
		CrmDyFormFields = (ICollection<CrmDyFormFields>)new HashSet<CrmDyFormFields>();
		CrmDyFormFields_Lang = (ICollection<CrmDyFormFields_Lang>)new HashSet<CrmDyFormFields_Lang>();
		CrmCompanyMoneyBag = (ICollection<CrmCompanyMoneyBag>)new HashSet<CrmCompanyMoneyBag>();
		CrmCompanyMoneyBag_Lang = (ICollection<CrmCompanyMoneyBag_Lang>)new HashSet<CrmCompanyMoneyBag_Lang>();
		WSOrderPayments_Lang = (ICollection<WSOrderPayments_Lang>)new HashSet<WSOrderPayments_Lang>();
		WSOrderPayments = (ICollection<WSOrderPayments>)new HashSet<WSOrderPayments>();
		WSPreOrderPayments_Lang = (ICollection<WSPreOrderPayments_Lang>)new HashSet<WSPreOrderPayments_Lang>();
		WSPreOrderPayments = (ICollection<WSPreOrderPayments>)new HashSet<WSPreOrderPayments>();
		CrmConversationStatusResultEventPolicy = (ICollection<CrmConversationStatusResultEventPolicy>)new HashSet<CrmConversationStatusResultEventPolicy>();
		CrmConversationStatusResultEventPolicy_Lang = (ICollection<CrmConversationStatusResultEventPolicy_Lang>)new HashSet<CrmConversationStatusResultEventPolicy_Lang>();
		CrmConversationStatusGroups = (ICollection<CrmConversationStatusGroups>)new HashSet<CrmConversationStatusGroups>();
		CrmConversationStatusGroups_Lang = (ICollection<CrmConversationStatusGroups_Lang>)new HashSet<CrmConversationStatusGroups_Lang>();
		CrmCompanyAddressType = (ICollection<CrmCompanyAddressType>)new HashSet<CrmCompanyAddressType>();
		CrmCompanyAddressType_Lang = (ICollection<CrmCompanyAddressType_Lang>)new HashSet<CrmCompanyAddressType_Lang>();
		CrmBankingAccountType_Lang = (ICollection<CrmBankingAccountType_Lang>)new HashSet<CrmBankingAccountType_Lang>();
		CrmBankingBanks_Lang = (ICollection<CrmBankingBanks_Lang>)new HashSet<CrmBankingBanks_Lang>();
		CrmBankingBranches_Lang = (ICollection<CrmBankingBranches_Lang>)new HashSet<CrmBankingBranches_Lang>();
		PayRollList_Lang = (ICollection<PayRollList_Lang>)new HashSet<PayRollList_Lang>();
		PayRollList = (ICollection<PayRollList>)new HashSet<PayRollList>();
		PayRollListGroups_Lang = (ICollection<PayRollListGroups_Lang>)new HashSet<PayRollListGroups_Lang>();
		PayRollListGroups = (ICollection<PayRollListGroups>)new HashSet<PayRollListGroups>();
		PayRollListItems = (ICollection<PayRollListItems>)new HashSet<PayRollListItems>();
		CrmLeaveKinds_Lang = (ICollection<CrmLeaveKinds_Lang>)new HashSet<CrmLeaveKinds_Lang>();
		CrmLeaveStayType_Lang = (ICollection<CrmLeaveStayType_Lang>)new HashSet<CrmLeaveStayType_Lang>();
		CrmLeaveVehicleType_Lang = (ICollection<CrmLeaveVehicleType_Lang>)new HashSet<CrmLeaveVehicleType_Lang>();
		CrmBankingAccounts = (ICollection<CrmBankingAccounts>)new HashSet<CrmBankingAccounts>();
		CrmBankingAccounts_Lang = (ICollection<CrmBankingAccounts_Lang>)new HashSet<CrmBankingAccounts_Lang>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		TspSetting_Lang = (ICollection<TspSetting_Lang>)new HashSet<TspSetting_Lang>();
		TspSetting = (ICollection<TspSetting>)new HashSet<TspSetting>();
		WSOrderPaymentTypes = (ICollection<WSOrderPaymentTypes>)new HashSet<WSOrderPaymentTypes>();
		WSDeliverySchedule = (ICollection<WSDeliverySchedule>)new HashSet<WSDeliverySchedule>();
		CrmLinkAccShomaranSetting = (ICollection<CrmLinkAccShomaranSetting>)new HashSet<CrmLinkAccShomaranSetting>();
		CrmLinkAccShomaranSetting_Lang = (ICollection<CrmLinkAccShomaranSetting_Lang>)new HashSet<CrmLinkAccShomaranSetting_Lang>();
		CrmCompanyQuickRegisterDefSetting_Lang = (ICollection<CrmCompanyQuickRegisterDefSetting_Lang>)new HashSet<CrmCompanyQuickRegisterDefSetting_Lang>();
		WSOrderItems_Lang = (ICollection<WSOrderItems_Lang>)new HashSet<WSOrderItems_Lang>();
		WSOrderItems = (ICollection<WSOrderItems>)new HashSet<WSOrderItems>();
		WSPreOrderItems_Lang = (ICollection<WSPreOrderItems_Lang>)new HashSet<WSPreOrderItems_Lang>();
		WSPreOrderItems = (ICollection<WSPreOrderItems>)new HashSet<WSPreOrderItems>();
		WSTmpUserItemCopy = (ICollection<WSTmpUserItemCopy>)new HashSet<WSTmpUserItemCopy>();
		CrmProjectTitles = (ICollection<CrmProjectTitles>)new HashSet<CrmProjectTitles>();
		CrmProjectTitles_Lang = (ICollection<CrmProjectTitles_Lang>)new HashSet<CrmProjectTitles_Lang>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		CrmsysSetting_Lang = (ICollection<CrmsysSetting_Lang>)new HashSet<CrmsysSetting_Lang>();
		CrmLinkAccArpaSetting = (ICollection<CrmLinkAccArpaSetting>)new HashSet<CrmLinkAccArpaSetting>();
		CrmLinkAccArpaSetting_Lang = (ICollection<CrmLinkAccArpaSetting_Lang>)new HashSet<CrmLinkAccArpaSetting_Lang>();
		CrmCompany = (ICollection<CrmCompany>)new HashSet<CrmCompany>();
		CrmCompany_Lang = (ICollection<CrmCompany_Lang>)new HashSet<CrmCompany_Lang>();
		WSDeliveryTerms_Lang = (ICollection<WSDeliveryTerms_Lang>)new HashSet<WSDeliveryTerms_Lang>();
		WSDeliveryTerms = (ICollection<WSDeliveryTerms>)new HashSet<WSDeliveryTerms>();
		WSBuyOrderDefaultSetting_Lang = (ICollection<WSBuyOrderDefaultSetting_Lang>)new HashSet<WSBuyOrderDefaultSetting_Lang>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSStockSupply_Lang = (ICollection<WSStockSupply_Lang>)new HashSet<WSStockSupply_Lang>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		WSStockSupplyItems_Lang = (ICollection<WSStockSupplyItems_Lang>)new HashSet<WSStockSupplyItems_Lang>();
		WSStockSupplyItems = (ICollection<WSStockSupplyItems>)new HashSet<WSStockSupplyItems>();
		CrmConversationStatusSalesFunnelSteps = (ICollection<CrmConversationStatusSalesFunnelSteps>)new HashSet<CrmConversationStatusSalesFunnelSteps>();
		CrmConversationStatusSalesFunnelSteps_Lang = (ICollection<CrmConversationStatusSalesFunnelSteps_Lang>)new HashSet<CrmConversationStatusSalesFunnelSteps_Lang>();
		UserMoneyBag_Lang = (ICollection<UserMoneyBag_Lang>)new HashSet<UserMoneyBag_Lang>();
		UserMoneyBag = (ICollection<UserMoneyBag>)new HashSet<UserMoneyBag>();
		WSDiscountStrategy_Lang = (ICollection<WSDiscountStrategy_Lang>)new HashSet<WSDiscountStrategy_Lang>();
		WSDiscountStrategy = (ICollection<WSDiscountStrategy>)new HashSet<WSDiscountStrategy>();
		WSOrderDiscounts_Lang = (ICollection<WSOrderDiscounts_Lang>)new HashSet<WSOrderDiscounts_Lang>();
		WSOrderDiscounts = (ICollection<WSOrderDiscounts>)new HashSet<WSOrderDiscounts>();
		WSPreOrderDiscounts_Lang = (ICollection<WSPreOrderDiscounts_Lang>)new HashSet<WSPreOrderDiscounts_Lang>();
		WSPreOrderDiscounts = (ICollection<WSPreOrderDiscounts>)new HashSet<WSPreOrderDiscounts>();
		CrmUserTasks = (ICollection<CrmUserTasks>)new HashSet<CrmUserTasks>();
		CrmUserTasks_Lang = (ICollection<CrmUserTasks_Lang>)new HashSet<CrmUserTasks_Lang>();
		CrmTelegSetting = (ICollection<CrmTelegSetting>)new HashSet<CrmTelegSetting>();
		WSOrderCommissions_Lang = (ICollection<WSOrderCommissions_Lang>)new HashSet<WSOrderCommissions_Lang>();
		WSOrderCommissions = (ICollection<WSOrderCommissions>)new HashSet<WSOrderCommissions>();
		CrmCmsWidgetGroups = (ICollection<CrmCmsWidgetGroups>)new HashSet<CrmCmsWidgetGroups>();
		CrmCmsWidgetGroups_Lang = (ICollection<CrmCmsWidgetGroups_Lang>)new HashSet<CrmCmsWidgetGroups_Lang>();
		CrmCmsWidgets = (ICollection<CrmCmsWidgets>)new HashSet<CrmCmsWidgets>();
		CrmCmsWidgets_Lang = (ICollection<CrmCmsWidgets_Lang>)new HashSet<CrmCmsWidgets_Lang>();
		CrmLinkAccByViewSetting = (ICollection<CrmLinkAccByViewSetting>)new HashSet<CrmLinkAccByViewSetting>();
		CrmLinkAccByViewSetting_Lang = (ICollection<CrmLinkAccByViewSetting_Lang>)new HashSet<CrmLinkAccByViewSetting_Lang>();
		WSVerificationWorkFlowSteps_Lang = (ICollection<WSVerificationWorkFlowSteps_Lang>)new HashSet<WSVerificationWorkFlowSteps_Lang>();
		WSVerificationWorkFlowSteps = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WSOrder_Lang = (ICollection<WSOrder_Lang>)new HashSet<WSOrder_Lang>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmLinkAccHamrahanSetting = (ICollection<CrmLinkAccHamrahanSetting>)new HashSet<CrmLinkAccHamrahanSetting>();
		CrmLinkAccHamrahanSetting_Lang = (ICollection<CrmLinkAccHamrahanSetting_Lang>)new HashSet<CrmLinkAccHamrahanSetting_Lang>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting_Lang = (ICollection<CrmFoSetting_Lang>)new HashSet<CrmFoSetting_Lang>();
		PayRollItems_Lang = (ICollection<PayRollItems_Lang>)new HashSet<PayRollItems_Lang>();
		PayRollItems = (ICollection<PayRollItems>)new HashSet<PayRollItems>();
		CrmLinkAccHamrahanSettingDetails = (ICollection<CrmLinkAccHamrahanSettingDetails>)new HashSet<CrmLinkAccHamrahanSettingDetails>();
		CrmLinkAccHamrahanSettingDetails_Lang = (ICollection<CrmLinkAccHamrahanSettingDetails_Lang>)new HashSet<CrmLinkAccHamrahanSettingDetails_Lang>();
		CrmMobSetting = (ICollection<CrmMobSetting>)new HashSet<CrmMobSetting>();
		WSOrderGroups_Lang = (ICollection<WSOrderGroups_Lang>)new HashSet<WSOrderGroups_Lang>();
		WSOrderGroups = (ICollection<WSOrderGroups>)new HashSet<WSOrderGroups>();
		Centers = (ICollection<Centers>)new HashSet<Centers>();
		Centers_Lang = (ICollection<Centers_Lang>)new HashSet<Centers_Lang>();
		WSProductSpecificationFieldGroups_Lang = (ICollection<WSProductSpecificationFieldGroups_Lang>)new HashSet<WSProductSpecificationFieldGroups_Lang>();
		WSProductSpecificationFieldGroups = (ICollection<WSProductSpecificationFieldGroups>)new HashSet<WSProductSpecificationFieldGroups>();
		WSProductSpecificationFieldTypes_Lang = (ICollection<WSProductSpecificationFieldTypes_Lang>)new HashSet<WSProductSpecificationFieldTypes_Lang>();
		WSProductSpecificationFieldTypes = (ICollection<WSProductSpecificationFieldTypes>)new HashSet<WSProductSpecificationFieldTypes>();
		WSProductSpecificationFields_Lang = (ICollection<WSProductSpecificationFields_Lang>)new HashSet<WSProductSpecificationFields_Lang>();
		WSProductSpecificationFields = (ICollection<WSProductSpecificationFields>)new HashSet<WSProductSpecificationFields>();
		CrmCmsHomePageSectionItems = (ICollection<CrmCmsHomePageSectionItems>)new HashSet<CrmCmsHomePageSectionItems>();
		CrmFoSettingRegister = (ICollection<CrmFoSettingRegister>)new HashSet<CrmFoSettingRegister>();
		CrmFoSettingRegister_Lang = (ICollection<CrmFoSettingRegister_Lang>)new HashSet<CrmFoSettingRegister_Lang>();
		WSProductShpException_Lang = (ICollection<WSProductShpException_Lang>)new HashSet<WSProductShpException_Lang>();
		WSProductShpException = (ICollection<WSProductShpException>)new HashSet<WSProductShpException>();
		WSSaleAreas_Lang = (ICollection<WSSaleAreas_Lang>)new HashSet<WSSaleAreas_Lang>();
		WSSaleAreas = (ICollection<WSSaleAreas>)new HashSet<WSSaleAreas>();
		WSPreOrder_Lang = (ICollection<WSPreOrder_Lang>)new HashSet<WSPreOrder_Lang>();
		CrmConversationStatusResult = (ICollection<CrmConversationStatusResult>)new HashSet<CrmConversationStatusResult>();
		CrmConversationStatusResult_Lang = (ICollection<CrmConversationStatusResult_Lang>)new HashSet<CrmConversationStatusResult_Lang>();
		CrmCashes = (ICollection<CrmCashes>)new HashSet<CrmCashes>();
		CrmCashes_Lang = (ICollection<CrmCashes_Lang>)new HashSet<CrmCashes_Lang>();
		WSOrderPaymentGroupsI_Lang = (ICollection<WSOrderPaymentGroupsI_Lang>)new HashSet<WSOrderPaymentGroupsI_Lang>();
		WSOrderPaymentGroupsI = (ICollection<WSOrderPaymentGroupsI>)new HashSet<WSOrderPaymentGroupsI>();
		WSOrderPaymentGroupsII_Lang = (ICollection<WSOrderPaymentGroupsII_Lang>)new HashSet<WSOrderPaymentGroupsII_Lang>();
		WSOrderPaymentGroupsII = (ICollection<WSOrderPaymentGroupsII>)new HashSet<WSOrderPaymentGroupsII>();
		SmsSendDetail = (ICollection<SmsSendDetail>)new HashSet<SmsSendDetail>();
		WSProducts_Lang = (ICollection<WSProducts_Lang>)new HashSet<WSProducts_Lang>();
		WSProducts = (ICollection<WSProducts>)new HashSet<WSProducts>();
		WSProductImportFromExcel = (ICollection<WSProductImportFromExcel>)new HashSet<WSProductImportFromExcel>();
		CrmConversationStatus = (ICollection<CrmConversationStatus>)new HashSet<CrmConversationStatus>();
		CrmConversationStatus_Lang = (ICollection<CrmConversationStatus_Lang>)new HashSet<CrmConversationStatus_Lang>();
		CrmTimeAttendance = (ICollection<CrmTimeAttendance>)new HashSet<CrmTimeAttendance>();
		WSDoc_Lang = (ICollection<WSDoc_Lang>)new HashSet<WSDoc_Lang>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSDocItems_Lang = (ICollection<WSDocItems_Lang>)new HashSet<WSDocItems_Lang>();
		WSDocItems = (ICollection<WSDocItems>)new HashSet<WSDocItems>();
		WSDocItemSerials_Lang = (ICollection<WSDocItemSerials_Lang>)new HashSet<WSDocItemSerials_Lang>();
		WSDocItemSerials = (ICollection<WSDocItemSerials>)new HashSet<WSDocItemSerials>();
		ScoreRules_Lang = (ICollection<ScoreRules_Lang>)new HashSet<ScoreRules_Lang>();
		ScoreRules = (ICollection<ScoreRules>)new HashSet<ScoreRules>();
		Scores_Lang = (ICollection<Scores_Lang>)new HashSet<Scores_Lang>();
		Scores = (ICollection<Scores>)new HashSet<Scores>();
		CrmProjects = (ICollection<CrmProjects>)new HashSet<CrmProjects>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
		CrmCompanyQuickRegisterDefSetting = (ICollection<CrmCompanyQuickRegisterDefSetting>)new HashSet<CrmCompanyQuickRegisterDefSetting>();
		Users_Lang = (ICollection<Users_Lang>)new HashSet<Users_Lang>();
		Users3 = (ICollection<Users>)new HashSet<Users>();
	}
}
