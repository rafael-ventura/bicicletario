-- =============================================
-- Versão: 1.0.0
-- Data: 2023-10-30
-- Autor: Rafael Ventura
-- Descrição: Cria o banco de dados BICICLETARIO
-- =============================================

-- Exclui o banco de dados BICICLETARIO se ele já existir
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'BICICLETARIO')
    DROP DATABASE BICICLETARIO
GO

-- Cria o banco de dados BICICLETARIO
CREATE DATABASE BICICLETARIO
GO
