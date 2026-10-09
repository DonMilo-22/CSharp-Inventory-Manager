# 📦 C# Inventory Manager

> Small JSON-backed inventory manager built with .NET.

![C%23](https://img.shields.io/badge/C%23-.NET%208-512BD4?logo=dotnet&logoColor=white)
![JSON](https://img.shields.io/badge/storage-JSON-yellow)
![License](https://img.shields.io/badge/license-MIT-green)

Inventory Manager is a terminal CRUD application for products, quantities and prices. Changes are saved locally so inventory survives between runs.

## ✨ Features

- Add products
- List inventory
- Restock or remove units
- Delete products
- Inventory value calculation
- JSON persistence
- Input validation

## 🚀 Run

```bash
dotnet run
```

## 🧭 Menu

```text
1. List products
2. Add product
3. Change stock
4. Delete product
5. Inventory summary
0. Exit
```

## 🗃️ Storage

The program automatically creates `inventory.json` next to the application data.

## 🧠 What it demonstrates

C# records/classes, LINQ, JSON serialization, file I/O, input validation and CRUD operations.

## 🛠️ Requirements

.NET 8 SDK or newer.

## 📄 License

MIT.

## 🆕 Recent changes

### 2026-10-08

- Added a menu option to update the price of an existing product.

### 2026-10-07

- The main inventory list is now sorted alphabetically by product name.

### 2026-10-06

- Added an `Out of stock` menu option to list products with no remaining units.

### 2026-10-05

- Added an `Export CSV` menu option that writes the current inventory to `inventory.csv`.

### 2026-10-04

- Added a case-insensitive product search option to the inventory menu.

### Previous update

- Added a configurable low-stock report to quickly find products that need restocking.
