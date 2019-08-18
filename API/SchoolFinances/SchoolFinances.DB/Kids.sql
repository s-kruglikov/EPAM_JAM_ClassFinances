CREATE TABLE [dbo].[kids] (
    [kid_id]     INT            IDENTITY (1, 1) NOT NULL,
    [last_name]  NVARCHAR (MAX) NOT NULL,
    [first_name] NVARCHAR (MAX) NOT NULL,
    [active]     BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([kid_id] ASC)
);