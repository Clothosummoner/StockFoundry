# StockFoundry

Ein kleines Lagerverwaltungsprogramm für die Konsole, geschrieben in C#. Mit diesem Projekt bringe ich mir C# von Grund auf bei.

## Features

- Menü, das so lange läuft, bis man „Beenden“ wählt
- **Wareneingang:** Bestand erhöhen
- **Warenausgang:** Bestand verringern, aber nur, wenn genug Ware da ist
- **Bestand anzeigen:** Artikeldaten, aktueller Bestand und Gesamtwert des Lagers
- Warnung, sobald der Mindestbestand erreicht oder unterschritten ist
- Ungültige Eingaben (Buchstaben, leere Eingabe, 0 oder negative Zahlen) werden abgefangen, das Programm stürzt nicht ab

## Beispiel

```
Bitte wählen Sie eine Option:
1. Wareneingang
2. Warenausgang
3. Lagerbestand prüfen
0. Beenden
Ihre Auswahl: 2
Warenausgang
Bitte geben Sie die Anzahl der ausgehenden Artikel ein: 95
Neuer Lagerbestand nach Warenausgang von 95 Stück: 5
Warnung: Lagerbestand unter Mindestbestand!

Ihre Auswahl: 3
Artikelnummer: 12345
Artikelname: Beispielartikel
Lagerbestand: 5
Mindestbestand: 10
Preis: 19,99 €
Gesamtwert des Lagerbestands: 99,95 €
Warnung: Lagerbestand unter Mindestbestand!
```

## Technik

- C# mit .NET 10, Konsolenanwendung
- Der Artikel ist eine eigene Klasse `Item` mit Properties für Nummer, Name, Bestand, Mindestbestand und Preis
- Menü mit einer `while`-Schleife und `switch`
- Wiederkehrende Abläufe stehen in eigenen Methoden, z. B. `ReadPositiveNumber` für die Zahleneingabe und `CheckMinimumStock` für die Warnung
- Eingaben werden mit `int.TryParse` geprüft statt mit `Convert.ToInt32`, damit falsche Eingaben nicht zum Absturz führen
- Preise und Lagerwert als `decimal`, damit bei Geldbeträgen keine Rundungsfehler entstehen
- Geldbeträge werden mit `:C` passend zur Spracheinstellung formatiert (z. B. `19,99 €`)

## Was ich dabei gelernt habe

- Datentypen in C# (`int`, `string`, `decimal`, `bool`) und warum C# den Typ einer Variable wissen will
- Bedingungen mit `if`/`else` und die Verknüpfung mit `&&`, `||` und `!`
- Grenzfälle testen: Was passiert bei genau 0, bei negativen Zahlen, bei Buchstaben?
- Code läuft von oben nach unten: erst rechnen, dann ausgeben
- Den Unterschied zwischen `return`, `break` und `continue`
- Methoden mit Parametern und Rückgabewert schreiben
- Klassen und Objekte: Eine Klasse ist der Bauplan, mit `new` entsteht daraus ein Objekt
- Warum ein `string` einen Startwert braucht: Der Unterschied zwischen `null` und `""`
- Mit Git in kleinen Schritten arbeiten und jeden Fortschritt committen

## Über das Projekt

Ich möchte eine Ausbildung als Fachinformatiker für Anwendungsentwicklung machen und bringe mir dafür selbst Programmieren bei. Neben JavaScript (mit meinem Browserspiel [ResourceFoundry](https://github.com/Clothosummoner/ResourceFoundry)) lerne ich mit StockFoundry C#, weil diese Sprache in vielen Firmen für Geschäftsanwendungen eingesetzt wird.

## Geplant

- Mehrere Artikel statt nur einem, gespeichert in einer Liste
- Artikel anlegen, bearbeiten und löschen
- Lagerdaten in einer Datei speichern, damit sie nach dem Beenden erhalten bleiben
- Später: eine Datenbank anbinden

## Starten

Voraussetzung: [.NET 10 SDK](https://dotnet.microsoft.com/download)

```
git clone https://github.com/Clothosummoner/StockFoundry.git
cd StockFoundry
dotnet run --project StockFoundry
```

Oder die `StockFoundry.slnx` in Visual Studio öffnen und mit F5 starten.
