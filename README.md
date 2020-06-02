# MantenimientoAccidente
Manejo de Controles de Formulario

El proyecto ASP.NET Web Forms requiere de .Net Framework 4.7.2 usando SQL como motor de pases de datos

Query de Bases de Datos:
-------------------------
```
create database crudaccidente
go
use crudaccidente
go
create table accidente(
	id int primary key not null identity(1,1),
	nombre varchar(30) not null,
	apellido varchar(30) not null,
	edad int not null,
	sexo int check(sexo = 0 or sexo = 1) not null,
	accidente date not null,
	estado int check(estado = 0 or estado = 1) not null,
	foto text not null,
	lesion varchar(4) not null,
	direccion varchar(250),
	detalle text
)
```
Configuración de la Conexión a Bases de Datos:
-----------------------------------
Abra el archivo MantenimientoAccidente/MantenimientoAccidente/DatabaseOPS.cs
En la clase Conexion, ubicar la linea que contiene la cadena de conexion, y modificar a conveniencia.
```
private SqlConnection conn = new SqlConnection("Server=JC-STATION;DataBase=crudaccidente;Integrated Security=true");
```
