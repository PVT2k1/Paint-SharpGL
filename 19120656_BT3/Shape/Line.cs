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
    //---------------------đoạn thẳng---------------------
    public class Line : Shape
    {
        public Line(Point pStart, Point pEnd, Color color, float pointWidth) : base(pStart, pEnd, color, pointWidth)
        {
           
        }

        //vẽ đoạn thẳng theo chiều của x từ nhỏ đến lớn
        public override void Draw(OpenGL gl)
        {
            gl.PointSize(pointWidth);
            gl.Color(useColor.R / 255.0, useColor.G / 255.0, useColor.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);

            if (pStart.X > pEnd.X)
            {
                Point tmp = pStart;
                pStart = pEnd;
                pEnd = tmp;
            }

            //đoạn thẳng thì điểm điều khiển là 2 đầu mút
            controlPoints.Add(pStart);
            controlPoints.Add(pEnd);

            int x1 = pStart.X, y1 = pStart.Y,
                x2 = pEnd.X, y2 = pEnd.Y;
            int Dx = Math.Abs(x2 - x1), Dy = Math.Abs(y2 - y1);
            gl.Vertex(x1, y1);

            //tính bước nhảy để biết điểm sau là điểm nào trong lân cận của điểm trước
            int x_step = 1, y_step = 1;
            if (y2 < y1)
                y_step = -1;

            // trường hợp là 1 đoạn thẳng song song Oy, vuông góc Ox
            if (x1 == x2)
                while (y1 != y2)
                {
                    y1 += y_step;
                    gl.Vertex(x1, y1);
                }

            // trường hợp là 1 đoạn thẳng song song Ox, vuông góc Oy
            else if (y1 == y2)
                while (x1 != x2)
                {
                    x1 += x_step;
                    gl.Vertex(x1, y1);
                }

            //trường hợp là đoạn thẳng xiên
            else
            {   //hệ số góc m thuộc khoảng: [-1,0) U (0,1]
                if (Dy <= Dx)
                {
                    int p = 2 * Dy - Dx;
                    while (x1 < x2)
                    {
                        if (p < 0)
                        {
                            p = p + 2 * Dy;
                            x1 += x_step;
                        }
                        else
                        {
                            p = p + 2 * Dy - 2 * Dx;
                            x1 += x_step;
                            y1 += y_step;
                        }
                        gl.Vertex(x1, y1);
                    }
                }

                else
                {
                    int p = 2 * Dx - Dy;
                    while (x1 < x2)
                    {
                        if (p < 0)
                        {
                            p = p + 2 * Dx;
                            y1 += y_step;
                        }
                        else
                        {
                            p = p + 2 * Dx - 2 * Dy;
                            y1 += y_step;
                            x1 += x_step;
                        }
                        gl.Vertex(x1, y1);
                    }
                }
            }
            gl.End();
        }

        //lấy 2 điểm điều khiển đầu mút của đoạn thẳng
        public override void drawControlBox(OpenGL gl)
        {
            base.drawControlBox(gl);
            gl.PointSize((float)10.0);
            gl.Color(Color.White.R / 255.0, Color.White.G / 255.0, Color.White.B / 255.0, 0);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i < controlPoints.Count(); i++)
                gl.Vertex(controlPoints[i].X, controlPoints[i].Y);
            gl.End();
        }

        public override void translate(OpenGL gl, double tx, double ty)
        {
            Affine.AffineTransform affineMatrix = new Affine.AffineTransform();
            affineMatrix.Translate(tx, ty);
            affineMatrix.Transform(pStart);
            affineMatrix.Transform(pEnd);
        }

    }
}