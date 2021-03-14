# Backend
É um projeto desenvolvido para um teste. Consiste na inclusão de um código backend para compor um código FrontEnd que pode ser encontrado abaixo

[Link para Frontend](https://gitlab.com/gabriel.militello1/desafio-tecnico-backend.git)

- [Ferramentas Usadas](#ferramentas-usadas)
- [Como executar](#como-executar)

## Ferramentas Usadas

- IDE de Desenvolvimento: [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/)
- Framework para desenvolvimento da API: [.Net Core 3.1](https://dotnet.microsoft.com/download/dotnet/3.1)

## Como Executar

- Abrir no terminal a pasta do projeto e executar os comandos abaixo 
  - dotnet build
  - dotnet run


    URL Base: <p><code>http://localhost:5000/</code></p>
## Erros

<p><code>200 OK</code> Tudo funcionou como esperado.</p>
<p><code>201 OK</code> O Recurso foi criado com sucesso.</p>
<p><code>400 Bad Request</code> Geralmente, um problema com os parâmetros.</p>
<p><code>404 Not Found</code> O recurso acessado não existe.</p>
<p><code>500 Server errors</code> Falha minha, algum erro no servidor.</p>

## Recursos

### Rotas

Permite fazer o login com email e senha:
URL Base: <p><code>http://localhost:5000/login</code></p>

<p><strong>Exemplo de body</strong></p>
<pre><code>
{
	"login":"seu login",
	"senha": "suaSenha"
}
</code></pre>

Permite busca todos os cards sem autenticação
<p><code>GET ANONIMO http://localhost:5000/cards/anonimo</code></p>

(POST)      http:/localhost:5000/login/<br>
(GET)       http://localhost:5000/cards/<br>
(POST)      http://localhost:5000/cards/<br>
(PUT)       http://localhost:5000/cards/{id}<br>
(DELETE)    http://localhost:5000/cards/{id}<br>


## Observações

### Difilculdades && codigo "esquisito "
Classe <b>ServiceInterceptor</b> no método <b>OnActionExecuting</b> foi usado um código que não acho ser a melhor implementação para se obter o titulo do card,pois apenas o id é recebido no parametro de context, mas funcionou.


 ```csharp
List<Card> cards = new List<Card>();
cards.AddRange(_context.cards.AsNoTracking().ToList());
var card = cards.FirstOrDefault(x => x.id.ToString() == id);
string titulo = card != null ? "- " + card.titulo : "";
