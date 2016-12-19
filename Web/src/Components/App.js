import React, { Component } from 'react';
import './../Styles/App.css';
import Header from './Header'
import Session from './../Session'

class App extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            // user : s.getAuthenticatedUser()
        }
    }

    render() {
        if (this.props.user == undefined) {
            return (
                < div
            className = "App" >
                < Header user={null}/ >
                    <h2 className="intro-text">
                        You need to Log in or Registrate!
                        </h2><h2 className="intro-text">
                    Sensor Monitoring - it is a new convenient service, made for people who know the cost of their personal time.
                    </h2><h2 className="intro-text">
                           It helps people to monitor the readings of their sensors as they are far away.
                    </h2><h2 className="intro-text">
                           Just add your sensor and let's begin!
                    </h2>
                < / div >
        )
            ;
        } else {
            return (
                < div
            className = "App" >
                < Header  user={this.props.user}/ >
                <h2 className='intro-text'>

                    Sensor Monitoring - it is a new convenient service, made for people who know the cost of their personal time.
                    </h2><h2 className='intro-text'>
                    It helps people to monitor the readings of their sensors as they are far away.
                    </h2><h2 className='intro-text'>
                    Just add your sensor and let's begin!
                    </h2>
            < / div >
        )
            ;
        }
    }
}


export default App;
