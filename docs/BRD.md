# BRD – Documento de Requisitos de Negócio
## Projeto: Sistema de Aluguel de Kitnets

### Visão Geral

O sistema apoia o proprietário/administradora na gestão de kitnets para locação, permitindo:

* Cadastro de unidades
* Cadastro de locatários
* Gestão de contratos
* Registro de pagamentos
* Consulta de inadimplência

### Problemas de Negócio

* Controle manual em planilhas/papel
* Risco de perda de informações
* Baixa visibilidade da inadimplência
* Falta de padronização de cadastros

### Objetivos

* Centralizar informações das locações
* Aumentar controle de pagamentos
* Facilitar emissão de relatórios simples
* Preparar base para futuro front end

### Regras de Negócio Principais

1. Cada kitnet pode ter no máximo um contrato ativo.
2. Locatário pode ter vários contratos, mas não mais de um ativo para a mesma unidade.
3. Pagamento sempre pertence a um contrato e a uma competência (mês/ano).
4. Não é permitido excluir kitnet ou locatário com contrato ativo.
5. Apenas usuários autenticados podem alterar dados.
