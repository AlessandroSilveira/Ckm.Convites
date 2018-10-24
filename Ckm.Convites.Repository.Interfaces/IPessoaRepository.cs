using Ckm.Convites.Entities;
using System.Collections.Generic;

namespace Ckm.Convites.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        bool Add (Pessoa pessoa);
        bool Update (Pessoa pessoa);
        bool Delete (int pessoaId);
        IList<Pessoa> GetAll();
        Pessoa GetById(int pessoaId);
    }
}
