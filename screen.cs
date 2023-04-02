using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


    internal class screen
    {
        const int XMAX = 119;
        const int YMAX = 50;


       enum color { black = '*', white = '.' }

       public char[,] screen1 = new char[XMAX, YMAX];

       public void screen_clear()
       {
           screen_init();
       }

       public void screen_refresh()
       {
         for (int row = YMAX - 1; row >= 0; row--)
        {
            Console.Write("\r\n");

            for (int column = 0; column < XMAX; column++)
            {
                Console.Write(screen1[column, row]);
            }
        }
       }

    public void screen_destroy()
    {
        for (int row = YMAX - 1; row >= 0; row--)
        {
            for (int column = 0; column < XMAX; column++)
            {
                screen1[row, column] = (char)color.black ;
            }
        }
    }

    internal void screen_init()
    {
        for (int column = 0; column < XMAX; column++)
        {
            for (int row = 0; row < YMAX; row++)
            {
                screen1[column, row] = (char)color.white;
            }
        }
    }

    internal static bool on_screen(int a, int b)
    {
        return 0 <= a && 0 <= b && a < XMAX && b < YMAX;
    }

    internal void put_point(int a, int b) 
    {
        screen1[a, b] = '*';
    }

    public int GetWidth()
    {
        return XMAX;
    }

    public int GetHeight()
    {
        return YMAX;
    }

}

