# Diszkrét matematika — Tételek röviden

## Tartalomjegyzék
1. Kombinatorikai alapfeladatok
2. Rendezett osztályozás, ismétléses permutációk
3. Ismétléses kombinációk korlátozásokkal
4. Szita-formula és speciális alakja
5. Lineáris differenciaegyenletek
6. Gráf alapfogalmak
7. Fa gráfok
8. Vonalak, Euler-vonal
9. Hamilton-kör
10. Páros gráfok
11. Síkgráfok
12. Gráfok színezése
13. Oszthatóság, lineáris diofantoszi egyenletek
14. Legkisebb közös többszörös, prímszámok
15. Kongruenciák
16. Maradékrendszerek, Euler-függvény

---

## 1. Kombinatorikai alapfeladatok

### 1.1. Ismétléses variációk
* **Definíció:** Egy $k$-elemű halmaz $n$-elemű halmazba való leképezései ($n$ elem $k$-tagú ismétléses variációja).
* **Száma:** $n^k$

### 1.2. Ismétlés nélküli variációk
* **Definíció:** Egy $k$-elemű halmaz $n$-elemű halmazba való *injektív* leképezései ($n$ elem $k$-tagú ismétlés nélküli variációja).
* **Száma:** $\frac{n!}{(n - k)!}$

### 1.3. Permutációk
* **Definíció:** Az $\{1, 2, \dots, n\}$ halmaz önmagára történő *bijektív* leképezése.
* **Kombinatorikus kérdés:** Hányféleképpen lehet sorbarendezni $n$ elemet?
* **Száma:** $n!$

### 1.4. Ismétlés nélküli kombinációk
* **Definíció:** Egy $n$-elemű halmaz $k$-elemű részhalmazai.
* **Száma:** $\binom{n}{k} := \frac{n!}{k!(n - k)!}$

### 1.5. Binomiális együtthatók tulajdonságai
* $\binom{n}{0} = \binom{n}{n} = 1$
* $\binom{n}{k} = \binom{n}{n - k}$
* $\binom{n + 1}{k + 1} = \binom{n}{k} + \binom{n}{k + 1}$
* $\binom{n}{0} + \binom{n}{1} + \dots + \binom{n}{n} = 2^n$

### 1.6. Pascal-háromszög
Az előző alfejezet tulajdonságaiból következik:

$$
\begin{matrix}
&&&&\binom{0}{0}&&&& \\
&&&\binom{1}{0}&&\binom{1}{1}&&& \\
&&\binom{2}{0}&&\binom{2}{1}&&\binom{2}{2}&& \\
&\binom{3}{0}&&\binom{3}{1}&&\binom{3}{2}&&\binom{3}{3}& \\
\vdots&&\vdots&&\vdots&&\vdots&&\vdots
\end{matrix}
\implies
\begin{matrix}
&&&&1&&&& \\
&&&1&&1&&& \\
&&1&&2&&1&& \\
&1&&3&&3&&1& \\
\vdots&&\vdots&&\vdots&&\vdots&&\vdots
\end{matrix}
$$

### 1.7. Ismétléses kombinációk
* **Definíció:** Egy $n$-elemű halmaz $k$-elemű részrendszere (egy elemet többször is választhatunk, a sorrend nem számít).
* **Megadása monoton sorozatként:** A kiválasztott elemeket egy rendezés segítségével felírhatjuk monoton növő sorozatként.
* **Száma:** $\binom{n + k - 1}{k}$

---

## 2. Rendezett osztályozás, ismétléses permutációk
Legyen $n, r \in \mathbb{N}$, $k_1, \dots, k_r \in \mathbb{N}_0$, és $n = k_1 + \dots + k_r$.

### 2.1. Rendezett osztályozás
* **Definíció:** Az $n$-elemű $A$ halmaz $(k_1, \dots, k_r)$ típusú rendezett osztályozása a $(C_1, \dots, C_r)$ rendezett $r$-es, ahol $C_1, \dots, C_r$ az $A$ halmaz páronként diszjunkt részhalmazai, $C_1 \cup \dots \cup C_r = A$, és $|C_1| = k_1, \dots, |C_r| = k_r$.
* **Száma:** $\frac{n!}{k_1! \dots k_r!}$

