using System;
using System.Collections.Generic;

namespace BankAPP
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper()!= "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                    //Listar Contas
                    MenuListarConta();
                    break;

                    case "2":
                    //Inserir Conta
                    MenuInserirConta();
                    break;

                    case "3":
                    //Transferir
                    MenuTransferir();
                    break;

                    case "4":
                    //Sacar
                    MenuSacar();
                    break;

                    case "5":
                    //Depositar
                    MenuDepositar();
                    break;

                    case "C":
                    //Limpar Tela
                    Console.Clear();
                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();  
            }

            Console.WriteLine("");
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }


        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("BankAPP ao seu dispor!");
            Console.WriteLine("Informe a opçao desejada:");
            Console.WriteLine("1- Listar Contas;");
            Console.WriteLine("2- Inserir nova conta;");
            Console.WriteLine("3- Transferir;");
            Console.WriteLine("4- Sacar;");
            Console.WriteLine("5- Depositar;");
            Console.WriteLine("C- Limpar Tela;");
            Console.WriteLine("X- Sair.");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void MenuListarConta()
        {
            Console.WriteLine("Listar contas");

			if (listContas.Count == 0)
			{
				Console.WriteLine("Nenhuma conta cadastrada.");
				return;
			}

			for (int i = 0; i < listContas.Count; i++)
			{
				Conta conta = listContas[i];
				Console.Write("#{0} - ", i);
				Console.WriteLine(conta);
			}
        }
        private static void MenuInserirConta()
        {
            Console.WriteLine("Inserir nova conta.");
            
            Console.WriteLine("Digite 1 para conta PF e 2 para conta PJ:");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o nome do cliente:");
            string entradaNome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Digite o saldo inicial:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Digite o crédito:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
        
            listContas.Add(novaConta);
        }

        private static void MenuTransferir()
        {
            Console.Write("Digite o número da conta de origem: ");
			int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
			int indiceContaDestino = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor a ser transferido: ");
			double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);
        }

        private static void MenuSacar()
        {
            Console.WriteLine("Digite a conta da qual deseja sacar:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Sacar(valorSaque); //não é preciso passar o indice para a rotina Sacar()
            // porque já está com dos dados referentes à conta indiceContaOrigem.
        }

        private static void MenuDepositar()
        {
            Console.Write("Digite o número da conta de destino: ");
		    int indiceContaDestino = int.Parse(Console.ReadLine());   

            Console.Write("Digite o valor a ser depositado: ");
			double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceContaDestino].Depositar(valorDeposito); //à semelhanca do MenuSacar...
        }
    } 
}
