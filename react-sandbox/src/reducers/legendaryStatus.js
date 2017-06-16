export const types = {
  QUESTION_LEGENDARYNESS: 'APP/QUESTION_LEGENDARYNESS',
  BECOME_LEGENDARY: 'APP/BECOME_LEGENDARY',
  LEGENDARY_FAILURE: 'APP/LEGENDARY_FAILURE'
}

export const initialState = {
  canBecomeLegendary: false, 
  isLegendary: false
};

export default (state=initialState, action)=> {
  switch (action.type){
    case types.QUESTION_LEGENDARYNESS:
      return {...state, canBecomeLegendary: true};
    case types.BECOME_LEGENDARY:
      if (state.canBecomeLegendary) {
        return {...state, isLegendary: true};
      }
      return {...state, isLegendary: false};
    case types.LEGENDARY_FAILURE:
      return {...state, isLegendary: false, canBecomeLegendary: false};
    default: return state;
  }
}

export const actions = {
  questionLegendaryness: {type: types.QUESTION_LEGENDARYNESS},
  becomeLegendary: {type: types.BECOME_LEGENDARY},
  legendaryFailure: {type: types.LEGENDARY_FAILURE}
};