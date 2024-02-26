using Raylib_cs;
using System.Numerics;

public class Program
{
    // Constant and readonly variables
    public static readonly string Title = "Game Title";
    public static bool DoFullscreen = true;

    static void Main(string[] args)
    {
        // Create a window to draw to. The arguments define width and height
        Raylib.InitWindow(1680, 1050, Title);
        // Set the target frames-per-second (FPS)
        Raylib.SetTargetFPS(60);
        // Prepare audio
        Raylib.InitAudioDevice();

        // Setup your game. This is a function YOU define.
        Setup();

        // Loop so long as window should not close
        while (!Raylib.WindowShouldClose())
        {
            // Enable drawing to the canvas (window)
            Raylib.BeginDrawing();
            // Clear the canvas with one color
            Raylib.ClearBackground(Color.RayWhite);

            // Your game code here. This is a function YOU define.
            Update();

            // Stop drawing to the canvas, begin displaying the frame
            Raylib.EndDrawing();
        }
        // Close the window
        Raylib.CloseWindow();
    }

    static void Setup()
    {
        // Your one-time setup code here
        CheckDoFullscreen();
    }

    static void Update()
    {
        // Your game code run each frame here
        CheckToggleControls();
        DemoDrawPlayerControls();
    }

    /// <summary>
    ///     Draw controls to screen
    /// </summary>
    static void DemoDrawPlayerControls()
    {
        Vector2 p1Offset = new Vector2(50, Raylib.GetScreenHeight() / 3);
        Vector2 p2Offset = new Vector2(Raylib.GetScreenWidth() / 2 + 50, Raylib.GetScreenHeight() / 3);
        Vector2 coinOffset = new Vector2(Raylib.GetScreenWidth() / 2 - 50, 100);
        ControlsDisplay.DrawPlayerControls(Players.P1, Color.Red, p1Offset);
        ControlsDisplay.DrawPlayerControls(Players.P2, Color.Blue, p2Offset);
        ControlsDisplay.DrawCoin(Color.Purple, coinOffset);
    }

    /// <summary>
    ///     Check if game should toggle between arcade's controls or custom keyboard controls for testing.
    /// </summary>
    public static void CheckToggleControls()
    {
        KeyboardKey toggleKey = KeyboardKey.Tab;
        if (Raylib.IsKeyPressed(toggleKey))
            Players.UseArcadeControls = !Players.UseArcadeControls;

        string msg = $"[{toggleKey}] {nameof(Players.UseArcadeControls)}: {Players.UseArcadeControls}";
        Raylib.DrawText(msg, 10, 10, 32, Color.Black);
    }

    /// <summary>
    ///     Check if game should go into fullscreen mode
    /// </summary>
    public static void CheckDoFullscreen()
    {
        if (!Raylib.IsWindowFullscreen() && DoFullscreen)
            Raylib.ToggleFullscreen();
    }

    /// <summary>
    ///     Example of how to get input.
    /// </summary>
    private static void ExampleControlsUsage()
    {
        // Check input using player's reference
        // Single input
        bool a = Controls.IsPressed(Players.P1.ButtonRow1Col1);
        // Multiple inputs
        bool b = Controls.AnyArePressed(Players.P1.ButtonRow1Col1, Players.P1.ButtonRow2Col1);
        bool c = Controls.AnyArePressed(Players.P1.FaceButtons);

        // Check input using a player reference and passing the desired enum
        // Single input
        bool d = Controls.IsPressed(Players.P1, ArcadeControl.ButtonRow1Col1);
        // Multiple input
        bool e = Controls.AnyArePressed(Players.P1, ArcadeControl.ButtonRow1Col1, ArcadeControl.ButtonRow2Col1);

        // Check BOTH players for one or more inputs
        // Multiple buttons for either player
        bool f = Controls.AnyArePressed(Players.Both, ArcadeControl.ButtonRow1Col1);
        bool g = Controls.AnyArePressed(Players.Both, ArcadeControl.ButtonRow1Col1, ArcadeControl.ButtonRow2Col1, ArcadeControl.ButtonFrontRight);
    }

}
