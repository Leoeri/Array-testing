using System;
using Raylib_cs;

namespace array_testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle mouse;
            Rectangle r1;
            Rectangle r2;
            int recHeight = 100;
            int recWidth = 100;
            int windowHeight = 600;
            int windowWidth = 800;
            int gridHeight = 6;
            int gridWidth = 6;
            int radiusCirc = (int)47.5;
            int[,] grid = new int[gridWidth, gridHeight];
            bool[,] trueGrid = new bool[gridWidth, gridHeight];
            int red = 1;
            int yellow = 2;
            bool leftClick;
            int playerTurn = 1;
            bool click = true;

            Raylib.InitWindow(windowWidth, windowHeight, "Poggershd");

            while (!Raylib.WindowShouldClose())
            {
                leftClick = Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BEIGE);

                for (int x = 1; x < gridWidth + 1; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {
                        mouse = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                        r1 = new Rectangle(x * recWidth, y * recHeight, recWidth, recHeight);
                        r2 = new Rectangle(x * recWidth + (int)2.5, y * recHeight - (int)2.5, recWidth - 5, recHeight - 5);
                        Raylib.DrawRectangleRec(r1, Color.BLACK);
                        Raylib.DrawRectangleRec(r2, Color.GRAY);
                        Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.DARKGRAY);
                    }
                }

                for (int x = 1; x < gridWidth + 1; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {
                        mouse = new Rectangle(Raylib.GetMouseX(), Raylib.GetMouseY(), 1, 1);
                        r1 = new Rectangle(x * recWidth, y * recHeight, recWidth, recHeight);
                        if (Raylib.CheckCollisionRecs(mouse, r1))
                        {
                            x--;
                            if (!trueGrid[x, y])
                            {
                                if (playerTurn == 1)
                                {
                                    Raylib.DrawCircle((x + 1) * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.RED);
                                    if (leftClick)
                                    {
                                        grid[x, y] = 1;
                                        trueGrid[x, y] = true;
                                    }
                                }
                                else if (playerTurn == 2)
                                {
                                    Raylib.DrawCircle((x + 1) * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.YELLOW);
                                    if (leftClick)
                                    {
                                        grid[x, y] = 2;
                                        trueGrid[x, y] = true;
                                    }
                                }
                            }
                            x++;
                        }
                    }
                }


                for (int x = 0; x < gridWidth; x++)
                {
                    for (int y = 0; y < gridHeight; y++)
                    {

                        if (red == grid[x, y])
                        {
                            x++;
                            Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.RED);
                            x--;
                        }
                        if (grid[x, y] == yellow)
                        {
                            x++;
                            Raylib.DrawCircle(x * recWidth + radiusCirc + (int)2.5, y * recHeight + radiusCirc - (int)1.5, radiusCirc, Color.YELLOW);
                            x--;
                        }

                    }
                }


                if (playerTurn == red && leftClick && click)
                {
                    playerTurn = yellow;
                    click = false;
                }
                else if (playerTurn == yellow && leftClick && click)
                {
                    playerTurn = red;
                    click = false;
                }
                if (Raylib.IsMouseButtonUp(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    click = true;
                }


                Raylib.EndDrawing();
            }
        }
    }
}

