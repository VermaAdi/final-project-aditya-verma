using Svg;
using System.Drawing.Imaging;

namespace SimplePainterApplication
{
    /// <summary>
    /// Class <c>Form1</c> defines functionality of the Form.
    /// </summary>
    public partial class Form1 : Form
    {
        //private fields
        private List<Shape> _actions = new List<Shape>();
        private Stack<List<Shape>> _undoStack = new Stack<List<Shape>>();
        private Shape _currentShape;
        private Point? _previousMousePosition = null;
        private Point _mouseDownLocation;
        private float _zoomFactor = 1.0f;
        private bool _drawing = false;

        public List<Shape> Shapes = new List<Shape>();

        /// <summary>
        /// Initializes a new instance of the <c>Form1</c> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(Form_KeyDown);
            this.KeyPreview = true;
            strokeColorDialog.Color = Color.Black;
            fillColorDialog.Color = Color.Aquamarine;
           
            UpdatePanels();
        }

        /// <summary>
        /// Updates the color panels for stroke and fill colors.
        /// </summary>
        private void UpdatePanels()
        {
            panel1.BackColor = strokeColorDialog.Color;
            panel2.BackColor = fillColorDialog.Color;

        }

        //---------------------------------------------- Picture Box Functionality -----------------------------------------------------

        /// <summary>
        /// Handles the Paint event for the PictureBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (_drawing && _currentShape != null && !freeDrawRadioButton.Checked)
            {
                using (var pen = new Pen(strokeColorDialog.Color, strokeWidthTrackBar.Value))
                using (SolidBrush brush = new SolidBrush(_currentShape.FillColor))
                {
                    var tempImage = GetImageWithShapes();
                    e.Graphics.DrawImage(tempImage, new Rectangle(0, 0, (int)(tempImage.Width * _zoomFactor), (int)(tempImage.Height * _zoomFactor)));
                    e.Graphics.ScaleTransform(_zoomFactor, _zoomFactor);
                    pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    if (_currentShape.Type == ShapeType.Rect || _currentShape.Type == ShapeType.Square)
                    {
                        e.Graphics.DrawRectangle(pen, _currentShape.X, _currentShape.Y, _currentShape.Width, _currentShape.Height);
                    }
                    else if (_currentShape.Type == ShapeType.Ellipse || _currentShape.Type == ShapeType.Circle)
                    {
                        e.Graphics.DrawEllipse(pen, _currentShape.X, _currentShape.Y, _currentShape.Width, _currentShape.Height);
                    }
                    else if (_currentShape.Type == ShapeType.Star)
                    {
                        PointF center = new PointF(_currentShape.X + _currentShape.Width / 2, _currentShape.Y + _currentShape.Height / 2);
                        float outerRadius = Math.Min(_currentShape.Width, _currentShape.Height) / 2;
                        float innerRadius = outerRadius * 0.5f;
                        int numPoints = 5;

                        DrawStar(e.Graphics, center, outerRadius, innerRadius, numPoints, pen, _currentShape.Filled ? brush : null);
                    }
                    else if (_currentShape.Type == ShapeType.Cloud)
                    {
                        RectangleF bounds = new RectangleF(_currentShape.X, _currentShape.Y, _currentShape.Width, _currentShape.Height);
                        DrawCloud(e.Graphics, bounds, pen, _currentShape.Filled ? brush : null);
                    }
                }
            }
            foreach (Shape shape in _actions)

