using Raylib_cs;

Raylib.InitWindow(800, 600, "very hard game");


Rectangle wall = new Rectangle(64, 0, 16, 200);


string scene = "start";


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



        //  if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
        //     {
        //       movement.X = -1;
        //     }
        //     else if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
        //     {
        //       movement.X = 1;
        //     }
        //     if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
        //     {
        //       movement.Y = -1;
        //     }
        //     else if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
        //     {
        //       movement.Y = 1;
        //     }
        //     if (movement.Length() > 0)
        //     {
        //       movement = Vector2.Normalize(movement) * speed;
        //     }

        //     characterRect.x += movement.X;
        //     characterRect.y += movement.Y;


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
    else if (scene == "game"){


        
    }

        Raylib.EndDrawing();












}