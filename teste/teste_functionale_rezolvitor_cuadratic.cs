using Xunit;
public class teste_rezolvitor_cuadratic {
    private readonly rezolvitor_cuadratic rezolvitor = new rezolvitor_cuadratic();

    // -------- CLASE DE ECHIVALENTA PENTRU afisare_rezolvare --------
    // Clasa E1: ecuatie degenerata fara solutii
    // Conditie: a nul, b nul, c nenul
    [Fact]
    public void clasa_fara_solutii() {
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));}
    // Clasa E2: ecuatie degenerata cu infinitate de solutii
    // Conditie: a nul, b nul, c nul
    [Fact]
    public void clasa_infinitate_solutii() {
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));}
    // Clasa E3: ecuatie cu o singura solutie
    // Subclasa E3.1: ecuatie liniara, adica a nul si b nenul
    [Fact]
    public void clasa_o_solutie_liniara() {
        Assert.Equal("Solutia este: 1.5.", rezolvitor.afisare_rezolvare(0, 6, -9));}
    // Subclasa E3.2: ecuatie cuadratica, adica a nenul si delta nul
    [Fact]
    public void clasa_o_solutie_cuadratica() {
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));}
    // Clasa E4: ecuatie cu doua solutii
    // Conditie: a nenul si delta nenul
    [Fact]
    public void clasa_doua_solutii() {
        Assert.Equal("Solutiile sunt: -2.82843 si 2.82843.", rezolvitor.afisare_rezolvare(1, 0, -8));}

    // -------- ANALIZA VALORILOR DE FRONTIERA --------
    // Frontiera F1: trecerea dintre coeficient patratic nul si coeficient patratic nenul
    // Cazul F1.1: coeficient patratic nul
    [Fact]
    public void frontiera_coeficient_patratic_nul() {
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));}
    // Cazul F1.2: coeficient patratic nenul
    [Fact]
    public void frontiera_coeficient_patratic_nenul() {
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(-1, 2, -1));}
    // Frontiera F2: trecerea dintre delta negativ, delta nul si delta pozitiv
    // Cazul F2.1: delta negativ
    [Fact]
    public void frontiera_delta_negativ() {
        Assert.Equal("Solutiile sunt: -i si i.", rezolvitor.afisare_rezolvare(1, 0, 1));}
    // Cazul F2.2: delta nul
    [Fact]
    public void frontiera_delta_nul() {
        Assert.Equal("Solutia este: -1.", rezolvitor.afisare_rezolvare(1, 2, 1));}
    // Cazul F2.3: delta pozitiv
    [Fact]
    public void frontiera_delta_pozitiv() {
        Assert.Equal("Solutiile sunt: -3.4641 si 3.4641.", rezolvitor.afisare_rezolvare(1, 0, -12));}
    // Frontiera F3: pentru coeficient patratic nul, trecerea dintre coeficient liniar nenul si coeficient liniar nul
    // Cazul F3.1: coeficient liniar nenul
    [Fact]
    public void frontiera_coeficient_liniar_nenul() {
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(0, 1, -1));}
    // Cazul F3.2: coeficient liniar nul
    [Fact]
    public void frontiera_coeficient_liniar_nul() {
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));}
    // Frontiera F4: pentru coeficient patratic nul si coeficient liniar nul, trecerea dintre coeficient liber nenul si coeficient liber nul
    // Cazul F4.1: coeficient liber nenul
    [Fact]
    public void frontiera_coeficient_liber_nenul() {
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));}
    // Cazul F4.2: coeficient liber nul
    [Fact]
    public void frontiera_coeficient_liber_nul() {
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));}

    // -------- PARTITIONARE IN CATEGORII --------
    // Categorii: coeficient patratic nul sau nenul, delta negativ sau nul sau pozitiv, coeficient liniar nul sau nenul, coeficient liber nul sau nenul
    // Observatie: combinatiile imposibile matematic sunt eliminate deoarece delta = b*b - 4*a*c
    // Categoria C1: coeficient patratic nul, delta nul, coeficient liniar nul, coeficient liber nul
    [Fact]
    public void categorie_coeficient_patratic_nul_delta_nul_coeficient_liniar_nul_coeficient_liber_nul() {
        Assert.Equal("Solutia poate fi orice numar complex.", rezolvitor.afisare_rezolvare(0, 0, 0));}
    // Categoria C2: coeficient patratic nul, delta nul, coeficient liniar nul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nul_delta_nul_coeficient_liniar_nul_coeficient_liber_nenul() {
        Assert.Equal("Nu exista solutii.", rezolvitor.afisare_rezolvare(0, 0, 5));}
    // Categoria C3: coeficient patratic nul, delta pozitiv, coeficient liniar nenul, coeficient liber nul
    [Fact]
    public void categorie_coeficient_patratic_nul_delta_pozitiv_coeficient_liniar_nenul_coeficient_liber_nul() {
        Assert.Equal("Solutia este: 0.", rezolvitor.afisare_rezolvare(0, 2, 0));}
    // Categoria C4: coeficient patratic nul, delta pozitiv, coeficient liniar nenul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nul_delta_pozitiv_coeficient_liniar_nenul_coeficient_liber_nenul() {
        Assert.Equal("Solutia este: 2.", rezolvitor.afisare_rezolvare(0, 2, -4));}
    // Categoria C5: coeficient patratic nenul, delta negativ, coeficient liniar nul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_negativ_coeficient_liniar_nul_coeficient_liber_nenul() {
        Assert.Equal("Solutiile sunt: -4.24264*i si 4.24264*i.", rezolvitor.afisare_rezolvare(1, 0, 18));}
    // Categoria C6: coeficient patratic nenul, delta negativ, coeficient liniar nenul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_negativ_coeficient_liniar_nenul_coeficient_liber_nenul() {
        Assert.Equal("Solutiile sunt: -0.5 - 0.86603*i si -0.5 + 0.86603*i.", rezolvitor.afisare_rezolvare(1, 1, 1));}
    // Categoria C7: coeficient patratic nenul, delta nul, coeficient liniar nul, coeficient liber nul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_nul_coeficient_liniar_nul_coeficient_liber_nul() {
        Assert.Equal("Solutia este: 0.", rezolvitor.afisare_rezolvare(1, 0, 0));}
    // Categoria C8: coeficient patratic nenul, delta nul, coeficient liniar nenul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_nul_coeficient_liniar_nenul_coeficient_liber_nenul() {
        Assert.Equal("Solutia este: 1.", rezolvitor.afisare_rezolvare(1, -2, 1));}
    // Categoria C9: coeficient patratic nenul, delta pozitiv, coeficient liniar nul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_pozitiv_coeficient_liniar_nul_coeficient_liber_nenul() {
        Assert.Equal("Solutiile sunt: -4.24264 si 4.24264.", rezolvitor.afisare_rezolvare(1, 0, -18));}
    // Categoria C10: coeficient patratic nenul, delta pozitiv, coeficient liniar nenul, coeficient liber nul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_pozitiv_coeficient_liniar_nenul_coeficient_liber_nul() {
        Assert.Equal("Solutiile sunt: 0 si 1.", rezolvitor.afisare_rezolvare(1, -1, 0));}
    // Categoria C11: coeficient patratic nenul, delta pozitiv, coeficient liniar nenul, coeficient liber nenul
    [Fact]
    public void categorie_coeficient_patratic_nenul_delta_pozitiv_coeficient_liniar_nenul_coeficient_liber_nenul() {
        Assert.Equal("Solutiile sunt: 2 si 3.", rezolvitor.afisare_rezolvare(1, -5, 6));}}