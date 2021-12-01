using App2.Models;
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
                var cpfExiste = _context.Table<Pessoas>().Where(x => x.CPF == pessoas.CPF && x.Ativo == true).FirstOrDefaultAsync();
                if (cpfExiste != null)
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

        public bool DeletarPessoa(Pessoas pessoas)
        {
            lock (locker)
            {
                if (!string.IsNullOrEmpty(pessoas.CPF))
                {
                    pessoas.Ativo = false;
                    _context.DeleteAsync(pessoas);
                    return true;
                }
            }
            return false;
        }
    }
}
