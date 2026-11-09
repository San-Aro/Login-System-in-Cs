# Beléptető Rendszer — Felhasználói Útmutató 

A **Beléptető Rendszer** egy egyszerűen kezelhető, konzolos felületű szoftver, amelyet portaszolgálatok, telephelyek és védett objektumok számára fejlesztettünk ki. A program segítségével digitálisan rögzíthető a személyi- és járműforgalom, valamint az adatok bármikor visszakereshetők.

---

## 📋 Tartalomjegyzék

1. [A program célja](#-a-program-célja)
2. [Menürendszer áttekintése](#-menürendszer-áttekintése)
3. [Adatrögzítés lépésről lépésre](#-adatrögzítés-lépésről-lépésre)
   - [Személy belépésének rögzítése](#1-személy-belépésének-rögzítése)
   - [Jármű belépésének rögzítése](#2-jármű-belépésének-rögzítése)
4. [Keresés a rögzített adatok között](#-keresés-a-rögzített-adatok-között)
5. [Adattárolás (`appData.csv`)](#-adattárolás-appdatacsv)
6. [Gyakorlati példák képernyőképekkel](#-gyakorlati-példák)

---

## 🎯 A program célja

A szoftver felváltja a hagyományos, papíralapú porta-naplókat:
- **Automatikus időbélyeget** rendel minden belépéshez az operációs rendszer pontos órája alapján.
- **Tartós adattárolást** biztosít a `appData.csv` fájlban (az adatok a program bezárása után sem vesznek el).
- **Azonnali visszakeresést** tesz lehetővé névre, rendszámra, járműtípusra vagy márkára.


---

## 🕹️ Menürendszer áttekintése

Indítás után a **Főmenü** jelenik meg:

```text
======================================================
        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT            
======================================================
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
3. Az adatok sikeres rögzítése után a rendszer visszajelzést ad:  
   `-----------------ADAT RÖGZÍTÉS SIKERES!----------------`
4. A belépési időpont automatikusan rögzítésre kerül.

### 2. Jármű belépésének rögzítése

1. A főmenüben írja be a **`2`**-es számot és nyomjon **Enter**-t.
2. Töltse ki a megjelenő mezőket:
   - **Jármű márkája:** pl. *Ford*
   - **Jármű típusa:** pl. *Focus*
   - **Jármű színe:** pl. *Fekete*
   - **Jármű rendszáma:** pl. *ABC-123*
3. Az adatok sikeres rögzítése után a rendszer visszajelzést ad:  
   `-----------------ADAT RÖGZÍTÉS SIKERES!----------------`
4. A belépési időpont automatikusan rögzítésre kerül.

---

## 🔍 Keresés a rögzített adatok között

A főmenü **`3`**-as pontját kiválasztva megnyílik a **Keresés menü**:

```text
=======================================================
        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT
=======================================================
                        KERESÉS
-------------------------------------------------------
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

=======================================================
        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT
=======================================================
              SZEMÉLY BELÉPÉSNEK RÖGZÍTÉS
-------------------------------------------------------
Adja meg az illető nevét: Feles Elek
Adja meg a személyi igazolvány számát: 9454512KL

-----------------ADAT RÖGZÍTÉS SIKERES!----------------
```

### 2. Példa: Keresés típus alapján
```text
Választott mód [1, 2, 3, 4]: 3

=======================================================
        BELÉPTETŐ RENDSZER - PORTASZOLGÁLAT
=======================================================
                        KERESÉS
-------------------------------------------------------
Válassz egy keresési módot:
1. személy neve alapján
2. jármű rendszáma alapján
3. jármű típusa alapján
4. jármű márkája alapján
5. Vissza a főmenüre
Választott mód [1, 2, 3, 4, 5]: 3
Adja meg a keresett kifejezést: focus


[JÁRMŰ]  Dátum: 09/11/2026 22:31:53 | Márka: Ford | Típus: Focus | Szín: szürke | Rendszám: AEKL340
```