            {
                if (shape.Selected)
                {
                    using (Pen selectionPen = new Pen(Color.Red, 1))
                    {
                        selectionPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawRectangle(selectionPen, shape.X - 2, shape.Y - 2, shape.Width + 4, shape.Height + 4);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the MouseDown event for the PictureBox, 
        /// initializing the drawing process.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (selectCheckBox.Checked)
            {
                Shape selectedShape = Shapes.LastOrDefault(shape => shape.Contains(e.Location));

                // Deselect all other shapes
                foreach (Shape shape in Shapes)
                {
                    shape.Selected = false;
                }

                if (selectedShape != null)
                {
                    selectedShape.Selected = true;
                }
            }
            if (e.Button == MouseButtons.Left) // Start drawing a shape
            {
                _drawing = true;
                _mouseDownLocation = e.Location;
                _currentShape = new Shape()
                {
                    X = e.X,
                    Y = e.Y,
                    Width = 0,
                    Height = 0,
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    Filled = filledCheckBox.Checked,
                    StrokeThickness = strokeWidthTrackBar.Value,
                    Type = ellipseRadioButton.Checked ? ShapeType.Ellipse :
                    (rectangleRadioButton.Checked ? ShapeType.Rect : (circleRadioButton.Checked ?
                    ShapeType.Circle : (sqaureRadioButton.Checked ? ShapeType.Square :
                    (starRadioButton.Checked ? ShapeType.Star : ShapeType.Cloud)))),

                };

            }
            else if (e.Button == MouseButtons.Right) // Cancel drawing the shape
            {
                _drawing = false;
                _currentShape = null;
                pictureBox1.Invalidate();
            }

        }

        /// <summary>
        /// Finalizes shape information when the mouse button is released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                _drawing = false;
                Shape shape = new Shape
                {
                    X = Math.Min(_mouseDownLocation.X, e.Location.X),
                    Y = Math.Min(_mouseDownLocation.Y, e.Location.Y),
                    Width = Math.Abs(e.Location.X - _mouseDownLocation.X),
                    Height = Math.Abs(e.Location.Y - _mouseDownLocation.Y),
                    StrokeColor = strokeColorDialog.Color,
                    FillColor = fillColorDialog.Color,
                    StrokeThickness = (float)strokeWidthTrackBar.Value,
                    Filled = filledCheckBox.Checked,
                };
                if (!freeDrawRadioButton.Checked)
                {
                    if (rectangleRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Rect;
                    }
                    else if (ellipseRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Ellipse;
                    }
                    else if (sqaureRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Square;
   
                    }
                    else if (circleRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Circle;
                    }
                    else if (cloudRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Cloud;
                    }
                    else if (starRadioButton.Checked)
                    {
                        shape.Type = ShapeType.Star;
                    }
                    // Add this line just before Shapes.Add(shape);
                    _actions.Add(shape);
                        SaveState();
                        Shapes.Add(shape);

                    // Update the PictureBox with the new shape
                    Bitmap updatedImage = GetImageWithShapes();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose(); // Dispose the old image to free up memory
                    }
                    pictureBox1.Image = updatedImage;
                }
                pictureBox1.Invalidate(); // Force the PictureBox to repaint
            }
        }

        /// <summary>
        /// Updates shapes when the mouse button 
        /// is moved across the picture box while pressed down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_drawing)
            {
                if (freeDrawRadioButton.Checked) // Free drawing with the mouse
                {
                    if (_previousMousePosition.HasValue)
                    {
                        if (pictureBox1.Image == null)
                        {
                            // Create a new Bitmap and set it as the PictureBox's Image
                            var newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);
                            using (var g = Graphics.FromImage(newBitmap))
                            {
                                g.Clear(Color.Transparent);
                            }
                            pictureBox1.Image = newBitmap;
                        }

                        using (var g = Graphics.FromImage(pictureBox1.Image))
                        using (var pen = new Pen(strokeColorDialog.Color, strokeWidthTrackBar.Value))
                        {
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                            g.DrawLine(pen, _previousMousePosition.Value, e.Location);
                        }

                        pictureBox1.Invalidate();
                    }

                    _previousMousePosition = e.Location;
                }
                else
                {
                    _currentShape.Width = e.X - _currentShape.X;
                    _currentShape.Height = e.Y - _currentShape.Y;
                    if (_currentShape.Type == ShapeType.Square || _currentShape.Type == ShapeType.Circle)
                    {
                        int side = (int)Math.Min(_currentShape.Width, _currentShape.Height);
                        _currentShape.Width = side;
                        _currentShape.Height = side;
                    }
                    pictureBox1.Invalidate();
                }
            }
            else
            {
                _previousMousePosition = null;
            }
        }

        //---------------------------------------------- Picture Box to SVG Document -----------------------------------------------------

        /// <summary>
        /// Converts a list of shapes to an SvgDocument.
        /// </summary>
        /// <param name="shapes">A list of shapes to be converted.</param>
        /// <returns>An SvgDocument containing the shapes.</returns>
        public SvgDocument ShapesToSvgDocument(List<Shape> shapes)
        {
            SvgDocument svgDocument = new SvgDocument();
            Svg.SvgGroup group = new Svg.SvgGroup();

            foreach (var shape in shapes)
            {
                if (shape.Type == ShapeType.Ellipse)
                {
                    Svg.SvgEllipse svgEllipse = new Svg.SvgEllipse
                    {
                        CenterX = new Svg.SvgUnit(shape.X + shape.Width / 2),
                        CenterY = new Svg.SvgUnit(shape.Y + shape.Height / 2),
                        RadiusX = new Svg.SvgUnit(shape.Width / 2),
                        RadiusY = new Svg.SvgUnit(shape.Height / 2),
                        Stroke = new SvgColourServer(shape.StrokeColor),
                        StrokeWidth = shape.StrokeThickness,
                    };

                    if (shape.Filled)
                    {
                        svgEllipse.Fill = new SvgColourServer(shape.FillColor);
                    }
                    else
                    {
                        svgEllipse.Fill = SvgPaintServer.None;
                    }

                    group.Children.Add(svgEllipse);
                }
                else if (shape.Type == ShapeType.Rect)
                {
                    Svg.SvgRectangle svgRectangle = new Svg.SvgRectangle
                    {
                        X = new Svg.SvgUnit(shape.X),
                        Y = new Svg.SvgUnit(shape.Y),
                        Width = new Svg.SvgUnit(shape.Width),
                        Height = new Svg.SvgUnit(shape.Height),
                        Stroke = new SvgColourServer(shape.StrokeColor),
                        StrokeWidth = shape.StrokeThickness,
                    };

                    if (shape.Filled)
                    {
                        svgRectangle.Fill = new SvgColourServer(shape.FillColor);
                    }
                    else
                    {
                        svgRectangle.Fill = SvgPaintServer.None;
                    }

                    group.Children.Add(svgRectangle);
                }
            }

            svgDocument.Children.Add(group);
            return svgDocument;
        }

        /// <summary>
        /// Creates a new Bitmap image containing the original image with the drawn shapes
        /// </summary>
        /// <returns>Returns a Bitmap image with the shapes drawn over the original image</returns>
        private Bitmap GetImageWithShapes()
        {
            Bitmap newImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(newImage))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw the original image
                if (pictureBox1.Image != null)
                {
                    g.DrawImage(pictureBox1.Image, 0, 0, pictureBox1.Width, pictureBox1.Height);
                }

                // Draw shapes
                foreach (Shape shape in Shapes)
                {
                    using (Pen pen = new Pen(shape.StrokeColor, shape.StrokeThickness))
                    using (SolidBrush brush = new SolidBrush(shape.FillColor))
                    {
                        if (shape.Type == ShapeType.Rect || shape.Type == ShapeType.Square)
                        {
                            g.DrawRectangle(pen, shape.X, shape.Y, shape.Width, shape.Height);
                            if (shape.Filled)
                            {
                                g.FillRectangle(brush, shape.X, shape.Y, shape.Width, shape.Height);
                            }
                        }
                        else if (shape.Type == ShapeType.Ellipse || shape.Type == ShapeType.Circle)
                        {
                            g.DrawEllipse(pen, shape.X, shape.Y, shape.Width, shape.Height);
                            if (shape.Filled)
                            {
                                g.FillEllipse(brush, shape.X, shape.Y, shape.Width, shape.Height);
                            }
                        }
                        else if (shape.Type == ShapeType.Cloud)
                        {
                            RectangleF bounds = new RectangleF(shape.X, shape.Y, shape.Width, shape.Height);
                            DrawCloud(g, bounds, pen, shape.Filled ? brush : null);
                        }
                        else if (shape.Type == ShapeType.Star)
                        {
                            PointF center = new PointF(shape.X + shape.Width / 2, shape.Y + shape.Height / 2);
                            float outerRadius = Math.Min(shape.Width, shape.Height) / 2;
                            float innerRadius = outerRadius * 0.5f;
                            int numPoints = 5;

                            DrawStar(g, center, outerRadius, innerRadius, numPoints, pen, shape.Filled ? brush : null);
                        }

                        // Highlight the selected shape with a dashed border
                        if (shape.Selected)
                        {
                            using (Pen selectionPen = new Pen(Color.Black, 1))
                            {
                                selectionPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                                g.DrawRectangle(selectionPen, shape.X - 2, shape.Y - 2, shape.Width + 4, shape.Height + 4);
                            }
                        }
                    }
                }
            }

            return newImage;
        }

        //---------------------------------------------- Additional Required Methods -----------------------------------------------------

        /// <summary>
        /// Applies the current zoom factor to the image in pictureBox1 control
        /// </summary>
        private void ApplyZoom()
        {
            if (pictureBox1.Image != null)
            {
                int newWidth = (int)(pictureBox1.Image.Width * _zoomFactor);
                int newHeight = (int)(pictureBox1.Image.Height * _zoomFactor);

                // Create a new Bitmap with the new dimensions
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                using (Graphics g = Graphics.FromImage(newBitmap))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(pictureBox1.Image, 0, 0, newWidth, newHeight);
                }

                // Assign the new Bitmap to the PictureBox and refresh
                pictureBox1.Image.Dispose(); // Dispose the old image to free up memory
                pictureBox1.Image = newBitmap;
                pictureBox1.Refresh();
            }
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Saves the current state of drawn shapes.
        /// </summary>
        private void SaveState()
        {
            List<Shape> state = new List<Shape>(Shapes.Select(s => s.Clone()));
            _undoStack.Push(state);
        }

        /// <summary>
        /// Keyboard ShortCut Functionality for Zoom-In and Zoom-Out.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Up) // Ctrl + 'Up'
            {
                zoomInButton_Click(sender, e);
            }
            else if (e.Control && e.KeyCode == Keys.Down) // Ctrl + 'Down'
            {
                zoomOutButton_Click(sender, e);
            }
        }

        //----------------------------------------------Special Shape Calculations -----------------------------------------------------

        /// <summary>
        /// Draws a star shape on the given Graphics object.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="center"></param>
        /// <param name="outerRadius"></param>
        /// <param name="innerRadius"></param>
        /// <param name="numPoints"></param>
        /// <param name="pen"></param>
        /// <param name="fillBrush"></param>
        private void DrawStar(Graphics g, PointF center, float outerRadius, float innerRadius, int numPoints, Pen pen, SolidBrush fillBrush)
        {
            PointF[] points = new PointF[numPoints * 2];
            double step = Math.PI / numPoints;
            double angle = Math.PI / 2;

            for (int i = 0; i < numPoints * 2; i++)
            {
                float radius = (i % 2 == 0) ? outerRadius : innerRadius;
                points[i] = new PointF(center.X + (float)(radius * Math.Cos(angle)), center.Y - (float)(radius * Math.Sin(angle)));
                angle += step;
            }

            if (fillBrush != null)
            {
                g.FillPolygon(fillBrush, points);
            }

            if (pen != null)
            {
                g.DrawPolygon(pen, points);
            }
        }

        /// <summary>
        /// Draws a cloud shape on the given Graphics object.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="bounds"></param>
        /// <param name="pen"></param>
        /// <param name="fillBrush"></param>
        private void DrawCloud(Graphics g, RectangleF bounds, Pen pen, SolidBrush fillBrush)
        {
            float cloudRadius = Math.Min(bounds.Width, bounds.Height) / 5;

            PointF[] circleCenters = new PointF[]
            {
                new PointF(bounds.Left + cloudRadius, bounds.Top + cloudRadius * 2),
                new PointF(bounds.Left + cloudRadius * 2, bounds.Top + cloudRadius),
                new PointF(bounds.Left + cloudRadius * 3, bounds.Top + cloudRadius),
                new PointF(bounds.Left + cloudRadius * 4, bounds.Top + cloudRadius * 2),
                new PointF(bounds.Left + cloudRadius * 3, bounds.Top + cloudRadius * 3),
                new PointF(bounds.Left + cloudRadius * 2, bounds.Top + cloudRadius * 3),
            };

            if (fillBrush != null)
            {
                foreach (PointF center in circleCenters)
                {
                    g.FillEllipse(fillBrush, center.X - cloudRadius, center.Y - cloudRadius, cloudRadius * 2, cloudRadius * 2);
                }
            }

            if (pen != null)
            {
                foreach (PointF center in circleCenters)
                {
                    g.DrawEllipse(pen, center.X - cloudRadius, center.Y - cloudRadius, cloudRadius * 2, cloudRadius * 2);
                }
            }
        }


        //---------------------------------------------- All Click Event Handlers -----------------------------------------------------

        /// <summary>
        /// Defines functionality when user clicks on strokeColorButton 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strokeColorButton_Click(object sender, EventArgs e)
        {
            strokeColorDialog.ShowDialog();
            UpdatePanels();
        }

        /// <summary>
        /// Defines functionality when user clicks on fillColorButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fillColorButton_Click(object sender, EventArgs e)
        {
            fillColorDialog.ShowDialog();
            UpdatePanels();
        }

        /// <summary>
        /// Imports an SVG file and displays it in the PictureBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importSvgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "SVG files (*.svg)|*.svg",
                Title = "Open SVG file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SvgDocument svgDocument = SvgDocument.Open(openFileDialog.FileName);
                Bitmap bitmap = svgDocument.Draw();
                pictureBox1.Image = bitmap;
            }
        }

        /// <summary>
        /// Exports the drawn shapes as an SVG file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportSvgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "SVG files (*.svg)|*.svg";
                saveFileDialog.DefaultExt = "svg";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SvgDocument svgDocument = ShapesToSvgDocument(Shapes);
                    svgDocument.Write(saveFileDialog.FileName);
                }
            }
        }

        /// <summary>
        /// Saves the drawn shapes as an image file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Determine the file format based on the selected extension
                    ImageFormat format;
                    switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            format = ImageFormat.Png;
                            break;
                    }

                    // Save the PictureBox's Image with shapes as an image file
                    Bitmap imageWithShapes = GetImageWithShapes();
                    imageWithShapes.Save(saveFileDialog.FileName, format);
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the exit menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event for the save-as menu item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG files (*.png)|*.png|JPEG files (*.jpg)|*.jpg|BMP files (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Determine the file format based on the selected extension
                    ImageFormat format;
                    switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ImageFormat.Bmp;
                            break;
                        default:
                            format = ImageFormat.Png;
                            break;
                    }

                    // Save the PictureBox's Image with shapes as an image file
                    Bitmap imageWithShapes = GetImageWithShapes();
                    imageWithShapes.Save(saveFileDialog.FileName, format);
                }
            }
        }

        /// <summary>
        /// Handles the Click event for the undoButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoButton_Click(object sender, EventArgs e)
        {
            if (_undoStack.Count > 0)
            {
                Shapes = _undoStack.Pop();
                pictureBox1.Invalidate();
            }
        }

        /// <summary>
        /// Handles the Click event for the clearToolStripMenuItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _actions.Clear();
            _undoStack.Clear();
            Shapes.Clear(); // Clear the Shapes list

            // Create a new transparent Bitmap for the PictureBox
            Bitmap newBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height, PixelFormat.Format32bppArgb);
            using (var g = Graphics.FromImage(newBitmap))
            {
                g.Clear(Color.Transparent);
            }

            // Dispose the old image and assign the new Bitmap to the PictureBox
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = newBitmap;

            pictureBox1.Invalidate(); // Refresh the PictureBox
        }

        /// <summary>
        /// Handles the Click event for the zoom-in button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomInButton_Click(object sender, EventArgs e)
        {
            _zoomFactor += 0.1f; // Increase the zoom factor by 10%
            ApplyZoom();
        }

        /// <summary>
        /// Handles the Click event for the zoom-out button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            if (_zoomFactor > 0.1f) // Prevent zoom factor from going below 10% (0.1)
            {
                _zoomFactor -= 0.1f; // Decrease the zoom factor by 10%
                ApplyZoom();
            }
        }

        /// <summary>
        /// Handles the Click event for the delete button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            SaveState(); // Save the state before deleting the shape
            Shapes.RemoveAll(shape => shape.Selected);
            pictureBox1.Invalidate();
        }

        /// <summary>
        /// Handles the DoubleClick event for the PictureBox1 control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            Shape selectedShape = Shapes.FirstOrDefault(shape => shape.Contains(Location));

            if (selectedShape != null)
            {
                foreach (Shape shape in Shapes)
                {
                    shape.Selected = shape == selectedShape;
                }
            }
            else
            {
                foreach (Shape shape in Shapes)
                {
                    shape.Selected = false;
                }
            }

            pictureBox1.Invalidate(); // Force the PictureBox to repaint
        }

        /// <summary>
        /// Handles the Click event for the PictureBox1 control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Shape selectedShape = Shapes.FirstOrDefault(shape => shape.Contains(Location));

            if (selectedShape != null)
            {
                Shapes.Remove(selectedShape);
                pictureBox1.Invalidate(); // Force the PictureBox to repaint
            }
        }

    }

}