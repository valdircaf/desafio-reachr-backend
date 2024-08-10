using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class VagaRepository : VagaInterface
    {
        private readonly VagaContext context;
        public VagaRepository(VagaContext context)
        {
            this.context = context;
        }
        public void DeleteVaga(Vagas vaga)
        {
            this.context.Remove(vaga);
        }

        public async Task<Vagas> GetVaga(int id)
        {
            return await this.context.Vagas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Vagas>> GetVagas()
        {
            return await this.context.Vagas.ToListAsync();
        }

        public void NewVaga(Vagas vaga)
        {
            this.context.Add(vaga);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public void UpdateVaga(Vagas vaga)
        {
            this.context.Update(vaga);
        }
    }
}