using System;

using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1000, 800, "Dokemon");

Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("Gubbar1.png");
Texture2D playerImage2 = Raylib.LoadTexture("frontgubbe.png");
Texture2D background = Raylib.LoadTexture("Hus1.png");
Texture2D ute = Raylib.LoadTexture("ute.png");
Texture2D waterFight = Raylib.LoadTexture("battle.png");
Texture2D intro = Raylib.LoadTexture("MenyBild.png");
Texture2D fire = Raylib.LoadTexture("chimchar.png");
Texture2D water = Raylib.LoadTexture("piplup.png");
Texture2D grass = Raylib.LoadTexture("turtwig.png");


float speed = 4f;
string lvl = "meny";
bool Meny = true;
bool Choosing = false;
bool firestart = false;
bool grassstart = false;
bool waterstart = false;
bool moving = false;






Rectangle playerRect = new Rectangle(100, 100, playerImage.width, playerImage.height);
Rectangle r2 = new Rectangle(380, 300, 150, 100);





while (!Raylib.WindowShouldClose())
{

    if (lvl == "meny")
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(intro, 0, 0, Color.WHITE);
        // Raylib.DrawRectangleRec(r2,Color.BLACK);

        Raylib.DrawText("Dokemon", 325, 200, 100, Color.RED);
        Raylib.DrawText("start", 380, 300, 50, Color.RED);
        Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);

        if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            if (mousePos.X > r2.x && mousePos.X < r2.x + r2.width && mousePos.Y > r2.y && mousePos.Y < r2.y + r2.height)
            {
                lvl = "choosing";
            }
        }



        Raylib.EndDrawing();
    }

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
                firestart = true;
                lvl = "huset";
                moving = true;

            }
            if (mousePos.X > 333 && mousePos.X < 666)
            {
                grassstart = true;
                lvl = "huset";
                moving = true;


            }
            if (mousePos.X > 666 && mousePos.X < 1000)
            {
                waterstart = true;
                lvl = "huset";
                moving = true;

            }
        }


        Raylib.EndDrawing();
    }

    if (lvl == "huset")
    {

        Raylib.BeginDrawing();
        Raylib.DrawTexture(background, 0, 0, Color.WHITE);


        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        if (moving == true)
        {
            Vector2 movement = ReadMovement(speed);
            playerRect.x += movement.X;
            playerRect.y += movement.Y;
        }

        Raylib.EndDrawing();


        if (playerRect.y + 50 > 800)
        {
            lvl = "ute";
            playerRect.x = 300;
            playerRect.y = 270;
        }

    }

    if (lvl == "ute")
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(ute, 0, 0, Color.WHITE);


        Raylib.DrawTexture(playerImage2, (int)playerRect.x, (int)playerRect.y, Color.WHITE);

        if (moving == true)
        {
            Vector2 movement = ReadMovement(speed);
            playerRect.x += movement.X;
            playerRect.y += movement.Y;
        }

        if (playerRect.x > 54.9 && playerRect.x < 130 && playerRect.y < 139 && playerRect.y > 105)
        {

            Random generator = new Random();
            int chans = generator.Next(10);

            if (chans == 1)
            {
                lvl = "fight";
            }
        }

        Raylib.EndDrawing();

    }

    if (lvl == "fight")
    {
        if (waterstart == true)
        {
            Raylib.BeginDrawing();

            Raylib.DrawTexture(waterFight, 0, 0, Color.WHITE);
            Raylib.EndDrawing();
            Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);


            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON)
            {

            }

        }
    }
}



static Vector2 ReadMovement(float speed)
{
    Vector2 movement = new Vector2();
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) movement.Y += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) movement.X += speed;

    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) movement.X -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) movement.Y -= speed;

    return movement;
}

// Get the position of the mouse



