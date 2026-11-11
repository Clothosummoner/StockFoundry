using StockFoundry;
string prompt = "Bitte geben Sie die Anzahl der Artikel ein: ";
List<Item> items = new List<Item>
{
    new Item { Name = "Artikel A", Number = 1, Stock = 10, MinimumStock = 5, Price = 9.99m },
    new Item { Name = "Artikel B", Number = 2, Stock = 20, MinimumStock = 10, Price = 19.99m },
    new Item { Name = "Artikel C", Number = 3, Stock = 5, MinimumStock = 2, Price = 29.99m }
};

bool running = true;
while (running)
{
    Console.WriteLine();
    Console.WriteLine("Bitte wählen Sie eine Option:");
    Console.WriteLine("1. Wareneingang");
    Console.WriteLine("2. Warenausgang");
    Console.WriteLine("3. Lagerbestand prüfen");
    Console.WriteLine("0. Beenden");
    Console.Write("Ihre Auswahl: ");
    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Wareneingang");
            Item? incomingItem = SelectItem();
            if (incomingItem != null)
            {
                int incoming = ReadPositiveNumber(prompt);
                incomingItem.Stock += incoming;
                Console.WriteLine($"Neuer Lagerbestand von {incomingItem.Name}: {incomingItem.Stock}");
            }
            break;
        case "2":
            Console.WriteLine("Warenausgang");
            Item? outgoingItem = SelectItem();
            if (outgoingItem != null)
            {
                int outgoing = ReadPositiveNumber(prompt);
                if (outgoingItem.Stock >= outgoing)
                {
                    outgoingItem.Stock -= outgoing;
                    Console.WriteLine($"Neuer Lagerbestand nach Warenausgang von {outgoing} Stück: {outgoingItem.Stock}");
                }
                else
                {
                    Console.WriteLine("Nicht genug Bestand für Warenausgang.");
                }
                CheckMinimumStock(outgoingItem);
            }

            break;
        case "3":
            decimal totalValue = 0;
            foreach (Item item in items)
            {
                Console.WriteLine();
                ShowStockDetails(item);
                CheckMinimumStock(item);
                totalValue += item.Stock * item.Price;
            }
            Console.WriteLine();
            Console.WriteLine($"Gesamtwert des Lagerbestands: {totalValue:C}");
            break;
        case "0":
            running = false;
            break;
        default:
            Console.WriteLine("Ungültige Auswahl. Bitte wählen Sie 1, 2, 3 oder 0.");
            break;
    }

}
Console.WriteLine("Programm beendet.");

void CheckMinimumStock(Item item)
{
    if (item.Stock <= item.MinimumStock)
    {
        Console.WriteLine("Warnung: Mindestbestand erreicht oder unter Mindestbestand!");
    }
    else
    {
        Console.WriteLine("Lagerbestand ist ausreichend.");
    }
}
void ShowStockDetails(Item item)
{
    Console.WriteLine($"Artikelnummer: {item.Number}");
    Console.WriteLine($"Artikelname: {item.Name}");
    Console.WriteLine($"Lagerbestand: {item.Stock}");
    Console.WriteLine($"Mindestbestand: {item.MinimumStock}");
    Console.WriteLine($"Preis: {item.Price:C}");
}
Item? SelectItem()
{  
    Console.WriteLine("Vorhandene Artikel:");
    foreach (Item item in items)
    {
        Console.WriteLine($"{item.Number}: {item.Name}");

    }
    int number = ReadPositiveNumber("Bitte geben Sie die Artikelnummer ein: ");
    foreach (Item item in items)
    {
        if (item.Number == number)
        {
            return item;
        }
    }
    Console.WriteLine("Kein Artikel mit dieser Nummer gefunden.");
    return null;
}
int ReadPositiveNumber(string prompt)
{
    int number;
    do
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (!int.TryParse(input, out number) || number <= 0)
        {
            Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine positive Zahl ein.");
        }
    } while (number <= 0);
    return number;
}
