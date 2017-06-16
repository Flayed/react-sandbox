import React, { Component } from 'react';

class Blink extends Component {
  constructor(props){
    super(props);
    this.state = {position: {left: 0, top: 0}, color: 'transparent', visible: false};
  }
  componentDidMount() {    
    this.timerId = setInterval (()=>{ this.tick()}, Math.random() * 1000 + 333);
  }
  componentWillUnmount() {
    clearInterval(this.timerId);
  }
  tick() {
    if (!this.state.visible){
      var leftPos = Math.random() * 100;
      var topPos = Math.random() * 100;
      var color = '#' + Math.floor(Math.random()*16777215).toString(16);
      this.setState({position: {left: leftPos + "vw", top: topPos + "vh"}, color: color, visible: true});
    }
    else{
      this.setState({visible: false});
    }
  }
  render() { 
    return (
      <span className={"blink " + (this.state.visible ? '' : 'hidden')} style={{left: this.state.position.left, top: this.state.position.top, color: this.state.color}}>
        {this.props.text}  
      </span>
    );
  }
}

export default Blink;