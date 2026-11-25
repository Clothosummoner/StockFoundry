# StockFoundry

Ein kleines Lagerverwaltungsprogramm für die Konsole, geschrieben in C#. Mit diesem Projekt bringe ich mir C# von Grund auf bei.

## Features

- Menü, das so lange läuft, bis man „Beenden“ wählt
- Mehrere Artikel, gespeichert in einer Liste. Ausgewählt wird ein Artikel über seine Artikelnummer
- **Wareneingang:** Bestand erhöhen
- **Warenausgang:** Bestand verringern, aber nur, wenn genug Ware da ist
- **Lagerbestand prüfen:** alle Artikel mit ihren Daten und der Gesamtwert des Lagers
- **Artikel hinzufügen:** Name, Artikelnummer, Bestand, Mindestbestand und Preis eingeben. Doppelte Artikelnummern werden verhindert
- Warnung, sobald der Mindestbestand erreicht oder unterschritten ist
- Preise können mit Komma oder mit Punkt eingegeben werden (`9,99` und `9.99`)
- Ungültige Eingaben (Buchstaben, leere Eingaben, negative Zahlen) werden abgefangen, das Programm stürzt nicht ab

## Beispiel

```
Bitte wählen Sie eine Option:
1. Wareneingang
2. Warenausgang
3. Lagerbestand prüfen
4. Artikel hinzufügen
0. Beenden
Ihre Auswahl: 4
Artikel hinzufügen
Bitte geben Sie den Artikelnamen ein: Schrauben
Bitte geben Sie die Artikelnummer ein: 4
Bitte geben Sie den Bestand des neuen Artikels ein: 100
Bitte geben Sie den Mindestbestand des neuen Artikels ein: 20
Bitte geben Sie den Preis des Artikels ein: 0.15
Der Artikel Schrauben mit der Nummer 4 wurde dem Bestand hinzugefügt.

Ihre Auswahl: 2
Warenausgang
Vorhandene Artikel:
1: Artikel A
2: Artikel B
3: Artikel C
4: Schrauben
Bitte geben Sie die Artikelnummer ein: 4
Bitte geben Sie die Anzahl der Artikel ein: 85
Neuer Lagerbestand nach Warenausgang von 85 Stück: 15
Warnung: Mindestbestand erreicht oder unter Mindestbestand!

Ihre Auswahl: 3
(...)
Artikelnummer: 4
Artikelname: Schrauben
Lagerbestand: 15
Mindestbestand: 20
Preis: 0,15 €
Warnung: Mindestbestand erreicht oder unter Mindestbestand!

Gesamtwert des Lagerbestands: 651,90 €
```

## Technik

- C# mit .NET 10, Konsolenanwendung
- Der Artikel ist eine eigene Klasse `Item` mit Properties für Nummer, Name, Bestand, Mindestbestand und Preis
- Alle Artikel liegen in einer `List<Item>` und werden mit `foreach` durchlaufen, z. B. für die Übersicht und den Gesamtwert
- Menü mit einer `while`-Schleife und `switch`
- Wiederkehrende Abläufe stehen in eigenen Methoden, z. B. `ReadPositiveNumber`, `ReadNonNegativeNumber` und `ReadPrice` für die Eingaben und `CheckMinimumStock` für die Warnung
- `SelectItem` gibt ein `Item?` zurück: den gefundenen Artikel oder `null`, wenn es die Nummer nicht gibt
- `NumberExists` gibt einen `bool` zurück und prüft, ob eine Artikelnummer schon vergeben ist
- Eingaben werden mit `int.TryParse` und `decimal.TryParse` geprüft statt mit `Convert`, damit falsche Eingaben nicht zum Absturz führen
- Beim Preis wird ein Punkt vor dem Umwandeln durch ein Komma ersetzt (`Replace`), damit `9.99` nicht als 999 gelesen wird
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
- Listen und `foreach`, und dass eine Methode `null` zurückgeben kann, wenn sie nichts findet
- Bei einer Suche gehört `return true` in die Schleife, `return false` aber erst hinter die Schleife. Sonst wird nur der erste Artikel geprüft
- `int.TryParse` setzt die Zahl bei einer falschen Eingabe auf 0. Darauf muss die Bedingung der Schleife achten
- Spracheinstellungen: Auf einem deutschen Windows ist der Punkt das Tausender-Trennzeichen. `9.99` wurde deshalb zuerst als 999 gespeichert
- `Replace` verändert einen String nicht, sondern gibt einen neuen zurück. Mit `?.` wird eine Methode nur aufgerufen, wenn die Variable nicht `null` ist
- Mit Git in kleinen Schritten arbeiten, jeden Fortschritt committen und neue Funktionen in eigenen Branches entwickeln

## Über das Projekt

Ich möchte eine Ausbildung als Fachinformatiker für Anwendungsentwicklung machen und bringe mir dafür selbst Programmieren bei. Neben JavaScript (mit meinem Browserspiel [ResourceFoundry](https://github.com/Clothosummoner/ResourceFoundry)) lerne ich mit StockFoundry C#, weil diese Sprache in vielen Firmen für Geschäftsanwendungen eingesetzt wird.

## Geplant

- Artikel bearbeiten und löschen
- Lagerdaten als JSON-Datei speichern, damit sie nach dem Beenden erhalten bleiben
- Später: eine Datenbank anbinden

## Starten

Voraussetzung: [.NET 10 SDK](https://dotnet.microsoft.com/download)

```
git clone https://github.com/Clothosummoner/StockFoundry.git
cd StockFoundry
dotnet run --project StockFoundry
```

Oder die `StockFoundry.slnx` in Visual Studio öffnen und mit F5 starten.
