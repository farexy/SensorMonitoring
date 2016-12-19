/**
 * Created by Александр on 05.12.2016.
 */
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css';
import './../Styles/forms.css';
import SensorEditor from './SensorEditor';
import SearchList from './SearchList';
import Header from './Header';
import SubscriptionView from './SubscriptionView';
import $ from 'jquery';
import searchIco from './../search.png';
import { SUBSCRIPTION_URL, SENSOR_URL} from './../URL';

class SensorList extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            list: [],
            search: ''
        }
        this.loadData();
    }

    render() {
        return(
            <div className='SubscriptionList'>
                <Header user={this.props.user}/>
                <div className='sensor-list'>
                    <div className="loginmodal-container">
                        <input onChange={this.handleSearchChange} className="text-input" placeholder="Search new"/>
                        <button className="search-button"  onClick={this.openSearch}>
                            <img src={searchIco} className="search-ico"/>
                        </button>
                    </div>
                    {
                        this.state.list.map((item) =>
                            <SubscriptionView user={this.props.user} key={item.Id} sensor={item}/>
                        )
                    }
                </div>
            </div>
        );

    }

    openAddSensorEditor = () => {
        ReactDOM.render(
            <SensorEditor sensorId='0' user={this.props.user} url={this.props.url}/>,
            document.getElementById('root')
        )
    }

    handleSearchChange = (e) => {
        this.setState({ search: e.target.value});
    }

    loadData = () => {
        $.ajax({
            url: SUBSCRIPTION_URL + 'getSubscriptionsByUserId?userId=' + this.props.user.Id,
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

    openSearch = () => {
        ReactDOM.render(
            <SearchList user={this.props.user} search={this.state.search} subscribedList={this.state.list}/>,
            document.getElementById('root')
        )
    }
}


export default SensorList;