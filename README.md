# ReisefradragApi

## Hva er ReisefradragApi?

Dette er et WebApi som tar inn reiseinformasjon som JSON og returnerer beregnet reisefradrag som JSON.

Eksempel på input-data er:
```
{
	"arbeidsreiser":[{"km":91,"antall":180},{"km":378,"antall":4}],
	"besoeksreiser":[{"km":580,"antall":4}],
	"utgifterBomFergeEtc":4850
}
```

Og svaret vil være på følgende format:
```
{
	"reisefradrag":13168
}
```

## Forretningslogikk

Reisefradraget beregnes som følger for inntektsåret 2017:
1. Totalt antall kilometer beregnes for alle arbeids- og besøksreiser. Øvre grense er 75 000 kilometer.
2. Det gis kr 1,50/km i fradrag for reiser opp til 50 000 km, deretter 0,70 kr opp til 75 000 km.
3. Hvis utgifter til bom, ferge etc. overstiger kr 3 400 så gis hele beløpet i fradrag, ellers gis ingenting.
4. Fra summen av kilometerfradraget og utgifter til bom, ferge etc. trekkes fra en egenandel på kr 22 000. Resten er reisefradraget.

## Utvikling, valg og tanker

### WebApi oppsett

Dotnet 5, WebApi template for å raskt få opp et prosjekt som kjører. Fikk også testet ut code-gen tool for å generere en controller klasse.

### DI

Valgte å lage og demonstrere en service for reisefradrag hvor alt av forretningslogikk foregår. Denne blir så injectet via DI.

### Validering

Validerer incoming request med FluentValidation. Hvis validering feiler vil bruker motta feilmelding(er) med hva som er galt.

