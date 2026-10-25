using System;

namespace Mobile.Models;

public class WSspSelectFinancialPeriod_Result
{
	public int ID { get; set; }

	public string Name { get; set; }

	public string FDate { get; set; }

	public string TDate { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public Guid? GUId { get; set; }

	public short? Year1 { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }
}
