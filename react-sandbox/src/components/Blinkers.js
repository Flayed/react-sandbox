import React from 'react';
import { connect } from 'react-redux';
import Blink from './Blink';

const mapStateToProps = (state) => {
    return { isLegendary: state.legendaryStatus.isLegendary };
}

const blinkers = ({isLegendary}) => {
    if (isLegendary)
    {
        var doges = [];
        var key = 0;
        for (let superlative of ['Wow', 'such legend', 'very pancake', 'wow', 'no vomit', 'much impress', 'so pancake', 'no waffle', 'legend', 'wow']) {
            doges.push(<Blink key={key++} text={superlative}/>);
        }
        return (
            <div className={isLegendary ? '' : 'hidden'}>
            {doges} 
            </div>
        );
    }
    else {
        return <div></div>
    }
}

export default connect(mapStateToProps)(blinkers);