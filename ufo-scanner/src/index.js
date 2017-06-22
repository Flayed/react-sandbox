import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore, applyMiddleware } from 'redux';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import './index.css';
import appReducer from './reducers/index';
import thunkMiddleware from 'redux-thunk';

registerServiceWorker();

let store = createStore(appReducer, applyMiddleware(thunkMiddleware));

ReactDOM.render(
<Provider store={store}>
<App />
</Provider>, document.getElementById('root'));
