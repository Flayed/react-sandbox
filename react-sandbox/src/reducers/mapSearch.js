export const types = {
    SEARCH: "MAP/SEARCH"
}

export const initialState = {
    searchText: '',
    searchHistory: []
};

export default (state=initialState, action)=> {
  switch (action.type){    
      case types.SEARCH:
        var idx = state.searchHistory.indexOf(action.searchText);        
        var searchHistory = idx >= 0 
        ? [action.searchText, ...state.searchHistory.slice(0, idx), ...state.searchHistory.slice(idx+1, state.searchHistory.length)]
        : [action.searchText, ...state.searchHistory];
        return {...state, searchText: action.searchText, searchHistory: searchHistory};
    default: return state;
  }
}

export const actions = {
    search: (searchText) => { return { type:types.SEARCH, searchText: searchText }}
};