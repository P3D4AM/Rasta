using System.Collections.Generic;

namespace Mobile.Models;

public class LoadUserTasksResultViewModel
{
	public List<MobspLoadUserTasks_Result> UserTasks { get; set; }

	public List<MobspSelectUserTasksRepeats_Result> Repeats { get; set; }
}
