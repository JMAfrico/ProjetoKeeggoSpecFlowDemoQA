#language: pt-br

Funcionalidade: Carrinho
//como cliente cadastrado quero ver meu carrinho de compras

@adicionar_item
Esquema do Cenario: adicionando item no carrinho

Dado que navego para pagina inicial
Quando clico em login
E preencho usuario valido de login
E preencho senha valida de login
E clico em login
E digito o nome do livro <livro> 
E clico no livro
E clico em adicionar a minha colecao
Entao valido livro adicionado ao carrinho


Exemplos: 
 | livro               |
 | Speaking JavaScript |


@remover_item
Cenario: remover item no carrinho

Dado que navego para pagina inicial
Quando clico em login
E preencho usuario valido de login
E preencho senha valida de login
E clico em login
E clico em Profile
E digito o nome do livro <livro> 
E clico em remover livro
E clico em confirmar de remover livro
Entao valido livro removido do carrinho


Exemplos: 
 | livro               |
 | Speaking JavaScript |