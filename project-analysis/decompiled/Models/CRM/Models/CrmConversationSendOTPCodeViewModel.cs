using System;

namespace CRM.Models;

public class CrmConversationSendOTPCodeViewModel
{
	public int ConversationID { get; set; }

	public int? cnvsProjectId { get; set; }

	public int cnvsCompanyId { get; set; }

	public string cnvsDesc { get; set; }

	public int? cnvsPersonId { get; set; }

	public int? cnvsFirstRegisterUserId { get; set; }

	public int? cnvsUserId { get; set; }

	public int? cnvsReferUserId { get; set; }

	public string CnvsMultiReferUserIds { get; set; }

	public string cnvsRemindDate { get; set; }

	public DateTime? cnvsRemindDateTime { get; set; }

	public string cnvsRemindTime { get; set; }

	public string cnvsRemindDateForAllarm { get; set; }

	public DateTime? cnvsRemindDateForAllarmTime { get; set; }

	public int? cnvsStatusResultId { get; set; }

	public string PrjPrdHisPrdNameJson { get; set; }

	public int? CmpKind { get; set; }

	public int? CmpReferUserId { get; set; }

	public int? CmpSuppUserId { get; set; }

	public int? CmpTitleId { get; set; }

	public string CmpName { get; set; }

	public string CmpPreTel { get; set; }

	public string CmpTel { get; set; }

	public string CmpAddress { get; set; }

	public string CmpMobile { get; set; }

	public string CmpEmail { get; set; }

	public int? PrsTitleId { get; set; }

	public string PrsFName { get; set; }

	public string PrsLName { get; set; }

	public string PrsMobile { get; set; }

	public string PrsEmail { get; set; }

	public string PrjTitle { get; set; }

	public int? PrjGroupId { get; set; }

	public int? PrjGradeId { get; set; }

	public int? PrjPriorityId { get; set; }

	public string PrjPostFix { get; set; }

	public string PrjRemindDateStr { get; set; }

	public DateTime? PrjRemindDate { get; set; }

	public string PrjTitleGroup { get; set; }

	public string PrjNumRef { get; set; }

	public string cnvsDesc_Lang { get; set; }
}
