using System;
using System.Numerics;
using Raylib_cs;


public class MOVING
{
    
    public static Vector2 ReadMovement(float speed)
    {
        // en vector vars rikting bestäms av WASD. Med hastigenet som är floaten speed.
        Vector2 movement = new Vector2();
        if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y += speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y -= speed;

        return movement;
    }
}
