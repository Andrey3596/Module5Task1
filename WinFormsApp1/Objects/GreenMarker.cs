using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Objects
{
    class GreenMarker : BaseObject
    {
        public GreenMarker(float x, float y, float angle) : base(x, y, angle)
        {

        }


        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), -12, -12, 24, 24);


            g.DrawEllipse(new Pen(Color.Green, 2), -12, -12, 24, 24);

        }


        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-12, -12, 24, 24);
            return path;
        }
    }
}
