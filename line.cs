using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

 internal class line:shape1
 {
    point w, e;
    screen screen1;

    public override point north() { return new point(e.x<w.x ? e.x+(w.x - e.x) / 2 : w.x + (e.x - w.x) / 2, e.y < w.y ? w.y : e.y); }
    public override point south() { return new point(e.x+(w.x-e.x)/2, e.y<w.y?e.y:w.y); } 

    public line(point a, point b, screen screen, string name)
    {
        if(ClassError.CheckPoints(new point[] { a, b }, screen1, name))
        { 
            addInDrawList = false;
        }
        w = a;
        e = b;
        screen1 = screen;
        detailName = name;
    }


    public line(point a, int L, screen screen, string name)
    {
        w = a;
        e = new point(a.x + L - 1, a.y);
        CheckPointsOnErrors(name);
        screen1 = screen;
        detailName = name;
        addShape.Invoke(this);
    }

    public void ChangePointsValues(point a, int L)
    {
        w = a;
        e = new point(a.x + L - 1, a.y);
        CheckPointsOnErrors(detailName);
    }

    private void CheckPointsOnErrors(string name)
    {
        if (ClassError.CheckParametersLine(w, e, name))
        {
            addInDrawList = false;
        }
    }

    public override void move(int a, int b)
    {
        w.x += a;
        w.y += b;
        e.x += a;
        e.y += b;

        if (ClassError.CheckPoints(new point[] { w, e }, screen1, detailName, "перемещении"))
        {
            addInDrawList = false;
        }
    }

    public override void draw()
    {
        if (addInDrawList == false) { return; }
        utility.put_line(w, e, screen1);
    }

    public override void resize(int d)
    { 
        e.x = w.x + (e.x - w.x) * d;
        e.y = w.y + (e.y - w.y) * d;

        if (ClassError.CheckPoints(new point[] { w, e }, screen1, detailName, "масштабировании"))
        {
            addInDrawList = false;
        }


    }

}