### 2.2. Ismétléses permutáció
* **Definíció:** Olyan $a_1, \dots, a_r$ elemekből álló $n$-hosszú sorozat, amelyben pontosan $k_1$ darab $a_1, \dots, k_r$ db $a_r$ elem szerepel ($(k_1, \dots, k_r)$ típusú ismétléses permutáció).
* **Száma:** $\frac{n!}{k_1! \dots k_r!}$

### 2.3. Kapcsolatuk
A $(k_1, \dots, k_r)$ típusú rendezett osztályozások és a $(k_1, \dots, k_r)$ típusú ismétléses permutációk száma azonos, mivel megadható egy bijekció a kettő között.

### 2.4. Polinomiális tétel
Legyen $n, r \in \mathbb{N}$ és $a_1, \dots, a_r \in \mathbb{R}$. Ekkor:
$$(a_1 + \dots + a_r)^n = \sum_{\substack{k_1, \dots, k_r \in \mathbb{N}_0 \\ k_1 + \dots + k_r = n}} \frac{n!}{k_1! \dots k_r!} a_1^{k_1} \dots a_r^{k_r}$$

### 2.5. Binomiális tétel
Legyen $n, r \in \mathbb{N}$, $a, b \in \mathbb{R}$. Ekkor:
$$(a + b)^n = \sum_{k=0}^{n} \binom{n}{k} a^k b^{n-k}$$

#### Következmény
* $\binom{n}{0} + \binom{n}{1} + \dots + \binom{n}{n} = 2^n$
* $\binom{n}{0} - \binom{n}{1} + \binom{n}{2} - \dots + (-1)^n \binom{n}{n} = 0$


## 3. Ismétléses kombinációk korlátozásokkal

### 3.1. Minden $i$-re $a_i$ legalább $s_i$-szer fordul elő
$$\binom{n + (k - s_1 - s_2 - \dots - s_n) - 1}{k - s_1 - s_2 - \dots - s_n} = \binom{n + (k - s_1 - s_2 - \dots - s_n) - 1}{n - 1}$$

### 3.2. Minden elem legalább egyszer fordul elő
Az előző képletben $s_i = 1, i = 1, 2, \dots, n$ behelyettesítéséből adódik:
$$\binom{k - 1}{n - 1}$$

### 3.3. Lineáris egyenletek egységnyi együtthatóval
A következőkben az alábbi egyenlet megoldásainak számáról lesz szó:  
Legyen $n, k \in \mathbb{N}$, és $n \leq k$.
$$x_1 + x_2 + \dots + x_n = k$$

* **Nemnegatív egész megoldások száma:** $\binom{n + k - 1}{k}$
* **Pozitív egész megoldások száma:** $\binom{k - 1}{n - 1}$
* **Az $x_i > c_i$ feltételeket teljesítő megoldások száma:** $\binom{k - c_1 - c_2 - \dots - c_n - 1}{n - 1}$

---

## 4. Szita-formula és speciális alakja

### 4.1. Szita-formula
Legyen $U$ véges halmaz, $A_1, \dots, A_n \subseteq U, n \in \mathbb{N}$. Ekkor:
$$|A_1 \cup \dots \cup A_n| = \sum_{r=1}^{n} (-1)^{r-1} \sum_{1 \leq i_1 < \dots < i_r \leq n} |A_{i_1} \cap \dots \cap A_{i_r}|$$
$$|\overline{A_1 \cup \dots \cup A_n}| = |U| + \sum_{r=1}^{n} (-1)^r \sum_{1 \leq i_1 < \dots < i_r \leq n} |A_{i_1} \cap \dots \cap A_{i_r}|$$

### 4.2. Speciális szita-formula
Legyen $U$ véges halmaz, $A_1, \dots, A_n \subseteq U$, amelyre bármely $r$ darab különböző $A_i$ indexű halmaz metszetének számossága azonos minden $r = 1, \dots, n$-re. Ekkor:
$$|A_1 \cup \dots \cup A_n| = \sum_{r=1}^{n} (-1)^{r-1} \binom{n}{r} |A_{i_1} \cap \dots \cap A_{i_r}|$$
$$|\overline{A_1 \cup \dots \cup A_n}| = |U| + \sum_{r=1}^{n} (-1)^r \binom{n}{r} |A_{i_1} \cap \dots \cap A_{i_r}|$$

