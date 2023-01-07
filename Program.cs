using System;

namespace ByteBank {
    public class Program {

        public static void Main(string[] args) {

            Menus menus = new Menus();
            Usuario usuario = new Usuario();
            Transacoes transacoes = new Transacoes();

            int opcaoMenu;

            do {

                menus.MostrarMenu();

                opcaoMenu = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------------------------");

                switch (opcaoMenu) {
                    case 0:
                        Console.WriteLine("Programa encerrado.");
                        break;
                    case 1:
                        usuario.CadastrarUsuario();
                        break;
                    case 2:
                        usuario.ExcluirUsuario();
                        break;
                    case 3:
                        usuario.MostrarTodosUsuários();
                        break;
                    case 4:
                        usuario.MostrarDetalhesUsuario();
                        break;
                    case 5:
                        usuario.TotalArmazenadoUsuarios();
                        break;
                    case 6:
                        menus.MostrarMenuManipularConta();
                        opcaoMenu = int.Parse(Console.ReadLine());

                        switch (opcaoMenu) {

                            case 0:
                                break;
                            case 1:
                                transacoes.RealizarDeposito();
                                break;
                            case 2:
                                transacoes.RealizarSaque();
                                break;
                            case 3:
                                transacoes.RealizarTranferencia();
                                break;
                        }
                        break;
                }
            } while (opcaoMenu != 0);

        }
    }
}