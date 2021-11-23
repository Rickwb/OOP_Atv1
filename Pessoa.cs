using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOP
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }

        public Pessoa(string nom, string sobre, string cpf)
        {

            this.Nome = nom;
            this.Sobrenome = sobre;

            char[] cpfLimpo = LimparCpf(cpf);
            if (cpf.Length == 11)
            {
                this.CPF = cpf;
            }
        }

        private char[] LimparCpf(string c)
        {
            c = c.Trim();
            c = c.Replace("-", "");
            c = c.Replace(".", "");
            return c.ToArray();
        }


    }


    public class Cliente : Pessoa
    {
        public Cliente(string nom, string sobre, string CPF) : base(nom, sobre, CPF)
        {
        }

        public int Idade { get; set; }
        public string? Telefone { get; set; }

        public Sorteio Sorteio { get; set; }
        private void Cadastrar(string Nome, string Sobrenome, string Cpf, string telefone, int Idade)
        {
            try
            {
                if (ValidarCliente(Nome,Sobrenome,Cpf,telefone,Idade))
                {
                this.Nome = Nome;
                this.Sobrenome = Sobrenome;
                this.CPF = Cpf;
                this.Telefone = telefone;
                this.Idade = Idade;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {

            }

        }

        private bool ValidarCliente(string Nome, string Sobrenome, string Cpf, string telefone, int Idade)
        {
                if (Nome.Where(c => char.IsDigit(c)).Any() == true || Sobrenome.Where(c => char.IsDigit(c)).Any() == true
                    || telefone.Where(c => char.IsLetter(c)).Any() == false || Cpf.Where(c => char.IsLetter(c)).Any() == false)
                {
                    return false;
                }
                if (Idade<18)
                {
                    return false;
                }
                return true;

        }

        public bool VerificarResultado(Sorteio sort)
        {
                if (sort.Clientes.Contains(this))
                {
                    if (sort.IDGanhador == Idade)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
        }

    }

    public class Funcionario : Pessoa
    {
        public Funcionario(string? nom, string? sobre, string? CPF) : base(nom, sobre, CPF)
        {
        }

        public string Cargo { get; set; }

        private Sorteio CadastrarSorteio(string nome, decimal valor)
        {
            Sorteio sort = new Sorteio();
            sort.Nome = nome;
            sort.Premio = valor;

            return sort;
        }

        public int Sortear(Sorteio sort)
        {
            if (sort.Nome != null && sort.Premio != 0)
            {
                Random random = new Random();
                sort.IDGanhador = random.Next(0, 100);
                return random.Next(1, 100);
            }
            else
            {
                return 0;
            }
        }

        public int Sortear(string nom, decimal valor)
        {
            Sorteio sorteio = CadastrarSorteio(nom, valor);
            if (sorteio.Nome != null && sorteio.Premio != 0)
            {
                Random random = new Random();
                sorteio.IDGanhador = random.Next(1, 100);
                return sorteio.IDGanhador;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Sorteio
    {
        public int IDGanhador { get; set; }
        public string Nome { get; set; }
        public decimal Premio { get; set; }

        public List<Cliente> Clientes { get; set; }
    }

    public class VerificarException:Exception
    {
        VerificarException()
        {

        }
        VerificarException(string Message,Exception ex)
        {
            this.Message = Message;
            throw ex;
        }
        VerificarException(string Message)
        {

        }

        public string Message { get; set; }
    }
    
}
