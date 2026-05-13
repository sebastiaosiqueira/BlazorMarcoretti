using System;
using MudBlazor;
using ArticlesPlataform.Components.Theme;

namespace ArticlesPlataform.Services
{
    public interface IThemeService
    {
        MudTheme CurrentTheme { get; }
        bool IsDarkMode { get; }
        event Action? OnThemeChanged;
        void ToggleDarkMode();
        void SetDarkMode(bool isDark);
    }

    public class ThemeService : IThemeService, IDisposable
    {
        public MudTheme CurrentTheme { get; private set; }
        public bool IsDarkMode { get; private set; }
        public event Action? OnThemeChanged;

        public ThemeService()
        {
            IsDarkMode = false;
            CurrentTheme = AppTheme.Create(IsDarkMode);
        }

        public void ToggleDarkMode() => SetDarkMode(!IsDarkMode);

        public void SetDarkMode(bool isDark)
        {
            if (IsDarkMode == isDark)
                return;

            IsDarkMode = isDark;
            CurrentTheme = AppTheme.Create(IsDarkMode);
            OnThemeChanged?.Invoke();
        }

        public void Dispose()
        {
            OnThemeChanged = null;
        }
    }
}
