import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css'
import SensorPage from './SensorPage';
import $ from 'jquery';
import {SENSOR_READING_URL} from './../URL'

class SensorView extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            reading: ""
        }
        this.loadReading();
    }

    render() {
        return(
            <div className='SubscriptionView' onClick={this.openSensorPage}>
                <h3 className="sensor-name">{this.props.sensor.Name}</h3>
                <h4 className="sensor-place">{this.props.sensor.Place}</h4>
                <h2 className="reading-pre-value">{this.state.reading}</h2>

            </div>
        );
    }

    loadReading = () => {
        $.ajax({
            url: SENSOR_READING_URL + 'getBySensorId?sensorId=' + this.props.sensor.Id,
            type: 'GET',
            success: (function(response){
                console.log(response);
                this.setState({reading:response})

            }).bind(this)
        });
    }
    
    openSensorPage = () => {
        this.open(<SensorPage user={this.props.user} reading={this.state.reading} sensor={this.props.sensor}/>)
    }

    open = (component) => {
        ReactDOM.render(
            component,
            document.getElementById('root')
        )
    }

}


export default SensorView;
