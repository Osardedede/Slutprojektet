using System;
using System.Collections.Generic;
using Raylib_cs;

public class Drawing
{

    public static void DrawWalls(List<Rectangle> walls)
    {

        // för varje rektangel som jag har lagt till i listan så ska den rita den rektangeln i brun färg. Detta kan vara för att kunna se dom när du testar  spelet
        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.BROWN);
        }
    }

}