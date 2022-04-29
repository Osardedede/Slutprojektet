using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;


public class Buttons
{
    public static string Klick(string lvl, Rectangle r2)
    {
        // om musen håls över samt klickar på r2 rektangeln så byts det rum
        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

            if (Raylib.CheckCollisionPointRec(mousePos, r2))
            {
                lvl = "choosing";
            }
        }

        return (lvl);
    }

    public static (bool, bool) Klick2(bool startFightMenu, bool fightmode, Rectangle fightModeButton)
    {

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

            // om musen håls över samt klickar på fightModeButton rektangeln så ändrar boolsen värde.


            if (Raylib.CheckCollisionPointRec(mousePos, fightModeButton))
            {
                startFightMenu = false;
                fightmode = true;
            }
        }

        return (fightmode, startFightMenu);
    }
}
