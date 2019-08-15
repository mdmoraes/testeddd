using AgendaContato.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaContato.Domain.Interfaces.Repositories
{
    interface IContatoRepository : IRepositoryBase<Contato>
    {
        IEnumerable<Contato> BuscarPorNome(string nome);
    }
}
