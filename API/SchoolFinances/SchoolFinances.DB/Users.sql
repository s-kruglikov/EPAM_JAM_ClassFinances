CREATE TABLE [dbo].[users] (
    [user_id]      INT            IDENTITY (1, 1) NOT NULL,
    [last_name]    NVARCHAR (MAX) NOT NULL,
    [first_name]   NVARCHAR (MAX) NOT NULL,
    [user_name]    NVARCHAR (MAX) NOT NULL,
    [password]     NVARCHAR (MAX) NOT NULL,
    [phone_number] NVARCHAR (MAX) NOT NULL,
    [role]         NVARCHAR (MAX) DEFAULT (user_name()) NOT NULL,
    [active]       BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);
