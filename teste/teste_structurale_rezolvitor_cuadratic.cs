using Xunit;

public class teste_structurale_rezolvitor_cuadratic {
    private readonly rezolvitor_cuadratic rezolvitor = new rezolvitor_cuadratic();

    [Fact]
    public void acoperire_instructiuni() {
        // Test 1.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 24 -> 27.
        // Acopera cazul ecuatiei identic nule.
        // Dupa acest test raman neacoperite nodurile:
        // 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 23, 25, 26.
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));

        // Test 2.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(DA) -> 8 -> 22 -> 23 -> 27.
        // Acopera cazul ecuatiei liniare imposibile.
        // Dupa acest test raman neacoperite nodurile:
        // 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 25, 26.
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));

        // Test 3.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(NU) -> 9 -> 22 -> 25 -> 27.
        // Acopera cazul ecuatiei liniare cu solutie unica.
        // Dupa acest test raman neacoperite nodurile:
        // 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 26.
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));

        // Test 4.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(DA) -> 12 -> 22 -> 25 -> 27.
        // Acopera cazul cuadratic cu delta == 0.
        // Dupa acest test raman neacoperite nodurile:
        // 13, 14, 15, 16, 17, 18, 19, 20, 21, 26.
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));

        // Test 5.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(NU) -> 13 -> 14(DA) -> 15 -> 17 -> 19 -> 20(DA)
        // -> 13 -> 14(DA) -> 15 -> 17 -> 19 -> 20(NU) -> 21 -> 22 -> 26 -> 27.
        // Acopera cazul cuadratic cu delta > 0 si doua solutii reale.
        // Dupa acest test raman neacoperite nodurile:
        // 16, 18.
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));

        // Test 6.
        // Parcurge nodurile:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(NU) -> 13 -> 14(NU) -> 16 -> 18 -> 17 -> 19 -> 20(DA)
        // -> 13 -> 14(NU) -> 16 -> 18 -> 17 -> 19 -> 20(NU) -> 21 -> 22 -> 26 -> 27.
        // Acopera cazul cuadratic cu delta < 0 si doua solutii complexe.
        // Dupa acest test nu mai ramane niciun nod neacoperit.
        Assert.Equal("Solutiile sunt: -i si i.", rezolvitor.afisare_rezolvare(1, 0, 1));}

    [Fact]
    public void acoperire_decizii() {
        // Decizia 3: a == 0 este adevarata.
        // Traseu: 1 -> 2 -> 3(DA) -> 4.
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));

        // Decizia 3: a == 0 este falsa.
        // Traseu: 1 -> 2 -> 3(NU) -> 10.
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));

        // Decizia 5: b == 0 && c == 0 este adevarata.
        // Traseu: 4 -> 5(DA) -> 6.
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));

        // Decizia 5 este falsa, iar decizia 7: b == 0 este adevarata.
        // Traseu: 4 -> 5(NU) -> 7(DA) -> 8.
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));

        // Decizia 7: b == 0 este falsa.
        // Traseu: 4 -> 5(NU) -> 7(NU) -> 9.
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));

        // Decizia 11: delta == 0 este adevarata.
        // Traseu: 10 -> 11(DA) -> 12.
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));

        // Decizia 11 este falsa, iar decizia 14: delta > 0 este adevarata.
        // Traseu: 10 -> 11(NU) -> 13 -> 14(DA) -> 15.
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));

        // Decizia 14: delta > 0 este falsa.
        // Traseu: 13 -> 14(NU) -> 16.
        Assert.Equal("Solutiile sunt: -i si i.", rezolvitor.afisare_rezolvare(1, 0, 1));

        // Decizia 20: indice_semn <= 1 este adevarata dupa prima iteratie.
        // Apoi aceeasi decizie devine falsa dupa a doua iteratie.
        // Traseu: 19 -> 20(DA) -> 13, apoi 19 -> 20(NU) -> 21.
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));

        // Nodul 22 alege ramura "Fara solutii".
        // Traseu: 22 -> 23 -> 27.
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));

        // Nodul 22 alege ramura "Infinitate".
        // Traseu: 22 -> 24 -> 27.
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));

        // Nodul 22 alege ramura "O solutie".
        // Traseu: 22 -> 25 -> 27.
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));

        // Nodul 22 alege ramura "Doua solutii".
        // Traseu: 22 -> 26 -> 27.
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));}

    [Fact]
    public void acoperire_conditii() {
        // Conditia 3: a == 0 este adevarata.
        // Conditia compusa 5: b == 0 && c == 0 are ambele conditii simple adevarate.
        // Traseu: 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 24 -> 27.
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));

        // Conditia 3: a == 0 este adevarata.
        // In conditia compusa 5, b == 0 este adevarata, dar c == 0 este falsa.
        // Deci 5 devine falsa, iar 7 devine adevarata.
        // Traseu: 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(DA) -> 8 -> 22 -> 23 -> 27.
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));

        // Conditia 3: a == 0 este adevarata.
        // In conditia compusa 5, b == 0 este falsa.
        // Din cauza operatorului &&, conditia c == 0 nu mai poate schimba rezultatul expresiei.
        // Decizia 7 este falsa, deci se calculeaza solutia liniara.
        // Traseu: 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(NU) -> 9 -> 22 -> 25 -> 27.
        Assert.Equal("Solutia este: 0.", rezolvitor.afisare_rezolvare(0, 2, 0));

        // Conditia 3: a == 0 este falsa.
        // Conditia 11: delta == 0 este adevarata.
        // Traseu: 1 -> 2 -> 3(NU) -> 10 -> 11(DA) -> 12 -> 22 -> 25 -> 27.
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));

        // Conditia 11: delta == 0 este falsa.
        // Conditia 14: delta > 0 este adevarata.
        // Conditia 20: indice_semn <= 1 este adevarata dupa prima iteratie si falsa dupa a doua.
        // Traseu: 13 -> 14(DA) -> 15 -> 17 -> 19 -> 20(DA), apoi 20(NU).
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));

        // Conditia 11: delta == 0 este falsa.
        // Conditia 14: delta > 0 este falsa, deci delta < 0.
        // Se intra in ramura de numere complexe.
        // Traseu: 13 -> 14(NU) -> 16 -> 18 -> 17.
        Assert.Equal("Solutiile sunt: -i si i.", rezolvitor.afisare_rezolvare(1, 0, 1));}

    [Fact]
    public void acoperire_circuite_independente() {
        // Complexitatea ciclomatica a grafului este:
        // V(G) = E - N + 2 = 35 - 27 + 2 = 10.
        // Deci, pe graful brut exista 10 circuite/trasee independente teoretice.
        // Totusi, nu toate sunt fezabile ca executii reale ale metodei publice afisare_rezolvare. Motivul este nodul 22, adica "Verificare finala".
        // Din nodul 22 exista 4 iesiri: 23, 24, 25 si 26. Dar iesirea aleasa depinde strict de lista intoarsa anterior de metoda rezolva.

        // Circuit independent 1 - posibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 24 -> 27.
        // Este posibil deoarece nodul 6 intoarce lista cu mesajul "Solutia poate fi orice numar complex.",
        // iar nodul 22 poate merge corect spre nodul 24.
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));

        // Circuit independent 2 - posibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(DA) -> 8 -> 22 -> 23 -> 27.
        // Este posibil deoarece nodul 8 intoarce lista cu mesajul "Nu exista solutii.",
        // iar nodul 22 poate merge corect spre nodul 23.
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));

        // Circuit independent 3 - posibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(NU) -> 9 -> 22 -> 25 -> 27.
        // Este posibil deoarece nodul 9 intoarce o lista cu o singura solutie numerica,
        // iar nodul 22 poate merge corect spre nodul 25.
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));

        // Circuit independent 4 - posibil:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(DA) -> 12 -> 22 -> 25 -> 27.
        // Este posibil deoarece nodul 12 intoarce o lista cu o singura solutie numerica,
        // iar nodul 22 poate merge corect spre nodul 25.
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));

        // Circuit independent 5 - posibil:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(NU) -> 13 -> 14(DA) -> 15 -> 17 -> 19 -> 20(DA)
        // -> 13 -> 14(DA) -> 15 -> 17 -> 19 -> 20(NU) -> 21 -> 22 -> 26 -> 27.
        // Este posibil deoarece delta > 0 produce doua solutii reale,
        // iar nodul 22 poate merge corect spre nodul 26.
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));

        // Circuit independent 6 - posibil:
        // 1 -> 2 -> 3(NU) -> 10 -> 11(NU) -> 13 -> 14(NU) -> 16 -> 18 -> 17 -> 19 -> 20(DA)
        // -> 13 -> 14(NU) -> 16 -> 18 -> 17 -> 19 -> 20(NU) -> 21 -> 22 -> 26 -> 27.
        // Este posibil deoarece delta < 0 produce doua solutii complexe,
        // iar nodul 22 poate merge corect spre nodul 26.
        Assert.Equal("Solutiile sunt: -i si i.", rezolvitor.afisare_rezolvare(1, 0, 1));

        // Circuit independent 7 - imposibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 23 -> 27.
        // Este imposibil deoarece nodul 6 produce infinitate de solutii.
        // Dupa nodul 6, nodul 22 nu poate merge spre 23, adica "Nu exista solutii.",
        // fiindca lista contine mesajul pentru infinitate, nu mesajul pentru lipsa solutiilor.

        // Circuit independent 8 - imposibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 25 -> 27.
        // Este imposibil deoarece nodul 6 produce mesaj special pentru infinitate de solutii.
        // Dupa nodul 6, nodul 22 nu poate merge spre 25, adica "O solutie",
        // fiindca lista nu contine o solutie numerica normala.

        // Circuit independent 9 - imposibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(DA) -> 6 -> 22 -> 26 -> 27.
        // Este imposibil deoarece nodul 6 produce o lista cu un singur mesaj special.
        // Dupa nodul 6, nodul 22 nu poate merge spre 26, adica "Doua solutii",
        // fiindca lista nu are doua elemente.

        // Circuit independent 10 - imposibil:
        // 1 -> 2 -> 3(DA) -> 4 -> 5(NU) -> 7(DA) -> 8 -> 22 -> 24 -> 27.
        // Este imposibil deoarece nodul 8 produce lipsa solutiilor.
        // Dupa nodul 8, nodul 22 nu poate merge spre 24, adica "Infinitate",
        // fiindca lista contine mesajul "Nu exista solutii.", nu mesajul pentru infinitate.
}}