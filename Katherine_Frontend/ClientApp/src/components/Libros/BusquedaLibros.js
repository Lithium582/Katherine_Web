import React, { Component } from 'react';
import { BotonBusquedaLibros } from './BotonBusquedaLibros';

export class BusquedaLibros extends Component {
    constructor(props) {
        super(props);

        this.state = {
            Libros: props.listaLibros,
            LogicaEditar: props.Editar,
            LogicaEliminar: props.Eliminar
        };
    }

    render() {
        return (
            <div>
                <table>
                    <thead>
                        <tr>
                            <th>Título</th>
                            <th>ISBN</th>
                            <th>Subtitulo</th>
                            <th>Autor</th>
                            <th>Precio</th>
                            <th>Cantidad Páginas</th>
                            <th colspan="2">Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            this.state.Libros.map((e, i) => {
                                return [
                                    <tr key={i}>
                                        <td>
                                            {e.titulo}
                                        </td>
                                        <td>
                                            {e.isbn}
                                        </td>
                                        <td>
                                            {e.subtitulo}
                                        </td>
                                        <td>
                                            {e.autor}
                                        </td>
                                        <td>
                                            {e.precio}
                                        </td>
                                        <td>
                                            {e.cantPaginas}
                                        </td>
                                        <td>
                                            <BotonBusquedaLibros
                                                libro={e}
                                                onButtonClick={this.state.LogicaEditar}
                                                textoBoton={"Editar"}>
                                            </BotonBusquedaLibros>
                                        </td>
                                        <td>
                                            <BotonBusquedaLibros
                                                libro={e}
                                                onButtonClick={this.state.LogicaEliminar}
                                                textoBoton={"Eliminar"}>
                                            </BotonBusquedaLibros>
                                        </td>
                                    </tr>
                                ];
                            })
                        }
                    </tbody>
                </table>
            </div>
        );
    }
}
