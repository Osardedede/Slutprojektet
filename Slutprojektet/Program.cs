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
Texture2D background = Raylib.LoadTexture("Hus1.png");


// bestämer hastigheten för karaktären i hela koden
float speed = 4f;

string lvl = "choosing";
// Gör min egen data typ för vilken typ man väljer i början av spelet
// Detta är fär att göra det enklare att ändra
PokemonElement startElement = PokemonElement.water;

Texture2D fire = Raylib.LoadTexture("chimchar.png");
Texture2D water = Raylib.LoadTexture("piplup.png");
Texture2D grass = Raylib.LoadTexture("turtwig.png");
bool startFightMenu = true;
bool fightmode = false;

Random generator = new Random();


// Varför jag använder en lista för att göra väggar är för att det
//  blir hundra gånger lättare när jag ska lägga till väggar, då jag
//  kan skriva wall.add(x,y,bredd,höjd)
List<Rectangle> walls = new List<Rectangle>();


Rectangle playerRect = new Rectangle(100, 100, playerImage.width, playerImage.height);
Rectangle r2 = new Rectangle(380, 300, 150, 100);

walls.Add(new Rectangle(0, 498, 281, 126));

// Skapar en vector som håller koll på min muspekare
Vector2 mousePos = new Vector2(Raylib.GetMousePosition().X, Raylib.GetMousePosition().Y);




while (!Raylib.WindowShouldClose())
{

    if (lvl == "meny")
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(intro, 0, 0, Color.WHITE);

        Raylib.DrawText("Dokemon", 325, 200, 100, Color.RED);
        Raylib.DrawText("start", 380, 300, 50, Color.RED);
        // En metod för start knappen som tar ut stringen lvl
        // Och behöver ta in det i parantesen, alltså lvl och rektangeln r2  
        lvl = Buttons.Klick(lvl, r2);

        Raylib.EndDrawing();
    }

// Samma metoder för alla rum
    (lvl, playerRect, startElement) = Rooms.Room2(lvl, playerRect, startElement, fire, water, grass);
    (lvl, playerRect) = Rooms.Room3(lvl, playerRect, walls, playerImage, speed, background);
    (lvl, playerRect) = Rooms.Room4(lvl, playerRect, playerImage2, speed, ute, generator);
    (lvl) = Rooms.Room5(lvl, waterFight, waterFight2, generator, fightmode, startFightMenu, startElement);
}

// Det är här som jag skapar datatypen som jag tidigare nämnde
// För att förbättra koden hade jag kunnat göra en likadan för lvl, för som sagt 
// göra det enklare att ändra och testa
public enum PokemonElement { fire, water, grass };