### 4.3. Elcserélt levelek problémája
Adott $n$ levél és $n$ megcímzett boríték. Hányféleképpen tudjuk a leveleket a borítékokba helyezni, hogy senki se kapja meg a neki írt levelet?  
**Válasz (fixpont nélküli permutációk száma, $D_n$):**
$$D_n = n! \cdot \left( \frac{1}{0!} - \frac{1}{1!} + \frac{1}{2!} - \dots + (-1)^n \frac{1}{n!} \right)$$

### 4.4. Szürjektív leképezések száma
Legyen $B$ egy $k$-elemű, $C$ pedig egy $n$-elemű halmaz, ahol $1 \leq n \leq k$. A $B \to C$ szürjektív leképezések száma:
$$\sum_{r=0}^{n} (-1)^r \binom{n}{r} (n - r)^k$$

---

## 5. Lineáris differenciaegyenletek

### 5.1. Inhomogén konstans együtthatós
Általános $k$-adrendű alak:
$$a_k x_n + a_{k-1} x_{n-1} + \dots + a_0 x_{n-k} = f_n, \quad n = k, k+1, \dots \quad (1)$$
ahol $a_k, \dots, a_0$ rögzített valós számok, $a_k \neq 0$ és $f_n$ egy nem azonosan $0$ sorozat.  
*Kezdeti feltétel:* $x_0 = v_0, x_1 = v_1, \dots, x_{k-1} = v_{k-1}$

### 5.2. Homogén konstans együtthatós
$$a_k x_n + a_{k-1} x_{n-1} + \dots + a_0 x_{n-k} = 0, \quad n = k, k+1, \dots \quad (2)$$

### 5.3. Állítások
* **Homogén:** A megoldások halmaza $k$-dimenziós lineáris tér. Ha $y_n, z_n$ megoldás, akkor $\alpha y_n + \beta z_n$ is az.
* **Inhomogén:** Általános megoldás = Homogén általános megoldása + Inhomogén egy partikuláris megoldása ($p_n$).

### 5.4. Karakterisztikus egyenlet
A differenciaegyenlet $r^n$ alakba való átírása és egyszerűsítése után kapott egyenlet. Példa: $ar^2 + br + c = 0$.

### 5.5. Próbafüggvény módszer
Ha $f_n = b^n$, akkor a partikuláris megoldást $p_n = A \cdot b^n$ alakban keressük.

### 5.6. Generátorfüggvény módszer
Egy $s_n$ sorozat generátorfüggvénye: $g(x) = \sum_{n=0}^{\infty} s_n x^n$.


## 6. Gráf alapfogalmak

### 6.1. Definíciók
* **Irányítatlan gráf:** Olyan $G = (V, E)$ rendezett pár, ahol $V \neq \emptyset$ a pontok halmaza, $E$ az élek halmaza.
* **Pont fokszáma ($d(v)$):** Az adott pontra illeszkedő élek száma (a hurokél $2$-t ér).
* **Hurokél:** Olyan él, amelynek a kezdő- és végpontja azonos.
* **Egyszerű gráf:** Hurokélmentes, többszörös élt nem tartalmazó gráf.
* **Séta:** Élek sorozata, ahol az egymást követő élek csatlakoznak.
* **Út:** Olyan séta, amely nem megy át kétszer ugyanazon a ponton.
* **Kör:** Olyan út, amely önmagába tér vissza (kezdő- és végpontja megegyezik).
* **Részgráf:** $G' = (V', E')$ részgráfja $G = (V, E)$-nek, ha $V' \subseteq V$ és $E' \subseteq E$.
* **Összefüggőség:** $G$ összefüggő, ha bármely két pontja között létezik séta.

### 6.2. Kézfogási tétel
Egy irányítatlan gráfban a pontok fokszámainak összege az élek számának kétszerese:
$$\sum_{v \in V} d(v) = 2|E|$$

### 6.3. Havel-Hakimi
Algoritmus, amely egy fokszámsorozatról megállapítja, hogy realizálható-e egyszerű gráfként.

### 6.4. Szomszédsági mátrix
Az $A = (a_{ij})_{n \times n}$ mátrix, ahol $a_{ij}$ a $v_i$ és $v_j$ közötti élek száma (hurokél esetén $2k$). Szimmetrikus, a sorösszege a pont fokszáma.

### 6.5. Tintacsepegtetős algoritmus
Egy gráf összefüggő komponenseinek meghatározására szolgál.

