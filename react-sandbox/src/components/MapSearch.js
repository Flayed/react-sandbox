import React, { Component } from 'react';
import { connect } from 'react-redux';
import { actions } from '../reducers/mapSearch';

const mapStateToProps = (state) => {
    return {
        searchText: state.mapSearch.searchText,
        searchHistory: state.mapSearch.searchHistory
    };
};

const mapDispatchToProps = (dispatch) => {
    return {
        onSearch: (searchText)=>{ dispatch(actions.search(searchText)) }
    };
};

class mapSearch extends Component {
    renderMap() {
        if (!this.props.searchText) return (<div />);
        var searchQuery = this.props.searchText.replace(' ', '+');
        return (
            <iframe
                title="Map"
                width="600"
                height="450"
                frameBorder="0"
                src={"https://www.google.com/maps/embed/v1/place?key=AIzaSyBIw0A_7HvN5bVSxbJN5s4QvKrF_J-IAZ8&q=" + searchQuery }
                >
            </iframe>
        );
    };

    renderHistory() {
        return (
            <div className="map-history">
                {this.props.searchHistory.map((item, idx)=> { return (                    
                    <span key={idx} className="map-history-link" onClick={() => {
                        this.props.onSearch(item); 
                        this.searchTextbox.value = item;
                        }}>
                        {item}
                    </span>
                );})}
            </div>
        );
    };

    search() {
        this.props.onSearch(this.searchTextbox.value);
        this.searchTextbox.value = ''; 
    }

    render() {
        return (
            <div>
                <input ref={node => {this.searchTextbox = node;}} 
                        onKeyUp={(evt)=>{ if (evt.keyCode === 13) this.search();}}/>
                <button onClick ={() => { this.search(); }} >
                    Search 
                </button>
                <div>
                    {this.renderHistory()}
                </div>
                {this.renderMap()}
            </div>
        );
    }
};



export default connect(mapStateToProps, mapDispatchToProps)(mapSearch);