import React, { Component } from 'react';
import { LibroABM } from './LibroABM';
import { CajaTexto } from "../ComponentesGenerales/CajaTexto";
import { BusquedaLibros } from "./BusquedaLibros";
import { Libro } from "../../Clases/Libro";

export class LibroScreen extends Component {
    constructor(props) {
        super(props);
        this.state = {
            currentCount: 0,
            libro: this.props.Libro,
            libroExterno: (this.props.Libro != null),
            nuevo: false,
            modificando: false,
            libros: null,
            busqueda: false,

            //camposBusqueda
            idBusqueda: 0,
            isbnBusqueda: "",
            tituloBusqueda: ""
        };

        this.handleCambioID = this.handleCambioID.bind(this);
        this.handleCambioISBN = this.handleCambioISBN.bind(this);
        this.handleCambioTitulo = this.handleCambioTitulo.bind(this);

        this.buscarLibro = this.buscarLibro.bind(this);
        this.nuevoLibro = this.nuevoLibro.bind(this);
        this.librosEncontrados = this.librosEncontrados.bind(this);
        this.volverAtras = this.volverAtras.bind(this);

        this.editarLibro = this.editarLibro.bind(this);
        this.eliminarLibro = this.eliminarLibro.bind(this);
    }

    volverAtras = () => {
        this.setState({
            nuevo: false,
            busqueda: true,
            modificando: false
        });

        this.buscarLibro();
    }

    buscarLibro() {
        this.setState({
            busqueda: false
        });

        let data = {
            ISBN: this.state.isbnBusqueda,
            Titulo: this.state.tituloBusqueda,
            Activo: true
        };

        Libro.buscarLibro(data, this.librosEncontrados);
    }

    librosEncontrados = (listaLibros) => {
        console.log(listaLibros);

        this.setState({
            libros: listaLibros,
            busqueda: true,
            nuevo: false,
            modificando: false
        });
    }

    nuevoLibro() {
        this.setState({
            nuevo: true,
            busqueda: false,
            modificando: false,
            libro: {}
        });
    }

    editarLibro(objLibro) {
        this.setState({
            modificando: true,
            busqueda: false,
            nuevo: false,
            libro: objLibro
        });
    }

    eliminarLibro(objLibro) {
        console.log(objLibro);

        let eliminar = window.confirm("¿Estás seguro que deseas eliminar el libro " + objLibro.titulo + " ?");

        if (eliminar) {
            let data = {
                ID: objLibro.id,
                ISBN: objLibro.isbn,
                Titulo: objLibro.titulo,
                Subtitulo: objLibro.subtitulo,
                Idioma: objLibro.idioma,
                Autor: objLibro.autor,
                Tipo: objLibro.tipo,
                Editorial: objLibro.editorial,
                Coleccion: objLibro.coleccion,
                Descripcion: objLibro.descripcion,
                Precio: objLibro.precio,
                FechaPublicacion: objLibro.fechaPublicacion,
                CantPaginas: objLibro.cantPaginas
            }

            Libro.eliminarLibro(data, this.callbackEliminarLibro);
        }
    }

    callbackEliminarLibro = (data) =>  {
        if (data) {
            alert("Libro eliminado correctamente");

            this.buscarLibro();
        } else {
            alert("ERROR PIF PIM PUM COSO");
        }
    }

    handleCambioID(event) {
        this.setState({
            idBusqueda: event.target.value
        })
    }

    handleCambioISBN(event) {
        this.setState({
            isbnBusqueda: event.target.value
        })
    }

    handleCambioTitulo(event) {
        this.setState({
            tituloBusqueda: event.target.value
        })
    }

    render() {
        return (
            <div>
                <h1>Libro</h1>

                <p>Búsqueda de libros</p>

                <p aria-live="polite">Current count: <strong>{this.state.currentCount}</strong></p>

                {/*<p>ID Libro</p>*/}
                {/*<input type="text" id="txtIDLibro" value={this.state.idBusqueda} onChange={this.handleCambioID} />*/}

                {
                    !(this.state.nuevo || this.state.modificando) &&
                    <div>
                        <p>ISBN</p>
                        <input type="text" value={this.state.isbnBusqueda} onChange={this.handleCambioISBN}></input>

                        {/*<input type="text" id="txtISBNLibro" value={this.state.isbnBusqueda} onChange={this.handleCambioISBN} />*/}

                        <p>Título</p>
                        <input type="text" value={this.state.tituloBusqueda} onChange={this.handleCambioTitulo}></input>
                        {/*<input type="text" id="txtISBNLibro" value={this.state.isbnBusqueda} onChange={this.handleCambioTitulo} />*/}

                        <button className="btn btn-primary" onClick={this.buscarLibro}>Buscar</button>
                        <button className="btn btn-primary" onClick={this.nuevoLibro}>Nuevo</button>
                    </div>
                }
                

                {
                    (this.state.nuevo || this.state.modificando) &&
                    <LibroABM
                        libro={this.state.libro}
                        volverAtras={this.volverAtras}
                    ></LibroABM>
                }

                {
                    (this.state.busqueda && !(this.state.nuevo || this.state.modificando)) &&
                    <BusquedaLibros
                        listaLibros={this.state.libros}
                        Editar={this.editarLibro}
                        Eliminar={this.eliminarLibro}></BusquedaLibros>
                }
            </div>
        );
    }
}
