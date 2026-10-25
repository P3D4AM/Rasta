using System.Collections.Generic;

namespace CRM.Models;

public class LoadIntMsgInfoViewModel
{
	public CRMspIntMsgSelectMessageInType_Result InternalMessageInfo { get; set; }

	public List<CRMspIntMsgSelectMessageFiles_Result> InternalMessageFiles { get; set; }

	public List<CRMspIntMsgGetToUsersInfo_Result> InternalMessageToUsersInfo { get; set; }
}
