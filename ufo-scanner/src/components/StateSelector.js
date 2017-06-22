import React from 'react';
import { connect } from 'react-redux';
import { actions as queryActions } from '../reducers/query';
import { actions as cityStateActions } from '../reducers/cityStates';

const mapStateToProps = (state) => {
    return {
        states: state.cityStates.states
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onSelectState: (cityState) => { dispatch(cityStateActions.selectState(cityState)); },
        onFetchCities: (cityState) => { dispatch(queryActions.fetchCities(cityState)); },
        onFetchAbductions: (cityState) => { dispatch(queryActions.fetchAbductions(cityState)); }
    };
};

const stateSelector = ({states, onFetchCities, onFetchAbductions, onSelectState}) => {
    if (states.length > 0) {
        return ( 
            <div className="app-state-selector">
                <span>Select State:</span>
                <select onChange={(evt) => { 
                    onSelectState(evt.target.value);
                    onFetchCities(evt.target.value);
                    onFetchAbductions(evt.target.value); }}>
                    <option value=''></option>
                    {states.map((state, idx)=><option key={idx} value={state}>{state}</option>)}
                </select>
            </div>
        );
    }
    return (<div></div>);
};

export default connect(mapStateToProps, mapDispatchToProps)(stateSelector);