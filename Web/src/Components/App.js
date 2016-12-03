import React, { Component } from 'react';
import './../Styles/App.css';
import Header from './Header'
import Session from './../Session'

class App extends Component {

  constructor(props,content){
    super(props,content);
    this.state = {
     // user : s.getAuthenticatedUser()
    }
  }

  render() {
   /* if(this.state.user == null) {
        return (
            <div className = "App" >
            <Header / >
            <p  className = "App-intro" >
          Login</p >

        < / div >);
    } else {*/
      return(
          <div className = "App" >
          <Header / >
          <p  className = "App-intro" >
          Hello {this.props.user}
      </p >
          < / div >
    );

    }
  }


export default App;
