USE [Master]
GO

CREATE DATABASE ApiBitzen

USE [ApiBitzen]
GO

CREATE TABLE [dbo].[tblPermissao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](150) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tblPermissao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblUsuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
	[Login] [nvarchar](70) NULL,
	[Senha] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](70) NULL,
	[IdPermissao] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tblUsuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblUsuario]  WITH CHECK ADD  CONSTRAINT [FK_tblUsuario_tblPermissao_IdPermissao] FOREIGN KEY([IdPermissao])
REFERENCES [dbo].[tblPermissao] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblUsuario] CHECK CONSTRAINT [FK_tblUsuario_tblPermissao_IdPermissao]
GO

CREATE TABLE [dbo].[tblTipoVeiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_tblTipoVeiculo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tblVeiculo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](80) NOT NULL,
	[Modelo] [nvarchar](70) NULL,
	[Ano] [nvarchar](4) NOT NULL,
	[Placa] [nvarchar](10) NULL,
	[KM] [int] NOT NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTipoVeiculo] [int] not null,
	[foto] nvarchar(1000) NOT NULL,
 CONSTRAINT [pk_tblVeiculos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblVeiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblveiculo_tblUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[tblUsuario] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblVeiculo]  WITH CHECK ADD  CONSTRAINT [FK_tblVeiculo_tblTipoVeiculo] FOREIGN KEY([IdTipoVeiculo])
REFERENCES [dbo].[tblTipoVeiculo] ([Id])
ON DELETE CASCADE
GO

CREATE TABLE [dbo].[tblTipoCombustivel](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_TipoCombustivel] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[tblAbastecimento](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVeiculo] [int] not null,
	[Km] [nvarchar](70) NULL,
	[Litros] [nvarchar](70) NULL,
	[ValorPago] [nvarchar](50) NOT NULL,
	[Data] datetime NULL,
	[NomePosto] [nvarchar](70) NULL,
	[IdUsuario] [int] NOT NULL,
	[IdTipoCombustivel] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_tblAbastecimento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tblAbastecimento]  WITH CHECK ADD  CONSTRAINT [FK_tblAbastecimento_tblVeiculo_IdVeiculo] FOREIGN KEY([IdVeiculo])
REFERENCES [dbo].[tblVeiculo] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblAbastecimento]  WITH CHECK ADD  CONSTRAINT [FK_tblAbastecimento_tblUsuario_IdUsuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[tblUsuario] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[tblAbastecimento]  WITH CHECK ADD  CONSTRAINT [FK_tblAbastecimento_tblTipoCombustivel_IdTipoCombustivel] FOREIGN KEY([IdTipoCombustivel])
REFERENCES [dbo].[tblTipoCombustivel] ([Id])
ON DELETE CASCADE
GO





