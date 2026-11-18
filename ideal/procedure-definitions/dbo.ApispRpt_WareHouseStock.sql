






/*RZ990924*/
Create PROCEDURE [dbo].[ApispRpt_WareHouseStock]
(			
/* 
	exec ApispRpt_WareHouseStock  0, 0, 0, 0, 0, 0, 0, 0, 0, 3, '13930909', 't' , '0', 1033, 1065 		 
*/
@Mode INT, /*-2,-1,0,1 = All,ByVal,0,>0*/
@FPId INT, 
@WHID INT, 
@FGId INT, 
@SGId INT, 
@PrdId INT,
@MaxStkVal FLOAT,
@MinStkVal FLOAT,
@EqualStkVal FLOAT,
@UserId INT, 
@rptDate VARCHAR(50), 
@rptDay NVARCHAR(50),
@PrdModel NVARCHAR(200),
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL,
@Tracing NVARCHAR(200) = NULL,
@FromRegisterDate DATETIME = NULL,
@ToRegisterDate DATETIME = NULL
)
AS
BEGIN
/**/
DECLARE @rptUserName NVARCHAR(max)
/**/
IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
	SELECT @rptUserName = ISNULL(FName, '') + ' ' + ISNULL(LName , '') FROM Users Us WHERE Us.UserId = CAST(@UserId AS VARCHAR(10))
ELSE
	SELECT @rptUserName = ISNULL(FName, '') + ' ' + ISNULL(LName , '') FROM Users_Lang Us WHERE Us.UserId = CAST(@UserId AS VARCHAR(10))  AND Us.LanguageID = @LanguageID
/**/
DECLARE @Term VARCHAR(max), 
@TermI VARCHAR(MAX)

SET @Term = ''
SET @TermI = ''
/*-----------------------------------------------*/
IF @WHID > 0
BEGIN 
	SET @Term = @Term + ' And D.WHId = ' + CAST(@WHId AS VARCHAR(10))
	SET @TermI = @TermI + ' And D.WHIdI = ' + CAST(@WHId AS VARCHAR(10))
END 
IF @FGId > 0
BEGIN 
	SET @Term = @Term + ' And PG.FGId = ' + CAST(@FGId AS VARCHAR(10))
	SET @TermI = @TermI + ' And PG.FGId = ' + CAST(@FGId AS VARCHAR(10))
END 
IF @SGId > 0
BEGIN 
	SET @Term = @Term + ' And PG.SGId = ' + CAST(@SGId AS VARCHAR(10))
	SET @TermI = @TermI + ' And PG.SGId = ' + CAST(@SGId AS VARCHAR(10))
END 
IF @PrdId > 0
BEGIN 
	SET @Term = @Term + ' And DI.PrdId = ' + CAST(@PrdId AS VARCHAR(10))
	SET @TermI = @TermI + ' And DI.PrdId = ' + CAST(@PrdId AS VARCHAR(10))
END
DECLARE @TracingColumn VARCHAR(max) = '' ,@GroupByTracing VARCHAR(max) = '',
@FinalGroupByTracing VARCHAR(max) = ''
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
/**/
IF @PrdModel > '0'
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
DECLARE @Term2 VARCHAR(4000)
SET @Term2 = ''
/*Cast RemainQuantity and modify mode in quantity*/
IF (@Mode = -1 AND @MaxStkVal > 0)
SET @Term2 = @Term2 + ' Having (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) >=  ' + CAST(@MaxStkVal AS VARCHAR(10))
ELSE
IF (@Mode = -1 AND @MinStkVal > 0)

SET @Term2 = @Term2 + ' Having ( (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) <=  ' + CAST(@MinStkVal AS VARCHAR(10)) + 
				' And (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) > 0 )' 				
