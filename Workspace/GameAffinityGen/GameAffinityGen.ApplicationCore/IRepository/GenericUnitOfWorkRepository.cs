
using System;
using System.Collections.Generic;
using System.Text;

namespace GameAffinityGen.ApplicationCore.IRepository.GameAffinity
{
public abstract class GenericUnitOfWorkRepository
{
protected IRegistradoRepository registradorepository;
protected IModeradorRepository moderadorrepository;
protected IListaRepository listarepository;
protected IResenyaRepository resenyarepository;
protected IValoracionRepository valoracionrepository;
protected IEmpresaRepository empresarepository;
protected IIndividuoRepository individuorepository;
protected IVideojuegoRepository videojuegorepository;
protected IInteraccionRepository interaccionrepository;


public abstract IRegistradoRepository RegistradoRepository {
        get;
}
public abstract IModeradorRepository ModeradorRepository {
        get;
}
public abstract IListaRepository ListaRepository {
        get;
}
public abstract IResenyaRepository ResenyaRepository {
        get;
}
public abstract IValoracionRepository ValoracionRepository {
        get;
}
public abstract IEmpresaRepository EmpresaRepository {
        get;
}
public abstract IIndividuoRepository IndividuoRepository {
        get;
}
public abstract IVideojuegoRepository VideojuegoRepository {
        get;
}
public abstract IInteraccionRepository InteraccionRepository {
        get;
}
}
}
