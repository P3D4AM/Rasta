







/*NKR990515*/
/*RZ14011019- Add PrdLinkAccPrdCode*/
Create PROCEDURE [dbo].[ApispSelectDocItems]
(
	/*
		EXEC ApispSelectDocItems NULL, NULL, 1033, 1065		
	*/
	@DocItemID INT = NULL,
	@DocId INT = NULL,
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL
)
AS
BEGIN
	/**/
	
	DECLARE @QRY NVARCHAR(MAX) = ''

	IF (@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN
		SET @QRY = '
			SELECT 
				DocItemID AS ApiDocItemID,
				DocId AS ApiDocId,
				PrdId AS ApiPrdId,
				(SELECT ISNULL(P.PrdName, '''') FROM WSProducts P WHERE P.ProductID = DI.PrdId) AS ApiPrd,
				Quantity AS ApiQuantity,
				CostId AS ApiCostId,
				Cost AS ApiCost,
				Description AS ApiDescription,
				IsFix AS ApiIsFix,
				WHId AS ApiWHId,
				(SELECT ISNULL(WH.WrhsName, '''') FROM WsWareHouse WH WHERE WH.WareHouseID = DI.WHId) AS ApiWH,
				NotVisible AS ApiNotVisible,
				FCR AS ApiFCR,
				FCRI AS ApiFCRI,
				Tracing AS ApiTracing,
				FPId AS ApiFPId,
				UserId AS ApiUserId,
				(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = DI.UserId) AS ApiEditUser,
				RegisterDate AS ApiRegisterDate,
				FirstRegisterUserId AS ApiFirstRegisterUserId,
				(SELECT ISNULL(U.FName, '''') + '' '' + ISNULL(U.LName, '''') FROM Users U WHERE U.UserId = DI.UserId) AS ApiFirstRegisterUser,
				FirstRegisterDate AS ApiFirstRegisterDate,
				[DocILinkAccItemId] AS ApiDocILinkAccItemId
				,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = DI.PrdId) AS ApiPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/ 
			FROM WSDocItems DI WHERE 1 = 1'
	END	
	ELSE IF (@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	BEGIN
		SET @QRY = '
			SELECT 
				DocItemID AS ApiDocItemID,
				DocId AS ApiDocId,
				PrdId AS ApiPrdId,
				(SELECT ISNULL(PL.PrdName, '''') FROM WSProducts_Lang PL WHERE PL.ProductID = DI.PrdId AND PL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiPrd,
				Quantity AS ApiQuantity,
				CostId AS ApiCostId,
				Cost AS ApiCost,
				(SELECT ISNULL(DIL.Description, '''') FROM WSDocItems_Lang DIL WHERE DIL.DocItemID = DI.DocItemID AND DIL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiDescription,
				IsFix AS ApiIsFix,
				WHId AS ApiWHId,
				(SELECT ISNULL(WHL.WrhsName, '''') FROM WsWareHouse_Lang WHL WHERE WHL.WareHouseID = DI.WHId AND WHL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiWH,
				NotVisible AS ApiNotVisible,
				FCR AS ApiFCR,
				FCRI AS ApiFCRI,
				Tracing AS ApiTracing,
				FPId AS ApiFPId,
				UserId AS ApiUserId,
				(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = DI.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiEditUser,
				RegisterDate AS ApiRegisterDate,
				FirstRegisterUserId AS ApiFirstRegisterUserId,
				(SELECT ISNULL(UL.FName, '''') + '' '' + ISNULL(UL.LName, '''') FROM Users_Lang UL WHERE UL.UserId = DI.UserId AND UL.LanguageID = ' + CAST(@LanguageID AS NVARCHAR(50)) + ') AS ApiFirstRegisterUser,
				FirstRegisterDate AS ApiFirstRegisterDate,
				[DocILinkAccItemId] AS ApiDocILinkAccItemId
				,(SELECT ISNULL(P.PrdLinkAccPrdCode, '''') FROM WSProducts P WHERE P.ProductID = DI.PrdId) AS ApiPrdLinkAccPrdCode /*RZ14011019- Add PrdLinkAccPrdCode*/ 
			FROM WSDocItems DI WHERE 1 = 1 '
	END

	IF (ISNULL(@DocItemID, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND DocItemID = ' + CAST(@DocItemID AS NVARCHAR(50))
	END
	IF (ISNULL(@DocId, 0) > 0)
	BEGIN
		SET @QRY = @QRY + ' AND DocId = ' + CAST(@DocId AS NVARCHAR(50))
	END


	EXECUTE (@QRY)

	/**/
END






