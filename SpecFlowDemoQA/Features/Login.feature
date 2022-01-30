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
