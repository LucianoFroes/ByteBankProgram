using System;

namespace ByteBank {
     class Menus {

        Usuario usuario = new Usuario();    

        public void MostrarMenu() {

            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Total armazenado no banco");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("\nDigite a opção desejada: ");
        }

        public void MostrarMenuManipularConta() {

            Console.WriteLine("1 - Fazer depósito");
            Console.WriteLine("2 - Realizar saque");
            Console.WriteLine("3 - Realizar transferência");
            Console.WriteLine("0 - Voltar");
            Console.Write("\nDigite a opção desejada: ");
        }
    }
}
