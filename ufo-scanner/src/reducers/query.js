import fetch from 'isomorphic-fetch';
import {types as cityStateTypes} from './cityStates';

const ufoService = "http://thetruthisoutthere.azurewebsites.net/API/Ufo/";
//const ufoService = "http://localhost/Ufo/API/Ufo/";

export const types = {
    SEARCH: 'QUERY/SEARCH',
    REQUEST_CITIES: 'QUERY/REQUEST_CITIES',
    RECEIVE_CITIES: 'QUERY/RECEIVE_CITIES',
    SELECT_CITY: 'QUERY/SELECT_CITY',
    REQUEST_ABDUCTIONS: 'QUERY/REQUEST_ABDUCTIONS',
    RECEIVE_ABDUCTIONS: 'QUERY/RECEIVE_ABDUCTIONS',
    TOGGLE_INFOCARD: 'QUERY/TOGGLE_INFOCARD'
}

export const initialState = {
    text: '',
    cities: [],
    isFetchingCities: false,
    selectedCity: '',
    abductions: [],
    isFetchingAbductions: false
};

export default (state=initialState, action)=> {
    switch (action.type) {
        case types.SEARCH:
            return {...state, text: action.text};
        case types.REQUEST_CITIES:
            return {...state, isFetchingCities: true};
        case types.RECEIVE_CITIES:
            return {...state, cities: action.cities, isFetchingCities: false};  
        case types.SELECT_CITY:
            return {...state, selectedCity: action.selectedCity};
        case types.REQUEST_ABDUCTIONS:
            return {...state, isFetchingAbductions: true, abductions: [] };
        case types.RECEIVE_ABDUCTIONS:
            return {...state, abductions: action.abductions.map(abduction => {return {...abduction, visible: false};}), isFetchingAbductions: false };
        case types.TOGGLE_INFOCARD:
            return {...state, abductions: state.abductions.map(abduction => { 
                    if (abduction.Id !== action.id) return abduction;
                    return {...abduction, visible: !abduction.visible};
                })};
        // CityState events
        case cityStateTypes.SELECT_STATE:
            return {...state, selectedCity: ''}
        default: return state;
    }
}

export const actions = {
    search: (text) => { return {type:types.SEARCH, text:text}; },        
    fetchCities: fetchCities,
    selectCity: (selectedCity) => {return {type: types.SELECT_CITY, selectedCity: selectedCity}},
    fetchAbductions: fetchAbductions,
    toggleInfocard: (abductionId) => {return {type: types.TOGGLE_INFOCARD, id: abductionId}}
};

export function fetchCities(cityState) {
    return (dispatch, getState) => {
        if (getState().query.isFetchingCities){
            return Promise.resolve();
        }
        dispatch({type: types.REQUEST_CITIES, cityState: cityState});
        return fetch(ufoService + 'MissingPersonCities/' + cityState +'/')
        .then(response => {
            return response.json();
        },
        error => console.log('oh, no!', error)
        ).then(json => {
            dispatch({type: types.RECEIVE_CITIES, cities: json});
        })
    };
}

export function fetchAbductions(cityState, city) {
    return (dispatch, getState) => {
        var qs = '/' + cityState.trim();
        if (city && city.length > 0) qs += '/' + city.trim();
        dispatch({type: types.REQUEST_ABDUCTIONS, cityState: cityState, city: city});
        return fetch(ufoService + 'MissingPersons' + qs + '/')
        .then(response => {            
            return response.json();
        },
        error => console.log('oh, no!', error)
        ).then(json => {            
            dispatch({type: types.RECEIVE_ABDUCTIONS, abductions: json});
        })
    };
}