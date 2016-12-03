/**
 * Created by Александр on 12.11.2016.
 */

import React, { Component } from 'react';
import './../Styles/App.css';
import Header from './Header';
import './../Styles/forms.css';
import $ from 'jquery';
import Session from './../Session'
import User from './../Models/User'
import App from './App'

class Registration extends Component {

    constructor(props,content){
        super(props,content);
        this.state = {
            email: "",
            password: "",
            passwordConfirm:"",
            fullName: "",
            passwordConfirmErr:"",
            passwordErr:"",
            emailErr:"",
            fullNameErr:""
        };
    }

    render() {
        return (
            <div className="Registration">
                <Header/>

                <div className="loginmodal-container">
                    <form className="Registration-form" onSubmit={this.validate}>
                <h1>Register</h1><br/>
                        <input
                            type="email" name="email" placeholder="Email" onChange={this.handleEmailChange}
                        /><br/>
                        <span className='alert-text'>{this.state.emailErr}</span><br/>
                        <input
                            type="text" name="fullName" placeholder="Full name" onChange={this.handleFullNameChange}
                        /><br/>
                        <span className='alert-text'>{this.state.fullNameErr}</span><br/>
                        <input
                            type="password" name="password" placeholder="Password" onChange={this.handlePasswordChange}
                        /><br/>
                        <span className='alert-text'>{this.state.passwordErr}</span><br/>
                        <input
                            type="password" name="passwordConfirmation" onChange={this.handlePasswordConfirmChange} placeholder="Confirm password"
                        /><br/>
                        <span className='alert-text'>{this.state.passwordConfirmErr}</span><br/>
                        <input
                            type="submit" className="login loginmodal-submit" value="Registrate"
                        /><br/>
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

    handleFullNameChange = (e) => {
        this.setState({ fullName: e.target.value});
    }

    handlePasswordConfirmChange = (e) => {
        this.setState({ passwordConfirm: e.target.value});
    }

    validate = (e) => {
        e.preventDefault();
        this.setState({
            passwordErr:"",
            passwordConfirmErr:"",
            emailErr:"",
            fullNameErr:""
        })
        var err = false;
        if(this.state.email.length == 0) {
            this.setState({emailErr: "Email can not be empty"})
            err = true;
        }
        if(this.state.password.length < 4) {
            this.setState({passwordErr: "Password too short"})
            err = true;
        }
        if(this.state.fullName.length == 0) {
            this.setState({fullNameErr: "Full name can not be empty"})
            err = true;
        }
        if(this.state.password !== this.state.passwordConfirm){
            this.setState({passwordConfirmErr:"Passwords are not equal"})
            err = true;
        }
        if(!err)
            this.post();
    }

    post = () => {
        var email = this.state.email.trim();
        var password = this.state.password.trim();
        var fullName = this.state.fullName.trim();

        var data = {
            "email": email,
            "password": password,
            "fullName": fullName
        }
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            type: 'POST',
            data: data,
            success: (function(response){
                if(response.IsSuccess) {
                    console.log(response);
                    Header.open(<App user={this.state.fullName}/>)
                } else this.setState({error:"Login or password are incorrect"})

            }).bind(this)
        });
    }

}

export default Registration;