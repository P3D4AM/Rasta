using System;

namespace Mobile.Models;

public class WSspSelectProductUnits_Result
{
	public int ProductUnitID { get; set; }

	public string Unit { get; set; }

	public int? QuantityInUnit { get; set; }

	public string Description { get; set; }

	public int UserId { get; set; }

	public short Month1 { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string UnitEn { get; set; }

	public Guid? GUId { get; set; }

	public double? FCR { get; set; }

	public string AppType { get; set; }

	public int? LanguageID { get; set; }

	public int? FirstRegisterUserId { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public DateTime? FirstRegisterDate { get; set; }

	public string FirstRegisterUser { get; set; }

	public string EditUser { get; set; }

	public double? FCRI { get; set; }

	public string SHPUnit { get; set; }
}
