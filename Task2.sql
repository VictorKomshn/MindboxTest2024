﻿select p.[Name], c.[Name]
from dbo.Products as p
	Left join dbo.ProductsCategories pc on p.[Id] = pc.[ProductId]
	Left join dbo.Categories c on pc.[CategoryId] = c.[Id]