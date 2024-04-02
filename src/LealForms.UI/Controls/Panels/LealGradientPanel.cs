using System.Drawing.Drawing2D;

namespace LealForms.UI.Controls.Panels
{
    public class LealGradientPanel : Panel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LealGradientPanel"/> class.
        /// </summary>
        /// <remarks>
        /// Note: This class calculates a gradient by blending the provided colors. Note that this operation is resource-intensive;
        /// frequent updates (e.g., during resizing) can lead to performance issues.
        /// </remarks>
        public LealGradientPanel()
        {
            BackgroundImageLayout = ImageLayout.Stretch;
            ParentChanged += LealGradientPanel_ParentChanged;
        }

        /// <summary>
        /// Gets or sets the first gradient color.
        /// </summary>
        public Color TopLeftGradientColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the second gradient color.
        /// </summary>
        public Color BottomLeftGradientColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the third gradient color.
        /// </summary>
        public Color TopRightGradientColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the fourth gradient color.
        /// </summary>
        public Color BottomRightGradientColor { get; set; } = Color.White;

        /// <summary>
        /// Gets or sets the resolution of the gradient. 
        /// Note: High resolutions may impact performance, especially on resize.
        /// </summary>
        public Size GradientResolution { get; set; } = new Size(1920, 1080);

        /// <summary>
        /// Handles the ParentChanged event. It updates the background image of the panel to reflect the current gradient colors.
        /// </summary>
        private void LealGradientPanel_ParentChanged(object? sender, EventArgs e)
        {
            // Dispose of the previous background image to free up resources.
            BackgroundImage?.Dispose();

            // Create a new gradient background image based on the specified colors and resolution.
            var rectangle = new Rectangle(0, 0, GradientResolution.Width, GradientResolution.Height);
            BackgroundImage = Gradient2D(rectangle, TopLeftGradientColor, BottomLeftGradientColor, TopRightGradientColor, BottomRightGradientColor);
        }

        /// <summary>
        /// Generates a 2D gradient image using the specified colors.
        /// </summary>
        /// <remarks>
        /// Note: This method calculates a gradient by blending the provided colors. Note that this operation is resource-intensive;
        /// frequent updates (e.g., during resizing) can lead to performance issues.
        /// </remarks>
        private static Bitmap Gradient2D(Rectangle rect, Color color1, Color color2, Color color3, Color color4)
        {
            // Define the gradient colors and initialize a new bitmap.
            var colors = new List<Color> { color1, color3, color4, color2 };
            var bmp = new Bitmap(rect.Width, rect.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                for (int y = 0; y < rect.Height; y++)
                {
                    using var pgb = new PathGradientBrush(GetCorners(rect).ToArray());
                    pgb.CenterColor = CalculateCentralColor(colors);
                    pgb.SurroundColors = [.. colors];
                    g.FillRectangle(pgb, 0, y, rect.Width, 1);
                }
            }

            return bmp;
        }

        /// <summary>
        /// Calculates the corners of a rectangle for use in a path gradient.
        /// </summary>
        private static List<PointF> GetCorners(RectangleF rect)
        {
            return [rect.Location,
                    new PointF(rect.Right, rect.Top),
                    new PointF(rect.Right, rect.Bottom),
                    new PointF(rect.Left, rect.Bottom)];
        }

        /// <summary>
        /// Calculates a central color by averaging the RGBA components of a list of colors.
        /// </summary>
        private static Color CalculateCentralColor(List<Color> colors)
        {
            var count = colors.Count;
            return Color.FromArgb(
                    colors.Sum(x => x.A) / count,
                    colors.Sum(x => x.R) / count,
                    colors.Sum(x => x.G) / count,
                    colors.Sum(x => x.B) / count);
        }
    }
}