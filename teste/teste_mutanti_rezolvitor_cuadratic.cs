using Xunit;
using System.Reflection;

public class teste_mutanti_rezolvitor_cuadratic {
    private readonly rezolvitor_cuadratic rezolvitor = new rezolvitor_cuadratic();

    [Fact]
    public void omoara_mutant_calcul_delta_cu_a_diferit_de_unu() {
        // Cod original: double delta = b*b - 4*a*c;
        // Cod mutant:   double delta = b*b - 4/a*c;
        // Problema: mutantul schimba formula discriminantului si imparte 4 la a in loc sa inmulteasca 4 cu a.
        Assert.Equal("Solutiile sunt: 1 si 2.", rezolvitor.afisare_rezolvare(2, -6, 4));}

    [Fact]
    public void omoara_mutant_numitor_solutie_unica_delta_zero() {
        // Cod original: -b/(2*a)
        // Cod mutant:   -b/(2/a)
        // Problema: mutantul modifica numitorul formulei pentru solutia unica.
        Assert.Equal("Solutia este: 3.", rezolvitor.afisare_rezolvare(2, -12, 18));}

    [Fact]
    public void omoara_mutant_numitor_solutii_reale_delta_pozitiv() {
        // Cod original: (-b + indice_semn*radical)/(2*a)
        // Cod mutant:   (-b + indice_semn*radical)/(2/a)
        // Problema: mutantul strica numitorul formulei pentru doua solutii reale.
        Assert.Equal("Solutiile sunt: 1 si 2.", rezolvitor.afisare_rezolvare(2, -6, 4));}

    [Fact]
    public void omoara_mutant_numitor_parte_reala_complexa() {
        // Cod original: double parte_reala = -b/(2*a);
        // Cod mutant:   double parte_reala = -b/(2/a);
        // Problema: mutantul calculeaza gresit partea reala a solutiilor complexe.
        Assert.Equal("Solutiile sunt: 1 - i si 1 + i.", rezolvitor.afisare_rezolvare(2, -4, 4));}

    [Fact]
    public void omoara_mutant_numitor_parte_imaginara_complexa() {
        // Cod original: double parte_imaginara = (indice_semn*Math.Sqrt(-delta))/(2*a);
        // Cod mutant:   double parte_imaginara = (indice_semn*Math.Sqrt(-delta))/(2/a);
        // Problema: mutantul calculeaza gresit partea imaginara a solutiilor complexe.
        Assert.Equal("Solutiile sunt: -2*i si 2*i.", rezolvitor.afisare_rezolvare(2, 0, 8));}

    [Fact]
    public void omoara_mutant_semn_minus_i_cu_parte_reala_nenula() {
        // Cod original: if(parte_imaginara==-1)
        // Cod mutant:   if(parte_imaginara==+1)
        // Problema: mutantul inverseaza cazul special pentru -i.
        Assert.Equal("Solutiile sunt: 1 - i si 1 + i.", rezolvitor.afisare_rezolvare(1, -2, 2));}

    [Fact]
    public void omoara_mutant_complex_cu_parte_imaginara_pozitiva_diferita_de_unu() {
        // Cod original: return $"{scrie_numar(parte_reala)} + {scrie_numar(parte_imaginara)}*i";
        // Cod mutant posibil: semnul + sau valoarea partii imaginare este modificata.
        // Problema: testele vechi verificau mai ales cazul cu i simplu, nu cazul cu 2*i.
        Assert.Equal("Solutiile sunt: 1 - 2*i si 1 + 2*i.", rezolvitor.afisare_rezolvare(1, -2, 5));}}