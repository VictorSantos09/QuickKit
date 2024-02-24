using QuickKit.Cmd;

namespace QuickKit.Sample.Console.Menus.Funcionario
{
    internal class FuncionarioCadastroMenu : IMenu
    {
        public void Show()
        {
            Writer.WriteLine("cadastrando funcionário");
        }
    }
}
