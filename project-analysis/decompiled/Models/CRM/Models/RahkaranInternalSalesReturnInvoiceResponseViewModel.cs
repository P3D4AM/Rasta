using System;
using System.Collections.Generic;

namespace CRM.Models;

public class RahkaranInternalSalesReturnInvoiceResponseViewModel
{
	public decimal? Additions { get; set; }

	public long? DeliveryAddressRef { get; set; }

	public int? DeliveryAddressType { get; set; }

	public string DeliveryAddressTypeTitle { get; set; }

	public string Description { get; set; }

	public long? ID { get; set; }

	public decimal? NetPrice { get; set; }

	public decimal? Price { get; set; }

	public decimal? Reductions { get; set; }

	public long? BrokerRef { get; set; }

	public long? ContractRef { get; set; }

	public string CreationDate { get; set; }

	public long? Creator { get; set; }

	public long? CurrencyRef { get; set; }

	public long? CustomerRef { get; set; }

	public DateTime? Date { get; set; }

	public DateTime? ExpirationDate { get; set; }

	public int? ExpirationDuration { get; set; }

	public long? InventoryRef { get; set; }

	public List<RahkaranInternalSalesReturnInvoiceItemResponseViewModel> Items { get; set; }

	public string LastModificationDate { get; set; }

	public string Number { get; set; }

	public decimal? OperationalCurrencyExchangeRate { get; set; }

	public bool? OperationalCurrencyExchangeRateIsReversed { get; set; }

	public long? OperationalCurrencyExchangeRateRef { get; set; }

	public long? PayerAccountRef { get; set; }

	public int? PayerTypeCode { get; set; }

	public string PayerTypeTitle { get; set; }

	public long? PaymentAgreementRef { get; set; }

	public long? PlantRef { get; set; }

	public List<RahkaranInternalSalesReturnInvoicePoliciesResponseViewModel> Policies { get; set; }

	public long? SalesAreaRef { get; set; }

	public long? SalesOfficeRef { get; set; }

	public long? SalesTypeRef { get; set; }

	public int? State { get; set; }
}
