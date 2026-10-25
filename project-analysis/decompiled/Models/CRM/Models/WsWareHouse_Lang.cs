using System.ComponentModel.DataAnnotations;

namespace CRM.Models;

[MetadataType(typeof(WsWareHouse_LangMetadata))]
public class WsWareHouse_Lang
{
	public int WsWareHouseLangID { get; set; }

	public int WareHouseID { get; set; }

	public int LanguageID { get; set; }

	public string WrhsName { get; set; }

	public string WrhsAddress { get; set; }

	public string WrhsArea { get; set; }

	public string WrhsPerson { get; set; }

	public string WrhsDescription { get; set; }

	public virtual Languages Languages { get; set; }

	public virtual WsWareHouse WsWareHouse { get; set; }
}
