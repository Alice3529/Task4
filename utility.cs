using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class utility
{
        public static void put_line(point first, point second, screen screen1)
        {
            int x0 = first.x;
            int x1 = second.x;
            int y0 = first.y;
            int y1 = second.y;

            int a = x1 - x0;
            int b = y1 - y0;
            int dx = 1;
            int dy = 1;
        

            if (a < 0)
            {
                dx = -1;
                a = -a;
            }
            if (b < 0)
            {
                dy = -1;
                b = -b;
            }

            int two_a = 2 * a;
            int two_b = 2 * b;
            int xCrit = -b + two_a;
            int eps = 0;

            while (true)
            {
                screen1.put_point(x0, y0);
                if (x0 == x1 && y0 == y1) { break; };
                if (eps <= xCrit)
                {
                    x0 += dx;
                    eps += two_b;
                }
                if (eps >= a || a < b)
                {
                    y0 += dy;
                    eps -= two_a;
                }
            }

        }

        public static void up(shape1 above, shape1 under)
        {
            if (above.addInDrawList==false || under.addInDrawList == false) { return; }
            point n = under.north();
            point s = above.south();
            above.move(n.x - s.x, n.y - s.y + 1);
        }

        public static void down(shape1 above, shape1 under)
        {
            if (above.addInDrawList == false || under.addInDrawList == false) { return; }
            point n = above.south();
            point s = under.north();
            under.move(n.x-s.x, n.y - s.y - 1);
        }

        public static void upRight(shape1 above, shape1 under)
        {
           if (above.addInDrawList == false || under.addInDrawList == false) { return; }
           point n = above.neast();
           point s = under.seast();
           under.move(n.x - s.x, n.y - s.y );
        }

        public static void upLeft(shape1 above, shape1 under)
        {
        if (above.addInDrawList == false || under.addInDrawList == false) { return; }
        point n = above.nwest();
        point s = under.swest();
        under.move(n.x - s.x, n.y - s.y);
        }



}

