using System.Collections.Generic;
using Kendo.Mvc.UI;

namespace CRM.Models;

public class CurrentCompanyViewModel
{
	public mct_CrmCompany_Result Company { get; set; }

	public List<MultiGroupItem> CompanyMultiGroup { get; set; }

	public int CurrentId { get; set; }

	public int NextId { get; set; }

	public int PreviousId { get; set; }

	public int FirstId { get; set; }

	public int LastId { get; set; }

	public string Message { get; set; }

	public bool IsFind { get; set; }

	public List<CrmCompanyPersonViewModel> Persons { get; set; }

	public List<TreeViewItemModel> Project { get; set; }

	public string ProjectActive { get; set; }

	public string ProjectArchive { get; set; }

	public List<CRMspSelectCompanyOperationsWeb_Result> Conversation { get; set; }

	public CompanyAccountingSummaryViewModel Accounting { get; set; }

	public bool CurrentProjectInArchive { get; set; }

	public string cmpLinkAccCode { get; set; }

	public string cmpLinkAccCustomerIdStr { get; set; }

	public string cmpLinkAccFirstTransferDateStr { get; set; }

	public string cmpLinkAccLastTransferDateStr { get; set; }

	public string cmpLinkAccData { get; set; }

	public string LinkAccSettingDB { get; set; }

	public string cmpLinkAccAllPayRemain { get; set; }

	public string CompanyMultiGroupInSummary { get; set; }

	public string cmpTelInSummary { get; set; }

	public string cmpTelIIInSummary { get; set; }

	public string cmpFaxInSummary { get; set; }

	public string cmpAddressInSummary { get; set; }

	public bool cmpHasLogo { get; set; }

	public CompanyAccountingSummaryViewModel AccountingInSummary { get; set; }

	public List<CrmCompanyPersonViewModel> PersonsInSummary { get; set; }

	public List<CRMspDySelectFormsMenuWithSysPartId_Result> PersonDyFormInSummary { get; set; }

	public List<CRMspSelectCompanyProjects_Result> ProjectsInSummary { get; set; }

	public string cmpCampaignIds { get; set; }

	public string cmpCampaignIdsList { get; set; }

	public string ProjectTicketTotal { get; set; }

	public string ProjectTicketAll { get; set; }

	public string ProjectTicketActive { get; set; }

	public string ProjectTicketArchive { get; set; }

	public bool ProjectIsTicket { get; set; }

	public CRMspReturnSumCompanyScores_Result SumCompanyScores { get; set; }

	public bool Taxable { get; set; }

	public bool IsHaveOrderOprExceptTspCmp { get; set; }

	public decimal? CmpMoneyBagAmount { get; set; }

	public string cmpFOInfoJson { get; set; }
}
