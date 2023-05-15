using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripto_COMPLETO
{
    class Program
    {
        static void Main(string[] args)
        {
            /*====================
            -------VARIAVEIS------
            ====================*/

            string alfabeto = " '1234567890-=qwertyuiop[asdfghjklç~]zxcvbnm,.;/!@#$%¨&*()_+QWERTYUIOP`{ASDFGHJKLÇ^}|ZXCVBNM<>:?";
            int a, b;



            Console.WriteLine("#############################\n#=== Criptografador 3000 ===#\n#############################\n");
            Console.WriteLine("================================================\n");
            Console.WriteLine("Escolha uma das opções: \n\t>Digite 1 para criptografar uma palavra ou texto;\n\t>Digite 2 para descriptografar uma senha;");
            char opcao = char.Parse(Console.ReadLine());
            if (opcao == '1')
            {



                /*====================
                -------ENTRADA--------
                ====================*/

                Console.WriteLine("\nDigite a palavra a ser criptografada: ");
                string palavra = Console.ReadLine();

                /*====================
                ----PROCESSAMENTO-----
                ====================*/

                //criação do vetorPalavra

                int resto = palavra.Length % 4;
                int divisao = palavra.Length / 4;
                int qtMatrizes;
                if (resto != 0)
                {
                    qtMatrizes = divisao + 1;
                }
                else
                {
                    qtMatrizes = divisao;
                }
                int compMatriz = qtMatrizes * 4;
                char[] vetorPalavra = new char[compMatriz];

                //tradução de palavra para vetorPalavraNum

                int[] vetorPalavraNum = new int[compMatriz];
                for (a = 0; a < palavra.Length; a++)
                {
                    vetorPalavraNum[a] = alfabeto.IndexOf(palavra[a]);
                }

                //criação de vetorChaveNum

                Random elemChave = new Random();

                int[] vetorChaveNum = new int[compMatriz];
                for (a = 0; a < compMatriz; a += 4)
                {
                    int determinante;
                    do
                    {
                        vetorChaveNum[a] = elemChave.Next(0, alfabeto.Length);
                        vetorChaveNum[a + 1] = elemChave.Next(0, alfabeto.Length);
                        vetorChaveNum[a + 2] = elemChave.Next(0, alfabeto.Length);
                        vetorChaveNum[a + 3] = elemChave.Next(0, alfabeto.Length);
                        determinante = (vetorChaveNum[a] * vetorChaveNum[a + 3]) - (vetorChaveNum[a + 1] * vetorChaveNum[a + 2]);
                    } while (determinante != 1);
                }

                //criação de vetorSenhanum (palavra * chave)

                int[] vetorSenhanum = new int[compMatriz];
                a = 0;
                for (b = 0; b < qtMatrizes; b++)
                {
                    vetorSenhanum[a] = vetorPalavraNum[a] * vetorChaveNum[a] + vetorPalavraNum[a + 1] * vetorChaveNum[a + 2];
                    vetorSenhanum[a + 1] = vetorPalavraNum[a] * vetorChaveNum[a + 1] + vetorPalavraNum[a + 1] * vetorChaveNum[a + 3];
                    vetorSenhanum[a + 2] = vetorPalavraNum[a + 2] * vetorChaveNum[a] + vetorPalavraNum[a + 3] * vetorChaveNum[a + 2];
                    vetorSenhanum[a + 3] = vetorPalavraNum[a + 2] * vetorChaveNum[a + 1] + vetorPalavraNum[a + 3] * vetorChaveNum[a + 3];
                    a = a + 4;
                }

                //correção de vetorSenhanum

                for (a = 0; a < compMatriz; a++)
                {
                    while (vetorSenhanum[a] >= alfabeto.Length)
                    {
                        vetorSenhanum[a] = vetorSenhanum[a] - alfabeto.Length;
                    }
                }

                //criação vetorChave e vetorSenha

                char[] vetorChave = new char[compMatriz];
                char[] vetorSenha = new char[compMatriz + 1];

                for (a = 0; a < compMatriz; a++)
                {
                    vetorChave[a] = alfabeto[vetorChaveNum[a]];
                    vetorSenha[a] = alfabeto[vetorSenhanum[a]];

                    if (vetorChave[a] == ' ')
                    {
                        vetorChave[a] = '¶';
                    }

                    if (vetorSenha[a] == ' ')
                    {
                        vetorSenha[a] = '¶';
                    }
                }

                string numerais = "0123456789";
                vetorSenha[compMatriz] = numerais[compMatriz - palavra.Length];

                //conversão de vetorSenha e vetorChave em string
                string chave = $"{vetorChave[0]}";
                string senha = $"{vetorSenha[0]}";
                for (a = 1; a < compMatriz; a++)
                {
                    chave = chave + vetorChave[a];
                }

                for (a = 1; a < compMatriz + 1; a++)
                {
                    senha = senha + vetorSenha[a];
                }

                /*====================
                --------SAÍDA---------
                ====================*/


                Console.WriteLine();
                Console.WriteLine("\nSua senha é: \n" + senha);

                Console.WriteLine();
                Console.WriteLine("Sua chave é: \n" + chave);


            }
            else if (opcao == '2')
            {

                /*====================
                -------ENTRADA--------
                ====================*/

                Console.WriteLine("Digite a senha: ");
                string senha = Console.ReadLine();

                Console.WriteLine("Digite a chave: ");
                string chave = Console.ReadLine();

                /*====================
                ----PROCESSAMENTO-----
                ====================*/

                int compMatriz = chave.Length;

                //criação de vetorSenha e vetorChave

                char[] vetorSenha = new char[senha.Length];
                for (a = 0; a < senha.Length; a++)
                {
                    vetorSenha[a] = senha[a];
                    if (vetorSenha[a] == '¶')
                    {
                        vetorSenha[a] = ' ';
                    }
                }

                char[] vetorChave = new char[compMatriz];
                for (a = 0; a < compMatriz; a++)
                {
                    vetorChave[a] = chave[a];
                    if (vetorChave[a] == '¶')
                    {
                        vetorChave[a] = ' ';
                    }
                }

                //conversão char-int da senha e da chave
                int[] vetorSenhaNum = new int[compMatriz];
                for (a = 0; a < compMatriz; a++)
                {
                    vetorSenhaNum[a] = alfabeto.IndexOf(vetorSenha[a]);
                }

                int[] vetorChaveNum = new int[compMatriz];
                a = 0;
                foreach (char letra in vetorChave)
                {
                    vetorChaveNum[a] = alfabeto.IndexOf(vetorChave[a]);
                    a++;
                }

                //cálculo da chave inversa
                int[] vetorChaveInversa = new int[compMatriz];
                int determinante;
                for (a = 0; a < compMatriz; a += 4)
                {
                    determinante = (vetorChaveNum[a] * vetorChaveNum[a + 3]) - (vetorChaveNum[a + 1] * vetorChaveNum[a + 2]);
                    vetorChaveInversa[a] = vetorChaveNum[a + 3] * determinante;
                    vetorChaveInversa[a + 1] = vetorChaveNum[a + 1] * (-1) * determinante;
                    vetorChaveInversa[a + 2] = vetorChaveNum[a + 2] * (-1) * determinante;
                    vetorChaveInversa[a + 3] = vetorChaveNum[a] * determinante;
                }

                //multiplicação da senha pela chave inversa
                int[] vetorPalavraNum = new int[compMatriz];
                for (a = 0; a < compMatriz; a += 4)
                {
                    vetorPalavraNum[a] = vetorSenhaNum[a] * vetorChaveInversa[a] + vetorSenhaNum[a + 1] * vetorChaveInversa[a + 2];
                    vetorPalavraNum[a + 1] = vetorSenhaNum[a] * vetorChaveInversa[a + 1] + vetorSenhaNum[a + 1] * vetorChaveInversa[a + 3];
                    vetorPalavraNum[a + 2] = vetorSenhaNum[a + 2] * vetorChaveInversa[a] + vetorSenhaNum[a + 3] * vetorChaveInversa[a + 2];
                    vetorPalavraNum[a + 3] = vetorSenhaNum[a + 2] * vetorChaveInversa[a + 1] + vetorSenhaNum[a + 3] * vetorChaveInversa[a + 3];
                }

                //correção dos valores de vetorPalavraNum
                for (a = 0; a < compMatriz; a++)
                {
                    while (vetorPalavraNum[a] >= alfabeto.Length)
                    {
                        vetorPalavraNum[a] = vetorPalavraNum[a] - alfabeto.Length;
                    }

                    while (vetorPalavraNum[a] < 0)
                    {
                        vetorPalavraNum[a] = vetorPalavraNum[a] + alfabeto.Length;
                    }
                }

                //tradução de vetorPalavraNum
                string numerais = "0123456789";
                int compPalavra = compMatriz - numerais.IndexOf(vetorSenha[vetorSenha.Length - 1]);
                char[] vetorPalavra = new char[compPalavra];
                for (a = 0; a < compPalavra; a++)
                {
                    vetorPalavra[a] = alfabeto[vetorPalavraNum[a]];
                }

                //conversão em string
                string palavra = $"{vetorPalavra[0]}";
                for (a = 1; a < compPalavra; a++)
                {
                    palavra = palavra + vetorPalavra[a];
                }


                /*====================
                --------SAÍDA---------
                ====================*/




                Console.WriteLine("\nA palavra é: \n" + palavra);


            }





            Console.ReadKey();
        }
    }
}
