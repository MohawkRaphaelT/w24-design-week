using Raylib_cs;

/// <summary>
///     Describes basic information for a player controller.
/// </summary>
public class Controller
{
    public static readonly int NumberOfControls = 13;

    public int ID { get; }
    public KeyboardKey[] AllControls { get; private init; }
    public KeyboardKey[] DPad => AllControls[0..4];
    public KeyboardKey[] FaceButtons => AllControls[4..10];
    public KeyboardKey[] FrontButtons => AllControls[10..12];
    public KeyboardKey[] AllButtons => AllControls[4..13];
    public KeyboardKey DPadUp => AllControls[0];
    public KeyboardKey DPadDown => AllControls[1];
    public KeyboardKey DPadLeft => AllControls[2];
    public KeyboardKey DPadRight => AllControls[3];
    public KeyboardKey ButtonRow1Col1 => AllControls[4];
    public KeyboardKey ButtonRow1Col2 => AllControls[5];
    public KeyboardKey ButtonRow1Col3 => AllControls[6];
    public KeyboardKey ButtonRow2Col1 => AllControls[7];
    public KeyboardKey ButtonRow2Col2 => AllControls[8];
    public KeyboardKey ButtonRow2Col3 => AllControls[9];
    public KeyboardKey ButtonFrontLeft => AllControls[10];
    public KeyboardKey ButtonFrontRight => AllControls[11];
    public KeyboardKey AuxilleryButton => AllControls[12];

    public Controller(int id, KeyboardKey[] controls)
    {
        if (controls is null)
        {
            string msg = $"Argument {nameof(controls)} is null!";
            throw new ArgumentException(msg);
        }

        if (controls.Length < NumberOfControls)
        {
            string msg =
                $"Argument {nameof(controls)} does not contain enough elements! " +
                $"{controls.Length}/{NumberOfControls}";
            throw new ArgumentException(msg);
        }

        ID = id;
        AllControls = controls;
    }

    /// <summary>
    ///     Get the the keyboard key binding of <paramref name="arcadeControl"/>.
    /// </summary>
    /// <param name="arcadeControl">The arcade control you want the keybinding of.</param>
    /// <returns>
    ///     The keyboard key of the specified <paramref name="arcadeControl"/>.
    /// </returns>
    /// <exception cref="NotImplementedException">
    ///     Errors when unmapped arcade cotnrol is given.
    /// </exception>
    public KeyboardKey GetKey(ArcadeControl arcadeControl)
    {
        return arcadeControl switch
        {
            ArcadeControl.DPadUp => DPadUp,
            ArcadeControl.DPadDown => DPadDown,
            ArcadeControl.DPadLeft => DPadLeft,
            ArcadeControl.DPadRight => DPadRight,
            ArcadeControl.ButtonRow1Col1 => ButtonRow1Col1,
            ArcadeControl.ButtonRow1Col2 => ButtonRow1Col2,
            ArcadeControl.ButtonRow1Col3 => ButtonRow1Col3,
            ArcadeControl.ButtonRow2Col1 => ButtonRow2Col1,
            ArcadeControl.ButtonRow2Col2 => ButtonRow2Col2,
            ArcadeControl.ButtonRow2Col3 => ButtonRow2Col3,
            ArcadeControl.ButtonFrontLeft => ButtonFrontLeft,
            ArcadeControl.ButtonFrontRight => ButtonFrontRight,
            ArcadeControl.AuxilleryButton => AuxilleryButton,
            _ => throw new NotImplementedException($"Uninplmeneted key {arcadeControl}."),
        };
    }

    /// <summary>
    ///     Get the the keyboard key bindings of <paramref name="arcadeControls"/>.
    /// </summary>
    /// <param name="arcadeControls">The arcade controls you want the keybindings of.</param>
    /// <returns>
    ///     The keyboard keys of the specified <paramref name="arcadeControls"/>.
    /// </returns>
    public KeyboardKey[] GetKeys(ArcadeControl[] arcadeControls)
    {
        KeyboardKey[] keys = new KeyboardKey[arcadeControls.Length];
        for (int i = 0; i < arcadeControls.Length; i++)
        {
            keys[i] = GetKey(arcadeControls[i]);
        }
        return keys;
    }

}
