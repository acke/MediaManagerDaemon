//Outch.. got some code pasted in this file. WHATAMESS....


namespace MediaManagerDaemon
{
    class INIFileReader
    {
var data = new INIFileReader<string, string>();
foreach (var row in File.ReadAllLines(PATH_TO_FILE))
  data.Add(row.Split('=')[0], row.Split('=')[1]);

Console.WriteLine(data["ServerName"]);
    }
}

INIFileReader<string,string> Properties = GetProperties("data.txt");
Console.WriteLine("Hello: " + Properties["Hello"]);
Console.ReadKey();

public static INIFileReader<string, string> GetProperties(string path)
{
    string fileData = "";
    using (StreamReader sr = new StreamReader(path))
    {
        fileData = sr.ReadToEnd().Replace("\r", "");
    }
    INIFileReader<string, string> Properties = new INIFileReader<string, string>();
    string[] kvp;
    string[] records = fileData.Split("\n".ToCharArray());
    foreach (string record in records)
    {
        kvp = record.Split("=".ToCharArray());
        Properties.Add(kvp[0], kvp[1]);
    }
    return Properties;
}

public static IINIFileReader ParseINIFileReader(string fileName)
{
    INIFileReader<string, string> iniFileProperties = new INIFileReader<string, string>();
    foreach (string line in File.ReadAllLines(fileName))
    {
        if ((!string.IsNullOrEmpty(line)) &&
            (!line.StartsWith(";")) &&
            (!line.StartsWith("#")) &&
            (!line.StartsWith("'")) &&
            (line.Contains('=')))
        {
            int index = line.IndexOf('=');
            string key = line.Substring(0, index).Trim();
            string value = line.Substring(index + 1).Trim();

            if ((value.StartsWith("\"") && value.EndsWith("\"")) ||
                (value.StartsWith("'") && value.EndsWith("'")))
            {
                value = value.Substring(1, value.Length - 2);
            }
            iniFileProperties.Add(key, value);
        }
    }

    return iniFileProperties;
}
