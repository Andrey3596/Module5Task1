using WinFormsApp1.Objects;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        List<BaseObject> objects = new();
        Player player;
        Marker marker;
        GreenMarker greenMarker;


        RedMarker redMarkerOne;
        RedMarker redMarkerTwo;
        RedMarker redMarkerFree;
        int count = 0;
        //rnd.Next() % 3
        public Form1()
        {
            InitializeComponent();
            var rnd = new Random();


            objects.Add(new MyRectangle(50, 50, 0));
            objects.Add(new MyRectangle(100, 100, 45));



            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] Игрок пересекся с {obj}\n" + txtLog.Text;

                if (obj is RedMarker)
                {
                    RedMarker red = (RedMarker)obj;
                    red.X = (rnd.Next() % pbMain.Width);
                    red.Y = (rnd.Next() % pbMain.Height);
                    red.size = 12;
                    textCount.Text = (count - 1).ToString();
                    count--;
                }
                else if (obj is GreenMarker) {
                    objects.Remove(obj);
                    greenMarker = new GreenMarker((rnd.Next() % pbMain.Width), (rnd.Next() % pbMain.Height), 0);
                    objects.Add(greenMarker);
                    textCount.Text = (count + 1).ToString();
                    count++;
                }
            };
            objects.Add(player);



            marker = new Marker(pbMain.Width / 2 + 50, pbMain.Height / 2 + 50, 0);
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            objects.Add(marker);



            redMarkerOne = new RedMarker((rnd.Next() % pbMain.Width), (rnd.Next() % pbMain.Height), 0);
            redMarkerTwo = new RedMarker((rnd.Next() % pbMain.Width), (rnd.Next() % pbMain.Height), 0);
            redMarkerFree = new RedMarker((rnd.Next() % pbMain.Width), (rnd.Next() % pbMain.Height), 0);

            

            
            objects.Add(redMarkerOne);
            objects.Add(redMarkerTwo);
            objects.Add(redMarkerFree);

            greenMarker = new GreenMarker((rnd.Next() % pbMain.Width), (rnd.Next() % pbMain.Height), 0);
            
            objects.Add(greenMarker);



        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;

            g.Clear(Color.White);

            updatePlayer();

            foreach (var obj in objects.ToList())
            {
                if (obj != player && player.Overlaps(obj, g))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }

            // рендерим объекты
            foreach (var obj in objects)
            {
                g.Transform = obj.GetTransform();
                obj.Render(g);
            }

        }


        private void updatePlayer()
        {
            if (marker != null)
            {
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                float length = MathF.Sqrt(dx * dx + dy * dy);
                dx /= length;
                dy /= length;

                player.vX += dx * 0.5f;
                player.vY += dy * 0.5f;

                player.Angle = 90 - MathF.Atan2(player.vX, player.vY) * 180 / MathF.PI;
            }
            if (redMarkerOne != null)
            {
                redMarkerOne.size++;
            }
            if (redMarkerTwo!= null)
            {
                redMarkerTwo.size++;
            }
            if (redMarkerFree != null)
            {
                redMarkerFree.size++;
            }


            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // пересчет позиция игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //updatePlayer();

            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker); // и главное не забыть пололжить в objects
            }

            marker.X = e.X; 
            marker.Y = e.Y;
        }
    }
}
