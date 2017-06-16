import React from 'react';
import { connect } from 'react-redux';
import {actions} from '../reducers/legendaryStatus';

const mapStateToProps = (state) => {
    return {
        canBecomeLegendary: state.legendaryStatus.canBecomeLegendary,
        isLegendary: state.legendaryStatus.isLegendary
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onBecomeLegendary: () => { dispatch(actions.becomeLegendary); }
    };
};

const legendaryButton = ({canBecomeLegendary, isLegendary, onBecomeLegendary}) => {
    return (
        <div className={canBecomeLegendary && !isLegendary ? "App-pancake-become-legendary" : "hidden"}>
            <button className="App-pancake-legendary-button" onClick={() => {onBecomeLegendary();}}>Become LEGENDARY</button>
        </div>
    );
}

export default connect(mapStateToProps, mapDispatchToProps)(legendaryButton);