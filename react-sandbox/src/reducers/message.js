import {types as consumedTypes} from './consumed'

export const initialState = '';

export default (state = initialState, action) => {
  switch (action.type){
    case consumedTypes.EAT:
      return '';
    case consumedTypes.BARF:
      return 'You barfed all over the floor!!  Too many pancakes!';
    default: return state;
  }
};