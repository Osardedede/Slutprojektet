using System;

using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

Raylib.InitWindow(1000, 800, "Pokemon");

Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("Gubbar1.png");
Texture2D playerImage2 = Raylib.LoadTexture("frontgubbe.png");
Texture2D ute = Raylib.LoadTexture("ute.png");
Texture2D waterFight = Raylib.LoadTexture("battle.png");
Texture2D waterFight2 = Raylib.LoadTexture("fightmode.png");
Texture2D intro = Raylib.LoadTexture("MenyBild.png");


float speed = 4f;
string lvl = "meny";

PokemonElement startElement = PokemonElement.fire;


bool startFightMenu = true;
bool fightmode = false;

Random generator = new Random();



List<Rectangle> walls = new List<Rectangle>();
List<Rectangle> walls2 = new List<Rectangle>();


Rectangle playerRect = new Rectangle(100, 100, playerImage.width, playerImage.height);
Rectangle r2 = new Rectangle(380, 300, 150, 100);



Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);




while (!Raylib.WindowShouldClose())
{

    if (lvl == "meny")
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(intro, 0, 0, Color.WHITE);

        Raylib.DrawText("Dokemon", 325, 200, 100, Color.RED);
        Raylib.DrawText("start", 380, 300, 50, Color.RED);

        buttons.Klick(mousePos, lvl, r2);






        Raylib.EndDrawing();
    }

    (lvl, playerRect, startElement) = Rooms.Room2(lvl, playerRect, PokemonElement.water);
    (lvl, playerRect) = Rooms.Room3(lvl, playerRect, walls, playerImage, speed);
    (lvl, playerRect) = Rooms.Room4(lvl, playerRect, walls, playerImage2, speed, ute, generator);
    (lvl) = Rooms.Room5(lvl, waterFight, waterFight2, generator, fightmode, startFightMenu, mousePos, PokemonElement.water);





}









public enum PokemonElement { fire, water, grass };