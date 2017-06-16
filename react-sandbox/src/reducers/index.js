import { combineReducers } from 'redux';
import consumed from './consumed';
import message from './message';
import legendaryStatus from './legendaryStatus';

const appReducer = combineReducers({consumed, message, legendaryStatus});

export default appReducer;