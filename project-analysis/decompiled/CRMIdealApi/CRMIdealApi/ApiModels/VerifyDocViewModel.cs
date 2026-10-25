using System;

namespace CRMIdealApi.ApiModels;

public class VerifyDocViewModel
{
	public string UserName { get; set; }

	public string Password { get; set; }

	public int ApiDocId { get; set; }

	public int ApiVerifierUserId { get; set; }

	public DateTime ApiVerifyDate { get; set; }

	public int? LanguageId { get; set; }
}
