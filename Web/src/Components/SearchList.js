import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css';
import searchIco from './../search.png';
import SensorEditor from './SensorEditor';
import Header from './Header';
import SensorView from './SensorView';
import $ from 'jquery';
import {SENSOR_URL} from './../URL';
import Session from './../Session'

class SearchList extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            list: [],
            search: this.props.search,
            subscribedList: this.props.subscribedList
        }
        this.loadData();
    }

    render() {
        return(
            <div className='SearchList'>
                <Header user={this.props.user}/>
                <div className='sensor-list'>
                    <div className="loginmodal-container">
                        <input onChange={this.handleSearchChange} className="text-input" placeholder="Search new"/>
                        <button className="search-button" type="submit" onClick={this.loadData}>
                            <img src={searchIco} className="search-ico"/>
                        </button>
                    </div>
                    {

                        this.state.list.map((item) => this.viewItem(item))
                    }
                </div>
            </div>
        );
    }

    handleSearchChange = (e) => {
        this.setState({ search: e.target.value});
    }


    openAddSensorEditor = () => {
        ReactDOM.render(
            <SensorEditor sensorId='0' masterId='1' method='create' url={this.props.url}/>,
            document.getElementById('root')
        )
    }

    viewItem = (item) => {
        if (this.containsId(item.Id))
            var view = <SensorView user={this.props.user} action='unsubscribe' key={item.Id} sensor={item}/>
        else
            var view = <SensorView user={this.props.user} action='subscribe' key={item.Id} sensor={item}/>
        return view;
    }

    containsId = (id) => {
        for(let i = 0; i < this.state.subscribedList.length; i++){
            if(this.state.subscribedList[i].Id == id){
                return true;
            }
        }
        return false;
    }

    loadData = () => {
        if(this.state.search == '')
            this.setState({search: ' '});
        $.ajax({
            url: SENSOR_URL + 'search?value=' + this.state.search,
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


export default SearchList;
