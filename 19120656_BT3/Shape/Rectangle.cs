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
    //---------------------hình chữ nhật---------------------
    class Rectangle : Shape
    {
        public Rectangle(Point pStart, Point pEnd, Color color, float pointWidth) : base(pStart, pEnd, color, pointWidth)
        {

        }

        //vẽ hình chữ nhật thông qua vẽ 4 cạnh đoạn thẳng của hình
        public override void Draw(OpenGL gl)
        {
            Point pLeftBelow = new Point();
            Point pRightAbove = new Point();
            Point pLeftAbove = new Point();
            Point pRightBelow = new Point();

            pLeftBelow.X = Math.Min(pStart.X, pEnd.X);
            pLeftBelow.Y = Math.Min(pStart.Y, pEnd.Y);
            pLeftAbove.X = Math.Min(pStart.X, pEnd.X);
            pLeftAbove.Y = Math.Max(pStart.Y, pEnd.Y);
            pRightBelow.X = Math.Max(pStart.X, pEnd.X);
            pRightBelow.Y = Math.Min(pStart.Y, pEnd.Y);
            pRightAbove.X = Math.Max(pStart.X, pEnd.X);
            pRightAbove.Y = Math.Max(pStart.Y, pEnd.Y);

            Point pLeftMid = new Point((pLeftAbove.X + pLeftBelow.X) / 2, (pLeftAbove.Y + pLeftBelow.Y) / 2);
            Point pAboveMid = new Point((pLeftAbove.X + pRightAbove.X) / 2, (pLeftAbove.Y + pRightAbove.Y) / 2);
            Point pRightMid = new Point((pRightAbove.X + pRightBelow.X) / 2, (pRightAbove.Y + pRightBelow.Y) / 2);
            Point pBelowMid = new Point((pLeftAbove.X + pRightAbove.X) / 2, (pLeftAbove.Y + pRightAbove.Y) / 2);

            //lấy các điểm điều khiển theo chiều kim đồng hồ, bắt đầu từ đỉnh trái dưới
            controlPoints.Add(pLeftBelow);
            controlPoints.Add(pLeftMid);
            controlPoints.Add(pLeftAbove);
            controlPoints.Add(pAboveMid);
            controlPoints.Add(pRightAbove);
            controlPoints.Add(pRightMid);
            controlPoints.Add(pRightBelow);
            controlPoints.Add(pBelowMid);

            Line edgeLeft = new Line(pLeftBelow, pLeftAbove, useColor, pointWidth); //cạnh trái
            edgeLeft.Draw(gl);

            Line edgeRigth = new Line(pRightBelow, pRightAbove, useColor, pointWidth);    //cạnh phải
            edgeRigth.Draw(gl);

            Line edgeAbove = new Line(pLeftAbove, pRightAbove, useColor, pointWidth);    //cạnh trên
            edgeAbove.Draw(gl);

            Line edgeBelow = new Line(pLeftBelow, pRightBelow, useColor, pointWidth);    //cạnh dưới
            edgeBelow.Draw(gl);
        }

        //vẽ và nối các điểm điều khiển của hình chữ nhật
        public override void drawControlBox(OpenGL gl)
        {
            base.drawControlBox(gl);
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