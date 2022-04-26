using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;


public class Rooms
{

    public static (string, Rectangle) Room2(string lvl, Rectangle playerRect, PokemonElement startElement, Texture2D fire, Texture2D water, Texture2D grass)
    {


        if (lvl == "choosing")
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            Raylib.DrawTexture(fire, 0, 0, Color.WHITE);
            Raylib.DrawTexture(grass, 333, 0, Color.WHITE);
            Raylib.DrawTexture(water, 666, 0, Color.WHITE);
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if (mousePos.X > 0 && mousePos.X < 333)
                {
                    startElement = PokemonElement.fire;
                    lvl = "huset";
                }
                if (mousePos.X > 333 && mousePos.X < 666)
                {
                    startElement = PokemonElement.grass;
                    lvl = "huset";


                }
                if (mousePos.X > 666 && mousePos.X < 1000)
                {
                    startElement = PokemonElement.water;
                    lvl = "huset";

                }
            }


            Raylib.EndDrawing();
        }
        return (lvl, playerRect);

    }
    public static (string, Rectangle) Room3(string lvl, Rectangle playerRect, List<Rectangle> walls, Texture2D playerImage, float speed, Texture2D background)
    {
        if (lvl == "huset")
        {
            speed = 5f;

            Raylib.BeginDrawing();
            Raylib.DrawTexture(background, 0, 0, Color.WHITE);


            Vector2 movement = MOVING.ReadMovement(speed);
            playerRect.x += movement.X;
            playerRect.y += movement.Y;

            bool undoX = false;
            bool undoY = false;
            foreach (Rectangle wall in walls)
            {
                if (Raylib.CheckCollisionRecs(playerRect, wall) == true)
                {
                    undoX = true;
                    undoY = true;
                }
            }


            Drawing.DrawWalls(walls);

            walls.Add(new Rectangle(0, 498, 281, 126));

            Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);


            if (undoX) playerRect.x -= movement.X;
            if (undoY) playerRect.y -= movement.Y;

            Raylib.EndDrawing();


            if (playerRect.y + 50 > 800)
            {
                lvl = "ute";
                playerRect.x = 300;
                playerRect.y = 270;
            }

        }
        return (lvl, playerRect);
    }
    public static (string, Rectangle) Room4(string lvl, Rectangle playerRect, List<Rectangle> walls2, Texture2D playerImage2, float speed, Texture2D ute, Random generator)
    {
        if (lvl == "ute")
        {

            Raylib.BeginDrawing();
            Raylib.DrawTexture(ute, 0, 0, Color.WHITE);


            Raylib.DrawTexture(playerImage2, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

            Vector2 movement = MOVING.ReadMovement(speed);
            playerRect.x += movement.X;
            playerRect.y += movement.Y;

            bool undoX = false;
            bool undoY = false;

            foreach (Rectangle wall2 in walls2)
            {
                if (Raylib.CheckCollisionRecs(playerRect, wall2) == true)
                {
                    undoX = true;
                    undoY = true;
                }
            }

            // walls2.Add(new Rectangle(0, 0, 281, 126));
            // Drawing.DrawWalls(walls);


            if (undoX) playerRect.x -= movement.X;
            if (undoY) playerRect.x -= movement.Y;

            if (playerRect.x > 194 && playerRect.x < 268 && playerRect.y < 292 && playerRect.y > 257)
            {

                int chans = generator.Next(10);

                if (chans == 1)
                {
                    lvl = "fight";
                }
            }


            Raylib.EndDrawing();

        }
        return (lvl, playerRect);
    }

    public static string Room5(string lvl, Texture2D waterFight, Texture2D waterFight2, Random generator, bool fightmode, bool startFightMenu, Vector2 mousePos, PokemonElement startElement)
    {
        if (lvl == "fight")
        {
            int enemyHP = 50;
            int MyHP = 50;
            Raylib.BeginDrawing();
            if (startElement == PokemonElement.water)
            {
                if (startFightMenu == true)
                {

                    Rectangle fightModeButton = new Rectangle(498, 623, 234, 79);
                    Raylib.DrawTexture(waterFight, 0, 0, Color.WHITE);

                    (fightmode, startFightMenu) = buttons.Klick2(mousePos, startFightMenu, fightmode, fightModeButton);
                }


                Rectangle WaterBeam = new Rectangle(50, 655, 190, 40);
                Rectangle BubbleBeam = new Rectangle(250, 655, 190, 40);

                while (fightmode == true)
                {
                    Raylib.DrawTexture(waterFight2, 0, 0, Color.WHITE);
                    Raylib.DrawText("Water beam", 50, 665, 30, Color.RED);
                    Raylib.DrawText("Bubble beam", 250, 665, 30, Color.RED);
                    Raylib.DrawText($"{enemyHP}/50", 270, 150, 50, Color.RED);
                    Raylib.DrawText($"{MyHP}/50", 840, 507, 50, Color.RED);
                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                    {
                        if (Raylib.CheckCollisionPointRec(mousePos, WaterBeam))
                        {
                            enemyHP -= 20;
                            int damage = generator.Next(10, 30);
                            MyHP -= damage;
                        }
                        if (Raylib.CheckCollisionPointRec(mousePos, BubbleBeam))
                        {
                            enemyHP -= 30;
                            int damage = generator.Next(20, 35);
                            MyHP -= damage;
                        }
                    }
                    if (MyHP < 0 || MyHP == 0)
                    {
                        Raylib.DrawText("YOU LOSE", 250, 665, 30, Color.RED);
                        fightmode = false;
                        lvl = "ute";


                    }
                    if (enemyHP < 0 || enemyHP == 0)
                    {
                        Raylib.DrawText("YOU WIN", 250, 665, 30, Color.RED);
                        fightmode = false;
                        lvl = "ute";


                    }
                    Raylib.EndDrawing();
                }
                Raylib.EndDrawing();

            }
        }
        return (lvl);
    }

}