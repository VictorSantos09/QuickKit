using QuickKit.Cmd;
using QuickKit.Sample.Console.Menus.Funcionario;
using QuickKit.Sample.Console.Shared;

namespace QuickKit.Sample.Console.Menus;

internal class MainMenu : Menu
{
    private readonly FuncionarioMenu _menu;
    
    public MainMenu()
    {
        _menu = new FuncionarioMenu();
    }

    internal override void ShowOptions()
    {
        Writer.WriteLine("1 - Funcionário");
    }

    internal override void OnBack()
    {
        Environment.Exit(0);
    }

    internal override void GoToOption(int option)
    {
        switch (option)
        {
            case 0:
                OnBack();
                break;
            case 1:
                _menu.Show();
                break;
            default:
                ShowInvalidOptionMessage();
                break;
        }
    }
}
