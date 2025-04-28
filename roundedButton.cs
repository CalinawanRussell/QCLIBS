using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public static class RoundedButtonHelper
{
    // Method to apply rounded corners to the button
    public static void ApplyRoundedCorners(Button btn, int radius)
    {
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0; // No border
        btn.BackColor = Color.Orange; // Set your desired background color
        btn.ForeColor = Color.White; // Set your desired text color
        btn.TextAlign = ContentAlignment.MiddleCenter;

        btn.Resize += (sender, e) => ApplyRegion(btn, radius);
        ApplyRegion(btn, radius);
    }

    // Apply the rounded region to the button
    private static void ApplyRegion(Button btn, int radius)
    {
        // Define the button size and shape
        Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);

        // Create the rounded rectangle path
        using (GraphicsPath path = GetRoundedPath(rect, radius))
        {
            btn.Region?.Dispose(); // Dispose of the previous region if it exists
            btn.Region = new Region(path); // Apply new rounded region
        }
    }

    // Generate a rounded path for the button
    private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int diameter = radius * 2;

        path.StartFigure();
        path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
        path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
        path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
        path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
        path.CloseFigure();

        return path;
    }
}