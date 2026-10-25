using System;

namespace CRM.Models;

public class ScorespSelectCompanyScores_Result
{
	public int ScoreId { get; set; }

	public DateTime? ScoreDate { get; set; }

	public string ScoreDatePersian { get; set; }

	public double? Score { get; set; }

	public int? ScoreRuleId { get; set; }

	public string ScoreRuleTitle { get; set; }

	public int? ScoreOrderId { get; set; }

	public string ScoreOrderInfo { get; set; }

	public int? ScoreCmpId { get; set; }

	public string ScoreCmpName { get; set; }

	public int? OrderView { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int? UserId { get; set; }

	public short? Year1 { get; set; }

	public short? Month1 { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? ScoreSysPartId { get; set; }

	public string ScoreSysPartTitle { get; set; }

	public int? ScoreObjectId { get; set; }

	public string ScoreObjectInfo { get; set; }

	public int? ScoreOprType { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public DateTime? ScoreExpireDate { get; set; }

	public string ScoreExpireDatePersian { get; set; }

	public bool? ScoreIsExpired { get; set; }

	public long? RowNumber { get; set; }

	public int? AllPage { get; set; }

	public string ScoreOprTypeTitle { get; set; }

	public string ScoreDesc { get; set; }

	public string ScoreDescription { get; set; }
}
