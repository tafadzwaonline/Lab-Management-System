Insert into  AttachFileTransTypes values(22222, 'SampleReceive', null, null, null)
Go

Alter table JobOrderDetails add IsEnable bit not null default(0)
Go

--One time update
--Update JobOrderDetails set IsEnable = 1
--Go

ALTER PROC [dbo].[SPGetActiveWorkOrderReport]
AS
Begin
select "WorkOrderList"."WorkOrderNo",
       "WorkOrderList"."TransDate",
       "CustomersList"."CustomerName",
       "WorkLast"."InvoiceDate" as "LastInvoicePaidDate",
	   "WorkLast"."Amount" as "LastInvoicePaidAmount"
  from (((("dbo"."WorkOrderList" "WorkOrderList"
    inner join "dbo"."JobOrderDetails" "JobOrderDetails"
       on ("JobOrderDetails"."JobOrderDetailsID" = "WorkOrderList"."FKJobOrderDetailsID"))
	inner join "dbo"."JobOrderMaster" "JobOrderMaster"
       on ("JobOrderMaster"."JobOrderMasterID" = "JobOrderDetails"."FKJobOrderMasterID"))
	inner join "dbo"."CustomersList" "CustomersList"
       on ("CustomersList"."CustomerID" = "JobOrderMaster"."FKCustomerID"))	
	left outer join (select * from
		(select ROW_NUMBER() OVER(PARTITION BY [WorkOrderID] ORDER BY [InvoiceId] DESC) RowNo,* from (
		select "WorkOrderList"."WorkOrderNo",
		"Invoice"."InvoiceId", "Invoice"."InvoiceDate", "WorkOrderList"."WorkOrderID",
		Sum( "WorkOrderTimeSheet"."TotalWorkingPrice" + "WorkOrderTimeSheet"."TotalAdditionalPrice") AS 'Amount'
		from ("dbo"."Invoice" "Invoice"
		inner join "dbo"."WorkOrderInvoice"
		"WorkOrderInvoice"
		on ("WorkOrderInvoice"."FkInvoiceId" = "Invoice"."InvoiceId")
		inner join "dbo"."WorkOrderList" "WorkOrderList"
		on ("WorkOrderList"."WorkOrderID" = "WorkOrderInvoice"."FkWorkOrderId")
		inner join "dbo"."JobOrderDetails" "JobOrderDetails"
		on ("JobOrderDetails"."JobOrderDetailsID" = "WorkOrderList"."FKJobOrderDetailsID")
		inner join "dbo"."PaymentMaster" "PaymentMaster"
		on ("PaymentMaster"."FKJobOrderMasterID" = "JobOrderDetails"."FKJobOrderMasterID")
		inner join "dbo"."WorkOrderTimeSheet"
		"WorkOrderTimeSheet"
		on ("WorkOrderTimeSheet"."FkWorkOrderID" = "WorkOrderInvoice"."FkWorkOrderId")
		And "WorkOrderTimeSheet"."StartDate" between  "WorkOrderInvoice"."StartDate" And "WorkOrderInvoice"."EndDate")	
		--where WorkOrderID = 454
		group by "WorkOrderList"."Description",
		"WorkOrderList"."WorkOrderNo","WorkOrderList"."WorkOrderID",
		"Invoice"."InvoiceId", "Invoice"."InvoiceDate"
		) as t
		) as t1 where t1.RowNo = 1
	   ) "WorkLast"
	  on ("WorkOrderList".WorkOrderID = "WorkLast"."WorkOrderID" ))	   
 where "WorkOrderList"."EndDate" >= GETDATE()
 order by "WorkOrderList"."WorkOrderID"
End
GO

ALTER PROC [dbo].[SPGetActiveJobkOrderReport]
AS
Begin

	select "JobOrderMaster"."JobOrderNumber",
		   "JobOrderMaster"."TransactionDate",
		   "CustomersList"."CustomerName",
		   "SampleReceived"."ReceiveDate" as "LastServiceReceivedDate",
		   "InvoiceLast"."PaymentDate" as "LastInvoicePaidDate",
		   "InvoiceLast"."PaymentAmount" as "LastInvoicePaidAmount"
	from ("dbo"."JobOrderMaster" "JobOrderMaster"
	  inner join "dbo"."CustomersList" "CustomersList"
		   on ("CustomersList"."CustomerID" = "JobOrderMaster"."FKCustomerID"))
	  left outer join (select * from 
		(select ROW_NUMBER() OVER(PARTITION BY [FKJobOrderMasterID] ORDER BY [PaymentID] DESC) RowNo,* from PaymentMaster 
		where PaymentType = 0) t
		where t.RowNo = 1) "InvoiceLast"
		   on ("JobOrderMaster"."JobOrderMasterID" = "InvoiceLast"."FKJobOrderMasterID")
	  left outer join (select * from
		(select ROW_NUMBER() OVER(PARTITION BY [FKJobOrderMasterID] ORDER BY [SampleID] DESC) RowNo,* from SampleReceiveList) s
	    where s.RowNo = 1) "SampleReceived"
		on ("JobOrderMaster"."JobOrderMasterID" = "SampleReceived"."FKJobOrderMasterID")
	where "JobOrderMaster"."ExpiryDate" >= GETDATE()
	order by "JobOrderMaster"."JobOrderMasterID"
End
GO

