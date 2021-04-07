CREATE TABLE tbCategory
(
    idCategory INT IDENTITY(1,1),
    dsCategory VARCHAR(30),
    CONSTRAINT PK_Category PRIMARY KEY (idCategory)
)
GO

CREATE TABLE tbRange
(
    idRange INT IDENTITY(1,1),
    firstValue  DECIMAL(15,2),
    lastValue   DECIMAL(15,2),
    CONSTRAINT PK_Range PRIMARY KEY (idRange)
)
GO

CREATE TABLE tbSector
(
    idSector INT IDENTITY(1,1),
    dsSector VARCHAR(30),
    CONSTRAINT PK_Sector PRIMARY KEY (idSector)
)
GO

CREATE TABLE tbTradeCategory
(
    idSector INT,
    idRange  INT,
    idCategory INT,
    CONSTRAINT PK_TradeCategory PRIMARY KEY (idSector,idRange,idCategory),
    CONSTRAINT FK_TradeCategory_Sector   FOREIGN KEY (idSector) REFERENCES tbSector (idSector),
    CONSTRAINT FK_TradeCategory_Range    FOREIGN KEY (idRange)  REFERENCES tbRange (idRange),
    CONSTRAINT FK_TradeCategory_Category FOREIGN KEY (idCategory) REFERENCES tbCategory (idCategory)
)
GO

CREATE TABLE tbTrades
(
    idTrade  INT IDENTITY(1,1),
    idClient INT,
    trdValue DECIMAL(15,2),
    idSector INT,
    CONSTRAINT PK_Trades PRIMARY KEY (idTrade),
    CONSTRAINT FK_Trades_Sector FOREIGN KEY (idSector) REFERENCES tbSector (idSector)
)
GO