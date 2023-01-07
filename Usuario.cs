using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace ByteBank {
    class Usuario {

        public static List<string> Nomes = new List<string>();
        public static List<string> Cpfs = new List<string>();
        public static List<string> Senhas = new List<string>();
        public static List<double> Saldos = new List<double>();

        public static string Cpf;
        public static string Senha;
        public static string Login;

        public int IndiceUsuario(string Cpf) {
            return Cpfs.IndexOf(Cpf);
        }

        public bool ConferirCadastroUsuario(string Cpf) {
            return Cpfs.Contains(Cpf);
        }

        public bool ConferirSenhaUsuario(int index, string senha) {
            if (Senhas[index] == senha) {
                return true;
            } else {
                return false;
            }
        }

        public void UsuarioCadastrado() {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUsuário já cadastrado!\n");
            Console.ResetColor();

        }

        public void UsuarioCadastradoComSucesso() {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nUsuário cadastrado com sucesso!\n");
            Console.ResetColor();
        }

        public void UsuarioNaoEncontrado() {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nUsuário não encontrado!\n");
            Console.ResetColor();
        }

        public void CadastrarUsuario() {

            Console.Clear();

            Console.Write("Digite o CPF: ");
            Cpf = Console.ReadLine();

            if (ConferirCadastroUsuario(Cpf) == false) {

                Cpfs.Add(Cpf);

                Console.Write("Digite o nome completo: ");
                Nomes.Add(Console.ReadLine());

                Console.Write("Insira a senha: ");
                Senhas.Add(Console.ReadLine());

                Saldos.Add(0.00);

                UsuarioCadastradoComSucesso();

            } else {
                UsuarioCadastrado();
            }
        }

        public void ExcluirUsuario() {

            Console.Clear();

            Console.Write("Digite o CPF: ");
            Cpf = Console.ReadLine();

            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            int index = Cpfs.IndexOf(Cpf);

            if (ConferirCadastroUsuario(Cpf) == true && ConferirSenhaUsuario(index, senha) == true) {

                Nomes.RemoveAt(index);
                Cpfs.RemoveAt(index);
                Senhas.RemoveAt(index);
                Saldos.RemoveAt(index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nUsuário removido com sucesso.\n");
                Console.ResetColor();

            } else {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUsuário não encontrado ou senha inválida!\n");
                Console.ResetColor();
            }
        }

        public void MostrarTodosUsuários() {

            for (int i = 0; i < Cpfs.Count(); i++) {
                Console.WriteLine($"{i + 1} - {Nomes[i]} | CPF: {Cpfs[i]}");
            }
            Console.WriteLine("");

        }

        public void MostrarDetalhesUsuario() {

            Console.Clear();

            Console.Write("Digite o CPF do usuário: ");
            Cpf = Console.ReadLine();

            if (ConferirCadastroUsuario(Cpf) == true) {

                int index = Cpfs.IndexOf(Cpf);
                Console.WriteLine($"\nID = {index + 1} | CPF = {Cpfs[index]} | Titular " +
                    $"= {Nomes[index]} | Saldo = R$ {Saldos[index]:F02}\n");
            } else {

                UsuarioNaoEncontrado();
            }
        }

        public void TotalArmazenadoUsuarios() {

            Console.Clear();

            double totalSaldos = 0.0;

            for (int i = 0; i < Saldos.Count(); i++) {
                totalSaldos =+ Saldos[i];
            }

            Console.WriteLine($"\nTotal armazenado é: {totalSaldos:F02}\n");
        }

        public void LoginEfetuadoComSucesso() {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nLogin efetuado com sucesso.\n");
            Console.ResetColor();

        }
    }
}
