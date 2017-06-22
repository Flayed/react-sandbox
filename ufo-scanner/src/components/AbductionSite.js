import React from 'react';
import { connect } from 'react-redux';
import AbductionSiteInfoCard from './AbductionSiteInfoCard';
import {actions as queryActions} from '../reducers/query';

const mapStateToProps = (state, ownProps) => {
    return {
        abduction: ownProps
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onAbductionSiteClick: (abductionId) => { dispatch(queryActions.toggleInfocard(abductionId)); },
    };
};

const abductionSite = ({abduction, onAbductionSiteClick}) => {
    return (
        <div>
            <div className='app-map-marker' onClick={()=>{ console.log("Toggling abduction site " + abduction.Id); onAbductionSiteClick(abduction.Id);  }}  />                 
            <AbductionSiteInfoCard abductionId={abduction.Id} />            
        </div>
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(abductionSite);