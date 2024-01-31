using System.Net.Quic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using Raylib_cs;

Raylib.InitWindow(800, 600, "very hard game");

Vector2 movement = new Vector2(0.1f, 0.1f);

Rectangle wall = new Rectangle(0, 60, 60, 60);
//Rectangle point = new Rectangle(0, 60, 60, 60);
Rectangle character = new Rectangle(20, 300, 40, 40);



bool game = false;
int level = 0;
float speed = 3f;




List<Rectangle> walls = new();
List<Rectangle> walls2 = new();
List<Rectangle> walls3 = new();

List<Rectangle> goals = new();
List<Rectangle> goals2 = new();
List<Rectangle> goals3 = new();



void CollisionV(List<Rectangle> walls)
{
    //Adds collision to walls and character
    foreach (Rectangle w in walls)
        if (Raylib.CheckCollisionRecs(w, character))
        {
        
            level= -1;
        }

}


void GoalV(List<Rectangle> goals, int newLevel)
{
    foreach (Rectangle g in goals)
        if (Raylib.CheckCollisionRecs(g, character))
        {

          
            character.X = 20;
            character.Y = 300;
            level = newLevel;
return;
        }

// }
// void GoalV2()
// {
//     foreach (Rectangle g in goals2)
//         if (Raylib.CheckCollisionRecs(g, character))
//         {
           
//             character.X = 20;
//             character.Y = 300;
//             level = 3;
//         }

// }
// void GoalV3()
// {
//     foreach (Rectangle g in goals3)
//         if (Raylib.CheckCollisionRecs(g, character))
//         {
//             level = -2;
//         }


 }






