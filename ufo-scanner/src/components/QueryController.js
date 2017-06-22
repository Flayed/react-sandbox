import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actions as cityStateActions } from '../reducers/cityStates';
import StateSelector from './StateSelector';
import CitySelector from './CitySelector';
import AbductionMap from './AbductionMap';

const mapStateToProps = (state) => {
    return {
        
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onFetchStates: () => { dispatch(cityStateActions.fetchStates()); },
    };
};

class QueryController extends Component {
    constructor(props){
        super(props);
        props.onFetchStates();
    }    
    render() {
        return (
            <div>                
                <StateSelector />
                <CitySelector />
                <AbductionMap />
            </div>
        );
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(QueryController);