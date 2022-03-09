# Katherine_Web
Proyecto de gestión de biblioteca usando .NET 6.0, React JS y SQL Server

Proyecto modular realizado usando ASP NET Core, mediante la creación de APIs, React JS para el consumo de esas APIs desde frontend, y SQL Server para el alojamiento de la base de datos.
Este proyecto se encuentra en pleno desarrollo, y se realizará sin usar herramientas del tipo de Entity Framework. La comunicación se hará a través de ADO.NET, mediante una biblioteca "Acceso a Datos" creada desde cero para este proyecto.

El objetivo es lograr un proyecto totalmente modular, con la capacidad de usar cualquier motor de base de datos (SQL y NoSQL), cualquier proveedor (o ninguno) de Facturación, y también de, a través de parámetros, desconectar o conectar funcionalidades según se requiera

La seguridad también es importante, por lo que se pretende implementar un sistema de tokens JWT (ahora mismo en proceso) con validación manual o usando Identity Framework (si es posible)

Pendientes:
- Modificaciones en las funciones callbacks (promesas)
- Pantalla de Login independiente
- Acceso a las APIs usando el token JWT generado
- Agregar estilos usando Tailwind
- Generar consola de pruebas
- Creación de tests unitarios
- Limpiar páginas generadas automáticamente
- Implementar algoritmos de hashing para el guardado de la contraseña en base de datos y otros intercambios de información sensible
