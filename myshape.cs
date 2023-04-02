using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class myshape : rectangle
{
    int w, h;
    line l_eye;
    line r_eye;
    line mouth;

    public myshape(point a, point b, screen screen1, string detailName) : base(a, b, screen1, detailName)
    {
        addShape.Invoke(this);
        ChangeFace();
    }



    public override void draw()
    {
        base.draw();
        int a = (swest().x + neast().x)/ 2;
        int b = (swest().y + neast().y) / 2;
        screen1.put_point(a, b);
    }

    public override void move(int a, int b)
    {
        base.move(a, b);
        h = neast().y - swest().y + 1;
        w = neast().x - swest().x + 1;
        l_eye.ChangePointsValues(new point(swest().x + 2, swest().y + (h * 3 / 4)), 2);
        r_eye.ChangePointsValues(new point(swest().x + w - 4, swest().y + (h * 3 / 4)), 2);
        mouth.ChangePointsValues(new point(swest().x + 2, swest().y + h / 4), w - 4);
       
    }

    public override void resize(int size)
    {
        base.resize(size);
        l_eye.resize(size);
        r_eye.resize(size);
        mouth.resize(size);
    }


    public void ChangeFace()
    {
        h = neast().y - swest().y + 1;
        w = neast().x - swest().x + 1;
        l_eye = new line(new point(swest().x + 2, swest().y + (h * 3 / 4)), 2, screen1, "левый глаз");
        r_eye = new line(new point(swest().x + w - 4, swest().y + (h * 3 / 4)), 2, screen1, "правый глаз");
        mouth = new line(new point(swest().x + 2, swest().y + h / 4), w - 4, screen1, "рот");
    }



}

