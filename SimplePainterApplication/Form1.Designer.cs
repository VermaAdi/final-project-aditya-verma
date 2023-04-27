using Svg;
namespace SimplePainterApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.strokeWidthTrackBar = new System.Windows.Forms.TrackBar();
            this.strokeColorDialog = new System.Windows.Forms.ColorDialog();
            this.strokeColorButton = new System.Windows.Forms.Button();
            this.filledCheckBox = new System.Windows.Forms.CheckBox();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.freeDrawRadioButton = new System.Windows.Forms.RadioButton();
            this.cloudToEllipseRadioButton = new System.Windows.Forms.RadioButton();
            this.cloudRadioButton = new System.Windows.Forms.RadioButton();
            this.starRadioButton = new System.Windows.Forms.RadioButton();
            this.circleRadioButton = new System.Windows.Forms.RadioButton();
            this.sqaureRadioButton = new System.Windows.Forms.RadioButton();
            this.rectangleRadioButton = new System.Windows.Forms.RadioButton();
            this.ellipseRadioButton = new System.Windows.Forms.RadioButton();
            this.fillColorDialog = new System.Windows.Forms.ColorDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSVGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInButton = new System.Windows.Forms.Button();
            this.zoomOutButton = new System.Windows.Forms.Button();
            this.selectCheckBox = new System.Windows.Forms.CheckBox();
            this.deleteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(18, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(953, 301);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // strokeWidthTrackBar
            // 
            this.strokeWidthTrackBar.Location = new System.Drawing.Point(648, 64);
            this.strokeWidthTrackBar.Minimum = 1;
            this.strokeWidthTrackBar.Name = "strokeWidthTrackBar";
            this.strokeWidthTrackBar.Size = new System.Drawing.Size(246, 56);
            this.strokeWidthTrackBar.TabIndex = 1;
            this.strokeWidthTrackBar.Value = 1;
            // 
            // strokeColorButton
            // 
            this.strokeColorButton.Location = new System.Drawing.Point(319, 37);
            this.strokeColorButton.Name = "strokeColorButton";
            this.strokeColorButton.Size = new System.Drawing.Size(144, 44);
            this.strokeColorButton.TabIndex = 2;
            this.strokeColorButton.Text = "Stroke Color";
            this.strokeColorButton.UseVisualStyleBackColor = true;
            this.strokeColorButton.Click += new System.EventHandler(this.strokeColorButton_Click);
            // 
            // filledCheckBox
            // 
            this.filledCheckBox.AutoSize = true;
            this.filledCheckBox.Location = new System.Drawing.Point(319, 148);
            this.filledCheckBox.Name = "filledCheckBox";
            this.filledCheckBox.Size = new System.Drawing.Size(67, 24);
            this.filledCheckBox.TabIndex = 3;
            this.filledCheckBox.Text = "Filled";
            this.filledCheckBox.UseVisualStyleBackColor = true;
            // 
            // fillColorButton
            // 
            this.fillColorButton.Location = new System.Drawing.Point(319, 84);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(144, 45);
            this.fillColorButton.TabIndex = 4;
            this.fillColorButton.Text = "Fill Color";
            this.fillColorButton.UseVisualStyleBackColor = true;
            this.fillColorButton.Click += new System.EventHandler(this.fillColorButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Stroke Width";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.freeDrawRadioButton);
            this.groupBox1.Controls.Add(this.cloudToEllipseRadioButton);
            this.groupBox1.Controls.Add(this.cloudRadioButton);
            this.groupBox1.Controls.Add(this.starRadioButton);
            this.groupBox1.Controls.Add(this.circleRadioButton);
            this.groupBox1.Controls.Add(this.sqaureRadioButton);
            this.groupBox1.Controls.Add(this.rectangleRadioButton);
            this.groupBox1.Controls.Add(this.ellipseRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(55, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 167);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shapes";
            // 
            // freeDrawRadioButton
            // 
            this.freeDrawRadioButton.AutoSize = true;
            this.freeDrawRadioButton.Location = new System.Drawing.Point(151, 56);
            this.freeDrawRadioButton.Name = "freeDrawRadioButton";
            this.freeDrawRadioButton.Size = new System.Drawing.Size(97, 24);
            this.freeDrawRadioButton.TabIndex = 7;
            this.freeDrawRadioButton.TabStop = true;
            this.freeDrawRadioButton.Text = "Free Draw";
            this.freeDrawRadioButton.UseVisualStyleBackColor = true;
            // 
            // cloudToEllipseRadioButton
            // 
            this.cloudToEllipseRadioButton.AutoSize = true;
            this.cloudToEllipseRadioButton.Location = new System.Drawing.Point(11, 56);
            this.cloudToEllipseRadioButton.Name = "cloudToEllipseRadioButton";
            this.cloudToEllipseRadioButton.Size = new System.Drawing.Size(134, 24);
            this.cloudToEllipseRadioButton.TabIndex = 6;
            this.cloudToEllipseRadioButton.TabStop = true;
            this.cloudToEllipseRadioButton.Text = "Cloud to Ellipse";
            this.cloudToEllipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // cloudRadioButton
            // 
            this.cloudRadioButton.AutoSize = true;
            this.cloudRadioButton.Location = new System.Drawing.Point(10, 27);
            this.cloudRadioButton.Name = "cloudRadioButton";
            this.cloudRadioButton.Size = new System.Drawing.Size(69, 24);
            this.cloudRadioButton.TabIndex = 5;
            this.cloudRadioButton.TabStop = true;
            this.cloudRadioButton.Text = "Cloud";
            this.cloudRadioButton.UseVisualStyleBackColor = true;
            // 
            // starRadioButton
            // 
            this.starRadioButton.AutoSize = true;
            this.starRadioButton.Location = new System.Drawing.Point(150, 23);
            this.starRadioButton.Name = "starRadioButton";
            this.starRadioButton.Size = new System.Drawing.Size(56, 24);
            this.starRadioButton.TabIndex = 4;
            this.starRadioButton.TabStop = true;
            this.starRadioButton.Text = "Star";
            this.starRadioButton.UseVisualStyleBackColor = true;
            // 
            // circleRadioButton
            // 
            this.circleRadioButton.AutoSize = true;
            this.circleRadioButton.Location = new System.Drawing.Point(150, 120);
            this.circleRadioButton.Name = "circleRadioButton";
            this.circleRadioButton.Size = new System.Drawing.Size(67, 24);
            this.circleRadioButton.TabIndex = 3;
            this.circleRadioButton.TabStop = true;
            this.circleRadioButton.Text = "Circle";
            this.circleRadioButton.UseVisualStyleBackColor = true;
            // 
            // sqaureRadioButton
            // 
            this.sqaureRadioButton.AutoSize = true;
            this.sqaureRadioButton.Location = new System.Drawing.Point(11, 120);
            this.sqaureRadioButton.Name = "sqaureRadioButton";
            this.sqaureRadioButton.Size = new System.Drawing.Size(76, 24);
            this.sqaureRadioButton.TabIndex = 2;
            this.sqaureRadioButton.TabStop = true;
            this.sqaureRadioButton.Text = "Square";
            this.sqaureRadioButton.UseVisualStyleBackColor = true;
            // 
            // rectangleRadioButton
            // 
            this.rectangleRadioButton.AutoSize = true;
            this.rectangleRadioButton.Location = new System.Drawing.Point(11, 91);
            this.rectangleRadioButton.Name = "rectangleRadioButton";
            this.rectangleRadioButton.Size = new System.Drawing.Size(96, 24);
            this.rectangleRadioButton.TabIndex = 1;
            this.rectangleRadioButton.Text = "Rectangle";
            this.rectangleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ellipseRadioButton
            // 
            this.ellipseRadioButton.AutoSize = true;
            this.ellipseRadioButton.Checked = true;
            this.ellipseRadioButton.Location = new System.Drawing.Point(150, 91);
            this.ellipseRadioButton.Name = "ellipseRadioButton";
            this.ellipseRadioButton.Size = new System.Drawing.Size(73, 24);
            this.ellipseRadioButton.TabIndex = 0;
            this.ellipseRadioButton.TabStop = true;
            this.ellipseRadioButton.Text = "Ellipse";
            this.ellipseRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(469, 45);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(26, 27);
            this.panel1.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(469, 93);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 27);
            this.panel2.TabIndex = 14;
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.shareToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip2.Size = new System.Drawing.Size(993, 30);
            this.menuStrip2.TabIndex = 16;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveMenuItem
            // 
            this.saveMenuItem.Name = "saveMenuItem";
            this.saveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveMenuItem.Size = new System.Drawing.Size(229, 26);
            this.saveMenuItem.Text = "Save";
            this.saveMenuItem.Click += new System.EventHandler(this.saveMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // shareToolStripMenuItem
            // 
            this.shareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSVGToolStripMenuItem,
            this.exportSVGToolStripMenuItem});
            this.shareToolStripMenuItem.Name = "shareToolStripMenuItem";
            this.shareToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.shareToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.shareToolStripMenuItem.Text = "Share";
            // 
            // importSVGToolStripMenuItem
            // 
            this.importSVGToolStripMenuItem.Name = "importSVGToolStripMenuItem";
            this.importSVGToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importSVGToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.importSVGToolStripMenuItem.Text = "Import SVG";
            this.importSVGToolStripMenuItem.Click += new System.EventHandler(this.importSvgToolStripMenuItem_Click);
            // 
            // exportSVGToolStripMenuItem
            // 
            this.exportSVGToolStripMenuItem.Name = "exportSVGToolStripMenuItem";
            this.exportSVGToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportSVGToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.exportSVGToolStripMenuItem.Text = "Export SVG";
            this.exportSVGToolStripMenuItem.Click += new System.EventHandler(this.exportSvgToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.undoButton});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // undoButton
            // 
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(177, 26);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // zoomInButton
            // 
            this.zoomInButton.Location = new System.Drawing.Point(510, 43);
            this.zoomInButton.Name = "zoomInButton";
            this.zoomInButton.Size = new System.Drawing.Size(107, 53);
            this.zoomInButton.TabIndex = 17;
            this.zoomInButton.Text = "Zoom In   (Ctrl + Up)";
            this.zoomInButton.UseVisualStyleBackColor = true;
            this.zoomInButton.Click += new System.EventHandler(this.zoomInButton_Click);
            this.zoomInButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // zoomOutButton
            // 
            this.zoomOutButton.Location = new System.Drawing.Point(510, 107);
            this.zoomOutButton.Name = "zoomOutButton";
            this.zoomOutButton.Size = new System.Drawing.Size(107, 52);
            this.zoomOutButton.TabIndex = 18;
            this.zoomOutButton.Text = "Zoom Out  (Ctrl + Down)";
            this.zoomOutButton.UseVisualStyleBackColor = true;
            this.zoomOutButton.Click += new System.EventHandler(this.zoomOutButton_Click);
            this.zoomOutButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_KeyDown);
            // 
            // selectCheckBox
            // 
            this.selectCheckBox.AutoSize = true;
            this.selectCheckBox.Location = new System.Drawing.Point(392, 148);
            this.selectCheckBox.Name = "selectCheckBox";
            this.selectCheckBox.Size = new System.Drawing.Size(71, 24);
            this.selectCheckBox.TabIndex = 19;
            this.selectCheckBox.Text = "Select";
            this.selectCheckBox.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(661, 118);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(107, 41);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 507);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectCheckBox);
            this.Controls.Add(this.zoomOutButton);
            this.Controls.Add(this.zoomInButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fillColorButton);
            this.Controls.Add(this.filledCheckBox);
            this.Controls.Add(this.strokeColorButton);
            this.Controls.Add(this.strokeWidthTrackBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.strokeWidthTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private PictureBox pictureBox1;
        private TrackBar strokeWidthTrackBar;
        private ColorDialog strokeColorDialog;
        private Button strokeColorButton;
        private CheckBox filledCheckBox;
        private Button fillColorButton;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton rectangleRadioButton;
        private RadioButton ellipseRadioButton;
        private ColorDialog fillColorDialog;
        private Panel panel1;
        private Panel panel2;
        private SvgDocument svgDocument;
        private RadioButton sqaureRadioButton;
        private RadioButton circleRadioButton;
        private RadioButton starRadioButton;
        private RadioButton cloudRadioButton;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem shareToolStripMenuItem;
        private ToolStripMenuItem importSVGToolStripMenuItem;
        private ToolStripMenuItem exportSVGToolStripMenuItem;
        private RadioButton cloudToEllipseRadioButton;
        private Button zoomInButton;
        private Button zoomOutButton;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private RadioButton freeDrawRadioButton;
        private ToolStripMenuItem undoButton;
        private CheckBox selectCheckBox;
        private Button deleteButton;
    }

}