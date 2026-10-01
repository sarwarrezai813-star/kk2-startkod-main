
# Del 1 - Felrapport

## Fel 1 - Tom rad i filen
Problem: När jag körde dotnet run då programmet kraschade och visade ShoppingList.cs och rad 90.
Orsak: Koden försökte använda parts[1], men den var tom rad samt hade inte tillräckligt många delar.
Lösninng: När jag användade string.IsNullOrWhiteSpece(line) för att kolla om raden är tom och därefter sätta jag continue för att kunna hoppa över den raden.

