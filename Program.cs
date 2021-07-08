using System;
using System.Collections.Generic;

namespace DIO_bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        // Listar contas
                        ListarContas();
                        break;

                    case "2":
                        // Inserir nova conta
                        inserirConta();
                        break;

                    case "3":
                        // Transferir dinheiro
                        transferir();
                        break;

                    case "4":
                        // Sacar dinheiro
                        sacar();
                        break;

                    case "5":
                        // Depositar
                        depositar();
                        break;

                    case "C":
                        // Limpar o console
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar os nossos serviços!");
            Console.WriteLine(); 
        }

        private static void transferir()
        {
            Console.Write("Digite o índice da conta de origem: ");
            int contaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o índice da conta de destino: ");
            int contaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[contaOrigem].transferirDinheiro(valorTransferencia, listaContas[contaDestino]);
        }

        private static void depositar()
        {
            Console.Write("Digite o índice da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].depositarDinheiro(valorDeposito);
        }

        private static void sacar()
        {
            Console.Write("Digite o índice da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].sacarDinheiro(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine();
            Console.WriteLine("Listar Contas:");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return; // Para sair do método caso não existam contas cadastradas
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i]; //Um objeto conta é criado a partir da listaContas
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta); //Executa o método. Conta.toString()
            }
        }

        private static void inserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 - Pessoa Física ou 2 - Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine()); // int.Parse() converte uma string em inteiro

            Console.Write("Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Saldo inicial da conta: ");
            double entradaSaldo = double.Parse(Console.ReadLine()); // double.Parse() converte uma string em um double

            Console.Write("Crédito da conta: ");
            double entradaCredito = double.Parse(Console.ReadLine());
            Console.WriteLine();

            //Criando uma nova conta:
            Conta novaConta = new Conta( tipoConta: (TipoConta)entradaTipoConta, // Conversão da entradaTipoConta para enum TipoConta
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);

            // Adicionando a lista de contas:
            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank ao seu dispor!");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }

}
