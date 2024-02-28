using QuickKit.Shared.Entities;

namespace QuickKit.Sample.API.Entities;

public class CargaEntity : IEntity
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public bool Ativo { get; set; }

    public CargaEntity(string nome, string descricao, DateTime dataCadastro, DateTime dataAtualizacao, bool ativo)
    {
        Nome = nome;
        Descricao = descricao;
        DataCadastro = dataCadastro;
        DataAtualizacao = dataAtualizacao;
        Ativo = ativo;
    }
}
