using System.Text.Json;

var file = "inventory.json";
var options = new JsonSerializerOptions { WriteIndented = true };
var products = File.Exists(file) ? JsonSerializer.Deserialize<List<Product>>(File.ReadAllText(file)) ?? new() : new List<Product>();

void Save() => File.WriteAllText(file, JsonSerializer.Serialize(products, options));
void ListItems() {
  Console.WriteLine("\nID   Product                      Qty     Price");
  Console.WriteLine("------------------------------------------------");
  foreach (var p in products.OrderBy(p => p.Name, StringComparer.OrdinalIgnoreCase)) Console.WriteLine($"{p.Id,-4} {p.Name,-28} {p.Quantity,5} {p.Price,9:C2}");
}

while (true) {
  Console.WriteLine("\nInventory Manager");
  Console.WriteLine("1. List products\n2. Add product\n3. Change stock\n4. Delete product\n5. Inventory summary\n6. Low-stock report\n7. Search products\n8. Export CSV\n9. Out of stock\n10. Change price\n0. Exit");
  Console.Write("> "); var choice = Console.ReadLine();
  if (choice == "0") break;
  if (choice == "1") ListItems();
  else if (choice == "2") {
    Console.Write("Name: "); var name = Console.ReadLine()?.Trim();
    Console.Write("Quantity: "); int.TryParse(Console.ReadLine(), out var qty);
    Console.Write("Price: "); decimal.TryParse(Console.ReadLine(), out var price);
    if (string.IsNullOrWhiteSpace(name) || qty < 0 || price < 0) { Console.WriteLine("Invalid data."); continue; }
    var id = products.Count == 0 ? 1 : products.Max(p => p.Id) + 1;
    products.Add(new Product(id,name,qty,price)); Save(); Console.WriteLine("Product added.");
  }
  else if (choice == "3") {
    Console.Write("Product ID: "); int.TryParse(Console.ReadLine(), out var id);
    var p = products.FirstOrDefault(x => x.Id == id); if (p is null) { Console.WriteLine("Not found."); continue; }
    Console.Write("Stock change (+/-): "); int.TryParse(Console.ReadLine(), out var delta);
    if (p.Quantity + delta < 0) { Console.WriteLine("Stock cannot be negative."); continue; }
    p.Quantity += delta; Save(); Console.WriteLine("Stock updated.");
  }
  else if (choice == "4") {
    Console.Write("Product ID: "); int.TryParse(Console.ReadLine(), out var id);
    var removed = products.RemoveAll(x => x.Id == id); if (removed > 0) { Save(); Console.WriteLine("Deleted."); } else Console.WriteLine("Not found.");
  }
  else if (choice == "5") {
    var units = products.Sum(p => p.Quantity); var value = products.Sum(p => p.Quantity * p.Price);
    Console.WriteLine($"Products: {products.Count} | Units: {units} | Inventory value: {value:C2}");
  }
  else if (choice == "10") {
    Console.Write("Product ID: "); int.TryParse(Console.ReadLine(), out var id);
    var p = products.FirstOrDefault(x => x.Id == id); if (p is null) { Console.WriteLine("Not found."); continue; }
    Console.Write("New price: "); decimal.TryParse(Console.ReadLine(), out var newPrice);
    if (newPrice < 0) { Console.WriteLine("Invalid price."); continue; }
    p.Price = newPrice; Save(); Console.WriteLine("Price updated.");
  }
  else if (choice == "9") {
    var empty = products.Where(p => p.Quantity == 0).ToList();
    if (empty.Count == 0) Console.WriteLine("All products are stocked.");
    else foreach (var p in empty) Console.WriteLine($"{p.Id}: {p.Name}");
  }
  else if (choice == "8") {
    var lines = new List<string> { "Id,Name,Quantity,Price" };
    lines.AddRange(products.Select(p => $"{p.Id},\"{p.Name.Replace("\"", "\"\"") }\",{p.Quantity},{p.Price}"));
    File.WriteAllLines("inventory.csv", lines);
    Console.WriteLine("Exported to inventory.csv");
  }
  else if (choice == "7") {
    Console.Write("Search name: "); var query = Console.ReadLine()?.Trim();
    if (string.IsNullOrWhiteSpace(query)) { Console.WriteLine("Enter a product name."); continue; }
    var matches = products.Where(p => p.Name.Contains(query, StringComparison.OrdinalIgnoreCase)).ToList();
    if (matches.Count == 0) Console.WriteLine("No matching products.");
    else foreach (var p in matches) Console.WriteLine($"{p.Id}: {p.Name} - {p.Quantity} unit(s)");
  }
  else if (choice == "6") {
    Console.Write("Low-stock threshold: "); int.TryParse(Console.ReadLine(), out var threshold);
    if (threshold < 0) threshold = 0;
    var low = products.Where(p => p.Quantity <= threshold).OrderBy(p => p.Quantity).ToList();
    if (low.Count == 0) Console.WriteLine("No low-stock products.");
    else foreach (var p in low) Console.WriteLine($"{p.Id}: {p.Name} - {p.Quantity} unit(s)");
  }
}

class Product(int id, string name, int quantity, decimal price) {
  public int Id { get; set; } = id;
  public string Name { get; set; } = name;
  public int Quantity { get; set; } = quantity;
  public decimal Price { get; set; } = price;
}
