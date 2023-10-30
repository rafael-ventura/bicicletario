# Scripts SQL do Projeto Bicicletario

## Sobre o Versionamento

Cada script SQL contém um cabeçalho de comentário que fornece informações sobre a versão, data, autor e uma descrição do que o script faz. Este cabeçalho segue o seguinte formato:


```sql
-- =============================================
-- Autor: [Nome do Autor]
-- Data de Criação: [Data, formato: DD/MM/YYYY]
-- Descrição: [Breve descrição do script]
-- Versão: [Número da versão, formato: V01, V02, ...]
-- =============================================
```

## Como Atualizar o Versionamento

Ao criar ou modificar um script:

1. Atualize a seção "Autor" com o seu nome ou alias.
2. Atualize a seção "Data de Criação" com a data atual.
3. Forneça uma breve descrição do script ou das mudanças na seção "Descrição".
4. Incrementar o número da versão na seção "Versão". Por exemplo, se o script anterior era V01, o novo deve ser V02, e assim por diante.

## Estrutura de Pastas

Os scripts estão organizados em pastas dentro do diretório `Infrastructure/Scripts`:

- `DatabaseCreation`: Contém scripts para criação do banco de dados e suas tabelas
- `SeedData`: Contém scripts para inserção de dados iniciais nas tabelas.