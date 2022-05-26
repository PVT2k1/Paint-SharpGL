using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19120656_BT3.Shape
{
    //---------------------hình ellipse---------------------
    public class Ellipse : Shape
    {
        public Ellipse(Point pStart, Point pEnd, Color color, float pointWidth) : base(pStart, pEnd, color, pointWidth)
        {

        }

        //lấy 4 điểm đối xứng thông qua trục lớn và trục bé đi qua tâm
        public void draw4Point(OpenGL gl, Point center, int x, int y)
        {
            gl.PointSize(pointWidth);
            gl.Color(useColor.R / 255.0, useColor.G / 255.0, useColor.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(center.X + x, center.Y + y);
            gl.Vertex(center.X + x, center.Y - y);
            gl.Vertex(center.X - x, center.Y - y);
            gl.Vertex(center.X - x, center.Y + y);
            gl.End();
        }

        //vẽ hình ellipse bằng thuật toán Bresenham
        public override void Draw(OpenGL gl)
        {
            base.Draw(gl);

            //----------tìm tâm, bán kính trục theo chiều Ox và bán kính trục theo chiều Oy----------
            Point center = new Point();
            center.X = (pStart.X + pEnd.X) / 2;
            center.Y = (pStart.Y + pEnd.Y) / 2;

            int a = 0, b = 0;
            a = Math.Abs(center.X - pStart.X);
            b = Math.Abs(center.Y - pStart.Y);

            //lấy các điểm điều khiển theo chiều kim đồng hồ, bắt đầu từ đỉnh trái dưới
            controlPoints.Add(new Point(center.X - a, center.Y - b));
            controlPoints.Add(new Point(center.X - a, center.Y));
            controlPoints.Add(new Point(center.X - a, center.Y + b));
            controlPoints.Add(new Point(center.X, center.Y + b));
            controlPoints.Add(new Point(center.X + a, center.Y + b));
            controlPoints.Add(new Point(center.X + a, center.Y));
            controlPoints.Add(new Point(center.X + a, center.Y - b));
            controlPoints.Add(new Point(center.X, center.Y - b));

            //--------------------------------BẮT ĐẦU VẼ Ở VÙNG 1 (VÙNG TRÊN)--------------------------------
            int x = 0, y = b;

            // x0 là hoành độ của điểm nằm ở ellipse, điểm chia ra vùng 1 và vùng 2 
            float x0 = (float)a * (float)a / (float)Math.Sqrt(a * a + b * b);
            float P = (float)(a * a * (1 - 2 * b) + b * b);     //thông số cơ bản khi dùng thuật toán này
            draw4Point(gl, center, x, y);

            while (x <= x0)
            {
                if (P < 0)
                    P += (2 * b * b) * (2 * x + 3);
                else
                {
                    P += (2 * b * b) * (2 * x + 3) + 4 * a * a * (1 - y);
                    y--;
                }
                x++;
                draw4Point(gl, center, x, y);
            }

            //--------------------------------BẮT ĐẦU VẼ Ở VÙNG 2 (VÙNG DƯỚI)--------------------------------
            x = a;
            y = 0;

            P = b * b * (1 - 2 * a) + a * a;
            draw4Point(gl, center, x, y);
            while (x > x0)
            {
                if (P < 0)
                    P += (2 * a * a) * (2 * y + 3);
                else
                {
                    P += (2 * a * a) * (2 * y + 3) + 4 * b * b * (1 - x);

                    x--;
                }
                y++;
                draw4Point(gl, center, x, y);
            }
        }

        //vẽ và nối các điểm điều khiển của hình chữ nhật
        public override void drawControlBox(OpenGL gl)
        {
            base.drawControlBox(gl);
            //vẽ các đường của Control Box trước, chưa thể hiện rõ các điểm điều khiển
            for (int i = 0; i < controlPoints.Count() - 1; i++)
            {
                Line tmp1 = new Line(controlPoints[i], controlPoints[i + 1], Color.White, (float)1.0);
                tmp1.Draw(gl);
            }
            Line tmp2 = new Line(controlPoints[controlPoints.Count() - 1], controlPoints[0], Color.White, (float)1.0);
            tmp2.Draw(gl);

            //thể hiện rõ các điểm điều khiển
            gl.PointSize((float)10.0);
            gl.Color(Color.White.R / 255.0, Color.White.G / 255.0, Color.White.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i < controlPoints.Count(); i++)
                gl.Vertex(controlPoints[i].X, controlPoints[i].Y);
            gl.End();
        }
    }
}
