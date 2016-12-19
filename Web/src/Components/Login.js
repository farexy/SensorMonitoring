/**
 * Created by Александр on 14.11.2016.
 */
import React, { Component } from 'react';
import './../Styles/App.css';
import './../Styles/forms.css';
import Header from './Header';
import $ from 'jquery';
import App from './App'
import {USER_URL} from './../URL'

class Login extends Component {

    constructor(props,content){
        super(props,content);
        this.state = {
            error:"",
            email:"",
            password:""
        };
    }

    render() {
        return (
            <div className="Login" >
            <Header/>
            <div className="loginmodal-container">
            <form className="Login-form" onSubmit={this.handleSubmit}>
    <h1>Login to Your Account</h1><br/>
        <input
        type="text"
        name="email"
        placeholder="Email"
        value={this.state.email}
        onChange={this.handleEmailChange}
    />
        <input
        type="password"
        name="password"
        placeholder="Password"
        value={this.state.password}
        onChange={this.handlePasswordChange}
    />
        <input 
            type="submit"
            name="login"
            className="login loginmodal-submit"
            value="Login"
        />
        <h3 className='alert-text'>{this.state.error}</h3>
        </form>
        </div>
        </div>
    );
    }

    handleEmailChange = (e) => {
        this.setState({ email: e.target.value});
    }

    handlePasswordChange = (e) => {
        this.setState({ password: e.target.value});
    }

    handleSubmit = (e) => {
        e.preventDefault();
        var email = this.state.email.trim();
        var password = this.state.password.trim();
        if (!email || !password) {
            return;
        }
        var data = {
            "email": email,
            "password": password
        }
        $.ajax({
            url: USER_URL + 'login',
            dataType: 'json',
            type: 'POST',
            data: data,
            success: (function(response){
                if(response != null) {
                    //console.log(response);
                    localStorage.setItem('user', response)
                    console.log(localStorage.getItem('user'))
                    Header.open(<App user={response}/>)
                } else this.setState({error:"Login or password are incorrect"})

            }).bind(this)
        });
    }

}

export default Login;