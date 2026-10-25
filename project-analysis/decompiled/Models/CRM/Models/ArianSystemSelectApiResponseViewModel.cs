using System.Collections.Generic;

namespace CRM.Models;

public class ArianSystemSelectApiResponseViewModel
{
	public string Err { get; set; }

	public long? TotalCount { get; set; }

	public List<List<object>> rows { get; set; }

	public List<ArianSystemSelectApiColumnInfoViewModel> cols { get; set; }

	public List<List<object>> defcols { get; set; }

	public string key { get; set; }

	public object ReqFields { get; set; }

	public object AutoNumbers { get; set; }

	public object CanAutoNumbers { get; set; }

	public object ColumnsLangInfo { get; set; }

	public ArianSystemSelectApiOtherInfoViewModel OtherInfo { get; set; }

	public object DefOrders { get; set; }
}
