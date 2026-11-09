List<string> szemelyek = new();


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

void serchInData(int mode, string expression)
{
    if (!File.Exists("appData.csv"))
    {
        Console.WriteLine("Nincs elmentett adat a fájlban.");
        return;
    }

    string[] lines = File.ReadAllLines("appData.csv");
    bool isResult = false;
    string searched = expression.Trim().ToLower();

    foreach (string line in lines)
    {
        if (string.IsNullOrWhiteSpace(line)) continue;

        string[] m = line.Split(';');

        // Személy rögzítés: P;Időpont;Név;Igazolványszám (min. 4 mező)
        if (mode == 1 && m[0] == "P" && m.Length >= 4)
        {
            if (m[2].ToLower().Contains(searched))
            {
                Console.WriteLine($"[SZEMÉLY] Dátum: {m[1]} | Név: {m[2]} | Ig. szám: {m[3]}");
                isResult = true;
            }
        }
        // Jármű rögzítés: C;Időpont;Márka;Típus;Szín;Rendszám (min. 6 mező)
        else if (m[0] == "C" && m.Length >= 6)
        {
            bool talalat = false;

            if (mode == 2 && m[5].ToLower().Contains(searched)) talalat = true; // Rendszám
            else if (mode == 3 && m[3].ToLower().Contains(searched)) talalat = true; // Típus
            else if (mode == 4 && m[2].ToLower().Contains(searched)) talalat = true; // Márka

            if (talalat)
            {
                Console.WriteLine($"[JÁRMŰ]  Dátum: {m[1]} | Márka: {m[2]} | Típus: {m[3]} | Szín: {m[4]} | Rendszám: {m[5]}");
                isResult = true;
            }
        }
    }

    if (!isResult)
    {
        Console.WriteLine("A megadott feltételekkel nem található bejegyzés.");
    }
}


try
{
    string teljesTartalom = File.ReadAllText("appData.csv");
    string[] sorok = File.ReadAllLines("appData.csv");
    Console.WriteLine($"{sorok.Length} sor: {teljesTartalom}");

}
catch (FileNotFoundException)
{
    File.WriteAllText("appData.csv", ""); // felülírja a fájlt
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Nincs jogosultság a fájl olvasásához.");
}


while (true)
{
    Console.WriteLine("=======================================================");
    Console.WriteLine("        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            ");
    Console.WriteLine("=======================================================");
    Console.WriteLine($" Rögzített személyek:  | Rögzített járművek: ");
    Console.WriteLine(new string('-', 55));
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

        Console.WriteLine("////////////////");
        Console.Write("Adja meg az illető nevét: ");
        string name = Console.ReadLine();

        Console.Write("Adja meg a személyi igazolvány számát: ");
        string id = Console.ReadLine();
        Console.WriteLine("////////////////");

        Console.WriteLine("");


        personLogin(name, id);
        Console.WriteLine("-----------------ADAT RÖGZÍTÉS SIKERES!----------------");

        Console.WriteLine("");
        Console.WriteLine("");


    }

    if (mode == 2)
    {

        Console.WriteLine("////////////////");
        Console.Write("Adja meg a a jármű márkáját: ");
        string brand = Console.ReadLine();

        Console.Write("Adja meg a jármű típusát: ");
        string type = Console.ReadLine();

        Console.Write("Adja meg a jármű színét: ");
        string color = Console.ReadLine();

        Console.Write("Adja meg a jármű rendszámát: ");
        string licencePlate = Console.ReadLine();
        Console.WriteLine("////////////////");

        Console.WriteLine("");


        carLogin(brand, type, color, licencePlate);
        Console.WriteLine("-----------------ADAT RÖGZÍTÉS SIKERES!----------------");

        Console.WriteLine("");
        Console.WriteLine("");

    }

    if (mode == 3)
    {

        Console.WriteLine("=======================================================");
        Console.WriteLine("                        KERESÉS                        ");
        Console.WriteLine("=======================================================");
        Console.WriteLine($" Rögzített személyek:  | Rögzített járművek: ");
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
        string kifejezes = Console.ReadLine();


        Console.WriteLine("");
        Console.WriteLine("");
        serchInData(searchMode, kifejezes);
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
