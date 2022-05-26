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
    //---------------------hình tròn---------------------
    public class Circle : Shape
    {
        public Circle(Point pStart, Point pEnd, Color color, float pointWidth) : base(pStart, pEnd, color, pointWidth)
        {

        }

        //vẽ 8 điểm đối xứng qua 2 trục tọa độ và 2 đường y=x, y=-x trong thuật toán Bresenham
        public void draw8Point(OpenGL gl, Point center, int x, int y)
        {
            gl.PointSize(pointWidth);
            gl.Color(useColor.R / 255.0, useColor.G / 255.0, useColor.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(center.X + x, center.Y + y);
            gl.Vertex(center.X + y, center.Y + x);
            gl.Vertex(center.X + y, center.Y - x);
            gl.Vertex(center.X + x, center.Y - y);
            gl.Vertex(center.X - x, center.Y - y);
            gl.Vertex(center.X - y, center.Y - x);
            gl.Vertex(center.X - y, center.Y + x);
            gl.Vertex(center.X - x, center.Y + y);
            gl.End();
        }

        //vẽ hình tròn sử dụng thuật toán Bresenham
        public override void Draw(OpenGL gl)
        {
            //tìm tâm và bán kinh của đường tròn
            int R = (int)Math.Sqrt(Math.Pow(pEnd.X - pStart.X, 2) + Math.Pow(pEnd.Y - pStart.Y, 2)) / 2;
            Point center = new Point();
            center.X = (pStart.X + pEnd.X) / 2;
            center.Y = (pStart.Y + pEnd.Y) / 2;
            base.Draw(gl);

            //các thông số cơ bản khi dùng thuật toán này
            int p = 3 - 2 * R;
            int x = 0, y = R;

            //lấy các điểm điều khiển theo chiều kim đồng hồ, bắt đầu từ đỉnh trái dưới
            controlPoints.Add(new Point(center.X - R, center.Y - R));
            controlPoints.Add(new Point(center.X - R, center.Y));
            controlPoints.Add(new Point(center.X - R, center.Y + R));
            controlPoints.Add(new Point(center.X, center.Y + R));
            controlPoints.Add(new Point(center.X + R, center.Y + R));
            controlPoints.Add(new Point(center.X + R, center.Y));
            controlPoints.Add(new Point(center.X + R, center.Y - R));
            controlPoints.Add(new Point(center.X, center.Y - R));

            //vẽ trước 8 điểm đối xứng như đã nói ở trên, trong đó có 1 điểm tọa độ (0,R)
            draw8Point(gl, center, x, y);

            while (x < y)
            {
                if (p < 0)
                    p += 4 * x + 6;
                else
                {
                    p += 4 * (x - y) + 10;
                    y -= 1;
                }
                x += 1;
                draw8Point(gl, center, x, y);
            }
        }

        //vẽ và nối các điểm điều khiển của ellipse
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
