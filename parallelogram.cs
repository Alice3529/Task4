using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


  internal class parallelogram: rectangle, reflectable, rotatable
  {
       int length;
       int h;
    

    public parallelogram(point a, point b, int length, screen screen1, string detailName=""):base(a, b, screen1, detailName)
    {
        length--;
        CheckPointsOnErrors(a, b, screen1, detailName);
        this.length = length;
        addShape.Invoke(this);
    }

 
    private void CheckPointsOnErrors(point a, point b, screen screen1, string detailName)
    {
        if (ClassError.CheckParameters(new point(a.x + 1, a.y + 1), b, detailName))
        {
            addInDrawList = false;
        }
        if (addInDrawList == true)
        {
            if (ClassError.CheckPoints(new point[] { a, b }, screen1, detailName))
            {
                addInDrawList = false;
            }
        }
    }

    public override void draw()
    {
        if (addInDrawList == false) { return; }

        if (ClassError.CheckPoints(new point[] {nwest()}, screen1, detailName))
        {
            addInDrawList = false;
        }

        if (addInDrawList == false) { return; }


        utility.put_line(swest(), seast(), screen1);
        utility.put_line(swest(), nwest(), screen1);
        utility.put_line(nwest(), neast(), screen1);
        utility.put_line(neast(), seast(), screen1);
        utility.put_line(west(), east(), screen1);

        utility.put_line(neast(), seast(), screen1);
        utility.put_line(west(), east(), screen1);
        int centerX = (east().x + west().x) / 2;
        int centerY = (east().y + west().y) / 2;
        h = (nwest().y - swest().y) / 2;
        utility.put_line(new point(centerX, west().y - h), new point(centerX, west().y + h), screen1);

    }


    public override point north() { return new point(ne.x -(length / 2), ne.y); }
    public override point south() { return new point((sw.x +length) / 2, sw.y); }
    public override point east() { return new point((ne.x + seast().x) / 2, (ne.y + seast().y) / 2); }
    public override point west() { return new point((sw.x+nwest().x)/2, (nwest().y + sw.y) / 2); }
    public override point neast() { return ne; }
    public override point seast() { return new point(rotatable==false? sw.x+length : ne.x, !rotatable ? sw.y : ne.y-length/2); }
    public override point nwest() {  return new point(rotatable==false? ne.x-length : sw.x, !rotatable ? ne.y:sw.y+length/2);  }
    public override point swest() { return sw; }

    public override void move(int x, int y)
    {
        sw.x += x;
        sw.y += y;
        ne.x += x;
        ne.y += y;

        if (ClassError.CheckPoints(new point[] { sw, ne }, screen1, detailName, "перемещении"))
        {
            addInDrawList = false;
        }

    }

    public void rotate_left()
    {
        if (ClassError.CheckWasRotated(rotatable, detailName)) { return; }
        int diagonalX = Math.Abs(neast().x - swest().x);
        int diagonalY = Math.Abs(neast().y - swest().y);
        rotatable = true;
        ne = new point(swest().x, swest().y + length/2);
        sw = new point(swest().x-diagonalY*2, swest().y - diagonalX/2+length/2);

        if (ClassError.CheckPoints(new point[] { sw, ne, nwest(), seast() }, screen1, detailName, "повороте"))
        {
            addInDrawList = false;
        }
    }

    public void rotate_right()
    {
        if (ClassError.CheckWasRotated(rotatable, detailName)) { return; }
        int diagonalX = Math.Abs(nwest().x - seast().x) / 2;
        int diagonalY = Math.Abs(nwest().y - seast().y) * 2;
        rotatable = true;
        sw = seast();
        ne = new point(sw.x + diagonalY, sw.y+diagonalX);

        if (ClassError.CheckPoints(new point[] { sw, ne, nwest(), seast() }, screen1, detailName, "повороте"))
        {
            addInDrawList = false;
        }
    }

    public void flip_horisontally()
    {
        if (ClassError.CheckWasReflected(reflectable, detailName)) { return; }
        sw.x = seast().x - (seast().x - swest().x);
        ne.x = nwest().x;
        reflectable = true;
        if (ClassError.CheckPoints(new point[] { sw, ne }, screen1, detailName, "отражении"))
        {
            addInDrawList = false;
        }
    }

    public void flip_vertically()
    {
        if (ClassError.CheckWasReflected(reflectable, detailName)) { return; }
        ne.y -= 4* h;
        reflectable = true;
        if (ClassError.CheckPoints(new point[] { sw, ne }, screen1, detailName, "отражении"))
        {
            addInDrawList = false;
        }
    }
}