ELSE
IF (@Mode = -1 AND @EqualStkVal > 0)
SET @Term2 = @Term2 + ' Having (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) =  ' + CAST(@EqualStkVal AS VARCHAR(10))
ELSE
IF @Mode = 0
SET @Term2 = @Term2 + ' Having (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) = 0 ' 
ELSE
IF @Mode = 1
SET @Term2 = @Term2 + ' Having (CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT)) > 0 '
/*-------------------------------------------------------------------*/
IF(@FromRegisterDate IS NOT NULL AND @ToRegisterDate IS NOT NULL)
BEGIN
/**/
	SET @Term = @Term + ' And DI.PrdId IN(SELECT WDI.[PrdId] FROM [dbo].[WSDocItems] WDI WHERE WDI.[RegisterDate] BETWEEN ''' + CAST(@FromRegisterDate AS VARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS VARCHAR(50)) + ''') '
	SET @TermI = @TermI + ' And DI.PrdId IN(SELECT WDI.[PrdId] FROM [dbo].[WSDocItems] WDI WHERE WDI.[RegisterDate] BETWEEN ''' + CAST(@FromRegisterDate AS VARCHAR(50)) + ''' AND ''' + CAST(@ToRegisterDate AS VARCHAR(50)) + ''') '
/**/
END
/*------------------------------------------------------------------*/
IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
BEGIN	

	 Execute (
		' SELECT 0 ApiFPId, ' + '''' +  @rptUserName + '''' + ' ApiUserName, '+ 
			'''' + @rptDate+''' ApiRptDate, '''+@rptDay +''' ApiRptDay,
			(SELECT WrhsName FROM dbo.WsWareHouse WHERE WareHouseID = WHId) ApiWrhsName,
			(SELECT WrhsCode FROM dbo.WsWareHouse WHERE WareHouseID = WHId) ApiWrhsCode,
			FGCode ApiFGCode, FGName ApiFGName, SGCode ApiSGCode, SGName ApiSGName, PrdCode ApiPrdCode, PrdName ApiPrdName, 
			PrdLatinName ApiPrdLatinName, PrdModel ApiPrdModel, PrdFirstBarcode ApiPrdFirstBarcode, PrdType ApiPrdType, PrdDesign ApiPrdDesign, PrdSize ApiPrdSize
			, Color ApiColor, 
			prdUnit ApiprdUnit, 
			ISNULL(SUM(InQuantity), 0) ApiInQuantity, ISNULL(SUM(OutQuantity), 0) ApiOutQuantity, 
			/*ISNULL(SUM(InQuantity), 0) - ISNULL(SUM(OutQuantity), 0) RemainQuantity,*/
			CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT) ApiRemainQuantity,/*90201- Cast RemainQuantity*/
			FGId ApiFGId, SGId ApiSGId, PrdId ApiPrdId, 
			/*FPId, */WHId	 ApiWHId		
			,PrdUnitFCR ApiPrdUnitFCR,
			CAST(0 AS FLOAT) ApiDocIFCR, CAST(0 AS FLOAT) ApiDocIFCRI
			,''' + @Tracing + ''' [ApiTracing] 
		FROM 
		( 	
		SELECT 	/*D.FPId, */ D.WHId, 
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
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//*Add FCR from WsDocItem*//*Deactive FCR*/
			
			' + @TracingColumn + ' /*Add Tracing*/
		FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
				ON(D.DocID = DI.DocId)
			INNER JOIN dbo.WSfnProductsInGroups() PG
				ON(DI.PrdId = PG.ProductID)	
		WHERE 1=1 AND D.OprId Not IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
		+ @term +
		' GROUP BY /*D.FPId, */D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
		PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
		PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
		PG.Unit /*,DI.[FCR] ,DI.[FCRI] *//*Add FCR from WsDocItem*/	/*Deactive FCR*/	
		' + @GroupByTracing + ' /*Add Tracing*/
		/*Added By ADBF 961208  ورود جابجایی انبار*/
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
			/* add FCR of WSProductUnits*/
			,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
				(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR 					
			/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//* Add FCR from WsDocItem*//* Deactive FCR*/
			' + @TracingColumn + ' /*Add Tracing*/
		FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
				ON(D.DocID = DI.DocId)
			INNER JOIN dbo.WSfnProductsInGroups() PG
				ON(DI.PrdId = PG.ProductID)	
		WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
		+ @term +
		' GROUP BY /*D.FPId, */D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
		PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
		PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
		PG.Unit/*,DI.[FCR] ,DI.[FCRI]*/ /* Add FCR from WsDocItem*/ /* Deactive FCR*/	
		' + @GroupByTracing + ' /* Add Tracing*/
		/*Added By ADBF 961208  خروج جابجایی انبار*/
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
			/*add FCR of WSProductUnits*/
			,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
				(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR 
			/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//*Add FCR from WsDocItem*//*Deactive FCR*/	
			' + @TracingColumn + ' /*Add Tracing*/		
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
		PG.Unit/*,DI.[FCR] ,DI.[FCRI] *//* Add FCR from WsDocItem*/ /* Deactive FCR*/	
		' + @GroupByTracing + ' /* Add Tracing*/
		/*--*/
		) T 
		GROUP BY /*FPId, */WHId, FGId, FGCode, FGName, SGId, SGCode, SGName, PrdId, PrdCode, PrdName, 
		PrdLatinName, PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, prdUnit 
		/* add FCR of WSProductUnits*/
		,PrdUnitFCR/*,DocIFCR ,DocIFCRI*/ /* Add FCR from WsDocItem*//* Deactive FCR*/ 
		' + @FinalGroupByTracing /* Add Tracing*/
		+ @term2 +
		' Order By /*FPId,*/ WHId, FGId, SGId, PrdId '
	)
END
ELSE
BEGIN IF(@LanguageID IS NOT NULL AND @LanguageID <> @DefaultLanguageID)
	EXECUTE (
		' SELECT  0 ApiFPId, ' + '''' +  @rptUserName + '''' + ' ApiUserName, '+ 
			'''' + @rptDate+''' ApiRptDate, '''+@rptDay +''' ApiRptDay,
			(SELECT WrhsName FROM dbo.WsWareHouse_Lang WHLN WHERE WHLN.WareHouseID = WHId AND WHLN.LanguageID=' + @LanguageID + ') ApiWrhsName,
			(SELECT WrhsCode FROM dbo.WsWareHouse WHERE WareHouseID = WHId) ApiWrhsCode,
			FGCode ApiFGCode, FGName ApiFGName, SGCode ApiSGCode, SGName ApiSGName, PrdCode ApiPrdCode, PrdName ApiPrdName, 
			PrdLatinName ApiPrdLatinName, PrdModel ApiPrdModel, PrdFirstBarcode ApiPrdFirstBarcode, PrdType ApiPrdType, PrdDesign ApiPrdDesign, PrdSize ApiPrdSize
			, Color ApiColor, 
			prdUnit ApiPrdUnit, 
			ISNULL(SUM(InQuantity), 0) ApiInQuantity, ISNULL(SUM(OutQuantity), 0) ApiOutQuantity, 
			/*ISNULL(SUM(InQuantity), 0) - ISNULL(SUM(OutQuantity), 0) RemainQuantity,*/
			CAST(CAST(ISNULL(SUM(InQuantity), 0) AS NUMERIC(18,3)) - CAST(ISNULL(SUM(OutQuantity), 0) AS NUMERIC(18,3)) AS FLOAT) ApiRemainQuantity,/*90201- Cast RemainQuantity*/
			FGId ApiFGId, SGId ApiSGId, PrdId ApiPrdId, 
			/*FPId,*//*- Remove FPId from Grouping*/			
			 WHId  ApiWHId
			/* add FCR of WSProductUnits*/
			,PrdUnitFCR ApiPrdUnitFCR,/*DocIFCR,DocIFCRI*//* Add FCR from WsDocItem*/
			CAST(0 AS FLOAT) ApiDocIFCR, CAST(0 AS FLOAT) ApiDocIFCRI/* Deactive FCR*/
			,''' + @Tracing + ''' [ApiTracing] /* Add Tracing*/
		FROM 
		( 	
			SELECT 	/*D.FPId, *//**/
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
				/* add FCR of WSProductUnits*/
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//* Add FCR from WsDocItem*//* Deactive FCR*/
				' + @TracingColumn + ' /* Add Tracing*/
			FROM dbo.WSDoc D 
			INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
			INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 '
			/* Added WareHouseMovementDoc in multi language*/
			+ ' AND D.OprId Not IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @term +
			' GROUP BY /*D.FPId,*//**/ D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/ /* Add FCR from WsDocItem*/ 			/* Deactive FCR*/
			' + @GroupByTracing + ' /* Add Tracing*/
			/* Added WareHouseMovementDoc in multi language*/
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
				/* add FCR of WSProductUnits*/
				,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
					(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR	
				/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//* Add FCR from WsDocItem*//* Deactive FCR*/
				' + @TracingColumn + ' /* Add Tracing*/
			FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
				ON(D.DocID = DI.DocId)
			INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG
				ON(DI.PrdId = PG.ProductID)	
			WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
			+ @term +
			' GROUP BY /*D.FPId,*//**/ D.WHId, DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
			PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
			PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
			PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/ /* Add FCR from WsDocItem*/ 			/* Deactive FCR*/
			' + @GroupByTracing + ' /* Add Tracing*/
		/* Added WareHouseMovementDoc in multi language*/
		UNION ALL
		SELECT 	/*D.FPId,*//**/ D.WHIdI, 
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
			/* add FCR of WSProductUnits*/
			,(SELECT FCR FROM dbo.WSProductUnits WPU WHERE WPU.ProductUnitId = 
				(SELECT WP.PrdUnitId FROM dbo.WSProducts WP WHERE WP.ProductID = DI.PrdId))PrdUnitFCR	
			/*,DI.[FCR] DocIFCR ,DI.[FCRI] DocIFCRI*//* Add FCR from WsDocItem*//* Deactive FCR*/
			' + @TracingColumn + ' /* Add Tracing*/
		FROM dbo.WSDoc D INNER JOIN dbo.WSDocItems DI
				ON(D.DocID = DI.DocId)
			INNER JOIN dbo.WSfnProductsInGroups_Lang(' + @LanguageID + ',' + @DefaultLanguageID + ') PG
				ON(DI.PrdId = PG.ProductID)	
		WHERE 1=1 AND D.OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3) ' 
		+ @termI +
		' GROUP BY /*D.FPId,*//**/ D.WHIdI, 
			DI.PrdId, PG.FGId, PG.FGCode, PG.FGName, PG.SGId, PG.SGCode, PG.SGName, 
		PG.PrdCode ,PG.PrdName, PG.GName, D.OprId,
		PG.PrdLatinName, PG.PrdModel, PG.PrdFirstBarcode, PG.PrdType, PG.PrdDesign, PG.PrdSize, PG.Color,
		PG.Unit /*,DI.[FCR] ,DI.[FCRI]*/ /* Add FCR from WsDocItem*/ /* Deactive FCR*/
		' + @GroupByTracing + ' /* Add Tracing*/
		/*--*/
		) T 
		GROUP BY /*FPId,*//**/ WHId, FGId, FGCode, FGName, SGId, SGCode, SGName, PrdId, PrdCode, PrdName, 
		PrdLatinName, PrdModel, PrdFirstBarcode, PrdType, PrdDesign, PrdSize, Color, prdUnit 
		/* add FCR of WSProductUnits*/
		,PrdUnitFCR/*,DocIFCR ,DocIFCRI*/ /* Add FCR from WsDocItem*//* Deactive FCR*/ 
		' + @FinalGroupByTracing /* Add Tracing*/
		+ @term2 +
		' Order By /*FPId,*//**/ WHId, FGId, SGId, PrdId '
	)
END
/**/
END





