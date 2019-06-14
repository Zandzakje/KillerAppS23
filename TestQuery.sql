--inner join
SELECT		[Character].CharacterId, [Character].[Name], [Character].[Level], [Character].[MaxHp],
			[Character].[Attack], [Character].[Defense], [Character].[Speed], [User].[Password],
			[User].[Class], [User].[CurrentExp], [User].[NextExp], [User].[TotalExp]
FROM		[Character] 
INNER JOIN	[User] ON [Character].CharacterId = [User].CharacterId
WHERE		[Character].[Name] = 'Damian' AND [User].[Password] = 123;


