import React from 'react';
import { connect } from 'react-redux';
import {actions as queryActions} from '../reducers/query';
import _ from 'lodash'

const mapStateToProps = (state, ownProps) => {
    return {
        abduction: _.find(state.query.abductions, (abduction)=>{
            return abduction.Id === ownProps.abductionId;})
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onCloseInfocard: (abductionId) => { dispatch(queryActions.toggleInfocard(abductionId)); },
    };
};

const abductionSiteInfoCard = ({abduction, onCloseInfocard}) => {
    if (abduction === undefined) {
        return (<div></div>);
    }
    var cn = 'app-abduction-infocard';
    if (!abduction.visible) cn += ' hidden';
    return (
        <div className={cn}>
            <div className="app-abduction-infocard-header">
                ABDUCTION
                <span className="app-abduction-infocard-header-close" onClick={()=>{onCloseInfocard(abduction.Id);}}>X</span>
            </div>
            <ul>
                <li>NAME: {abduction.Name}</li>
                <li>GENDER: {abduction.Gender}</li>
                <li>AGE: {abduction.Age}</li>
                <li>RACE: {abduction.Race}</li>
                <li>LAST SEEN: {abduction.LastSeen}</li>
                <li>CITY: {abduction.City}</li>
                <li>STATE: {abduction.CityState}</li>
            </ul>
        </div>  
    );
};

export default connect(mapStateToProps, mapDispatchToProps)(abductionSiteInfoCard);