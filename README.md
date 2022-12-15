# Boas vindas ao repositório do Tryitter 🐦

## O que foi desenvolvido 👩‍💻

O `Tryitter` é uma rede social, totalmente baseada em texto. Cujo objetivo é proporcionar **um ambiente em que as pessoas estudantes poderão** por meio de textos e imagens **compartilhar suas experiências** e também acessar posts que possam contribuir para seu aprendizado.

## Arquitetura 🧩

A arquitetura inicial foi definida da seguinte forma:

<img src="https://content-assets.betrybe.com/prod/Arquitetura%20do%20Tema%201.jpeg" />

Conforme visto na imagem acima, haverá um **Front-End** que será responsável por interagir com as pessoas estudantes e mandar as muitas requisições para o **Back-End**, que, por sua vez, será responsável por manter as informações atualizadas em um banco de dados MySQL Server usando o Framework Entity.

## Funcionalidades 📱

1. Implementar um C.R.U.D. para as contas de pessoas estudantes;
2. Implementar um C.R.U.D. para um post de uma pessoa estudante;
3. Alterar um post depois de publicado.


## Desenvolvimento 🎯

Nessa rede social, **as pessoas estudantes devem conseguir** `se cadastrar com nome, e-mail, módulo atual que estão estudando na Trybe, status personalizado e senha para se autenticar`. Deve ser possível também `alterar essa conta a qualquer momento, desde que a pessoa usuária esteja autenticada.`

Uma pessoa estudante deve poder também `publicar posts em seu perfil, que poderão conter texto com até 300 caracteres e arquivos de imagem, além de conseguir pesquisar outras contas por nome e optar por listar todos seus posts.

## Métodos
Requisições para a API seguem os padrões:
| Método | Descrição |
|---|---|
| `GET` | Retorna informações de um ou mais registros. |
| `POST` | Utilizado para criar um novo registro. |
| `PUT` | Utilizado para atualiza as propriedades. |
| `DELETE` | Utilizado para deletar um registro. |

## Respostas
| Código | Descrição |
|---|---|
| `200` | Requisição executada com sucesso.|
| `201` | Novo recurso criado. |
| `400` | Erros de validação ou os campos informados não existem no sistema.|
| `401` | Dados de acesso inválidos.|
| `500` | Erro interno do servidor.|


## Linguagem utilizada 🛠

<img title="CSharp" alt="CSharp" height="80" width="80" src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" />  


## Instalando depedências 🔽

1. Faça um clone deste repositório com:

```git clone git@github.com:julialanapatto/tryitter.git``` 

2. Siga para o diretório:
```cd Tryitter.csproj ```

3. Restaure as dependências:
```dotnet restore```

4. Rode o serviço db com o comando:
```docker-compose up```

5. Atualize o banco de dados:
```dotnet ef database update```

6. Rode a aplicação:
```dotnet run```

7.Após rodar a aplicação, você deverá acessar através de:
https://localhost:7292/swagger/index.html


## Executando os testes de integração 🧪
Para rodas os testes:
```dotnet test```


## Documentação da API 📒

Para visualização do funcionamento da API, disponibilizamos os vídeos de funcionamento das rotas via Swagger, estão na seguinte pasta: /src/Tryyitter/docs ou acompanhe a execução da aplicação a seguir:

## Executando a aplicação 🖥

## Considerações durante o desenvolvimento 📝
Video 1: Método POST Student e obtenção do token para autorização e seu retorno no GET Student.

https://user-images.githubusercontent.com/90054523/207755996-2878a45e-e99b-4145-b807-ac5cf16db397.mp4


Vídeo 2: Método GET, PUT e DELETE Student por Id do estudante e seu retorno no GET Student.

https://user-images.githubusercontent.com/90054523/207756003-c35de942-d9c2-4347-b920-6bbf370fffd8.mp4

Vídeo 3: Autorização e método POST Post e seu retorno no GET Post.

https://user-images.githubusercontent.com/90054523/207756013-25e27d17-e47d-421e-888b-c84a342dac4c.mp4

Vídeo 4: Método PUT Post.

https://user-images.githubusercontent.com/90054523/207756030-5a14f75a-76b8-4c99-90be-bdcf2bb5d254.mp4

Vídeo 5: Método DELETE Post.

https://user-images.githubusercontent.com/90054523/207756045-3fbb1932-2db0-4a4b-abf1-08027802605f.mp4

Vídeo 6: Método GET Post por Id do Estudante.

https://user-images.githubusercontent.com/90054523/207756063-eba516d7-a725-49fe-a52f-6899d83a1a5e.mp4



## Considerações Finais

Obrigada por terem nos acompanhado até aqui.

Estamos disponíveis para feedbacks sobre melhorias no projeto e também para parcerias em novos desenvolvimentos.
