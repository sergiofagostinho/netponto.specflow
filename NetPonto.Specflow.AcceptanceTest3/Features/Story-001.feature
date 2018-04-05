#language: pt-PT
Funcionalidade: História 001 - Enviar a amigo
	Quando preencho o formulário de enviar a amigo, é enviado um email

@priority1
Esquema do Cenário: Preencher formulário de enviar a amigo envia email
	Dado que estou no formulário "enviar a amigo"
		E preenchi os campos com o nome "Sergio" e endereço "<email>"
	Quando carrego no botão “enviar”
	Então um email é enviado para o meu amigo

Exemplos: 
| email                  |
| paulo.iap@gmail.com    |
| seesharptec@gmail.com  |
| jorgesalitre@gmail.com |

Esquema do Cenário: Preencher formulário de enviar a amigo não envia email
	Dado que estou no formulário "enviar a amigo"
		E preenchi os campos com o nome "<nome>" e endereço "<email>"
	Quando carrego no botão “enviar”
	Então é mostrada uma mensagem de erro com o texto "<erro>"
		E nenhum email é enviado para o meu amigo

Exemplos: 
| nome             | email                      | erro                                    |
|                  |                            | Os campos são obrigatórios!             |
| Eu               |                            | Os campos são obrigatórios!             |
|                  | foo@bar.com                | Os campos são obrigatórios!             |
| Z                | piap@gmail.com             | 2 a 24 letras, sem números nem símbolos |
| Sérgio81         | csharptek@gmail.com        | 2 a 24 letras, sem números nem símbolos |
| _darkoolfxper666 | darksalt@gmail.com         | 2 a 24 letras, sem números nem símbolos |
| José Povinho     | foo                        | o endereço de email não é válido        |
| John Doe         | csharptek_at_gmail.com     | o endereço de email não é válido        |
