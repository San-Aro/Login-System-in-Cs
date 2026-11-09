void personLogin(string full_name, string idNum)
{
    DateTime most = DateTime.Now;
    File.AppendAllText("appData.csv", $"P;{most};{full_name};{idNum}\n");
}

void carLogin(string brand, string type, string color, string licencePlate)
{
    DateTime most = DateTime.Now;
    File.AppendAllText("appData.csv", $"C;{most};{brand};{type};{color};{licencePlate}\n");
}

void serchInData(int mode, string term)
{
    if (!File.Exists("appData.csv"))
    {
        Console.WriteLine("Nincs elmentett adat a fájlban.");
        return;
    }

    string[] lines = File.ReadAllLines("appData.csv");
    bool isResult = false;
    string searched = term.Trim().ToLower();

    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line)) continue;

        string[] data = line.Split(';');


        if (mode == 1 && data[0] == "P" && data.Length >= 4)
        {
            if (data[2].ToLower().Contains(searched))
            {
                Console.WriteLine($"[SZEMÉLY] Dátum: {data[1]} | Név: {data[2]} | Ig. szám: {data[3]}");
                isResult = true;
            }
        }

        else if (data[0] == "C" && data.Length >= 6)
        {
            bool searchResults = false;

            if (mode == 2 && data[5].ToLower().Contains(searched)) searchResults = true;
            else if (mode == 3 && data[3].ToLower().Contains(searched)) searchResults = true;
            else if (mode == 4 && data[2].ToLower().Contains(searched)) searchResults = true;

            if (searchResults)
            {
                Console.WriteLine($"[JÁRMŰ]  Dátum: {data[1]} | Márka: {data[2]} | Típus: {data[3]} | Szín: {data[4]} | Rendszám: {data[5]}");
                isResult = true;
            }
        }
    }

    if (!isResult)
    {
        Console.WriteLine("A megadott feltételekkel nem található bejegyzés.");
    }
}



while (true)
{
    Console.WriteLine("=======================================================");
    Console.WriteLine("        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            ");
    Console.WriteLine("=======================================================");
    Console.WriteLine("Válassz egy módot: ");
    Console.WriteLine("1. személy belépésének rögzítése");
    Console.WriteLine("2. jármű belépésének rögzítése");
    Console.WriteLine("3. keresés a korábban rögzített adatok között");
    Console.WriteLine("4. kilépés a programból");

    Console.Write("Választott mód [1, 2, 3, 4]: ");
    int mode = int.Parse(Console.ReadLine());

    Console.WriteLine("");

    if (mode == 1)
    {

        Console.WriteLine("=======================================================");
        Console.WriteLine("        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            ");
        Console.WriteLine("=======================================================");
        Console.WriteLine("              SZEMÉLY BELÉPÉSNEK RÖGZÍTÉS              ");
        Console.WriteLine(new string('-', 55));
        Console.Write("Adja meg az illető nevét: ");
        string name = Console.ReadLine();
        Console.Write("Adja meg a személyi igazolvány számát: ");
        string id = Console.ReadLine();

        Console.WriteLine("");


        personLogin(name, id);
        Console.WriteLine("-----------------ADAT RÖGZÍTÉS SIKERES!----------------");

        Console.WriteLine("");
        Console.WriteLine("");


    }

    if (mode == 2)
    {

        Console.WriteLine("=======================================================");
        Console.WriteLine("        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            ");
        Console.WriteLine("=======================================================");
        Console.WriteLine("               JÁRMŰ BELÉPÉSNEK RÖGZÍTÉS               ");
        Console.WriteLine(new string('-', 55));
        Console.Write("Adja meg a a jármű márkáját: ");
        string brand = Console.ReadLine();
        Console.Write("Adja meg a jármű típusát: ");
        string type = Console.ReadLine();

        Console.Write("Adja meg a jármű színét: ");
        string color = Console.ReadLine();

        Console.Write("Adja meg a jármű rendszámát: ");
        string licencePlate = Console.ReadLine();

        Console.WriteLine("");


        carLogin(brand, type, color, licencePlate);
        Console.WriteLine("-----------------ADAT RÖGZÍTÉS SIKERES!----------------");

        Console.WriteLine("");
        Console.WriteLine("");

    }

    if (mode == 3)
    {
        Console.WriteLine("=======================================================");
        Console.WriteLine("        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            ");
        Console.WriteLine("=======================================================");
        Console.WriteLine("                        KERESÉS                        ");
        Console.WriteLine(new string('-', 55));
        Console.WriteLine("Válassz egy keresési módot: ");
        Console.WriteLine("1. személy neve alapján");
        Console.WriteLine("2. jármű rendszáma alapján");
        Console.WriteLine("3. jármű típusa alapján");
        Console.WriteLine("4. jármű márkája alapján");
        Console.WriteLine("5. Vissza a főmenüre");

        Console.Write("Választott mód [1, 2, 3, 4, 5]: ");
        int searchMode = int.Parse(Console.ReadLine());

        Console.Write("Adja meg a keresett kifejezést: ");
        string searchQuery = Console.ReadLine();


        Console.WriteLine("");
        Console.WriteLine("");
        serchInData(searchMode, searchQuery);
        Console.WriteLine("");
        Console.WriteLine("");

        if (searchMode == 5)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------VISSZA A FŐMENÜRE------------------");
            Console.WriteLine("");
            Console.WriteLine("");
        }

    }

    if (mode == 4)
    {
        break;
    }
}
