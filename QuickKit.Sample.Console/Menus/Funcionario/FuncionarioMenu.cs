using QuickKit.Cmd;
using QuickKit.Sample.Console.Shared;

namespace QuickKit.Sample.Console.Menus.Funcionario;

internal class FuncionarioMenu : Menu
{
    private readonly FuncionarioCadastroMenu _funcionarioCadastroMenu;
    private readonly FuncionarioConsultaMenu _funcionarioConsultaMenu;
    public FuncionarioMenu()
    {
        _funcionarioCadastroMenu = new();
        _funcionarioConsultaMenu = new();
    }
    internal override void GoToOption(int option)
    {
        switch (option)
        {
            case 0:
                OnBack();
                break;
            case 1:
                _funcionarioCadastroMenu.Show();
                break;
            case 2:
                _funcionarioConsultaMenu.Show();
                break;
            default:
                ShowInvalidOptionMessage();
                break;
        }
    }

    internal override void ShowOptions()
    {
        Writer.WriteLine("1 - Cadastrar");
        Writer.WriteLine("2 - Consultar");
    }
}
