using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(UserLoginAllowedTimesMetadata))]
public class UserLoginAllowedTimes
{
	public int UserLoginAllowedTimeId { get; set; }

	public int crmUserId { get; set; }

	public int? DayNumber { get; set; }

	public string FTime { get; set; }

	public string TTime { get; set; }

	public string FDatePersian { get; set; }

	public DateTime? FDatetime { get; set; }

	public string TDatePersian { get; set; }

	public DateTime? TDatetime { get; set; }

	public string IPAddress { get; set; }

	public int FirstUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public short Year1 { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid GUId { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual Users Users { get; set; }

	public virtual Users Users1 { get; set; }

	public virtual Users Users2 { get; set; }

	public virtual Users Users3 { get; set; }
}
