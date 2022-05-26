using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using _19120656_BT3.Shape;
//sửa lỗi: 'Rectangle' is an ambiguous reference between '_19120656_BT3.Shape.Rectangle' and 'System.Drawing.Rectangle'
using Rectangle = _19120656_BT3.Shape.Rectangle;

namespace _19120656_BT3
{
    public partial class SharpGLForm : Form
    {
        OpenGL gl;
        List<Shape.Shape> shapeList;    //danh sách hình sẽ vẽ

        Color useColor; //màu để vẽ hình

        //-1:nếu chưa chọn hình để vẽ
        //0: Line, 1: Circle, 2: Ellipse , 3: Regular triangle
        //4: Rectangle , 5:Regular Pentagon, 6:Regular Hexagon
        short shapeOption;

        Point pStart, pEnd; //điểm bắt đầu và kết thúc khi nhấn và thả chuột
        float pointWidth; //độ dày của nét vẽ
        bool isTransforming;    //đánh dấu đang thực hiện biến đổi affine
        int choosingShape;  //Số thứ tự của hình đang được chọn lại, trả về -1 nếu chưa có hình nào được chọn
        bool isShapeChange; //đánh dấu thực hiện thay đổi hình khi được tác động bởi phép biến đổi affine
        bool isMove;    //đánh dấu thực hiện biến đổi affine tịnh tiến
        bool isRotate;  //đánh dấu thực hiện biến đổi affine phép quay
        bool isScale;   //đánh dấu thực hiện biến đổi affine phép co giãn

        public SharpGLForm()
        {
            InitializeComponent();
            //giá trị màu ban đầu
            useColor = Color.White;
            shapeOption = 0;    //mặc định ban đầu là đoạn thẳng
            pStart = new Point() { };
            pEnd = new Point() { };
            gl = openGLControl.OpenGL;
            pointWidth = (float)2.0;
            shapeList = new List<Shape.Shape>();
            isTransforming = false;
            choosingShape = -1;
            isShapeChange = false;
            isRotate = false;
            isScale = false;
            isMove = false;
        }

        //ghi nhận thao tác nhấn chuột
        private void ctrl_OpenGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            //nhấp chuột trái
            if (e.Button == MouseButtons.Left)
            {
                //cập nhật tọa độ điểm đầu và cuối (chung cho cả 2 trường hợp vẽ hình hoặc không vẽ hình)
                pStart.X = e.Location.X;
                pStart.Y = gl.RenderContextProvider.Height - e.Location.Y;
                pEnd = pStart;

                //nhấn chuột trái nhưng không vẽ hình => chọn hình hoặc biến đổi affine
                if (shapeOption == -1)
                {
                    //chọn hình để thực hiện phép biến đổi affine
                    if (choosingShape == -1)
                    {
                        //tìm ra điểm điều khiển gần nhất với điểm click hiện tại
                        float minDistance = 99999999999999;

                        for (int i = 0; i < shapeList.Count(); i++)
                        {
                            List<Point> tmpControlPoint = shapeList[i].getControlPoint();   //lấy tập điểm điều khiển của hình
                            for (int j = 0; j < tmpControlPoint.Count(); j++)
                            {
                                float distance = tmpControlPoint[j].X * tmpControlPoint[j].X + tmpControlPoint[j].Y * tmpControlPoint[j].Y;
                                if (distance < minDistance)
                                {
                                    minDistance = distance;
                                    choosingShape = i;
                                }
                            }
                        }
                    }

                    if (isScale)
                    {
                        isScale = false;
                    }

                    if (isRotate)
                    {
                        isRotate = false;
                    }
                }
            }
        }

        //ghi nhận thao tác thả nhấn chuột
        private void ctrl_OpenGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            pEnd.X = e.Location.X;
            pEnd.Y = gl.RenderContextProvider.Height - e.Location.Y;
            //khi thả nhấn chuột thì kiểm tra xem phải vẽ hình không, và thực hiện vẽ nếu đúng

