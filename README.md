# Aplicação Copa de Filmes

Projeto de exemplo de uma copa do mundo de filmes.
Projeto composto por uma aplicação Angular 8 e API .NET Core 2.2.

## Código-fonte
Para ter acesso ao código-fonte do projeto, clone o repositório

    git clone https://github.com/chpsousa/CopaFilmes.git
    
ou [clique aqui](https://github.com/chpsousa/CopaFilmes/archive/master.zip) para baixar o código-fonte em um arquivo .zip.

## Aplicação
O projeto Angular 8 conta com dois componentes principais componentes: MoviesSelection e MoviesResult.
O componente MoviesSelection é responsável pela seleção dos filmes que vão participar do campeonato, e o MoviesResult é o componente que irá mostrar o resultado do campeonato.

### Execução
Para executar a aplicação Angular:
- Clone o repositório;
- Acesse o diretório copafilmes-front, utilizando seu prompt de comando.
- Execute o comando `ng s`

## API
A API foi criada utilizando o padrão RESTful.
Ela conta com uma controller chamada Movies.

### Execução
Para executar a API:
- Clone o repositório;
- Acesse o diretório do projeto CopaFilmes.API, utilizando seu prompt de comando.
- Execute o comando `dotnet run`

ou 
- Abra a Solution CopaFilmes.sln
- Selecione o projeto CopaFilmes.API
- Pressione a tecla F5.

### [GET]

Enviando uma requisição do tipo GET para a [API](http://copadefilmes.azurewebsites.net/api/movies) ela irá retornar todos os filmes.

### [POST]

Ao enviar uma requisição do tipo POST para a [API](http://copadefilmes.azurewebsites.net/api/movies), com um objeto JSON como corpo da requisição contendo um array de 8 filmes, ela irá executar o campeonato de filmes.
Caso o corpo da requisição seja inválido, ela irá retornar o código 500.

Exemplo de corpo de requisição:

`{ "Movies" :[
  {
    "id": "tt3606756",
    "titulo": "Os Incríveis 2",
    "ano": 2018,
    "nota": 8.5
  },
  {
    "id": "tt4881806",
    "titulo": "Jurassic World: Reino Ameaçado",
    "ano": 2018,
    "nota": 6.7
  },
  {
    "id": "tt5164214",
    "titulo": "Oito Mulheres e um Segredo",
    "ano": 2018,
    "nota": 6.3
  },
  {
    "id": "tt7784604",
    "titulo": "Hereditário",
    "ano": 2018,
    "nota": 7.8
  },
  {
    "id": "tt4154756",
    "titulo": "Vingadores: Guerra Infinita",
    "ano": 2018,
    "nota": 8.8
  },
  {
    "id": "tt5463162",
    "titulo": "Deadpool 2",
    "ano": 2018,
    "nota": 8.1
  },
  {
    "id": "tt3778644",
    "titulo": "Han Solo: Uma História Star Wars",
    "ano": 2018,
    "nota": 7.2
  },
  {
    "id": "tt3501632",
    "titulo": "Thor: Ragnarok",
    "ano": 2017,
    "nota": 7.9
  }
]}`

## Testes
O projeto conta com testes de unidade automatizados.
Para executar os testes:

- Clone o repositório
- Acesse o diretório do projeto de testes, CopaFilmes.Tests que está dentro de copafilmes-backend.
- Execute o comando `dotnet test` com seu prompt de comando.

ou

- Abra a Solution CopaFilmes.sln com o Visual Studio.
- Clique com o botão direito sobre o projeto CopaFilmes.Tests
- Clique sobre a opção Run tests.

## Autor
Carlos Henrique Prado Sousa - [Linkedin](https://www.linkedin.com/in/chpsousa/)
