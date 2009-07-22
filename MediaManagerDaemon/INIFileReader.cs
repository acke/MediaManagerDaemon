
namespace MediaManagerDaemon
{
    class INIFileReader
    {
var data = new Dictionary<string, string>();
foreach (var row in File.ReadAllLines(PATH_TO_FILE))
  data.Add(row.Split('=')[0], row.Split('=')[1]);

Console.WriteLine(data["ServerName"]);
    }
}
