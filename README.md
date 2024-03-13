# Projeto de Objetivos Financeiros

## Tecnologias Utilizadas
- AspNet.Core( .NET 8 )
- Arquitetura Limpa
- MediatR
- Transações
- IUnitOfWork
- Entity Framework Core
- CQRS
- Padrao Repository

#### Desenvolver uma API para controle de Objetivos financeiros.

1. Gestão de caixa (cadastro, atualização, remoção, listagem, detalhes)
   - Criar um endpoint que permite simular a evolução do Cash, com base no valor das contribuições mensais e rendimentos (PLUS)
   - Crie um endpoint que permita fazer upload de um arquivo de imagem de meta/capa de caixa (PLUS)
   - Crie uma propriedade para o valor total da Caixa sempre calculado ao registrar novas transações, ao invés de sempre somar tudo na busca por detalhes (PLUS) Dica: use transação
2. Gerenciamento de transações (registro, remoção, listagem, detalhes)
3. Relatórios
   - Gerar relatório de evolução das Caixas (PLUS)

#### Regras de negócios aplicada

- A transação deverá ser realizada com até duas casas decimais de precisão, não podendo ser negativa
- Tipo: Depósito / Retirada
