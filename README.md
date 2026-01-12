# 🧱 Arquitectura OrderService (.NET Web API)

Este README explica **paso a paso y en profundidad** cómo está
construido el proyecto **OrderService**, aplicando **Arquitectura
Hexagonal**, **Clean Architecture**, **SOLID**, y conceptos de
**programación imperativa y declarativa**, con el objetivo de que puedas
**entenderlo y replicarlo en cualquier otro proyecto**.

------------------------------------------------------------------------

## 🎯 Objetivo del Proyecto

Este proyecto sirve como:

-   Ejemplo real de arquitectura profesional
-   Base reutilizable para microservicios
-   Referencia para CoreERP
-   Guía práctica (no teórica) de buenas prácticas en .NET

------------------------------------------------------------------------

## 🧠 Principios Aplicados

-   Clean Architecture
-   Hexagonal Architecture (Ports & Adapters)
-   SOLID
-   Separación estricta de responsabilidades
-   EF Core solo en Infrastructure
-   Configuración externa (Docker + .env)

------------------------------------------------------------------------

## 📦 Estructura General de la Solución

    OrderService.sln
    │
    ├── OrderService.Api
    ├── OrderService.Application
    ├── OrderService.Domain
    ├── OrderService.Infrastructure
    │
    ├── docker-compose.yml
    ├── .env
    └── .gitignore

------------------------------------------------------------------------

## 🔁 Flujo Completo de una Request

1.  Cliente (Postman / Frontend) envía HTTP Request
2.  Controller recibe la request (API)
3.  Controller delega al caso de uso (Application)
4.  Caso de uso ejecuta reglas del dominio
5.  Repository (Infrastructure) accede a la DB
6.  Respuesta regresa hacia el cliente

```{=html}
<!-- -->
```
    HTTP → Controller → UseCase → Repository → EF → DB

**Importante:**\
El Controller **no contiene lógica de negocio**.

------------------------------------------------------------------------

## 🟦 OrderService.Domain (Dominio)

### Responsabilidad

Contiene la lógica de negocio pura.

### Incluye

-   Entidades
-   Value Objects
-   Reglas de negocio
-   Excepciones de dominio

### No incluye

-   EF Core
-   DTOs
-   Controllers
-   Infraestructura

```{=html}
<!-- -->
```
    Domain
    ├── Entities
    │   └── Order.cs
    ├── ValueObjects
    ├── Exceptions
    └── Common

**Regla de oro:**\
El dominio no depende de nadie.

------------------------------------------------------------------------

## 🟨 OrderService.Application (Casos de Uso)

### Responsabilidad

Define **qué hace el sistema**, no **cómo lo hace**.

### Incluye

-   Casos de uso
-   Interfaces (puertos)
-   DTOs
-   Validaciones

### No incluye

-   EF Core
-   SQL
-   Controllers

```{=html}
<!-- -->
```
    Application
    ├── Interfaces
    │   └── IOrderRepository.cs
    ├── UseCases
    │   ├── CreateOrder
    │   └── GetOrders
    ├── DTOs

------------------------------------------------------------------------

## 🟥 OrderService.Infrastructure (Implementaciones)

### Responsabilidad

Contiene los detalles técnicos.

### Incluye

-   EF Core
-   DbContext
-   Repositories
-   Migraciones
-   Configuración técnica

```{=html}
<!-- -->
```
    Infrastructure
    ├── Persistence
    │   ├── OrderDbContext.cs
    │   ├── Configurations
    │   └── Migrations
    ├── Repositories
    └── DependencyInjection.cs

**Aquí viven las migraciones EF Core.**

------------------------------------------------------------------------

## 🟩 OrderService.Api (Host)

### Responsabilidad

Orquesta la aplicación y expone la API.

### Incluye

-   Controllers
-   Program.cs
-   Configuración
-   Middlewares

```{=html}
<!-- -->
```
    Api
    ├── Controllers
    ├── Program.cs
    └── appsettings.json

------------------------------------------------------------------------

## 🧠 Programación Imperativa vs Declarativa

### Imperativa

Indicas **cómo** hacer algo paso a paso.

``` csharp
foreach (var order in orders)
{
    total += order.Total;
}
```

### Declarativa

Indicas **qué** quieres obtener.

``` csharp
var total = orders.Sum(o => o.Total);
```

### En este proyecto

-   Dominio → Imperativo (claridad)
-   Application → Mixto
-   Infrastructure → Declarativo (LINQ / EF)

------------------------------------------------------------------------

## ⚠️ Errores Comunes y Cómo Evitarlos

❌ Usar DbContext en Controllers\
✔ Usar repositorios

❌ Lógica de negocio en API\
✔ Lógica en Domain / Application

❌ EF Core en Domain\
✔ EF solo en Infrastructure

❌ Configuración hardcodeada\
✔ Variables de entorno

------------------------------------------------------------------------

## 🔄 Cómo Adaptar Esto a Otro Servicio

1.  Copia la estructura completa
2.  Cambia el nombre del servicio
3.  Crea nuevas entidades en Domain
4.  Define nuevos casos de uso
5.  Implementa repositorios
6.  Ajusta migraciones

**La arquitectura no cambia.**

------------------------------------------------------------------------

## 🐳 Docker y Variables de Entorno

### `.env`

    DB_HOST=db
    DB_PORT=1433
    DB_NAME=ordersdb
    DB_USER=sa
    DB_PASSWORD=123John@
    API_PORT=6011

### Beneficios

-   Configuración desacoplada
-   Fácil despliegue
-   Entornos consistentes

------------------------------------------------------------------------

## 🧠 Reglas de Oro Finales

-   Domain no depende de nadie
-   Application solo depende de Domain
-   Infrastructure implementa Application
-   API solo orquesta
-   EF Core solo en Infrastructure
-   Migraciones solo en Infrastructure

------------------------------------------------------------------------

## 🚀 Nivel Profesional

Esta arquitectura es utilizada en:

-   Microservicios reales
-   ERP empresariales
-   SaaS
-   CoreERP

------------------------------------------------------------------------

**Autor:** Jonathan Vallecillos\
**Proyecto:** OrderService\
**Nivel:** Enterprise / Production Ready
