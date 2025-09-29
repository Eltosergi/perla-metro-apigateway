# 🚉 Perla Metro - API Main (API Gateway)

## 📋 Descripción

La **API Main** actúa como el **orquestador central** del sistema Perla Metro, implementando un **API Gateway** que coordina todas las comunicaciones entre los microservicios y gestiona la seguridad mediante autenticación JWT y autorización por roles.

Este componente es fundamental en la arquitectura SOA implementada, sirviendo como punto único de entrada para todas las solicitudes del sistema.

---

## 🏗️ Arquitectura del Sistema

### Arquitectura SOA (Service-Oriented Architecture)
El sistema sigue una **arquitectura de monolito distribuido con SOA**, donde:

- **Separación de responsabilidades**: Cada servicio gestiona su dominio específico
- **Independencia tecnológica**: Cada servicio puede usar diferentes bases de datos y tecnologías
- **Comunicación estandarizada**: Todos los servicios se comunican mediante APIs REST
- **Centralización de seguridad**: La API Main gestiona autenticación y autorización

---

## 🎯 Patrones de Diseño Implementados (en la API Main)

### 1. **API Gateway Pattern**
- **Propósito**: Punto único de entrada para todas las solicitudes
- **Implementación**: Ocelot como gateway que enruta requests a los microservicios apropiados
- **Beneficios**: Simplifica el cliente, centraliza cross-cutting concerns

### 2. **Service Orchestration**
- **Propósito**: Coordinar llamadas entre múltiples servicios
- **Implementación**: API Main orquesta la comunicación entre Users, Tickets, Routes y Stations Services
- **Beneficios**: Mantiene consistencia y maneja flujos transaccionales complejos


---

## 📡 Endpoints Disponibles


### 👥 Users Service
```http
POST /user/register
POST /user/login
GET /user/all
GET /user/{id}
DELETE /user/{id}
PUT /user/Update
GET /DeleteHistorial
```

### 🎫 Tickets Service
```http
GET /api/tickets
GET /api/tickets/{id}
POST /api/tickets
PUT /api/tickets/{id}
DELETE /api/tickets/{id}
GET /tickets/health
```

### 🛤️ Routes Service
```http
TBD
```

### 🚉 Stations Service
```http
GET    /stations
GET    /stations/{id}
POST   /stations
PUT    /stations/{id}
DELETE /stations/{id}
```

Los endpoints se encuentran más detallados en el **[Manual de usuario](https://drive.google.com/file/d/1CDDhkeJxtLfps_gMXVOf-LqP1Wp3ixn8)**

---

## 🚀 Instalación y Configuración

### Prerrequisitos
- .NET 9.0

### Ejecución Local
```bash
# Clonar repositorio
git clone https://github.com/Eltosergi/perla-metro-apigateway.git
cd perla-metro-apigateway

# Restaurar dependencias
dotnet restore

# Ejecutar aplicación
dotnet run
```

En caso de querer ejecutar todos los servicios de forma local, modifique las URL de todos los servicios en el archivo `Ocelot.json`.

---

## 📝 Ejemplos de Uso

### Registro de Usuario
```http
POST /user/register
Content-Type: application/json

{
  "name": "Juan",
  "lastName": "Pérez",
  "email": "juan.perez@perlametro.cl",
  "password": "SecurePass123!",
  "confirmPassword": "SecurePass123!"
}
```

### Login
```http
POST /user/login
Content-Type: application/json

{
  "email": "juan.perez@perlametro.cl",
  "password": "SecurePass123!"
}
```

### Consulta de Estaciones (requiere autenticación)
```http
GET /stations
Authorization: Bearer <tu-token-jwt>
```

---

## 🔗 Enlaces a Repositorios

- **API Main**: [https://github.com/Eltosergi/perla-metro-apigateway](https://github.com/Eltosergi/perla-metro-apigateway)
- **Users Service**: [https://github.com/Eltosergi/perla-metro-userService](https://github.com/Eltosergi/perla-metro-userService)
- **Tickets Service**: [https://github.com/RonaldoMorales/perla-metro-tickets-service](https://github.com/RonaldoMorales/perla-metro-tickets-service)
- **Routes Service**: [https://github.com/Rexwar/perla-metro-route-service](https://github.com/Rexwar/perla-metro-route-service)
- **Stations Service**: [https://github.com/danukaz/perla-metro-stations-service](https://github.com/danukaz/perla-metro-stations-service)

---

## 👨‍💻 Equipo de Desarrollo

- **Sergio Parada** - Users Service
- **Ronaldo Morales** - Tickets Service  
- **Rey Valdés** - Routes Service
- **Daniel Tomigo** - Stations Service
- **Colaboración colectiva** en API Main

---

## 📄 Licencia

Este proyecto es desarrollado para fines académicos en el contexto del Taller de Arquitectura de Sistemas de la Universidad Católica del Norte.

---


