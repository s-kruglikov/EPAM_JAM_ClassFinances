CREATE TABLE [dbo].[l_user_to_kid] (
    [id]      INT IDENTITY (1, 1) NOT NULL,
    [kid_id]  INT NOT NULL,
    [user_id] INT NOT NULL,
    [active]  BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_l_user_to_kid_ToUsers] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([user_id]),
    CONSTRAINT [FK_l_user_to_kid_ToKids] FOREIGN KEY ([kid_id]) REFERENCES [dbo].[kids] ([kid_id])
);