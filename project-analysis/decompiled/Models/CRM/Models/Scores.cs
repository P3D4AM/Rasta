using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(ScoresMetadata))]
public class Scores
{
	public int ScoreId { get; set; }

	public DateTime ScoreDate { get; set; }

	public string ScoreDatePersian { get; set; }

	public double Score { get; set; }

	public int? ScoreRuleId { get; set; }

	public int? ScoreOrderId { get; set; }

	public int? ScoreCmpId { get; set; }

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

	public int? ScoreSysPartId { get; set; }

	public int? ScoreObjectId { get; set; }

	public int? ScoreOprType { get; set; }

	public DateTime? ScoreExpireDate { get; set; }

	public string ScoreExpireDatePersian { get; set; }

	public bool? ScoreIsExpired { get; set; }

	public string ScoreDescription { get; set; }

	public int? ScoreKind { get; set; }

	public int? ScoreUserId { get; set; }

	public int? DisCodeRuleId { get; set; }

	public int? ScoreCId { get; set; }

	public virtual Centers Centers { get; set; }

	public virtual CrmCompany CrmCompany { get; set; }

	public virtual CrmSystemParts CrmSystemParts { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual ScoreRules ScoreRules { get; set; }

	public virtual ICollection<Scores_Lang> Scores_Lang { get; set; }

	public virtual WSOrder WSOrder { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public Scores()
	{
		Scores_Lang = (ICollection<Scores_Lang>)new HashSet<Scores_Lang>();
	}
}
