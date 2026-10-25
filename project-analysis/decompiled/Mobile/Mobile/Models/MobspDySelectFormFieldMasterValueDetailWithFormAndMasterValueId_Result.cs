using System;

namespace Mobile.Models;

public class MobspDySelectFormFieldMasterValueDetailWithFormAndMasterValueId_Result
{
	public int FormFieldMasterValueDetailId { get; set; }

	public int MasterValueId { get; set; }

	public int FormId { get; set; }

	public bool? IsDeleted { get; set; }

	public bool? IsChecked { get; set; }

	public int? CheckerUserId { get; set; }

	public DateTime? CheckedDate { get; set; }

	public string CheckedDatePersian { get; set; }

	public int FirstRegisterUserId { get; set; }

	public DateTime FirstRegisterDate { get; set; }

	public string FirstRegisterDatePersian { get; set; }

	public int UserId { get; set; }

	public DateTime RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public string AppType { get; set; }

	public int LanguageID { get; set; }
}
