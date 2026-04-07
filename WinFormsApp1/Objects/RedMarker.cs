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
       
        public float size = 12;
        //public event Action<RedMarker> OnPlayerTouch;
        public RedMarker(float x, float y, float angle) : base(x, y, angle)
        {

        }


        public override void Render(Graphics g)
        {
            
            g.FillEllipse(new SolidBrush(Color.Red), -(size / 2), -(size/2), size, size);


        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-(size / 2), -(size / 2), size, size);
            return path;
        }

        //public override void Overlap(BaseObject obj)
        //{
        //    base.Overlap(obj);

        //    // Если пересеклись с игроком  вызываем событие
        //    if (obj is Player)
        //    {
        //        OnPlayerTouch(this);
        //    }
        //}

    }
}