# C# Inventory Manager

Gestor educativo de inventario desde terminal, desarrollado con C# y .NET 8.

Conserva productos, existencias y precios en JSON local.

## Funciones actuales

- Crear, listar, buscar y eliminar productos.
- Cambiar existencias y precios.
- Listado alfabético y reportes de existencias bajas o agotadas.
- Resumen de productos, unidades, valor, precio promedio y productos agotados.
- Exportación CSV.

## Requisitos

.NET 8 SDK. Usa un SDK capaz de compilar el destino `net8.0` declarado por el proyecto.

## Instalación y uso

```bash
git clone https://github.com/DonMilo-22/CSharp-Inventory-Manager.git
cd CSharp-Inventory-Manager
dotnet run
```

## Menú

| Opción | Acción |
|---|---|
| `1` | Listar productos por nombre. |
| `2` | Agregar producto. |
| `3` | Aumentar o reducir existencias. |
| `4` | Eliminar por ID. |
| `5` | Consultar resumen. |
| `6` | Reporte de existencias menores o iguales al umbral elegido. |
| `7` | Buscar por nombre sin distinguir mayúsculas. |
| `8` | Exportar CSV. |
| `9` | Mostrar productos sin existencias. |
| `10` | Cambiar precio. |
| `0` | Salir. |

## Almacenamiento y límites

`inventory.json` e `inventory.csv` se escriben en el directorio de trabajo, no necesariamente junto al ejecutable. Los formatos monetarios y decimales dependen de la configuración regional del proceso. El promedio del resumen es por producto, sin ponderar unidades. El borrado es inmediato; no hay papelera, cuentas, concurrencia ni sincronización. Es un proyecto educativo, no un sistema comercial de inventario.

## Comprobaciones

`dotnet build` comprueba la compilación. Para revisar persistencia manualmente, agrega un producto ficticio y vuelve a iniciar desde la misma carpeta.

## Autor y licencia

Desarrollado por [DonMilo-22](https://github.com/DonMilo-22).

Licencia: MIT.

## Actualización 2026-10-12

- Added a menu option to rename an existing product.

## Actualización adicional 2026-10-12

- Product creation now warns when the same product name already exists in the inventory.

## Historial

Consulta [CHANGELOG.md](CHANGELOG.md) para ver las actualizaciones.

## Actualización 2026-10-14

- Product creation now rejects non-numeric quantity or price input instead of silently treating invalid input as zero.
