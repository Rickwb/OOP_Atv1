using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Animal
    {
        public string Nome { get; protected set; }

        public abstract string Falar();

    }


    public class Cachorro : Animal
    {

        public sealed override string Falar()
        {
            return "au au au";
        }

        public void NomearCahorro()
        {
            Console.WriteLine("Escreva um nome para o cachorro");
            this.Nome = Console.ReadLine();
        }


    }

    public class Doberman : Cachorro
    {
      
    }

    public class DorbermanBR : Doberman
    {
        
    }

    public class Gato : Animal
    {
        public sealed override string Falar()
        {
            return "miau miau";
        }

        public EspeciesGato Especie { get; set; }
    }

    public enum EspeciesGato
    {
        Persa,
        semPelo,
        Garfield
    }

}