### 6.6. Izomorf gráfok
$G \cong G'$, ha létezik köztük illeszkedéstartó $\phi: V \to V'$ és $\psi: E \to E'$ bijekció.

---

## 7. Fa gráfok
* **Definíció:** Körmentes, hurokélmentes és összefüggő gráf.
* **Tulajdonságok:**
  * Tetszőleges élt elhagyva két komponensre esik szét.
  * Tetszőleges új élt hozzáadva pontosan egy kör keletkezik benne.
  * Az $n$-pontú fának pontosan $n - 1$ éle van.
  * Minden legalább kétpontú fának van legalább két $1$ fokszámszámú pontja (levele).

---

## 8. Vonalak, Euler-vonal
* **Vonal:** Olyan séta, amely minden élét legfeljebb egyszer érinti.
* **Euler-vonal:** Olyan vonal, amely a gráf *minden élesén* pontosan egyszer áthalad.
* **Euler-gráf:** Van benne zárt Euler-vonal $\iff$ minden pont fokszáma páros.
* **Nyílt Euler-vonal feltétele:** Pontosan $2$ darab páratlan fokszámú pont van.
* **Vágóél:** Olyan él, aminek elhagyásával nő a komponensek száma.
* **Fleury-algoritmus:** Euler-vonal keresésére szolgál (vágóélt csak végső esetben választunk).

---

## 9. Hamilton-kör
* **Hamilton-kör / út:** Olyan kör / út, amely a gráf *minden pontján* pontosan egyszer halad át.
* **Szükséges feltétel:** Ha $G$-ből elhagyunk $m$ darab pontot, a megmaradt gráf legfeljebb $m$ komponensre eshet szét.
* **Dirac tétele (elegendő feltétel):** Ha egy $n \geq 3$ pontú egyszerű gráfban minden pont fokszáma $d(v) \geq \frac{n}{2}$, akkor a gráfban van Hamilton-kör.


## 10. Páros gráfok
* **Definíció:** A pontok halmaza felbontható $A$ és $B$ osztályra ($A \cap B = \emptyset$), hogy minden él $A$-beli és $B$-beli pontot köt össze.
* **Tétel:** Egy gráf pontosan akkor páros, ha nem tartalmaz páratlan hosszú kört.
* **Párosítás ($M$):** Független élek halmaza (nincs közös végpontjuk).
* **Teljes párosítás:** A gráf összes pontját lefedi. Ekkor $|A| = |B|$.
* **Lefogó ponthalmaz ($S$):** Minden élnek legalább az egyik végpontja $S$-ben van.
* **$\nu(G)$ és $\tau(G)$:** $\nu(G)$ a maximális párosítás, $\tau(G)$ a minimális lefogó halmaz mérete.
* **Kőnig-tétel:** Páros gráfokban $\nu(G) = \tau(G)$.
* **Kőnig-Hall-kritérium:** Páros gráfban akkor létezik $A$-t lefedő párosítás, ha minden $X \subseteq A$ halmazra $|X| \leq |\Gamma(X)|$ (ahol $\Gamma(X)$ az $X$ szomszédainak halmaza).

---

## 11. Síkgráfok
* **Definíció:** Síkba rajzolható élmetszések nélkül. A rajzot *síktérképnek* nevezzük.
* **Országok:** A síktérkép élei által határolt tartományok (a külső, végtelen tartomány is egy ország).
* **Határélek összege:** $\sum_{C} h_G(C) = 2|E(G)|$ (a vágóélek kettőnek számítanak).
* **Euler-tétel:** Összefüggő síkgráfra: $c(G) + o(G) = e(G) + 2$ (pontok + országok = élek + 2).
* **Következmény:** Egyszerű, legalább 3 pontú síkgráfra: $e(G) \leq 3c(G) - 6$.
* **Kuratowski tétele:** Egy gráf pontosan akkor síkgráf, ha nem tartalmaz a $K_5$ vagy $K_{3,3}$ gráfokkal topologikusan izomorf részgráfot.

---

## 12. Gráfok színezése
* **Jó színezés:** Szomszédos pontok színe különböző.
* **Kromatikus szám ($\chi(G)$):** A jó színezéshez szükséges legkevesebb szín.
* **Tulajdonságok:**
  * $\chi(G) = 1 \iff$ nincs él.
  * $\chi(K_n) = n$.
  * $\chi(G) = 2 \iff G$ páros gráf ($\geq 1$ éllel).
  * $\chi(G) \geq 3 \iff$ van benne páratlan kör.
