import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';
import { createStore } from 'redux';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
import './index.css';
import appReducer from './reducers/index';

registerServiceWorker();

let store = createStore(appReducer);

ReactDOM.render(
<Provider store={store}>
<App />
</Provider>, document.getElementById('root'));
