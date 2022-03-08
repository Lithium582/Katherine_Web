class Libro {
    static buscarLibro (parametro, callback) {
        fetch(
            'https://localhost:5021/Libros/GetLibros',
            {
                method: "PUT",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametro)
            }
        ).then(response => response.json())
            .then(data =>
                callback(data)
            );
    }

    static eliminarLibro(parametro, callback) {
        fetch(
            'https://localhost:5021/Libros/EliminarLibro',
            {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametro)
            }
        ).then(response => response.json())
            .then(data => {
                callback(data);
            });
    }

    static insertarLibro(parametro, callback) {
        fetch(
            'https://localhost:5021/Libros/AltaLibro',
            {
                method: "POST",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(parametro)
            }
        ).then(response => response.json())
            .then(data => {
                console.log(data);

                callback(data);
            });
    }


    
}

export { Libro }