* **Ötszíntétel:** Bármely egyszerű síkgráfra $\chi(G) \leq 5$.
* **Országok színezése:** Ha nincs vágóél, az országok is kiszínezhetők legfeljebb 5 színnel.


## 13. Oszthatóság, lineáris diofantoszi egyenletek

### 13.1. Oszthatóság
$a \mid b \iff \exists x \in \mathbb{Z}: b = ax$.  
*Tulajdonságok:* Reflexív ($a \mid a$), tranzitív ($a \mid b \land b \mid c \implies a \mid c$), lineáris kombinációt megőriz ($a \mid b \land a \mid c \implies a \mid bx + cy$).

### 13.2. Maradékos osztás tétele
$\forall a > 0, b \in \mathbb{Z}$-hez $\exists! \, q, r \in \mathbb{Z}$, hogy $b = aq + r$, ahol $0 \leq r < a$.

### 13.3. Legnagyobb közös osztó (lnko / $(a,b)$)
A közös osztók közül a legnagyobb.

### 13.4. Bézout tétel
Az $(a,b)$ felírható $a$ és $b$ lineáris kombinációjaként: $(a, b) = ax_0 + by_0 \quad (x_0, y_0 \in \mathbb{Z})$.

### 13.5. Relatív prímek
$a$ és $b$ relatív prímek, ha $(a, b) = 1$.

### 13.6. Euklideszi algoritmus
Szerepe: Maradékos osztások láncolatával meghatározza két szám legnagyobb közös osztóját.

### 13.7. Lineáris diofantoszi egyenletek
$ax + by = c$ ($a, b, c \in \mathbb{Z}$). Megoldható $\iff (a,b) \mid c$.  
*Általános megoldás:* $x = x_0 + k \frac{b}{(a,b)}, \quad y = y_0 - k \frac{a}{(a,b)} \quad (k \in \mathbb{Z})$.

---

## 14. Legkisebb közös többszörös, prímszámok
* **Lkkt ($[a,b]$):** A közös többszörösök közül a legkisebb pozitív. Tétel: $(a,b) \cdot [a,b] = ab$.
* **A számelmélet alaptétele:** Minden $n > 1$ egész szám a tényezők sorrendjétől eltekintve egyértelműen felbontható prímszámok szorzatára: $n = p_1^{\alpha_1} \dots p_r^{\alpha_r}$.
* **Euklidész tétele:** A prímszámok száma végtelen.
* **Prímszámtétel:** $\lim_{n \to \infty} \frac{\pi(n)}{\frac{n}{\ln n}} = 1$.

---

## 15. Kongruenciák

### 15.1. Definíció
$a \equiv b \pmod n \iff n \mid (a - b)$. Ez egy ekvivalenciareláció.  
*Műveletek:* Összeadhatók, szorozhatók. Osztásnál: $ac \equiv bc \pmod n \implies a \equiv b \pmod{\frac{n}{(c,n)}}$.

### 15.2. Lineáris kongruenciák
$ax \equiv b \pmod n$. Megoldható $\iff d = (a,n) \mid b$. Ekkor pontosan $d$ darab inkongruens megoldás van modulo $n$.

### 15.4. Kínai maradéktétel
Ha $m_1, \dots, m_k$ páronként relatív prímek, akkor az $x \equiv a_i \pmod{{m_i}}$ kongruencia-rendszernek mindig van megoldása, és az egyértelmű modulo $m_1 \dots m_k$.

---

## 16. Maradékrendszerek, Euler-függvény
* **Euler $\phi(n)$ függvény:** Az $n$-nél kisebb, $n$-hez relatív prím pozitív egészek száma. Gyengén multiplikatív (ha $(m,n)=1 \implies \phi(mn)=\phi(m)\phi(n)$).
* **Euler-tétel:** Ha $(a,n) = 1 \implies a^{\phi(n)} \equiv 1 \pmod n$.
* **Fermat-tétel:** Ha $p$ prím és $p \nmid a \implies a^{p-1} \equiv 1 \pmod p$.
* **Kiszámítása:** $n = p_1^{k_1} \dots p_r^{k_r} \implies \phi(n) = n \cdot \prod_{i=1}^r \left(1 - \frac{1}{p_i}\right)$.

