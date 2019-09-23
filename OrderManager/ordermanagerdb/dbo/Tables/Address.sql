CREATE TABLE [dbo].[Address] (
    [Id]           INT           NOT NULL,
    [AddressLine1] TEXT          NOT NULL,
    [AddressLine2] TEXT          NOT NULL,
    [State]        NVARCHAR (50) NOT NULL,
    [Pincode]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

