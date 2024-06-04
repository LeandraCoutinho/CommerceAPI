# CommerceAPI
Esse projeto consiste em uma API Rest responsável por cadastrar pessoas, produtos e compras.

## Funcionalidades:
- CRUD pessoa.
- CRUD produto.
- CRUD compras.
- Listar as compras de cada pessoa de acordo com o documento.
- Paginação dos usuários existentes.
- Ordenação dos dados cadastrados.
- Token de autenticação.
- Salva imagens tanto via base64 e quanto url.
- Atribui permissões ao usuário.
- Permissões: 'CdastroPessoa', 'BuscaPessoa', 'EditaPessoa', 'DeletaPessoa'.

## Tecnologias usadas:
- C#
- .NET 6
- Entity Framerwork Core 6
- MySQL
- AutoMapper
- FluentValidation

### Um pouco mais sobre CommerceAPI:
  - PersonController está como Admin e só tem a permissão de 'BuscaPessoa' e 'EditaPessoa' (Fique a vontade para atribuir as permissões que dejesa).
  - Todas as rotas exigem autorização por meio do token.