CREATE FUNCTION [dbo].[Split]
(
	@String VARCHAR(MAX), 
	@Delimiter CHAR(1)
)       
RETURNS @temptable TABLE (items VARCHAR(MAX))       
AS       
BEGIN      
    DECLARE @idx INT       
    DECLARE @slice VARCHAR(8000)       

    SELECT @idx = 1       
        IF LEN(@String)<1 OR @String IS NULL  RETURN       

    WHILE @idx!= 0       
    BEGIN       
        SET @idx = CHARINDEX(@Delimiter,@String)       
        IF @idx!=0       
            SET @slice = LEFT(@String,@idx - 1)       
        ELSE       
            SET @slice = @String       

        IF(LEN(@slice)>0)  
            INSERT INTO @temptable(Items) VALUES(@slice)       

        SET @String = RIGHT(@String,LEN(@String) - @idx)       
        IF LEN(@String) = 0 BREAK       
    END   
RETURN 
END
Go

CREATE PROC [dbo].[SPGetServicesVsConsumableReport]
@FromDate NVarchar(20),
@ToDate NVarchar(20),
@JoNo Int,
@ServiceNo Int,
@ItemNos NVarchar(50)
AS
Begin

	SET NOCOUNT ON;  
	IF 1=0 BEGIN  
		SET FMTONLY OFF  
	END  

	--drop table #Items
    create table #Items
	(
		ItemID int
	);

	INSERT INTO #Items (ItemID)
	SELECT items FROM Split(@ItemNos,',')

	DECLARE @cols AS NVARCHAR(MAX),
    @query  AS NVARCHAR(MAX);
	
	create table #temp
	(
		JobOrderNumber nvarchar(50),
		TestName nvarchar(500),
		ItemName nvarchar(200),
		ItemID int,
		Qty decimal(18,2)
	)

	INSERT INTO #temp --(JobOrderNumber, TestName, ItemName, ItemID, Qty)
	select JM.JobOrderNumber, TL.TestName, 
	Trim(Coalesce(IL.ItemName,'')) AS ItemName, IL.ItemID, Sum(Coalesce(TI.Qty,0)) AS Qty
	from SampleReceiveList SR
	INNER JOIN JobOrderMaster JM ON SR.FKJobOrderMasterID = JM.JobOrderMasterID
	INNER JOIN SampleReceiveTestList SRT ON SR.SampleID = SRT.FKSampleID
	INNER JOIN TestsList TL ON SRT.FKTestID = TL.TestID
	LEFT OUTER JOIN TestItems TI ON TL.TestID = TI.FKTestID
	LEFT OUTER JOIN ItemsList IL ON TI.FKItemID = IL.ItemID
	--where  ((@DateFrom = '' or @DateFrom )--SR.SampleNo = '4613' --IL.ItemName = 'Glass bead' -- jm.JobOrderNumber = 73
	where ((@FromDate = '' or @FromDate <= SR.ReceiveDate)
       and (@ToDate = '' or SR.ReceiveDate <= @ToDate))
       and (@JoNo = 0 or JM.JobOrderNumber = @JoNo)
	   and (@ServiceNo = 0 or TL.TestID = @ServiceNo)
	group by JM.JobOrderNumber, TL.TestName, IL.ItemName, IL.ItemID

	Update #temp Set ItemName = '', Qty = null where ItemID is null
	Update #temp Set ItemName = '', Qty = null where ItemID Not in (select ItemID from #Items)
	
	--SET @cols = STUFF((SELECT distinct ',' + QUOTENAME(c.ItemName) 
	--			FROM #temp c
	--			INNER JOIn #Items i ON c.ItemID = i.ItemID
	--			where c.ItemName != ''
	--			FOR XML PATH(''), TYPE
	--			).value('.', 'NVARCHAR(MAX)') 
	--		,1,1,'')

	----print @cols

	--set @query = 'SELECT JobOrderNumber,TestName, ' + @cols + ' from 
	--			(
	--				select JobOrderNumber,TestName,Qty,ItemName
	--				from #temp
	--		   ) x
	--			pivot 
	--			(
	--				 sum(Qty)
	--				for ItemName in (' + @cols + ')
	--			) p '

	--execute(@query)
	--SET FMTONLY ON  
	select * from #temp
	--SET FMTONLY OFF  

	--select JM.JobOrderNumber, TL.TestName, 
	--Trim(Coalesce(IL.ItemName,'')) AS ItemName, IL.ItemID, Sum(Coalesce(TI.Qty,0)) AS Qty
	--from SampleReceiveList SR
	--INNER JOIN JobOrderMaster JM ON SR.FKJobOrderMasterID = JM.JobOrderMasterID
	--INNER JOIN SampleReceiveTestList SRT ON SR.SampleID = SRT.FKSampleID
	--INNER JOIN TestsList TL ON SRT.FKTestID = TL.TestID
	--LEFT OUTER JOIN TestItems TI ON TL.TestID = TI.FKTestID --AND TI.FKItemID in (select ItemID from #Items)
	--LEFT OUTER JOIN ItemsList IL ON TI.FKItemID = IL.ItemID --AND IL.ItemID in (select ItemID from #Items)
	----where  ((@DateFrom = '' or @DateFrom )--SR.SampleNo = '4613' --IL.ItemName = 'Glass bead' -- jm.JobOrderNumber = 73
	--where ((@FromDate = '' or @FromDate <= SR.ReceiveDate)
 --      and (@ToDate = '' or SR.ReceiveDate <= @ToDate))
 --      and (@JoNo = 0 or JM.JobOrderNumber = @JoNo)
	--   and (@ServiceNo = 0 or TL.TestID = @ServiceNo)
	--group by JM.JobOrderNumber, TL.TestName, IL.ItemName, IL.ItemID
End
GO