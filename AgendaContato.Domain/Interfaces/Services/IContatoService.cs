using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaContato.Domain.Entities;

namespace AgendaContato.Domain.Interfaces.Services
{
    interface IContatoService: IServiceBase<Contato>
    {
        IEnumerable<Contato> BuscarPorNome(string nome);
    }
}
