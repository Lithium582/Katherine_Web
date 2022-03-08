import React, { Component } from 'react';

export class CajaTexto extends Component {
    constructor(props) {
        super(props);

        this.state = {
            valor: this.props.valor,
            funcionHandle: this.props.funcionHandle
        };
    }
    render() {
        return (
            <div>
                <input type="text" id="txtValor" value={this.state.valor} onChange={this.state.funcionHandle} />
            </div>
        );
    }
}
