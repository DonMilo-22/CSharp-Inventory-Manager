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
