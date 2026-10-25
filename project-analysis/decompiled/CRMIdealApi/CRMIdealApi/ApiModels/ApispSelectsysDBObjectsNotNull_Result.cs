using System;

namespace CRMIdealApi.ApiModels;

public class ApispSelectsysDBObjectsNotNull_Result
{
	public int ApiDBObjectId { get; set; }

	public string ApiDBObjectName { get; set; }

	public string ApiFieldName { get; set; }

	public string ApiFieldTitle { get; set; }

	public bool? ApiNotNull { get; set; }

	public int? ApiOrderView { get; set; }

	public int? ApiFirstRegisterUserId { get; set; }

	public DateTime? ApiFirstRegisterDate { get; set; }

	public string ApiFirstRegisterUser { get; set; }
}
