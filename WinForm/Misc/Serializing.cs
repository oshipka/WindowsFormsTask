using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WinForm.Shape;

namespace WinForm.Misc
{
    internal static class Serializing
    {
        public static void Serialize(string file, List<Line> lines)
        {
            Stream stream = new FileStream(file, FileMode.Create);
            var serializer = new XmlSerializer(typeof(List<Line>));
            serializer.Serialize(stream, lines);
            stream.Close();
        }

        public static List<Line> Deserialize(string file)
        {
            Stream stream = new FileStream(file, FileMode.Open);
            var serializer = new XmlSerializer(typeof(List<Line>));
            var result = serializer.Deserialize(stream) as List<Line>;
            stream.Close();
            return result;
        }
    }
}
