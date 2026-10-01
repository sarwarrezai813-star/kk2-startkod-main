
# Del 1 - Felrapport

## Fel 1 - Tom rad i filen
Problem: När jag körde dotnet run då programmet kraschade och visade ShoppingList.cs och rad 90.
Orsak: Koden försökte använda parts[1], men den var tom rad samt hade inte tillräckligt många delar.
Lösninng: När jag användade string.IsNullOrWhiteSpece(line) för att kolla om raden är tom och därefter sätta jag continue för att kunna hoppa över den raden.

## Fel 2 - Ogiltigt val i menyn
Problem: När jag löste första problem då dotnet run går till menyn och när jag valde ett heltal fungerade men när jag skrev en bokstav istället för nummer då kraschade programmet samt terminal visade progrma.cs och rad 16.
Orsak: De har använd int.parse och int.parse kunde inte omvandla bokstaven till ett heltal.
Lösning: Jag byt till int.TryParse om användaren inte skrev ett nummer då programmet ska visa "Ogiltigt val, försök igen" samt ska gå tillbaka till menyn.


