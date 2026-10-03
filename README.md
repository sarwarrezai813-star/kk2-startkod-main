
# Del 1 - Felrapport

## Fel 1 - Tom rad i filen
Problem: När jag körde dotnet run då programmet kraschade och visade ShoppingList.cs och rad 90.
Orsak: Koden försökte använda parts[1], men den var tom rad samt hade inte tillräckligt många delar.
Lösninng: När jag användade string.IsNullOrWhiteSpece(line) för att kolla om raden är tom och därefter jag sätt continue för att kunna hoppa över den raden.
jag har använd Trim() på namnet när filenläsas in för att Trim() tar bort osynliga tecken som \r. Efter ändring visas den sparade varan korrekt efter en omstartoch går även att hitta med sökfunktionen.

## Fel 2 - Ogiltigt talinmatning
Problem: När jag löste första problem då dotnet run går till menyn, pris och när jag valde ett heltal fungerade men när jag skrev en bokstav istället för nummer då kraschade programmet samt terminal visade progrma.cs och rad 16, och 28 på pris.
Orsak: De har använd int.parse och int.parse kunde inte omvandla bokstaven till ett heltal.
Lösning: Jag byt till int.TryParse om användaren inte skrev ett nummer då programmet ska visa "Ogiltigt val, försök igen" samt ska gå tillbaka till menyn.

## Fel 3 - Ta bort en vara som inte finns
Problem: Jag försökte ta bort en vara med ett nummer som inte finns i listan till exampel 100 då programmet kraschade samt visade ShoppingList.cs rad 20 och program.cs rad 45.
Orsak: RemoveAt försökte använda ett index som låg utanför listans och därför programmet fick ArgumentOutOfRangeException.
Lösning: Jag lade en if-kontroll i RemoveAt-metoden som kontrollerar om numret är mindre än 1 eller större än items.Count. Om användaren skrev en ogiltigt nummer då programmet visar "Ogiltigt nummer" och return avsluta metoden innan RemoveAt körs.

## Fel 4 - items.txt saknas
Problem: När jag ändrade filen till items-old.txt och körde dotnet run då programmet kraschade och visade ShoppingList.cs rad 89.
Orsak: Load-metoden försökte läsa items.txt med file.ReadAllText(path) även när filen inte fanns.
Lösning: På rad 89 jag lade en if-file.Exists(path) för att kolla om filen finns innan programmet försöker läsa den. Om det finns ingen file då programmet visar "Ingen sparad lista hittades." samt return avslutar. Efter ändring programmet startade utan items.txt saknas.


## Fel 5 - Fel totalsumma
Problem: Programmet kraschade inte vid totalsumma men totalsumma var fel.
Listan hade tre priserna 15 kr, 32 kr, 89 kr och det blir 136 kr men programmet visade 121 kr.
Orsak: ShoppingList.cs på rad 33 for-loopen började med i = 1 och en index börjar på 0 då programmet hoppade över den första varan, 15 kr.
Lösning: Jag började ändra rad 33 for-loppen från i = 1 till i = 0. Då började for-loppen från första varan och totalsumma blev 136 kr.

## Fel 6 - Tom catch döljer fel
Problem: Save-metoden hade ett tomt catch och när sparningen misslyckades då användaren fick ingen felmeddelande. 
Orska: Meddelande "Listan är sparad." var utanför try-blocket.
Lösning: Först jag flyttade "Listan är sparad." in i try-blocket för att meddelande ska visas när sparad lyckas. Jag lade i catch-blocket en (IOexception) för att visa "kunde inte sparad listan.".
