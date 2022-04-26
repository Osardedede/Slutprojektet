using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;


public class buttons
{
    public static string Klick(Vector2 mousePos, string lvl, Rectangle r2)
    {
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (Raylib.CheckCollisionPointRec(mousePos, r2))
            {
                lvl = "choosing";
            }
        }

        return (lvl);
    }

    public static (bool, bool) Klick2(Vector2 mousePos, bool startFightMenu, bool fightmode, Rectangle fightModeButton)
    {

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {

            if (Raylib.CheckCollisionPointRec(mousePos, fightModeButton))
            {

            System.Console.WriteLine("hej");
            startFightMenu = false;
            fightmode = true;
        }
        }

        return (fightmode, startFightMenu);
    }
}
