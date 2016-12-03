/**
 * Created by Александр on 12.11.2016.
 */
import React, { Component } from 'react';
import ReactDOM from 'react-dom';
import logo from './../favicon.png';
import './../Styles/Header.css';
import Registration from './Registration';
import Login from './Login';
import App from './App';

class Header extends Component {
    render() {
        return (
        <div className="Header">
            <div>
            <div className="lil"><a href="default.asp"><img src={logo} className="App-logo" alt="logo" /></a></div>
                <div className="lil"><a><h2>Sensor monitoring</h2></a></div>
                <div className="lil"><a onClick={this.openRegistration}>Sign in</a></div>
                <div className="lil"><a onClick={this.openLogin}>Login</a></div>

            </div>
        </div>

        );
    }

    openRegistration(){
        Header.open(<Registration url='http://localhost:24688/api/user/register'/>)
    }

    openLogin(){
        Header.open(<Login url='http://localhost:24688/api/user/login'/> )
    }

    static open(component){
        ReactDOM.render(
            component,
            document.getElementById('root')
        )
    }


}

export default Header;