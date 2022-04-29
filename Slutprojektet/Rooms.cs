using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;


public class Rooms
{

    public static (string, Rectangle, PokemonElement) Room2(string lvl, Rectangle playerRect, PokemonElement startElement, Texture2D fire, Texture2D water, Texture2D grass)
    {


        if (lvl == "choosing")
        {

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);

            Raylib.DrawTexture(fire, 0, 0, Color.WHITE);
            Raylib.DrawTexture(grass, 333, 0, Color.WHITE);
            Raylib.DrawTexture(water, 666, 0, Color.WHITE);
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

            // Om jag klickar i ett visst område så blir min startElement än viss sak
            // Men spelet funkar bara om jag väljer water så därför har jag bara det alternativet
            // Så strukturen är där om jag hade vilat bygga vidare på spelet

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
            {
                if (mousePos.X > 0 && mousePos.X < 333)
                {
                    startElement = PokemonElement.water;
                    lvl = "huset";
                }
                if (mousePos.X > 333 && mousePos.X < 666)
                {
                    startElement = PokemonElement.water;
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
        return (lvl, playerRect, startElement);

    }
    public static (string, Rectangle) Room3(string lvl, Rectangle playerRect, List<Rectangle> walls, Texture2D playerImage, float speed, Texture2D background)
    {
        if (lvl == "huset")
        {
            speed = 5f;

            Raylib.BeginDrawing();
            Raylib.DrawTexture(background, 0, 0, Color.WHITE);

            // Jag skapar en vector som är = metoden ReadMovment(speed)
            Vector2 movement = MOVING.ReadMovement(speed);

            // Kod för att gå
            playerRect.x += movement.X;
            playerRect.y += movement.Y;


            // Koden under är för att kolla om jag har gått in i en av vägarna
            // ifrån listan walls. Om jag har gjort det så blir Undo boolsen
            // true och gör därefter så att jag inte kan fortsätta i den riktningen 
            // igenom koden: if (undoX) playerRect.x -= movement.X;

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
            if (undoX) playerRect.x -= movement.X;
            if (undoY) playerRect.y -= movement.Y;
            // Anropar metoden som ritar vägarna
            Drawing.DrawWalls(walls);


            Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);



            Raylib.EndDrawing();

            // kod för att kolla om jag går ut igenom dörren och därefter byter lvl
            if (playerRect.y + 50 > 800 && playerRect.x > 423 && playerRect.x < 639)
            {
                lvl = "ute";
                playerRect.x = 300;
                playerRect.y = 270;
            }

        }
        return (lvl, playerRect);
    }
    public static (string, Rectangle) Room4(string lvl, Rectangle playerRect, Texture2D playerImage2, float speed, Texture2D ute, Random generator)
    {
        if (lvl == "ute")
        {

            Raylib.BeginDrawing();
            Raylib.DrawTexture(ute, 0, 0, Color.WHITE);


            Raylib.DrawTexture(playerImage2, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

            Vector2 movement = MOVING.ReadMovement(speed);
            playerRect.x += movement.X;
            playerRect.y += movement.Y;


            // Här var det tänkt att det ska vara en timer på när du står i gräset en viss tid
            // Så ska du hamna i fighten
            // problemet är att du kan inte röra dig medans du står i gräset, samt den måste kunna räkna för att funka
            // Men då tänkte jag att det kan vara som att spelaren har gått i en fälla
            if (playerRect.x > 194 && playerRect.x < 250 && playerRect.y > 257 && playerRect.y < 280)
            {
                // Den har två floats där en konstant går ned
                float timerMaxValue = 2;
                float timerCurrentValue = timerMaxValue;



                bool timer = true;

                while (timer == true)
                {
                    playerRect.x = 269;
                    playerRect.y = 258;

                    Console.WriteLine(timerCurrentValue);
                    timerCurrentValue -= Raylib.GetFrameTime();

                    // Efter timern är under 0 så går den tillbaks till startvärdet och byter lvl
                    if (timerCurrentValue < 0)
                    {
                        timerCurrentValue = timerMaxValue;

                        lvl = "fight";
                        timer = false;
                    }
                }
            }




            // här är några andra sett som jag testade, For loopen
            //  hade samma problem som whilen att det frös men jag
            //  ville testa att göra en ricktig timer så valde while
            //  loopen

            // for (int i = 0; i < 501; i++)
            // {
            //     Console.WriteLine(i);
            //     if (i == 500)
            //     {
            //         lvl = "fight";
            //     }
            // }

            // int chans = generator.Next(10);

            // if (chans == 1)
            // {
            //     lvl = "fight";
            // }


            Raylib.EndDrawing();

        }
        return (lvl, playerRect);
    }

    public static string Room5(string lvl, Texture2D waterFight, Texture2D waterFight2, Random generator, bool fightmode, bool startFightMenu, PokemonElement startElement)
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

                    Raylib.DrawTexture(waterFight, 0, 0, Color.WHITE);
                    Rectangle fightModeButton = new Rectangle(498, 623, 234, 79);
                    // samma som knappen i start menyn så är det en metod för knappen. Som ger till baka två st bools.
                    (fightmode, startFightMenu) = Buttons.Klick2(startFightMenu, fightmode, fightModeButton);
                }


                Rectangle WaterBeam = new Rectangle(50, 655, 190, 40);
                Rectangle BubbleBeam = new Rectangle(250, 655, 190, 40);

                // Tills någon dör så är man fast i en while loop 
                while (fightmode == true)
                {
                    Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

                    Raylib.DrawTexture(waterFight2, 0, 0, Color.WHITE);
                    Raylib.DrawText("Water beam", 50, 665, 30, Color.RED);
                    Raylib.DrawText("Bubble beam", 250, 665, 30, Color.RED);
                    Raylib.DrawText($"{enemyHP}/50", 270, 150, 50, Color.RED);
                    Raylib.DrawText($"{MyHP}/50", 840, 507, 50, Color.RED);

                    // Om man kickar på en av knapparna så blir det en random dammage till motstondaren och dig.
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