using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Objects
{
    class RedMarker : BaseObject
    {
        public float xRed = -6;
        public float yRed = -6;
        public float hRed = 12;
        public float wRed = 12;

        public RedMarker(float x, float y, float angle) : base(x, y, angle)
        {

        }


        public override void Render(Graphics g)
        {
            
            g.FillEllipse(new SolidBrush(Color.Red), xRed, xRed, hRed, hRed);


        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(xRed, xRed, hRed, hRed);
            return path;
        }
    }
}