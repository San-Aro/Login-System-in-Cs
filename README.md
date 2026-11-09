# Beléptető Rendszer — Felhasználói Útmutató (User Guide)

A **Beléptető Rendszer** egy egyszerűen kezelhető, konzolos felületű szoftver, amelyet portaszolgálatok, telephelyek és védett objektumok számára fejlesztettünk ki. A program segítségével digitálisan rögzíthető a személyi- és járműforgalom, valamint az adatok bármikor visszakereshetők.

---

## 📋 Tartalomjegyzék

1. [A program célja](#-a-program-célja)
2. [Rendszerkövetelmények és Indítás](#-rendszerkövetelmények-és-indítás)
3. [Menürendszer áttekintése](#-menürendszer-áttekintése)
4. [Adatrögzítés lépésről lépésre](#-adatrögzítés-lépésről-lépésre)
   - [Személy belépésének rögzítése](#1-személy-belépésének-rögzítése)
   - [Jármű belépésének rögzítése](#2-jármű-belépésének-rögzítése)
5. [Keresés a rögzített adatok között](#-keresés-a-rögzített-adatok-között)
6. [Adattárolás (`appData.csv`)](#-adattárolás-appdatacsv)
7. [Gyakorlati példák képernyőképekkel](#-gyakorlati-példák)

---

## 🎯 A program célja

A szoftver felváltja a hagyományos, papíralapú porta-naplókat:
- **Automatikus időbélyeget** rendel minden belépéshez az operációs rendszer pontos órája alapján.
- **Tartós adattárolást** biztosít a `appData.csv` fájlban (az adatok a program bezárása után sem vesznek el).
- **Azonnali visszakeresést** tesz lehetővé névre, rendszámra, járműtípusra vagy márkára.

---

## 💻 Rendszerkövetelmények és Indítás

- **Operációs rendszer:** Windows, macOS vagy Linux.
- **Környezet:** .NET SDK (6.0 vagy újabb).

### Indítás lépései:
1. Nyisson meg egy terminált vagy parancssort a projekt mappájában.
2. Futtassa a következő parancsot:
   ```bash
   dotnet run
   ```

---

## 🕹️ Menürendszer áttekintése

Indítás után a **Főmenü** jelenik meg:

```text
======================================================
        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            
======================================================
 Rögzített személyek:  | Rögzített járművek: 
-------------------------------------------------------
Válassz egy módot: 
1. személy belépésének rögzítése
2. jármű belépésének rögzítése
3. keresés a korábban rögzített adatok között
4. kilépés a programból
Választott mód [1, 2, 3, 4]:
```

A kívánt funkció elindításához írja be a menüpont számát (`1`, `2`, `3` vagy `4`), majd nyomjon **Enter** billentyűt.

---

## 📖 Adatrögzítés lépésről lépésre

### 1. Személy belépésének rögzítése

1. A főmenüben írja be az **`1`**-es számot és nyomjon **Enter**-t.
2. A kijelzőn megjelennek a beviteli mezők:
   - **Adja meg az illető nevét:** Írja be a belépő személy teljes nevét (pl. *Kovács Péter*).
   - **Adja meg a személyi igazolvány számát:** Írja be az igazolványszámot (pl. *123456AB*).
3. Az adatok beírása után a rendszer kiírja:  
   `-----------------ADAT RÖGZÍTÉS SIKERES!----------------`
4. A belépési időpont automatikusan rögzítésre kerül.

### 2. Jármű belépésének rögzítése

1. A főmenüben írja be a **`2`**-es számot és nyomjon **Enter**-t.
2. Töltse ki a megjelenő mezőket:
   - **Jármű márkája:** pl. *Ford*
   - **Jármű típusa:** pl. *Focus*
   - **Jármű színe:** pl. *Fekete*
   - **Jármű rendszáma:** pl. *ABC-123*
3. Sikeres rögzítéskor a rendszer visszajelzést ad, és az adatsor automatikusan elmentődik a fájlba.

---

## 🔍 Keresés a rögzített adatok között

A főmenü **`3`**-as pontját kiválasztva megnyílik a **Keresés menü**:

```text
======================================================
                        KERESÉS                        
======================================================
1. személy neve alapján
2. jármű rendszáma alapján
3. jármű típusa alapján
4. jármű márkája alapján
5. Vissza a főmenüre
```

### A keresés használata:
1. Válasszon egy keresési szempontot (1-4).
2. Adja meg a keresett kifejezést (a kereső kis- és nagybetű független, és rész szavakra is keres).
3. A rendszer kilistázza a feltételnek megfelelő összes rekordot.
4. Ha a `5`-ös opciót választja, visszatér a főmenübe.

---

## 💾 Adattárolás (`appData.csv`)

A program az összes adatot a projekt mappájában lévő **`appData.csv`** nevű szöveges fájlba menti.

### Fájlstruktúra:
- **Személyi rekord (`P`):** `P;Időpont;Név;Igazolványszám`
- **Jármű rekord (`C`):** `C;Időpont;Márka;Típus;Szín;Rendszám`

*Példa a fájl tartalmára:*
```csv
P;2026-11-09 14:30:00;Kovács Péter;123456AB
C;2026-11-09 14:35:12;Ford;Focus;Fekete;ABC-123
```

---

## 🧪 Gyakorlati példák

### 1. Példa: Személy rögzítése
```text
Választott mód [1, 2, 3, 4]: 1

////////////////
Adja meg az illető nevét: Nagy Anna
Adja meg a személyi igazolvány számát: 987654CD
////////////////

-----------------ADAT RÖGZÍTÉS SIKERES!----------------
```

### 2. Példa: Keresés rendszám alapján
```text
Választott mód [1, 2, 3, 4]: 3

Választott mód [1, 2, 3, 4, 5]: 2
Adja meg a keresett kifejezést: abc-123

[JÁRMŰ]  Dátum: 2026-11-09 14:35:12 | Márka: Ford | Típus: Focus | Szín: Fekete | Rendszám: ABC-123
```