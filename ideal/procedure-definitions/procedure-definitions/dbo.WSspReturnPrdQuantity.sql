




/*ADBF921205*/
/*RZ960225 For multi language*/
/*ADBF 961208
Added Opr3 And WHId=0 ForAll WH
تغییر به نحوی که هم موجودی برگه جابجایی بین انبار ها را لحاظ کن
هم
با پاس دادن انبار صفر موجودی همه انبار ها از کالای انتخابی را بیاورد
*/
/*RZ981107- Add FCR*/
/*RZ990210- Deactive FCR*/
/*RZ990318- Add Tracing*/  
/*RZ991108- Modify RemainCurrAndAll when is e+*/
/*RZ14000511- Add condition in calculate tracing count in out*/
/*RZ14010905- Convert Remain*/
Create Procedure [dbo].[WSspReturnPrdQuantity]	
(		
/* 
	exec WSspReturnPrdQuantity 7927, 2, 1, 0, 1065, 1065 ,null,null,N'AA-10-20'	
*/
@PrdId INT, 
@FPId INT, 
@WHId INT, 
@CurrId INT, 
/*RZ960225 For multi language*/
@LanguageID INT = NULL,
@DefaultLanguageID INT = NULL,
/*RZ981107- Add FCR*/
@FCR FLOAT = NULL,
@FCRI FLOAT = NULL
/*RZ981107- End*/
,@Tracing NVARCHAR(200) = NULL/*RZ990318- Add Tracing*/
)
As
BEGIN
/**/
DECLARE @QuantityIn float/*ADBF951205*/, 
	@QuantityOut float/*ADBF951205*/, 
	@RemainCount float/*ADBF951205*/,
	@PrdName NVARCHAR(1000)/*ADBF951205 100->1000*/, 
	@NetPreOrderCount float,
	/*Added By ADBF9612*/
	@QuantityInAllWH float, 
	@QuantityOutAllWH float, 
	@RemainCountAllWH float,
	@RemainCurrAndAll VARCHAR(300),/*RZ991108- Modify RemainCurrAndAll when is e+*/
	/*RZ990318- Add Tracing*/
	@TracingQuantityIn float,
	@TracingQuantityOut float,
	@TracingRemainCount FLOAT
	/*RZ990318- End*/
	
IF(@LanguageID IS NULL OR @LanguageID = @DefaultLanguageID)
BEGIN
/*---------------------------------------*/
SELECT 
	@QuantityIn = IsNull(SUM(DI.Quantity), 0), 
	@PrdName = (SELECT PrdName FROM dbo.WSProducts WHERE ProductID = DI.PrdId)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
/*ADBF961208 
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)*//*1--@OprId*/
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
And DI.PrdId = @PrdId 
And D.WHId = @WHId
/*--AND DI.ID <> @CurrId*/
/*Added By ADBF in 961208 Because OutQty Have this*/
AND DI.DocItemID <> @CurrId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
GROUP BY DI.PrdId
/*-----*/
SELECT 
	@QuantityOut = IsNull(SUM(DI.Quantity), 0)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
And DI.PrdId = @PrdId
And D.WHId = @WHId
AND DI.DocItemID <> @CurrId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*Added By ADBF 961208*/
OR ( 
	(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
	And DI.PrdId = @PrdId
	And D.WHIdI = @WHId
	AND DI.DocItemID <> @CurrId
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
)--@WHId)
/*Added End*/
GROUP BY DI.PrdId
/*----*/
SELECT 
	@QuantityInAllWH = IsNull(SUM(DI.Quantity), 0)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
/*ADBF961208 
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)*//*1--@OprId*/
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
And DI.PrdId = @PrdId 
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*And D.WHId = @WHId*/
/*--AND DI.ID <> @CurrId*/
/*Added By ADBF in 961208 Because OutQty Have this*/
AND DI.DocItemID <> @CurrId
GROUP BY DI.PrdId
/*-----*/
SELECT 
	@QuantityOutAllWH = IsNull(SUM(DI.Quantity), 0)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
And DI.PrdId = @PrdId
/*And D.WHId = @WHId*/
AND DI.DocItemID <> @CurrId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*Added By ADBF 961208*/
OR ( 
	(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
	And DI.PrdId = @PrdId
	/*And D.WHIdI = @WHId*/
	AND DI.DocItemID <> @CurrId
)--@WHId)
/*Added End*/
GROUP BY DI.PrdId
/*----*/
SELECT 
	@NetPreOrderCount = ISNULL(SUM(pordIQuantity), 0) 
