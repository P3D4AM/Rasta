using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectProductSpecificationFieldGroups_Result
{
	public int SpecificationFieldGroupID { get; set; }

	public string FieldGroupTitle { get; set; }

	public bool? FieldGroupInActive { get; set; }

	public int? OrderView { get; set; }

	public int? UserId { get; set; }

	public string EditUser { get; set; }

	public DateTime? RegisterDate { get; set; }

	public string RegisterDatePersian { get; set; }

	public int? FieldGroupCId { get; set; }

	public string FieldGroupCenter { get; set; }
}
