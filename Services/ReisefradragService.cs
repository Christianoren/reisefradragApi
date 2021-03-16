using reisefradragApi.Models;
namespace reisefradragApi.Services
{
    //Service..
    public class ReisefradragService
    {
        public ReisefradragResult Reisefradrag()
        {
            var result = new ReisefradragResult { Reisefradrag = 1337 };
            return result;
        }
    }
}