            if (shapeOption != -1)
            {
                Shape.Shape shape;
                if (shapeOption == 0)
                    shape = new Line(pStart, pEnd, useColor, pointWidth);
                else if (shapeOption == 1)
                    shape = new Circle(pStart, pEnd, useColor, pointWidth);
                else if (shapeOption == 2)
                    shape = new Ellipse(pStart, pEnd, useColor, pointWidth);
                else if (shapeOption == 4)
                    shape = new Rectangle(pStart, pEnd, useColor, pointWidth);
                else shape = new RegularPolygon(pStart, pEnd, useColor, pointWidth, shapeOption);
                shapeList.Add(shape);
                //reset shapeOption
                shapeOption = -1;
            }
        }

        //ghi nhận thao tác di chuyển chuột
        private void ctrl_OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            //liên tục cập nhật pEnd trogn lúc di chuyển chuột
            pEnd = e.Location;

            //khi không vẽ hình nhưng vẫn nhấn và di chuyển chuột => biến đổi à
            if (shapeOption==-1)
            {

            }    
        }

        //vẽ các hình
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //vẽ các hình có trong danh sách
            for (int i = 0; i < shapeList.Count(); i++)
                shapeList[i].Draw(gl);
            if (choosingShape >= 0)
                shapeList[choosingShape].drawControlBox(gl);
            gl.Flush();
        }

        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the clear color.
            gl.ClearColor(1.0f, 1.0f, 1.0f, 1.0f);
            // Load the identity.
            gl.LoadIdentity();
        }

        private void openGLControl_Resized(object sender, EventArgs e)
        {
            // Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;
            // Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            // Load the identity.
            gl.LoadIdentity();
            // Create a perspective transformation.
            gl.Viewport(0, 0, openGLControl.Width, openGLControl.Height);
            gl.Ortho2D(0, openGLControl.Width, 0, openGLControl.Height);
            //Vẽ lại hình
            isShapeChange = true;
        }

        //***************************Khi click vào các button******************************************//

        //click button chọn vẽ đoạn thẳng
        private void bt_Line_Click(object sender, EventArgs e)
        {
            shapeOption = 0;
        }

        //click button chọn vẽ hình tròn
        private void bt_Circle_Click(object sender, EventArgs e)
        {
            shapeOption = 1;
        }

        //click button chọn vẽ hình chữ nhật
        private void bt_Rectangle_Click(object sender, EventArgs e)
        {
            shapeOption = 4;
        }

        //click button chọn vẽ hình ellipse
        private void bt_Ellipse_Click(object sender, EventArgs e)
        {
            shapeOption = 2;
        }

        //click button chọn vẽ tam giác đều
        private void bt_RegularTriangle_Click(object sender, EventArgs e)
        {
            shapeOption = 3;
        }

        //click button chọn vẽ ngũ giác đều
        private void bt_RegularPentagon_Click(object sender, EventArgs e)
        {
            shapeOption = 5;
        }

        //click button chọn vẽ lục giác đều
        private void bt_RegularHexagon_Click(object sender, EventArgs e)
        {
            shapeOption = 6;
        }

        //click vào chọn độ dày nét vẽ thì sẽ thay đổi giá trị thuộc tính line Width
        private void select_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = select_size.SelectedItem.ToString();
            pointWidth = float.Parse(selected);
        }

        //Click để xóa các hình đã thực hiện trên GL_Control
        private void bt_Clear_Click(object sender, EventArgs e)
        {
            shapeList.Clear();
            shapeOption = -1;
            choosingShape = -1;
        }

        //Click để thực hiện phép quay hình quanh tâm của hình
        private void bt_Rotate_Click(object sender, EventArgs e)
        {
            isRotate = true;
        }

        //click để thực hiện phép co giãn hình quanh tâm
        private void bt_Scale_Click(object sender, EventArgs e)
        {
            isScale = true;
        }

        private void bt_Move_Click(object sender, EventArgs e)
        {
            isMove = true;
        }

        //click button gọi hộp thoại màu và lưu kết quả của người dùng
        private void bt_BangMau_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                useColor = colorDialog1.Color;
        }
    }
}