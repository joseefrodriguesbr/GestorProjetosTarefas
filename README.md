# Gestor de Projetos e Tarefas

# Pós-Graduação em Desenvolvimento Mobile e Cloud Computing – Inatel
## DM106 - Desenvolvimento de Web Services com segurança sob plataforma .NET

## Projeto Final

### Autor: 
José Enderson Ferreira Rodrigues   
jose.rodrigues@pg.inatel.br, jose.e.f.rodrigues.br@gmail.com

## Implementação
Gestor de Projetos e Tarefas: sistema que permite criar vários Projetos e alocar vários Empregados com suas respectivas Tarefas. 

### Funcionalidades novas: 
* **EndPoints de Identity (Autenticação) com requisição de Autorização**
* **Método de Logout na API**
* **Adição de método que lista os Empregados vinculados a um projeto**

### Funcionalidades anteriores: 
* Programa console do projeto
* Integração com ORM Entity Framework
* Classes Context e DAL de Shared.Data
* Implementação de DAL genérica
* Implementação de banco com Migrations
* Implementação da relação entre as classes (1:N) e (N:N) utilizando Migrations e Proxies
* Implementação e teste do método GET na API
* API completa com EndPoints utilizando DI.
* Documentação com Swagger.
* Configuração dos DTOs para as requests e responses da API

### Migrations disponíveis: 
* **FirsMigration** : criação das tabelas Empregado e Tarefa
* **InitialDataEntry** : geração de dados para a tabela Empregado
* **RelateEmpregadoTarefa** : inclusão de chaves ligando as tabelas Empregado e Tarefa (relação 1:N)
* **TarefaDataEntry** : geração de dados para a tabela Tarefa
* **RelateEmpregadoProjeto** : criação das tabelas Projeto e Empregado (relação N:N) com respectivas chaves de ligação 
* **IdentityTables** : criação de tabelas que suportarão a autenticação do endpoint
* **ProjetoDataEntry** : geração de dados para a tabela Projeto
* **EmpregadoProjetoDataEntry** : geração de dados para a tabela EmpregadoProjeto

### Documentação: 
https://github.com/joseefrodriguesbr/GestorProjetosTarefas

## Diagrama de classes

<img style="margin-right: 30px" src="./ClassDiagram.jpg" width="600px" alt="Diagrama de Classes"/><br>

## Recursos da Microsoft Azure criados
<img style="margin-right: 30px" src="./AzureRecursosCriados.jpg" width="1024px;" alt="Avatar"/><br>

## Recursos da Microsoft Azure excluídos após testes
<img style="margin-right: 30px" src="./AzureRecursosExcluidos.jpg" width="1024px;" alt="Avatar"/><br>

## Projetos relacionados
* https://github.com/joseefrodriguesbr/GestorProjetosTarefas/tree/Aula_1_2

* https://github.com/joseefrodriguesbr/GestorProjetosTarefas/tree/Aula_2_4

* https://github.com/joseefrodriguesbr/GestorProjetosTarefas/tree/Aula_3_2

* https://github.com/joseefrodriguesbr/GestorProjetosTarefas/tree/Aula_4_2

* https://github.com/joseefrodriguesbr/GestorProjetosTarefas/tree/master

### IDE
- **Microsoft Visual Studio Community 2022 (64 bits) - 17.13.6**
### Linguagem
- **C#**




