# AlbaPizzaApp

> **Nota**: No realicé el FrontEnd con WindowsForm ya que hace algunos años que no lo uso. Además, no pude completar la autenticación JWT. Sin embargo, dediqué todo mi empeño a la parte del backend, estructurando el proyecto con arquitectura limpia y aplicando las mejores prácticas.

## Descripción

AlbaPizzaApp es una aplicación de backend para la gestión de una pizzería, desarrollada con un enfoque en la arquitectura limpia y los principios SOLID. El proyecto está diseñado para ser modular, mantenible y extensible, utilizando patrones de diseño y tecnologías modernas.

## Estructura del Proyecto

El proyecto está estructurado en cuatro capas principales:

1. **Domain**: Contiene las entidades de negocio, agregados, eventos de dominio y lógica de negocio.
2. **Application**: Contiene los casos de uso (commands, queries) y la lógica de aplicación.
3. **Infrastructure**: Contiene la implementación de los repositorios, UnitOfWork, configuración de los ORMs (Entity Framework y Dapper) y otros servicios de infraestructura.
4. **API (Presentation)**: Contiene los controladores API y la configuración de la API.

## Patrones de Diseño Utilizados

- **Factory Pattern**: Para la creación de objetos complejos.
- **Repository**: Para la abstracción de las operaciones de datos.
- **UnitOfWork**: Para la gestión de transacciones.
- **CQRS**: Para la separación de comandos y consultas.

## Tecnologías Utilizadas

- **Entity Framework**: ORM principal para la gestión de datos.
- **Dapper**: Micro ORM utilizado para consultas eficientes.
- **MediatR**: Para la implementación de CQRS.
- **FluentValidation**: Para la validación de comandos y consultas.
- **FluentAssertions**: Para la creación de pruebas unitarias legibles y expresivas.
- **NetArchTest.Rules**: Para la validación de la arquitectura del proyecto.

## Instalación

1. Clona el repositorio:
    ```bash
    git clone https://github.com/tu-usuario/AlbaPizzaApp.git
    ```

2. Navega al directorio del proyecto:
    ```bash
    cd AlbaPizzaApp
    ```

3. Restaura los paquetes NuGet:
    ```bash
    dotnet restore
    ```

4. Aplica las migraciones de la base de datos:
    ```bash
    dotnet ef database update --project Infrastructure
    ```

5. Ejecuta el proyecto:
    ```bash
    dotnet run --project API
    ```

## Uso

### API Endpoints

#### Customers

- **GET** `/api/customers` - Obtener todos los clientes
- **GET** `/api/customers/{id}` - Obtener un cliente por ID
- **POST** `/api/customers` - Registrar un nuevo cliente
- **PUT** `/api/customers` - Actualizar un cliente existente
- **DELETE** `/api/customers/{id}` - Eliminar un cliente

#### Addresses

- **GET** `/api/addresses` - Obtener todas las direcciones
- **GET** `/api/addresses/{id}` - Obtener una dirección por ID
- **GET** `/api/addresses/by-customer/{customerId}` - Obtener direcciones por ID de cliente
- **POST** `/api/addresses` - Registrar una nueva dirección
- **PUT** `/api/addresses` - Actualizar una dirección existente
- **DELETE** `/api/addresses/{id}` - Eliminar una dirección

#### Orders

- **GET** `/api/orders` - Obtener todas las órdenes
- **GET** `/api/orders/{id}` - Obtener una orden por ID
- **GET** `/api/orders/by-customer/{customerId}` - Obtener órdenes por ID de cliente
- **POST** `/api/orders` - Registrar una nueva orden
- **PUT** `/api/orders` - Actualizar una orden existente
- **PUT** `/api/orders/confirm` - Confirmar una orden
- **PUT** `/api/orders/cancel` - Cancelar una orden

#### Order Details

- **GET** `/api/orderdetails/by-order/{orderId}` - Obtener detalles de la orden por ID de la orden
- **POST** `/api/orderdetails` - Registrar un nuevo detalle de la orden
- **PUT** `/api/orderdetails` - Actualizar un detalle de la orden existente
- **DELETE** `/api/orderdetails/{id}` - Eliminar un detalle de la orden

## Pruebas

Las pruebas unitarias y de integración se encuentran en el proyecto `Tests`. Se utilizan `FluentAssertions` para asegurar la legibilidad y expresividad de las pruebas.

Ejecuta las pruebas con el siguiente comando:
```bash
dotnet test
