using QuickKit.Cmd;
using QuickKit.Cmd.Menu;
using QuickKit.Sample.Cmd.Menus.Shared;

namespace QuickKit.Sample.Cmd.Menus.Funcionario;

internal class FuncionarioMenu : MenuSecundary
{
    private readonly FuncionarioCadastroMenu _funcionarioCadastroMenu;
    private readonly FuncionarioConsultaMenu _funcionarioConsultaMenu;

    private static readonly string _defaultInvalidOptionMessage = "Opção inválida, tente novamente.";
    public FuncionarioMenu()
    {
        _funcionarioCadastroMenu = new();
        _funcionarioConsultaMenu = new();
    }

    public override void GoToOption(int option)
    {
        switch (option)
        {
            case 0:
                Back();
                break;
            case 1:
                _funcionarioCadastroMenu.Show();
                break;
            case 2:
                _funcionarioConsultaMenu.Show();
                break;
            default:
                ShowInvalidOptionMessage(_defaultInvalidOptionMessage);
                break;
        }
    }


    public override void ShowOptions()
    {
        Consoler.WriteLine("1 - Cadastrar");
        Consoler.WriteLine("2 - Consultar");
    }
}
