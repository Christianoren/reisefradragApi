using reisefradragApi.Models;

namespace reisefradragApi.Services
{
    public class ReisefradragService
    {
        public ReisefradragResult Reisefradrag(ReisefradragRequest rfr)
        {
            const double fradragSatsEn = 1.5;
            const double fradragSatsTo = 0.7;
            const int oevreGrense = 75000;
            const int nedreGrense = 50000;
            const int minsteFradragBomFerge = 3400;
            const int egenandel = 22000;

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

            if (rfr.UtgifterBomFergeEtc > minsteFradragBomFerge)
            {
                reisefradragSum += rfr.UtgifterBomFergeEtc;
            }

            if (kmTotalt > oevreGrense)
            {
                reisefradragSum += 50000 * fradragSatsEn;
                reisefradragSum += 25000 * fradragSatsTo;
            }

            if (kmTotalt > nedreGrense && kmTotalt <= oevreGrense)
            {
                reisefradragSum += 50000 * fradragSatsEn;
                reisefradragSum += (kmTotalt - 50000) * fradragSatsTo;
            }

            if (kmTotalt <= nedreGrense && kmTotalt > 0)
            {
                reisefradragSum += kmTotalt * fradragSatsEn;
            }

            reisefradragSum -= egenandel;

            return new ReisefradragResult { Reisefradrag = reisefradragSum };
        }
    }
}