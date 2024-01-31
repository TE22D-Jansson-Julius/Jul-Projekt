using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 600, "very hard game");

Vector2 movement = new Vector2(0.1f, 0.1f);

Rectangle wall = new Rectangle(64, 0, 16, 200);
Rectangle character = new Rectangle(20, 300, 40, 40);

float speed = 3;

string scene = "start";



//--------------------------------------------------------------------------------------------------------
//-------------------------------------------Graphics-----------------------------------------------------
//--------------------------------------------------------------------------------------------------------


while (!Raylib.WindowShouldClose())
{
    if (scene == "start")
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
            scene = "game";
        }

    }
    else if (scene == "game")
    {

        movement = Vector2.Zero;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            movement.X = 1;
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
        {
            movement.Y = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
        {
            movement.Y = 1;
        }
        if (movement.Length() > 0)
        {
            movement = Vector2.Normalize(movement) * speed;
        }

        character.X += movement.X;
        character.Y += movement.Y;


    }







    //--------------------------------------------------------------------------------------------------------
    //-------------------------------------------Graphics-----------------------------------------------------
    //--------------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    if (scene == "start")
    {
        Raylib.ClearBackground(Color.BROWN);
        Raylib.DrawText("Welcome to the worlds hardest game", 50, 250, 35, Color.BLACK);
        Raylib.DrawText("Press Space to play", 75, 285, 35, Color.BLACK);
    }
    else if (scene == "game")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText("W,A,S,D To Move", 10, 10, 40, Color.BLACK);

        Raylib.DrawRectangleRec(character, Color.BLUE);

    }

    Raylib.EndDrawing();












}