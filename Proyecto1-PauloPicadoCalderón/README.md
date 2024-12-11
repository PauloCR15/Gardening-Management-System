# Proyecto 1 - Jardinería Hermanos Hernández

## Índice

1. [Descripción General](#descripción-general)
2. [Funcionalidades](#funcionalidades)
   - [Gestión de empleados](#gestión-de-empleados)
   - [Gestión de maquinaria](#gestión-de-maquinaria)
   - [Gestión de clientes](#gestión-de-clientes)
   - [Gestión de mantenimientos](#gestión-de-mantenimientos)
3. [Tecnologías Utilizadas](#tecnologías-utilizadas)
4. [Estructura del Proyecto](#estructura-del-proyecto)
5. [Instrucciones para Ejecutar el Proyecto](#instrucciones-para-ejecutar-el-proyecto)
6. [Limitaciones](#limitaciones)
7. [Autor](#autor)
8. [Licencia](#licencia)

## Descripción General

Este proyecto consiste en un sistema web diseñado para la Microempresa de Jardinería Hermanos Hernández. El sistema permite gestionar empleados, maquinarias, clientes y mantenimientos de propiedades, utilizando el patrón de diseño MVC y Programación Orientada a Objetos (POO) en C# con .NET 7. Los datos son almacenados temporalmente en variables de aplicación, sin persistencia en bases de datos, lo que significa que se perderán al cerrar la aplicación.

## Funcionalidades

### Gestión de empleados
   - Crear, leer, actualizar, eliminar y buscar empleados.
   - Datos manejados: cédula, fecha de nacimiento, lateralidad (diestro/zurdo), fecha de ingreso a la empresa, salario por hora.

### Gestión de maquinaria
   - Crear, leer, actualizar, eliminar y buscar maquinarias.
   - Datos manejados: ID del inventario, descripción, tipo de maquinaria, horas de uso actuales, horas de uso máximo al día, horas de uso para dar mantenimiento.

### Gestión de clientes
   - Crear, leer, actualizar, eliminar y buscar clientes.
   - Datos manejados: identificación, nombre completo, dirección completa (provincia, cantón, distrito, dirección exacta), preferencia de mantenimiento en invierno y verano (quincenal o mensual).

### Gestión de mantenimientos
   - Crear, leer, actualizar, eliminar y buscar mantenimientos.
   - Datos manejados: ID del mantenimiento, ID del cliente, fechas de ejecutado y agendado, cantidad de metros cuadrados de propiedad y cerca viva, días sin chapia (calculado automáticamente), fecha aproximada de la próxima chapia, tipo de zacate, aplicación de productos, costos calculados de chapia y aplicación de productos, estado del mantenimiento.

## Tecnologías Utilizadas

- **Lenguaje de programación**: C#
- **Framework**: .NET 7
- **Patrón de diseño**: MVC (Modelo-Vista-Controlador)
- **Entorno de desarrollo**: Visual Studio 2022
- **Almacenamiento temporal**: Variables de aplicación (sin persistencia en base de datos)
- **Estilo y maquetación**:
   - **SASS** con **SCSS**
   - **Bootstrap**
   - **JavaScript**

## Estructura del Proyecto

El proyecto sigue la estructura básica del patrón MVC:

- **Models**: Define las clases para empleados, maquinarias, clientes y mantenimientos.
- **Controllers**: Maneja la lógica de negocio y las operaciones CRUD para cada entidad.
- **Views**: Contiene las páginas web que permiten la interacción con el usuario, utilizando SASS, Bootstrap y JavaScript para la maquetación y estilo.

## Instrucciones para Ejecutar el Proyecto

1. **Requisitos previos**:
   - Visual Studio 2022 instalado.
   - .NET 7 SDK instalado.

2. **Pasos para ejecutar**:
   - Clona el repositorio o descomprime el archivo ZIP del proyecto.
   - Abre el proyecto en Visual Studio 2022.
   - Ejecuta la aplicación.
   - Navega por el sistema para gestionar empleados, maquinarias, clientes y mantenimientos.

## Limitaciones

- Los datos no se almacenan de forma persistente; se guardan temporalmente en variables de aplicación y se pierden al cerrar la aplicación.
- Solo un usuario puede interactuar con el sistema en esta primera versión.

## Autor

- **Nombre**: Paulo Picado Calderón 
- **Universidad**: Universidad Estatal a Distancia
- **Escuela**: Vicerrectoría de Docencia - Escuela de Ciencias Exactas y Naturales
- **Cátedra**: Ingeniería de Software - Fundamentos de Programación Web 03075
- **Proyecto**: Proyecto 1 - Valor 30% (3.0)

## Licencia

Este proyecto ha sido desarrollado para fines educativos y no está disponible bajo una licencia específica.

## Repositorio

Puedes encontrar el repositorio del proyecto [aquí](https://github.com/PauloCR15/Tarea-1-Fundamentos-Programacion.git).

## Perfil de GitHub

Visita mi perfil de GitHub [aquí](https://github.com/PauloCR15).
