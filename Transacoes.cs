using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace ByteBank {
    class Transacoes {

        Usuario usuario = new Usuario();

        double ValorTransacao;

        public void RealizarDeposito() {

            Console.Clear();

            Console.Write("Digite o seu CPF para realizar o login: ");
            Usuario.Cpf = Console.ReadLine();

            int index = usuario.IndiceUsuario(Usuario.Cpf);

            Console.Write("Digite sua senha: ");
            Usuario.Senha = Console.ReadLine();

            if (usuario.ConferirCadastroUsuario(Usuario.Cpf) == true && usuario.ConferirSenhaUsuario(index, Usuario.Senha) == true) {

                usuario.LoginEfetuadoComSucesso();

                Console.Write("Digite o CPF do titular para efetuar o depósito: ");
                string cpf = Console.ReadLine();

                if (usuario.ConferirCadastroUsuario(cpf) == false) {

                    usuario.UsuarioNaoEncontrado();

                } else {

                    Console.Write("Qual o valar do depósito? ");
                    ValorTransacao = double.Parse(Console.ReadLine());

                    if (ValorTransacao > 0) {

                        Usuario.Saldos[usuario.IndiceUsuario(cpf)] = +ValorTransacao;

                        ComprovanteDeposito(usuario.IndiceUsuario(cpf), ValorTransacao);

                    } else {

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nValores negativos não são válidos!\n");
                        Console.ResetColor();

                    }
                }
            } else {
                usuario.UsuarioNaoEncontrado();
            }
        }

        public void ComprovanteDeposito(int index, double valorTransacao) {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nDeposito efetuado com sucesso\n");
            Console.ResetColor();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            DateTime data = DateTime.Now;

            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Comprovante\n");
            Console.WriteLine($"Transação concluída no valor de {valorTransacao:F02}\n" +
            $"Destinatário: {Usuario.Nomes[index]}\nCPF: {Usuario.Cpfs[index]}\n" +
                    $"Data e Hora: {data}");
            Console.WriteLine("-----------------------------\n");

        }

        public void RealizarTranferencia() {

            string cpfTranferencia;

            Console.Clear();
            Console.Write("Digite o seu CPF para realizar o login: ");
            Usuario.Cpf = Console.ReadLine();

            int index = usuario.IndiceUsuario(Usuario.Cpf);

            Console.Write("Digite sua senha: ");
            Usuario.Senha = Console.ReadLine();

            if (usuario.ConferirCadastroUsuario(Usuario.Cpf) == true && usuario.ConferirSenhaUsuario(index, Usuario.Senha) == true) {

                usuario.LoginEfetuadoComSucesso();

                Console.Write("Digite o Cpf da conta destinatária: ");
                cpfTranferencia = Console.ReadLine();

                int indexDestinatario = usuario.IndiceUsuario(cpfTranferencia);

                Console.Write("Digite o valor da transação: ");
                ValorTransacao = double.Parse(Console.ReadLine());

                if (ValorTransacao > 0 && Usuario.Saldos[index] >= ValorTransacao) {

                    Usuario.Saldos[index] = Usuario.Saldos[index] - ValorTransacao;
                    Usuario.Saldos[indexDestinatario] =+ ValorTransacao;

                    ComprovanteTransferencia(indexDestinatario, ValorTransacao);

                } else {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNão foi possível realizar a operação.");
                    Console.WriteLine("\nSaldo insuficiente ou valor da transação menor que zero.\n");
                    Console.ResetColor();

                }

            } else {

                usuario.UsuarioNaoEncontrado();
            }
        }

        public void ComprovanteTransferencia(int index, double valorTransacao) {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTranferência efetuada com sucesso\n");
            Console.ResetColor();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            DateTime data = DateTime.Now;

            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Comprovante\n");
            Console.WriteLine($"Transação concluída no valor de {valorTransacao:F02}\n" +
            $"Destinatário: {Usuario.Nomes[index]}\nCPF: {Usuario.Cpfs[index]}\n" +
                    $"Data e Hora: {data}");
            Console.WriteLine("-----------------------------\n");

        }

        public void RealizarSaque() {

            Console.Clear();
            Console.Write("Digite o seu CPF para realizar o login: ");
            Usuario.Cpf = Console.ReadLine();

            int index = usuario.IndiceUsuario(Usuario.Cpf);

            Console.Write("Digite sua senha: ");
            Usuario.Senha = Console.ReadLine();

            if (usuario.ConferirCadastroUsuario(Usuario.Cpf) == true && usuario.ConferirSenhaUsuario(index, Usuario.Senha) == true) {

                usuario.LoginEfetuadoComSucesso();

                Console.WriteLine("Qual valor deseja sacar? ");
                ValorTransacao = double.Parse(Console.ReadLine());

                if(ValorTransacao > 0 && ValorTransacao <= Usuario.Saldos[index]) {

                    Usuario.Saldos[index] = Usuario.Saldos[index] - ValorTransacao;

                    ComprovanteSaque(index, ValorTransacao);
                } else {

                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Saldo insuficiente ou valor inválido.");
                    Console.ResetColor();
                }

            } else {

                usuario.UsuarioNaoEncontrado();
            }
        }

        public void ComprovanteSaque(int index, double valorTransacao) {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSaque efetuado com sucesso\n");
            Console.ResetColor();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            DateTime data = DateTime.Now;

            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Comprovante\n");
            Console.WriteLine($"Saque concluído no valor de {valorTransacao:F02}\n" +
                    $"Data e Hora: {data}");
            Console.WriteLine("-----------------------------\n");

        }
    }
}
