using System;
using System.Collections.Generic;
using Raylib_cs;

public class Drawing
{

    public static void DrawWalls(List<Rectangle> walls)
    {
        foreach (Rectangle wall in walls)
        {
            Raylib.DrawRectangleRec(wall, Color.BROWN);
        }
    }

}