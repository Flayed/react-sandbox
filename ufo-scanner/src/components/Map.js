import React, {Component} from 'react';
import GoogleMap from 'google-map-react';

export default class Map extends Component {
    constructor(props){
        super(props);
        this.state = {
            zoom: (props.zoom ? props.zoom : 1),
            center: (props.center ? props.center : [0,0]),          
        };
    }
    render () {
        return (
            <div className="app-map">
                <GoogleMap                
                    center={this.state.center}
                    zoom={this.state.zoom}>
                    {this.props.children}
                </GoogleMap>
            </div>
        );
    }
}

