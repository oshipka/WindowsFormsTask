using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WinForm.Misc;

namespace WinForm
{
    public partial class DrawALine : Form
    {
        public DrawALine()
        {
            InitializeComponent();
        }

        private void DrawMouseClick(object sender, MouseEventArgs e)
        {
            if (_paintingToolIsActive)
            {
                var newPoint = new Point(e.X, e.Y);
                if (_points.Count == 1)
                {
                    if (MiscFunctions.PointsAreDifferent(_points[0], newPoint))
                    {
                        _points.Add(newPoint);
                        drawPan.Panel1.Invalidate();
                        _isSaved = false;
                    }
                }
                else
                {
                    _points.Add(newPoint);
                    drawPan.Panel1.Invalidate();
                }
            }
        }

        private void Draw(object sender, PaintEventArgs e)
        {
            MiscFunctions.DrawLinesList(_lines, e.Graphics);
            if (_points.Count == 1)
            {
                _isDrawing = true;
                MiscFunctions.DrawLine(_points[0], _mousePosition, drawPan.Panel1.CreateGraphics());
            }
            else if (_points.Count == 2)
            {
                _isDrawing = false;
                MiscFunctions.DrawLine(_points[0], _points[1], e.Graphics);
                if (MiscFunctions.GetColorFromColorDialog(out var color, colorDialog))
                {
                    e.Graphics.Clear(SystemColors.Control);
                    MiscFunctions.DrawLinesList(_lines, e.Graphics);
                    SetLine(color, e.Graphics);
                }
                else
                {
                    e.Graphics.Clear(SystemColors.Control);
                    MiscFunctions.DrawLinesList(_lines, e.Graphics);
                }
                _points.Clear();
            }
        }

        private void ClickOpen(object objSrc, EventArgs args)
        {
            if (!_isSaved)
            {
                if (MiscFunctions.SavingPictureMessageBox() == DialogResult.Yes)
                {
                    ClickSave(objSrc, args);
                }
            }
            var ofd = new OpenFileDialog
            {
                Filter = @"Xml files (*.xml)|*.xml|All files (*.*)|*.*",
                DefaultExt = "xml",
                AddExtension = true
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                drawPan.Panel1.Refresh();
                drawPan.Panel1.Invalidate();
                _lines.Clear();
                try
                {
                    _lines = Serializing.Deserialize(ofd.FileName);
                    MiscFunctions.DrawLinesList(_lines, drawPan.Panel1.CreateGraphics());
                    shapesToolStripMenuItem.DropDownItems.Clear();
                    foreach (var line in _lines)
                    {
                        var lineItem = new ToolStripMenuItem
                        {
                            Size = new Size(129, 26),
                            Text = line.Name,
                        };
                        lineItem.Click += ShapesMenuItemClick;
                        shapesToolStripMenuItem.DropDownItems.Add(lineItem);
                        listBox.Items.Add($"Added new line ({line.Name}), color: {Color.FromArgb(line.R, line.G, line.B).Name}");
                    }
                    SwitchMovingObject(_lines.Count > 0 ? _lines.Count : 0);
                }
                catch (InvalidOperationException exc)
                {
                    MessageBox.Show(
                        $@"File '{ofd.FileName}' is invalid\n\nException: {exc.Message}",
                        @"Invalid file was loaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            _isSaved = true;
        }

        private void ClickSave(object objSrc, EventArgs args)
        {
            var sfd = new SaveFileDialog
            {
                Filter = @"Xml files (*.xml)|*.xml|All files (*.*)|*.*",
                DefaultExt = "xml",
                FileName = "Lines",
                AddExtension = true
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Serializing.Serialize(sfd.FileName, _lines);
                _isSaved = true;
            }
        }

        private void ClickCreateNew(object objSrc, EventArgs args)
        {
            if (!_isSaved)
            {
                if (MiscFunctions.SavingPictureMessageBox() == DialogResult.Yes)
                {
                    ClickSave(objSrc, args);
                }
            }
            drawPan.Panel1.Refresh();
            drawPan.Panel1.Invalidate();
            _lines.Clear();
            _objToMove = 0;
            shapesToolStripMenuItem.DropDownItems.Clear();
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (_isDrawing)
            {
                _mousePosition = new Point(e.X, e.Y);
                drawPan.Panel1.Refresh();
            }
            if (_isMouseDown && _lines.Count > 0)
            {
                MiscFunctions.MoveLine(
                    _lines[_objToMove - 1],
                    new Point(_mousePosOnMouseDown.X - e.X, _mousePosOnMouseDown.Y - e.Y)
                );
                drawPan.Panel1.Refresh();
                _mousePosOnMouseDown = e.Location;
                status.Text = $@"{e.X}, {e.Y}px";
            }
        }

        private void OnClosingHandler(object sender, FormClosingEventArgs e)
        {
            if (!_isSaved)
            {
                if (MiscFunctions.SavingPictureMessageBox() == DialogResult.Yes)
                {
                    ClickSave(sender, e);
                }
            }
        }

        private void ObjectMovingHandler(object sender, KeyEventArgs e)
        {
            if (_objToMove > 0 && _lines.Count > 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                    case Keys.D:
                        _lines[_objToMove - 1].StartX += 5;
                        _lines[_objToMove - 1].EndX += 5;
                        break;
                    case Keys.Left:
                    case Keys.A:
                        _lines[_objToMove - 1].StartX -= 5;
                        _lines[_objToMove - 1].EndX -= 5;
                        break;
                    case Keys.Up:
                    case Keys.W:
                        _lines[_objToMove - 1].StartY -= 5;
                        _lines[_objToMove - 1].EndY -= 5;
                        break;
                    case Keys.Down:
                    case Keys.S:
                        _lines[_objToMove - 1].StartY += 5;
                        _lines[_objToMove - 1].EndY += 5;
                        break;
                    default:
                        Console.WriteLine(@"Invalid button was pressed");
                        break;
                }

                drawPan.Panel1.Refresh();
            }
        }

        private void ShapesMenuItemClick(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item)
            {
                SwitchMovingObject(shapesToolStripMenuItem.DropDownItems.IndexOf(item) + 1);
            }
        }

        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !_paintingToolIsActive)
            {
                _mousePosOnMouseDown.X = e.X;
                _mousePosOnMouseDown.Y = e.Y;
                var curLine = MiscFunctions.GetLineByClick(_mousePosOnMouseDown, _lines);
                if (curLine != null)
                {
                    SwitchMovingObject(_lines.IndexOf(curLine) + 1);
                    _isMouseDown = true;
                }
            }
        }

