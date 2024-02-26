using Raylib_cs;

public static class Controls
{
    // Get input using KeyboardKey
    public static bool IsPressed(KeyboardKey key) => Raylib.IsKeyPressed(key);
    public static bool IsReleased(KeyboardKey key) => Raylib.IsKeyReleased(key);
    public static bool IsUp(KeyboardKey key) => Raylib.IsKeyUp(key);
    public static bool IsDown(KeyboardKey key) => Raylib.IsKeyDown(key);

    // Get input using multiple KeyboardKeys
    public static bool AnyArePressed(params KeyboardKey[] keys) => AnyAre(keys, (KeyboardKey key) => { return Raylib.IsKeyPressed(key); });
    public static bool AnyAreReleased(params KeyboardKey[] keys) => AnyAre(keys, (KeyboardKey key) => { return Raylib.IsKeyReleased(key); });
    public static bool AnyAreUp(params KeyboardKey[] keys) => AnyAre(keys, (KeyboardKey key) => { return Raylib.IsKeyUp(key); });
    public static bool AnyAreDown(params KeyboardKey[] keys) => AnyAre(keys, (KeyboardKey key) => { return Raylib.IsKeyDown(key); });
    private static bool AnyAre(KeyboardKey[] keys, Func<KeyboardKey, bool> function)
    {
        foreach (var key in keys)
        {
            bool isPressed = function(key);
            if (isPressed)
                return true;
        }
        return false;
    }

    // Get input using Player and ArcadeControl
    public static bool IsPressed(Controller player, ArcadeControl arcadeControl) => IsPressed(player.GetKey(arcadeControl));
    public static bool IsReleased(Controller player, ArcadeControl arcadeControl) => IsReleased(player.GetKey(arcadeControl));
    public static bool IsUp(Controller player, ArcadeControl arcadeControl) => IsUp(player.GetKey(arcadeControl));
    public static bool IsDown(Controller player, ArcadeControl arcadeControl) => IsDown(player.GetKey(arcadeControl));

    // Get input using Player and multiple ArcadeControls
    public static bool AnyArePressed(Controller player, params ArcadeControl[] arcadeControls) => Are(player, arcadeControls, IsPressed);
    public static bool AnyAreReleased(Controller player, params ArcadeControl[] arcadeControls) => Are(player, arcadeControls, IsReleased);
    public static bool AnyAreUp(Controller player, params ArcadeControl[] arcadeControls) => Are(player, arcadeControls, IsUp);
    public static bool AnyAreDown(Controller player, params ArcadeControl[] arcadeControls) => Are(player, arcadeControls, IsDown);
    private static bool Are(Controller player, ArcadeControl[] arcadeControls, Func<Controller, ArcadeControl, bool> function)
    {
        foreach (var control in arcadeControls)
        {
            bool isPressed = function(player, control);
            if (isPressed)
                return true;
        }
        return false;
    }
    
    // Get input using multiple Players and multiple ArcadeControls
    public static bool AnyArePressed(Controller[] players, params ArcadeControl[] arcadeControls) => AnyAre(players, arcadeControls, IsPressed);
    public static bool AnyAreReleased(Controller[] players, params ArcadeControl[] arcadeControls) => AnyAre(players, arcadeControls, IsReleased);
    public static bool AnyAreUp(Controller[] players, params ArcadeControl[] arcadeControls) => AnyAre(players, arcadeControls, IsUp);
    public static bool AnyAreDown(Controller[] players, params ArcadeControl[] arcadeControls) => AnyAre(players, arcadeControls, IsDown);
    private static bool AnyAre(Controller[] players, ArcadeControl[] arcadeControls, Func<Controller, ArcadeControl, bool> function)
    {
        foreach (var player in players)
        {
            bool isPressed = Are(player, arcadeControls, function);
            if (isPressed)
                return true;
        }
        return false;
    }
}
