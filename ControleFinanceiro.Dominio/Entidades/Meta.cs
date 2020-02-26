using ControleFinanceiro.Dominio.Enums;

namespace ControleFinanceiro.Dominio.Entidades
{
    public class Meta
    {
        public Meta()
        {

        }

        public Meta(int id, string destino, float procentagem, ETipoMeta tipo)
        {
            this.Id = id;
            this.Destino = destino;
            this.Porcentagem = procentagem;
            this.Tipo = tipo;
        }

        public int Id { get; set; }
        public string Destino { get; set; }
        public float Porcentagem { get; set; }
        public ETipoMeta Tipo { get; set; }
    }
}
