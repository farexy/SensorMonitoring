
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import Header from './Header';
import './../Styles/App.css';
import './../Styles/Sensor.css';
import './../Styles/SensorPage.css'
import $ from 'jquery';
import {SENSOR_READING_URL} from './../URL'
//import SensorEditor from './SensorEditor'

class SensorPage extends Component {

    static URL = "localhost:24688/api/sensorreading/"

    constructor(props, content) {
        super(props, content);
        this.state = {
            reading: this.props.reading
        }
        this.loadReading();
        this.connect();
    }

    render() {
        if(this.state.reading > this.props.sensor.Limit)
            var readingSpan = <span className="reading-red">{this.state.reading}</span>;
        else
            var readingSpan = <span className="reading">{this.state.reading}</span>;

        return(
            <div className='SensorPage'>
                <Header user={this.props.user}/>
                <h1 className="reading-titel">Current reading: {readingSpan}</h1>
                <div className="characteristics">
                    <h4>Name:{this.props.sensor.Name}</h4>
                    <h4>Place:{this.props.sensor.Place}</h4>
                    <h4>Substance:{this.props.sensor.Substance}</h4>
                    <h4>Dimension:{this.props.sensor.Dimension}</h4>
                    <h4>Limit:{this.props.sensor.Limit}</h4>
                </div>
            </div>
        );
    }

    connect = () => {

        setTimeout(this.loadReading, 5000);

    }

    openEditor = () => {
        ReactDOM.render(
            <SensorEditor sensor={this.props.sensor} masterId='1' method='update' url={this.props.url}/>,
            document.getElementById('root')
        )
    }

    loadReading = () => {
        $.ajax({
            url: SENSOR_READING_URL + 'getBySensorId?sensorId=' + this.props.sensor.Id,
            dataType: 'json',
            type: 'GET',
            success: (function (response) {
                if(response != null){
                    this.setState({
                        reading: response
                    })
                }
            }).bind(this)
        });
        this.connect();
    }
}


export default SensorPage;
