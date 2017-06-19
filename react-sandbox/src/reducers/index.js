import { combineReducers } from 'redux';
import consumed from './consumed';
import message from './message';
import legendaryStatus from './legendaryStatus';
import mapSearch from './mapSearch';

const appReducer = combineReducers({consumed, message, legendaryStatus, mapSearch});

export default appReducer;