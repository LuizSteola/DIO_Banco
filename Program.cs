using System;
using System.Collections.Generic;

namespace ProjetoBankDIO
{
    class Program
    {

        static List<Conta> listaContas = new List<Conta>();


        static void Main(string[] args)
        {

            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario != "X"){
                switch (opcaoUsuario){
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();                
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços. Até breve!");
            Console.ReadLine();
          
        }

        private static void Transferir()
        {
            Console.WriteLine("***Transferir***");
            Console.Write("Digite o número da conta de origem: ");
            int numeroOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int numeroDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            if(valorTransferencia > 0){
                listaContas[numeroOrigem].Transferir(valorTransferencia, listaContas[numeroDestino]);
            } else{
                Console.WriteLine("ERRO: O valor da transferência deve ser maior que R$ 0.00!");
            }

            
        }

        private static void Depositar()
        {
            Console.WriteLine("***Depósito***");
            Console.Write("Informe o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("***Saque***");
            Console.Write("Informe o número da conta:");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Informe o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("***Listar contas***");

            if(listaContas.Count == 0){
                Console.WriteLine("Nenhuma Conta Cadastrada");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("# {0} - ", i);
                Console.WriteLine(conta);
                Console.WriteLine();
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("***INSERIR CONTA***");
            int entradaTipoConta;
            do{
                Console.Write("Digite 1 para Conta física e 2 para Jurídica: ");
                entradaTipoConta = int.Parse(Console.ReadLine());
                    if(entradaTipoConta != 1 && entradaTipoConta != 2 ){
                    Console.WriteLine("Valor inválido. Escolha entre 1 ou 2.");
                    }
            }while(entradaTipoConta != 1 && entradaTipoConta != 2 );
        
            Console.Write("Digite o Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito inicial: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);

            listaContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario(){
        Console.WriteLine();
        Console.WriteLine("*** DIO Bank ***");
        Console.WriteLine("Informe a opção desejada: ");
        Console.WriteLine();
        Console.WriteLine("1 - Listar Contas");
        Console.WriteLine("2 - Inserir nova conta");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Sacar");
        Console.WriteLine("5 - Depositar");
        Console.WriteLine("C - Limpar Tela");
        Console.WriteLine("X - Sair");

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine(); 
        return opcaoUsuario;

    }
    
    }
    
}
