using System.Text.Json;
using System.Xml.Serialization;
namespace _10._1Ser_DeSer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jsonpath = @"D:\MSSA\20483\Wk10\10-1json.txt";
            string xmlpath = @"D:\MSSA\20483\Wk10\10-1xml.xml";

            Phone p1 = new Phone("apple", "12 pro", 899.99f);
            Phone p2 = new Phone("samsung", "galaxy s19", 799.99f);

            JSONSerialize(p1, jsonpath);
            JSONDeSerialize(jsonpath);

            Console.WriteLine();
            XMLSerialize(p2, xmlpath);
            XMLDeSerialize(xmlpath);
        }

        static void JSONSerialize(Phone phone, string jsonpath)
        {
            if (File.Exists(jsonpath))
            {

                File.Delete(jsonpath);
            }
            FileStream fs = new FileStream(jsonpath, FileMode.CreateNew, FileAccess.Write);
            Console.WriteLine("Serializing to JSON...");
            JsonSerializer.Serialize(fs, phone);
            fs.Close();

            string jsonText = File.ReadAllText(jsonpath);
            Console.WriteLine(jsonText);
        }

        static void JSONDeSerialize(string jsonpath)
        {
            FileStream fs = new FileStream(jsonpath, FileMode.Open, FileAccess.Read);
            var obj = JsonSerializer.Deserialize<Phone>(fs);
            fs.Close();
            Console.WriteLine($"Deserialized json: {obj.Brand}, {obj.Model}, {obj.Price} ");
        }

        static void XMLSerialize(Phone phone, string xmlpath)
        {
            if (File.Exists(xmlpath))
            {
                File.Delete(xmlpath);
            }
            FileStream fs = new FileStream(xmlpath, FileMode.CreateNew, FileAccess.Write);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Phone));
            Console.WriteLine("Serializing to XML...");
            xmlSerializer.Serialize(fs, phone);
            fs.Close();

            string xmlText = File.ReadAllText(xmlpath);
            Console.WriteLine(xmlText);
        }

        static void XMLDeSerialize(string xmlpath)
        {
            FileStream fs = new FileStream(xmlpath, FileMode.Open, FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer (typeof(Phone));
            var obj = (Phone)xmlSerializer.Deserialize(fs);
            fs.Close();
            Console.WriteLine($"Deserialized XML: {obj.Brand}, {obj.Model}, {obj.Price}" );
        }
    }
}
