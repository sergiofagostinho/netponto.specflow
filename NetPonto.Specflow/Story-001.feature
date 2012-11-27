#language: pt-PT
Funcionalidade: História 001 - Enviar a amigo
	Quando preencho o formulário de enviar a amigo, é enviado um email

Cenário: Preencher formulário de enviar a amigo envia email
	Dado que estou no formulário "enviar email a amigo"
		E preenchi os campos
	Quando carrego no botão “enviar”
	Então um email é enviado para o meu amigo
