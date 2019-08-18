CREATE TABLE [dbo].[classes] (
    [class_id]   INT            IDENTITY (1, 1) NOT NULL,
    [class_name] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([class_id] ASC)
);
