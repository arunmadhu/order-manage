CREATE TABLE [dbo].[Order] (
    [Id]           INT           NOT NULL,
    [OrderNumber]  NVARCHAR (50) NOT NULL,
    [CustomerName] NVARCHAR (50) NOT NULL,
    [TotalPrice]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

