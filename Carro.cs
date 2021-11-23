using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    
    public abstract class Carro
    {
        public string Modelo { get; set; }

        public virtual void Acelerar(int seg)
        {

        }

        public abstract void Freiar();

    }

    public class Bmw : Carro,IDrift
    {
        public double PotenciaHP { get; protected set; }
        public double Velocidade { get; private set; }
        public Stages Stage { get; set; }

        public override void Acelerar(int seg)
        {
            this.Velocidade = this.PotenciaHP * seg;
        }

        public void FazerDrift()
        {
            
        }

        public override void Freiar()
        {
            this.Velocidade = 0;

            
        }
    }

    public class Mercedes : Carro,IDrift
    {

        public double PotenciaHP { get; protected set; }
        public double Velocidade { get; private set; }
        public Stages Stage { get; set; }
        public override void Acelerar(int seg)
        {
            this.Velocidade = this.PotenciaHP * seg;
        }

        public void FazerDrift()
        {
            Acelerar(5);
            if (this.Velocidade != 0)
            {
                do
                {
                Freiar();

                } while (this.Velocidade>=30);
            }

        }

        public override void Freiar()
        {
            this.Velocidade -= 1;
        }
    }

    interface IDrift
    {
        public void FazerDrift();

    }
    public enum Stages
    {
        Stage1,
        Stage2,
        Stage3,
        Stage4
    }
}




