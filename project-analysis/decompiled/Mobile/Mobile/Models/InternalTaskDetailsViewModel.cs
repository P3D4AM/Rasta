using System.Collections.Generic;

namespace Mobile.Models;

public class InternalTaskDetailsViewModel
{
	public MobspIntMsgSelectMessageInType_Result Detail;

	public List<MobspIntMsgSelectMessageFiles_Result> FileList;

	public List<MobspIntMsgGetToUsersInfo_Result> ReceiverList;
}
