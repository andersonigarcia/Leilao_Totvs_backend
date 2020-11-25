# Leilao_Totvs_backend
Aplicação modelo utilizando CQRS, .Net Core 3.1, Sql server.

Aplicação modelo utilizando .Net Core 3.1, Sql Server e o partners CQRS.

Objetivo:
Criar uma API simples utilizando CQRA em .Net Core 3.1 para acessar um banco de dados sql server. 
Utilizei code first para criação do modelo e da base de dados.

Segue o exemplo de escopo utilizado para criação da interface.


Login:
Função: autenticação na aplicação para acesso às funcionalidades
Campos: usuário, senha
Restrições:
Todos os campos são obrigatórios.
Usuários desativados não poderão acessar o sistema.

Logout:
Função: logoff da aplicação
Restrições:
Nenhum serviço pode ser acessado após o logout da aplicação.

Cadastro de leilão (CRUD):
Função: Cadastrar/Visualizar/Editar e Excluir novos leilões.
Campos: nome do leilão, valor inicial, indicador se o item leiloado é "usado", usuário responsável pelo leilão, data de abertura e finalização.
Restrições:
Todos os campos são obrigatórios.
Listagem de leilões


Função: Listar todos os leilões existentes.
Campos: nome do leilão, valor inicial, indicador se o item leiloado é "usado" e usuário responsável pelo leilão, indicador se o leilão está foi finalizado"


Como executar:
1) Clonar o projeto via visual studio 2019.
2) Ter uma instância do sql server rodando e acessível;
3) Configurar a string de conexão de acordo com o banco de dados;
4) Rodar a migration
5) Rodar o projeto normalmente pelo visual studio 2019 (F5)


Os testes poderão ser feitos pelo swagger, postman ou qualquer outra ferramenta que desejar.
