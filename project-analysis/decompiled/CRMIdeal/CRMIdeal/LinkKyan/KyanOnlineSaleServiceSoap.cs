using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CRMIdeal.LinkKyan;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(Namespace = "KyanOnlineSaleService", ConfigurationName = "LinkKyan.KyanOnlineSaleServiceSoap")]
public interface KyanOnlineSaleServiceSoap
{
	[OperationContract(Action = "KyanOnlineSaleService/AuthenticationUser", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AuthenticationUserResponse AuthenticationUser(AuthenticationUserRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/AuthenticationUser", ReplyAction = "*")]
	Task<AuthenticationUserResponse> AuthenticationUserAsync(AuthenticationUserRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/InputPermission", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	InputPermissionResponse InputPermission(InputPermissionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/InputPermission", ReplyAction = "*")]
	Task<InputPermissionResponse> InputPermissionAsync(InputPermissionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemListResponse GetItemList(GetItemListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemList", ReplyAction = "*")]
	Task<GetItemListResponse> GetItemListAsync(GetItemListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoResponse GetItemInfo(GetItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfo", ReplyAction = "*")]
	Task<GetItemInfoResponse> GetItemInfoAsync(GetItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithItemID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoWithItemIDResponse GetItemInfoWithItemID(GetItemInfoWithItemIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithItemID", ReplyAction = "*")]
	Task<GetItemInfoWithItemIDResponse> GetItemInfoWithItemIDAsync(GetItemInfoWithItemIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithGroupID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoWithGroupIDResponse GetItemInfoWithGroupID(GetItemInfoWithGroupIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithGroupID", ReplyAction = "*")]
	Task<GetItemInfoWithGroupIDResponse> GetItemInfoWithGroupIDAsync(GetItemInfoWithGroupIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsInformationWithInventoryIDandBarcodes", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemsInformationWithInventoryIDandBarcodesResponse GetItemsInformationWithInventoryIDandBarcodes(GetItemsInformationWithInventoryIDandBarcodesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsInformationWithInventoryIDandBarcodes", ReplyAction = "*")]
	Task<GetItemsInformationWithInventoryIDandBarcodesResponse> GetItemsInformationWithInventoryIDandBarcodesAsync(GetItemsInformationWithInventoryIDandBarcodesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithPagination", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemListWithPaginationResponse GetItemListWithPagination(GetItemListWithPaginationRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithPagination", ReplyAction = "*")]
	Task<GetItemListWithPaginationResponse> GetItemListWithPaginationAsync(GetItemListWithPaginationRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithInventoryIDPlusJet", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoWithInventoryIDPlusJetResponse GetItemInfoWithInventoryIDPlusJet(GetItemInfoWithInventoryIDPlusJetRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithInventoryIDPlusJet", ReplyAction = "*")]
	Task<GetItemInfoWithInventoryIDPlusJetResponse> GetItemInfoWithInventoryIDPlusJetAsync(GetItemInfoWithInventoryIDPlusJetRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithParentInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemListWithParentInfoResponse GetItemListWithParentInfo(GetItemListWithParentInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithParentInfo", ReplyAction = "*")]
	Task<GetItemListWithParentInfoResponse> GetItemListWithParentInfoAsync(GetItemListWithParentInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithinventoryID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoWithinventoryIDResponse GetItemInfoWithinventoryID(GetItemInfoWithinventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithinventoryID", ReplyAction = "*")]
	Task<GetItemInfoWithinventoryIDResponse> GetItemInfoWithinventoryIDAsync(GetItemInfoWithinventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithinventoryIDandBarcodes", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemInfoWithinventoryIDandBarcodesResponse GetItemInfoWithinventoryIDandBarcodes(GetItemInfoWithinventoryIDandBarcodesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemInfoWithinventoryIDandBarcodes", ReplyAction = "*")]
	Task<GetItemInfoWithinventoryIDandBarcodesResponse> GetItemInfoWithinventoryIDandBarcodesAsync(GetItemInfoWithinventoryIDandBarcodesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetGeneralItemInfoPlus", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetGeneralItemInfoPlusResponse GetGeneralItemInfoPlus(GetGeneralItemInfoPlusRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetGeneralItemInfoPlus", ReplyAction = "*")]
	Task<GetGeneralItemInfoPlusResponse> GetGeneralItemInfoPlusAsync(GetGeneralItemInfoPlusRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsQuantityAllInventoryWithBarcode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemsQuantityAllInventoryWithBarcodeResponse GetItemsQuantityAllInventoryWithBarcode(GetItemsQuantityAllInventoryWithBarcodeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsQuantityAllInventoryWithBarcode", ReplyAction = "*")]
	Task<GetItemsQuantityAllInventoryWithBarcodeResponse> GetItemsQuantityAllInventoryWithBarcodeAsync(GetItemsQuantityAllInventoryWithBarcodeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsQuantityListInventoryWithBarcode", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemsQuantityListInventoryWithBarcodeResponse GetItemsQuantityListInventoryWithBarcode(GetItemsQuantityListInventoryWithBarcodeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemsQuantityListInventoryWithBarcode", ReplyAction = "*")]
	Task<GetItemsQuantityListInventoryWithBarcodeResponse> GetItemsQuantityListInventoryWithBarcodeAsync(GetItemsQuantityListInventoryWithBarcodeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemQuantityWithInventoryID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemQuantityWithInventoryIDResponse GetItemQuantityWithInventoryID(GetItemQuantityWithInventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemQuantityWithInventoryID", ReplyAction = "*")]
	Task<GetItemQuantityWithInventoryIDResponse> GetItemQuantityWithInventoryIDAsync(GetItemQuantityWithInventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetArrayItemInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetArrayItemInfoResponse GetArrayItemInfo(GetArrayItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetArrayItemInfo", ReplyAction = "*")]
	Task<GetArrayItemInfoResponse> GetArrayItemInfoAsync(GetArrayItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemStockStatus", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemStockStatusResponse GetItemStockStatus(GetItemStockStatusRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemStockStatus", ReplyAction = "*")]
	Task<GetItemStockStatusResponse> GetItemStockStatusAsync(GetItemStockStatusRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateProperty", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTemplatePropertyResponse GetTemplateProperty(GetTemplatePropertyRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateProperty", ReplyAction = "*")]
	Task<GetTemplatePropertyResponse> GetTemplatePropertyAsync(GetTemplatePropertyRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateAttributes", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTemplateAttributesResponse GetTemplateAttributes(GetTemplateAttributesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateAttributes", ReplyAction = "*")]
	Task<GetTemplateAttributesResponse> GetTemplateAttributesAsync(GetTemplateAttributesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateItemInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTemplateItemInfoResponse GetTemplateItemInfo(GetTemplateItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTemplateItemInfo", ReplyAction = "*")]
	Task<GetTemplateItemInfoResponse> GetTemplateItemInfoAsync(GetTemplateItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetAllTemplateItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetAllTemplateItemsResponse GetAllTemplateItems(GetAllTemplateItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetAllTemplateItems", ReplyAction = "*")]
	Task<GetAllTemplateItemsResponse> GetAllTemplateItemsAsync(GetAllTemplateItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixProperty", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetMatrixPropertyResponse GetMatrixProperty(GetMatrixPropertyRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixProperty", ReplyAction = "*")]
	Task<GetMatrixPropertyResponse> GetMatrixPropertyAsync(GetMatrixPropertyRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixAttribute", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetMatrixAttributeResponse GetMatrixAttribute(GetMatrixAttributeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixAttribute", ReplyAction = "*")]
	Task<GetMatrixAttributeResponse> GetMatrixAttributeAsync(GetMatrixAttributeRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixItemInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetMatrixItemInfoResponse GetMatrixItemInfo(GetMatrixItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetMatrixItemInfo", ReplyAction = "*")]
	Task<GetMatrixItemInfoResponse> GetMatrixItemInfoAsync(GetMatrixItemInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetAllMatrixItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetAllMatrixItemsResponse GetAllMatrixItems(GetAllMatrixItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetAllMatrixItems", ReplyAction = "*")]
	Task<GetAllMatrixItemsResponse> GetAllMatrixItemsAsync(GetAllMatrixItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPosDepartmentList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetPosDepartmentListResponse GetPosDepartmentList(GetPosDepartmentListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPosDepartmentList", ReplyAction = "*")]
	Task<GetPosDepartmentListResponse> GetPosDepartmentListAsync(GetPosDepartmentListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPosDepartmentLevelList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetPosDepartmentLevelListResponse GetPosDepartmentLevelList(GetPosDepartmentLevelListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPosDepartmentLevelList", ReplyAction = "*")]
	Task<GetPosDepartmentLevelListResponse> GetPosDepartmentLevelListAsync(GetPosDepartmentLevelListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetInventoriesList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetInventoriesListResponse GetInventoriesList(GetInventoriesListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetInventoriesList", ReplyAction = "*")]
	Task<GetInventoriesListResponse> GetInventoriesListAsync(GetInventoriesListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransferOut", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	QuickExternalTransferOutResponse QuickExternalTransferOut(QuickExternalTransferOutRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransferOut", ReplyAction = "*")]
	Task<QuickExternalTransferOutResponse> QuickExternalTransferOutAsync(QuickExternalTransferOutRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransferIn", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	QuickExternalTransferInResponse QuickExternalTransferIn(QuickExternalTransferInRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransferIn", ReplyAction = "*")]
	Task<QuickExternalTransferInResponse> QuickExternalTransferInAsync(QuickExternalTransferInRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ItemOrder", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ItemOrderResponse ItemOrder(ItemOrderRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ItemOrder", ReplyAction = "*")]
	Task<ItemOrderResponse> ItemOrderAsync(ItemOrderRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ItemReceiving", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ItemReceivingResponse ItemReceiving(ItemReceivingRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ItemReceiving", ReplyAction = "*")]
	Task<ItemReceivingResponse> ItemReceivingAsync(ItemReceivingRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CreateCustomerResponse CreateCustomer(CreateCustomerRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateCustomer", ReplyAction = "*")]
	Task<CreateCustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateCustomerToRS", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CreateCustomerToRSResponse CreateCustomerToRS(CreateCustomerToRSRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateCustomerToRS", ReplyAction = "*")]
	Task<CreateCustomerToRSResponse> CreateCustomerToRSAsync(CreateCustomerToRSRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerListResponse GetCustomerList(GetCustomerListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerList", ReplyAction = "*")]
	Task<GetCustomerListResponse> GetCustomerListAsync(GetCustomerListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerListWithPageRow", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerListWithPageRowResponse GetCustomerListWithPageRow(GetCustomerListWithPageRowRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerListWithPageRow", ReplyAction = "*")]
	Task<GetCustomerListWithPageRowResponse> GetCustomerListWithPageRowAsync(GetCustomerListWithPageRowRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerInfoWithCustomerID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerInfoWithCustomerIDResponse GetCustomerInfoWithCustomerID(GetCustomerInfoWithCustomerIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerInfoWithCustomerID", ReplyAction = "*")]
	Task<GetCustomerInfoWithCustomerIDResponse> GetCustomerInfoWithCustomerIDAsync(GetCustomerInfoWithCustomerIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerInfoWithMemberID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerInfoWithMemberIDResponse GetCustomerInfoWithMemberID(GetCustomerInfoWithMemberIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerInfoWithMemberID", ReplyAction = "*")]
	Task<GetCustomerInfoWithMemberIDResponse> GetCustomerInfoWithMemberIDAsync(GetCustomerInfoWithMemberIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomersBaseInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomersBaseInfoResponse GetCustomersBaseInfo(GetCustomersBaseInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomersBaseInfo", ReplyAction = "*")]
	Task<GetCustomersBaseInfoResponse> GetCustomersBaseInfoAsync(GetCustomersBaseInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/UpdateCustomerInfo", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	UpdateCustomerInfoResponse UpdateCustomerInfo(UpdateCustomerInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/UpdateCustomerInfo", ReplyAction = "*")]
	Task<UpdateCustomerInfoResponse> UpdateCustomerInfoAsync(UpdateCustomerInfoRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerAddressInfoWithCustomerID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerAddressInfoWithCustomerIDResponse GetCustomerAddressInfoWithCustomerID(GetCustomerAddressInfoWithCustomerIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerAddressInfoWithCustomerID", ReplyAction = "*")]
	Task<GetCustomerAddressInfoWithCustomerIDResponse> GetCustomerAddressInfoWithCustomerIDAsync(GetCustomerAddressInfoWithCustomerIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerGroup", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerGroupResponse GetCustomerGroup(GetCustomerGroupRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerGroup", ReplyAction = "*")]
	Task<GetCustomerGroupResponse> GetCustomerGroupAsync(GetCustomerGroupRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerTransaction", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetCustomerTransactionResponse GetCustomerTransaction(GetCustomerTransactionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetCustomerTransaction", ReplyAction = "*")]
	Task<GetCustomerTransactionResponse> GetCustomerTransactionAsync(GetCustomerTransactionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTransactionByRetailStoreID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTransactionByRetailStoreIDResponse GetTransactionByRetailStoreID(GetTransactionByRetailStoreIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTransactionByRetailStoreID", ReplyAction = "*")]
	Task<GetTransactionByRetailStoreIDResponse> GetTransactionByRetailStoreIDAsync(GetTransactionByRetailStoreIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/Buycustomers", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	BuycustomersResponse Buycustomers(BuycustomersRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/Buycustomers", ReplyAction = "*")]
	Task<BuycustomersResponse> BuycustomersAsync(BuycustomersRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/BuycustomersWithFactorItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	BuycustomersWithFactorItemsResponse BuycustomersWithFactorItems(BuycustomersWithFactorItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/BuycustomersWithFactorItems", ReplyAction = "*")]
	Task<BuycustomersWithFactorItemsResponse> BuycustomersWithFactorItemsAsync(BuycustomersWithFactorItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CustomerCreditOperations", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CustomerCreditOperationsResponse CustomerCreditOperations(CustomerCreditOperationsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CustomerCreditOperations", ReplyAction = "*")]
	Task<CustomerCreditOperationsResponse> CustomerCreditOperationsAsync(CustomerCreditOperationsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTaxChargeAmount", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTaxChargeAmountResponse GetTaxChargeAmount(GetTaxChargeAmountRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTaxChargeAmount", ReplyAction = "*")]
	Task<GetTaxChargeAmountResponse> GetTaxChargeAmountAsync(GetTaxChargeAmountRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTenderList", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTenderListResponse GetTenderList(GetTenderListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTenderList", ReplyAction = "*")]
	Task<GetTenderListResponse> GetTenderListAsync(GetTenderListRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPromotions", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetPromotionsResponse GetPromotions(GetPromotionsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPromotions", ReplyAction = "*")]
	Task<GetPromotionsResponse> GetPromotionsAsync(GetPromotionsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPromotionCustomerGroups", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetPromotionCustomerGroupsResponse GetPromotionCustomerGroups(GetPromotionCustomerGroupsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetPromotionCustomerGroups", ReplyAction = "*")]
	Task<GetPromotionCustomerGroupsResponse> GetPromotionCustomerGroupsAsync(GetPromotionCustomerGroupsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/AddToReserve", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	AddToReserveResponse AddToReserve(AddToReserveRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/AddToReserve", ReplyAction = "*")]
	Task<AddToReserveResponse> AddToReserveAsync(AddToReserveRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SaleItemsResponse SaleItems(SaleItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleItems", ReplyAction = "*")]
	Task<SaleItemsResponse> SaleItemsAsync(SaleItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleItemsDate", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SaleItemsDateResponse SaleItemsDate(SaleItemsDateRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleItemsDate", ReplyAction = "*")]
	Task<SaleItemsDateResponse> SaleItemsDateAsync(SaleItemsDateRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/WholeSales", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WholeSalesResponse WholeSales(WholeSalesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/WholeSales", ReplyAction = "*")]
	Task<WholeSalesResponse> WholeSalesAsync(WholeSalesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnWholesales", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ReturnWholesalesResponse ReturnWholesales(ReturnWholesalesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnWholesales", ReplyAction = "*")]
	Task<ReturnWholesalesResponse> ReturnWholesalesAsync(ReturnWholesalesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SuspendTransaction", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SuspendTransactionResponse SuspendTransaction(SuspendTransactionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SuspendTransaction", ReplyAction = "*")]
	Task<SuspendTransactionResponse> SuspendTransactionAsync(SuspendTransactionRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/LayAwaySaleItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	LayAwaySaleItemsResponse LayAwaySaleItems(LayAwaySaleItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/LayAwaySaleItems", ReplyAction = "*")]
	Task<LayAwaySaleItemsResponse> LayAwaySaleItemsAsync(LayAwaySaleItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetRecieptDetail", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetRecieptDetailResponse GetRecieptDetail(GetRecieptDetailRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetRecieptDetail", ReplyAction = "*")]
	Task<GetRecieptDetailResponse> GetRecieptDetailAsync(GetRecieptDetailRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetRecieptHeader", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetRecieptHeaderResponse GetRecieptHeader(GetRecieptHeaderRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetRecieptHeader", ReplyAction = "*")]
	Task<GetRecieptHeaderResponse> GetRecieptHeaderAsync(GetRecieptHeaderRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleReturnItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	SaleReturnItemsResponse SaleReturnItems(SaleReturnItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/SaleReturnItems", ReplyAction = "*")]
	Task<SaleReturnItemsResponse> SaleReturnItemsAsync(SaleReturnItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnItems", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ReturnItemsResponse ReturnItems(ReturnItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnItems", ReplyAction = "*")]
	Task<ReturnItemsResponse> ReturnItemsAsync(ReturnItemsRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ValidateGiftCertificates", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ValidateGiftCertificatesResponse ValidateGiftCertificates(ValidateGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ValidateGiftCertificates", ReplyAction = "*")]
	Task<ValidateGiftCertificatesResponse> ValidateGiftCertificatesAsync(ValidateGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateGiftCertificate", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	CreateGiftCertificateResponse CreateGiftCertificate(CreateGiftCertificateRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/CreateGiftCertificate", ReplyAction = "*")]
	Task<CreateGiftCertificateResponse> CreateGiftCertificateAsync(CreateGiftCertificateRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUnUsedGiftCertificates", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetUnUsedGiftCertificatesResponse GetUnUsedGiftCertificates(GetUnUsedGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUnUsedGiftCertificates", ReplyAction = "*")]
	Task<GetUnUsedGiftCertificatesResponse> GetUnUsedGiftCertificatesAsync(GetUnUsedGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUsedGiftCertificates", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetUsedGiftCertificatesResponse GetUsedGiftCertificates(GetUsedGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUsedGiftCertificates", ReplyAction = "*")]
	Task<GetUsedGiftCertificatesResponse> GetUsedGiftCertificatesAsync(GetUsedGiftCertificatesRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUsedCreditCustomer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetUsedCreditCustomerResponse GetUsedCreditCustomer(GetUsedCreditCustomerRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetUsedCreditCustomer", ReplyAction = "*")]
	Task<GetUsedCreditCustomerResponse> GetUsedCreditCustomerAsync(GetUsedCreditCustomerRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithinventoryID", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetItemListWithinventoryIDResponse GetItemListWithinventoryID(GetItemListWithinventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetItemListWithinventoryID", ReplyAction = "*")]
	Task<GetItemListWithinventoryIDResponse> GetItemListWithinventoryIDAsync(GetItemListWithinventoryIDRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransfer", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	QuickExternalTransferResponse QuickExternalTransfer(QuickExternalTransferRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/QuickExternalTransfer", ReplyAction = "*")]
	Task<QuickExternalTransferResponse> QuickExternalTransferAsync(QuickExternalTransferRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ApproveDocument", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ApproveDocumentResponse ApproveDocument(ApproveDocumentRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ApproveDocument", ReplyAction = "*")]
	Task<ApproveDocumentResponse> ApproveDocumentAsync(ApproveDocumentRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTransactionWithDs_info_2", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	GetTransactionWithDs_info_2Response GetTransactionWithDs_info_2(GetTransactionWithDs_info_2Request request);

	[OperationContract(Action = "KyanOnlineSaleService/GetTransactionWithDs_info_2", ReplyAction = "*")]
	Task<GetTransactionWithDs_info_2Response> GetTransactionWithDs_info_2Async(GetTransactionWithDs_info_2Request request);

	[OperationContract(Action = "KyanOnlineSaleService/Wholesale", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	WholesaleResponse Wholesale(WholesaleRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/Wholesale", ReplyAction = "*")]
	Task<WholesaleResponse> WholesaleAsync(WholesaleRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnWholesale", ReplyAction = "*")]
	[XmlSerializerFormat(SupportFaults = true)]
	ReturnWholesaleResponse ReturnWholesale(ReturnWholesaleRequest request);

	[OperationContract(Action = "KyanOnlineSaleService/ReturnWholesale", ReplyAction = "*")]
	Task<ReturnWholesaleResponse> ReturnWholesaleAsync(ReturnWholesaleRequest request);
}
