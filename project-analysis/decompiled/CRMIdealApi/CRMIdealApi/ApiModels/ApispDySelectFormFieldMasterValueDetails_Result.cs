using System;

namespace CRMIdealApi.ApiModels;

public class ApispDySelectFormFieldMasterValueDetails_Result
{
	public int? ApiCompanyId { get; set; }

	public string ApiCompany { get; set; }

	public int? ApiCompanyPersonId { get; set; }

	public string ApiCompanyPerson { get; set; }

	public int? ApiProjectId { get; set; }

	public string ApiProject { get; set; }

	public int? ApiConversationId { get; set; }

	public string ApiCnvsDesc { get; set; }

	public string ApiCnvsTopic { get; set; }

	public string ApiCnvsDate { get; set; }

	public DateTime? ApiCnvsDateTime { get; set; }

	public int? ApiMasterObjectId { get; set; }

	public string ApiMasterObjectInfo { get; set; }

	public string ApiMasterObjectDate { get; set; }

	public DateTime? ApiMasterObjectDateTime { get; set; }

	public int? ApiDetailObjectId { get; set; }

	public int? ApiSubDetailObjectId { get; set; }
}
