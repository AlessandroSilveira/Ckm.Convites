using Ckm.Convites.Entities;
using System.Collections.Generic;

namespace Ckm.Convites.Business.Interfaces
{
    public interface IPessoaManager
    {
        bool Add(Pessoa pessoa);
        bool Update(Pessoa pessoa);
        bool Delete(int pessoaId);
        IList<Pessoa> GetAll();
        Pessoa GetById(int pessoaId);
    }
}
