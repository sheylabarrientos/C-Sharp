USE [LojaServices3]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Endereco_Id] [int] NOT NULL,
	[Email] [nchar](100) NULL,
	[Password] [nchar](255) NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Compra]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Compra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantidade] [int] NOT NULL,
	[Preco] [decimal](9, 2) NOT NULL,
	[Cliente_Id] [int] NOT NULL,
	[Produto_Id] [int] NOT NULL,
 CONSTRAINT [PK_Compra] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Enderecos]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enderecos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [int] NOT NULL,
	[Logradouro] [nvarchar](200) NOT NULL,
	[Complemento] [nvarchar](100) NULL,
	[Bairro] [nvarchar](50) NOT NULL,
	[Cidade] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Enderecos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Categoria] [nvarchar](50) NOT NULL,
	[PrecoUnitario] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocao_Produto]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocao_Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Produto_Id] [int] NOT NULL,
	[Promocao_Id] [int] NOT NULL,
 CONSTRAINT [PK_Promocao_Produto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Promocoes]    Script Date: 16/04/2020 15:10:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Promocoes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](100) NOT NULL,
	[DataInicio] [datetime2](7) NOT NULL,
	[DataTermino] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Promocoes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (1, N'Ingrid', 1, N'ingrid@codenation.com                                                                               ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (1003, N'Sheyla', 1003, N'sheyla@mail.com                                                                                     ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (1004, N'Elis', 1004, N'elis@mail.com                                                                                       ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (2004, N'Marcela', 2002, N'marcela@mail.com                                                                                    ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (2005, N'Barbara', 2003, N'barbara@mail.com                                                                                    ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (2006, N'Carla', 2004, N'carla@mail.com                                                                                      ', N'password                                                                                                                                                                                                                                                       ')
INSERT [dbo].[Cliente] ([Id], [Name], [Endereco_Id], [Email], [Password]) VALUES (2007, N'Juliana', 2005, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
SET IDENTITY_INSERT [dbo].[Compra] ON 

INSERT [dbo].[Compra] ([Id], [Quantidade], [Preco], [Cliente_Id], [Produto_Id]) VALUES (1, 2, CAST(3600.00 AS Decimal(9, 2)), 1, 1)
INSERT [dbo].[Compra] ([Id], [Quantidade], [Preco], [Cliente_Id], [Produto_Id]) VALUES (2, 5, CAST(3800.00 AS Decimal(9, 2)), 1, 1)
INSERT [dbo].[Compra] ([Id], [Quantidade], [Preco], [Cliente_Id], [Produto_Id]) VALUES (3, 1, CAST(70.00 AS Decimal(9, 2)), 1, 3)
INSERT [dbo].[Compra] ([Id], [Quantidade], [Preco], [Cliente_Id], [Produto_Id]) VALUES (1003, 9, CAST(700.00 AS Decimal(9, 2)), 1003, 1002)
SET IDENTITY_INSERT [dbo].[Compra] OFF
SET IDENTITY_INSERT [dbo].[Enderecos] ON 

INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (1, 130, N'Rua Um', NULL, N'Teste', N'São Paulo')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (2, 200, N'Rua segundo', N'segundo complemento', N'segundo bairro', N'segundo Cidade')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (3, 100, N'Rua primeira', N'Primeiro complemento', N'Primeiro bairro', N'Primeira Cidade')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (1002, 100, N'Rua primeira', N'Primeiro complemento', N'Primeiro bairro', N'Primeira Cidade')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (1003, 100, N'Rua 2', N'Primeiro complemento', N'Primeiro bairro', N'Primeira Cidade')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (1004, 200, N'Rua 123', N'segundo complemento', N'segundo bairro', N'segundo Cidade')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (2002, 12, N'Rua doze', N'esquina', N'Bairro doze', N'Cidade doze')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (2003, 12, N'Rua doze', N'esquina', N'Bairro doze', N'Cidade doze')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (2004, 226, N'Rua 226', NULL, N'Bairro 226', N'Cidade 226')
INSERT [dbo].[Enderecos] ([Id], [Numero], [Logradouro], [Complemento], [Bairro], [Cidade]) VALUES (2005, 200, N'Rua segundo', NULL, N'NovoBairro', N'Nova Cidade')
SET IDENTITY_INSERT [dbo].[Enderecos] OFF
SET IDENTITY_INSERT [dbo].[Produto] ON 

INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (1, N'Notebook-A', N'Computadores', CAST(3800.00 AS Decimal(9, 2)))
INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (2, N'Teclado', N'Acessorios', CAST(150.00 AS Decimal(9, 2)))
INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (3, N'Monitor', N'Acessorios', CAST(1600.00 AS Decimal(9, 2)))
INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (1002, N'Suporte notebook alteração', N'Acessorios', CAST(70.00 AS Decimal(9, 2)))
INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (1003, N'Suporte notebook PUT', N'Acessorios', CAST(780.00 AS Decimal(9, 2)))
INSERT [dbo].[Produto] ([Id], [Name], [Categoria], [PrecoUnitario]) VALUES (2002, N'Suporte notebook PostMan', N'Acessorios', CAST(780.00 AS Decimal(9, 2)))
SET IDENTITY_INSERT [dbo].[Produto] OFF
SET IDENTITY_INSERT [dbo].[Promocao_Produto] ON 

INSERT [dbo].[Promocao_Produto] ([Id], [Produto_Id], [Promocao_Id]) VALUES (1, 1, 1)
INSERT [dbo].[Promocao_Produto] ([Id], [Produto_Id], [Promocao_Id]) VALUES (2, 1, 2)
INSERT [dbo].[Promocao_Produto] ([Id], [Produto_Id], [Promocao_Id]) VALUES (1002, 1, 1003)
SET IDENTITY_INSERT [dbo].[Promocao_Produto] OFF
SET IDENTITY_INSERT [dbo].[Promocoes] ON 

INSERT [dbo].[Promocoes] ([Id], [Descricao], [DataInicio], [DataTermino]) VALUES (1, N'Black Friday 2020', CAST(N'2020-11-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Promocoes] ([Id], [Descricao], [DataInicio], [DataTermino]) VALUES (2, N'Pascoa 2020', CAST(N'2020-04-20T00:00:00.0000000' AS DateTime2), CAST(N'2020-04-05T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Promocoes] ([Id], [Descricao], [DataInicio], [DataTermino]) VALUES (1002, N'Covid-19', CAST(N'2020-12-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-12-13T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Promocoes] ([Id], [Descricao], [DataInicio], [DataTermino]) VALUES (1003, N'Covid-19', CAST(N'2020-04-01T00:00:00.0000000' AS DateTime2), CAST(N'2020-04-13T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Promocoes] OFF
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Enderecos_Endereco_Id] FOREIGN KEY([Endereco_Id])
REFERENCES [dbo].[Enderecos] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Enderecos_Endereco_Id]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Cliente] FOREIGN KEY([Cliente_Id])
REFERENCES [dbo].[Cliente] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Cliente]
GO
ALTER TABLE [dbo].[Compra]  WITH CHECK ADD  CONSTRAINT [FK_Compra_Produto] FOREIGN KEY([Produto_Id])
REFERENCES [dbo].[Produto] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Compra] CHECK CONSTRAINT [FK_Compra_Produto]
GO
ALTER TABLE [dbo].[Promocao_Produto]  WITH CHECK ADD  CONSTRAINT [FK__Produto_Promocao] FOREIGN KEY([Produto_Id])
REFERENCES [dbo].[Produto] ([Id])
GO
ALTER TABLE [dbo].[Promocao_Produto] CHECK CONSTRAINT [FK__Produto_Promocao]
GO
ALTER TABLE [dbo].[Promocao_Produto]  WITH CHECK ADD  CONSTRAINT [FK__Promocao_Produto] FOREIGN KEY([Promocao_Id])
REFERENCES [dbo].[Promocoes] ([Id])
GO
ALTER TABLE [dbo].[Promocao_Produto] CHECK CONSTRAINT [FK__Promocao_Produto]
GO
