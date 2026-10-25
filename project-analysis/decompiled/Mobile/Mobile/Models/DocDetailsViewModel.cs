using System.Collections.Generic;

namespace Mobile.Models;

public class DocDetailsViewModel
{
	public MobspSelectDocs_Result Doc { get; set; }

	public List<MobspSelectDocItems_Result> DocItems { get; set; }

	public List<MobspSelectDocItemSerials_Result> DocItemSerials { get; set; }

	public List<MobspIntMsgGetByTypeAndAttachRecId_Result> InternalMsg { get; set; }

	public List<DocItemPrdQuantityViewModel> ItemsPrdQuantity { get; set; }

	public List<MobspReturnOrderFromDoc_Result> OrderList { get; set; }
}
