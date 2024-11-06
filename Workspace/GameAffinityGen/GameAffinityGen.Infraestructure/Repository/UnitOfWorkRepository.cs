

using GameAffinityGen.ApplicationCore.IRepository.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using GameAffinityGen.Infraestructure.CP;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameAffinityGen.Infraestructure.Repository
{
public class UnitOfWorkRepository : GenericUnitOfWorkRepository
{
SessionCPNHibernate session;


public UnitOfWorkRepository(SessionCPNHibernate session)
{
        this.session = session;
}

public override IRegistradoRepository RegistradoRepository {
        get
        {
                this.registradorepository = new RegistradoRepository ();
                this.registradorepository.setSessionCP (session);
                return this.registradorepository;
        }
}

public override IModeradorRepository ModeradorRepository {
        get
        {
                this.moderadorrepository = new ModeradorRepository ();
                this.moderadorrepository.setSessionCP (session);
                return this.moderadorrepository;
        }
}

public override IListaRepository ListaRepository {
        get
        {
                this.listarepository = new ListaRepository ();
                this.listarepository.setSessionCP (session);
                return this.listarepository;
        }
}

public override IResenyaRepository ResenyaRepository {
        get
        {
                this.resenyarepository = new ResenyaRepository ();
                this.resenyarepository.setSessionCP (session);
                return this.resenyarepository;
        }
}

public override IValoracionRepository ValoracionRepository {
        get
        {
                this.valoracionrepository = new ValoracionRepository ();
                this.valoracionrepository.setSessionCP (session);
                return this.valoracionrepository;
        }
}

public override IEmpresaRepository EmpresaRepository {
        get
        {
                this.empresarepository = new EmpresaRepository ();
                this.empresarepository.setSessionCP (session);
                return this.empresarepository;
        }
}

public override IIndividuoRepository IndividuoRepository {
        get
        {
                this.individuorepository = new IndividuoRepository ();
                this.individuorepository.setSessionCP (session);
                return this.individuorepository;
        }
}

public override IVideojuegoRepository VideojuegoRepository {
        get
        {
                this.videojuegorepository = new VideojuegoRepository ();
                this.videojuegorepository.setSessionCP (session);
                return this.videojuegorepository;
        }
}

public override IInteraccionRepository InteraccionRepository {
        get
        {
                this.interaccionrepository = new InteraccionRepository ();
                this.interaccionrepository.setSessionCP (session);
                return this.interaccionrepository;
        }
}
}
}

