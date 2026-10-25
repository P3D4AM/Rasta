namespace CRM.Models;

public class CmpSetFieldStatusViewModel
{
	public bool? CantSaveDupPrsMob { get; set; }

	public bool? CantSaveDupPrsEmail { get; set; }

	public bool? MustFullcnvsRemindDate { get; set; }

	public bool? DisablefrmcmpSearchOnType { get; set; }

	public bool? CantSaveDupTel { get; set; }

	public bool? CantSaveDupFax { get; set; }

	public bool? CantSaveDupZipCode { get; set; }

	public bool? CantSaveDupPrsNationalCode { get; set; }

	public bool? CantSaveDupCmpNationalCode { get; set; }

	public bool? CantSaveDupCmpEconomicCode { get; set; }

	public bool? MustFullPrsNationalCode { get; set; }

	public bool? MustFullCmpMainPrsNationalCode { get; set; }

	public bool? CantSaveDupCmpMainPrsNationalCode { get; set; }

	public bool? cmpQNotNullProjectGroup { get; set; }

	public bool? cmpQNotNullProjectGrade { get; set; }

	public bool? cmpQNotNullProjectPriority { get; set; }

	public bool? cmpQDefPrintAfterSave { get; set; }

	public int? MobNumLen { get; set; }

	public bool? MobNumLenNoCheck { get; set; }
}
