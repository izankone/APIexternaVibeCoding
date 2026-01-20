# 📜 Bitácora de Decisiones Técnicas: API Externa Vibe Coding

Este documento detalla el proceso de resolución de problemas y las decisiones de arquitectura tomadas para el desarrollo de la API en .NET 8.

## 🛠 1. Arquitectura y Modelado
**Decisión:** Se implementó un patrón de repositorio con separación de modelos de datos (Models) y objetos de transferencia (DTOs).
**Justificación:** - Los **Models** representan las tablas físicas en SQLite.
- Los **DTOs** aseguran que la API solo exponga los datos necesarios, desacoplando la base de datos de la respuesta JSON enviada al cliente.

## 📦 2. Gestión de Dependencias y Versiones
**Decisión:** Se forzó la instalación de los paquetes `Microsoft.EntityFrameworkCore.Sqlite` y `Design` en su versión **8.0.0**.
**Justificación:** - Se detectó un error **NU1202** al intentar instalar versiones para .NET 10 en un entorno de .NET 8.
- La consistencia de versiones evita errores de restauración y asegura la compatibilidad con el SDK local.

## 🔧 3. Resolución de Errores de Compilación Críticos

### Error CS0738: Implementación de Interfaz
- **Problema:** El repositorio devolvía modelos de base de datos en lugar de DTOs.
- **Solución:** Se ajustaron las firmas de los métodos `GetExternalUsersAsync` y `GetExternalPostsAsync` para que coincidan con la interfaz `IApiRepository`.

### Error CS1061 y CS0718: Configuración del Contexto
- **Problema:** El sistema no reconocía `.UseSqlite()` y rechazaba la clase estática `AppContext`.
- **Solución:** - Se añadió la directiva `using Microsoft.EntityFrameworkCore;`.
  - Se sustituyó `AppContext` por la clase de contexto personalizada **`AppDbContext`**.

### Error CS0246: Ámbito y Visibilidad
- **Problema:** `Program.cs` no encontraba la clase `AppDbContext` a pesar de existir en el proyecto.
- **Solución:** Se añadió el espacio de nombres `using APIExternaVibeCoding.Data;`, vinculando correctamente la capa de datos con el punto de entrada de la aplicación.

## 🗄️ 4. Persistencia de Datos
**Decisión:** Uso de Entity Framework Core Migrations para generar el archivo `mi_api.db`.
**Justificación:** - Las migraciones permiten llevar un control de versiones del esquema de la base de datos.
- El comando `dotnet ef database update` materializa la infraestructura necesaria para la persistencia local.

## 🌐 5. Verificación de Endpoints
**Decisión:** Configuración de Swagger UI como interfaz principal de pruebas.
**Justificación:** - Permite validar de forma visual que los controladores (`ExternalDataController`) están inyectando correctamente el repositorio y consumiendo la API externa.
- Se corrigieron errores 404 asegurando que el usuario acceda a la ruta `/swagger` o `/api/ExternalData/users`.

---
*Documento generado como parte de la práctica de Vibe Coding - 2026.*