FROM dbo.WSPreOrderItems
WHERE PreOrderId IN (
	SELECT IsNull(PreOrderID , '') 
	FROM dbo.WSPreOrder
	WHERE PreOrderID NOT IN (SELECT PreOrderID FROM dbo.WSOrder)
)
AND pordIPrdId = @PrdId
/*----*/
SET @RemainCount = IsNull(@QuantityIn, 0) - IsNull(@QuantityOut, 0)
SET @RemainCountAllWH = IsNull(@QuantityInAllWH, 0) - IsNull(@QuantityOutAllWH, 0)
/*SET @RemainCurrAndAll = CAST(@RemainCount AS VARCHAR(10)) + '/' + CAST(@RemainCountAllWH AS VARCHAR(10))*/
/*RZ991108- Modify RemainCurrAndAll when is e+*/
SET @RemainCurrAndAll = CAST(CAST(ISNULL(@RemainCount,0) AS NUMERIC(18,3)) AS VARCHAR(100)) + '/' 
					  + CAST(CAST(ISNULL(@RemainCountAllWH,0) AS NUMERIC(18,3))  AS VARCHAR(100))
SET @RemainCurrAndAll = REPLACE(@RemainCurrAndAll,'.000','')
/*RZ991108- End*/
/*----*/
/*RZ990318- Add Tracing*/
IF(ISNULL(@Tracing,'') <> '')
BEGIN
/**/
	SELECT 
		@TracingQuantityIn = IsNull(SUM(DI.Quantity), 0)
	FROM dbo.WSDoc D 
	INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
	WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
	And DI.PrdId = @PrdId 
	And D.WHId = @WHId
	AND DI.DocItemID <> @CurrId
	AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
	GROUP BY DI.PrdId
	/*----*/
	SELECT 
		@TracingQuantityOut = IsNull(SUM(DI.Quantity), 0)
	FROM dbo.WSDoc D 
	INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
	WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
	And DI.PrdId = @PrdId
	And D.WHId = @WHId
	AND DI.DocItemID <> @CurrId
	AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
	OR ( 
		(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
		And DI.PrdId = @PrdId
		And D.WHIdI = @WHId
		AND DI.DocItemID <> @CurrId
		/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
		/*RZ14000511- Add condition in calculate tracing count in out*/
		AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
		/*RZ14000511- End*/
	)
	GROUP BY DI.PrdId
	/*----*/
	SET @TracingRemainCount = ISNULL(@TracingQuantityIn, 0) - ISNULL(@TracingQuantityOut, 0)
/**/
END
ELSE
BEGIN
/**/
	SET @TracingRemainCount = @RemainCount
/**/
END
/*RZ990318- End*/
/*----*/
SELECT /*@RemainCount QuantityRemain,*/
CAST(CAST(@RemainCount AS NUMERIC(18,3)) AS FLOAT)QuantityRemain, /*RZ14010905- Convert Remain*/

@QuantityIn QuantityIn, @QuantityOut QuantityOut, @PrdId PrdId, @PrdName PrdName, 
	/*@RemainCount RemainCount*/	
	CAST(CAST(@RemainCount AS NUMERIC(18,3)) AS FLOAT)RemainCount /*RZ14010905- Convert Remain*/
	, @NetPreOrderCount NetPreOrderCount, @RemainCountAllWH RemainCountAllWH, @RemainCurrAndAll RemainCurrAndAll 
	/*,@TracingRemainCount TracingRemainCount*/ /*RZ990318- Add Tracing*/
	,CAST(CAST(@TracingRemainCount AS NUMERIC(18,3)) AS FLOAT)TracingRemainCount /*RZ14010905- Convert Remain*/
/*----*/
END
/*--==========================================================================================*/
ELSE
/*--==========================================================================================*/
BEGIN/*RZ960225 For multi language*/	
SELECT 
	@QuantityIn = IsNull(SUM(DI.Quantity), 0), 
	@PrdName = (SELECT PrdName FROM dbo.WSProducts_Lang PLN WHERE PLN.ProductID = DI.PrdId  AND PLN.LanguageID = @LanguageID)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
/*ADBF961208 
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)*//*1--@OprId*/
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
And DI.PrdId = @PrdId
And D.WHId = @WHId
/*--AND DI.ID <> @CurrId*/
/*Added By ADBF in 961208 Because OutQty Have this*/
AND DI.DocItemID <> @CurrId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
GROUP BY DI.PrdId
/*-----*/
SELECT 
	@QuantityOut = IsNull(SUM(DI.Quantity), 0)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
And DI.PrdId = @PrdId
/*AND D.FPId = @FPId*/ 
And D.WHId = @WHId
AND DI.DocItemID <> @CurrId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*Added By ADBF 961208*/
OR ( 
	(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
	And DI.PrdId = @PrdId
	And D.WHIdI = @WHId
	AND DI.DocItemID <> @CurrId
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
)--@WHId)
/*Added End*/
GROUP BY DI.PrdId
/*----*/
SELECT 
	@QuantityInAllWH = IsNull(SUM(DI.Quantity), 0) 
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
/*ADBF961208 
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 1)*//*1--@OprId*/
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
And DI.PrdId = @PrdId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*And D.WHId = @WHId*/
/*--AND DI.ID <> @CurrId*/
/*Added By ADBF in 961208 Because OutQty Have this*/
AND DI.DocItemID <> @CurrId
GROUP BY DI.PrdId
/*-----*/
SELECT 
	@QuantityOutAllWH = IsNull(SUM(DI.Quantity), 0)
FROM dbo.WSDoc D 
INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
And DI.PrdId = @PrdId
/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
/*AND D.FPId = @FPId*/ 
/*And D.WHId = @WHId*/
AND DI.DocItemID <> @CurrId
/*Added By ADBF 961208*/
OR ( 
	(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
	And DI.PrdId = @PrdId
	/*And D.WHIdI = @WHId*/
	AND DI.DocItemID <> @CurrId
)--@WHId)
/*Added End*/
GROUP BY DI.PrdId
/*----*/
SELECT 
	@NetPreOrderCount = ISNULL(SUM(pordIQuantity), 0) 
FROM dbo.WSPreOrderItems
WHERE PreOrderId IN (
	SELECT IsNull(PreOrderID , '') 
	FROM dbo.WSPreOrder
	WHERE PreOrderID NOT IN (SELECT PreOrderID FROM dbo.WSOrder)
)
AND pordIPrdId = @PrdId
/*----*/
SET @RemainCount = IsNull(@QuantityIn, 0) - IsNull(@QuantityOut, 0)
SET @RemainCountAllWH = IsNull(@QuantityInAllWH, 0) - IsNull(@QuantityOutAllWH, 0)
/*SET @RemainCurrAndAll = CAST(@RemainCount AS VARCHAR(10)) + '/' + CAST(@RemainCountAllWH AS VARCHAR(10))*/
/*RZ991108- Modify RemainCurrAndAll when is e+*/
SET @RemainCurrAndAll = CAST(CAST(ISNULL(@RemainCount,0) AS NUMERIC(18,3)) AS VARCHAR(100)) + '/' 
					  + CAST(CAST(ISNULL(@RemainCountAllWH,0) AS NUMERIC(18,3))  AS VARCHAR(100))
SET @RemainCurrAndAll = REPLACE(@RemainCurrAndAll,'.000','')
/*RZ991108- End*/
/*----*/
/*RZ990318- Add Tracing*/
IF(ISNULL(@Tracing,'') <> '')
BEGIN
/**/
	SELECT 
		@TracingQuantityIn = IsNull(SUM(DI.Quantity), 0)
	FROM dbo.WSDoc D 
	INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
	WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType IN (1,3) )
	And DI.PrdId = @PrdId 
	And D.WHId = @WHId
	AND DI.DocItemID <> @CurrId
	AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
	GROUP BY DI.PrdId
	/*----*/
	SELECT 
		@TracingQuantityOut = IsNull(SUM(DI.Quantity), 0)
	FROM dbo.WSDoc D 
	INNER JOIN dbo.WSDocItems DI ON(D.DocID = DI.DocId)
	WHERE OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 2)/*2--@OprId*/
	And DI.PrdId = @PrdId
	And D.WHId = @WHId
	AND DI.DocItemID <> @CurrId
	AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
	/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
	OR ( 
		(OprId IN (SELECT DocOprId FROM dbo.WSDocOpr WHERE OprType = 3)) 
		And DI.PrdId = @PrdId
		And D.WHIdI = @WHId
		AND DI.DocItemID <> @CurrId
		/*AND (ISNULL(DI.FCR,0) = ISNULL(@FCR,0) AND ISNULL(DI.FCRI,0) = ISNULL(@FCRI,0))*//*RZ981107- Add FCR*//*RZ990210- Deactive FCR*/
		/*RZ14000511- Add condition in calculate tracing count in out*/
		AND ( 
			(REPLACE(REPLACE(REPLACE(CAST(DI.[Tracing] AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740))) =
			(REPLACE(REPLACE(REPLACE(CAST(@Tracing AS NVARCHAR(2000)),NCHAR(1610), NCHAR(1740)),NCHAR(1603),NCHAR(1705)),NCHAR(1609),NCHAR(1740)))
		)
		/*RZ14000511- End*/
	)
	GROUP BY DI.PrdId
	/*----*/
	SET @TracingRemainCount = ISNULL(@TracingQuantityIn, 0) - ISNULL(@TracingQuantityOut, 0)
/**/
END
ELSE
BEGIN
/**/
	SET @TracingRemainCount = @RemainCount
/**/
END
/*RZ990318- End*/
/*----*/

	SELECT /*@RemainCount QuantityRemain,*/
		CAST(CAST(@RemainCount AS NUMERIC(18,3)) AS FLOAT)QuantityRemain, /*RZ14010905- Convert Remain*/

		@QuantityIn QuantityIn, @QuantityOut QuantityOut, @PrdId PrdId, @PrdName PrdName, 
	/*@RemainCount RemainCount*/	
	CAST(CAST(@RemainCount AS NUMERIC(18,3)) AS FLOAT)RemainCount /*RZ14010905- Convert Remain*/
	, @NetPreOrderCount NetPreOrderCount, @RemainCountAllWH RemainCountAllWH, @RemainCurrAndAll RemainCurrAndAll 
	/*,@TracingRemainCount TracingRemainCount*/ /*RZ990318- Add Tracing*/
	,CAST(CAST(@TracingRemainCount AS NUMERIC(18,3)) AS FLOAT)TracingRemainCount /*RZ14010905- Convert Remain*/
END
/**/
END