        private void MouseUpHandler(object sender, MouseEventArgs e)
        {
            _isMouseDown = false;
            if (_lines?.Count > 0 && !_paintingToolIsActive)
            {
                MiscFunctions.LogMoving(_lines[_objToMove - 1], listBox);
            }
        }

        private void DrawingToolHandler(object sender, EventArgs e)
        {
            _paintingToolIsActive = true;
            SwitchTools(true);
        }

        private void MovingToolHandler(object sender, EventArgs e)
        {
            _paintingToolIsActive = false;
            SwitchTools(false);
        }

        private void SetLine(Color color, Graphics graphics)
        {
            graphics.DrawLine(new Pen(color), _points[0].X, _points[0].Y, _points[1].X, _points[1].Y);
            _lines.Add(new Shape.Line($"{_counter}. {color.Name}", _points[0], _points[1], color));
            var line = new ToolStripMenuItem
            {
                Name = $"#{_counter}",
                Size = new Size(129, 26),
                Text = $@"#{_counter} ({color.Name})",
            };
            line.Click += ShapesMenuItemClick;
            shapesToolStripMenuItem.DropDownItems.Add(line);
            listBox.Items.Add($"Added line: \"#{_counter} ({color.Name})\"");
            _counter++;
            SwitchMovingObject(_lines.Count > 0 ? _lines.Count : 0);
        }

        private void SwitchMovingObject(int objNumber)
        {
            if (_objToMove <= shapesToolStripMenuItem.DropDownItems.Count && _objToMove > 0)
            {
                ((ToolStripMenuItem)shapesToolStripMenuItem.DropDownItems[_objToMove - 1]).Checked = false;
            }
            _objToMove = objNumber;
            ((ToolStripMenuItem)shapesToolStripMenuItem.DropDownItems[_objToMove - 1]).Checked = true;
        }

        private void SwitchTools(bool state)
        {
            ((ToolStripMenuItem)toolsToolStripMenuItem.DropDownItems[0]).Checked = state;
            ((ToolStripMenuItem)toolsToolStripMenuItem.DropDownItems[1]).Checked = !state;
        }

        private readonly List<Point> _points = new List<Point>();
        private List<Shape.Line> _lines = new List<Shape.Line>();
        private uint _counter = 1;
        private bool _isSaved = true;
        private int _objToMove;
        private Point _mousePosition;
        private bool _isDrawing;
        private bool _isMouseDown;
        private bool _paintingToolIsActive = true;
        private Point _mousePosOnMouseDown;
    }
}
