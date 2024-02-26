using Raylib_cs;
using System.Numerics;

/// <summary>
///     A demo class to draw the arcade controls to the screen.
/// </summary>
public static class ControlsDisplay
{
    public static readonly float stride = 1.1f;
    public static readonly float length = 85;
    public static readonly float radius = length / 2f;
    public static readonly Vector2 size = new Vector2(length, length);
    public static Color InactiveColor { get; set; } = Color.Gray;

    public static void DrawPlayerControls(Controller player, Color color, Vector2 offset)
    {
        float unit = length * stride;
        DrawDPad(player, color, offset + new Vector2(1, 1) * unit);
        DrawFaceButtons(player, color, offset + new Vector2(4f, 1f) * unit);
        DrawFrontButtons(player, color, offset + new Vector2(3f, 4f) * unit);
        DrawAuxButton(player, color, offset + new Vector2(7.5f, 0.5f) * unit);
    }

    public static void DrawCoin(Color color, Vector2 offset)
    {
        Color coin = Controls.IsDown(Players.Coin) ? color : InactiveColor;
        Raylib.DrawRectangleV(offset, size, coin);
    }

    public static void DrawDPad(Controller player, Color color, Vector2 offset)
    {
        Color up = Controls.IsDown(player.DPadUp) ? color : InactiveColor;
        Color down = Controls.IsDown(player.DPadDown) ? color : InactiveColor;
        Color left = Controls.IsDown(player.DPadLeft) ? color : InactiveColor;
        Color right = Controls.IsDown(player.DPadRight) ? color : InactiveColor;

        Raylib.DrawRectangleV(offset - new Vector2(0, length), size, up);
        Raylib.DrawRectangleV(offset + new Vector2(0, length), size, down);
        Raylib.DrawRectangleV(offset - new Vector2(length, 0), size, left);
        Raylib.DrawRectangleV(offset + new Vector2(length, 0), size, right);
    }

    public static void DrawFaceButtons(Controller player, Color color, Vector2 offset)
    {
        Color r1c1 = Controls.IsDown(player.ButtonRow1Col1) ? color : InactiveColor;
        Color r1c2 = Controls.IsDown(player.ButtonRow1Col2) ? color : InactiveColor;
        Color r1c3 = Controls.IsDown(player.ButtonRow1Col3) ? color : InactiveColor;
        Color r2c1 = Controls.IsDown(player.ButtonRow2Col1) ? color : InactiveColor;
        Color r2c2 = Controls.IsDown(player.ButtonRow2Col2) ? color : InactiveColor;
        Color r2c3 = Controls.IsDown(player.ButtonRow2Col3) ? color : InactiveColor;

        float stride0 = 0;
        float stride1 = 1.1f * length;
        float stride2 = 1.1f * 2 * length;

        Raylib.DrawCircleV(offset + new Vector2(stride0, stride0), radius, r1c1);
        Raylib.DrawCircleV(offset + new Vector2(stride1, stride0), radius, r1c2);
        Raylib.DrawCircleV(offset + new Vector2(stride2, stride0), radius, r1c3);
        Raylib.DrawCircleV(offset + new Vector2(stride0, stride1), radius, r2c1);
        Raylib.DrawCircleV(offset + new Vector2(stride1, stride1), radius, r2c2);
        Raylib.DrawCircleV(offset + new Vector2(stride2, stride1), radius, r2c3);
    }

    public static void DrawFrontButtons(Controller player, Color color, Vector2 offset)
    {
        Color left = Controls.IsDown(player.ButtonFrontLeft) ? color : InactiveColor;
        Color right = Controls.IsDown(player.ButtonFrontRight) ? color : InactiveColor;

        float stride0 = 0;
        float stride1 = stride * length;

        Raylib.DrawCircleV(offset + new Vector2(stride0, 0), radius, left);
        Raylib.DrawCircleV(offset + new Vector2(stride1, 0), radius, right);
    }

    public static void DrawAuxButton(Controller player, Color color, Vector2 offset)
    {
        Color aux = Controls.IsDown(player.AuxilleryButton) ? color : InactiveColor;
        Raylib.DrawCircleV(offset, radius, aux);
    }
}
