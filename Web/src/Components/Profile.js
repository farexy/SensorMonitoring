
import React, { Component } from 'react';
import './../Styles/App.css';
import './../Styles/forms.css';
import Header from './Header';
import $ from 'jquery';
import App from './App'
import {USER_URL} from './../URL'

class Profile extends Component {

    constructor(props,content){
        super(props,content);
        this.state = {
            email: this.props.user.Email,
            password: this.props.user.Password.trim(),
            passwordConfirm:this.props.user.Password.trim(),
            fullName: this.props.user.FullName,
            passwordConfirmErr:"",
            passwordErr:"",
            emailErr:"",
            fullNameErr:""
        };
    }

    render() {
        return (
            <div className="Profile">
                <Header user={this.props.user}/>
                <div className="loginmodal-container">
                    <form className="Registration-form" onSubmit={this.validate}>
                        <h1>Profile</h1><br/>
                        <input
                            type="email" name="email" placeholder="Email"
                            onChange={this.handleEmailChange} value={this.state.email}
                        /><br/>
                        <span className='alert-text'>{this.state.emailErr}</span><br/>
                        <input
                            type="text" name="fullName" placeholder="Full name"
                            onChange={this.handleFullNameChange} value={this.state.fullName}
                        /><br/>
                        <span className='alert-text'>{this.state.fullNameErr}</span><br/>
                        <input
                            type="password" name="password" placeholder="Password"
                            onChange={this.handlePasswordChange} value={this.state.password}
                        /><br/>
                        <span className='alert-text'>{this.state.passwordErr}</span><br/>
                        <input
                            type="password" name="passwordConfirmation" onChange={this.handlePasswordConfirmChange}
                            placeholder="Confirm password" value={this.state.passwordConfirm}
                        /><br/>
                        <span className='alert-text'>{this.state.passwordConfirmErr}</span><br/>
                        <input
                            type="submit" className="login loginmodal-submit" value="Save"
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

        var err = false;
        if (this.state.email.length == 0) {
            this.setState({emailErr: "Email can not be empty"})
            err = true;
        }
        if (this.state.password.length < 4) {
            this.setState({passwordErr: "Password too short"})
            err = true;
        }
        if (this.state.fullName.length == 0) {
            this.setState({fullNameErr: "Full name can not be empty"})
            err = true;
        }
        if (this.state.password !== this.state.passwordConfirm) {
            this.setState({passwordConfirmErr: "Passwords are not equal"})
            err = true;
        }
        if (!err)
            this.post();
    }

    post = () => {
        var email = this.state.email.trim();
        var password = this.state.password.trim();
        var fullName = this.state.fullName.trim();
        var id = this.props.user.Id;

        var data = {
            "Id" : id,
            "Email": email,
            "Password": password,
            "FullName": fullName
        }
        $.ajax({
            url: USER_URL + 'update',
            dataType: 'json',
            type: 'POST',
            data: data,
            success: (function(response){
                if(response != null) {
                    //console.log(response);
                    Header.open(<App user={data}/>)
                } else this.setState({error:"Login or password are incorrect"})

            }).bind(this)
        });
    }

}

export default Profile;