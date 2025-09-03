# 🚀 Instruções de Execução - Sistema de Gerenciamento de Livros
### Criado em 02/09/2025
### Por José Mauro da Silva
### Alterado em 03/09/2025


Este documento contém instruções detalhadas para executar tanto o backend quanto o frontend do sistema.

## 📋 Pré-requisitos

### Backend (.NET)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

### Frontend (React)
- [Node.js 18+](https://nodejs.org/)
- npm, yarn ou bun

## 🔧 Configuração do Backend

### 1. Configurar Banco de Dados

1. **Abra o SQL Server Management Studio** ou **Azure Data Studio**
2. **Conecte-se ao seu servidor SQL Server**
3. **Crie um novo banco de dados:**
   ```sql
   CREATE DATABASE Books;
   ```

### 2. Configurar String de Conexão

1. **Abra o arquivo** `GerenciamentoLivros/appsettings.Development.json`
2. **Atualize a string de conexão** com suas credenciais:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=Books;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=True"
     }
   }
   ```

### 3. Executar Migrações

1. **Abra o terminal na pasta** `GerenciamentoLivros`
2. **Execute o comando:**
   ```bash
   dotnet ef database update
   ```

### 4. Executar o Backend

1. **No terminal, execute:**
   ```bash
   dotnet run
   ```
2. **O backend estará disponível em:** `https://localhost:7001`
3. **Swagger UI estará em:** `https://localhost:7001/swagger`

## 🌐 Configuração do Frontend

### 1. Instalar Dependências

1. **Abra o terminal na pasta** `LivrosFronEnd`
2. **Execute:**
   ```bash
   npm install
   # ou
   yarn install
   # ou
   bun install
   ```

### 2. Configurar Variáveis de Ambiente

1. **Crie um arquivo** `.env.local` na raiz do projeto frontend
2. **Adicione o conteúdo:**
   ```env
   VITE_API_BASE_URL=https://localhost:7001/api/v1
   ```

### 3. Executar o Frontend

1. **No terminal, execute:**
   ```bash
   npm run dev
   # ou
   yarn dev
   # ou
   bun dev
   ```
2. **O frontend estará disponível em:** `http://localhost:5173`

## 🧪 Testando a Integração

### 1. Verificar Backend
- Acesse: `https://localhost:7001/swagger`
- Verifique se todos os endpoints estão funcionando
- Teste um endpoint GET (ex: `/api/v1/books`)

### 2. Verificar Frontend
- Acesse: `http://localhost:5173`
- Navegue para a página de Livros
- Verifique se os dados estão sendo carregados da API

### 3. Testar Operações CRUD
- **Criar:** Clique em "Novo Livro" (se implementado)
- **Ler:** Verifique se a lista está sendo carregada
- **Atualizar:** Clique no botão de editar (se implementado)
- **Deletar:** Clique no botão de excluir e confirme

## 🔍 Solução de Problemas

### Backend não inicia
- Verifique se a porta 7001 está livre
- Confirme se o .NET 8.0 está instalado
- Verifique a string de conexão do banco

### Frontend não carrega dados
- Confirme se o backend está rodando
- Verifique a URL da API no `.env.local`
- Abra o console do navegador para ver erros
- Verifique se o CORS está configurado

### Erro de CORS
- Confirme se o backend tem a política de CORS ativa
- Verifique se as origens estão corretas no `Program.cs`

### Erro de banco de dados
- Verifique se o SQL Server está rodando
- Confirme se o banco `Books` existe
- Execute as migrações: `dotnet ef database update`

## 📱 Estrutura de URLs

### Backend
- **API Base:** `https://localhost:7001/api/v1`
- **Swagger:** `https://localhost:7001/swagger`

### Frontend
- **Aplicação:** `http://localhost:5173`
- **Livros:** `http://localhost:5173/books`
- **Autores:** `http://localhost:5173/authors`
- **Gêneros:** `http://localhost:5173/genres`

## 🚀 Comandos Rápidos

### Backend
```bash
cd GerenciamentoLivros
dotnet restore
dotnet ef database update
dotnet run
```

### Frontend
```bash
cd LivrosFronEnd
npm install
npm run dev
```

## Veja mais detalhes da execução do Frontend em https://github.com/MauraoCB/LivrosFronEnd/blob/main/README.md
