import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import './../Styles/App.css';
import './../Styles/Sensor.css'
import './../Styles/modal.css'
import SubscriptionList from './SubscriptionList';
import $ from 'jquery';
import SensorEditor from './SensorEditor';
import SensorPage from './SensorPage';
import Session from './../Session';
import {SUBSCRIPTION_URL} from './../URL';

class SensorView extends Component {

    constructor(props, content) {
        super(props, content);
        this.state = {
            modalWindowClass : "modal-window-hidden",
            password: '',
            error:''
        }
    }

    render() {
        if(this.props.action === 'subscribe') {
            var onclick = this.openSubscription ;
            var button = <button className='settings-button' onClick={this.openSubscription}>Subscribe</button>
        }
        if(this.props.action === 'setting') {
            var onclick = this.openSensorPage;
            var button = <button className='settings-button' onClick={this.openEditor}>Settings</button>
        }
        if(this.props.action === 'unsubscribe'){
            var onclick = this.unsubscribe;
            var button = <button className='unsubscribe-button' onClick={this.unsubscribe}>Unsubscribe</button>
        }
        return(
            //modal dialog

            <div className='SensorView' onClick={onclick}>

                <div className={this.state.modalWindowClass}>
                    <h4 className="modal-text">Enter password:</h4>
                    <input type="password" className="modal-input" onChange={this.handlePasswordChange} value={this.state.password}/>
                    <span className="error-text">{this.state.error}</span><br/>
                    <button onClick={this.subscribe}>Subscribe</button>
                    <button onClick={this.closeSubscription}>Cancel</button>
                </div>

                <h4 className="sensor-id">ID: {this.props.sensor.Id}</h4>
                <h3 className="sensor-name">{this.props.sensor.Name}</h3>
                <h4 className="sensor-place">{this.props.sensor.Place}</h4>
                {button}
            </div>
        );
    }

    handlePasswordChange = (e) => {
        this.setState({password: e.target.value})
    }

    subscribe = () => {
        var data = {
            "sensorId": this.props.sensor.Id,
            "password": this.state.password,
            "userId": this.props.user.Id
        }
        $.ajax({
            url: SUBSCRIPTION_URL + 'createSubscription',
            dataType: 'json',
            type: 'POST',
            data: data,
            success: (function(response){
                if(response.IsSuccess) {
                    this.openSubscriptionList();

                } else this.setState({error:response.ExceptionMessage})

            }).bind(this)
        });
    }

    unsubscribe = () => {
        $.ajax({
            url: SUBSCRIPTION_URL + 'delete?sensorId=' + this.props.sensor.Id + '&userId=' + 1,
            type: 'GET',
            success: (function(response){
                if(response.IsSuccess) {
                    this.openSubscriptionList();
                } else alert(response.ExceptionMessage)

            }).bind(this)
        });
    }

    openSubscriptionList = () => {
        this.open(<SubscriptionList user={this.props.user}/>)
    }

    openSensorPage = () => {
        this.open(<SensorPage user={this.props.user} sensor={this.props.sensor}/>)
    }

    openEditor = () => {
        this.open(<SensorEditor user={this.props.user} sensor={this.props.sensor}/>)
    }

    openSubscription = () => {
        this.setState({modalWindowClass:"modal-window-visible"})
    }


    closeSubscription = () => {
        this.setState({modalWindowClass:'modal-window-hidden', password: ''})
    }

    open = (component) => {
        ReactDOM.render(
            component,
            document.getElementById('root')
        )
    }
    
}


export default SensorView;
