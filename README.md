# Exemplo criado apartir do framework de criação de projetos React

# 1 . Instruções para rodar

# 1 . 1 Pré requisitos
    - SQL SERVER
    - node versão >=10
    - dotnet sdk versão 9
    - dotnet runtime versão 9
    - executar navegador com CORS security desabilitado Ex Chrome.: "C:\Program Files\Google\Chrome\Application\chrome.exe" --disable-web-security  --user-data-dir="C:\temp"


# 1 . 2 Para rodar o front
    Verificar o caminho do backend e colocar o apontamento correto em src\constants\apiConstants.js na constante API_BASE_URL.
    É necessário instalar as bibliotecas react com o comando "npm install".
    Após é só executar normalmente "npm run start".

# 1 . 3 Para rodar o backend
    Basta executar "npm run backend"

# 1 . 3 Interação
    No navegador, digitar http://localhost:3000/
    Haverá a tela de login e o botão de register, caso queira cadastrar o usuario e senha
    Em caso de login positivo, redireciona para a página de home
    Em caso de erro, simplesmente mostra a mensagem

# 1 . 4 Considerações
    - Foi criado com padrão de arquitetura Service Pattern e o Repository Pattern
    - É utilizado injeção de dependência
    - É utilizado validação por JWT Token bearer
    - A aplicação poderia ser mais elaborada, mas foi focada na demonstração das habilidades:
        - Uso de CRUD em Rest/API
        - Codificação em React
        - Codificação com arquiteturas em C#
        - Autenticação e Autorização

        Poderia aplicar mais algumas boas práticas como : 
        - Desgin pattern mediator
        - Uso de bancos de cache, como Redis
        - Mais logs em pontos estratégicos


# Getting Started with Create React App

This project was bootstrapped with [Create React App](https://github.com/facebook/create-react-app).

## Available Scripts

In the project directory, you can run:

### `npm start`

Runs the app in the development mode.\
Open [http://localhost:3000](http://localhost:3000) to view it in your browser.

The page will reload when you make changes.\
You may also see any lint errors in the console.

### `npm test`

Launches the test runner in the interactive watch mode.\
See the section about [running tests](https://facebook.github.io/create-react-app/docs/running-tests) for more information.

### `npm run build`

Builds the app for production to the `build` folder.\
It correctly bundles React in production mode and optimizes the build for the best performance.

The build is minified and the filenames include the hashes.\
Your app is ready to be deployed!

See the section about [deployment](https://facebook.github.io/create-react-app/docs/deployment) for more information.

### `npm run eject`

**Note: this is a one-way operation. Once you `eject`, you can't go back!**

If you aren't satisfied with the build tool and configuration choices, you can `eject` at any time. This command will remove the single build dependency from your project.

Instead, it will copy all the configuration files and the transitive dependencies (webpack, Babel, ESLint, etc) right into your project so you have full control over them. All of the commands except `eject` will still work, but they will point to the copied scripts so you can tweak them. At this point you're on your own.

You don't have to ever use `eject`. The curated feature set is suitable for small and middle deployments, and you shouldn't feel obligated to use this feature. However we understand that this tool wouldn't be useful if you couldn't customize it when you are ready for it.

## Learn More

You can learn more in the [Create React App documentation](https://facebook.github.io/create-react-app/docs/getting-started).

To learn React, check out the [React documentation](https://reactjs.org/).

### Code Splitting

This section has moved here: [https://facebook.github.io/create-react-app/docs/code-splitting](https://facebook.github.io/create-react-app/docs/code-splitting)

### Analyzing the Bundle Size

This section has moved here: [https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size](https://facebook.github.io/create-react-app/docs/analyzing-the-bundle-size)

### Making a Progressive Web App

This section has moved here: [https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app](https://facebook.github.io/create-react-app/docs/making-a-progressive-web-app)

### Advanced Configuration

This section has moved here: [https://facebook.github.io/create-react-app/docs/advanced-configuration](https://facebook.github.io/create-react-app/docs/advanced-configuration)

### Deployment

This section has moved here: [https://facebook.github.io/create-react-app/docs/deployment](https://facebook.github.io/create-react-app/docs/deployment)

### `npm run build` fails to minify

This section has moved here: [https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify](https://facebook.github.io/create-react-app/docs/troubleshooting#npm-run-build-fails-to-minify)



