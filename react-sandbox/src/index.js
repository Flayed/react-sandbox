import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import appReducer from './reducers/index';
import App from './App';
import registerServiceWorker from './registerServiceWorker';

registerServiceWorker();

let pancakeStore = createStore(appReducer);
ReactDOM.render(
    <Provider store={pancakeStore}>
      <App />
    </Provider>
  , document.getElementById('root'));