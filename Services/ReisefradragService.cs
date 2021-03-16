using reisefradragApi.Models;

namespace reisefradragApi.Services
{
    public class ReisefradragService
    {
        public ReisefradragResult Reisefradrag(ReisefradragRequest rfr)
        {
            //TODO: calculate deduction
            //Norsk engelsk?
            const double deductionRateOne = 1.5;
            const double deductionRateTwo = 0.7;
            const int minsteFradragBomFerge = 3400;

            int fradragBomFergeEtc = 0;
            int kmSum = 0;

            foreach (var arbeidsreise in rfr.Arbeidsreiser)
            {
                var sum = arbeidsreise.Km * arbeidsreise.Antall;
                kmSum += sum;
            }

            foreach (var besoeksreiser in rfr.Besoeksreiser)
            {
                var sum = besoeksreiser.Km * besoeksreiser.Antall;
                kmSum += sum;
            }

            if (rfr.UtgifterBomFergeEtc > minsteFradragBomFerge)
            {
                fradragBomFergeEtc += rfr.UtgifterBomFergeEtc;
            }



            // For testing
            var result = new ReisefradragResult { Reisefradrag = 1337 };
            return result;
        }
    }
}