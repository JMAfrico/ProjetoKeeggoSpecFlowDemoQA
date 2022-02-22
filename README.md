# Projeto Keeggo - SpecFlow DemoQA

## Projeto realizado como parte dos requisitos de estudos da Keeggo, onde foi realizados os testes automáticos do site https://demoqa.com/books.

># Testes realizados: 

- Cadastro de usuário<br>
- Login de usuário<br> 
- Adicionar livro no carrinho<br>
- Remover livro no carrinho<br>

># Tecnologias utilizadas: 

- Linguagem de programação C#<br>
- IDE Visual Studio 2022<br> 
- Xunit<br>
- SpecFlow<br>

>### Dependências instaladas:
- Csv Helper - Para a criação da massa de dados<br>
- Itext7- Para criação das eviências de testes<br>
- Selenium WebDriver- Para instância de novo driver<br>
- Selenium WebDriver Chrome Driver- Para instância de novo driver do navegador Google Chrome<br>
- Selenium Support<br>
- xunit - Para testes unitários<br>
- xunit.runner.visualstudio - Runner para execução dos testes<br>
- SpecFlow.Xunit<br>


>### Extensões instaladas:
- SpecFlow for Visual Studio 2022<br>

>### Divisão dos pacotes:
- Features - Para a escrita dos cenários de testes
- Steps - Métodos que representam os passos do cenário de testes
- Page - Classes que armazenam os elementos da página 
- Logic - Métodos que implementam a lógica e interação com os elementos da página
- Helpers - Classes de auxilio para inicialização do Driver e para leitura dos dados
- Utils - Classes que auxiliam a criação das evidências dos testes.
- Evidences - Armazenamento das evidências dos testes
- Dados - Arquivos em formato CSV onde ficam armazenados os dados das massas.
