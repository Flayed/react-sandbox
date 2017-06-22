import {combineReducers} from 'redux';
import query from './query';
import cityStates from './cityStates';

export default combineReducers({query, cityStates});