using Enygma.ClassEncrypt;

Caesar caesar = new Caesar();
Vigenere vigenere = new Vigenere();
Trilho trilho = new Trilho();
Trilho_2 trilho_2 = new Trilho_2();

#region Variables

string Key, InMessage, OutMessage;
int select, Displacement;

#endregion

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

switch (select)
{
    case 1:
        EncryptCifraCaesar();
        DecryptCaesar();
        break;
    case 2:
        EncryptCifraVigenere();
        DecryptVigenere();
        break;
    case 3:
        EncryptCifraTrilho();
        DecryptCifraTrilho();
        break;
    case 4:
        NewEncryptCifraTrilho();
        NewDecryptCifraTrilho();
        break;
    default:
        break;
}

#endregion

#region E/S

string EntradaTexto()
{
    Thread.Sleep(800);
    Console.WriteLine("Digite a frase a ser convertida\n");
    Thread.Sleep(800);
    Console.Write("Input: ");
    InMessage = Console.ReadLine();

    return InMessage;
}

void SaidaTexto(string texto)
{
    Thread.Sleep(800);
    Console.WriteLine($"\nA frase convertida seria: {texto.ToUpper()}\n");
    Thread.Sleep(800);
}

#endregion

#region Encrypt

void EncryptCifraCaesar()
{
    Console.WriteLine("\nCriptografação via Caesar\n");
    Console.WriteLine("\nDigite o deslocamento a ser utilizado\n");
    Thread.Sleep(800);
    Console.Write("Input: ");
    Displacement = int.Parse(Console.ReadLine());

    OutMessage = caesar.CriptografarCesar(EntradaTexto(), Displacement);
    SaidaTexto(OutMessage);
}

void EncryptCifraVigenere()
{
    Console.WriteLine("\nCriptografação via Vinegere\n");
    Console.WriteLine("\nDigite a senha a ser utilizada\n");
    Thread.Sleep(800);
    Console.Write("Input: ");
    Key = Console.ReadLine();

    OutMessage = vigenere.CriptografarVigenere(EntradaTexto(), Key);
    SaidaTexto(OutMessage);
}

void EncryptCifraTrilho()
{
    Console.WriteLine("\nCriptografação via Trilho\n");
    Console.WriteLine("\nDigite a altura do trilho a ser utilizada\n");
    Thread.Sleep(800);
    Console.Write("Input: ");
    Displacement = int.Parse(Console.ReadLine());

    OutMessage = trilho.CriptografarTrilho(EntradaTexto(), Displacement);
    SaidaTexto(OutMessage);
}

void NewEncryptCifraTrilho()
{
    Console.WriteLine("\nCriptografação via Transposição\n");

    OutMessage = trilho_2.EncryptRailFence(EntradaTexto());
    SaidaTexto(OutMessage);
}

#endregion

#region Decrypt

void DecryptCaesar()
{
    Thread.Sleep(800);
    SaidaTexto(caesar.DecryptCaesar(OutMessage, Displacement));
}

void DecryptVigenere()
{
    Thread.Sleep(800);
    SaidaTexto(vigenere.DecryptVigenere(OutMessage, Key));
}

void DecryptCifraTrilho()
{
    Thread.Sleep(800);
    // SaidaTexto(trilho.DesriptografarTrilho(OutMessage, Displacement));
    OutMessage = trilho.DesriptografarTrilho(OutMessage, Displacement);
    SaidaTexto(OutMessage);

}

void NewDecryptCifraTrilho()
{
    Console.WriteLine("\nDescriptografação via Transposição\n");

    OutMessage = trilho_2.DecryptRailFence(EntradaTexto());
    SaidaTexto(OutMessage);
}

#endregion