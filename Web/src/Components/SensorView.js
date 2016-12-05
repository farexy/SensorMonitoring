/**
 * Created by Александр on 05.12.2016.
 */
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css'
import SensorEditor from './SensorEditor'
import Session from './../Session'

class SensorView extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            // user : s.getAuthenticatedUser()
        }
    }

    render() {
        return(
            <div className='SensorView'>
                <h3 className="sensor-name">{this.props.sensor.Name}</h3>
                <h4 className="sensor-place">{this.props.sensor.Place}</h4>
                <button className='settings-button' onClick={this.openEditor}>Settings</button>
            </div>
        );
    }

    openEditor = () => {
        ReactDOM.render(
        <SensorEditor sensor={this.props.sensor} masterId='1' method='update' url={this.props.url}/>,
        document.getElementById('root')
        )
    }
}


export default SensorView;
