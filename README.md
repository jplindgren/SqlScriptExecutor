SqlScriptExecutor
=================


Insert your scripts in your project as embedded resources, call the function ExecutScripts in the class MysqlScriptExecutor passing ConnectionString of your target database and the full name of the scripts. Your script will be executed. 
I use mostly in integration tests when i need to set pre-defined data in my database and cleanup it after the tests.


Insira seus scripts no projeto como embedded resource, chame a função ExecutScripts na classe MysqlScriptExecutor passando a connection string do banco onde os scripts devam ser executados e o nome completo onde os scripts se encontram. Seus scripts serão executados na ordem em que foram passados.
Eu uso basicamente em testes de integração, inserindo por exemplos dados para preparar o banco e ao fim dos testes executando outros scripts de limpeza.


For now only works with Mysql Scripts...

Por enquanto apenas scripts Mysql...
