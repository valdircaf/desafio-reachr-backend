
namespace api.Model
{
    public class Vagas
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Descricao { get; set; }

        public required string Cidade { get; set; }

        public required string Uf { get; set; }

        public required float Sallary { get; set; }
    }
}