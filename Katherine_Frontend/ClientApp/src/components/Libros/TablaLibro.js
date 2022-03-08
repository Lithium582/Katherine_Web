import React, { Component } from 'react';

export class TablaLibro extends Component {
    constructor(props) {
        super(props);
        this.state = {
            ID: props.id,
            ISBN: props.isbn,
            Titulo: props.titulo,
            Subtitulo: props.subtitulo,
            Idioma: props.idioma,
            Autor: props.autor,
            Tipo: props.tipo,
            Editorial: props.editorial,
            Coleccion: props.coleccion,
            Descripcion: props.descripcion,
            Precio: props.precio,
            FechaPublicacion: props.fechapublicacion,
            CantPaginas: props.cantpaginas,
            VistaParcial: props.vistaparcial
        };
    }

    render() {
        return (
            <div>
                <table>
                    <tbody>
                        <tr>
                            <td>
                                Título
                            </td>
                            <td>
                                {this.state.Titulo}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                ISBN
                            </td>
                            <td>
                                {this.state.ISBN}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Subtitulo
                            </td>
                            <td>
                                {this.state.Subtitulo}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Idioma
                            </td>
                            <td>
                                {this.state.Idioma}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Autor
                            </td>
                            <td>
                                {this.state.Autor}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo
                            </td>
                            <td>
                                {this.state.Tipo}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Editorial
                            </td>
                            <td>
                                {this.state.Editorial}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Colección
                            </td>
                            <td>
                                {this.state.Coleccion}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Descripción
                            </td>
                            <td>
                                {this.state.Descripcion}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Fecha Publicación
                            </td>
                            <td>
                                {this.state.FechaPublicacion}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Precio
                            </td>
                            <td>
                                {this.state.Precio}
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Cantidad Páginas
                            </td>
                            <td>
                                {this.state.CantPaginas}
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        );
    }
}
