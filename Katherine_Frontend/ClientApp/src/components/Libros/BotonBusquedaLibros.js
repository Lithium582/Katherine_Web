import React, { Component } from 'react';

export class BotonBusquedaLibros extends Component {
    constructor(props) {
        super(props);

        this.state = {
            onButtonClick: props.onButtonClick,
            libro: props.libro,
            textoBoton: props.textoBoton
        };

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick = () => {
        this.props.onButtonClick(this.state.libro);
    }

    render() {
        return (
            <div>
                <button
                    onClick={this.handleClick}>
                    {this.state.textoBoton}
                </button>
            </div>
        );
    }
}
