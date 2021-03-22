using reisefradragApi.Models;

namespace reisefradragApi.Services
{
    public class ReisefradragService
    {
        public ReisefradragResult Reisefradrag(ReisefradragRequest rfr)
        {
            const double FradragSatsEn = 1.5;
            const double FradragSatsTo = 0.7;
            const int OevreGrense = 75000;
            const int NedreGrense = 50000;
            const int MinsteFradragBomFerge = 3400;
            const int Egenandel = 22000;

            int kmTotalt = 0;
            double reisefradragSum = 0;

            foreach (var arbeidsreise in rfr.Arbeidsreiser)
            {
                var antallKmPerArbeidsreise = arbeidsreise.Km * arbeidsreise.Antall;
                kmTotalt += antallKmPerArbeidsreise;
            }

            foreach (var besoeksreiser in rfr.Besoeksreiser)
            {
                var kmPerBesoeksreise = besoeksreiser.Km * besoeksreiser.Antall;
                kmTotalt += kmPerBesoeksreise;
            }

            if (rfr.UtgifterBomFergeEtc > MinsteFradragBomFerge)
            {
                reisefradragSum += rfr.UtgifterBomFergeEtc;
            }

            if (kmTotalt > OevreGrense)
            {
                reisefradragSum += 50000 * FradragSatsEn;
                reisefradragSum += 25000 * FradragSatsTo;
            }

            if (kmTotalt > NedreGrense && kmTotalt <= OevreGrense)
            {
                reisefradragSum += 50000 * FradragSatsEn;
                reisefradragSum += (kmTotalt - 50000) * FradragSatsTo;
            }

            if (kmTotalt <= NedreGrense && kmTotalt > 0)
            {
                reisefradragSum += kmTotalt * FradragSatsEn;
            }

            reisefradragSum -= Egenandel;

            return new ReisefradragResult { Reisefradrag = reisefradragSum };
        }
    }
}