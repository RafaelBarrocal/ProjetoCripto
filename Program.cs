//OFICIAL
//Variaveis
    string Palavra;
    int Divisao, QuantidadeMatrizes, ComprimentoPalavra;
    Single Resto;

//Entrada
    Console.Write("Digite a palavra a ser criptografada:");
    Palavra = Console.ReadLine();

//Processamento
    //Criação da "Matriz" Palavra:
    ComprimentoPalavra = Palavra.Length;
    Resto = (ComprimentoPalavra % 4);
    Divisao = Convert.ToInt32(ComprimentoPalavra / 4);

    if (Resto != 0)
    {
        
        QuantidadeMatrizes = (Divisao +1);
    }
    else
    {
        QuantidadeMatrizes = Divisao;
    }

    int ComprimentoMatriz = (QuantidadeMatrizes * 4);

    char[] VetorPalavra = new char [ComprimentoMatriz];

    //////////////////////////////////
    //Conversão da Palavra em String para Matriz
    int a = 0;
    foreach (char Char in Palavra)
    {
        VetorPalavra[a] = Palavra[a];
        a++;
    }

    ///////////////////////////////////
    //Preenchimento dos espacos restantes
    if (ComprimentoPalavra < ComprimentoMatriz)
    {
        a = ComprimentoPalavra;

        do
        {
             VetorPalavra[a] = '0';
            a++;
        } while (a < ComprimentoMatriz);
    }
    
    ///////////////////////////////////
    //Conversão letras para numeros
    int[] VetorPalavraNumerico = new int [ComprimentoMatriz];
    string Alfabeto = " '1234567890-=qwertyuiop[asdfghjklç~]zxcvbnm,.;/!@#$%¨&*()_+QWERTYUIOP`{ASDFGHJKLÇ^}|ZXCVBNM<>:?áãâéẽêíĩîóõôúũûÁÃÂÉẼÊÍĨÎÓÕÔÚŨÛ";

    for (a = 0; a < ComprimentoPalavra; a++)
    {
        VetorPalavraNumerico[a] = Alfabeto.IndexOf(VetorPalavra[a]);
    }

    /////////////////////////////////
    //Criacao do VetorChaveNumerico
    int[] VetorChaveNumerico = new int [ComprimentoMatriz];
    a = 0;
    int b = 0;

    for (int c = 1; c <= QuantidadeMatrizes; c++)
    {
        int SomaDasPosicoes = (VetorPalavraNumerico[a] + VetorPalavraNumerico[(a+1)] + VetorPalavraNumerico[(a+2)] + VetorPalavraNumerico[(a+3)]);
        a = a+3;
        do
        {
            VetorChaveNumerico[b] = (VetorPalavraNumerico[b] + SomaDasPosicoes); 
            b++;
        } while(b<=a);
        a++;       
    }

    /////////////////////////////////
    //Correcao dos valores de chave que estao acima dos suportados

    for (a = 0; a < ComprimentoMatriz; a++)
    {
        while (VetorChaveNumerico[a] > Alfabeto.Length)
        {
            VetorChaveNumerico[a] = (VetorChaveNumerico[a] - Alfabeto.Length);
        }

    }

    ///////////////////////////////////////////
    //Criacao do VetorSenhaNumerico / Palavra * Chave
    int[] VetorSenhaNumerico = new int [ComprimentoMatriz];
    a = 0;
    for (b = 0; b < QuantidadeMatrizes; b++)
    {
        VetorSenhaNumerico[a] = ((VetorPalavraNumerico[a] * VetorChaveNumerico[a]) + (VetorPalavraNumerico[(a+1)] * VetorChaveNumerico[(a+2)]));
        VetorSenhaNumerico[(a+1)] = ((VetorPalavraNumerico[a] * VetorChaveNumerico[(a+1)]) + (VetorPalavraNumerico[(a+1)] * VetorChaveNumerico[(a+3)]));
        VetorSenhaNumerico[(a+2)] = ((VetorPalavraNumerico[(a+2)] * VetorChaveNumerico[a]) + (VetorPalavraNumerico[(a+3)] * VetorChaveNumerico[(a+2)]));
        VetorSenhaNumerico[(a+3)] = ((VetorPalavraNumerico[(a+2)] * VetorChaveNumerico[(a+1)]) + (VetorPalavraNumerico[(a+3)] * VetorChaveNumerico[(a+3)]));
        a = a + 4;
    }

    ////////////////////////////////////////
    //Correcao dos valores de senha que estao acima dos suportados

    for (a = 0; a < ComprimentoMatriz; a++)
    {
        while (VetorSenhaNumerico[a] > Alfabeto.Length)
        {
            VetorSenhaNumerico[a] = (VetorSenhaNumerico[a] - Alfabeto.Length);
        }

    }

    ///////////////////////////////////////////
    //Criacao dos VetorChave e VetorSenha

    char[] VetorChave = new char [ComprimentoMatriz];
    char[] VetorSenha = new char [ComprimentoMatriz];
    a = 0;

    foreach (int Numero in VetorChaveNumerico)
    {
        VetorChave[a] = Alfabeto[VetorChaveNumerico[a]];
        a++;
    }

    a = 0;
    foreach (int Numero in VetorSenhaNumerico)
    {
        VetorSenha[a] = Alfabeto[VetorSenhaNumerico[a]];
        a++;
    }
    








    /////////////////////////////////
    //teste
    int z = 0;
    foreach (int num in VetorPalavraNumerico)
    {

        Console.Write($"{VetorPalavraNumerico[z]} ");
        z++;
    }
    
    Console.WriteLine();

    z = 0;
    foreach (int num in VetorChaveNumerico)
    {

        Console.Write($"{VetorChaveNumerico[z]} ");
        z++;
    }
    Console.WriteLine($"\n {ComprimentoMatriz}");

    Console.WriteLine();

    z = 0;
    foreach (int num in VetorSenhaNumerico)
    {

        Console.Write($"{VetorSenhaNumerico[z]} ");
        z++;
    }

    Console.WriteLine();
    Console.Write("Sua Chave é: ");
    z = 0;
    foreach (char letra in VetorChave)
    {

        Console.Write($"{VetorChave[z]} ");
        z++;
    }

    Console.WriteLine();
    Console.Write("Sua Senha é: ");
    z = 0;
    foreach (char letra in VetorSenha)
    {

        Console.Write($"{VetorSenha[z]} ");
        z++;
    }

    Console.ReadKey();
    


//Saida

