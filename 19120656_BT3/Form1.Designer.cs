
namespace _19120656_BT3
{
    partial class SharpGLForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpGLForm));
            this.bt_Circle = new System.Windows.Forms.Button();
            this.bt_ColorsBox = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.openGLControl = new SharpGL.OpenGLControl();
            this.bt_Rectangle = new System.Windows.Forms.Button();
            this.bt_Ellipse = new System.Windows.Forms.Button();
            this.select_size = new System.Windows.Forms.ComboBox();
            this.bt_Line = new System.Windows.Forms.Button();
            this.bt_RegularPentagon = new System.Windows.Forms.Button();
            this.bt_RegularHexagon = new System.Windows.Forms.Button();
            this.bt_RegularTriangle = new System.Windows.Forms.Button();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.bt_Rotate = new System.Windows.Forms.Button();
            this.bt_Scale = new System.Windows.Forms.Button();
            this.bt_Move = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_Circle
            // 
            this.bt_Circle.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Circle.Location = new System.Drawing.Point(98, 12);
            this.bt_Circle.Name = "bt_Circle";
            this.bt_Circle.Size = new System.Drawing.Size(90, 30);
            this.bt_Circle.TabIndex = 1;
            this.bt_Circle.Text = "Circle";
            this.bt_Circle.UseVisualStyleBackColor = true;
            this.bt_Circle.Click += new System.EventHandler(this.bt_Circle_Click);
            // 
            // bt_ColorsBox
            // 
            this.bt_ColorsBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_ColorsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ColorsBox.Image = ((System.Drawing.Image)(resources.GetObject("bt_ColorsBox.Image")));
            this.bt_ColorsBox.Location = new System.Drawing.Point(612, 59);
            this.bt_ColorsBox.Name = "bt_ColorsBox";
            this.bt_ColorsBox.Size = new System.Drawing.Size(90, 36);
            this.bt_ColorsBox.TabIndex = 2;
            this.bt_ColorsBox.Text = "Colors Box";
            this.bt_ColorsBox.UseVisualStyleBackColor = true;
            this.bt_ColorsBox.Click += new System.EventHandler(this.bt_BangMau_Click);
            // 
            // openGLControl
            // 
            this.openGLControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(2, 48);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(591, 314);
            this.openGLControl.TabIndex = 3;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseUp);
            // 
            // bt_Rectangle
            // 
            this.bt_Rectangle.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Rectangle.Location = new System.Drawing.Point(194, 12);
            this.bt_Rectangle.Name = "bt_Rectangle";
            this.bt_Rectangle.Size = new System.Drawing.Size(90, 30);
            this.bt_Rectangle.TabIndex = 4;
            this.bt_Rectangle.Text = "Rectangle";
            this.bt_Rectangle.UseVisualStyleBackColor = true;
            this.bt_Rectangle.Click += new System.EventHandler(this.bt_Rectangle_Click);
            // 
            // bt_Ellipse
            // 
            this.bt_Ellipse.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Ellipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Ellipse.Location = new System.Drawing.Point(290, 12);
            this.bt_Ellipse.Name = "bt_Ellipse";
            this.bt_Ellipse.Size = new System.Drawing.Size(90, 30);
            this.bt_Ellipse.TabIndex = 5;
            this.bt_Ellipse.Text = "Ellipse";
            this.bt_Ellipse.UseVisualStyleBackColor = true;
            this.bt_Ellipse.Click += new System.EventHandler(this.bt_Ellipse_Click);
            // 
            // select_size
            // 
            this.select_size.Cursor = System.Windows.Forms.Cursors.Hand;
            this.select_size.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_size.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.select_size.FormattingEnabled = true;
            this.select_size.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.select_size.Location = new System.Drawing.Point(599, 267);
            this.select_size.Name = "select_size";
            this.select_size.Size = new System.Drawing.Size(108, 24);
            this.select_size.TabIndex = 10;
            this.select_size.Text = "Width_Level";
            this.select_size.SelectedIndexChanged += new System.EventHandler(this.select_size_SelectedIndexChanged);
            // 
            // bt_Line
            // 
            this.bt_Line.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_Line.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Line.Location = new System.Drawing.Point(2, 12);
            this.bt_Line.Name = "bt_Line";
            this.bt_Line.Size = new System.Drawing.Size(90, 30);
            this.bt_Line.TabIndex = 0;
            this.bt_Line.Text = "Line";
            this.bt_Line.UseVisualStyleBackColor = true;
            this.bt_Line.Click += new System.EventHandler(this.bt_Line_Click);
            // 
            // bt_RegularPentagon
            // 
            this.bt_RegularPentagon.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_RegularPentagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RegularPentagon.Location = new System.Drawing.Point(386, 12);
            this.bt_RegularPentagon.Name = "bt_RegularPentagon";
            this.bt_RegularPentagon.Size = new System.Drawing.Size(98, 29);
            this.bt_RegularPentagon.TabIndex = 11;
            this.bt_RegularPentagon.Text = "Pentagon";
            this.bt_RegularPentagon.UseVisualStyleBackColor = true;
            this.bt_RegularPentagon.Click += new System.EventHandler(this.bt_RegularPentagon_Click);
            // 
            // bt_RegularHexagon
            // 
            this.bt_RegularHexagon.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_RegularHexagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RegularHexagon.Location = new System.Drawing.Point(490, 13);
            this.bt_RegularHexagon.Name = "bt_RegularHexagon";
            this.bt_RegularHexagon.Size = new System.Drawing.Size(96, 29);
            this.bt_RegularHexagon.TabIndex = 12;
            this.bt_RegularHexagon.Text = "Hexagon";
            this.bt_RegularHexagon.UseVisualStyleBackColor = true;
            this.bt_RegularHexagon.Click += new System.EventHandler(this.bt_RegularHexagon_Click);
            // 
            // bt_RegularTriangle
            // 
            this.bt_RegularTriangle.Cursor = System.Windows.Forms.Cursors.Default;
            this.bt_RegularTriangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RegularTriangle.Location = new System.Drawing.Point(592, 12);
            this.bt_RegularTriangle.Name = "bt_RegularTriangle";
            this.bt_RegularTriangle.Size = new System.Drawing.Size(90, 29);
            this.bt_RegularTriangle.TabIndex = 13;
            this.bt_RegularTriangle.Text = "Triangle";
            this.bt_RegularTriangle.UseVisualStyleBackColor = true;
            this.bt_RegularTriangle.Click += new System.EventHandler(this.bt_RegularTriangle_Click);
            // 
            // bt_Clear
            // 
            this.bt_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Clear.Location = new System.Drawing.Point(612, 311);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(80, 35);
            this.bt_Clear.TabIndex = 14;
            this.bt_Clear.Text = "Clear All";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // bt_Rotate
            // 
            this.bt_Rotate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Rotate.Location = new System.Drawing.Point(612, 165);
            this.bt_Rotate.Name = "bt_Rotate";
            this.bt_Rotate.Size = new System.Drawing.Size(80, 29);
            this.bt_Rotate.TabIndex = 15;
            this.bt_Rotate.Text = "Rotate";
            this.bt_Rotate.UseVisualStyleBackColor = true;
            this.bt_Rotate.Click += new System.EventHandler(this.bt_Rotate_Click);
            // 
            // bt_Scale
            // 
            this.bt_Scale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Scale.Location = new System.Drawing.Point(612, 216);
            this.bt_Scale.Name = "bt_Scale";
            this.bt_Scale.Size = new System.Drawing.Size(80, 28);
            this.bt_Scale.TabIndex = 16;
            this.bt_Scale.Text = "Scale";
            this.bt_Scale.UseVisualStyleBackColor = true;
            this.bt_Scale.Click += new System.EventHandler(this.bt_Scale_Click);
            // 
            // bt_Move
            // 
            this.bt_Move.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Move.Location = new System.Drawing.Point(612, 114);
            this.bt_Move.Name = "bt_Move";
            this.bt_Move.Size = new System.Drawing.Size(80, 28);
            this.bt_Move.TabIndex = 17;
            this.bt_Move.Text = "Move";
            this.bt_Move.UseVisualStyleBackColor = true;
            this.bt_Move.Click += new System.EventHandler(this.bt_Move_Click);
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(719, 383);
            this.Controls.Add(this.bt_Move);
            this.Controls.Add(this.bt_Scale);
            this.Controls.Add(this.bt_Rotate);
            this.Controls.Add(this.bt_Clear);
            this.Controls.Add(this.bt_RegularTriangle);
            this.Controls.Add(this.bt_RegularHexagon);
            this.Controls.Add(this.bt_RegularPentagon);
            this.Controls.Add(this.select_size);
            this.Controls.Add(this.bt_Ellipse);
            this.Controls.Add(this.bt_Rectangle);
            this.Controls.Add(this.openGLControl);
            this.Controls.Add(this.bt_ColorsBox);
            this.Controls.Add(this.bt_Circle);
            this.Controls.Add(this.bt_Line);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "SharpGLForm";
            this.Text = "SharpGL Form";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bt_Circle;
        private System.Windows.Forms.Button bt_ColorsBox;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button bt_Rectangle;
        private System.Windows.Forms.Button bt_Ellipse;
        private System.Windows.Forms.ComboBox select_size;
        private System.Windows.Forms.Button bt_Line;
        private System.Windows.Forms.Button bt_RegularPentagon;
        private System.Windows.Forms.Button bt_RegularHexagon;
        private System.Windows.Forms.Button bt_RegularTriangle;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button bt_Rotate;
        private System.Windows.Forms.Button bt_Scale;
        private System.Windows.Forms.Button bt_Move;
    }
}

