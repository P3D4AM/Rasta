using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace CRMIdeal.LinkKyan;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class KyanOnlineSaleServiceSoapClient : ClientBase<KyanOnlineSaleServiceSoap>, KyanOnlineSaleServiceSoap
{
	public KyanOnlineSaleServiceSoapClient()
	{
	}

	public KyanOnlineSaleServiceSoapClient(string endpointConfigurationName)
		: base(endpointConfigurationName)
	{
	}

	public KyanOnlineSaleServiceSoapClient(string endpointConfigurationName, string remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public KyanOnlineSaleServiceSoapClient(string endpointConfigurationName, EndpointAddress remoteAddress)
		: base(endpointConfigurationName, remoteAddress)
	{
	}

	public KyanOnlineSaleServiceSoapClient(Binding binding, EndpointAddress remoteAddress)
		: base(binding, remoteAddress)
	{
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	AuthenticationUserResponse KyanOnlineSaleServiceSoap.AuthenticationUser(AuthenticationUserRequest request)
	{
		return base.Channel.AuthenticationUser(request);
	}

	public AuthenticationResult AuthenticationUser(AuthUser AuthUser)
	{
		AuthenticationUserRequest authenticationUserRequest = new AuthenticationUserRequest();
		authenticationUserRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).AuthenticationUser(authenticationUserRequest).AuthenticationUserResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<AuthenticationUserResponse> KyanOnlineSaleServiceSoap.AuthenticationUserAsync(AuthenticationUserRequest request)
	{
		return base.Channel.AuthenticationUserAsync(request);
	}

	public Task<AuthenticationUserResponse> AuthenticationUserAsync(AuthUser AuthUser)
	{
		AuthenticationUserRequest authenticationUserRequest = new AuthenticationUserRequest();
		authenticationUserRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).AuthenticationUserAsync(authenticationUserRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	InputPermissionResponse KyanOnlineSaleServiceSoap.InputPermission(InputPermissionRequest request)
	{
		return base.Channel.InputPermission(request);
	}

	public Result InputPermission(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int RsID)
	{
		InputPermissionRequest inputPermissionRequest = new InputPermissionRequest();
		inputPermissionRequest.ValidationSoapHeader = ValidationSoapHeader;
		inputPermissionRequest.AuthUser = AuthUser;
		inputPermissionRequest.RsID = RsID;
		return ((KyanOnlineSaleServiceSoap)this).InputPermission(inputPermissionRequest).InputPermissionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<InputPermissionResponse> KyanOnlineSaleServiceSoap.InputPermissionAsync(InputPermissionRequest request)
	{
		return base.Channel.InputPermissionAsync(request);
	}

	public Task<InputPermissionResponse> InputPermissionAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int RsID)
	{
		InputPermissionRequest inputPermissionRequest = new InputPermissionRequest();
		inputPermissionRequest.ValidationSoapHeader = ValidationSoapHeader;
		inputPermissionRequest.AuthUser = AuthUser;
		inputPermissionRequest.RsID = RsID;
		return ((KyanOnlineSaleServiceSoap)this).InputPermissionAsync(inputPermissionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemListResponse KyanOnlineSaleServiceSoap.GetItemList(GetItemListRequest request)
	{
		return base.Channel.GetItemList(request);
	}

	public ResponseDataOfitm GetItemList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetItemListRequest getItemListRequest = new GetItemListRequest();
		getItemListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListRequest.AuthUser = AuthUser;
		getItemListRequest.StartDate = StartDate;
		getItemListRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemList(getItemListRequest).GetItemListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemListResponse> KyanOnlineSaleServiceSoap.GetItemListAsync(GetItemListRequest request)
	{
		return base.Channel.GetItemListAsync(request);
	}

	public Task<GetItemListResponse> GetItemListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetItemListRequest getItemListRequest = new GetItemListRequest();
		getItemListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListRequest.AuthUser = AuthUser;
		getItemListRequest.StartDate = StartDate;
		getItemListRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListAsync(getItemListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoResponse KyanOnlineSaleServiceSoap.GetItemInfo(GetItemInfoRequest request)
	{
		return base.Channel.GetItemInfo(request);
	}

	public ResponseDataOfitm GetItemInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string barcode)
	{
		GetItemInfoRequest getItemInfoRequest = new GetItemInfoRequest();
		getItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoRequest.AuthUser = AuthUser;
		getItemInfoRequest.barcode = barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfo(getItemInfoRequest).GetItemInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoResponse> KyanOnlineSaleServiceSoap.GetItemInfoAsync(GetItemInfoRequest request)
	{
		return base.Channel.GetItemInfoAsync(request);
	}

	public Task<GetItemInfoResponse> GetItemInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string barcode)
	{
		GetItemInfoRequest getItemInfoRequest = new GetItemInfoRequest();
		getItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoRequest.AuthUser = AuthUser;
		getItemInfoRequest.barcode = barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoAsync(getItemInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoWithItemIDResponse KyanOnlineSaleServiceSoap.GetItemInfoWithItemID(GetItemInfoWithItemIDRequest request)
	{
		return base.Channel.GetItemInfoWithItemID(request);
	}

	public ResponseDataOfitm GetItemInfoWithItemID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int ItemID)
	{
		GetItemInfoWithItemIDRequest getItemInfoWithItemIDRequest = new GetItemInfoWithItemIDRequest();
		getItemInfoWithItemIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithItemIDRequest.AuthUser = AuthUser;
		getItemInfoWithItemIDRequest.ItemID = ItemID;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithItemID(getItemInfoWithItemIDRequest).GetItemInfoWithItemIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoWithItemIDResponse> KyanOnlineSaleServiceSoap.GetItemInfoWithItemIDAsync(GetItemInfoWithItemIDRequest request)
	{
		return base.Channel.GetItemInfoWithItemIDAsync(request);
	}

	public Task<GetItemInfoWithItemIDResponse> GetItemInfoWithItemIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int ItemID)
	{
		GetItemInfoWithItemIDRequest getItemInfoWithItemIDRequest = new GetItemInfoWithItemIDRequest();
		getItemInfoWithItemIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithItemIDRequest.AuthUser = AuthUser;
		getItemInfoWithItemIDRequest.ItemID = ItemID;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithItemIDAsync(getItemInfoWithItemIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoWithGroupIDResponse KyanOnlineSaleServiceSoap.GetItemInfoWithGroupID(GetItemInfoWithGroupIDRequest request)
	{
		return base.Channel.GetItemInfoWithGroupID(request);
	}

	public ResponseDataOfitm GetItemInfoWithGroupID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int groupID)
	{
		GetItemInfoWithGroupIDRequest getItemInfoWithGroupIDRequest = new GetItemInfoWithGroupIDRequest();
		getItemInfoWithGroupIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithGroupIDRequest.AuthUser = AuthUser;
		getItemInfoWithGroupIDRequest.groupID = groupID;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithGroupID(getItemInfoWithGroupIDRequest).GetItemInfoWithGroupIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoWithGroupIDResponse> KyanOnlineSaleServiceSoap.GetItemInfoWithGroupIDAsync(GetItemInfoWithGroupIDRequest request)
	{
		return base.Channel.GetItemInfoWithGroupIDAsync(request);
	}

	public Task<GetItemInfoWithGroupIDResponse> GetItemInfoWithGroupIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int groupID)
	{
		GetItemInfoWithGroupIDRequest getItemInfoWithGroupIDRequest = new GetItemInfoWithGroupIDRequest();
		getItemInfoWithGroupIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithGroupIDRequest.AuthUser = AuthUser;
		getItemInfoWithGroupIDRequest.groupID = groupID;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithGroupIDAsync(getItemInfoWithGroupIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemsInformationWithInventoryIDandBarcodesResponse KyanOnlineSaleServiceSoap.GetItemsInformationWithInventoryIDandBarcodes(GetItemsInformationWithInventoryIDandBarcodesRequest request)
	{
		return base.Channel.GetItemsInformationWithInventoryIDandBarcodes(request);
	}

	public ResponseDataOfitm GetItemsInformationWithInventoryIDandBarcodes(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryId, string[] barcodes)
	{
		GetItemsInformationWithInventoryIDandBarcodesRequest getItemsInformationWithInventoryIDandBarcodesRequest = new GetItemsInformationWithInventoryIDandBarcodesRequest();
		getItemsInformationWithInventoryIDandBarcodesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsInformationWithInventoryIDandBarcodesRequest.AuthUser = AuthUser;
		getItemsInformationWithInventoryIDandBarcodesRequest.inventoryId = inventoryId;
		getItemsInformationWithInventoryIDandBarcodesRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsInformationWithInventoryIDandBarcodes(getItemsInformationWithInventoryIDandBarcodesRequest).GetItemsInformationWithInventoryIDandBarcodesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemsInformationWithInventoryIDandBarcodesResponse> KyanOnlineSaleServiceSoap.GetItemsInformationWithInventoryIDandBarcodesAsync(GetItemsInformationWithInventoryIDandBarcodesRequest request)
	{
		return base.Channel.GetItemsInformationWithInventoryIDandBarcodesAsync(request);
	}

	public Task<GetItemsInformationWithInventoryIDandBarcodesResponse> GetItemsInformationWithInventoryIDandBarcodesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryId, string[] barcodes)
	{
		GetItemsInformationWithInventoryIDandBarcodesRequest getItemsInformationWithInventoryIDandBarcodesRequest = new GetItemsInformationWithInventoryIDandBarcodesRequest();
		getItemsInformationWithInventoryIDandBarcodesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsInformationWithInventoryIDandBarcodesRequest.AuthUser = AuthUser;
		getItemsInformationWithInventoryIDandBarcodesRequest.inventoryId = inventoryId;
		getItemsInformationWithInventoryIDandBarcodesRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsInformationWithInventoryIDandBarcodesAsync(getItemsInformationWithInventoryIDandBarcodesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemListWithPaginationResponse KyanOnlineSaleServiceSoap.GetItemListWithPagination(GetItemListWithPaginationRequest request)
	{
		return base.Channel.GetItemListWithPagination(request);
	}

	public ResponseDataOfitmWithRowNo GetItemListWithPagination(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int RowNoBgin)
	{
		GetItemListWithPaginationRequest getItemListWithPaginationRequest = new GetItemListWithPaginationRequest();
		getItemListWithPaginationRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithPaginationRequest.AuthUser = AuthUser;
		getItemListWithPaginationRequest.RowNoBgin = RowNoBgin;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithPagination(getItemListWithPaginationRequest).GetItemListWithPaginationResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemListWithPaginationResponse> KyanOnlineSaleServiceSoap.GetItemListWithPaginationAsync(GetItemListWithPaginationRequest request)
	{
		return base.Channel.GetItemListWithPaginationAsync(request);
	}

	public Task<GetItemListWithPaginationResponse> GetItemListWithPaginationAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int RowNoBgin)
	{
		GetItemListWithPaginationRequest getItemListWithPaginationRequest = new GetItemListWithPaginationRequest();
		getItemListWithPaginationRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithPaginationRequest.AuthUser = AuthUser;
		getItemListWithPaginationRequest.RowNoBgin = RowNoBgin;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithPaginationAsync(getItemListWithPaginationRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoWithInventoryIDPlusJetResponse KyanOnlineSaleServiceSoap.GetItemInfoWithInventoryIDPlusJet(GetItemInfoWithInventoryIDPlusJetRequest request)
	{
		return base.Channel.GetItemInfoWithInventoryIDPlusJet(request);
	}

	public ResponseDataOfgoodDetail GetItemInfoWithInventoryIDPlusJet(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryID, int RowNoBgin)
	{
		GetItemInfoWithInventoryIDPlusJetRequest getItemInfoWithInventoryIDPlusJetRequest = new GetItemInfoWithInventoryIDPlusJetRequest();
		getItemInfoWithInventoryIDPlusJetRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithInventoryIDPlusJetRequest.AuthUser = AuthUser;
		getItemInfoWithInventoryIDPlusJetRequest.inventoryID = inventoryID;
		getItemInfoWithInventoryIDPlusJetRequest.RowNoBgin = RowNoBgin;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithInventoryIDPlusJet(getItemInfoWithInventoryIDPlusJetRequest).GetItemInfoWithInventoryIDPlusJetResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoWithInventoryIDPlusJetResponse> KyanOnlineSaleServiceSoap.GetItemInfoWithInventoryIDPlusJetAsync(GetItemInfoWithInventoryIDPlusJetRequest request)
	{
		return base.Channel.GetItemInfoWithInventoryIDPlusJetAsync(request);
	}

	public Task<GetItemInfoWithInventoryIDPlusJetResponse> GetItemInfoWithInventoryIDPlusJetAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventoryID, int RowNoBgin)
	{
		GetItemInfoWithInventoryIDPlusJetRequest getItemInfoWithInventoryIDPlusJetRequest = new GetItemInfoWithInventoryIDPlusJetRequest();
		getItemInfoWithInventoryIDPlusJetRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithInventoryIDPlusJetRequest.AuthUser = AuthUser;
		getItemInfoWithInventoryIDPlusJetRequest.inventoryID = inventoryID;
		getItemInfoWithInventoryIDPlusJetRequest.RowNoBgin = RowNoBgin;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithInventoryIDPlusJetAsync(getItemInfoWithInventoryIDPlusJetRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemListWithParentInfoResponse KyanOnlineSaleServiceSoap.GetItemListWithParentInfo(GetItemListWithParentInfoRequest request)
	{
		return base.Channel.GetItemListWithParentInfo(request);
	}

	public ResponseDataOfitmWithParentInfo GetItemListWithParentInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, bool Active)
	{
		GetItemListWithParentInfoRequest getItemListWithParentInfoRequest = new GetItemListWithParentInfoRequest();
		getItemListWithParentInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithParentInfoRequest.AuthUser = AuthUser;
		getItemListWithParentInfoRequest.StartDate = StartDate;
		getItemListWithParentInfoRequest.EndDate = EndDate;
		getItemListWithParentInfoRequest.Active = Active;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithParentInfo(getItemListWithParentInfoRequest).GetItemListWithParentInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemListWithParentInfoResponse> KyanOnlineSaleServiceSoap.GetItemListWithParentInfoAsync(GetItemListWithParentInfoRequest request)
	{
		return base.Channel.GetItemListWithParentInfoAsync(request);
	}

	public Task<GetItemListWithParentInfoResponse> GetItemListWithParentInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, bool Active)
	{
		GetItemListWithParentInfoRequest getItemListWithParentInfoRequest = new GetItemListWithParentInfoRequest();
		getItemListWithParentInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithParentInfoRequest.AuthUser = AuthUser;
		getItemListWithParentInfoRequest.StartDate = StartDate;
		getItemListWithParentInfoRequest.EndDate = EndDate;
		getItemListWithParentInfoRequest.Active = Active;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithParentInfoAsync(getItemListWithParentInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoWithinventoryIDResponse KyanOnlineSaleServiceSoap.GetItemInfoWithinventoryID(GetItemInfoWithinventoryIDRequest request)
	{
		return base.Channel.GetItemInfoWithinventoryID(request);
	}

	public ResponseDataOfitm3 GetItemInfoWithinventoryID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string StartDate, string EndDate)
	{
		GetItemInfoWithinventoryIDRequest getItemInfoWithinventoryIDRequest = new GetItemInfoWithinventoryIDRequest();
		getItemInfoWithinventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithinventoryIDRequest.AuthUser = AuthUser;
		getItemInfoWithinventoryIDRequest.inventories = inventories;
		getItemInfoWithinventoryIDRequest.StartDate = StartDate;
		getItemInfoWithinventoryIDRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithinventoryID(getItemInfoWithinventoryIDRequest).GetItemInfoWithinventoryIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoWithinventoryIDResponse> KyanOnlineSaleServiceSoap.GetItemInfoWithinventoryIDAsync(GetItemInfoWithinventoryIDRequest request)
	{
		return base.Channel.GetItemInfoWithinventoryIDAsync(request);
	}

	public Task<GetItemInfoWithinventoryIDResponse> GetItemInfoWithinventoryIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string StartDate, string EndDate)
	{
		GetItemInfoWithinventoryIDRequest getItemInfoWithinventoryIDRequest = new GetItemInfoWithinventoryIDRequest();
		getItemInfoWithinventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithinventoryIDRequest.AuthUser = AuthUser;
		getItemInfoWithinventoryIDRequest.inventories = inventories;
		getItemInfoWithinventoryIDRequest.StartDate = StartDate;
		getItemInfoWithinventoryIDRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithinventoryIDAsync(getItemInfoWithinventoryIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemInfoWithinventoryIDandBarcodesResponse KyanOnlineSaleServiceSoap.GetItemInfoWithinventoryIDandBarcodes(GetItemInfoWithinventoryIDandBarcodesRequest request)
	{
		return base.Channel.GetItemInfoWithinventoryIDandBarcodes(request);
	}

	public ResponseDataOfitm3 GetItemInfoWithinventoryIDandBarcodes(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string[] barcodes, string StartDate, string EndDate)
	{
		GetItemInfoWithinventoryIDandBarcodesRequest getItemInfoWithinventoryIDandBarcodesRequest = new GetItemInfoWithinventoryIDandBarcodesRequest();
		getItemInfoWithinventoryIDandBarcodesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithinventoryIDandBarcodesRequest.AuthUser = AuthUser;
		getItemInfoWithinventoryIDandBarcodesRequest.inventories = inventories;
		getItemInfoWithinventoryIDandBarcodesRequest.barcodes = barcodes;
		getItemInfoWithinventoryIDandBarcodesRequest.StartDate = StartDate;
		getItemInfoWithinventoryIDandBarcodesRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithinventoryIDandBarcodes(getItemInfoWithinventoryIDandBarcodesRequest).GetItemInfoWithinventoryIDandBarcodesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemInfoWithinventoryIDandBarcodesResponse> KyanOnlineSaleServiceSoap.GetItemInfoWithinventoryIDandBarcodesAsync(GetItemInfoWithinventoryIDandBarcodesRequest request)
	{
		return base.Channel.GetItemInfoWithinventoryIDandBarcodesAsync(request);
	}

	public Task<GetItemInfoWithinventoryIDandBarcodesResponse> GetItemInfoWithinventoryIDandBarcodesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] inventories, string[] barcodes, string StartDate, string EndDate)
	{
		GetItemInfoWithinventoryIDandBarcodesRequest getItemInfoWithinventoryIDandBarcodesRequest = new GetItemInfoWithinventoryIDandBarcodesRequest();
		getItemInfoWithinventoryIDandBarcodesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemInfoWithinventoryIDandBarcodesRequest.AuthUser = AuthUser;
		getItemInfoWithinventoryIDandBarcodesRequest.inventories = inventories;
		getItemInfoWithinventoryIDandBarcodesRequest.barcodes = barcodes;
		getItemInfoWithinventoryIDandBarcodesRequest.StartDate = StartDate;
		getItemInfoWithinventoryIDandBarcodesRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetItemInfoWithinventoryIDandBarcodesAsync(getItemInfoWithinventoryIDandBarcodesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetGeneralItemInfoPlusResponse KyanOnlineSaleServiceSoap.GetGeneralItemInfoPlus(GetGeneralItemInfoPlusRequest request)
	{
		return base.Channel.GetGeneralItemInfoPlus(request);
	}

	public ResponseDataOfGeneralItemInfoPlusModel GetGeneralItemInfoPlus(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retailStoreId)
	{
		GetGeneralItemInfoPlusRequest getGeneralItemInfoPlusRequest = new GetGeneralItemInfoPlusRequest();
		getGeneralItemInfoPlusRequest.ValidationSoapHeader = ValidationSoapHeader;
		getGeneralItemInfoPlusRequest.AuthUser = AuthUser;
		getGeneralItemInfoPlusRequest.retailStoreId = retailStoreId;
		return ((KyanOnlineSaleServiceSoap)this).GetGeneralItemInfoPlus(getGeneralItemInfoPlusRequest).GetGeneralItemInfoPlusResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetGeneralItemInfoPlusResponse> KyanOnlineSaleServiceSoap.GetGeneralItemInfoPlusAsync(GetGeneralItemInfoPlusRequest request)
	{
		return base.Channel.GetGeneralItemInfoPlusAsync(request);
	}

	public Task<GetGeneralItemInfoPlusResponse> GetGeneralItemInfoPlusAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retailStoreId)
	{
		GetGeneralItemInfoPlusRequest getGeneralItemInfoPlusRequest = new GetGeneralItemInfoPlusRequest();
		getGeneralItemInfoPlusRequest.ValidationSoapHeader = ValidationSoapHeader;
		getGeneralItemInfoPlusRequest.AuthUser = AuthUser;
		getGeneralItemInfoPlusRequest.retailStoreId = retailStoreId;
		return ((KyanOnlineSaleServiceSoap)this).GetGeneralItemInfoPlusAsync(getGeneralItemInfoPlusRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemsQuantityAllInventoryWithBarcodeResponse KyanOnlineSaleServiceSoap.GetItemsQuantityAllInventoryWithBarcode(GetItemsQuantityAllInventoryWithBarcodeRequest request)
	{
		return base.Channel.GetItemsQuantityAllInventoryWithBarcode(request);
	}

	public ResponseDataOfItemStock GetItemsQuantityAllInventoryWithBarcode(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] retailStores, string[] barcodes)
	{
		GetItemsQuantityAllInventoryWithBarcodeRequest getItemsQuantityAllInventoryWithBarcodeRequest = new GetItemsQuantityAllInventoryWithBarcodeRequest();
		getItemsQuantityAllInventoryWithBarcodeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsQuantityAllInventoryWithBarcodeRequest.AuthUser = AuthUser;
		getItemsQuantityAllInventoryWithBarcodeRequest.retailStores = retailStores;
		getItemsQuantityAllInventoryWithBarcodeRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsQuantityAllInventoryWithBarcode(getItemsQuantityAllInventoryWithBarcodeRequest).GetItemsQuantityAllInventoryWithBarcodeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemsQuantityAllInventoryWithBarcodeResponse> KyanOnlineSaleServiceSoap.GetItemsQuantityAllInventoryWithBarcodeAsync(GetItemsQuantityAllInventoryWithBarcodeRequest request)
	{
		return base.Channel.GetItemsQuantityAllInventoryWithBarcodeAsync(request);
	}

	public Task<GetItemsQuantityAllInventoryWithBarcodeResponse> GetItemsQuantityAllInventoryWithBarcodeAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] retailStores, string[] barcodes)
	{
		GetItemsQuantityAllInventoryWithBarcodeRequest getItemsQuantityAllInventoryWithBarcodeRequest = new GetItemsQuantityAllInventoryWithBarcodeRequest();
		getItemsQuantityAllInventoryWithBarcodeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsQuantityAllInventoryWithBarcodeRequest.AuthUser = AuthUser;
		getItemsQuantityAllInventoryWithBarcodeRequest.retailStores = retailStores;
		getItemsQuantityAllInventoryWithBarcodeRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsQuantityAllInventoryWithBarcodeAsync(getItemsQuantityAllInventoryWithBarcodeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemsQuantityListInventoryWithBarcodeResponse KyanOnlineSaleServiceSoap.GetItemsQuantityListInventoryWithBarcode(GetItemsQuantityListInventoryWithBarcodeRequest request)
	{
		return base.Channel.GetItemsQuantityListInventoryWithBarcode(request);
	}

	public ResponseDataOfItemStock2 GetItemsQuantityListInventoryWithBarcode(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] Inventories, string[] barcodes)
	{
		GetItemsQuantityListInventoryWithBarcodeRequest getItemsQuantityListInventoryWithBarcodeRequest = new GetItemsQuantityListInventoryWithBarcodeRequest();
		getItemsQuantityListInventoryWithBarcodeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsQuantityListInventoryWithBarcodeRequest.AuthUser = AuthUser;
		getItemsQuantityListInventoryWithBarcodeRequest.Inventories = Inventories;
		getItemsQuantityListInventoryWithBarcodeRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsQuantityListInventoryWithBarcode(getItemsQuantityListInventoryWithBarcodeRequest).GetItemsQuantityListInventoryWithBarcodeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemsQuantityListInventoryWithBarcodeResponse> KyanOnlineSaleServiceSoap.GetItemsQuantityListInventoryWithBarcodeAsync(GetItemsQuantityListInventoryWithBarcodeRequest request)
	{
		return base.Channel.GetItemsQuantityListInventoryWithBarcodeAsync(request);
	}

	public Task<GetItemsQuantityListInventoryWithBarcodeResponse> GetItemsQuantityListInventoryWithBarcodeAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int[] Inventories, string[] barcodes)
	{
		GetItemsQuantityListInventoryWithBarcodeRequest getItemsQuantityListInventoryWithBarcodeRequest = new GetItemsQuantityListInventoryWithBarcodeRequest();
		getItemsQuantityListInventoryWithBarcodeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemsQuantityListInventoryWithBarcodeRequest.AuthUser = AuthUser;
		getItemsQuantityListInventoryWithBarcodeRequest.Inventories = Inventories;
		getItemsQuantityListInventoryWithBarcodeRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetItemsQuantityListInventoryWithBarcodeAsync(getItemsQuantityListInventoryWithBarcodeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemQuantityWithInventoryIDResponse KyanOnlineSaleServiceSoap.GetItemQuantityWithInventoryID(GetItemQuantityWithInventoryIDRequest request)
	{
		return base.Channel.GetItemQuantityWithInventoryID(request);
	}

	public ResponseDataOfBarCodeStock GetItemQuantityWithInventoryID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventory)
	{
		GetItemQuantityWithInventoryIDRequest getItemQuantityWithInventoryIDRequest = new GetItemQuantityWithInventoryIDRequest();
		getItemQuantityWithInventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemQuantityWithInventoryIDRequest.AuthUser = AuthUser;
		getItemQuantityWithInventoryIDRequest.inventory = inventory;
		return ((KyanOnlineSaleServiceSoap)this).GetItemQuantityWithInventoryID(getItemQuantityWithInventoryIDRequest).GetItemQuantityWithInventoryIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemQuantityWithInventoryIDResponse> KyanOnlineSaleServiceSoap.GetItemQuantityWithInventoryIDAsync(GetItemQuantityWithInventoryIDRequest request)
	{
		return base.Channel.GetItemQuantityWithInventoryIDAsync(request);
	}

	public Task<GetItemQuantityWithInventoryIDResponse> GetItemQuantityWithInventoryIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventory)
	{
		GetItemQuantityWithInventoryIDRequest getItemQuantityWithInventoryIDRequest = new GetItemQuantityWithInventoryIDRequest();
		getItemQuantityWithInventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemQuantityWithInventoryIDRequest.AuthUser = AuthUser;
		getItemQuantityWithInventoryIDRequest.inventory = inventory;
		return ((KyanOnlineSaleServiceSoap)this).GetItemQuantityWithInventoryIDAsync(getItemQuantityWithInventoryIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetArrayItemInfoResponse KyanOnlineSaleServiceSoap.GetArrayItemInfo(GetArrayItemInfoRequest request)
	{
		return base.Channel.GetArrayItemInfo(request);
	}

	public ResponseDataOfitm GetArrayItemInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcodes)
	{
		GetArrayItemInfoRequest getArrayItemInfoRequest = new GetArrayItemInfoRequest();
		getArrayItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getArrayItemInfoRequest.AuthUser = AuthUser;
		getArrayItemInfoRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetArrayItemInfo(getArrayItemInfoRequest).GetArrayItemInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetArrayItemInfoResponse> KyanOnlineSaleServiceSoap.GetArrayItemInfoAsync(GetArrayItemInfoRequest request)
	{
		return base.Channel.GetArrayItemInfoAsync(request);
	}

	public Task<GetArrayItemInfoResponse> GetArrayItemInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcodes)
	{
		GetArrayItemInfoRequest getArrayItemInfoRequest = new GetArrayItemInfoRequest();
		getArrayItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getArrayItemInfoRequest.AuthUser = AuthUser;
		getArrayItemInfoRequest.barcodes = barcodes;
		return ((KyanOnlineSaleServiceSoap)this).GetArrayItemInfoAsync(getArrayItemInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemStockStatusResponse KyanOnlineSaleServiceSoap.GetItemStockStatus(GetItemStockStatusRequest request)
	{
		return base.Channel.GetItemStockStatus(request);
	}

	public ResponseDataOfLoanItemStock GetItemStockStatus(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetItemStockStatusRequest getItemStockStatusRequest = new GetItemStockStatusRequest();
		getItemStockStatusRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemStockStatusRequest.AuthUser = AuthUser;
		getItemStockStatusRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetItemStockStatus(getItemStockStatusRequest).GetItemStockStatusResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemStockStatusResponse> KyanOnlineSaleServiceSoap.GetItemStockStatusAsync(GetItemStockStatusRequest request)
	{
		return base.Channel.GetItemStockStatusAsync(request);
	}

	public Task<GetItemStockStatusResponse> GetItemStockStatusAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetItemStockStatusRequest getItemStockStatusRequest = new GetItemStockStatusRequest();
		getItemStockStatusRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemStockStatusRequest.AuthUser = AuthUser;
		getItemStockStatusRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetItemStockStatusAsync(getItemStockStatusRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTemplatePropertyResponse KyanOnlineSaleServiceSoap.GetTemplateProperty(GetTemplatePropertyRequest request)
	{
		return base.Channel.GetTemplateProperty(request);
	}

	public ResponseDataOfTemplate GetTemplateProperty(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTemplatePropertyRequest getTemplatePropertyRequest = new GetTemplatePropertyRequest();
		getTemplatePropertyRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplatePropertyRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplateProperty(getTemplatePropertyRequest).GetTemplatePropertyResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTemplatePropertyResponse> KyanOnlineSaleServiceSoap.GetTemplatePropertyAsync(GetTemplatePropertyRequest request)
	{
		return base.Channel.GetTemplatePropertyAsync(request);
	}

	public Task<GetTemplatePropertyResponse> GetTemplatePropertyAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTemplatePropertyRequest getTemplatePropertyRequest = new GetTemplatePropertyRequest();
		getTemplatePropertyRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplatePropertyRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplatePropertyAsync(getTemplatePropertyRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTemplateAttributesResponse KyanOnlineSaleServiceSoap.GetTemplateAttributes(GetTemplateAttributesRequest request)
	{
		return base.Channel.GetTemplateAttributes(request);
	}

	public ResponseDataOfAttribute GetTemplateAttributes(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTemplateAttributesRequest getTemplateAttributesRequest = new GetTemplateAttributesRequest();
		getTemplateAttributesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplateAttributesRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplateAttributes(getTemplateAttributesRequest).GetTemplateAttributesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTemplateAttributesResponse> KyanOnlineSaleServiceSoap.GetTemplateAttributesAsync(GetTemplateAttributesRequest request)
	{
		return base.Channel.GetTemplateAttributesAsync(request);
	}

	public Task<GetTemplateAttributesResponse> GetTemplateAttributesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTemplateAttributesRequest getTemplateAttributesRequest = new GetTemplateAttributesRequest();
		getTemplateAttributesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplateAttributesRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplateAttributesAsync(getTemplateAttributesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTemplateItemInfoResponse KyanOnlineSaleServiceSoap.GetTemplateItemInfo(GetTemplateItemInfoRequest request)
	{
		return base.Channel.GetTemplateItemInfo(request);
	}

	public ResponseDataOfTemplateItem GetTemplateItemInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetTemplateItemInfoRequest getTemplateItemInfoRequest = new GetTemplateItemInfoRequest();
		getTemplateItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplateItemInfoRequest.AuthUser = AuthUser;
		getTemplateItemInfoRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplateItemInfo(getTemplateItemInfoRequest).GetTemplateItemInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTemplateItemInfoResponse> KyanOnlineSaleServiceSoap.GetTemplateItemInfoAsync(GetTemplateItemInfoRequest request)
	{
		return base.Channel.GetTemplateItemInfoAsync(request);
	}

	public Task<GetTemplateItemInfoResponse> GetTemplateItemInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetTemplateItemInfoRequest getTemplateItemInfoRequest = new GetTemplateItemInfoRequest();
		getTemplateItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTemplateItemInfoRequest.AuthUser = AuthUser;
		getTemplateItemInfoRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetTemplateItemInfoAsync(getTemplateItemInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetAllTemplateItemsResponse KyanOnlineSaleServiceSoap.GetAllTemplateItems(GetAllTemplateItemsRequest request)
	{
		return base.Channel.GetAllTemplateItems(request);
	}

	public ResponseDataOfTemplateItem GetAllTemplateItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetAllTemplateItemsRequest getAllTemplateItemsRequest = new GetAllTemplateItemsRequest();
		getAllTemplateItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getAllTemplateItemsRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetAllTemplateItems(getAllTemplateItemsRequest).GetAllTemplateItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetAllTemplateItemsResponse> KyanOnlineSaleServiceSoap.GetAllTemplateItemsAsync(GetAllTemplateItemsRequest request)
	{
		return base.Channel.GetAllTemplateItemsAsync(request);
	}

	public Task<GetAllTemplateItemsResponse> GetAllTemplateItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetAllTemplateItemsRequest getAllTemplateItemsRequest = new GetAllTemplateItemsRequest();
		getAllTemplateItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getAllTemplateItemsRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetAllTemplateItemsAsync(getAllTemplateItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetMatrixPropertyResponse KyanOnlineSaleServiceSoap.GetMatrixProperty(GetMatrixPropertyRequest request)
	{
		return base.Channel.GetMatrixProperty(request);
	}

	public ResponseDataOfTemplate GetMatrixProperty(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetMatrixPropertyRequest getMatrixPropertyRequest = new GetMatrixPropertyRequest();
		getMatrixPropertyRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixPropertyRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixProperty(getMatrixPropertyRequest).GetMatrixPropertyResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetMatrixPropertyResponse> KyanOnlineSaleServiceSoap.GetMatrixPropertyAsync(GetMatrixPropertyRequest request)
	{
		return base.Channel.GetMatrixPropertyAsync(request);
	}

	public Task<GetMatrixPropertyResponse> GetMatrixPropertyAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetMatrixPropertyRequest getMatrixPropertyRequest = new GetMatrixPropertyRequest();
		getMatrixPropertyRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixPropertyRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixPropertyAsync(getMatrixPropertyRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetMatrixAttributeResponse KyanOnlineSaleServiceSoap.GetMatrixAttribute(GetMatrixAttributeRequest request)
	{
		return base.Channel.GetMatrixAttribute(request);
	}

	public ResponseDataOfAttribute GetMatrixAttribute(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetMatrixAttributeRequest getMatrixAttributeRequest = new GetMatrixAttributeRequest();
		getMatrixAttributeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixAttributeRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixAttribute(getMatrixAttributeRequest).GetMatrixAttributeResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetMatrixAttributeResponse> KyanOnlineSaleServiceSoap.GetMatrixAttributeAsync(GetMatrixAttributeRequest request)
	{
		return base.Channel.GetMatrixAttributeAsync(request);
	}

	public Task<GetMatrixAttributeResponse> GetMatrixAttributeAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetMatrixAttributeRequest getMatrixAttributeRequest = new GetMatrixAttributeRequest();
		getMatrixAttributeRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixAttributeRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixAttributeAsync(getMatrixAttributeRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetMatrixItemInfoResponse KyanOnlineSaleServiceSoap.GetMatrixItemInfo(GetMatrixItemInfoRequest request)
	{
		return base.Channel.GetMatrixItemInfo(request);
	}

	public ResponseDataOfTemplateItem GetMatrixItemInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetMatrixItemInfoRequest getMatrixItemInfoRequest = new GetMatrixItemInfoRequest();
		getMatrixItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixItemInfoRequest.AuthUser = AuthUser;
		getMatrixItemInfoRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixItemInfo(getMatrixItemInfoRequest).GetMatrixItemInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetMatrixItemInfoResponse> KyanOnlineSaleServiceSoap.GetMatrixItemInfoAsync(GetMatrixItemInfoRequest request)
	{
		return base.Channel.GetMatrixItemInfoAsync(request);
	}

	public Task<GetMatrixItemInfoResponse> GetMatrixItemInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string Barcode)
	{
		GetMatrixItemInfoRequest getMatrixItemInfoRequest = new GetMatrixItemInfoRequest();
		getMatrixItemInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getMatrixItemInfoRequest.AuthUser = AuthUser;
		getMatrixItemInfoRequest.Barcode = Barcode;
		return ((KyanOnlineSaleServiceSoap)this).GetMatrixItemInfoAsync(getMatrixItemInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetAllMatrixItemsResponse KyanOnlineSaleServiceSoap.GetAllMatrixItems(GetAllMatrixItemsRequest request)
	{
		return base.Channel.GetAllMatrixItems(request);
	}

	public ResponseDataOfTemplateItem GetAllMatrixItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetAllMatrixItemsRequest getAllMatrixItemsRequest = new GetAllMatrixItemsRequest();
		getAllMatrixItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getAllMatrixItemsRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetAllMatrixItems(getAllMatrixItemsRequest).GetAllMatrixItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetAllMatrixItemsResponse> KyanOnlineSaleServiceSoap.GetAllMatrixItemsAsync(GetAllMatrixItemsRequest request)
	{
		return base.Channel.GetAllMatrixItemsAsync(request);
	}

	public Task<GetAllMatrixItemsResponse> GetAllMatrixItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetAllMatrixItemsRequest getAllMatrixItemsRequest = new GetAllMatrixItemsRequest();
		getAllMatrixItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getAllMatrixItemsRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetAllMatrixItemsAsync(getAllMatrixItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPosDepartmentListResponse KyanOnlineSaleServiceSoap.GetPosDepartmentList(GetPosDepartmentListRequest request)
	{
		return base.Channel.GetPosDepartmentList(request);
	}

	public ResponseDataOfPosDepartment GetPosDepartmentList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetPosDepartmentListRequest getPosDepartmentListRequest = new GetPosDepartmentListRequest();
		getPosDepartmentListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPosDepartmentListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetPosDepartmentList(getPosDepartmentListRequest).GetPosDepartmentListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetPosDepartmentListResponse> KyanOnlineSaleServiceSoap.GetPosDepartmentListAsync(GetPosDepartmentListRequest request)
	{
		return base.Channel.GetPosDepartmentListAsync(request);
	}

	public Task<GetPosDepartmentListResponse> GetPosDepartmentListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetPosDepartmentListRequest getPosDepartmentListRequest = new GetPosDepartmentListRequest();
		getPosDepartmentListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPosDepartmentListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetPosDepartmentListAsync(getPosDepartmentListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPosDepartmentLevelListResponse KyanOnlineSaleServiceSoap.GetPosDepartmentLevelList(GetPosDepartmentLevelListRequest request)
	{
		return base.Channel.GetPosDepartmentLevelList(request);
	}

	public ResponseDataOfPosDepartmentList GetPosDepartmentLevelList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetPosDepartmentLevelListRequest getPosDepartmentLevelListRequest = new GetPosDepartmentLevelListRequest();
		getPosDepartmentLevelListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPosDepartmentLevelListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetPosDepartmentLevelList(getPosDepartmentLevelListRequest).GetPosDepartmentLevelListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetPosDepartmentLevelListResponse> KyanOnlineSaleServiceSoap.GetPosDepartmentLevelListAsync(GetPosDepartmentLevelListRequest request)
	{
		return base.Channel.GetPosDepartmentLevelListAsync(request);
	}

	public Task<GetPosDepartmentLevelListResponse> GetPosDepartmentLevelListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetPosDepartmentLevelListRequest getPosDepartmentLevelListRequest = new GetPosDepartmentLevelListRequest();
		getPosDepartmentLevelListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPosDepartmentLevelListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetPosDepartmentLevelListAsync(getPosDepartmentLevelListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetInventoriesListResponse KyanOnlineSaleServiceSoap.GetInventoriesList(GetInventoriesListRequest request)
	{
		return base.Channel.GetInventoriesList(request);
	}

	public ResponseDataOfInventory GetInventoriesList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetInventoriesListRequest getInventoriesListRequest = new GetInventoriesListRequest();
		getInventoriesListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getInventoriesListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetInventoriesList(getInventoriesListRequest).GetInventoriesListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetInventoriesListResponse> KyanOnlineSaleServiceSoap.GetInventoriesListAsync(GetInventoriesListRequest request)
	{
		return base.Channel.GetInventoriesListAsync(request);
	}

	public Task<GetInventoriesListResponse> GetInventoriesListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetInventoriesListRequest getInventoriesListRequest = new GetInventoriesListRequest();
		getInventoriesListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getInventoriesListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetInventoriesListAsync(getInventoriesListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	QuickExternalTransferOutResponse KyanOnlineSaleServiceSoap.QuickExternalTransferOut(QuickExternalTransferOutRequest request)
	{
		return base.Channel.QuickExternalTransferOut(request);
	}

	public ResponseDataOfQuickTransferResult QuickExternalTransferOut(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int DestinationRsID)
	{
		QuickExternalTransferOutRequest quickExternalTransferOutRequest = new QuickExternalTransferOutRequest();
		quickExternalTransferOutRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferOutRequest.AuthUser = AuthUser;
		quickExternalTransferOutRequest.LstTransfer = LstTransfer;
		quickExternalTransferOutRequest.DestinationRsID = DestinationRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransferOut(quickExternalTransferOutRequest).QuickExternalTransferOutResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<QuickExternalTransferOutResponse> KyanOnlineSaleServiceSoap.QuickExternalTransferOutAsync(QuickExternalTransferOutRequest request)
	{
		return base.Channel.QuickExternalTransferOutAsync(request);
	}

	public Task<QuickExternalTransferOutResponse> QuickExternalTransferOutAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int DestinationRsID)
	{
		QuickExternalTransferOutRequest quickExternalTransferOutRequest = new QuickExternalTransferOutRequest();
		quickExternalTransferOutRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferOutRequest.AuthUser = AuthUser;
		quickExternalTransferOutRequest.LstTransfer = LstTransfer;
		quickExternalTransferOutRequest.DestinationRsID = DestinationRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransferOutAsync(quickExternalTransferOutRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	QuickExternalTransferInResponse KyanOnlineSaleServiceSoap.QuickExternalTransferIn(QuickExternalTransferInRequest request)
	{
		return base.Channel.QuickExternalTransferIn(request);
	}

	public ResponseDataOfQuickTransferResult QuickExternalTransferIn(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int SourceRsID)
	{
		QuickExternalTransferInRequest quickExternalTransferInRequest = new QuickExternalTransferInRequest();
		quickExternalTransferInRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferInRequest.AuthUser = AuthUser;
		quickExternalTransferInRequest.LstTransfer = LstTransfer;
		quickExternalTransferInRequest.SourceRsID = SourceRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransferIn(quickExternalTransferInRequest).QuickExternalTransferInResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<QuickExternalTransferInResponse> KyanOnlineSaleServiceSoap.QuickExternalTransferInAsync(QuickExternalTransferInRequest request)
	{
		return base.Channel.QuickExternalTransferInAsync(request);
	}

	public Task<QuickExternalTransferInResponse> QuickExternalTransferInAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int SourceRsID)
	{
		QuickExternalTransferInRequest quickExternalTransferInRequest = new QuickExternalTransferInRequest();
		quickExternalTransferInRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferInRequest.AuthUser = AuthUser;
		quickExternalTransferInRequest.LstTransfer = LstTransfer;
		quickExternalTransferInRequest.SourceRsID = SourceRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransferInAsync(quickExternalTransferInRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ItemOrderResponse KyanOnlineSaleServiceSoap.ItemOrder(ItemOrderRequest request)
	{
		return base.Channel.ItemOrder(request);
	}

	public ResponseDataOfString ItemOrder(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, OrderHeader orderHeader, OrderDetails[] orderLineItem)
	{
		ItemOrderRequest itemOrderRequest = new ItemOrderRequest();
		itemOrderRequest.ValidationSoapHeader = ValidationSoapHeader;
		itemOrderRequest.AuthUser = AuthUser;
		itemOrderRequest.orderHeader = orderHeader;
		itemOrderRequest.orderLineItem = orderLineItem;
		return ((KyanOnlineSaleServiceSoap)this).ItemOrder(itemOrderRequest).ItemOrderResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ItemOrderResponse> KyanOnlineSaleServiceSoap.ItemOrderAsync(ItemOrderRequest request)
	{
		return base.Channel.ItemOrderAsync(request);
	}

	public Task<ItemOrderResponse> ItemOrderAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, OrderHeader orderHeader, OrderDetails[] orderLineItem)
	{
		ItemOrderRequest itemOrderRequest = new ItemOrderRequest();
		itemOrderRequest.ValidationSoapHeader = ValidationSoapHeader;
		itemOrderRequest.AuthUser = AuthUser;
		itemOrderRequest.orderHeader = orderHeader;
		itemOrderRequest.orderLineItem = orderLineItem;
		return ((KyanOnlineSaleServiceSoap)this).ItemOrderAsync(itemOrderRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ItemReceivingResponse KyanOnlineSaleServiceSoap.ItemReceiving(ItemReceivingRequest request)
	{
		return base.Channel.ItemReceiving(request);
	}

	public ResponseDataOfString ItemReceiving(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReceiveHeader receiveHeader, OrderDetails[] orderLineItem)
	{
		ItemReceivingRequest itemReceivingRequest = new ItemReceivingRequest();
		itemReceivingRequest.ValidationSoapHeader = ValidationSoapHeader;
		itemReceivingRequest.AuthUser = AuthUser;
		itemReceivingRequest.receiveHeader = receiveHeader;
		itemReceivingRequest.orderLineItem = orderLineItem;
		return ((KyanOnlineSaleServiceSoap)this).ItemReceiving(itemReceivingRequest).ItemReceivingResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ItemReceivingResponse> KyanOnlineSaleServiceSoap.ItemReceivingAsync(ItemReceivingRequest request)
	{
		return base.Channel.ItemReceivingAsync(request);
	}

	public Task<ItemReceivingResponse> ItemReceivingAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReceiveHeader receiveHeader, OrderDetails[] orderLineItem)
	{
		ItemReceivingRequest itemReceivingRequest = new ItemReceivingRequest();
		itemReceivingRequest.ValidationSoapHeader = ValidationSoapHeader;
		itemReceivingRequest.AuthUser = AuthUser;
		itemReceivingRequest.receiveHeader = receiveHeader;
		itemReceivingRequest.orderLineItem = orderLineItem;
		return ((KyanOnlineSaleServiceSoap)this).ItemReceivingAsync(itemReceivingRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CreateCustomerResponse KyanOnlineSaleServiceSoap.CreateCustomer(CreateCustomerRequest request)
	{
		return base.Channel.CreateCustomer(request);
	}

	public ResponseDataOfString CreateCustomer(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer)
	{
		CreateCustomerRequest createCustomerRequest = new CreateCustomerRequest();
		createCustomerRequest.ValidationSoapHeader = ValidationSoapHeader;
		createCustomerRequest.AuthUser = AuthUser;
		createCustomerRequest.NewCustomer = NewCustomer;
		return ((KyanOnlineSaleServiceSoap)this).CreateCustomer(createCustomerRequest).CreateCustomerResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CreateCustomerResponse> KyanOnlineSaleServiceSoap.CreateCustomerAsync(CreateCustomerRequest request)
	{
		return base.Channel.CreateCustomerAsync(request);
	}

	public Task<CreateCustomerResponse> CreateCustomerAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer)
	{
		CreateCustomerRequest createCustomerRequest = new CreateCustomerRequest();
		createCustomerRequest.ValidationSoapHeader = ValidationSoapHeader;
		createCustomerRequest.AuthUser = AuthUser;
		createCustomerRequest.NewCustomer = NewCustomer;
		return ((KyanOnlineSaleServiceSoap)this).CreateCustomerAsync(createCustomerRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CreateCustomerToRSResponse KyanOnlineSaleServiceSoap.CreateCustomerToRS(CreateCustomerToRSRequest request)
	{
		return base.Channel.CreateCustomerToRS(request);
	}

	public ResponseDataOfString CreateCustomerToRS(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer, int RetailStoreID)
	{
		CreateCustomerToRSRequest createCustomerToRSRequest = new CreateCustomerToRSRequest();
		createCustomerToRSRequest.ValidationSoapHeader = ValidationSoapHeader;
		createCustomerToRSRequest.AuthUser = AuthUser;
		createCustomerToRSRequest.NewCustomer = NewCustomer;
		createCustomerToRSRequest.RetailStoreID = RetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).CreateCustomerToRS(createCustomerToRSRequest).CreateCustomerToRSResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CreateCustomerToRSResponse> KyanOnlineSaleServiceSoap.CreateCustomerToRSAsync(CreateCustomerToRSRequest request)
	{
		return base.Channel.CreateCustomerToRSAsync(request);
	}

	public Task<CreateCustomerToRSResponse> CreateCustomerToRSAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer NewCustomer, int RetailStoreID)
	{
		CreateCustomerToRSRequest createCustomerToRSRequest = new CreateCustomerToRSRequest();
		createCustomerToRSRequest.ValidationSoapHeader = ValidationSoapHeader;
		createCustomerToRSRequest.AuthUser = AuthUser;
		createCustomerToRSRequest.NewCustomer = NewCustomer;
		createCustomerToRSRequest.RetailStoreID = RetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).CreateCustomerToRSAsync(createCustomerToRSRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerListResponse KyanOnlineSaleServiceSoap.GetCustomerList(GetCustomerListRequest request)
	{
		return base.Channel.GetCustomerList(request);
	}

	public ResponseDataOfCustomer GetCustomerList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetCustomerListRequest getCustomerListRequest = new GetCustomerListRequest();
		getCustomerListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerListRequest.AuthUser = AuthUser;
		getCustomerListRequest.StartDate = StartDate;
		getCustomerListRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerList(getCustomerListRequest).GetCustomerListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerListResponse> KyanOnlineSaleServiceSoap.GetCustomerListAsync(GetCustomerListRequest request)
	{
		return base.Channel.GetCustomerListAsync(request);
	}

	public Task<GetCustomerListResponse> GetCustomerListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetCustomerListRequest getCustomerListRequest = new GetCustomerListRequest();
		getCustomerListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerListRequest.AuthUser = AuthUser;
		getCustomerListRequest.StartDate = StartDate;
		getCustomerListRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerListAsync(getCustomerListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerListWithPageRowResponse KyanOnlineSaleServiceSoap.GetCustomerListWithPageRow(GetCustomerListWithPageRowRequest request)
	{
		return base.Channel.GetCustomerListWithPageRow(request);
	}

	public ResponseDataOfcustomerModel GetCustomerListWithPageRow(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, DateTime? StartDate, DateTime? EndDate, int RowNoBgin, int PageRow, int DefinationLocation)
	{
		GetCustomerListWithPageRowRequest getCustomerListWithPageRowRequest = new GetCustomerListWithPageRowRequest();
		getCustomerListWithPageRowRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerListWithPageRowRequest.AuthUser = AuthUser;
		getCustomerListWithPageRowRequest.StartDate = StartDate;
		getCustomerListWithPageRowRequest.EndDate = EndDate;
		getCustomerListWithPageRowRequest.RowNoBgin = RowNoBgin;
		getCustomerListWithPageRowRequest.PageRow = PageRow;
		getCustomerListWithPageRowRequest.DefinationLocation = DefinationLocation;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerListWithPageRow(getCustomerListWithPageRowRequest).GetCustomerListWithPageRowResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerListWithPageRowResponse> KyanOnlineSaleServiceSoap.GetCustomerListWithPageRowAsync(GetCustomerListWithPageRowRequest request)
	{
		return base.Channel.GetCustomerListWithPageRowAsync(request);
	}

	public Task<GetCustomerListWithPageRowResponse> GetCustomerListWithPageRowAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, DateTime? StartDate, DateTime? EndDate, int RowNoBgin, int PageRow, int DefinationLocation)
	{
		GetCustomerListWithPageRowRequest getCustomerListWithPageRowRequest = new GetCustomerListWithPageRowRequest();
		getCustomerListWithPageRowRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerListWithPageRowRequest.AuthUser = AuthUser;
		getCustomerListWithPageRowRequest.StartDate = StartDate;
		getCustomerListWithPageRowRequest.EndDate = EndDate;
		getCustomerListWithPageRowRequest.RowNoBgin = RowNoBgin;
		getCustomerListWithPageRowRequest.PageRow = PageRow;
		getCustomerListWithPageRowRequest.DefinationLocation = DefinationLocation;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerListWithPageRowAsync(getCustomerListWithPageRowRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerInfoWithCustomerIDResponse KyanOnlineSaleServiceSoap.GetCustomerInfoWithCustomerID(GetCustomerInfoWithCustomerIDRequest request)
	{
		return base.Channel.GetCustomerInfoWithCustomerID(request);
	}

	public ResponseDataOfCustomer GetCustomerInfoWithCustomerID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID)
	{
		GetCustomerInfoWithCustomerIDRequest getCustomerInfoWithCustomerIDRequest = new GetCustomerInfoWithCustomerIDRequest();
		getCustomerInfoWithCustomerIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerInfoWithCustomerIDRequest.AuthUser = AuthUser;
		getCustomerInfoWithCustomerIDRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerInfoWithCustomerID(getCustomerInfoWithCustomerIDRequest).GetCustomerInfoWithCustomerIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerInfoWithCustomerIDResponse> KyanOnlineSaleServiceSoap.GetCustomerInfoWithCustomerIDAsync(GetCustomerInfoWithCustomerIDRequest request)
	{
		return base.Channel.GetCustomerInfoWithCustomerIDAsync(request);
	}

	public Task<GetCustomerInfoWithCustomerIDResponse> GetCustomerInfoWithCustomerIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID)
	{
		GetCustomerInfoWithCustomerIDRequest getCustomerInfoWithCustomerIDRequest = new GetCustomerInfoWithCustomerIDRequest();
		getCustomerInfoWithCustomerIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerInfoWithCustomerIDRequest.AuthUser = AuthUser;
		getCustomerInfoWithCustomerIDRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerInfoWithCustomerIDAsync(getCustomerInfoWithCustomerIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerInfoWithMemberIDResponse KyanOnlineSaleServiceSoap.GetCustomerInfoWithMemberID(GetCustomerInfoWithMemberIDRequest request)
	{
		return base.Channel.GetCustomerInfoWithMemberID(request);
	}

	public ResponseDataOfCustomer GetCustomerInfoWithMemberID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string MemberID)
	{
		GetCustomerInfoWithMemberIDRequest getCustomerInfoWithMemberIDRequest = new GetCustomerInfoWithMemberIDRequest();
		getCustomerInfoWithMemberIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerInfoWithMemberIDRequest.AuthUser = AuthUser;
		getCustomerInfoWithMemberIDRequest.MemberID = MemberID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerInfoWithMemberID(getCustomerInfoWithMemberIDRequest).GetCustomerInfoWithMemberIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerInfoWithMemberIDResponse> KyanOnlineSaleServiceSoap.GetCustomerInfoWithMemberIDAsync(GetCustomerInfoWithMemberIDRequest request)
	{
		return base.Channel.GetCustomerInfoWithMemberIDAsync(request);
	}

	public Task<GetCustomerInfoWithMemberIDResponse> GetCustomerInfoWithMemberIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string MemberID)
	{
		GetCustomerInfoWithMemberIDRequest getCustomerInfoWithMemberIDRequest = new GetCustomerInfoWithMemberIDRequest();
		getCustomerInfoWithMemberIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerInfoWithMemberIDRequest.AuthUser = AuthUser;
		getCustomerInfoWithMemberIDRequest.MemberID = MemberID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerInfoWithMemberIDAsync(getCustomerInfoWithMemberIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomersBaseInfoResponse KyanOnlineSaleServiceSoap.GetCustomersBaseInfo(GetCustomersBaseInfoRequest request)
	{
		return base.Channel.GetCustomersBaseInfo(request);
	}

	public ResponseDataOfCustomer GetCustomersBaseInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, FiledName filedName, string[] value)
	{
		GetCustomersBaseInfoRequest getCustomersBaseInfoRequest = new GetCustomersBaseInfoRequest();
		getCustomersBaseInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomersBaseInfoRequest.AuthUser = AuthUser;
		getCustomersBaseInfoRequest.filedName = filedName;
		getCustomersBaseInfoRequest.value = value;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomersBaseInfo(getCustomersBaseInfoRequest).GetCustomersBaseInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomersBaseInfoResponse> KyanOnlineSaleServiceSoap.GetCustomersBaseInfoAsync(GetCustomersBaseInfoRequest request)
	{
		return base.Channel.GetCustomersBaseInfoAsync(request);
	}

	public Task<GetCustomersBaseInfoResponse> GetCustomersBaseInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, FiledName filedName, string[] value)
	{
		GetCustomersBaseInfoRequest getCustomersBaseInfoRequest = new GetCustomersBaseInfoRequest();
		getCustomersBaseInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomersBaseInfoRequest.AuthUser = AuthUser;
		getCustomersBaseInfoRequest.filedName = filedName;
		getCustomersBaseInfoRequest.value = value;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomersBaseInfoAsync(getCustomersBaseInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	UpdateCustomerInfoResponse KyanOnlineSaleServiceSoap.UpdateCustomerInfo(UpdateCustomerInfoRequest request)
	{
		return base.Channel.UpdateCustomerInfo(request);
	}

	public ResponseDataOfCustomer UpdateCustomerInfo(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer UpdattedCustomer)
	{
		UpdateCustomerInfoRequest updateCustomerInfoRequest = new UpdateCustomerInfoRequest();
		updateCustomerInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		updateCustomerInfoRequest.AuthUser = AuthUser;
		updateCustomerInfoRequest.UpdattedCustomer = UpdattedCustomer;
		return ((KyanOnlineSaleServiceSoap)this).UpdateCustomerInfo(updateCustomerInfoRequest).UpdateCustomerInfoResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<UpdateCustomerInfoResponse> KyanOnlineSaleServiceSoap.UpdateCustomerInfoAsync(UpdateCustomerInfoRequest request)
	{
		return base.Channel.UpdateCustomerInfoAsync(request);
	}

	public Task<UpdateCustomerInfoResponse> UpdateCustomerInfoAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, Customer UpdattedCustomer)
	{
		UpdateCustomerInfoRequest updateCustomerInfoRequest = new UpdateCustomerInfoRequest();
		updateCustomerInfoRequest.ValidationSoapHeader = ValidationSoapHeader;
		updateCustomerInfoRequest.AuthUser = AuthUser;
		updateCustomerInfoRequest.UpdattedCustomer = UpdattedCustomer;
		return ((KyanOnlineSaleServiceSoap)this).UpdateCustomerInfoAsync(updateCustomerInfoRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerAddressInfoWithCustomerIDResponse KyanOnlineSaleServiceSoap.GetCustomerAddressInfoWithCustomerID(GetCustomerAddressInfoWithCustomerIDRequest request)
	{
		return base.Channel.GetCustomerAddressInfoWithCustomerID(request);
	}

	public ResponseDataOfCustomerAddress GetCustomerAddressInfoWithCustomerID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID)
	{
		GetCustomerAddressInfoWithCustomerIDRequest getCustomerAddressInfoWithCustomerIDRequest = new GetCustomerAddressInfoWithCustomerIDRequest();
		getCustomerAddressInfoWithCustomerIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerAddressInfoWithCustomerIDRequest.AuthUser = AuthUser;
		getCustomerAddressInfoWithCustomerIDRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerAddressInfoWithCustomerID(getCustomerAddressInfoWithCustomerIDRequest).GetCustomerAddressInfoWithCustomerIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerAddressInfoWithCustomerIDResponse> KyanOnlineSaleServiceSoap.GetCustomerAddressInfoWithCustomerIDAsync(GetCustomerAddressInfoWithCustomerIDRequest request)
	{
		return base.Channel.GetCustomerAddressInfoWithCustomerIDAsync(request);
	}

	public Task<GetCustomerAddressInfoWithCustomerIDResponse> GetCustomerAddressInfoWithCustomerIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID)
	{
		GetCustomerAddressInfoWithCustomerIDRequest getCustomerAddressInfoWithCustomerIDRequest = new GetCustomerAddressInfoWithCustomerIDRequest();
		getCustomerAddressInfoWithCustomerIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerAddressInfoWithCustomerIDRequest.AuthUser = AuthUser;
		getCustomerAddressInfoWithCustomerIDRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerAddressInfoWithCustomerIDAsync(getCustomerAddressInfoWithCustomerIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerGroupResponse KyanOnlineSaleServiceSoap.GetCustomerGroup(GetCustomerGroupRequest request)
	{
		return base.Channel.GetCustomerGroup(request);
	}

	public ResponseDataOfcustomerGroup GetCustomerGroup(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetCustomerGroupRequest getCustomerGroupRequest = new GetCustomerGroupRequest();
		getCustomerGroupRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerGroupRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerGroup(getCustomerGroupRequest).GetCustomerGroupResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerGroupResponse> KyanOnlineSaleServiceSoap.GetCustomerGroupAsync(GetCustomerGroupRequest request)
	{
		return base.Channel.GetCustomerGroupAsync(request);
	}

	public Task<GetCustomerGroupResponse> GetCustomerGroupAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetCustomerGroupRequest getCustomerGroupRequest = new GetCustomerGroupRequest();
		getCustomerGroupRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerGroupRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerGroupAsync(getCustomerGroupRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetCustomerTransactionResponse KyanOnlineSaleServiceSoap.GetCustomerTransaction(GetCustomerTransactionRequest request)
	{
		return base.Channel.GetCustomerTransaction(request);
	}

	public ResponseDataOfCustomerTransaction GetCustomerTransaction(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, string customerID)
	{
		GetCustomerTransactionRequest getCustomerTransactionRequest = new GetCustomerTransactionRequest();
		getCustomerTransactionRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerTransactionRequest.AuthUser = AuthUser;
		getCustomerTransactionRequest.StartDate = StartDate;
		getCustomerTransactionRequest.EndDate = EndDate;
		getCustomerTransactionRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerTransaction(getCustomerTransactionRequest).GetCustomerTransactionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetCustomerTransactionResponse> KyanOnlineSaleServiceSoap.GetCustomerTransactionAsync(GetCustomerTransactionRequest request)
	{
		return base.Channel.GetCustomerTransactionAsync(request);
	}

	public Task<GetCustomerTransactionResponse> GetCustomerTransactionAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate, string customerID)
	{
		GetCustomerTransactionRequest getCustomerTransactionRequest = new GetCustomerTransactionRequest();
		getCustomerTransactionRequest.ValidationSoapHeader = ValidationSoapHeader;
		getCustomerTransactionRequest.AuthUser = AuthUser;
		getCustomerTransactionRequest.StartDate = StartDate;
		getCustomerTransactionRequest.EndDate = EndDate;
		getCustomerTransactionRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).GetCustomerTransactionAsync(getCustomerTransactionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTransactionByRetailStoreIDResponse KyanOnlineSaleServiceSoap.GetTransactionByRetailStoreID(GetTransactionByRetailStoreIDRequest request)
	{
		return base.Channel.GetTransactionByRetailStoreID(request);
	}

	public ResponseDataOfReceiptDsInfModel GetTransactionByRetailStoreID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int? RS, DateTime StartDate, DateTime EndDate)
	{
		GetTransactionByRetailStoreIDRequest getTransactionByRetailStoreIDRequest = new GetTransactionByRetailStoreIDRequest();
		getTransactionByRetailStoreIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTransactionByRetailStoreIDRequest.AuthUser = AuthUser;
		getTransactionByRetailStoreIDRequest.RS = RS;
		getTransactionByRetailStoreIDRequest.StartDate = StartDate;
		getTransactionByRetailStoreIDRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetTransactionByRetailStoreID(getTransactionByRetailStoreIDRequest).GetTransactionByRetailStoreIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTransactionByRetailStoreIDResponse> KyanOnlineSaleServiceSoap.GetTransactionByRetailStoreIDAsync(GetTransactionByRetailStoreIDRequest request)
	{
		return base.Channel.GetTransactionByRetailStoreIDAsync(request);
	}

	public Task<GetTransactionByRetailStoreIDResponse> GetTransactionByRetailStoreIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int? RS, DateTime StartDate, DateTime EndDate)
	{
		GetTransactionByRetailStoreIDRequest getTransactionByRetailStoreIDRequest = new GetTransactionByRetailStoreIDRequest();
		getTransactionByRetailStoreIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTransactionByRetailStoreIDRequest.AuthUser = AuthUser;
		getTransactionByRetailStoreIDRequest.RS = RS;
		getTransactionByRetailStoreIDRequest.StartDate = StartDate;
		getTransactionByRetailStoreIDRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetTransactionByRetailStoreIDAsync(getTransactionByRetailStoreIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	BuycustomersResponse KyanOnlineSaleServiceSoap.Buycustomers(BuycustomersRequest request)
	{
		return base.Channel.Buycustomers(request);
	}

	public ResponseDataOfBuycustomersModel Buycustomers(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		BuycustomersRequest buycustomersRequest = new BuycustomersRequest();
		buycustomersRequest.ValidationSoapHeader = ValidationSoapHeader;
		buycustomersRequest.AuthUser = AuthUser;
		buycustomersRequest.StartDate = StartDate;
		buycustomersRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).Buycustomers(buycustomersRequest).BuycustomersResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<BuycustomersResponse> KyanOnlineSaleServiceSoap.BuycustomersAsync(BuycustomersRequest request)
	{
		return base.Channel.BuycustomersAsync(request);
	}

	public Task<BuycustomersResponse> BuycustomersAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		BuycustomersRequest buycustomersRequest = new BuycustomersRequest();
		buycustomersRequest.ValidationSoapHeader = ValidationSoapHeader;
		buycustomersRequest.AuthUser = AuthUser;
		buycustomersRequest.StartDate = StartDate;
		buycustomersRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).BuycustomersAsync(buycustomersRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	BuycustomersWithFactorItemsResponse KyanOnlineSaleServiceSoap.BuycustomersWithFactorItems(BuycustomersWithFactorItemsRequest request)
	{
		return base.Channel.BuycustomersWithFactorItems(request);
	}

	public ResponseDataOfBuycustomersWithFactorItemsModel BuycustomersWithFactorItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		BuycustomersWithFactorItemsRequest buycustomersWithFactorItemsRequest = new BuycustomersWithFactorItemsRequest();
		buycustomersWithFactorItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		buycustomersWithFactorItemsRequest.AuthUser = AuthUser;
		buycustomersWithFactorItemsRequest.StartDate = StartDate;
		buycustomersWithFactorItemsRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).BuycustomersWithFactorItems(buycustomersWithFactorItemsRequest).BuycustomersWithFactorItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<BuycustomersWithFactorItemsResponse> KyanOnlineSaleServiceSoap.BuycustomersWithFactorItemsAsync(BuycustomersWithFactorItemsRequest request)
	{
		return base.Channel.BuycustomersWithFactorItemsAsync(request);
	}

	public Task<BuycustomersWithFactorItemsResponse> BuycustomersWithFactorItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		BuycustomersWithFactorItemsRequest buycustomersWithFactorItemsRequest = new BuycustomersWithFactorItemsRequest();
		buycustomersWithFactorItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		buycustomersWithFactorItemsRequest.AuthUser = AuthUser;
		buycustomersWithFactorItemsRequest.StartDate = StartDate;
		buycustomersWithFactorItemsRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).BuycustomersWithFactorItemsAsync(buycustomersWithFactorItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CustomerCreditOperationsResponse KyanOnlineSaleServiceSoap.CustomerCreditOperations(CustomerCreditOperationsRequest request)
	{
		return base.Channel.CustomerCreditOperations(request);
	}

	public ResponseDataOfString CustomerCreditOperations(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID, decimal credit, OperationCredit operationCredit)
	{
		CustomerCreditOperationsRequest customerCreditOperationsRequest = new CustomerCreditOperationsRequest();
		customerCreditOperationsRequest.ValidationSoapHeader = ValidationSoapHeader;
		customerCreditOperationsRequest.AuthUser = AuthUser;
		customerCreditOperationsRequest.customerID = customerID;
		customerCreditOperationsRequest.credit = credit;
		customerCreditOperationsRequest.operationCredit = operationCredit;
		return ((KyanOnlineSaleServiceSoap)this).CustomerCreditOperations(customerCreditOperationsRequest).CustomerCreditOperationsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CustomerCreditOperationsResponse> KyanOnlineSaleServiceSoap.CustomerCreditOperationsAsync(CustomerCreditOperationsRequest request)
	{
		return base.Channel.CustomerCreditOperationsAsync(request);
	}

	public Task<CustomerCreditOperationsResponse> CustomerCreditOperationsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int customerID, decimal credit, OperationCredit operationCredit)
	{
		CustomerCreditOperationsRequest customerCreditOperationsRequest = new CustomerCreditOperationsRequest();
		customerCreditOperationsRequest.ValidationSoapHeader = ValidationSoapHeader;
		customerCreditOperationsRequest.AuthUser = AuthUser;
		customerCreditOperationsRequest.customerID = customerID;
		customerCreditOperationsRequest.credit = credit;
		customerCreditOperationsRequest.operationCredit = operationCredit;
		return ((KyanOnlineSaleServiceSoap)this).CustomerCreditOperationsAsync(customerCreditOperationsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTaxChargeAmountResponse KyanOnlineSaleServiceSoap.GetTaxChargeAmount(GetTaxChargeAmountRequest request)
	{
		return base.Channel.GetTaxChargeAmount(request);
	}

	public ResponseDataOfConfigEntity GetTaxChargeAmount(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTaxChargeAmountRequest getTaxChargeAmountRequest = new GetTaxChargeAmountRequest();
		getTaxChargeAmountRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTaxChargeAmountRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTaxChargeAmount(getTaxChargeAmountRequest).GetTaxChargeAmountResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTaxChargeAmountResponse> KyanOnlineSaleServiceSoap.GetTaxChargeAmountAsync(GetTaxChargeAmountRequest request)
	{
		return base.Channel.GetTaxChargeAmountAsync(request);
	}

	public Task<GetTaxChargeAmountResponse> GetTaxChargeAmountAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTaxChargeAmountRequest getTaxChargeAmountRequest = new GetTaxChargeAmountRequest();
		getTaxChargeAmountRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTaxChargeAmountRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTaxChargeAmountAsync(getTaxChargeAmountRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTenderListResponse KyanOnlineSaleServiceSoap.GetTenderList(GetTenderListRequest request)
	{
		return base.Channel.GetTenderList(request);
	}

	public ResponseDataOfTenderModel GetTenderList(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTenderListRequest getTenderListRequest = new GetTenderListRequest();
		getTenderListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTenderListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTenderList(getTenderListRequest).GetTenderListResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTenderListResponse> KyanOnlineSaleServiceSoap.GetTenderListAsync(GetTenderListRequest request)
	{
		return base.Channel.GetTenderListAsync(request);
	}

	public Task<GetTenderListResponse> GetTenderListAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetTenderListRequest getTenderListRequest = new GetTenderListRequest();
		getTenderListRequest.ValidationSoapHeader = ValidationSoapHeader;
		getTenderListRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetTenderListAsync(getTenderListRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPromotionsResponse KyanOnlineSaleServiceSoap.GetPromotions(GetPromotionsRequest request)
	{
		return base.Channel.GetPromotions(request);
	}

	public ResponseDataOfPromotionHeaderModel GetPromotions(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retialStore)
	{
		GetPromotionsRequest getPromotionsRequest = new GetPromotionsRequest();
		getPromotionsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPromotionsRequest.AuthUser = AuthUser;
		getPromotionsRequest.retialStore = retialStore;
		return ((KyanOnlineSaleServiceSoap)this).GetPromotions(getPromotionsRequest).GetPromotionsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetPromotionsResponse> KyanOnlineSaleServiceSoap.GetPromotionsAsync(GetPromotionsRequest request)
	{
		return base.Channel.GetPromotionsAsync(request);
	}

	public Task<GetPromotionsResponse> GetPromotionsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retialStore)
	{
		GetPromotionsRequest getPromotionsRequest = new GetPromotionsRequest();
		getPromotionsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPromotionsRequest.AuthUser = AuthUser;
		getPromotionsRequest.retialStore = retialStore;
		return ((KyanOnlineSaleServiceSoap)this).GetPromotionsAsync(getPromotionsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetPromotionCustomerGroupsResponse KyanOnlineSaleServiceSoap.GetPromotionCustomerGroups(GetPromotionCustomerGroupsRequest request)
	{
		return base.Channel.GetPromotionCustomerGroups(request);
	}

	public ResponseDataOfPromotionCustomerGroupModel GetPromotionCustomerGroups(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retialStore)
	{
		GetPromotionCustomerGroupsRequest getPromotionCustomerGroupsRequest = new GetPromotionCustomerGroupsRequest();
		getPromotionCustomerGroupsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPromotionCustomerGroupsRequest.AuthUser = AuthUser;
		getPromotionCustomerGroupsRequest.retialStore = retialStore;
		return ((KyanOnlineSaleServiceSoap)this).GetPromotionCustomerGroups(getPromotionCustomerGroupsRequest).GetPromotionCustomerGroupsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetPromotionCustomerGroupsResponse> KyanOnlineSaleServiceSoap.GetPromotionCustomerGroupsAsync(GetPromotionCustomerGroupsRequest request)
	{
		return base.Channel.GetPromotionCustomerGroupsAsync(request);
	}

	public Task<GetPromotionCustomerGroupsResponse> GetPromotionCustomerGroupsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int retialStore)
	{
		GetPromotionCustomerGroupsRequest getPromotionCustomerGroupsRequest = new GetPromotionCustomerGroupsRequest();
		getPromotionCustomerGroupsRequest.ValidationSoapHeader = ValidationSoapHeader;
		getPromotionCustomerGroupsRequest.AuthUser = AuthUser;
		getPromotionCustomerGroupsRequest.retialStore = retialStore;
		return ((KyanOnlineSaleServiceSoap)this).GetPromotionCustomerGroupsAsync(getPromotionCustomerGroupsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	AddToReserveResponse KyanOnlineSaleServiceSoap.AddToReserve(AddToReserveRequest request)
	{
		return base.Channel.AddToReserve(request);
	}

	public ResponseDataOfResult AddToReserve(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] ItemsID, bool CancelReservation)
	{
		AddToReserveRequest addToReserveRequest = new AddToReserveRequest();
		addToReserveRequest.ValidationSoapHeader = ValidationSoapHeader;
		addToReserveRequest.AuthUser = AuthUser;
		addToReserveRequest.ItemsID = ItemsID;
		addToReserveRequest.CancelReservation = CancelReservation;
		return ((KyanOnlineSaleServiceSoap)this).AddToReserve(addToReserveRequest).AddToReserveResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<AddToReserveResponse> KyanOnlineSaleServiceSoap.AddToReserveAsync(AddToReserveRequest request)
	{
		return base.Channel.AddToReserveAsync(request);
	}

	public Task<AddToReserveResponse> AddToReserveAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] ItemsID, bool CancelReservation)
	{
		AddToReserveRequest addToReserveRequest = new AddToReserveRequest();
		addToReserveRequest.ValidationSoapHeader = ValidationSoapHeader;
		addToReserveRequest.AuthUser = AuthUser;
		addToReserveRequest.ItemsID = ItemsID;
		addToReserveRequest.CancelReservation = CancelReservation;
		return ((KyanOnlineSaleServiceSoap)this).AddToReserveAsync(addToReserveRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SaleItemsResponse KyanOnlineSaleServiceSoap.SaleItems(SaleItemsRequest request)
	{
		return base.Channel.SaleItems(request);
	}

	public ResponseDataOfString SaleItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, int SourceRetailStoreID, TenderPrice[] listTenderPrice)
	{
		SaleItemsRequest saleItemsRequest = new SaleItemsRequest();
		saleItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleItemsRequest.AuthUser = AuthUser;
		saleItemsRequest.lstSaleItms = lstSaleItms;
		saleItemsRequest.CustomerID = CustomerID;
		saleItemsRequest.SourceRetailStoreID = SourceRetailStoreID;
		saleItemsRequest.listTenderPrice = listTenderPrice;
		return ((KyanOnlineSaleServiceSoap)this).SaleItems(saleItemsRequest).SaleItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SaleItemsResponse> KyanOnlineSaleServiceSoap.SaleItemsAsync(SaleItemsRequest request)
	{
		return base.Channel.SaleItemsAsync(request);
	}

	public Task<SaleItemsResponse> SaleItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, int SourceRetailStoreID, TenderPrice[] listTenderPrice)
	{
		SaleItemsRequest saleItemsRequest = new SaleItemsRequest();
		saleItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleItemsRequest.AuthUser = AuthUser;
		saleItemsRequest.lstSaleItms = lstSaleItms;
		saleItemsRequest.CustomerID = CustomerID;
		saleItemsRequest.SourceRetailStoreID = SourceRetailStoreID;
		saleItemsRequest.listTenderPrice = listTenderPrice;
		return ((KyanOnlineSaleServiceSoap)this).SaleItemsAsync(saleItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SaleItemsDateResponse KyanOnlineSaleServiceSoap.SaleItemsDate(SaleItemsDateRequest request)
	{
		return base.Channel.SaleItemsDate(request);
	}

	public ResponseDataOfString SaleItemsDate(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, TenderPrice[] listTenderPrice, DateTime bussinessDay)
	{
		SaleItemsDateRequest saleItemsDateRequest = new SaleItemsDateRequest();
		saleItemsDateRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleItemsDateRequest.AuthUser = AuthUser;
		saleItemsDateRequest.lstSaleItms = lstSaleItms;
		saleItemsDateRequest.CustomerID = CustomerID;
		saleItemsDateRequest.listTenderPrice = listTenderPrice;
		saleItemsDateRequest.bussinessDay = bussinessDay;
		return ((KyanOnlineSaleServiceSoap)this).SaleItemsDate(saleItemsDateRequest).SaleItemsDateResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SaleItemsDateResponse> KyanOnlineSaleServiceSoap.SaleItemsDateAsync(SaleItemsDateRequest request)
	{
		return base.Channel.SaleItemsDateAsync(request);
	}

	public Task<SaleItemsDateResponse> SaleItemsDateAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int? CustomerID, TenderPrice[] listTenderPrice, DateTime bussinessDay)
	{
		SaleItemsDateRequest saleItemsDateRequest = new SaleItemsDateRequest();
		saleItemsDateRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleItemsDateRequest.AuthUser = AuthUser;
		saleItemsDateRequest.lstSaleItms = lstSaleItms;
		saleItemsDateRequest.CustomerID = CustomerID;
		saleItemsDateRequest.listTenderPrice = listTenderPrice;
		saleItemsDateRequest.bussinessDay = bussinessDay;
		return ((KyanOnlineSaleServiceSoap)this).SaleItemsDateAsync(saleItemsDateRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WholeSalesResponse KyanOnlineSaleServiceSoap.WholeSales(WholeSalesRequest request)
	{
		return base.Channel.WholeSales(request);
	}

	public ResponseDataOfWholeSaleReult WholeSales(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		WholeSalesRequest wholeSalesRequest = new WholeSalesRequest();
		wholeSalesRequest.ValidationSoapHeader = ValidationSoapHeader;
		wholeSalesRequest.AuthUser = AuthUser;
		wholeSalesRequest.lstWholeSaleItms = lstWholeSaleItms;
		wholeSalesRequest.CustomerID = CustomerID;
		wholeSalesRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).WholeSales(wholeSalesRequest).WholeSalesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<WholeSalesResponse> KyanOnlineSaleServiceSoap.WholeSalesAsync(WholeSalesRequest request)
	{
		return base.Channel.WholeSalesAsync(request);
	}

	public Task<WholeSalesResponse> WholeSalesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		WholeSalesRequest wholeSalesRequest = new WholeSalesRequest();
		wholeSalesRequest.ValidationSoapHeader = ValidationSoapHeader;
		wholeSalesRequest.AuthUser = AuthUser;
		wholeSalesRequest.lstWholeSaleItms = lstWholeSaleItms;
		wholeSalesRequest.CustomerID = CustomerID;
		wholeSalesRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).WholeSalesAsync(wholeSalesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReturnWholesalesResponse KyanOnlineSaleServiceSoap.ReturnWholesales(ReturnWholesalesRequest request)
	{
		return base.Channel.ReturnWholesales(request);
	}

	public ResponseDataOfReturnWholeSaleReult ReturnWholesales(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		ReturnWholesalesRequest returnWholesalesRequest = new ReturnWholesalesRequest();
		returnWholesalesRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnWholesalesRequest.AuthUser = AuthUser;
		returnWholesalesRequest.lstWholeSaleItms = lstWholeSaleItms;
		returnWholesalesRequest.CustomerID = CustomerID;
		returnWholesalesRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).ReturnWholesales(returnWholesalesRequest).ReturnWholesalesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReturnWholesalesResponse> KyanOnlineSaleServiceSoap.ReturnWholesalesAsync(ReturnWholesalesRequest request)
	{
		return base.Channel.ReturnWholesalesAsync(request);
	}

	public Task<ReturnWholesalesResponse> ReturnWholesalesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		ReturnWholesalesRequest returnWholesalesRequest = new ReturnWholesalesRequest();
		returnWholesalesRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnWholesalesRequest.AuthUser = AuthUser;
		returnWholesalesRequest.lstWholeSaleItms = lstWholeSaleItms;
		returnWholesalesRequest.CustomerID = CustomerID;
		returnWholesalesRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).ReturnWholesalesAsync(returnWholesalesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SuspendTransactionResponse KyanOnlineSaleServiceSoap.SuspendTransaction(SuspendTransactionRequest request)
	{
		return base.Channel.SuspendTransaction(request);
	}

	public ResponseDataOfString SuspendTransaction(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSuspendItms, int? CustomerID, int SourceRetailStoreID)
	{
		SuspendTransactionRequest suspendTransactionRequest = new SuspendTransactionRequest();
		suspendTransactionRequest.ValidationSoapHeader = ValidationSoapHeader;
		suspendTransactionRequest.AuthUser = AuthUser;
		suspendTransactionRequest.lstSuspendItms = lstSuspendItms;
		suspendTransactionRequest.CustomerID = CustomerID;
		suspendTransactionRequest.SourceRetailStoreID = SourceRetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).SuspendTransaction(suspendTransactionRequest).SuspendTransactionResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SuspendTransactionResponse> KyanOnlineSaleServiceSoap.SuspendTransactionAsync(SuspendTransactionRequest request)
	{
		return base.Channel.SuspendTransactionAsync(request);
	}

	public Task<SuspendTransactionResponse> SuspendTransactionAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSuspendItms, int? CustomerID, int SourceRetailStoreID)
	{
		SuspendTransactionRequest suspendTransactionRequest = new SuspendTransactionRequest();
		suspendTransactionRequest.ValidationSoapHeader = ValidationSoapHeader;
		suspendTransactionRequest.AuthUser = AuthUser;
		suspendTransactionRequest.lstSuspendItms = lstSuspendItms;
		suspendTransactionRequest.CustomerID = CustomerID;
		suspendTransactionRequest.SourceRetailStoreID = SourceRetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).SuspendTransactionAsync(suspendTransactionRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	LayAwaySaleItemsResponse KyanOnlineSaleServiceSoap.LayAwaySaleItems(LayAwaySaleItemsRequest request)
	{
		return base.Channel.LayAwaySaleItems(request);
	}

	public ResponseDataOfString LayAwaySaleItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int CustomerID, int SourceRetailStoreID)
	{
		LayAwaySaleItemsRequest layAwaySaleItemsRequest = new LayAwaySaleItemsRequest();
		layAwaySaleItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		layAwaySaleItemsRequest.AuthUser = AuthUser;
		layAwaySaleItemsRequest.lstSaleItms = lstSaleItms;
		layAwaySaleItemsRequest.CustomerID = CustomerID;
		layAwaySaleItemsRequest.SourceRetailStoreID = SourceRetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).LayAwaySaleItems(layAwaySaleItemsRequest).LayAwaySaleItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<LayAwaySaleItemsResponse> KyanOnlineSaleServiceSoap.LayAwaySaleItemsAsync(LayAwaySaleItemsRequest request)
	{
		return base.Channel.LayAwaySaleItemsAsync(request);
	}

	public Task<LayAwaySaleItemsResponse> LayAwaySaleItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, SaleItemObject[] lstSaleItms, int CustomerID, int SourceRetailStoreID)
	{
		LayAwaySaleItemsRequest layAwaySaleItemsRequest = new LayAwaySaleItemsRequest();
		layAwaySaleItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		layAwaySaleItemsRequest.AuthUser = AuthUser;
		layAwaySaleItemsRequest.lstSaleItms = lstSaleItms;
		layAwaySaleItemsRequest.CustomerID = CustomerID;
		layAwaySaleItemsRequest.SourceRetailStoreID = SourceRetailStoreID;
		return ((KyanOnlineSaleServiceSoap)this).LayAwaySaleItemsAsync(layAwaySaleItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetRecieptDetailResponse KyanOnlineSaleServiceSoap.GetRecieptDetail(GetRecieptDetailRequest request)
	{
		return base.Channel.GetRecieptDetail(request);
	}

	public ResponseDataOfRecieptsDetail GetRecieptDetail(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcode)
	{
		GetRecieptDetailRequest getRecieptDetailRequest = new GetRecieptDetailRequest();
		getRecieptDetailRequest.ValidationSoapHeader = ValidationSoapHeader;
		getRecieptDetailRequest.AuthUser = AuthUser;
		getRecieptDetailRequest.RecieptBarcode = RecieptBarcode;
		return ((KyanOnlineSaleServiceSoap)this).GetRecieptDetail(getRecieptDetailRequest).GetRecieptDetailResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetRecieptDetailResponse> KyanOnlineSaleServiceSoap.GetRecieptDetailAsync(GetRecieptDetailRequest request)
	{
		return base.Channel.GetRecieptDetailAsync(request);
	}

	public Task<GetRecieptDetailResponse> GetRecieptDetailAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcode)
	{
		GetRecieptDetailRequest getRecieptDetailRequest = new GetRecieptDetailRequest();
		getRecieptDetailRequest.ValidationSoapHeader = ValidationSoapHeader;
		getRecieptDetailRequest.AuthUser = AuthUser;
		getRecieptDetailRequest.RecieptBarcode = RecieptBarcode;
		return ((KyanOnlineSaleServiceSoap)this).GetRecieptDetailAsync(getRecieptDetailRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetRecieptHeaderResponse KyanOnlineSaleServiceSoap.GetRecieptHeader(GetRecieptHeaderRequest request)
	{
		return base.Channel.GetRecieptHeader(request);
	}

	public ResponseDataOfRecieptsHeader GetRecieptHeader(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcode)
	{
		GetRecieptHeaderRequest getRecieptHeaderRequest = new GetRecieptHeaderRequest();
		getRecieptHeaderRequest.ValidationSoapHeader = ValidationSoapHeader;
		getRecieptHeaderRequest.AuthUser = AuthUser;
		getRecieptHeaderRequest.RecieptBarcode = RecieptBarcode;
		return ((KyanOnlineSaleServiceSoap)this).GetRecieptHeader(getRecieptHeaderRequest).GetRecieptHeaderResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetRecieptHeaderResponse> KyanOnlineSaleServiceSoap.GetRecieptHeaderAsync(GetRecieptHeaderRequest request)
	{
		return base.Channel.GetRecieptHeaderAsync(request);
	}

	public Task<GetRecieptHeaderResponse> GetRecieptHeaderAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcode)
	{
		GetRecieptHeaderRequest getRecieptHeaderRequest = new GetRecieptHeaderRequest();
		getRecieptHeaderRequest.ValidationSoapHeader = ValidationSoapHeader;
		getRecieptHeaderRequest.AuthUser = AuthUser;
		getRecieptHeaderRequest.RecieptBarcode = RecieptBarcode;
		return ((KyanOnlineSaleServiceSoap)this).GetRecieptHeaderAsync(getRecieptHeaderRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	SaleReturnItemsResponse KyanOnlineSaleServiceSoap.SaleReturnItems(SaleReturnItemsRequest request)
	{
		return base.Channel.SaleReturnItems(request);
	}

	public ResponseDataOfString SaleReturnItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcodeSale)
	{
		SaleReturnItemsRequest saleReturnItemsRequest = new SaleReturnItemsRequest();
		saleReturnItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleReturnItemsRequest.AuthUser = AuthUser;
		saleReturnItemsRequest.RecieptBarcodeSale = RecieptBarcodeSale;
		return ((KyanOnlineSaleServiceSoap)this).SaleReturnItems(saleReturnItemsRequest).SaleReturnItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<SaleReturnItemsResponse> KyanOnlineSaleServiceSoap.SaleReturnItemsAsync(SaleReturnItemsRequest request)
	{
		return base.Channel.SaleReturnItemsAsync(request);
	}

	public Task<SaleReturnItemsResponse> SaleReturnItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string RecieptBarcodeSale)
	{
		SaleReturnItemsRequest saleReturnItemsRequest = new SaleReturnItemsRequest();
		saleReturnItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		saleReturnItemsRequest.AuthUser = AuthUser;
		saleReturnItemsRequest.RecieptBarcodeSale = RecieptBarcodeSale;
		return ((KyanOnlineSaleServiceSoap)this).SaleReturnItemsAsync(saleReturnItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReturnItemsResponse KyanOnlineSaleServiceSoap.ReturnItems(ReturnItemsRequest request)
	{
		return base.Channel.ReturnItems(request);
	}

	public ResponseDataOfString ReturnItems(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReturnItemObject[] ReturnItems1, int? customerID)
	{
		ReturnItemsRequest returnItemsRequest = new ReturnItemsRequest();
		returnItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnItemsRequest.AuthUser = AuthUser;
		returnItemsRequest.ReturnItems = ReturnItems1;
		returnItemsRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).ReturnItems(returnItemsRequest).ReturnItemsResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReturnItemsResponse> KyanOnlineSaleServiceSoap.ReturnItemsAsync(ReturnItemsRequest request)
	{
		return base.Channel.ReturnItemsAsync(request);
	}

	public Task<ReturnItemsResponse> ReturnItemsAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ReturnItemObject[] ReturnItems, int? customerID)
	{
		ReturnItemsRequest returnItemsRequest = new ReturnItemsRequest();
		returnItemsRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnItemsRequest.AuthUser = AuthUser;
		returnItemsRequest.ReturnItems = ReturnItems;
		returnItemsRequest.customerID = customerID;
		return ((KyanOnlineSaleServiceSoap)this).ReturnItemsAsync(returnItemsRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ValidateGiftCertificatesResponse KyanOnlineSaleServiceSoap.ValidateGiftCertificates(ValidateGiftCertificatesRequest request)
	{
		return base.Channel.ValidateGiftCertificates(request);
	}

	public ResponseDataOfGiftCertificate ValidateGiftCertificates(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcode)
	{
		ValidateGiftCertificatesRequest validateGiftCertificatesRequest = new ValidateGiftCertificatesRequest();
		validateGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		validateGiftCertificatesRequest.AuthUser = AuthUser;
		validateGiftCertificatesRequest.barcode = barcode;
		return ((KyanOnlineSaleServiceSoap)this).ValidateGiftCertificates(validateGiftCertificatesRequest).ValidateGiftCertificatesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ValidateGiftCertificatesResponse> KyanOnlineSaleServiceSoap.ValidateGiftCertificatesAsync(ValidateGiftCertificatesRequest request)
	{
		return base.Channel.ValidateGiftCertificatesAsync(request);
	}

	public Task<ValidateGiftCertificatesResponse> ValidateGiftCertificatesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string[] barcode)
	{
		ValidateGiftCertificatesRequest validateGiftCertificatesRequest = new ValidateGiftCertificatesRequest();
		validateGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		validateGiftCertificatesRequest.AuthUser = AuthUser;
		validateGiftCertificatesRequest.barcode = barcode;
		return ((KyanOnlineSaleServiceSoap)this).ValidateGiftCertificatesAsync(validateGiftCertificatesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	CreateGiftCertificateResponse KyanOnlineSaleServiceSoap.CreateGiftCertificate(CreateGiftCertificateRequest request)
	{
		return base.Channel.CreateGiftCertificate(request);
	}

	public ResponseDataOfResult CreateGiftCertificate(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string barcode, string memberID, decimal Amount, int BonHOrBonT, int BonCartType)
	{
		CreateGiftCertificateRequest createGiftCertificateRequest = new CreateGiftCertificateRequest();
		createGiftCertificateRequest.ValidationSoapHeader = ValidationSoapHeader;
		createGiftCertificateRequest.AuthUser = AuthUser;
		createGiftCertificateRequest.barcode = barcode;
		createGiftCertificateRequest.memberID = memberID;
		createGiftCertificateRequest.Amount = Amount;
		createGiftCertificateRequest.BonHOrBonT = BonHOrBonT;
		createGiftCertificateRequest.BonCartType = BonCartType;
		return ((KyanOnlineSaleServiceSoap)this).CreateGiftCertificate(createGiftCertificateRequest).CreateGiftCertificateResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<CreateGiftCertificateResponse> KyanOnlineSaleServiceSoap.CreateGiftCertificateAsync(CreateGiftCertificateRequest request)
	{
		return base.Channel.CreateGiftCertificateAsync(request);
	}

	public Task<CreateGiftCertificateResponse> CreateGiftCertificateAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string barcode, string memberID, decimal Amount, int BonHOrBonT, int BonCartType)
	{
		CreateGiftCertificateRequest createGiftCertificateRequest = new CreateGiftCertificateRequest();
		createGiftCertificateRequest.ValidationSoapHeader = ValidationSoapHeader;
		createGiftCertificateRequest.AuthUser = AuthUser;
		createGiftCertificateRequest.barcode = barcode;
		createGiftCertificateRequest.memberID = memberID;
		createGiftCertificateRequest.Amount = Amount;
		createGiftCertificateRequest.BonHOrBonT = BonHOrBonT;
		createGiftCertificateRequest.BonCartType = BonCartType;
		return ((KyanOnlineSaleServiceSoap)this).CreateGiftCertificateAsync(createGiftCertificateRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetUnUsedGiftCertificatesResponse KyanOnlineSaleServiceSoap.GetUnUsedGiftCertificates(GetUnUsedGiftCertificatesRequest request)
	{
		return base.Channel.GetUnUsedGiftCertificates(request);
	}

	public ResponseDataOfUnUsedGiftCertificates GetUnUsedGiftCertificates(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetUnUsedGiftCertificatesRequest getUnUsedGiftCertificatesRequest = new GetUnUsedGiftCertificatesRequest();
		getUnUsedGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUnUsedGiftCertificatesRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetUnUsedGiftCertificates(getUnUsedGiftCertificatesRequest).GetUnUsedGiftCertificatesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetUnUsedGiftCertificatesResponse> KyanOnlineSaleServiceSoap.GetUnUsedGiftCertificatesAsync(GetUnUsedGiftCertificatesRequest request)
	{
		return base.Channel.GetUnUsedGiftCertificatesAsync(request);
	}

	public Task<GetUnUsedGiftCertificatesResponse> GetUnUsedGiftCertificatesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser)
	{
		GetUnUsedGiftCertificatesRequest getUnUsedGiftCertificatesRequest = new GetUnUsedGiftCertificatesRequest();
		getUnUsedGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUnUsedGiftCertificatesRequest.AuthUser = AuthUser;
		return ((KyanOnlineSaleServiceSoap)this).GetUnUsedGiftCertificatesAsync(getUnUsedGiftCertificatesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetUsedGiftCertificatesResponse KyanOnlineSaleServiceSoap.GetUsedGiftCertificates(GetUsedGiftCertificatesRequest request)
	{
		return base.Channel.GetUsedGiftCertificates(request);
	}

	public ResponseDataOfUsedGiftCertificate GetUsedGiftCertificates(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetUsedGiftCertificatesRequest getUsedGiftCertificatesRequest = new GetUsedGiftCertificatesRequest();
		getUsedGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUsedGiftCertificatesRequest.AuthUser = AuthUser;
		getUsedGiftCertificatesRequest.StartDate = StartDate;
		getUsedGiftCertificatesRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetUsedGiftCertificates(getUsedGiftCertificatesRequest).GetUsedGiftCertificatesResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetUsedGiftCertificatesResponse> KyanOnlineSaleServiceSoap.GetUsedGiftCertificatesAsync(GetUsedGiftCertificatesRequest request)
	{
		return base.Channel.GetUsedGiftCertificatesAsync(request);
	}

	public Task<GetUsedGiftCertificatesResponse> GetUsedGiftCertificatesAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetUsedGiftCertificatesRequest getUsedGiftCertificatesRequest = new GetUsedGiftCertificatesRequest();
		getUsedGiftCertificatesRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUsedGiftCertificatesRequest.AuthUser = AuthUser;
		getUsedGiftCertificatesRequest.StartDate = StartDate;
		getUsedGiftCertificatesRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetUsedGiftCertificatesAsync(getUsedGiftCertificatesRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetUsedCreditCustomerResponse KyanOnlineSaleServiceSoap.GetUsedCreditCustomer(GetUsedCreditCustomerRequest request)
	{
		return base.Channel.GetUsedCreditCustomer(request);
	}

	public ResponseDataOfUsedCreditCustomer GetUsedCreditCustomer(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetUsedCreditCustomerRequest getUsedCreditCustomerRequest = new GetUsedCreditCustomerRequest();
		getUsedCreditCustomerRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUsedCreditCustomerRequest.AuthUser = AuthUser;
		getUsedCreditCustomerRequest.StartDate = StartDate;
		getUsedCreditCustomerRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetUsedCreditCustomer(getUsedCreditCustomerRequest).GetUsedCreditCustomerResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetUsedCreditCustomerResponse> KyanOnlineSaleServiceSoap.GetUsedCreditCustomerAsync(GetUsedCreditCustomerRequest request)
	{
		return base.Channel.GetUsedCreditCustomerAsync(request);
	}

	public Task<GetUsedCreditCustomerResponse> GetUsedCreditCustomerAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, string StartDate, string EndDate)
	{
		GetUsedCreditCustomerRequest getUsedCreditCustomerRequest = new GetUsedCreditCustomerRequest();
		getUsedCreditCustomerRequest.ValidationSoapHeader = ValidationSoapHeader;
		getUsedCreditCustomerRequest.AuthUser = AuthUser;
		getUsedCreditCustomerRequest.StartDate = StartDate;
		getUsedCreditCustomerRequest.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetUsedCreditCustomerAsync(getUsedCreditCustomerRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetItemListWithinventoryIDResponse KyanOnlineSaleServiceSoap.GetItemListWithinventoryID(GetItemListWithinventoryIDRequest request)
	{
		return base.Channel.GetItemListWithinventoryID(request);
	}

	public ResponseDataOfitm GetItemListWithinventoryID(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventory)
	{
		GetItemListWithinventoryIDRequest getItemListWithinventoryIDRequest = new GetItemListWithinventoryIDRequest();
		getItemListWithinventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithinventoryIDRequest.AuthUser = AuthUser;
		getItemListWithinventoryIDRequest.inventory = inventory;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithinventoryID(getItemListWithinventoryIDRequest).GetItemListWithinventoryIDResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetItemListWithinventoryIDResponse> KyanOnlineSaleServiceSoap.GetItemListWithinventoryIDAsync(GetItemListWithinventoryIDRequest request)
	{
		return base.Channel.GetItemListWithinventoryIDAsync(request);
	}

	public Task<GetItemListWithinventoryIDResponse> GetItemListWithinventoryIDAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int inventory)
	{
		GetItemListWithinventoryIDRequest getItemListWithinventoryIDRequest = new GetItemListWithinventoryIDRequest();
		getItemListWithinventoryIDRequest.ValidationSoapHeader = ValidationSoapHeader;
		getItemListWithinventoryIDRequest.AuthUser = AuthUser;
		getItemListWithinventoryIDRequest.inventory = inventory;
		return ((KyanOnlineSaleServiceSoap)this).GetItemListWithinventoryIDAsync(getItemListWithinventoryIDRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	QuickExternalTransferResponse KyanOnlineSaleServiceSoap.QuickExternalTransfer(QuickExternalTransferRequest request)
	{
		return base.Channel.QuickExternalTransfer(request);
	}

	public QuickTransferReultModel QuickExternalTransfer(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int DestinationRsID)
	{
		QuickExternalTransferRequest quickExternalTransferRequest = new QuickExternalTransferRequest();
		quickExternalTransferRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferRequest.AuthUser = AuthUser;
		quickExternalTransferRequest.LstTransfer = LstTransfer;
		quickExternalTransferRequest.DestinationRsID = DestinationRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransfer(quickExternalTransferRequest).QuickExternalTransferResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<QuickExternalTransferResponse> KyanOnlineSaleServiceSoap.QuickExternalTransferAsync(QuickExternalTransferRequest request)
	{
		return base.Channel.QuickExternalTransferAsync(request);
	}

	public Task<QuickExternalTransferResponse> QuickExternalTransferAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int DestinationRsID)
	{
		QuickExternalTransferRequest quickExternalTransferRequest = new QuickExternalTransferRequest();
		quickExternalTransferRequest.ValidationSoapHeader = ValidationSoapHeader;
		quickExternalTransferRequest.AuthUser = AuthUser;
		quickExternalTransferRequest.LstTransfer = LstTransfer;
		quickExternalTransferRequest.DestinationRsID = DestinationRsID;
		return ((KyanOnlineSaleServiceSoap)this).QuickExternalTransferAsync(quickExternalTransferRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ApproveDocumentResponse KyanOnlineSaleServiceSoap.ApproveDocument(ApproveDocumentRequest request)
	{
		return base.Channel.ApproveDocument(request);
	}

	public QuickTransferReultModel ApproveDocument(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int SourceRsID)
	{
		ApproveDocumentRequest approveDocumentRequest = new ApproveDocumentRequest();
		approveDocumentRequest.ValidationSoapHeader = ValidationSoapHeader;
		approveDocumentRequest.AuthUser = AuthUser;
		approveDocumentRequest.LstTransfer = LstTransfer;
		approveDocumentRequest.SourceRsID = SourceRsID;
		return ((KyanOnlineSaleServiceSoap)this).ApproveDocument(approveDocumentRequest).ApproveDocumentResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ApproveDocumentResponse> KyanOnlineSaleServiceSoap.ApproveDocumentAsync(ApproveDocumentRequest request)
	{
		return base.Channel.ApproveDocumentAsync(request);
	}

	public Task<ApproveDocumentResponse> ApproveDocumentAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, ItemStock[] LstTransfer, int SourceRsID)
	{
		ApproveDocumentRequest approveDocumentRequest = new ApproveDocumentRequest();
		approveDocumentRequest.ValidationSoapHeader = ValidationSoapHeader;
		approveDocumentRequest.AuthUser = AuthUser;
		approveDocumentRequest.LstTransfer = LstTransfer;
		approveDocumentRequest.SourceRsID = SourceRsID;
		return ((KyanOnlineSaleServiceSoap)this).ApproveDocumentAsync(approveDocumentRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	GetTransactionWithDs_info_2Response KyanOnlineSaleServiceSoap.GetTransactionWithDs_info_2(GetTransactionWithDs_info_2Request request)
	{
		return base.Channel.GetTransactionWithDs_info_2(request);
	}

	public ResponseDataOfReceiptDsInfModel GetTransactionWithDs_info_2(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int? RS, DateTime StartDate, DateTime EndDate)
	{
		GetTransactionWithDs_info_2Request getTransactionWithDs_info_2Request = new GetTransactionWithDs_info_2Request();
		getTransactionWithDs_info_2Request.ValidationSoapHeader = ValidationSoapHeader;
		getTransactionWithDs_info_2Request.AuthUser = AuthUser;
		getTransactionWithDs_info_2Request.RS = RS;
		getTransactionWithDs_info_2Request.StartDate = StartDate;
		getTransactionWithDs_info_2Request.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetTransactionWithDs_info_2(getTransactionWithDs_info_2Request).GetTransactionWithDs_info_2Result;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<GetTransactionWithDs_info_2Response> KyanOnlineSaleServiceSoap.GetTransactionWithDs_info_2Async(GetTransactionWithDs_info_2Request request)
	{
		return base.Channel.GetTransactionWithDs_info_2Async(request);
	}

	public Task<GetTransactionWithDs_info_2Response> GetTransactionWithDs_info_2Async(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, int? RS, DateTime StartDate, DateTime EndDate)
	{
		GetTransactionWithDs_info_2Request getTransactionWithDs_info_2Request = new GetTransactionWithDs_info_2Request();
		getTransactionWithDs_info_2Request.ValidationSoapHeader = ValidationSoapHeader;
		getTransactionWithDs_info_2Request.AuthUser = AuthUser;
		getTransactionWithDs_info_2Request.RS = RS;
		getTransactionWithDs_info_2Request.StartDate = StartDate;
		getTransactionWithDs_info_2Request.EndDate = EndDate;
		return ((KyanOnlineSaleServiceSoap)this).GetTransactionWithDs_info_2Async(getTransactionWithDs_info_2Request);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	WholesaleResponse KyanOnlineSaleServiceSoap.Wholesale(WholesaleRequest request)
	{
		return base.Channel.Wholesale(request);
	}

	public WholeSaleReultModel Wholesale(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		WholesaleRequest wholesaleRequest = new WholesaleRequest();
		wholesaleRequest.ValidationSoapHeader = ValidationSoapHeader;
		wholesaleRequest.AuthUser = AuthUser;
		wholesaleRequest.lstWholeSaleItms = lstWholeSaleItms;
		wholesaleRequest.CustomerID = CustomerID;
		wholesaleRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).Wholesale(wholesaleRequest).WholesaleResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<WholesaleResponse> KyanOnlineSaleServiceSoap.WholesaleAsync(WholesaleRequest request)
	{
		return base.Channel.WholesaleAsync(request);
	}

	public Task<WholesaleResponse> WholesaleAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		WholesaleRequest wholesaleRequest = new WholesaleRequest();
		wholesaleRequest.ValidationSoapHeader = ValidationSoapHeader;
		wholesaleRequest.AuthUser = AuthUser;
		wholesaleRequest.lstWholeSaleItms = lstWholeSaleItms;
		wholesaleRequest.CustomerID = CustomerID;
		wholesaleRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).WholesaleAsync(wholesaleRequest);
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	ReturnWholesaleResponse KyanOnlineSaleServiceSoap.ReturnWholesale(ReturnWholesaleRequest request)
	{
		return base.Channel.ReturnWholesale(request);
	}

	public ReturnWholeSaleReultMode ReturnWholesale(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		ReturnWholesaleRequest returnWholesaleRequest = new ReturnWholesaleRequest();
		returnWholesaleRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnWholesaleRequest.AuthUser = AuthUser;
		returnWholesaleRequest.lstWholeSaleItms = lstWholeSaleItms;
		returnWholesaleRequest.CustomerID = CustomerID;
		returnWholesaleRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).ReturnWholesale(returnWholesaleRequest).ReturnWholesaleResult;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	Task<ReturnWholesaleResponse> KyanOnlineSaleServiceSoap.ReturnWholesaleAsync(ReturnWholesaleRequest request)
	{
		return base.Channel.ReturnWholesaleAsync(request);
	}

	public Task<ReturnWholesaleResponse> ReturnWholesaleAsync(ValidationSoapHeader ValidationSoapHeader, AuthUser AuthUser, WholeSaleModel[] lstWholeSaleItms, int CustomerID, string Description)
	{
		ReturnWholesaleRequest returnWholesaleRequest = new ReturnWholesaleRequest();
		returnWholesaleRequest.ValidationSoapHeader = ValidationSoapHeader;
		returnWholesaleRequest.AuthUser = AuthUser;
		returnWholesaleRequest.lstWholeSaleItms = lstWholeSaleItms;
		returnWholesaleRequest.CustomerID = CustomerID;
		returnWholesaleRequest.Description = Description;
		return ((KyanOnlineSaleServiceSoap)this).ReturnWholesaleAsync(returnWholesaleRequest);
	}
}
