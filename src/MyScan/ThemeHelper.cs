using ControlzEx.Theming;
using System.Windows;

namespace MyScan
{
    public class ThemeHelper
    {
        public static bool IsDarkTheme()
        {
            return GetThemeBaseColor() == ThemeManager.BaseColorDarkConst;
        }

        public static string GetThemeBaseColor()
        {
            return ThemeManager.Current.DetectTheme(Application.Current).BaseColorScheme;
        }

        public static string GetThemeColor()
        {
            return ThemeManager.Current.DetectTheme(Application.Current).ColorScheme;
        }

        public static void ToogleThemeBase()
        {
            string baseColor = ThemeManager.BaseColorDarkConst;
            if (IsDarkTheme()) baseColor = ThemeManager.BaseColorLightConst;
            ThemeManager.Current.ChangeThemeBaseColor(Application.Current, baseColor);
        }

        public static void SetThemeColor(string color)
        {
            ThemeManager.Current.ChangeThemeColorScheme(Application.Current, color);
        }
    }
}
