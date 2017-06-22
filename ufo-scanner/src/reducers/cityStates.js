import fetch from 'isomorphic-fetch';

const ufoService = "http://thetruthisoutthere.azurewebsites.net/API/Ufo/";

export const types = {
    REQUEST_STATES: 'CITYSTATE/REQUEST_STATES',
    RECEIVE_STATES: 'CITYSTATE/RECEIVE_STATES',
    SELECT_STATE: 'CITYSTATE/SELECT_STATE',
}

export const initialState = {
    states: [],
    isFetchingStates: false,
    selectedState: ''
};

export default (state=initialState, action)=> {
    switch (action.type) {
        case types.REQUEST_STATES:
            return {...state, isFetchingStates: true};
        case types.RECEIVE_STATES:
            return {...state, states: action.states, isFetchingStates: false};
        case types.SELECT_STATE:
            return {...state, selectedState: action.selectedState};
        default: return state;
    }
}

export const actions = {
    fetchStates: fetchStates,
    selectState: (selectedState) => {return {type: types.SELECT_STATE, selectedState: selectedState}},
};

export function fetchStates() {    
    return (dispatch, getState) => {
        // do not fetch again if we are in the middle of fetching or have already fetched
        if (getState().cityStates.states.length > 0 || getState().cityStates.isFetchingStates) {
            return Promise.resolve();
        }
        dispatch({type: types.REQUEST_STATES});            
        return fetch(ufoService + 'MissingPersonStates/')
        .then(response => {
            return response.json();    
        },
        error => console.log('Oh no!', error)
        ).then(json => {
            dispatch({type: types.RECEIVE_STATES, states: json});
        })
    };
}