/**
 * Created by Александр on 12.11.2016.
 */
import React, { Component } from 'react';
import ReactDOM from 'react-dom'; 
import logo from './../favicon.png';
import './../Styles/Header.css';
import Registration from './Registration';
import Login from './Login';
import SensorList from './SensorList';
import SubscriptionList from './SubscriptionList';
import Profile from './Profile';
import App from './App';

class Header extends Component {
    render() {
        if(this.props.user == null)
            var component = <div>
                <div className="lil"><a onClick={this.openMain}><img src={logo} className="App-logo" alt="logo" /></a></div>
                <div className="lil"><a><h2>Sensor monitoring</h2></a></div>
                <div className="lil"><a onClick={this.openRegistration}>Sign in</a></div>
                <div className="lil"><a onClick={this.openLogin}>Login</a></div>
            </div>
        else
            var component = <div>
                <div className="lil"><a onClick={this.openMain}><img src={logo} className="App-logo" alt="logo" /></a></div>
                <div className="lil"><a onClick={this.openMain}><h2>Sensor monitoring</h2></a></div>
                <div className="lil"><a onClick={this.openSensorEditor }>My sensors</a></div>
                <div className="lil"><a onClick={this.openSubscriptionList}>My subscriptions</a></div>
                <div className="lil"><a onClick={this.openProfile}>Hello, {this.props.user.FullName}!</a></div>
                <div className="lil"><a onClick={this.logout}>Logout</a></div>
            </div>
        return (
        <div className="Header">
            {component}
        </div>
        );
    }

    logout = () => {
        Header.open(<App/>)
    }

    openMain = () => {
        Header.open(<App user={this.props.user} />)
    }

    openProfile = () => {
        Header.open(<Profile user={this.props.user}/>)
    }

    openRegistration = () => {
        Header.open(<Registration url='http://localhost:24688/api/user/register'/>)
    }

    openLogin = () => {
        Header.open(<Login url='http://localhost:24688/api/user/login'/> )
    }

    openSensorEditor = () => {
        Header.open(<SensorList user={this.props.user} url='http://localhost:24688/api/sensor/' masterId='1'/> )
    }

    openSubscriptionList = () => {
        Header.open(<SubscriptionList user={this.props.user} url="http://localhost:24688/api/subscription" masterId="1"/>)
    }

    static open(component){
        ReactDOM.render(
            component,
            document.getElementById('root')
        )
    }


}

export default Header;