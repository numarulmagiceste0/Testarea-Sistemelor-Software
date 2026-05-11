# Rezolvitor Cuadratic

Proiect realizat în C# (.NET 9) care rezolvă ecuații de gradul I și II cu coeficienți reali, returnând soluții reale sau complexe formatate ca șiruri de caractere.

## Structura proiectului
```bash
rezolvitor_cuadratic/
├── cod/
│   ├── cod_rezolvitor.csproj
│   └── rezolvitor_cuadratic.cs          # Codul sursă principal
├── teste/
│   ├── teste_rezolvitor.csproj
│   ├── teste_functionale_rezolvitor_cuadratic.cs
│   ├── teste_structurale_rezolvitor_cuadratic.cs
│   └── teste_mutanti_rezolvitor_cuadratic.cs
├── diagrame/
│   ├── GRAF CAUZA-EFECT.drawio.pdf      # Graful cauză-efect
│   └── graful progamului.svg            # Graful de flux al programului
├── imagini/
│   ├── coverage.png                     # Raport acoperire cod
│   ├── mutanti.png                      # Raport testare mutanți (Stryker)
│   └── teste.png                        # Rezultatul rulării testelor
├── coverage-report/                     # Raport HTML generat de Coverlet
└── rezolvitor_cuadratic.sln
```

## Funcționalitate

Clasa `rezolvitor_cuadratic` expune metoda publică:

string afisare_rezolvare(double coeficient_patratic, double coeficient_liniar, double coeficient_liber)

Aceasta rezolvă ecuația `a·x² + b·x + c = 0` și returnează:

| Caz | Exemplu intrare | Rezultat returnat |
|-----|-----------------|-------------------|
| `a=0, b=0, c=0` | `(0, 0, 0)` | `"Solutia poate fi orice numar complex."` |
| `a=0, b=0, c≠0` | `(0, 0, 5)` | `"Nu exista solutii."` |
| `a=0, b≠0` | `(0, 2, -4)` | `"Solutia este: 2."` |
| `a≠0, Δ=0` | `(1, -2, 1)` | `"Solutia este: 1."` |
| `a≠0, Δ>0` | `(1, -5, 6)` | `"Solutiile sunt: 2 si 3."` |
| `a≠0, Δ<0` | `(1, 0, 1)` | `"Solutiile sunt: -i si i."` |

## Rulare

# Clonare proiect
git clone <url-repo>
cd rezolvitor_cuadratic

# Rulare teste
dotnet test

# Generare raport acoperire (necesită coverlet și reportgenerator)
dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"teste/TestResults/**/coverage.cobertura.xml" -targetdir:"coverage-report"

## Testare

Proiectul conține **36 de teste** organizate în trei fișiere:

### Teste funcționale (`teste_functionale_rezolvitor_cuadratic.cs`)
Verifică comportamentul corect al metodei publice prin:
- **Clase de echivalență** (E1–E4): ecuație fără soluții, cu infinitate de soluții, cu o soluție, cu două soluții.
- **Analiza valorilor de frontieră** (F1–F4): tranziții între coeficienți nuli/nenuli și valori ale discriminantului.
- **Partiționare în categorii** (C1–C11): combinații exhaustive ale semnelor coeficienților și ale discriminantului.

### Teste structurale (`teste_structurale_rezolvitor_cuadratic.cs`)
Verifică acoperirea grafului de flux al programului (27 noduri, 35 arce, complexitate ciclomatică V(G) = 10):
- **Acoperire instrucțiuni** — toate cele 27 de noduri executate.
- **Acoperire decizii** — toate ramurile adevărat/fals parcurse.
- **Acoperire condiții** — fiecare condiție simplă evaluată cu `true` și `false`.
- **Circuite independente** — cele 6 trasee fezabile din cele 10 teoretice identificate și justificate.

### Teste mutanți (`teste_mutanti_rezolvitor_cuadratic.cs`)
Teste dedicate uciderii mutanților supraviețuitori detectați cu **Stryker.NET**, vizând formule critice (discriminant, numitor, parte reală/imaginară).

### Rezultate

| Metrică | Valoare |
|---------|---------|
| Teste totale | 36 |
| Teste trecute | 36 |
| Acoperire linii | **100%** (41/41) |
| Acoperire ramuri | **100%** (38/38) |
| Scor mutanți (Stryker) | **97.37%** (72/74 uciși) |

## Diagrame

### Graful cauză-efect
Modelează relațiile logice dintre condițiile de intrare (`a` nul, `b` nul, `c` nul, `Δ` nul) și efectele posibile (fără soluții, infinitate de soluții, soluție unică, două soluții) folosind operatori `&&` și `NAND`.

### Graful programului
Graf de flux cu 27 de noduri care acoperă toate ramurile de execuție ale metodelor `rezolva_ecuatie_liniara`, `rezolva` și `afisare_rezolvare`.

## Tehnologii folosite

- **Limbaj:** C# (.NET 9)
- **Framework testare:** xUnit
- **Acoperire cod:** Coverlet + ReportGenerator
- **Testare mutanți:** Stryker.NET
