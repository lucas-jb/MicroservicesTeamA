# Proyecto Microservices Team A

Un proyecto WebApi de gestión de proveedores, compras y productos.
En lenguaje C# utilizando .NET Core 6.0.

## Integrantes

**Equipo A** conformado por **Lucas**, **Airam**, **Enrique**, **Jose Alejandro**, **Dayana**, **Illia** y **Pablo**.

## Estructura del proyecto

La solución está formada por cuatro proyectos:

- Productos
- Proveedores
- Compras
- PruebaSearch

## Descripción del funcionamiento

1. Mediante repositorios Fake, los servicios Productos, Proveedores y compras, generan instancias de cada uno de ellos.
2. El proyecto PruebaSearch realiza las peticiones a los otros servicios y recupera los datos.
