using Ckm.Convites.Entities;
using Ckm.Convites.Repository.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using static System.Data.CommandType;  


namespace Ckm.Convites.Repository
{
    public class PessoaRepository :  BaseRepository, IPessoaRepository
    {
        public bool Add(Pessoa pessoa)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Nome", pessoa.Nome);
                parameters.Add("@Telefone", pessoa.Telefone);
                parameters.Add("@Email", pessoa.Email);
                parameters.Add("@Cpf", pessoa.Cpf);
                parameters.Add("@DataCadastro", DateTime.Now);
                SqlMapper.Execute(con, "AddPessoa", param:parameters, commandType:StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int pessoaId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PessoaId", pessoaId);
            SqlMapper.Execute(con, "DeletePessoa", param:parameters, commandType:StoredProcedure);
            return true;
        }

        public IList<Pessoa> GetAll()
        {
            IList<Pessoa> customerList = SqlMapper.Query<Pessoa>(con, "GetAllPessoa", commandType:StoredProcedure).ToList();
            return customerList;
        }

        public Pessoa GetById(int pessoaId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PessoaID", pessoaId);
                return SqlMapper.Query<Pessoa>((SqlConnection)con, "GetPessoaById", parameters, commandType:StoredProcedure).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Pessoa pessoa)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PessoaId", pessoa.PessoaId);
                parameters.Add("@Nome", pessoa.Nome);
                parameters.Add("@Telefone", pessoa.Telefone);
                parameters.Add("@Email", pessoa.Email);
                parameters.Add("@Cpf", pessoa.Cpf);
                SqlMapper.Execute(con, "Update", param: parameters, commandType: StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
