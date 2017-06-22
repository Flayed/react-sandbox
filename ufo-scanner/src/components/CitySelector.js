import React from 'react';
import { connect } from 'react-redux';
import {actions as queryActions} from '../reducers/query';

const mapStateToProps = (state) => {
    return {
        cities: state.query.cities,
        selectedState: state.cityStates.selectedState
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onSelectCity: (city) => { dispatch(queryActions.selectCity(city)); },
        onFetchAbductions: (cityState, city) => { dispatch(queryActions.fetchAbductions(cityState, city)); }
    };
};

const citySelector = ({selectedState, cities, onFetchAbductions, onSelectCity}) => {
    if (cities.length > 0) {
        return (
            <div className="app-city-selector">
                <span>Select City:</span>
                <select onChange={(evt) => { 
                    onSelectCity(evt.target.value);
                    onFetchAbductions(selectedState, evt.target.value); }}>
                    <option value=''></option>
                    {cities.map((city, idx)=><option key={idx} value={city}>{city}</option>)}
                </select>
            </div>
        );
    }
    return (<div></div>);
};

export default connect(mapStateToProps, mapDispatchToProps)(citySelector);