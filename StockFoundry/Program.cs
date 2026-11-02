int itemNumber = 12345;
string itemName = "Beispielartikel";
int stock = 100;
int minimumStock = 10;
decimal price = 19.99m;
decimal totalValue = 0;
Console.WriteLine($"Artikelnummer: {itemNumber}");
Console.WriteLine($"Artikelname: {itemName}");
Console.WriteLine($"Lagerbestand: {stock}");
Console.WriteLine($"Mindestbestand: {minimumStock}");
Console.WriteLine($"Preis: {price:C}");
Console.Write("Bitte geben Sie die Anzahl der eingehenden Artikel ein: ");
string? input = Console.ReadLine();
if (!int.TryParse(input, out int incoming) || incoming <= 0)
{
    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
    return;
}
Console.Write("Bitte geben Sie die Anzahl der ausgehenden Artikel ein: ");
string? outgoingInput = Console.ReadLine();
if (!int.TryParse(outgoingInput, out int outgoing) || outgoing <= 0)
{
    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine gültige Zahl ein.");
    return;
}
stock += incoming;
Console.WriteLine($"Neuer Lagerbestand nach Wareneingang von {incoming} Stück: {stock}");
if (stock >= outgoing)
{
    stock -= outgoing;
    Console.WriteLine($"Neuer Lagerbestand nach Warenausgang von {outgoing} Stück: {stock}");
}
else
{
    Console.WriteLine("Nicht genug Bestand für Warenausgang.");
}
if (stock <= minimumStock)
{
    Console.WriteLine("Warnung: Lagerbestand unter Mindestbestand!");
}
else
{
    Console.WriteLine("Lagerbestand ist ausreichend.");
}
totalValue = stock * price;
Console.WriteLine($"Gesamtwert des Lagerbestands: {totalValue:C}");



