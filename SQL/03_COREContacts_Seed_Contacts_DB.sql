USE COREContacts;

IF NOT EXISTS (SELECT * FROM [dbo].[contacts] WHERE [Email] = 'elon.musk@example.com')
    INSERT INTO [dbo].[contacts] ([FirstName], [LastName], [Email], [TwitterUsername], [Note], [ImageUrl])
    VALUES ('Elon', 'Musk', 'elon.musk@example.com', 'elonmusk', 'CEO of Tesla and SpaceX', 'https://example.com/images/elonmusk.jpg');

IF NOT EXISTS (SELECT * FROM [dbo].[contacts] WHERE [Email] = 'bill.gates@example.com')
    INSERT INTO [dbo].[contacts] ([FirstName], [LastName], [Email], [TwitterUsername], [Note], [ImageUrl])
    VALUES ('Bill', 'Gates', 'bill.gates@example.com', 'BillGates', 'Co-founder of Microsoft', 'https://example.com/images/billgates.jpg');

IF NOT EXISTS (SELECT * FROM [dbo].[contacts] WHERE [Email] = 'sheryl.sandberg@example.com')
    INSERT INTO [dbo].[contacts] ([FirstName], [LastName], [Email], [TwitterUsername], [Note], [ImageUrl])
    VALUES ('Sheryl', 'Sandberg', 'sheryl.sandberg@example.com', 'sherylsandberg', 'COO of Facebook', 'https://example.com/images/sherylsandberg.jpg');

