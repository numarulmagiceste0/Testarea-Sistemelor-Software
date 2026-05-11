using System;
using System.Collections.Generic;
public class rezolvitor_cuadratic{
    private string scrie_numar(double valoare){
        if(valoare==(long)valoare){return((long)valoare).ToString();}
        return valoare.ToString("0.#####");}
private string formeaza_numar_complex(double parte_reala,double parte_imaginara){
    if(parte_reala==0){
        if(parte_imaginara==1){return"i";}
        if(parte_imaginara==-1){return"-i";}
        return$"{scrie_numar(parte_imaginara)}*i";}
    if(parte_imaginara>0){
        if(parte_imaginara==1){return$"{scrie_numar(parte_reala)} + i";}
        return$"{scrie_numar(parte_reala)} + {scrie_numar(parte_imaginara)}*i";}
    else{
        if(parte_imaginara==-1){return$"{scrie_numar(parte_reala)} - i";}
        return$"{scrie_numar(parte_reala)} - {scrie_numar(Math.Abs(parte_imaginara))}*i";}}
    private List<string> rezolva_ecuatie_liniara(double coeficient_liniar,double coeficient_liber){
        if(coeficient_liniar==0&&coeficient_liber==0){return new List<string>{"Solutia poate fi orice numar complex."};}
        if(coeficient_liniar==0){return new List<string>{"Nu exista solutii."};}
        return new List<string>{scrie_numar(-coeficient_liber/coeficient_liniar)};}
    private List<string> rezolva(double coeficient_patratic,double coeficient_liniar,double coeficient_liber){
        double a=coeficient_patratic;
        double b=coeficient_liniar;
        double c=coeficient_liber;
        if(a==0){return rezolva_ecuatie_liniara(b,c);}
        double delta=b*b-4*a*c;
        if(delta==0){return new List<string>{scrie_numar(-b/(2*a))};}
        List<string> solutii=new List<string>();
        for(int indice_semn=-1;indice_semn<=1;indice_semn+=2){
            if(delta>0){
                double radical=Math.Sqrt(delta);
                solutii.Add(scrie_numar((-b+indice_semn*radical)/(2*a)));}
            else{
                double parte_reala=-b/(2*a);
                double parte_imaginara=(indice_semn*Math.Sqrt(-delta))/(2*a);
                solutii.Add(formeaza_numar_complex(parte_reala,parte_imaginara));}}
        return solutii;}
    public string afisare_rezolvare(double coeficient_patratic,double coeficient_liniar,double coeficient_liber){
        List<string> solutii=rezolva(coeficient_patratic,coeficient_liniar,coeficient_liber);
        if(solutii.Count==1&&solutii[0]=="Nu exista solutii."){return"Nu exista solutii.";}
        if(solutii.Count==1&&solutii[0]=="Solutia poate fi orice numar complex."){return"Solutia poate fi orice numar complex.";}
        if(solutii.Count==1){return$"Solutia este: {solutii[0]}.";}
        return$"Solutiile sunt: {solutii[0]} si {solutii[1]}.";}}