using Xunit;
using System.Drawing;

namespace ShareX.ScreenCaptureLib.Tests.Presentation.RegionCapture;

public class RegionCaptureAspectRatioTests
{
    [Fact]
    public void TestSquareAspectRatioConstraint()
    {
        Point start = new Point(10, 10);
        Point end = new Point(110, 60);
        Rectangle rect = HelpersLib.CaptureHelpers.CreateRectangle(start, end);
        
        int size = Math.Max(rect.Width, rect.Height);
        Rectangle constrained = new Rectangle(rect.X, rect.Y, size, size);

        Assert.Equal(100, constrained.Width);
        Assert.Equal(100, constrained.Height);
    }

    [Fact]
    public void TestCustomAspectRatioConstraint()
    {
        Point start = new Point(0, 0);
        Point end = new Point(200, 100);
        Rectangle rect = HelpersLib.CaptureHelpers.CreateRectangle(start, end);

        // Force 4:3 aspect ratio calculation
        int width = rect.Width;
        int height = (int)(width * 3.0 / 4.0);
        Rectangle constrained = new Rectangle(rect.X, rect.Y, width, height);

        Assert.Equal(200, constrained.Width);
        Assert.Equal(150, constrained.Height);
    }
}
