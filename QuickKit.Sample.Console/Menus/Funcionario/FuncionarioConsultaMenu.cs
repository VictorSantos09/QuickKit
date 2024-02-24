using QuickKit.Cmd;

namespace QuickKit.Sample.Console.Menus.Funcionario;

internal class FuncionarioConsultaMenu : IMenuView
{
    public void Show()
    {
        Writer.WriteLine("apresentando funcionários");
    }
}
