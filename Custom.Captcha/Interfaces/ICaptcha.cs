using Custom.MCaptcha.Classes;

namespace Custom.MCaptcha.Interfaces
{
    public interface ICaptcha
    {
        BaseCaptcha GenerateCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null);

        BaseCaptcha GenerateBitmapCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null);

        BaseCaptcha GenerateStreamCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null);

        string GenerateStringCaptcha();
    }
}
