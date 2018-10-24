using Ckm.Convites.Business;
using Ckm.Convites.Business.Interfaces;
using Ckm.Convites.Repository;
using Ckm.Convites.Repository.Interfaces;
using SimpleInjector;

namespace Ckm.Convites.DependencyInjection
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IPessoaManager, PessoaManager>(Lifestyle.Scoped);
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
        }
    }
}
