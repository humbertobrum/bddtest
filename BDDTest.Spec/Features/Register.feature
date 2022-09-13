
Feature: Register

@mytag
Scenario: Mostrar erro de validação ao registrar
	Given Navegou para a página de cadastro
	And preencheu os dados do formulário
	When clicar no botão de criar conta
	Then mostrou erros de validação