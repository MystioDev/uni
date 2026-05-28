# 📝 Vizsga Részletei: `2026_05_28_vizsga` (Múzeumi Kiállítás Kezelő Rendszer)

A C# projekt egy olyan rendszert valósít meg, amely egy **Múzeumi Kiállítást (`Exhibition`)** és az abban szereplő különféle **Műtárgyakat (`Artifact`)** (mint például Festmények, Szobrok és Vázák) kezel. Emellett kezeli a **Felajánlásokat (`Donations`)** is, és kiszámítja a kölcsönzött műtárgyak tiszteletdíjait.

### 🏛️ Kulcsfontosságú Osztályok és Interfészek
A forráskódok a `base_code` és a `solution` mappákban a következőképpen épülnek fel:

*   **`Interfaces/IExhibition.cs`**:
    Definiálja a kiállítás kezeléséhez szükséges műveleteket (adatok dinamikus betöltése/mentése JSON-ből, értékes tárgyak keresése, vitrin kiíratása és adományok feldolgozása).
*   **`Models/Artifact.cs`**:
    Az absztrakt ősosztály, amely minden műtárgy közös tulajdonságait reprezentálja.
*   **`Models/Painting.cs`, `Models/Sculpture.cs`, `Models/Vase.cs`**:
    A specifikus műtárgytípusok származtatott osztályai, egyedi konstruktorokkal és felüldefiniált `ToString()` metódussal.
*   **`Models/Exhibition.cs`**:
    Az `IExhibition` interfészt megvalósító fő koordinátor osztály.
*   **`Models/Donations.cs` és `Models/GiftedArtifacts.cs`**:
    A külső JSON fájlokból betöltött felajánlásokat és kölcsönzéseket reprezentáló osztályok.

---

## ⚙️ A Vizsgamegoldás Tesztelése és Futtatása

### Preprocesszor részek:
*   `PART1`: A műtárgyak adatszerkezetének és származtatásának ellenőrzése.
*   `PART2`: Konstruktorok és `ToString()` metódusok ellenőrzése a gyerekosztályokban.
*   `PART3`: Az `IExhibition` interfész megvalósításának ellenőrzése.
*   `PART4`: Adatok dinamikus betöltése JSON fájlokból (`paintings.json`, `sculptures.json`, `vases.json`).
*   `PART5` - `PART6`: Keresés és szűrés az értékek alapján (pl. legalább 12 000 000 Ft értékű tárgyak).
*   `PART7` - `PART10`: Beérkező adományok/kölcsönzések feldolgozása és tiszteletdíjak számítása.
*   `PART11`: Aktuális állapot kimentése JSON fájlokba.
