CREATE TABLE [dbo].[ProductSku]
(
	[Id] BIGINT NOT NULL  IDENTITY, 
    [SKU] NVARCHAR(MAX) NULL, 
    [IsDefault] INT NULL, 
    [ProductId] BIGINT NOT NULL, 
    PRIMARY KEY ([Id] DESC)
)

GO


CREATE INDEX [IX_ProductSku_Column] ON [dbo].[ProductSku] ([ProductId])

GO
