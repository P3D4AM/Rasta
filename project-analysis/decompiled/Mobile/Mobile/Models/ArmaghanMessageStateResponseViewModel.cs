using System.Collections.Generic;

namespace Mobile.Models;

public class ArmaghanMessageStateResponseViewModel
{
	public ArmaghanErrorResponseViewModel errorModel { get; set; }

	public List<ArmaghanMessageStateResultesponseViewModel> states { get; set; }
}
