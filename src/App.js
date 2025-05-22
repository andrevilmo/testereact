import React, { useState } from 'react';
import './App.css';
import Header from './components/Header/Header';
import LoginForm from './components/LoginForm/LoginForm';
import RegistrationForm from './components/RegistrationForm/RegistrationForm';
import Home from './components/Home/Home';
import PrivateRoute from './utils/PrivateRoute';
import {
  Router,
  Switch,
  Route
} from "react-router-dom";
import AlertComponent from './components/AlertComponent/AlertComponent';
function App() {
  const [title, updateTitle] = useState(null);
  const [errorMessage, updateErrorMessage] = useState(null);
  const MyContext = React.createContext("NAV_");
  var createBrowserHistory = require("history").createBrowserHistory;
  const history = createBrowserHistory();
  const contextType = MyContext;
  let browseTo = function (somepath) {
    console.log('REDIRECIONA PARA ' + somepath)
    history.push({ pathname: somepath })
  }
  return (

    <MyContext.Provider value="dark">
      <Router history={history}>
        <div className="App">
          <Header title={title}  browseTo={browseTo} />
          <div className="container d-flex align-items-center flex-column">
            <Switch>
              <Route path="/" exact={true}>
                <LoginForm history={history} browseTo={browseTo} showError={updateErrorMessage} updateTitle={updateTitle} />
              </Route>
              <Route path="/register" exact={true}>
                <RegistrationForm history={history} browseTo={browseTo} showError={updateErrorMessage} updateTitle={updateTitle} />
              </Route>
              <Route path="/login" exact={true}>
                <LoginForm history={history} browseTo={browseTo} showError={updateErrorMessage} updateTitle={updateTitle} />
              </Route>
              <PrivateRoute path="/home" exact={true}>
                <Home history={history} browseTo={browseTo} />
              </PrivateRoute>
            </Switch>
            <AlertComponent errorMessage={errorMessage} hideError={updateErrorMessage} />
          </div>
        </div>
      </Router>
    </MyContext.Provider>
  );
}

export default App;