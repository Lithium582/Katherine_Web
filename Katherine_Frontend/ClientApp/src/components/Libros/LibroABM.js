import React, { Component } from 'react';
import { Libro } from "../../Clases/Libro";

export class LibroABM extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            idBusqueda: 0,
            libro: this.props.libro,
            volverAtras: this.props.volverAtras,
            textoBoton: "Insertar"
        }

        this.handleCambioISBN = this.handleCambioISBN.bind(this);
        this.handleCambioTitulo = this.handleCambioTitulo.bind(this);
        this.handleCambioSubtitulo = this.handleCambioSubtitulo.bind(this);
        this.handleCambioIdioma = this.handleCambioIdioma.bind(this);
        this.handleCambioDescripcion = this.handleCambioDescripcion.bind(this);
        this.handleCambioAutor = this.handleCambioAutor.bind(this);
        this.handleCambioTipo = this.handleCambioTipo.bind(this);
        this.handleCambioEditorial = this.handleCambioEditorial.bind(this);
        this.handleCambioColeccion = this.handleCambioColeccion.bind(this);
        this.handleCambioPrecio = this.handleCambioPrecio.bind(this);
        this.handleCambioCantPaginas = this.handleCambioCantPaginas.bind(this);
        this.handleCambioFechaPublicacion = this.handleCambioFechaPublicacion.bind(this);

        this.insertarLibro = this.insertarLibro.bind(this);
    }

    componentDidMount() {
        this.cargarDatosLibros();
    }

    cargarDatosLibros() {
        this.setState(
            {
                idLibro: this.state.libro.id,
                ISBN: this.state.libro.isbn,
                Titulo: this.state.libro.titulo,
                Subtitulo: this.state.libro.subtitulo,
                Idioma: this.state.libro.idioma,
                Descripcion: this.state.libro.descripcion,
                Autor: this.state.libro.autor,
                Tipo: this.state.libro.tipo,
                Editorial: this.state.libro.editorial,
                Coleccion: this.state.libro.coleccion,
                Precio: this.state.libro.precio,
                CantPaginas: this.state.libro.cantPaginas,
                FechaPublicacion: this.state.libro.fechaPublicacion,
                Activo: this.state.libro.activo
            }
        );

        if (this.state.libro != null) {
            this.setState({
                textoBoton: "Modificar",
            })
        }
    }

    insertarLibro() {
        let data = {
            ID: (this.state.idLibro || -1),
            ISBN: this.state.ISBN,
            Titulo: this.state.Titulo,
            Subtitulo: this.state.Subtitulo,
            Idioma: this.state.Idioma,
            Autor: this.state.Autor,
            Tipo: this.state.Tipo,
            Editorial: this.state.Editorial,
            Coleccion: this.state.Coleccion,
            Descripcion: this.state.Descripcion,
            Precio: this.state.Precio,
            FechaPublicacion: this.state.FechaPublicacion,
            CantPaginas: this.state.CantPaginas,
            Activo: (this.state.activo || true)
        }

        console.log("LIBRITO", data);

        Libro.insertarLibro(data, this.callbackInsertarLibro);
    }

    callbackInsertarLibro = (data) => {
        if (data) {
            alert("Libro guardado correctamente");

            this.state.volverAtras();
        } else {
            alert("ERROR PIF PIM PUM COSO");
        }
    }

    handleCambioISBN(event) {
        this.setState({
            ISBN: event.target.value
        })
    }

    handleCambioTitulo(event) {
        this.setState({
            Titulo: event.target.value
        })
    }

    handleCambioSubtitulo(event) {
        this.setState({
            Subtitulo: event.target.value
        })

    }

    handleCambioIdioma(event) {
        this.setState({
            Idioma: event.target.value
        })
    }

    handleCambioDescripcion(event) {
        this.setState({
            Descripcion: event.target.value
        })
    }

    handleCambioAutor(event) {
        this.setState({
            Autor: event.target.value
        })
    }

    handleCambioTipo(event) {
        this.setState({
            Tipo: event.target.value
        })
    }

    handleCambioEditorial(event) {
        this.setState({
            Editorial: event.target.value
        })
    }

    handleCambioColeccion(event) {
        this.setState({
            Coleccion: event.target.value
        })
    }

    handleCambioPrecio(event) {
        this.setState({
            Precio: event.target.value
        })
    }

    handleCambioCantPaginas(event) {
        this.setState({
            CantPaginas: event.target.value
        })
    }

    handleCambioFechaPublicacion(event) {
        this.setState({
            FechaPublicacion: event.target.value
        })
    }

    render() {
        return (
            <div>
                <h1>Libro</h1>
                
                <p>{ this.state.textoBoton } libro</p>

                <table>
                    <tbody>
                        <tr>
                            <td>
                                <p>ISBN</p>
                            </td>
                            <td>
                                <input type="text" id="txtISBN" value={this.state.ISBN} onChange={this.handleCambioISBN} />
                            </td>

                            <td>
                                <p>Título</p>
                            </td>
                            <td>
                                <input type="text" id="txtTitulo" value={this.state.Titulo} onChange={this.handleCambioTitulo} />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Subtitulo</p>
                            </td>
                            <td>
                                <input type="text" id="txtSubtitulo" value={this.state.Subtitulo} onChange={this.handleCambioSubtitulo} />
                            </td>

                            <td>
                                <p>Idioma</p>
                            </td>
                            <td>
                                <input type="text" id="txtIdioma" value={this.state.Idioma} onChange={this.handleCambioIdioma} />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Descripción</p>
                            </td>
                            <td>
                                <input type="textarea" id="txtDescripcion" value={this.state.Descripcion} onChange={this.handleCambioDescripcion} />
                            </td>

                            <td>
                                <p>Autor</p>
                            </td>
                            <td>
                                <input type="text" id="txtAutor" value={this.state.Autor} onChange={this.handleCambioAutor} />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Tipo</p>
                            </td>
                            <td>
                                <input type="text" id="txtTipo" value={this.state.Tipo} onChange={this.handleCambioTipo} />
                            </td>

                            <td>
                                <p>Editorial</p>
                            </td>
                            <td>
                                <input type="text" id="txtEditorial" value={this.state.Editorial} onChange={this.handleCambioEditorial} />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Colección</p>
                            </td>
                            <td>
                                <input type="text" id="txtColeccion" value={this.state.Coleccion} onChange={this.handleCambioColeccion} />
                            </td>

                            <td>
                                <p>Precio</p>
                            </td>
                            <td>
                                <input type="text" id="txtPrecio" value={this.state.Precio} onChange={this.handleCambioPrecio} />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>Cant. Páginas</p>
                            </td>
                            <td>
                                <input type="text" id="txtCantPaginas" value={this.state.CantPaginas} onChange={this.handleCambioCantPaginas} />
                            </td>
                            <td>
                                <p>Fecha de Publicación</p>
                            </td>
                            <td>
                                <input type="text" id="txtFechaPublicacion" value={this.state.FechaPublicacion} onChange={this.handleCambioFechaPublicacion} />
                            </td>
                        </tr>
                    </tbody>
                </table>
                {/*<p>ID Libro</p>*/}
                {/*<input type="text" id="txtIDLibro" value={this.state.idBusqueda} onChange={this.handleCambioID} />*/}

                <button className="btn btn-primary" onClick={this.insertarLibro}>{ this.state.textoBoton }</button>
                <button className="btn btn-primary" onClick={this.state.volverAtras}>VOLVER</button>
            </div>
        );
    }
}
