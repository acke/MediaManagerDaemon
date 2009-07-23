//Outch.. got some code pasted in this file. WHATAMESS....

using System.IO;
using System;

namespace MediaManagerDaemon
{
    class INIFileReader
    {
             
        //public static Dictionary<string, string> GetProperties(string path)
        //{
        //    string fileData = "";
        //    using (StreamReader sr = new StreamReader(path))
        //    {
        //        fileData = sr.ReadToEnd().Replace("\r", "");
        //    }
        //    Dictionary<string, string> Properties = new Dictionary<string, string>();
        //    string[] kvp;
        //    string[] records = fileData.Split("\n".ToCharArray());
        //    foreach (string record in records)
        //    {
        //        kvp = record.Split("=".ToCharArray());
        //        Properties.Add(kvp[0], kvp[1]);
        //    }
        //    return Properties;
        //}

//Here's an example of how to use it:

Dictionary<string,string> Properties = ReadPropertiesFile("setup.ini");
//Console.WriteLine("Hello: " + Properties["Hello"]);
//Console.ReadKey();

public static IDictionary ReadDictionaryFile(string fileName)
{
    Dictionary<string, string> dictionary = new Dictionary<string, string>();
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
            dictionary.Add(key, value);
        }
    }

    return dictionary;
}


   }
}