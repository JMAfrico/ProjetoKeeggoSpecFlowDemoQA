#language: pt-br

Funcionalidade: Login

@login_valido
Cenario: Login com dados validos

Dado que estou no site
Quando clico em login
E preencho usuario valido de login
E preencho senha valida de login
E clico em login
Então valido que estou logado no site
