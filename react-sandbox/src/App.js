import React from 'react';
import { connect } from 'react-redux';
import Blinkers from './components/Blinkers';
import PancakePlate from './components/PancakePlate';
import Header from './components/Header';
import Intro from './components/Intro';
import LegendaryButton from './components/LegendaryButton';
import MapSearch from './components/MapSearch';
import './App.css';

const mapStateToProps = (state) => {
  return { isLegendary: state.legendaryStatus.isLegendary }
};

const app = ({isLegendary}) => {
  var appClassName = isLegendary ? "App legendary-background" : "App";
  return (
    <div className={appClassName}>
      <Header />
      <Intro />
      <MapSearch />
      <PancakePlate />
      <LegendaryButton />
      <Blinkers />
    </div>
  );
};

export default connect(mapStateToProps)(app);