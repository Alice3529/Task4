using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;


  internal class main
  {
       static List<shape1> shapes = new List<shape1>();
       static myshape face;
       static rectangle hat;
       static line brim;
       static parallelogram feathers1, earOne, earTwo;

    static void Main(string[] args)
    {
        shape1.addShape += AddInDrawList;
        screen screen = new screen();

        CreateShapes(screen);
        ChangeShapes();
        PlaceShapes();

        screen.screen_init();
        shape_refresh();
        screen.screen_refresh();
    }

    private static void CreateShapes(screen screen)
    {
        face = new myshape(new point(15, 10), new point(27, 20), screen, "лицо");
        hat = new rectangle(new point(0, 0), new point(14, 5), screen, "шляпа");
        brim = new line(new point(0, 15), 17, screen, "поле шляпы");
        earOne= new parallelogram(new point(0, 0), new point(7, 4),6, screen, "ухо1");
        earTwo = new parallelogram(new point(0, 0), new point(7, 4), 6, screen, "ухо2");
        feathers1 = new parallelogram(new point(30, 10), new point(36, 15),10, screen, "перо низ");
    }

    private static void ChangeShapes()
    {
        brim.resize(2);
        face.resize(2);
        face.move(20, 5); 
        earTwo.flip_horisontally();
        feathers1.rotate_left();

    }

    private static void PlaceShapes()
    {
        utility.up(brim, face);
        utility.up(hat, brim);
        utility.upRight(hat, earOne);
        utility.upLeft(hat, earTwo);
        utility.down(face, feathers1);
    }

  
    public static void shape_refresh()
    {
        foreach (shape1 shape in shapes)
        {
            shape.draw();
        }
    }

    public static void AddInDrawList(shape1 shape)
    {
        if (shape.addInDrawList==false) { return; }
        shapes.Add(shape);
    }

 
}

