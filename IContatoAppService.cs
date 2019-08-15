using System;
using AgendaContato.Domain.Entities;


namespace AgendaContato.Application.Interface
{
    public interface IContatoAppService : IAppServiceBase<Contato>
    {
        IEnumerable<Contato> BuscarPorNome(string nome);
    }
}
