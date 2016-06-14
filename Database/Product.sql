﻿CREATE TABLE [dbo].[ProductSku]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY, 
    [SKU] NVARCHAR(MAX) NULL, 
    [IsDefault] INT NULL, 
    [ProductId] BIGINT NOT NULL
)
