using reisefradragApi.Models;

namespace reisefradragApi.Services
{
    public class ReisefradragService
    {
        public ReisefradragResult Reisefradrag(ReisefradragRequest rfr)
        {
            var result = new ReisefradragResult { Reisefradrag = 1337 };
            return result;
        }
    }
}