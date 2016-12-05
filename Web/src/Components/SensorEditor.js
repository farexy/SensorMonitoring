/**
 * Created by Александр on 04.12.2016.
 */
import React, { Component } from 'react';
import './../Styles/App.css';
import './../Styles/forms.css';
import Header from './Header';
import SensorList from './SensorList';
import $ from 'jquery';
import Session from './../Session'

class SensorEditor extends Component {

    constructor(props, content) {
        super(props, content);

        if(props.sensor != null) {
            if(this.props.sensor.Place == null)
                this.props.sensor.Place = "";
            this.state = {
                name: this.props.sensor.Name,
                place: this.props.sensor.Place,
                substance: this.props.sensor.Substance,
                limit: this.props.sensor.Limit.toString(),
                dimension: this.props.sensor.Dimension,
                password: this.props.sensor.Password,
                nameErr: "",
                placeErr: "",
                substanceErr: "",
                limitErr: "",
                dimensionErr: "",
                passwordErr: ""
            }
        } else
            {
                this.state = {
                    name: '',
                    place: '',
                    substance: '',
                    limit: '',
                    dimension: '',
                    password: '',
                    nameErr: "",
                    placeErr: "",
                    substanceErr: "",
                    limitErr: "",
                    dimensionErr: "",
                    passwordErr: ""
                }
            }
    }


    render() {
        if(this.props.sensor != null)
            var component = <button className = 'delete-button' onClick = {this.delete}> Delete  < / button >;
        return (
            < div
        className = "SensorEditor" >
            < Header / >
            < div
        className = "loginmodal-container" >
            < form
        className = "Sensor-form"
        onSubmit = {this.validate
    }>
    <
        h1 > Create
        sensor < / h1 > < br / >
        < input
        type = "text"
        name = "name"
        placeholder = "Name"
        onChange = {this.handleNameChange
    }
        value = {this.state.name
    }
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.nameErr
    }</
        span > < br / >
        < input
        type = "text"
        name = "place"
        placeholder = "Place"
        onChange = {this.handlePlaceChange}
        value = {this.state.place}
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.placeErr
    }</
        span > < br / >
        < input
        type = "text"
        name = "substance"
        placeholder = "Substance"
        onChange = {this.handleSubstanceChange
    }
        value = {this.state.substance
    }
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.substanceErr
    }</
        span > < br / >
        < input
        type = "text"
        name = "limit"
        onChange = {this.handleLimitChange
    }
        placeholder = "Limits"
        value = {this.state.limit
    }
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.limitErr
    }</
        span > < br / >
        < input
        type = "text"
        name = "dimension"
        placeholder = "Dimension"
        onChange = {this.handleDimensionChange
    }
        value = {this.state.dimension
    }
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.dimensionErr
    }</
        span > < br / >
        < input
        type = "password"
        name = "password"
        placeholder = "Password"
        onChange = {this.handlePasswordChange}
        value = {this.state.password}
    /><
        br / >
        < span
        className = 'alert-text' > {this.state.passwordErr}
    </ span > < br / >
        < input
        type = "submit"
        className = "login loginmodal-submit"
        value = "Save"
            / > < br / >
            < / form >
            {component}
            < / div >
            < / div >
    )
        ;

    }

    handleNameChange = (e) => {
        this.setState({name: e.target.value});
    }

    handlePasswordChange = (e) => {
        this.setState({password: e.target.value});
    }

    handlePlaceChange = (e) => {
        this.setState({place: e.target.value});
    }

    handleSubstanceChange = (e) => {
        this.setState({substance: e.target.value});
    }

    handleLimitChange = (e) => {
        this.setState({limit: e.target.value});
    }

    handleDimensionChange = (e) => {
        this.setState({dimension: e.target.value});
    }

    validate = (e) => {
        e.preventDefault();
        this.setState({
            nameErr: "",
            placeErr: "",
            substanceErr: "",
            limitErr: "",
            dimensionErr: "",
            passwordErr: ""
        })
        var err = false;
        if (this.state.name.length < 5) {
            this.setState({nameErr: "Name is too short"})
            err = true;
        }
        if (this.state.password.length < 5) {
            this.setState({passwordErr: "Password is too short"})
            err = true;
        }
        if (this.state.dimension.length == 0) {
            this.setState({dimensionErr: "Dimension can't be empty"})
            err = true;
        }
        if (this.state.substance.length == 0) {
            this.setState({substanceErr: "Substance can't be empty"})
            err = true;
        }
        let regex = /^[0-9]+([.][0-9]+)|[0-9]+$/;
        if (!this.state.limit.match(regex)) {
            this.setState({limitErr: "Limit should be a float value"})
            err = true;
        }
        if (!err)
            this.post();
    }

    loadData = () => {
        $.ajax({
            url: this.props.url + 'getSensor?id=' + this.props.sensorId,
            dataType: 'json',
            type: 'GET',
            success: (function (response) {
                if(response != null){
                    this.setState({
                        name: response.Name,
                        place: response.Place,
                        substance: response.Substance,
                        limit: response.Limit,
                        dimension: response.Dimension,
                        password: response.Password,
                    })
                }

            }).bind(this)
        });
    }

    delete = () =>{
        $.ajax({
            url: this.props.url + 'delete?id=' + this.props.sensor.Id,
            type: 'DELETE',
            success: (function (response) {
                if (response.IsSuccess) {
                    console.log(response);
                    Header.open(<SensorList url='http://localhost:24688/api/sensor/' masterId='1'/>);

                } else console.log(response)

            }).bind(this)
        });
    }

    post = () => {
        var name = this.state.name.trim();
        var password = this.state.password.trim();
        var place = this.state.place.trim();
        var limit = this.state.limit;
        var dimension = this.state.dimension.trim();
        var substance = this.state.substance.trim();
        var userId = this.props.masterId;
        if(this.props.sensor != null)
            var id = this.props.sensor.Id;
        else
            var id = 0;

        var data = {
            "id": id,
            "name": name,
            "password": password,
            "place": place,
            "limit": limit,
            "dimension": dimension,
            "substance": substance,
            "userId": userId
        }
        $.ajax({
            url: this.props.url + this.props.method,
            dataType: 'json',
            type: 'POST',
            data: data,
            success: (function (response) {
                if (response.IsSuccess) {
                    console.log(response);
                    Header.open(<SensorList url='http://localhost:24688/api/sensor/' masterId='1'/>);

                } else console.log(response)

            }).bind(this)
        });

    }
}


export default SensorEditor;