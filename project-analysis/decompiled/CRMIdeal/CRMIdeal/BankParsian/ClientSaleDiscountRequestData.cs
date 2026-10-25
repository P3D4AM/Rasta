using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace CRMIdeal.BankParsian;

[Serializable]
[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[DataContract(Name = "ClientSaleDiscountRequestData", Namespace = "https://pec.Shaparak.ir/NewIPGServices/Sale/SaleService")]
public class ClientSaleDiscountRequestData : ClientSaleRequestData
{
	[OptionalField]
	private Product[] DiscountProductField;

	[DataMember(EmitDefaultValue = false)]
	public Product[] DiscountProduct
	{
		get
		{
			return DiscountProductField;
		}
		set
		{
			if (DiscountProductField != value)
			{
				DiscountProductField = value;
				RaisePropertyChanged("DiscountProduct");
			}
		}
	}
}
