export const types = {
    SEARCH: 'QUERY/SEARCH'
}

export const initialState = {
    text: ''
};

export default (state=initialState, action)=> {
    switch (action.type) {
        case types.SEARCH:
            return {...state, text: action.text};    
        default: return state;
    }
}

export const actions = {
    search: (text) => { return {type:types.SEARCH, text:text}; }
};