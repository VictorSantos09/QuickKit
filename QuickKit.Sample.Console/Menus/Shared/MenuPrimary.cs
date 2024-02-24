using QuickKit.Cmd;
using QuickKit.Cmd.Menu;
using QuickKit.Sample.Cmd.Menus.Funcionario;

namespace QuickKit.Sample.Cmd.Menus.Shared;

internal class MenuPrimary : MenuMain
{
    private readonly FuncionarioMenu _funcionarioMenu;

    public MenuPrimary()
    {
        _funcionarioMenu = new();
    }

    public override void GoToOption(int option)
    {
        switch (option)
        {
            case 0:
                Exit();
                break;
            case 1:
                _funcionarioMenu.Show();
                break;
            default:
                ShowInvalidOptionMessage("Opção inválida");
                break;
        }
    }

    public override int SelectOption()
    {
        return Consoler.ReadAs<int>(
            "digite uma opção válida",
            "digite um número");
    }

    public override void ShowOptions()
    {
        Consoler.WriteLine("0 - Fechar");
        Consoler.WriteLine("1 - Funcionário");
    }
}
