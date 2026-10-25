namespace CRM.Models.ViewModel.FormBase;

public class CrmShiftWorkingLanguageViewModel
{
	public int ShiftWorkingId { get; set; }

	public string swTitle { get; set; }

	public int? OrderView { get; set; }

	public int? swMaxSoonEntryTime { get; set; }

	public int? swMaxLateExitTime { get; set; }

	public int? swMaxLateEntryTime { get; set; }

	public int? swMaxSoonExitTime { get; set; }

	public int? swMaxIsCloseDurationTime { get; set; }

	public string swTitle_Lang { get; set; }
}
