using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WSVerificationWorkFlowsMetadata))]
public class WSVerificationWorkFlows
{
	public int VerificationWorkFlowId { get; set; }

	public int? ObjectType { get; set; }

	public string VerificationWorkFlowTitle { get; set; }

	public string VerifyRequestText { get; set; }

	public bool SequenceObservation { get; set; }

	public bool IsActive { get; set; }

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

	public virtual Languages Languages { get; set; }

	public virtual ICollection<WSVerificationRequestDetails> WSVerificationRequestDetails { get; set; }

	public virtual ICollection<WSVerificationRequests> WSVerificationRequests { get; set; }

	public virtual ICollection<WSVerificationWorkFlows_Lang> WSVerificationWorkFlows_Lang { get; set; }

	public virtual ICollection<CrmDyFormFieldMasterValues> CrmDyFormFieldMasterValues { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments { get; set; }

	public virtual ICollection<UserDepartments> UserDepartments1 { get; set; }

	public virtual ICollection<CrmLeave> CrmLeave { get; set; }

	public virtual ICollection<CrmDyForms> CrmDyForms { get; set; }

	public virtual ICollection<WSPreOrder> WSPreOrder { get; set; }

	public virtual ICollection<CrmsysSetting> CrmsysSetting { get; set; }

	public virtual ICollection<WSBuyOrder> WSBuyOrder { get; set; }

	public virtual ICollection<WSBuyOrderDefaultSetting> WSBuyOrderDefaultSetting { get; set; }

	public virtual ICollection<WSStockSupply> WSStockSupply { get; set; }

	public virtual ICollection<SecLetterDefaultSettings> SecLetterDefaultSettings { get; set; }

	public virtual ICollection<SecLetters> SecLetters { get; set; }

	public virtual ICollection<WSVerificationWorkFlowSteps> WSVerificationWorkFlowSteps { get; set; }

	public virtual ICollection<WSOrder> WSOrder { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting { get; set; }

	public virtual ICollection<CrmFoSetting> CrmFoSetting1 { get; set; }

	public virtual ICollection<CrmFund> CrmFund { get; set; }

	public virtual ICollection<CrmFundGroups> CrmFundGroups { get; set; }

	public virtual ICollection<WSDoc> WSDoc { get; set; }

	public virtual ICollection<WSOrderDefaultSetting> WSOrderDefaultSetting { get; set; }

	public virtual ICollection<WSPreOrderDefaultSetting> WSPreOrderDefaultSetting { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public WSVerificationWorkFlows()
	{
		WSVerificationRequestDetails = (ICollection<WSVerificationRequestDetails>)new HashSet<WSVerificationRequestDetails>();
		WSVerificationRequests = (ICollection<WSVerificationRequests>)new HashSet<WSVerificationRequests>();
		WSVerificationWorkFlows_Lang = (ICollection<WSVerificationWorkFlows_Lang>)new HashSet<WSVerificationWorkFlows_Lang>();
		CrmDyFormFieldMasterValues = (ICollection<CrmDyFormFieldMasterValues>)new HashSet<CrmDyFormFieldMasterValues>();
		UserDepartments = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		UserDepartments1 = (ICollection<UserDepartments>)new HashSet<UserDepartments>();
		CrmLeave = (ICollection<CrmLeave>)new HashSet<CrmLeave>();
		CrmDyForms = (ICollection<CrmDyForms>)new HashSet<CrmDyForms>();
		WSPreOrder = (ICollection<WSPreOrder>)new HashSet<WSPreOrder>();
		CrmsysSetting = (ICollection<CrmsysSetting>)new HashSet<CrmsysSetting>();
		WSBuyOrder = (ICollection<WSBuyOrder>)new HashSet<WSBuyOrder>();
		WSBuyOrderDefaultSetting = (ICollection<WSBuyOrderDefaultSetting>)new HashSet<WSBuyOrderDefaultSetting>();
		WSStockSupply = (ICollection<WSStockSupply>)new HashSet<WSStockSupply>();
		SecLetterDefaultSettings = (ICollection<SecLetterDefaultSettings>)new HashSet<SecLetterDefaultSettings>();
		SecLetters = (ICollection<SecLetters>)new HashSet<SecLetters>();
		WSVerificationWorkFlowSteps = (ICollection<WSVerificationWorkFlowSteps>)new HashSet<WSVerificationWorkFlowSteps>();
		WSOrder = (ICollection<WSOrder>)new HashSet<WSOrder>();
		CrmFoSetting = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFoSetting1 = (ICollection<CrmFoSetting>)new HashSet<CrmFoSetting>();
		CrmFund = (ICollection<CrmFund>)new HashSet<CrmFund>();
		CrmFundGroups = (ICollection<CrmFundGroups>)new HashSet<CrmFundGroups>();
		WSDoc = (ICollection<WSDoc>)new HashSet<WSDoc>();
		WSOrderDefaultSetting = (ICollection<WSOrderDefaultSetting>)new HashSet<WSOrderDefaultSetting>();
		WSPreOrderDefaultSetting = (ICollection<WSPreOrderDefaultSetting>)new HashSet<WSPreOrderDefaultSetting>();
	}
}
