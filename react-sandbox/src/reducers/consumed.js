export const types = {EAT: 'APP/EAT', BARF: 'APP/BARF'};

export const initialState = 0;

export default (state = initialState, action) => {
  switch (action.type) {
    case types.EAT:
      return state + 1;
    case types.BARF:
      return Math.max(state - 5, 0);
    default: return state;
  }
}

export const actions = {
  eat: { type: types.EAT },
  barf: { type: types.BARF }
}