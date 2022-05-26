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
    //---------------------hình học---------------------
    public class Shape
    {
        protected Color useColor; //màu vẽ điểm lên pixel
        protected float pointWidth;   //size của điểm được vẽ
        protected Point pStart;
        protected Point pEnd;
        protected List<Point> controlPoints;  //tập các điểm điều khiển của hình

        public Shape(Point pStart, Point pEnd, Color useColor, float pointWidth)
        {
            this.pStart = pStart;
            this.pEnd = pEnd;
            this.useColor = useColor;
            this.pointWidth = pointWidth;
            controlPoints = new List<Point>();
        }

        public List<Point> getControlPoint()
        {
            return controlPoints;
        }

        //hàm thực hiện vẽ đối tượng hình học
        public virtual void Draw(OpenGL gl) { }

        //hàm vẽ hộp điểm điều khiển khi click chọn hình
        public virtual void drawControlBox(OpenGL gl) { }

        //hàm thực hiện phép tịnh tiến hình theo 2 giá trị tx, ty
        public virtual void translate(OpenGL gl, double tx, double ty) { }

        //hàm thực hiện phép co giãn theo 2 giá trị tx, ty
        public virtual void Scale(OpenGL gl, double sx, double sy) { }
    }
}