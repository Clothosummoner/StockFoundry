int itemNumber = 12345;
string itemName = "Beispielartikel";
int stock = 100;
int minimumStock = 10;
decimal price = 19.99m;
decimal totalValue = 0;
string prompt = "Bitte geben Sie die Anzahl der Artikel ein: ";

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
            int incoming = ReadPositiveNumber(prompt);
            stock += incoming;
            Console.WriteLine($"Neuer Lagerbestand nach Wareneingang von {incoming} Stück: {stock}");
            break;
        case "2":
            Console.WriteLine("Warenausgang");
            int outgoing = ReadPositiveNumber("Bitte geben Sie die Anzahl der ausgehenden Artikel ein: ");
            if (stock >= outgoing)
            {
                stock -= outgoing;
                Console.WriteLine($"Neuer Lagerbestand nach Warenausgang von {outgoing} Stück: {stock}");
            }
            else
            {
                Console.WriteLine("Nicht genug Bestand für Warenausgang.");
            }
            CheckMinimumStock(stock, minimumStock);
            break;
        case "3":
            ShowStockDetails(itemNumber, itemName, stock, minimumStock, price);
            totalValue = stock * price;
            Console.WriteLine($"Gesamtwert des Lagerbestands: {totalValue:C}");
            CheckMinimumStock(stock, minimumStock);
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

void CheckMinimumStock (int stock, int minimumStock)
{
    if (stock <= minimumStock)
    {
        Console.WriteLine("Warnung: Lagerbestand unter Mindestbestand!");
    }
    else
    {
        Console.WriteLine("Lagerbestand ist ausreichend.");
    }
}
void ShowStockDetails(int itemNumber, string itemName, int stock, int minimumStock, decimal price)
{
    Console.WriteLine($"Artikelnummer: {itemNumber}");
    Console.WriteLine($"Artikelname: {itemName}");
    Console.WriteLine($"Lagerbestand: {stock}");
    Console.WriteLine($"Mindestbestand: {minimumStock}");
    Console.WriteLine($"Preis: {price:C}");
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
