using System.Collections.Generic;

namespace Mobile.Models;

public class FoLoadFullFormResult
{
	public List<FOMobspDySelectFormAndSubForms_Result> Forms { get; set; }

	public List<FOMobspDySelectFormFieldsByParentFormId_Result> Fields { get; set; }
}
