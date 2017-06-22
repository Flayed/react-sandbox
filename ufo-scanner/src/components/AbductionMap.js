import React from 'react';
import { connect } from 'react-redux';
import Map from './Map';
import AbductionSite from './AbductionSite';

const mapStateToProps = (state) => {
    return {
        abductions: state.query.abductions,
        zoom: state.query.selectedCity.length > 0 ? 13 : state.cityStates.selectedState === 'AK' ?  5 : 7
    };
};

const mapDispatchToProps = (dispatch) => {
    return {

    };
};

const abductionMap = ({abductions, zoom}) => {
    if (abductions.length > 0) {
        var markers = [];
        var lat = 0;
        var lng = 0;
        for (var abduction of abductions) {
            markers.push(
                <AbductionSite key={abduction.Id} lat={abduction.Latitude} lng={abduction.Longitude} {...abduction} />
            );
            lat += abduction.Latitude;
            lng += abduction.Longitude;
        }       
        var center = [lat/abductions.length, lng/abductions.length];
        return (
            <Map zoom={zoom} center={center} >
                {markers}
            </Map>
        );
    }
    return (<div></div>);
};

export default connect(mapStateToProps, mapDispatchToProps)(abductionMap);