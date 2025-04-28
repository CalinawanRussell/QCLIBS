public class ColoredProgressBar : ProgressBar
{
    public Color BarColor { get; set; } = Color.Orange;

    public ColoredProgressBar()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        UpdateStyles();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        Graphics g = e.Graphics;

        // Draw border in white
        using (Pen pen = new Pen(Color.White, 2))
        {
            g.DrawRectangle(pen, 1, 1, rect.Width - 2, rect.Height - 2);
        }

        // Draw the progress bar fill
        rect.Inflate(-3, -3);
        if (Value > 0)
        {
            Rectangle fillRect = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);
            using (SolidBrush brush = new SolidBrush(this.BarColor))
            {
                g.FillRectangle(brush, fillRect);
            }
        }
    }
}