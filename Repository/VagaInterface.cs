using api.Model;

namespace api.Repository
{
    public interface VagaInterface
    {
        Task<IEnumerable<Vagas>> GetVagas();

        Task<Vagas> GetVaga(int id);

        void NewVaga(Vagas vaga);

        void UpdateVaga(Vagas vaga);

        void DeleteVaga(Vagas vaga);

        Task<bool> SaveChangesAsync();

    }
}