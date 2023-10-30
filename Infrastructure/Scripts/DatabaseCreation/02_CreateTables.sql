-- =============================================
-- Versão: 1.0.0
-- Data: 2023-10-30
-- Autor: Rafael Ventura
-- Descrição: Cria tabelas no banco de dados BICICLETARIO
-- =============================================

USE BICICLETARIO
GO

-- Exclui a tabela Bicicletas se ela já existir
IF OBJECT_ID('dbo.Bicicletas', 'U') IS NOT NULL
    DROP TABLE dbo.Bicicletas
GO

-- Cria a tabela Bicicletas
CREATE TABLE dbo.Bicicletas
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Marca NVARCHAR(50),
    Modelo NVARCHAR(50),
    Cor NVARCHAR(50)
)
GO
