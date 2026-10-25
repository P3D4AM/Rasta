namespace CRMIdealApi.ApiModels.ViewModel.BaseInfo;

public class InsertProjectTitleViewModel : PublicParametersWithOutCenter
{
	public string ApiProjectTitle { get; set; }

	public int? ApiProjectTitleGroupId { get; set; }

	public int? ApiProjectTitleStatusGroupId { get; set; }

	public int? ApiProjectTitleGradeId { get; set; }

	public int? ApiProjectTitlePriorityId { get; set; }

	public string ApiProjectTitleDesc { get; set; }

	public bool? ApiActivePrjNumRWithTitle { get; set; }

	public int? ApiPrjTitleGroupId { get; set; }

	public int? ApiPrjRemindDay { get; set; }

	public bool? ApiPrjFOCmpCanSee { get; set; }

	public bool? ApiPrjIsTicket { get; set; }

	public string ApiPrjPostFix { get; set; }
}
