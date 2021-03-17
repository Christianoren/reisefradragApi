using System.Collections.Generic;

namespace reisefradragApi.Models
{
    public class ReisefradragRequest
    {
        public List<Arbeidsreise> Arbeidsreiser { get; set; }
        public List<Besoeksreise> Besoeksreiser { get; set; }
        public int UtgifterBomFergeEtc { get; set; }
        
        public class Arbeidsreise
        {
            public int Km { get; set; }
            public int Antall { get; set; }
        }

        public class Besoeksreise
        {
            public int Km { get; set; }
            public int Antall { get; set; }
        }
    }
}