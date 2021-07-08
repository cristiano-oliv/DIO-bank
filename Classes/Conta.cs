using System;

namespace DIO_bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; } 
        private string Nome { get; set; }

        // Construtor da classe:
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome; 
        }

        public bool sacarDinheiro (double valorSaque) // O método retorna um booleano  
                                                        // 0 - Operação não realizada | 1 - Operação realizada
        {
            //Validação de saldo suficiente:
            if (this.Saldo - valorSaque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;
            }
            
            this.Saldo = this.Saldo - valorSaque;
            Console.WriteLine("{0}, o saldo atual de sua conta é R$ {1}.", this.Nome, this.Saldo);
            return true;
        }

        public void depositarDinheiro (double valorDeposito) 
        {
            this.Saldo = this.Saldo + valorDeposito;
            Console.WriteLine("{0}, o saldo atual de sua conta é R$ {1}.", this.Nome, this.Saldo);
        }

        public bool transferirDinheiro (double valorTransferencia, Conta contaDestino)
        {
            if (this.sacarDinheiro(valorTransferencia) == true)
            {
                contaDestino.depositarDinheiro(valorTransferencia);
                Console.WriteLine("Transferência efetuada com sucesso.");
                return true;
            }

            else 
            {
                Console.WriteLine("A transferência não poude ser efetuada.");
                return false;
            }
        }

        public override string ToString()
        {
            string infoConta = "";
            infoConta += "Tipo Conta: " + this.TipoConta + " | ";
            infoConta += "Nome: " + this.Nome + " | ";
            infoConta += "Saldo: " + this.Saldo + " | ";
            infoConta += "Credito: " + this.Credito;
            return infoConta;
        }

    }
}