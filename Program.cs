ShoppingList list = new ShoppingList("items.txt");
list.Load();

while (true)
{
    Console.WriteLine();
    list.Print();
    Console.WriteLine();
    Console.WriteLine("1. Lägg till vara");
    Console.WriteLine("2. Ta bort vara");
    Console.WriteLine("3. Spara");
    Console.WriteLine("4. Sök vara");
    Console.WriteLine("5. Avsluta");
    Console.Write("Välj: ");

    bool success = int.TryParse(Console.ReadLine(), out int choice);
    if (!success)
    {
        Console.WriteLine("Ogiltigt val. försök igen.");
        continue;
    }

    if (choice == 1)
    {
        Console.Write("Namn: ");
        string name = Console.ReadLine();
        Console.Write("Pris: ");
       bool priceSuccess = int.TryParse(Console.ReadLine(), out int price);
       if (!priceSuccess)
        {
            Console.WriteLine("Ogiltigt pris.");
            continue;
        }
        try
        {
            list.Add(new Item(name, price));
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    
    }
    else if (choice == 2)
    {
        Console.Write("Nummer: ");
        bool numberSuccess = int.TryParse(Console.ReadLine(), out int number);
        if (!numberSuccess)
        {
            Console.WriteLine("Ogitligt nummer.");
            continue;
        }
        list.RemoveAt(number);
    }
    else if (choice == 3)
    {
        list.Save();
    }
    else if (choice == 4)
    {
        Console.Write("Namn att söka efter: ");
        string wanted = Console.ReadLine();
        Item found = list.Find(wanted);

        if (found == null)
        {
            Console.WriteLine("Varan finns inte i listan.");
        }
        else
        {
            Console.WriteLine($"Hittade: {found}");
        }
    }
    else if (choice == 5)
    {
        break;
    }
}
