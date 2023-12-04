using System;
using System.IO;

class Program {
  public static void Main (string[] args) {
    //verifica se o argumento -f ou --file foi fornecido
    bool createFile = Array.Exists(args, arg => arg.Equals("-f") || arg.Equals("--file"));

    //obtém as especificações do PC
    OperatingSystem os = Environment.OSVersion;
    string systemVersion = $"{os.Platform} {os.Version}";
    string clrVersion = Environment.Version.ToString();
    bool is64Bit = Environment.Is64BitOperatingSystem;

    //exibe as especificações no console
    Console.WriteLine("PC Specifications");
    Console.WriteLine($"- System Version: {systemVersion}");
    Console.WriteLine($"- CLR Version: {clrVersion}");
    Console.WriteLine($"- 64-bit System: {is64Bit}");

    //cria um arquivo de texto se o argumento -f ou --file foi fornecido
    if (createFile)
    {
      string filePath = "PCSpecs.text";

      try
      {
        //grava as especificações no arquivo
        using (StreamWriter writer = new StreamWriter (filePath)) 
        {
          writer.WriteLine("PC Specifications: ");
          writer.WriteLine($"- System Version: {systemVersion}");
          writer.WriteLine($"- CLR Version: {clrVersion}");
          writer.WriteLine($"- 64-bit System: {is64Bit}");
        }
        Console.WriteLine($"As especificações foram salvas no arquivo: {filePath}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ocorreu um erro ao criar o arquivo: {ex.Message}");
      }
    }
  }
}