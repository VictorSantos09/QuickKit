using QuickKit.Cmd;
using QuickKit.Sample.Cmd.Menus.Shared;

namespace QuickKit.Sample.Cmd.Menus.Funcionario;

internal class FuncionarioConsultaMenu : MenuSecundary
{
    protected override string NotNullAlertMessage { get; set; } = "Digite algo válido";

    public override void GoToOption(int option)
    {
        switch (option)
        {
            case 0:
                Back();
                break;
            case 1:
                Consoler.WriteLine("Todos os funcionários");
                break;
            default:
                ShowInvalidOptionMessage(NotNullAlertMessage);
                break;
        }
    }

    public override void ShowOptions()
    {
        Consoler.WriteLine("1 - Ver Todos");
    }
}
