using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace designflat_melvin;

public partial class MainWindow : Window
{
    private Button _homeButton;
    private Button _eatInButton;
    private ContentControl _mainContent;

    public MainWindow()
    {
        InitializeComponent();
        InitializeNavigation();
    }

    private void InitializeNavigation()
    {
        _homeButton = this.FindControl<Button>("HomeButton");
        _eatInButton = this.FindControl<Button>("EatInButton");
        _mainContent = this.FindControl<ContentControl>("MainContent");

        if (_homeButton != null)
        {
            _homeButton.Click += HomeButton_Click;
        }

        if (_eatInButton != null)
        {
            _eatInButton.Click += EatInButton_Click;
        }

        // Set initial content to HomeView and activate Home button
        if (_mainContent != null)
        {
            _mainContent.Content = new HomeView();
        }
        SetActiveButton(_homeButton);
    }

    private void HomeButton_Click(object? sender, RoutedEventArgs e)
    {
        _mainContent.Content = new HomeView();
        SetActiveButton(_homeButton);
    }

    private void EatInButton_Click(object? sender, RoutedEventArgs e)
    {
        _mainContent.Content = new EatInView();
        SetActiveButton(_eatInButton);
    }

    private void SetActiveButton(Button? activeButton)
    {
        if (_homeButton != null)
        {
            _homeButton.Classes.Remove("Active");
        }
        if (_eatInButton != null)
        {
            _eatInButton.Classes.Remove("Active");
        }
        if (activeButton != null)
        {
            activeButton.Classes.Add("Active");
        }
    }
}
