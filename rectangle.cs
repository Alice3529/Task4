using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    internal class rectangle: shape1, rotatable
{
        internal point sw=new point();
        internal point ne=new point();
        internal screen screen1;

        public rectangle(point a, point b, screen screen1, string detailName)
        {
            sw = a;
            ne = b;
            this.screen1 = screen1;
            this.detailName = detailName;
            addShape.Invoke(this);
        }


    public override point north() { return new point((ne.x + sw.x) / 2, ne.y); }
    public override point south() { return new point((ne.x + sw.x) / 2, sw.y); }
    public override point west() { return new point(sw.x, (ne.y + sw.y) / 2); }
    public override point east() { return new point(ne.x, (ne.y + sw.y) / 2); }
    public override point neast() { return ne; }
    public override point seast() { return new point(ne.x, sw.y); }
    public override point nwest() { return new point(sw.x, ne.y); }
    public override point swest() { return sw; }

    public override void draw()
    {
        utility.put_line(nwest(), ne, screen1);
        utility.put_line(ne, seast(), screen1);
        utility.put_line(seast(), swest(), screen1);
        utility.put_line(sw, nwest(), screen1);

    }

    public void rotate_right()
    {
        int w =ne.x-sw.x;
        int h=ne.y-sw.y;
        sw.x = ne.x;
        ne.x = ne.x + h*2;
        ne.y = sw.y + w/2-1;
      
    }
    public void rotate_left()
    {
        int w = ne.x - sw.x;
        int h = ne.y - sw.y;
        ne.x = sw.x - h;
        ne.y = sw.y + w-1;
       
    }


    public override void resize(int d)
    {
        ne.x = sw.x + (ne.x - sw.x) * d;
        ne.y = sw.y + (ne.y-sw.y) * d;
       
    }

    public override void move(int a, int b)
    {
        sw.x += a;
        sw.y += b;
        ne.x += a;
        ne.y += b;

       
    }

}

