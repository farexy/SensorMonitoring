/**
 * Created by Александр on 05.12.2016.
 */
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css';
import SensorEditor from './SensorEditor';
import Header from './Header';
import SensorView from './SensorView';
import $ from 'jquery';
import Session from './../Session'

class SensorList extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            list: []
        }
        this.loadData();
    }

    render() {
        return(
            <div className='SensorList'>
            <Header/>
                <div className='sensor-list'>
                <button className='add-button' onClick={this.openAddSensorEditor}>Add new sensor</button>
        {
            this.state.list.map((item) =>
                <SensorView key={item.Id} sensor={item} url={this.props.url}/>
            )
        }
            </div>
        </div>
    );

    }

    openAddSensorEditor = () => {
        ReactDOM.render(
            <SensorEditor sensorId='0' masterId='1' method='create' url={this.props.url}/>,
            document.getElementById('root')
        )
    }

    loadData = () => {
        $.ajax({
            url: this.props.url + 'getSensorsByMasterId?userId=' + this.props.masterId,
            dataType: 'json',
            type: 'GET',
            success: (function (response) {
                if(response != null){
                    console.log(response)

                    this.setState({
                        list: response
                    })
                }

            }).bind(this)
        });

    }
}


export default SensorList;