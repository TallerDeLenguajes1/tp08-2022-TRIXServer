System.Console.WriteLine($"--\tDirectorio");
System.Console.WriteLine("--");
int flagFolder = 0;
string path;

do
{
    if (flagFolder > 0)
    {
        System.Console.WriteLine("El directorio ingresado no existe, reintente");

    }

    System.Console.Write("Ingrese el directorio: ");
    path = Console.ReadLine();
    System.Console.WriteLine("--");
    flagFolder++;

}
while (!Directory.Exists(path));

if (Directory.GetFiles(path).Length > 0)
{
    List<string> archivos = Directory.GetFiles(path).ToList();
    var archivoWrite = new StreamWriter(File.Open("index.csv", FileMode.Create));

    int numeroRegistro = 1;

    foreach (var item in archivos)
    {
        string nombreArchivo = Path.GetFileNameWithoutExtension(item);
        string extensionArchivo = Path.GetExtension(item);
        string registro = $"{numeroRegistro},{nombreArchivo},{extensionArchivo}";
        archivoWrite.WriteLine(registro);
        numeroRegistro++;

    }

    System.Console.WriteLine("Registros de archivos guardado");
    System.Console.WriteLine("--");

    archivoWrite.Close();

    var archivoRead = new StreamReader(File.Open("index.csv", FileMode.Open));

    System.Console.WriteLine(archivoRead.ReadToEnd());

    archivoRead.Close();

}