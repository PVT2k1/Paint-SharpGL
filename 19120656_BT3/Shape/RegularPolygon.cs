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
    public class RegularPolygon : Shape
    {
        private int numVertices;
        public RegularPolygon(Point pStart, Point pEnd, Color color, float pointWidth, int numVertices) : base(pStart, pEnd, color, pointWidth)
        {
            this.numVertices = numVertices;
        }

        //vẽ các hình đa giác đều: tam giác đều, ngũ giác đều, lục giác đều
        public override void Draw(OpenGL gl)
        {
            var vertices = new Point[numVertices - 1];
            var radianBetweenVertex = 2 * Math.PI / (float)numVertices;

            controlPoints.Add(pEnd);

            //phép quay điểm pEnd quanh pStart 1 góc cố định để tạo ra các đỉnh còn lại của đa giác đều có tâm là pStart
            for (var i = 0; i < vertices.Length; ++i)
            {
                var theta = (i + 1) * radianBetweenVertex;
                var cos = Math.Cos(theta);
                var sin = Math.Sin(theta);

                //áp dụng phép biến đổi affine (trường hợp này là phép quay pEnd quanh pStart)
                vertices[i].X = (int)(cos * (float)pEnd.X - sin * (float)pEnd.Y - (float)pStart.X * cos + (float)pStart.Y * sin + (float)pStart.X);
                vertices[i].Y = (int)(sin * (float)pEnd.X + cos * (float)pEnd.Y - (float)pStart.X * sin - (float)pStart.Y * cos + (float)pStart.Y);
                controlPoints.Add(vertices[i]);
            }

            //nối các đỉnh lại với nhau
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                Line tmp = new Line(vertices[i], vertices[i + 1], useColor, pointWidth);
                tmp.Draw(gl);
            }

            Line tmp1 = new Line(pEnd, vertices[vertices.Length - 1], useColor, pointWidth);
            tmp1.Draw(gl);

            Line tmp2 = new Line(vertices[0], pEnd, useColor, pointWidth);
            tmp2.Draw(gl);
        }
    }
}