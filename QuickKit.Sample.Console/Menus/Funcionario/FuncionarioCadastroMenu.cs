using QuickKit.Cmd;
using QuickKit.Cmd.Enums;
using QuickKit.Cmd.Menu;

namespace QuickKit.Sample.Cmd.Menus.Funcionario
{
    internal class FuncionarioCadastroMenu : MenuNoOption
    {
        public override void Show()
        {
            Consoler.WriteLine("cadastrando funcionario...", AlertType.Success);
        }
    }
}
