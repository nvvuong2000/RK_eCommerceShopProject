import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { Provider } from 'react-redux';
import * as serviceWorker from './serviceWorker';
import { createStore, applyMiddleware } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './reducers/index';
import { createBrowserHistory } from "history";
import { Router } from 'react-router';
import "react-toastify/dist/ReactToastify.css";
import history from './history';


// Note: this API requires redux@>=3.1.0
const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || typeof (compose);
const store = createStore(
  rootReducer,
  composeEnhancers(
    applyMiddleware(thunk),
  )
);
ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
        <App />  
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
