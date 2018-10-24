using Ckm.Convites.Business.Interfaces;
using Ckm.Convites.Entities;
using Ckm.Convites.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace Ckm.Convites.Business
{
    public class PessoaManager : IPessoaManager
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaManager(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }
        public bool Add(Pessoa pessoa)
        {
            return _pessoaRepository.Add(pessoa);
        }

        public bool Delete(int pessoaId)
        {
            return _pessoaRepository.Delete(pessoaId);
        }

        public IList<Pessoa> GetAll()
        {
            return _pessoaRepository.GetAll();
        }

        public Pessoa GetById(int pessoaId)
        {
            return _pessoaRepository.GetById(pessoaId);
        }

        public bool Update(Pessoa pessoa)
        {
            return _pessoaRepository.Update(pessoa);
        }
    }
}
