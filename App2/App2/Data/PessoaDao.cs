﻿using App2.Models;
using SQLite;
using System.Threading.Tasks;

namespace App2.Data
{
    public class PessoaDao
    {
        private readonly SQLiteAsyncConnection _context;
        static object locker = new object();

        public PessoaDao(string dbPath)
        {
            _context = new SQLiteAsyncConnection(dbPath);

            //_context.CreateTableAsync<Endereco>().Wait();
            //_context.CreateTableAsync<Telefone>().Wait();
            _context.CreateTableAsync<Pessoas>().Wait();
        }

        public Task<Pessoas> GetPessoas(string cpf)
        {
            lock (locker)
            {
                if (string.IsNullOrEmpty(cpf)) { return null; }

                return _context.Table<Pessoas>().Where(x => x.CPF == cpf && x.Ativo == true).FirstOrDefaultAsync();
            }
        }

        public bool SalvarPessoa(Pessoas pessoas)
        {
            if (pessoas == null)
            {
                return false;
            }
            lock (locker)
            {
                if (string.IsNullOrEmpty(pessoas.CPF))
                {
                    _context.UpdateAsync(pessoas);
                    return true;
                }
                else
                {
                    pessoas.Ativo = true;
                    _context.InsertAsync(pessoas);
                    return true;
                }
            }
        }

        public bool DeletarPessoa(string cpf)
        {
            lock (locker)
            {
                if (cpf != null)
                {
                    var pessoa = _context.Table<Pessoas>().Where(x => x.CPF == cpf && x.Ativo == true).FirstOrDefaultAsync();
                    _context.DeleteAsync(pessoa);
                    return true;
                }
            }
            return false;
        }
    }
}
