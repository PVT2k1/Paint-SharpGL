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

namespace _19120656_BT3.Affine
{
    public class AffineTransform
    {
        //Lớp "AffineTransform", định nghĩa các phép biến đổi Affine 2D (3x3)

        //Ma trận biến đổi Affine
        List<double> transformMatrix;

        public AffineTransform()
        {
            transformMatrix = new List<double> { 1, 0, 0, 0, 1, 0, 0, 0, 1 };
        }

        //Hàm nhân một ma trận khác với ma trận hiện hành
        public void Multiply(List<double> matrix)
        {
            List<double> resMatrix = new List<double> { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        resMatrix[i * 3 + j] += matrix[i * 3 + k] * transformMatrix[k * 3 + j];
            transformMatrix = resMatrix;
        }

        //phép tịnh tiến
        public void Translate(double dx, double dy)
        {
            List<double> transformMatrix = new List<double> { 1, 0, dx, 0, 1, dy, 0, 0, 1 };
            Multiply(transformMatrix);
        }

        //phép co giãn
        public void Scale(double sx, double sy)
        {
            List<double> transformMatrix = new List<double> { sx, 0, 0, 0, sy, 0, 0, 0, 1 };
            Multiply(transformMatrix);
        }

        //phép quay
        public void Rotate(double phi)
        {
            double cosPhi = Math.Cos(phi), sinPhi = Math.Sin(phi);
            List<double> rotateMatrix = new List<double> { cosPhi, -sinPhi, 0, sinPhi, cosPhi, 0, 0, 0, 1 };

            Multiply(rotateMatrix);
        }

        //áp dụng phép biến đổi lên một điểm (ở hàm này là p)
        public Point Transform(Point p)
        {
            List<double> srcPoint = new List<double> { p.X, p.Y, 1.0 };
            List<double> dstPoint = new List<double> { 0, 0, 0 };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    dstPoint[i] += transformMatrix[i * 3 + j] * srcPoint[j];
            Point res = new Point((int)(Math.Round(dstPoint[0])), (int)(Math.Round(srcPoint[1])));
            return res;
        }
    }
}