
import React from 'react';
import { actions as consumeActions } from '../reducers/consumed';
import { actions as legendaryActions } from '../reducers/legendaryStatus';
import { connect } from 'react-redux';

const mapStateToProps = (state) => {
    return {
        consumed: state.consumed,
        message: state.message
    };
};

const mapDispatchToProps = (dispatch) => {
    return { actions: 
        {
            onBarf: () => { dispatch(consumeActions.barf); },
            onEat: () => { dispatch(consumeActions.eat); },
            onQuestionLegendaryness: () => { dispatch(legendaryActions.questionLegendaryness); },
            onLegendaryFailure: () => { dispatch(legendaryActions.legendaryFailure); }
        }
    };
};

const tryEatPancake = (consumed, actions) => {
    if (Math.random() > .9 - (consumed * .05)) {
        actions.onBarf();
        if (consumed <= 10) {
            actions.onLegendaryFailure();
        }
    }
    else {
        actions.onEat();
        if (consumed >= 5) {
            actions.onQuestionLegendaryness();
        }
    }              
};

const PancakePlate = ({consumed, message, actions}) => {
    return  <div>
        <div className="App-pancake">
            PANCAKES EATEN: <span className={message.length > 0 ? 'puke': ''}>{consumed}</span>
            </div>        
            <button onClick={()=> {tryEatPancake(consumed, actions);}}>
            NOM
            </button>
            <div className="App-pancake-message">
                {message}
            </div>
    </div>
};

export default connect(mapStateToProps, mapDispatchToProps)(PancakePlate);

