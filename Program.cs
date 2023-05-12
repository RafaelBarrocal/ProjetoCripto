/*################################
============OFICIAL===============
################################*/



/*====================
-------VARIAVEIS------
====================*/


    string palavra;
    int divisao, quantidadeMatrizes, comprimentoPalavra;
    int a,b;
    Single resto;


/*====================
-------ENTRADA--------
====================*/



    Console.Write("Digite a palavra a ser criptografada:");
    palavra = Console.ReadLine();


/*====================
----PROCESSAMENTO-----
====================*/


    //Criação da "Matriz" palavra:


    comprimentoPalavra = palavra.Length;
    resto = (comprimentoPalavra % 4);
    divisao = Convert.ToInt32(comprimentoPalavra / 4);

    if (resto != 0)
    {
        
        quantidadeMatrizes = (divisao +1);
    }
    else
    {
        quantidadeMatrizes = divisao;
    }

    int comprimentoMatriz = (quantidadeMatrizes * 4);

    char[] vetorPalavra = new char [comprimentoMatriz];


    //Conversão da palavra em String para Matriz


    a = 0;
    foreach (char Char in palavra)
    {
        vetorPalavra[a] = palavra[a];
        a++;
    }

    
    //Preenchimento dos espacos restantes


        a = comprimentoPalavra;
        int acrescimo = 0;

        while (a < comprimentoMatriz)
        {
             vetorPalavra[a] = '0';
            a++;
            acrescimo++;
        }
    
    
    //Conversão letras para numeros


    int[] vetorPalavraNumerico = new int [comprimentoMatriz];
    string alfabeto = " '1234567890-=qwertyuiop[asdfghjklç~]zxcvbnm,.;/!@#$%¨&*()_+QWERTYUIOP`{ASDFGHJKLÇ^}|ZXCVBNM<>:?áãâéẽêíĩîóõôúũûÁÃÂÉẼÊÍĨÎÓÕÔÚŨÛ";

    for (a = 0; a < comprimentoPalavra; a++)
    {
        vetorPalavraNumerico[a] = alfabeto.IndexOf(vetorPalavra[a]);
    }

    
    //Criação do vetorChaveNumerico

            int[] vetorChaveNumerico = new int[comprimentoMatriz];
            Random aleatorio = new Random();
            int determinante;
            b = (alfabeto.Length);

            for(a = 0; a < comprimentoMatriz; a += 4)
            {
                do
                {
                    vetorChaveNumerico[a] = aleatorio.Next(b);
                    vetorChaveNumerico[a + 1] = aleatorio.Next(b);
                    vetorChaveNumerico[a + 2] = aleatorio.Next(b);
                    vetorChaveNumerico[a + 3] = aleatorio.Next(b);
                    determinante = (vetorChaveNumerico[a] * vetorChaveNumerico[a + 3]) - (vetorChaveNumerico[a + 1] * vetorChaveNumerico[a + 2]);
                    Console.WriteLine(vetorChaveNumerico[a]);       
                } while (determinante != 1 || determinante != -1);
            }
    
    //Criacao do vetorSenhaNumerico / palavra * Chave


    int[] vetorSenhaNumerico = new int [comprimentoMatriz];
    a = 0;
    for (b = 0; b < quantidadeMatrizes; b++)
    {
        vetorSenhaNumerico[a] = ((vetorPalavraNumerico[a] * vetorChaveNumerico[a]) + (vetorPalavraNumerico[(a+1)] * vetorChaveNumerico[(a+2)]));
        vetorSenhaNumerico[(a+1)] = ((vetorPalavraNumerico[a] * vetorChaveNumerico[(a+1)]) + (vetorPalavraNumerico[(a+1)] * vetorChaveNumerico[(a+3)]));
        vetorSenhaNumerico[(a+2)] = ((vetorPalavraNumerico[(a+2)] * vetorChaveNumerico[a]) + (vetorPalavraNumerico[(a+3)] * vetorChaveNumerico[(a+2)]));
        vetorSenhaNumerico[(a+3)] = ((vetorPalavraNumerico[(a+2)] * vetorChaveNumerico[(a+1)]) + (vetorPalavraNumerico[(a+3)] * vetorChaveNumerico[(a+3)]));
        a = a + 4;
    }

    
    //Correcao dos valores de senha que estao acima dos suportados


    for (a = 0; a < comprimentoMatriz; a++)
    {
        while (vetorSenhaNumerico[a] >= alfabeto.Length)
        {
            vetorSenhaNumerico[a] = (vetorSenhaNumerico[a] - alfabeto.Length);
        }

    }

    
    //Criacao dos vetorChave e vetorSenha


    char[] vetorChave = new char [comprimentoMatriz];
    char[] vetorSenha = new char [(comprimentoMatriz + 1)];

    for (a = 0; a < comprimentoMatriz; ++a)
    {
        vetorChave[a] = alfabeto[vetorChaveNumerico[a]];

        vetorSenha[a] = alfabeto[vetorSenhaNumerico[a]];
    }
    
    vetorSenha[comprimentoMatriz] = Convert.ToChar(acrescimo);


    //Substituição de ' ' por '¶'

    a = 0;
    foreach (char elementoChar in vetorChave)
    {
        if (Convert.ToBoolean(vetorSenha[a] = ' '))
        {
            vetorSenha[a] = '¶';
        }

        if (Convert.ToBoolean(vetorChave[a] = ' '))
        {
            vetorChave[a] = '¶';
        }
        a++;
    }



/*====================
--------TESTES--------
====================*/


    int z = 0;
    foreach (int num in vetorPalavraNumerico)
    {

        Console.Write($"{vetorPalavraNumerico[z]} ");
        z++;
    }
    
    Console.WriteLine();

    z = 0;
    foreach (int num in vetorChaveNumerico)
    {

        Console.Write($"{vetorChaveNumerico[z]} ");
        z++;
    }
    Console.WriteLine($"\n {comprimentoMatriz}");

    Console.WriteLine();

    z = 0;
    foreach (int num in vetorSenhaNumerico)
    {

        Console.Write($"{vetorSenhaNumerico[z]} ");
        z++;
    }

    Console.WriteLine();
    Console.Write("Sua Chave é: ");
    z = 0;
    foreach (char letra in vetorChave)
    {

        Console.Write($"{vetorChave[z]} ");
        z++;
    }

    Console.WriteLine();
    Console.Write("Sua Senha é: ");
    z = 0;
    foreach (char letra in vetorSenha)
    {

        Console.Write($"{vetorSenha[z]} ");
        z++;
    }

    Console.ReadKey();