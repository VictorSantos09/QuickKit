using QuickKit.Cmd;
using QuickKit.Cmd.Menu;

namespace QuickKit.Sample.Cmd.Menus.Shared;
internal abstract class MenuSecundary : MenuSub
{
    protected override string NotNullAlertMessage { get; set; } = "Digite algo válido";

    public override abstract void GoToOption(int option);

    public override void Show()
    {
        ShowPreviousOption();
        ShowOptions();
        var option = SelectOption();
        GoToOption(option);
    }

    public override abstract void ShowOptions();

    public override void ShowPreviousOption()
    {
        Consoler.WriteLine("0 - Voltar");
    }
}
