using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinForm.Misc
{
    /*internal*/public static class MiscFunctions
    {
        public static void DrawLine(Point start, Point end, Graphics graphics)
        {
            if (start.X >= end.X)
            {
                SwapPoints(ref start, ref end);
            }
            graphics.DrawLine(new Pen(Color.Black, 1), start.X, start.Y, end.X, end.Y);
        }

        public static bool GetColorFromColorDialog(out Color color, ColorDialog colorDialog)
        {
            var dialogResult = colorDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                color = colorDialog.Color;
                return true;
            }
            color = Color.White;
            return false;
        }

        public static void DrawLinesList(List<Shape.Line> list, Graphics graphics)
        {
            list.ForEach(line => graphics
                .DrawLine(new Pen(Color.FromArgb(line.R, line.G, line.B)),
                line.StartX,
                line.StartY,
                line.EndX, 
                line.EndY
                )
            );
        }

        public static bool PointsAreDifferent(Point firstPoint, Point secondPoint)
        {
            return firstPoint.X != secondPoint.X && firstPoint.Y != secondPoint.Y;
        }

        public static DialogResult SavingPictureMessageBox()
        {
            return MessageBox.Show(
                @"Save current picture?",
                @"Saving picture",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
        }

        public static void SwapPoints(ref Point first, ref Point second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        public static Shape.Line MoveLine(Shape.Line line, Point location)
        {
            line.StartX = line.StartX - location.X;
            line.StartY = line.StartY - location.Y;
            return line;
        }

        public static Shape.Line GetLineByClick(Point clickPosition, List<Shape.Line> lines)
        {
            for (var i = lines.Count - 1; i >= 0; i--)
            {
                if (PointIsBetween(clickPosition, lines[i]))
                {
                    return lines[i];
                }
            }

            return null;
        }

        public static bool PointIsBetween (Point point, Shape.Line line)
        {
            var crossproduct = (point.Y - line.StartY) * (line.EndX - line.StartX) - (point.X - line.StartX) * (line.EndY - line.StartY);
            if (Math.Abs(crossproduct) > 0.000000001)
            {
                return false;
            }

            var dotproduct = (point.X - line.StartX) * (line.EndX - line.StartX) + (point.Y - line.StartY) * (line.EndY - line.StartY);
            if (dotproduct < 0)

            {
                return false;
            }

            var squaredlengthba = (line.EndX - line.StartX) * (line.EndX - line.StartX) + (line.EndY - line.StartY) * (line.EndY - line.StartY);
            if (dotproduct > squaredlengthba)
            {
                return false;
            }
            
            return true;
        }

        public static void LogMoving(Shape.Line line, StatusBarPanel statusBP)
        {
            statusBP.Text = ($"\"{line.Name}\" got a new position: start ({line.StartX}, {line.StartY}), end ({line.EndX}, {line.EndY})");
        }
    }
}
