CREATE TABLE [dbo].[l_kid_to_class] (
    [id]       INT IDENTITY (1, 1) NOT NULL,
    [kid_id]   INT NOT NULL,
    [class_id] INT NOT NULL,
    [active]   BIT NOT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_l_kid_to_class_ToClasses] FOREIGN KEY ([class_id]) REFERENCES [dbo].[classes] ([class_id]),
    CONSTRAINT [FK_l_kid_to_class_ToKids] FOREIGN KEY ([kid_id]) REFERENCES [dbo].[kids] ([kid_id])
);
