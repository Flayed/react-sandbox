import React from 'react';
import { connect } from 'react-redux';
import logo from '../assets/logo.svg';
import pancakeLogo from '../assets/pancake.png';

const mapStateToProps = (state) => {
    return {isLegendary: state.legendaryStatus.isLegendary};
};

const header = ({isLegendary}) => {
    var imgsrc = isLegendary ? pancakeLogo : logo;
    var title = isLegendary ? "Grab a seat in Pancakeville" : "Wecome to React";
    return (
        <div className="App-header">
            <img src={imgsrc} className="App-logo" alt="logo" />
            <h2>{title}</h2>
        </div>
    );
};

export default connect(mapStateToProps)(header);
