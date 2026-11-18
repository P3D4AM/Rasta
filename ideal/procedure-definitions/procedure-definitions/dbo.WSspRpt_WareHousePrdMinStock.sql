



/*NKR14000520- Create From WSspRpt_WareHouseStock*/
/*NKR14000520- Add @MinStkQuan*/
/*NKR14000614- Add PrdMinQty to Result*/
CREATE PROCEDURE [dbo].[WSspRpt_WareHousePrdMinStock]
(			
	/* 
		exec [WSspRpt_WareHousePrdMinStock]  0,0,0,0,0,0,3,'13930909','1','0',1065,1065,'',0,0,1
	*/
	@Mode INT, /*-2,-1,0,1 = All,ByVal,0,>0*/
	@FPId INT, 
	@WHID INT, 
	@FGId INT, 
	@SGId INT, 
	@PrdId INT,
	@UserId INT, 
	@rptDate VARCHAR(50), 
	@rptDay NVARCHAR(50),
	@PrdModel NVARCHAR(200),
	@LanguageID INT = NULL,
	@DefaultLanguageID INT = NULL,
	@Tracing NVARCHAR(200) = NULL,
	@PrdKind INT = NULL,/*PrdKind = 0 ==> all, PrdKind == 1 ==> product, PrdKind == 2 ==> service*/
	@PrdInActive INT = NULL,/*PrdInActive = -1 ==> all, PrdInActive == 0 ==> active, PrdInActive == 1 ==> inactive*/
	/*NKR140000520*/
	@MinStkQuan FLOAT
)
As
BEGIN
/**/
	DECLARE @rptUserName NVARCHAR(max)
	/**/
	IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
		SELECT @rptUserName = ISNULL(FName, '') + ' ' + ISNULL(LName , '') FROM Users Us WHERE Us.UserId = CAST(@UserId AS VARCHAR(10))
	ELSE
		SELECT @rptUserName = ISNULL(FName, '') + ' ' + ISNULL(LName , '') FROM Users_Lang Us WHERE Us.UserId = CAST(@UserId AS VARCHAR(10))  AND Us.LanguageID = @LanguageID
	/**/
	SET @MinStkQuan = ISNULL(@MinStkQuan, 0)
	/**/
	DECLARE @Term VARCHAR(max), @TermI VARCHAR(MAX)

	SET @Term = ''
	SET @TermI = ''


	/*--------------------------- WH --------------------------*/
	IF @WHID > 0
	BEGIN 
		SET @Term = @Term + ' And D.WHId = ' + CAST(@WHId AS VARCHAR(10))
		SET @TermI = @TermI + ' And D.WHIdI = ' + CAST(@WHId AS VARCHAR(10))
	END 
	ELSE 
	BEGIN
	/**/
		SET @Term = @Term + ' And D.WHId IN (SELECT WUP.[WHId]
											 FROM [dbo].[WSWareHouseUserPermissions] WUP
											 WHERE ISNULL(WUP.[CrmUserId],0) IN(0, ' + CAST(@UserId AS VARCHAR(10)) + ')) ' 
		/*------------------*/
		SET @TermI = @TermI + ' And D.WHIdI IN (SELECT WUP.[WHId]
											 FROM [dbo].[WSWareHouseUserPermissions] WUP
											 WHERE ISNULL(WUP.[CrmUserId],0) IN(0, ' + CAST(@UserId AS VARCHAR(10)) + ')) ' 
	/**/
	END

	/*----------------------- FirstGroup -----------------------*/
	IF @FGId > 0
	BEGIN 
		SET @Term = @Term + ' And PG.FGId = ' + CAST(@FGId AS VARCHAR(10))
		SET @TermI = @TermI + ' And PG.FGId = ' + CAST(@FGId AS VARCHAR(10))
	END 

	/*---------------------- SecondGroup -----------------------*/
	IF @SGId > 0
	BEGIN 
		SET @Term = @Term + ' And PG.SGId = ' + CAST(@SGId AS VARCHAR(10))
		SET @TermI = @TermI + ' And PG.SGId = ' + CAST(@SGId AS VARCHAR(10))
	END 

	/*------------------------- Product ------------------------*/
	IF @PrdId > 0
	BEGIN 
		SET @Term = @Term + ' And DI.PrdId = ' + CAST(@PrdId AS VARCHAR(10))
		SET @TermI = @TermI + ' And DI.PrdId = ' + CAST(@PrdId AS VARCHAR(10))
	END


	/*------------------------- Tracing ------------------------*/
	DECLARE @TracingColumn VARCHAR(max) = '' ,@GroupByTracing VARCHAR(max) = '', @FinalGroupByTracing VARCHAR(max) = ''
	IF(ISNULL(@Tracing,'0') <> '0')
	BEGIN
	/**/
		IF(ISNULL(@Tracing,'') = '#-1#')/*without tracing*/
		BEGIN
		/**/
			SET @Tracing = ''
			SET @Term = @Term + ' And ISNULL(DI.[Tracing],'''') ='''' '  	
			SET @TermI = @TermI + ' And ISNULL(DI.[Tracing],'''') ='''' ' 
		/**/
		END	
		ELSE /*with tracing*/
		BEGIN
		/**/
			SET @Term = @Term + ' And ISNULL(DI.[Tracing],'''') = ''' + @Tracing + ''' '	
			SET @TermI = @TermI + ' And ISNULL(DI.[Tracing],'''') = ''' + @Tracing + ''' '
		/**/
		END
		/**/
		SET @TracingColumn = ',ISNULL(DI.[Tracing],'''') [Tracing] '
		SET @GroupByTracing = ',DI.[Tracing] '
		SET @FinalGroupByTracing = ',[Tracing] '
	/**/
	END
	ELSE IF(ISNULL(@Tracing,'0') = '0') /*ALL*/
	BEGIN
	/**/
		SET @Tracing = ''
		SET @TracingColumn = ''
		SET @GroupByTracing = ''
		SET @FinalGroupByTracing = ''
	/**/
	END

	IF @PrdModel > '0'
	BEGIN
		/**/
		IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
		BEGIN
			 SET @Term = @Term + 
				' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE PrdModel = ''' + @PrdModel +''')'
			 SET @TermI = @TermI + 
				' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE PrdModel = ''' + @PrdModel +''')'
		END
		ELSE
		BEGIN
			 SET @Term = @Term + 
				' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts_Lang p WHERE p.LanguageID = '+CAST(@LanguageID AS VARCHAR(10))
				+' AND p.PrdModel = ''' + @PrdModel +''')'
			 SET @TermI = @TermI + 
				' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts_Lang p WHERE p.LanguageID = '+CAST(@LanguageID AS VARCHAR(10))
				+' AND p.PrdModel = ''' + @PrdModel +''')'
		END
		/**/
	END


	/*------------------------- PrdKind --------------------------*/
	IF(ISNULL(@PrdKind,0) > 0)/*PrdKind = 0 ==> all, PrdKind == 1 ==> product, PrdKind == 2 ==> service*/
	BEGIN
	/**/
		SET @Term = @Term + 
			' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE ISNULL(p.PrdKind,0) = '+ CAST(@PrdKind AS VARCHAR(10)) +') '	

		SET @TermI = @TermI + 
			' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE ISNULL(p.PrdKind,0) = '+ CAST(@PrdKind AS VARCHAR(10)) +') '	
	/**/
	END

	/*----------------------- PrdInactive ------------------------*/
	IF(ISNULL(@PrdInActive,-1) > -1)/*PrdInActive = -1 ==> all, PrdInActive == 0 ==> active, PrdInActive == 1 ==> inactive*/
	BEGIN
	/**/
		SET @Term = @Term + 
			' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE ISNULL(p.PrdInActive,0) = '+ CAST(@PrdInActive AS VARCHAR(10)) +') '

		SET @TermI = @TermI + 
			' And DI.PrdId IN (SELECT ProductID FROM dbo.WSProducts p WHERE ISNULL(p.PrdInActive,0) = '+ CAST(@PrdInActive AS VARCHAR(10)) +') '
	/**/
	END

	/*-------------------------------------------------*/
	DECLARE @Term2 VARCHAR(4000)
	SET @Term2 = ''

	/**/
	IF (@MinStkQuan > 0)
	BEGIN
		SET @Term2 = @Term2 + ' Having ( (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) <=  ' + CAST(@MinStkQuan AS VARCHAR(10)) + 
				' And (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) > 0 )' 				
	END
	ELSE /*(@MinStkQuan <= 0)*/
	BEGIN
		SET @Term2 = @Term2 + 
					' Having ( (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) <=  ' + 
					'(SELECT TOP 1 ISNULL([PrdMinQty], 0) FROM [dbo].[WSProducts] P WHERE P.[ProductID] = PrdId)' + 
					' And (SELECT TOP 1 ISNULL([PrdMinQty], 0) FROM [dbo].[WSProducts] P WHERE P.[ProductID] = PrdId) > 0 )'
					/*' And (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) > 0 )'*/
	END

	IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	BEGIN	
		/**/
		EXECUTE (
			' SELECT 0 FPId, ' + '''' +  @rptUserName + '''' + ' UserName, '+ 
				'''' + @rptDate+''' rptDate, '''+@rptDay +''' rptDay,
				(SELECT WrhsName FROM dbo.WsWareHouse WHERE WareHouseID = WHId) WrhsName,
				(SELECT WrhsCode FROM dbo.WsWareHouse WHERE WareHouseID = WHId) WrhsCode,
				FGCode, FGName, SGCode, SGName, PrdCode, PrdName, 
				PrdLatinName , PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, 
				prdUnit, 
				ISNULL(SUM(InQuantity), 0) InQuantity, ISNULL(SUM(OutQuantity), 0) OutQuantity, 
				/*ISNULL(SUM(InQuantity), 0) - ISNULL(SUM(OutQuantity), 0) RemainQuantity,*/
				CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT) RemainQuantity,
				FGId, SGId, PrdId, 
				/*NKR14000614*/
				(SELECT PrdMinQty FROM WSProducts WHERE ProductID = PrdId) as [PrdMinQty],
				WHId,PrdUnitFCR,
				CAST(0 AS FLOAT) DocIFCR, CAST(0 AS FLOAT) DocIFCRI
				,''' + @Tracing + ''' [Tracing]
			FROM 
			( 	
			SELECT  D.WHId, 
				PG.FGId, PG.FGCode, PG.FGName, 
				PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode PrdCode, PG.PrdName PrdName,
				PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
				CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)
						/*D.OprId = 1 */
						THEN IsNull(SUM(DI.Quantity), 0) END InQuantity,
				CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2) 
						/*D.OprId = 2 */
						THEN IsNull(SUM(DI.Quantity), 0) END OutQuantity,
				PG.PrdLatinName , 
				PG.PrdModel , 
				PG.PrdFirstBarcode , 
				PG.PrdType , 
				PG.PrdDesign , 
				PG.PrdSize , 
				PG.Color,
				PG.Unit prdUnit	
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR 			
			
				' + @TracingColumn + ' 
			FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
					ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups() PG
					ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 AND D.OprId Not IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @term +
			' GROUP BY D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit 
			' + @GroupByTracing + ' 
			UNION ALL
			SELECT 	/*D.FPId, */D.WHId, 
				PG.FGId, PG.FGCode, PG.FGName, 
				PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode PrdCode, PG.PrdName PrdName,
				PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
				ISNULL( SUM(DI.Quantity), 0) InQuantity,
				Null OutQuantity,
				PG.PrdLatinName , 
				PG.PrdModel , 
				PG.PrdFirstBarcode , 
				PG.PrdType , 
				PG.PrdDesign , 
				PG.PrdSize , 
				PG.Color,
				PG.Unit prdUnit	
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR 					
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*/
				' + @TracingColumn + ' 
			FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
					ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups() PG
					ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @term +
			' GROUP BY D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit/*,DI.[FCR] ,DI.[FCRI]*/ 
			' + @GroupByTracing + ' 
			UNION ALL
			SELECT 	/*D.FPId, */D.WHIdI, 
				PG.FGId, PG.FGCode, PG.FGName, 
				PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode PrdCode, PG.PrdName PrdName,
				PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
				Null InQuantity,
				ISNULL( SUM(DI.Quantity), 0) OutQuantity,
				PG.PrdLatinName , 
				PG.PrdModel , 
				PG.PrdFirstBarcode , 
				PG.PrdType , 
				PG.PrdDesign , 
				PG.PrdSize , 
				PG.Color,
				PG.Unit prdUnit	
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR 
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*/
				' + @TracingColumn + ' 	
			FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
					ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups() PG
					ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @termI +
			' GROUP BY /*D.FPId,*/ D.WHIdI,
				DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit/*,DI.[FCR] ,DI.[FCRI] */
			' + @GroupByTracing + '
			/*--*/
			) T 
			GROUP BY /*FPId, */WHId, FGId, FGCode, FGName, SGId, SGCode, SGName, PrdId, PrdCode, PrdName, 
			PrdLatinName, PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, prdUnit 
			,PrdUnitFCR/*,DocIFCR ,DocIFCRI*/
			' + @FinalGroupByTracing 
			+ @Term2 + 
			' Order By /*FPId,*/ WHId, FGId, SGId, PrdId '
		)

	END
	ELSE
	BEGIN
		EXECUTE (
			' SELECT  0 FPId, ' + '''' +  @rptUserName + '''' + ' UserName, '+ 
				'''' + @rptDate+''' rptDate, '''+@rptDay +''' rptDay,
				(SELECT WrhsName FROM dbo.WsWareHouse_Lang WHLN WHERE WHLN.WareHouseID = WHId AND WHLN.LanguageID=' + @LanguageID + ') WrhsName,
				(SELECT WrhsCode FROM dbo.WsWareHouse WHERE WareHouseID = WHId) WrhsCode,
				FGCode, FGName, SGCode, SGName, PrdCode, PrdName, 
				PrdLatinName , PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, 
				prdUnit, 
				ISNULL(SUM(InQuantity), 0) InQuantity, ISNULL(SUM(OutQuantity), 0) OutQuantity, 
				/*ISNULL(SUM(InQuantity), 0) - ISNULL(SUM(OutQuantity), 0) RemainQuantity,*/
				CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT) RemainQuantity,
				FGId, SGId, PrdId, 
				/*NKR14000614*/
				(SELECT PrdMinQty FROM WSProducts WHERE ProductID = PrdId) as [PrdMinQty],
				/*FPId,*/		
				 WHId 
				,PrdUnitFCR ,/*DocIFCR,DocIFCRI*/
				CAST(0 AS FLOAT) DocIFCR, CAST(0 AS FLOAT) DocIFCRI
				,''' + @Tracing + ''' [Tracing]
			FROM 
			( 	
				SELECT 	/*D.FPId, */
					D.WHId, 
					PG.FGId, PG.FGCode, PG.FGName, 
					PG.SGId, PG.SGCode, PG.SGName, 
					PG.PrdCode PrdCode, PG.PrdName PrdName,
					PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
					CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)
							/*D.OprId = 1 */
							THEN IsNull(SUM(DI.Quantity), 0) END InQuantity,
					CASE WHEN D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2) 
							/*D.OprId = 2 */
							THEN IsNull(SUM(DI.Quantity), 0) END OutQuantity,
					PG.PrdLatinName , 
					PG.PrdModel , 
					PG.PrdFirstBarcode , 
					PG.PrdType , 
					PG.PrdDesign , 
					PG.PrdSize , 
					PG.Color,
					PG.Unit prdUnit
					,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
						(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR
					/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*/
					' + @TracingColumn + ' 
				FROM dbo.WSDoc D 
				INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG ON(DI.PrdId = PG.ProductID)	
				WHERE 1=1 '
				+ ' AND D.OprId Not IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
				+ @term +
				' GROUP BY /*D.FPId,*/ D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
				PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
				PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/
				' + @GroupByTracing + ' 
				UNION ALL
				SELECT 	/*D.FPId,*/ D.WHId, 
					PG.FGId, PG.FGCode, PG.FGName, 
					PG.SGId, PG.SGCode, PG.SGName, 
					PG.PrdCode PrdCode, PG.PrdName PrdName,
					PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
					ISNULL( SUM(DI.Quantity), 0) InQuantity,
					Null OutQuantity,
					PG.PrdLatinName , 
					PG.PrdModel , 
					PG.PrdFirstBarcode , 
					PG.PrdType , 
					PG.PrdDesign , 
					PG.PrdSize , 
					PG.Color,
					PG.Unit prdUnit	
					,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
						(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR	
					/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*/
					' + @TracingColumn + ' 
				FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
					ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG
					ON(DI.PrdId = PG.ProductID)	
				WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
				+ @term +
				' GROUP BY /*D.FPId,*/ D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
				PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
				PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/
				' + @GroupByTracing + '
			UNION ALL
			SELECT 	/*D.FPId,*/ D.WHIdI,
				PG.FGId, PG.FGCode, PG.FGName, 
				PG.SGId, PG.SGCode, PG.SGName, 
				PG.PrdCode PrdCode, PG.PrdName PrdName,
				PG.GName, PrdId, IsNull(SUM(DI.Quantity), 0) Qty,
				Null InQuantity,
				ISNULL( SUM(DI.Quantity), 0) OutQuantity,
				PG.PrdLatinName , 
				PG.PrdModel , 
				PG.PrdFirstBarcode , 
				PG.PrdType , 
				PG.PrdDesign , 
				PG.PrdSize , 
				PG.Color,
				PG.Unit prdUnit	
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR	
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*/
				' + @TracingColumn + ' 
			FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
					ON(D.DocID = DI.DocId)
				INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG
					ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @termI +
			' GROUP BY /*D.FPId,*/ D.WHIdI, 
				DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/ 
			' + @GroupByTracing + ' 
			/*--*/
			) T 
			GROUP BY /*FPId,*/ WHId, FGId, FGCode, FGName, SGId, SGCode, SGName, PrdId, PrdCode, PrdName, 
			PrdLatinName, PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, prdUnit 
			,PrdUnitFCR/*,DocIFCR ,DocIFCRI*/
			' + @FinalGroupByTracing
			+ @term2 +
			' Order By /*FPId,*/ WHId, FGId, SGId, PrdId '
		)
		/**/
	END
	/**/
END





