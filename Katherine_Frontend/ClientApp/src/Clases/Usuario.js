class Usuario {
    static token = "";
    static Login(usuario, password, callback) {
        let data = {
            Usuario: usuario,
            Password: password
        };

        fetch(
            'https://localhost:5021/Autenticacion/Login',
            {
                method: "PUT",
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(data)
            }
        ).then(response => response.json())
            .then(data =>
                callback(data)
            );
    }
}

export { Usuario }