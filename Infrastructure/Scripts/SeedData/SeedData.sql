-- =============================================
-- Versão: 1.0.0
-- Data: 2023-10-30
-- Autor: Rafael Ventura
-- Descrição: Inserção de dados iniciais na tabela Bicicletas
-- =============================================

USE BICICLETARIO
GO

-- Inserindo dados na tabela Bicicletas
INSERT INTO dbo.Bicicletas (Marca, Modelo, Cor)
VALUES
    ('Caloi', 'Caloi 10', 'Vermelha'),
    ('Caloi', 'Caloi 100', 'Azul'),
    ('Trek', 'Marlin 5', 'Preta'),
    ('Giant', 'Talon 3', 'Verde'),
    ('Specialized', 'Rockhopper', 'Branca'),
    ('Scott', 'Aspect 950', 'Amarela'),
    ('Cannondale', 'Trail 8', 'Cinza'),
    ('Merida', 'Big Nine 20-D', 'Laranja'),
    ('GT', 'Aggressor Expert', 'Rosa'),
    ('Orbea', 'MX 50', 'Violeta'),
    ('Bianchi', 'Kuma 29.1', 'Dourada'),
    ('KHS', 'SixFifty 500', 'Prata');
GO
