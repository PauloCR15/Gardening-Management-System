# Proyecto 3 - Gestión de Inventarios y Mantenimiento

## Descripción

Este proyecto es una aplicación web desarrollada en **.NET 7** que implementa un sistema de gestión de empleados, clientes, maquinaria (inventario), mantenimiento y reportes de proyecciones. Se diseñó como una mejora del **Proyecto 2**, incorporando nuevas funcionalidades y una estructura mejorada.

El sistema está compuesto por un sitio web basado en el patrón **MVC** y servicios RESTful **Web API**, utilizando **programación orientada a objetos** y una base de datos **SQL Express**.

---

## Funcionalidades principales

### CRUD y búsqueda
- **Empleados:** Crear, leer, actualizar y eliminar empleados. Permite realizar búsquedas por nombre y puesto.
- **Clientes:** Crear, leer, actualizar y eliminar clientes. Incluye búsquedas por nombre, contacto y preferencias.
- **Maquinaria (Inventario):** Gestión completa del inventario de maquinaria, con seguimiento de disponibilidad y estado.
- **Mantenimiento:** Registro y seguimiento de los mantenimientos realizados.

### Reportes RESTful
El sistema incluye un servicio RESTful para generar dos reportes importantes, que son calculados y generados dinámicamente:
1. **Clientes a contactar la próxima semana:** Identifica los clientes que necesitan agendar un mantenimiento según la proyección.
2. **Clientes inactivos:** Muestra los clientes que no han agendado un mantenimiento en más de dos meses.

Estos reportes no se almacenan en la base de datos, sino que son generados por el sistema en función de los datos almacenados de clientes y mantenimientos.

---

## Detalles técnicos

### Herramientas y Tecnologías
- **Framework:** .NET 7
- **Lenguaje de programación:** C#
- **Patrón de diseño:** MVC (para el frontend) y RESTful (para el backend)
- **Base de datos:** SQL Express
- **IDE:** Visual Studio

### Estructura del proyecto
1. **Servicios Web API:** 
   - Gestión de datos mediante operaciones RESTful.
   - Intercambio de objetos como parámetros entre métodos.
2. **Base de Datos:**
   - Estructura diseñada hasta la segunda forma normal (2NF).
   - Tablas para empleados, clientes, maquinaria, mantenimiento.
3. **Frontend MVC:**
   - Navegación completa entre las páginas de la aplicación.
   - Diseño intuitivo para la interacción con las funcionalidades del sistema.

### Requisitos adicionales
- El sistema es ejecutable únicamente en el servidor virtual asignado.
- Se incluye el script de creación de la base de datos para garantizar la replicación del proyecto. El script debe ser ejecutado para crear la base de datos y las tablas necesarias.

---

## Instrucciones para la ejecución

1. **Descarga y descomprime el archivo del proyecto**:
   - Nombre del archivo: `Proyecto3-PauloPicadoCalderon.zip`.
2. **Configura la base de datos**:
   - Ejecuta el script de creación de la base de datos `EmpresaJardineria_Script.sql` para crear las tablas y relaciones necesarias.
3. **Ejecuta el proyecto**:
   - Abre la solución en Visual Studio.
   - Configura la conexión a la base de datos en el archivo `appsettings.json`.
   - Ejecuta la aplicación en modo **IIS Express**.
4. **Accede a la aplicación**:
   - Utiliza el navegador para navegar por las distintas páginas y probar las funcionalidades.

---

## Script de Creación de la Base de Datos

El script de creación de la base de datos se incluye en el archivo `EmpresaJardineria_Script.sql`. Este script crea las tablas necesarias y establece las relaciones entre ellas para que el sistema funcione correctamente.

---

## Video demostrativo

Se incluye un video explicativo dentro del servidor virtual en la carpeta `Proyecto3`. Este video muestra:
- Configuración inicial.
- Navegación por el sitio web.
- Pruebas de los servicios RESTful.
- Ejecución de los reportes.

---

## Repositorio

El código fuente completo del proyecto está disponible en el siguiente enlace de GitHub:

[Repositorio del Proyecto 3](https://github.com/PauloCR15/Tarea-3-Fundamentos-Programacion.git)

---

## Autor

**Paulo Picado Calderón**  
Ingeniero en informática  
Proyecto presentado para la asignatura: **Fundamentos de Programación Web 03075**
