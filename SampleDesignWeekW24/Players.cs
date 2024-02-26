using Raylib_cs;

/// <summary>
///     Class to manage players and game key bindings
/// </summary>
public static class Players
{
    public static bool UseArcadeControls { get; set; } = false;
    // Key bindings
    public static readonly KeyboardKey Coin = KeyboardKey.Five;
    public static readonly KeyboardKey[] P1ArcadeControls =
    {
        KeyboardKey.Up,
        KeyboardKey.Down,
        KeyboardKey.Left,
        KeyboardKey.Right,
        KeyboardKey.Z,
        KeyboardKey.LeftShift,
        KeyboardKey.Space,
        KeyboardKey.LeftControl,
        KeyboardKey.LeftAlt,
        KeyboardKey.X,
        KeyboardKey.C,
        KeyboardKey.V,
        KeyboardKey.One,
    };
    public static readonly KeyboardKey[] P2ArcadeControls =
    {
        KeyboardKey.R,
        KeyboardKey.F,
        KeyboardKey.D,
        KeyboardKey.G,
        KeyboardKey.I,
        KeyboardKey.W,
        KeyboardKey.Q,
        KeyboardKey.A,
        KeyboardKey.S,
        KeyboardKey.K,
        KeyboardKey.J,
        KeyboardKey.L,
        KeyboardKey.Two,
    };
    public static readonly KeyboardKey[] P1KeyboardControls =
    {
        KeyboardKey.W,
        KeyboardKey.S,
        KeyboardKey.A,
        KeyboardKey.D,
        KeyboardKey.R,
        KeyboardKey.T,
        KeyboardKey.Y,
        KeyboardKey.F,
        KeyboardKey.G,
        KeyboardKey.H,
        KeyboardKey.V,
        KeyboardKey.B,
        KeyboardKey.N,
    };
    public static readonly KeyboardKey[] P2KeyboardControls =
    {
        KeyboardKey.Up,
        KeyboardKey.Down,
        KeyboardKey.Left,
        KeyboardKey.Right,
        KeyboardKey.P,
        KeyboardKey.LeftBracket,
        KeyboardKey.RightBracket,
        KeyboardKey.L,
        KeyboardKey.Semicolon,
        KeyboardKey.Apostrophe,
        KeyboardKey.Comma,
        KeyboardKey.Period,
        KeyboardKey.Slash,
    };
    // 2 controllers for each player
    public static readonly Controller ArcadeP1 = new(1, P1ArcadeControls);
    public static readonly Controller ArcadeP2 = new(2, P2ArcadeControls);
    public static readonly Controller KeyboardP1 = new(1, P1KeyboardControls);
    public static readonly Controller KeyboardP2 = new(2, P2KeyboardControls);

    // Properties
    // These small functions figure out which controls to use.
    // (bool:a?b) is the ternary operator.
    public static Controller P1 => UseArcadeControls ? ArcadeP1 : KeyboardP1;
    public static Controller P2 => UseArcadeControls ? ArcadeP2 : KeyboardP2;
    public static Controller[] Both => new Controller[] { P1, P2 };
}