while (!Raylib.WindowShouldClose())
{
     
    Raylib.SetTargetFPS(60);
    if (level == 0)
    {
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
          
            level = 1;
            game = true;
        }

    }
    else if (game == true)
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



        if (character.X <= 0)
        {
            character.X = 0;
        }
        if (character.X >= 760)
        {
            character.X = 760;
        }


        if (character.Y <= 0)
        {
            character.Y = 0;
        }
        if (character.Y >= 560)
        {
            character.Y = 560;
        }

      

     }

    if (level == 1) 
    {
        
        Raylib.ClearBackground(Color.DARKBLUE);
       
        // Fick hjälp av Micke B


        int[,] grid = {
    {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,0,2,1},
    {1,1,1,1,1,0,0,0,0,0,1,1,1,0,1,1},
    {1,1,1,1,0,0,0,0,0,0,0,1,1,0,1,1},
    {1,1,1,1,0,0,1,1,1,0,0,1,1,0,1,1},
    {0,0,0,0,0,0,1,1,0,0,0,1,1,0,1,1},
    {0,0,0,0,0,1,1,1,0,1,0,1,1,0,1,1},
    {1,1,1,1,1,1,1,1,0,1,0,1,1,0,1,1},
    {1,1,1,1,1,1,1,1,0,0,0,1,1,0,1,1},
    {1,1,1,1,1,1,1,1,1,0,1,1,1,0,1,1},
    {1,1,1,1,1,1,1,1,1,0,0,0,0,0,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
     };


        int tileSize = 50;

        for (var x = 0; x < grid.GetLength(1); x++)
        {
            for (var y = 0; y < grid.GetLength(0); y++)
            {
                if (grid[y, x] == 1)
                {
                    walls.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
                if (grid[y, x] == 2)
                {

                    goals.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
            }
        }
    }



    if (level == 2)
    {


        int[,] grid2 = {
    {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
    {0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,1},
    {1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1},
    {1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
};

        int tileSize = 50;


        for (var x = 0; x < grid2.GetLength(1); x++)
        {
            for (var y = 0; y < grid2.GetLength(0); y++)
            {
                if (grid2[y, x] == 1)
                {
                    walls2.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
                if (grid2[y, x] == 2)
                {

                    goals2.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
            }
        }
    }


if (level == 3)
    {


        int[,] grid3 = {
    {0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
    {1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1},
    {1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1},
    {1,1,1,1,1,1,1,0,1,1,1,1,1,1,0,1},
    {0,0,0,1,1,1,1,0,0,0,0,1,1,1,0,1},
    {0,0,0,1,1,1,1,1,1,1,0,0,1,1,0,1},
    {1,1,0,1,1,1,0,0,0,1,1,0,1,1,0,1},
    {1,1,0,1,1,1,0,1,0,0,1,0,1,1,0,1},
    {1,1,0,1,1,1,0,0,1,0,0,0,1,1,0,1},
    {1,1,0,1,1,1,1,0,1,1,1,1,1,0,0,1},
    {1,1,0,0,0,0,0,0,1,2,0,0,0,0,1,1}
};

        int tileSize = 50;


        for (var x = 0; x < grid3.GetLength(1); x++)
        {
            for (var y = 0; y < grid3.GetLength(0); y++)
            {
                if (grid3[y, x] == 1)
                {
                    walls3.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
                if (grid3[y, x] == 2)
                {

                    goals3.Add(new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize));
                }
            }
        }
    }
    //--------------------------------------------------------------------------------------------------------
    //-------------------------------------------Graphics-----------------------------------------------------
    //--------------------------------------------------------------------------------------------------------

    Raylib.BeginDrawing();
    if (level == 0)
    {
        Raylib.ClearBackground(Color.BROWN);
        Raylib.DrawText("Welcome to the worlds hardest game", 50, 250, 35, Color.BLACK);
        Raylib.DrawText("Complete the game before the character stops moving", 20, 285, 25, Color.BLACK);
        Raylib.DrawText("Press Space to play", 150, 310, 35, Color.BLACK);
    }

    if (level == 1)
    {

        CollisionV(walls);
 GoalV(goals, 2);
 
        // Raylib.ClearBackground(Color.DARKBLUE);
        Raylib.DrawText("W,A,S,D To Move", 5, 5, 40, Color.BLACK);

        Raylib.DrawRectangleRec(character, Color.BLUE);

       

        foreach (Rectangle w in walls)
        {
            Raylib.DrawRectangleRec(w, Color.BLACK);
            Raylib.DrawRectangleLinesEx(w, 1, Color.DARKBLUE);
        }
        foreach (Rectangle g in goals)
        {
            Raylib.DrawRectangleRec(g, Color.GREEN);
            Raylib.DrawRectangleLinesEx(g, 1, Color.BLACK);

        }
    }

    if (level == 2)
    {

        CollisionV(walls2);
GoalV(goals2, 3);

        Raylib.ClearBackground(Color.DARKGREEN);
        Raylib.DrawText("W,A,S,D To Move", 5, 5, 40, Color.BLACK);

        Raylib.DrawRectangleRec(character, Color.BLUE);


        foreach (Rectangle w in walls2)
        {
            Raylib.DrawRectangleRec(w, Color.GREEN);
            Raylib.DrawRectangleLinesEx(w, 1, Color.DARKGREEN);
        }
        foreach (Rectangle g in goals2)
        {
            Raylib.DrawRectangleRec(g, Color.RED);
            Raylib.DrawRectangleLinesEx(g, 1, Color.BLACK);

        }
    }

    if (level == 3)
    {
        CollisionV(walls3);
GoalV(goals3, -2);

        Raylib.ClearBackground(Color.DARKGREEN);
        Raylib.DrawText("W,A,S,D To Move", 5, 5, 40, Color.BLACK);

        Raylib.DrawRectangleRec(character, Color.BLUE);


        foreach (Rectangle w in walls3)
        {
            Raylib.DrawRectangleRec(w, Color.PURPLE);
            Raylib.DrawRectangleLinesEx(w, 1, Color.ORANGE);
        }
        foreach (Rectangle g in goals3)
        {
            Raylib.DrawRectangleRec(g, Color.LIME);
            Raylib.DrawRectangleLinesEx(g, 1, Color.BLACK);

        }
    }

    if (level == -1)
    {
     Raylib.ClearBackground(Color.MAROON);
     Raylib.DrawText("You Died", 150, 250, 70, Color.BLACK);
     Raylib.DrawText("Press Space to retry!", 75, 320, 35, Color.BLACK);
        Raylib.DrawText("Press Esc to rage quit!", 75, 350, 35, Color.BLACK);

     if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
     {
        level = 1;
          character.X = 20;
            character.Y = 300;

        
     }
    }


if (level == -2)
{
    Raylib.ClearBackground(Color.DARKPURPLE);
        Raylib.DrawText("Victory Royale!", 50, 250, 70, Color.GOLD);
        Raylib.DrawText("Press Space to exit", 75, 320, 35, Color.BLACK);
        if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
        {
 Environment.Exit(0);

        }
}

   
    
    

    Raylib.EndDrawing();
}

