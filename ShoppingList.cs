// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int budgetLimit;

    public ShoppingList(string path, int budgetLimit)
    {
        this.path = path;
        this.budgetLimit = budgetLimit;
    }
    
    public bool Add(Item item)
    {
        if (Total() + item.Price > budgetLimit)
        {
            return false;
        }
        items.Add(item);
        return true;
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        if (number < 1 || number > items.Count)
        {
            Console.WriteLine("Ogiltigt nummer.");
            return;
        }
        items.RemoveAt(number - 1);
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

        try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
             Console.WriteLine("Listan är sparad.");
        }
        catch (IOException)

        {
            Console.WriteLine("Kunde inte spara listan.");
        }

       
    }

    // Reads the file back into the list.
    public void Load()
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Ingen sparad lista hittades.");
            return;
        }
        string text = File.ReadAllText(path);
        string[] lines = text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }
            string[] parts = line.Split(';');
            items.Add(new Item(parts[1].Trim(), int.Parse(parts[0])));
        }
    }
}
