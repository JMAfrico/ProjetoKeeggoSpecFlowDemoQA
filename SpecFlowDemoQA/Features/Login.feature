#language: pt-br

Funcionalidade: Login
Como usuario do site, quero me cadastrar para efetuar compras de livros

@login_valido
Cenario: Login com dados validos

Dado que navego para pagina inicial
Quando clico em login
E preencho usuario valido de login
E preencho senha valida de login
E clico em login
Então valido que estou logado no site

@login_invalido
Cenario: Login com dados invalidos

Dado que navego para pagina inicial
Quando clico em login
E preencho usuario invalido de login
E preencho senha invalida de login
E clico em login
Então valido que nao estou logado no site

@cadastro_valido
Cenario: Cadastro com dados validos

Dado que navego para pagina inicial
Quando clico em login
E clico em novo usuario de login
E preencho o campo primeiro nome de novo usuario
E preencho o campo ultimo nome de novo usuario
E preencho o campo usuario de novo usuario
E preencho o campo senha de novo usuario
E clico na opcao nao sou um robo
E clico em registrar
Então valido a mensagem de usuario cadastrado

@cadastro_invalido
Cenario: Cadastro com dados invalidos

Dado que navego para pagina inicial
Quando clico em login
E clico em novo usuario de login
E preencho o campo primeiro nome de novo usuario
E preencho o campo ultimo nome de novo usuario
E preencho o campo usuario de novo usuario
E preencho o campo senha de novo usuario
E clico na opcao nao sou um robo
E clico em registrar
Então valido a mensagem de erro ao efetuar cadastro

@cadastro_invalido_usuario_ja_existe
Cenario: Cadastro com dados invalidos usuario ja existe

Dado que navego para pagina inicial
Quando clico em login
E clico em novo usuario de login
E preencho o campo primeiro nome de novo usuario
E preencho o campo ultimo nome de novo usuario
E preencho o campo usuario de novo usuario
E preencho o campo senha de novo usuario
E clico na opcao nao sou um robo
E clico em registrar
Então valido a mensagem de usuario existente