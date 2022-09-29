using PUC.MinhaAcademiaPlus.Domain.Interfaces;
using Tasken.SRC.Infra.Data;

namespace PUC.MinhaAcademiaPlus.Infra.Data
{
    public class MainRepository : BaseRepository, IMainRepository
    {
        public MainRepository(Context context) : base(context)
        {
        }

    }
}
