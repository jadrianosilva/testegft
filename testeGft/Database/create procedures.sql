
--procedures CRUD Categorias
CREATE PROC dbo.sp_category_insert(@dsCategory VARCHAR(30))
AS

    INSERT INTO tbCategory(dsCategory)
    VALUES(@dsCategory)

    SELECT @@IDENTITY AS 'idCategory'
GO

CREATE PROC dbo.sp_category_update(@IdCategory INT,
                                   @dsCategory VARCHAR(30))
AS

    UPDATE tbCategory
       SET dsCategory = @dsCategory
     WHERE idCategory = @IdCategory
GO

CREATE PROC dbo.sp_category_delete(@IdCategory INT)
AS

    DELETE tbCategory
     WHERE idCategory = @IdCategory
GO

CREATE PROC dbo.sp_category_listar
AS
    SELECT idCategory
          ,dsCategory
      FROM tbCategory
GO

CREATE PROC dbo.sp_category_consultar(@IdCategory INT)
AS
    SELECT idCategory
          ,dsCategory
      FROM tbCategory
     WHERE idCategory = @IdCategory
GO

--procedures CRUD Range
CREATE PROC dbo.sp_range_insert(@FirstValue DECIMAL(15,2),
                                @LastValue DECIMAL(15,2))
AS

    INSERT INTO tbRange(firstValue, lastValue)
    VALUES(@FirstValue,@LastValue)

    SELECT @@IDENTITY AS 'idRange'
GO

CREATE PROC dbo.sp_range_update(@IdRange INT,
                                @FirstValue DECIMAL(15,2),
                                @LastValue  DECIMAL(15,2))
AS

    UPDATE tbRange
       SET firstValue = @FirstValue
          ,lastValue  = @LastValue
     WHERE idRange = @IdRange
GO

CREATE PROC dbo.sp_range_delete(@IdRange INT)
AS

    DELETE tbRange
     WHERE idRange = @IdRange
GO

CREATE PROC dbo.sp_range_listar
AS
    SELECT idRange
          ,firstValue
          ,lastValue
      FROM tbRange
GO

CREATE PROC dbo.sp_range_consultar(@IdRange INT)
AS
    SELECT idRange
          ,firstValue
          ,lastValue
      FROM tbRange
     WHERE idRange = @IdRange
GO

--procedures CRUD Sector
CREATE PROC dbo.sp_sector_insert(@DsSector VARCHAR(30))
AS

    INSERT INTO tbSector(dsSector)
    VALUES(@DsSector)

    SELECT @@IDENTITY AS 'idSector'
GO

CREATE PROC dbo.sp_sector_update(@IdSector INT,
                                 @DsSector VARCHAR(30))
AS

    UPDATE tbSector
       SET dsSector = @DsSector
     WHERE idSector = @IdSector
GO

CREATE PROC dbo.sp_sector_delete(@IdSector INT)
AS

    DELETE tbSector
     WHERE idSector = @IdSector
GO

CREATE PROC dbo.sp_sector_listar
AS
    SELECT idSector
          ,dsSector
      FROM tbSector
GO

CREATE PROC dbo.sp_sector_consultar(@IdSector INT)
AS
    SELECT idSector
          ,dsSector
      FROM tbSector
     WHERE idSector = @IdSector
GO


--procedures CRUD Trade
CREATE PROC dbo.sp_trade_insert(@IdCliente INT
                               ,@TradeValue DECIMAL(15,2)
                               ,@IdSector  INT)
AS

    INSERT INTO tbTrades(idClient,trdValue,idSector)
    VALUES(@IdCliente,@TradeValue,@IdSector)

    SELECT @@IDENTITY AS 'idTrade'
GO
CREATE PROC dbo.sp_trade_update(@IdTrade    INT
                               ,@TradeValue DECIMAL(15,2)
                               ,@IdSector   INT)
AS
    UPDATE tbTrades
       SET trdValue = @TradeValue
          ,idSector = @IdSector
     WHERE idTrade  = @IdTrade
 
GO
CREATE PROC dbo.sp_trade_delete(@IdTrade INT)
AS
    DELETE tbTrades
     WHERE idTrade  = @IdTrade

GO

CREATE PROC dbo.sp_trade_listar
AS
    SELECT tr.idTrade
           tr.idCliente
           tr.tradeValue
           tr.idSector
           se.dsSector
      FROM tbTrades tr
     INNER JOIN tbSector se
        ON tr.idSector = se.idSector
     ORDER BY tr.idCliente
GO

CREATE PROC dbo.sp_trade_consultar(@IdTrade INT)
AS 
    SELECT tr.idTrade
           tr.idCliente
           tr.tradeValue
           tr.idSector
           se.dsSector
      FROM tbTrades tr
     INNER JOIN tbSector se
        ON tr.idSector = se.idSector
     WHERE tr.idTrade  = @IdTrade
GO

CREATE PROC dbo.sp_tradeCategory_insert(@IdCategory INT,
                                        @IdRange    INT,
                                        @IdSector   INT)
AS
    INSERT INTO tbTradeCategory
	VALUES (@IdCategory,@IdRange,@IdSector)
GO

CREATE PROC dbo.sp_tradeCategory_delete(@IdCategory INT,
                                        @IdRange    INT,
                                        @IdSector   INT)
AS
    DELETE tbTradeCategory
	 WHERE idCategory = @IdCategory
	   AND idRange    = @IdRange
	   AND idSector   = @IdSector
GO

CREATE PROC dbo.sp_tradeCategory_sector(@TradeValue DECIMAL(15,2)
                                       ,@DsSector VARCHAR(30))
AS
	SELECT DsCategoria
	  FROM tbCategory ct
	 INNER JOIN tbTradeCategory tr
		ON ct.idCategory = tr.idCategory
	 INNER JOIN tbRange  rg
		ON tr.idRange    = rg.IdRange
	 INNER JOIN tbSector se
		ON tr.idSector   = se.idSector
	 WHERE @TradeValue BETWEEN rg.firstValue AND rg.lastValue
	   AND se.dsSector = @DsSector
GO