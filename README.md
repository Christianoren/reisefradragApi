# ReisefradragApi

## Hva er ReisefradragApi?

Dette er et WebApi som tar inn reiseinformasjon som JSON og returnerer beregnet reisefradrag som JSON.

Eksempel p� input-data er:
```
{
	"arbeidsreiser":[{"km":91,"antall":180},{"km":378,"antall":4}],
	"besoeksreiser":[{"km":580,"antall":4}],
	"utgifterBomFergeEtc":4850
}
```

Og svaret vil v�re p� f�lgende format:
```
{
	"reisefradrag":13168
}
```

## Forretningslogikk

Reisefradraget beregnes som f�lger for inntekts�ret 2017:
1. Totalt antall kilometer beregnes for alle arbeids- og bes�ksreiser. �vre grense er 75 000 kilometer.
2. Det gis kr 1,50/km i fradrag for reiser opp til 50 000 km, deretter 0,70 kr opp til 75 000 km.
3. Hvis utgifter til bom, ferge etc. overstiger kr 3 400 s� gis hele bel�pet i fradrag, ellers gis ingenting.
4. Fra summen av kilometerfradraget og utgifter til bom, ferge etc. trekkes fra en egenandel p� kr 22 000. Resten er reisefradraget.

## Utvikling, valg og tanker

### WebApi oppsett

Dotnet 5, WebApi template for � raskt f� opp et prosjekt som kj�rer. Fikk ogs� testet ut code-gen tool for � generere en controller klasse.

### DI

Valgte � lage og demonstrere en service for reisefradrag hvor alt av forretningslogikk foreg�r. Denne blir s� injectet via DI.

### Validering

Validerer incoming request med FluentValidation. Hvis validering feiler vil bruker motta feilmelding(er) med hva som er galt.

