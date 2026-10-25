using System;

namespace CRM.Models;

public class PayRollspPrintListItems_Result
{
	public int PayRollListItemId { get; set; }

	public int PayRollListId { get; set; }

	public int CycleId { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public int PayRollUserCycleId { get; set; }

	public int CrmUserId { get; set; }

	public string CycleTitle { get; set; }

	public int? CycleDuration { get; set; }

	public DateTime CycleDate { get; set; }

	public string CycleDatePersian { get; set; }

	public bool? CycleIsVerified { get; set; }

	public int? CycleVerifierUserId { get; set; }

	public DateTime? CycleVerifiedDate { get; set; }

	public string CycleVerifiedDatePersian { get; set; }

	public int? CyclePrintFormatId { get; set; }

	public string CrmUser { get; set; }

	public string CycleVerifierUser { get; set; }

	public string CyclePrintFormat { get; set; }

	public decimal? CycleNetSalary { get; set; }

	public int? CycleDefBankingAccountId { get; set; }

	public string CycleDefBankingAccountTitle { get; set; }

	public string CycleDefBankingAccountNumber { get; set; }

	public string CycleDefBankingAccountShabaNumber { get; set; }

	public string CycleDefBankingAccountCardNumber { get; set; }

	public int? CycleMonth { get; set; }

	public int? CycleYear { get; set; }

	public decimal? IncSumAmount { get; set; }

	public decimal? DecSumAmount { get; set; }

	public decimal? SumAmount { get; set; }

	public decimal? AllSumPay { get; set; }

	public decimal? AllPayRemain { get; set; }

	public string CrmUserPersCode { get; set; }

	public string CrmUserTel { get; set; }

	public string CrmUserTelDesc { get; set; }

	public string CrmUserMobile { get; set; }

	public string CrmUserMobileII { get; set; }

	public string CrmUserAddress { get; set; }

	public string CrmUserFatherName { get; set; }

	public string CrmUserNationalCode { get; set; }

	public string CrmUserIdentityNumber { get; set; }

	public string CrmUserInsuranceCode { get; set; }

	public DateTime? CrmUserStartDate { get; set; }

	public string CrmUserStartDatePersian { get; set; }

	public DateTime? CrmUserExpireDate { get; set; }

	public string CrmUserExpireDatePersian { get; set; }

	public string CrmResponsibleUser { get; set; }

	public string CrmUserDepartment { get; set; }

	public string CrmUserPosition { get; set; }

	public string CrmUserGroup { get; set; }
}
