using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;


public class Buttons
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

    public static (bool, bool) Klick2( bool startFightMenu, bool fightmode, Rectangle fightModeButton)
    {

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);


            if (Raylib.CheckCollisionPointRec(mousePos, fightModeButton))
            {
            startFightMenu = false;
            fightmode = true;
        }
        }

        return (fightmode, startFightMenu);
    }
}
