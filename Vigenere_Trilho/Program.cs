using Enygma.ClassEncrypt;

// Declaração das Classes

Caesar caesar = new Caesar();

Vigenere vigenere = new Vigenere();

Trilho trilho = new Trilho();

Trilho_2 trilho_2 = new Trilho_2();

// Declaração das variaveis

#region Variables

string Key, InMessage, OutMessage, Acumudador;

int select, Displacement;

int[] senha = new int[7];

#endregion

// Menu de exibição

#region Menu

Console.WriteLine("Escolha o método a ser utilizado\n");

Thread.Sleep(800);

Console.WriteLine("1 - Cifra Caesar\n");

Thread.Sleep(800);

Console.WriteLine("2 - Cifra Vinagere\n");

Thread.Sleep(800);

Console.WriteLine("3 - Cerca de trilho\n");

Thread.Sleep(800);

Console.WriteLine("4 - Nova Cerca de trilho\n");

Thread.Sleep(800);

Console.Write("Input: ");

select = int.Parse(Console.ReadLine());

// Seletor de evento, de acordo à escolha do usuario

switch (select)
{
    // Cifra Caesar
    case 1:

        EncryptCifraCaesar();

        DecryptCaesar();

        break;

    // Cifra Vinagrete 

    case 2:

        EncryptCifraVigenere();

        DecryptVigenere();

        break;

    // Cerca de trilho

    case 3:

        EncryptCifraTrilho();

        DecryptCifraTrilho();

        break;

    // Nova Cerca de trilho

    case 4:

        NewEncryptCifraTrilho();

        NewDecryptCifraTrilho();

        break;

    // Caso seja outra escolha, não condizente com o especificado

    default:
        break;
}

#endregion

// Declaração das entradas e saídas no programa

#region E/S

string EntradaTexto()
{
    Thread.Sleep(800);

    Console.Write("Digite a frase : ");

    InMessage = Console.ReadLine();

    InMessage = InMessage.ToLower();

    InMessage = InMessage.Replace(",", "");

    InMessage = InMessage.Replace(".", "");

    InMessage = InMessage.Replace(" ", "");

    return InMessage;
}

string EntradaSenha()
{
    Thread.Sleep(800);

    Console.Write("\nDigite a senha: ");

    Key = Console.ReadLine();

    return InMessage;
}

int EntradaDeslocamento()
{
    Thread.Sleep(800);

    Console.Write("\nDigite o deslocamento: ");

    Displacement = int.Parse(Console.ReadLine());

    return Displacement;
}

void SaidaCriptografada(string texto)
{
    Acumudador = texto;

    Thread.Sleep(800);

    Console.WriteLine($"\nA frase criptografada seria: {texto.ToUpper()}\n");

    Thread.Sleep(800);
}

void SaidaDescriptografada(string texto)
{
    Thread.Sleep(800);

    Console.WriteLine($"\nA frase descriptografada seria: {texto.ToUpper()}\n");

    Thread.Sleep(800);
}

#endregion

// Declaração das funções Criptografadoras

#region Encrypt

void EncryptCifraCaesar()
{
    Console.WriteLine("\nCriptografação via Caesar\n");

    InMessage = EntradaTexto();

    Displacement = EntradaDeslocamento();

    OutMessage = caesar.CriptografarEmCaesar(InMessage, Displacement);

    Thread.Sleep(800);

    SaidaCriptografada(OutMessage);
}

void EncryptCifraVigenere()
{
    Console.WriteLine("\nCriptografação via Vinegere\n");

    InMessage = EntradaTexto();

    Key = EntradaSenha();

    Thread.Sleep(800);

    SaidaCriptografada(vigenere.CriptografarEmVigenere(InMessage, Key));
}

void EncryptCifraTrilho()
{
    Console.WriteLine("\nCriptografação via Trilho\n");

    InMessage = EntradaTexto();

    Displacement = EntradaDeslocamento();

    Thread.Sleep(800);

    SaidaCriptografada(trilho.CriptografarEmTrilho(InMessage, Displacement));
}

void NewEncryptCifraTrilho()
{
    Console.WriteLine("\nCriptografação via Transposição\n");

    InMessage = EntradaTexto();

    Thread.Sleep(800);

    senha = trilho_2.GerarSenha();

    Console.WriteLine($"\n{string.Join(", ", senha)}");

    Thread.Sleep(800);

    SaidaCriptografada(trilho_2.CriptografarEmTrilho(InMessage, senha));
}

#endregion

// Declaração das funções Criptografadoras

#region Decrypt

void DecryptCaesar()
{
    Console.WriteLine("\nDescriptografação via Caesar\n");

    Displacement = EntradaDeslocamento();

    Thread.Sleep(800);

    SaidaDescriptografada(caesar.DescriptografarEmCaesar(Acumudador, Displacement));
}

void DecryptVigenere()
{
    Console.WriteLine("\nDescriptografação via Vinegere\n");

    Key = EntradaSenha();

    Thread.Sleep(800);

    SaidaDescriptografada(vigenere.DescriptografarEmVigenere(Acumudador, Key));
}

void DecryptCifraTrilho()
{
    Console.WriteLine("\nDescriptografação via Trilho\n");

    Displacement = EntradaDeslocamento();

    Thread.Sleep(800);

    SaidaDescriptografada(trilho.DesriptografarEmTrilho(Acumudador, Displacement));

}

void NewDecryptCifraTrilho()
{
    Console.WriteLine("\nDescriptografação via Transposição\n");

    Thread.Sleep(800);

    SaidaDescriptografada(trilho_2.DescriptografarEmTrilho(Acumudador, senha));
}

#endregion