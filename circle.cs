using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  internal class circle: rectangle, reflectable
  {
       bool reflected;
       int radius;
       point center;


       public circle(point a, point b, screen screen1, string detailName) : base(a, b, screen1, detailName)
       {
       }


       public override point north() { return center; }
       public override point south() { return new point(center.x - radius, center.y - radius); }

       public override void draw()
       {
          if (addInDrawList==false) { return; }
          int x = radius, y = 0;
          int D = 2 * (1 - radius);
 
          while (x >= 0)
          {
            if (reflected==true)
            {
                screen1.put_point(center.x - x, center.y + y/2);
                screen1.put_point(center.x + x, center.y + y/2);
            }
            else
            {
                screen1.put_point(center.x - x, center.y - y/2);
                screen1.put_point(center.x + x, center.y - y/2);
            }



            if (D < 0 && 2 * D + 2 * x - 1 <= 0)
            {
                ++y;
                D += 2 * y + 1;
            }
            else if (D > 0 && 2 * D - 2 * y - 1 >= 0)
            {
                --x;
                D -= 2 * x - 1;
            }
            else
            {
                x--; ++y;
                D += 2 * y - 2 * x + 2;
            }
        }
    }

    public override void move(int x, int y)
    {
        sw.x += x;
        sw.y += y;
        ne.x += x;
        ne.y += y;
        center = new point((swest().x + neast().x) / 2, west().y);
        radius = (neast().x - nwest().x) / 2;

    }

    public void flip_horisontally()
    {
    }

    public void flip_vertically()
    {
        reflected = !reflected;
        reflectable = true;
    }

    public override void resize(int d)
    {
        radius *= d;
        sw.x = center.x - radius;
        ne.x = center.x + radius;
    }
}

