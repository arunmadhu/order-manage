CREATE TABLE [dbo].[OrderAddress] (
    [Id]        INT NOT NULL,
    [OrderId]   INT NOT NULL,
    [AddressId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderAddress_ToTable] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([Id]),
    CONSTRAINT [FK_OrderAddress_ToTable_1] FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address] ([Id])
);

