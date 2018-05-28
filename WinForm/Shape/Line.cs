using System;
using System.Drawing;
using WinForm.Misc;
using System.Xml.Serialization;

namespace WinForm.Shape
{
    [Serializable]
    public class Line
    {
        [XmlAttribute]
        public int StartX { get; set; }
        [XmlAttribute]
        public int StartY { get; set; }
        [XmlAttribute]
        public int EndX { get; set; }
        [XmlAttribute]
        public int EndY { get; set; }
        [XmlAttribute]
        public int R { get; set; }
        [XmlAttribute]
        public int G { get; set; }
        [XmlAttribute]
        public int B { get; set; }
        [XmlAttribute]
        public string Name { get; set; }

        public Line()
        {
        }

        public Line(string name, Point start, Point end, Color color)
        {
            Name = name;
            StartX = start.X;
            StartY = start.Y;
            EndX = end.X;
            EndY = end.Y;
            R = color.R;
            G = color.G;
            B = color.B;
        }
    }
}
