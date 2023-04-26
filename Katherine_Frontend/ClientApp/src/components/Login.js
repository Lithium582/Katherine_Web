import React, { Component } from 'react';
import { Usuario } from "../Clases/Usuario";
import { Route, Redirect } from 'react-router-dom';

export class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            Usuario: "",
            Password: ""
        }

        this.handleCambioUsuario = this.handleCambioUsuario.bind(this);
        this.handleCambioPassword = this.handleCambioPassword.bind(this);

        this.funcLogin = this.funcLogin.bind(this);
        this.callbackLogin = this.callbackLogin.bind(this);
    }

    funcLogin() {
        //Unauthorized
        //status: 401
        //title: "Unauthorized"
        //traceId: "00-d995b860d838e447b8b9d4d3baa3394c-5b8bab16f0ec314f-00"
        //type: "https://tools.ietf.org/html/rfc7235#section-3.1"

        //OK
        //expiration: "2022-03-08T00:03:10Z"
        //token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE2NDY2OTc3OTAsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NjE5NTUiLCJhdWQiOiJodHRwOi8vbG9jYWxob3N0OjQyMDAifQ.Gqi3xXTNCnyK6qgyxeXHWWyOjjn0NogUjn8PoLg1_Kw"
        Usuario.Login(this.state.Usuario, this.state.Password, this.callbackLogin);
    }

    callbackLogin(data) {
        console.log("SOY LOGIN ", data);

        if (data.token != "") {
            Usuario.token = data.token;
        }

        this.props.history.push("/home");
    }

    handleCambioUsuario(event) {
        this.setState({
            Usuario: event.target.value
        })
    }

    handleCambioPassword(event) {
        this.setState({
            Password: event.target.value
        })
    }

    render() {
        return (
            <div>
                <h1>LOGIN</h1>

                <p>BIENVENIDO</p>

                <table>
                    <tbody>
                        <tr>
                            <td>
                                <p>Usuario</p>
                            </td>
                            <td>
                                <input type="text" id="txtUsuario" value={this.state.Usuario} onChange={this.handleCambioUsuario} />
                            </td>

                            <td>
                                <p>Título</p>
                            </td>
                            <td>
                                <input type="password" id="txtPassowrd" value={this.state.Password} onChange={this.handleCambioPassword} />
                            </td>
                        </tr>
                    </tbody>
                </table>

                <button className="btn btn-primary" onClick={this.funcLogin}>Entrar</button>
            </div>
        );
    }
}