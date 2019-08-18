CREATE TABLE [dbo].[donates]
(
	[donate_id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [purpose] NVARCHAR(MAX) NOT NULL, 
    [amount] INT NOT NULL, 
    [due_date] DATETIME NOT NULL, 
    [created_date] DATETIME NOT NULL, 
    [created_by] INT NOT NULL, 
    [active] BIT NOT NULL, 
    CONSTRAINT [FK_donates_ToUsers] FOREIGN KEY ([created_by]) REFERENCES [users]([user_id])
)
