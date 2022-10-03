using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioHistoria : IRepositorioHistoria
    {
        /// <summary>
        /// Referencia al contexto de Historia
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());

        public RepositorioHistoria(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Historia AddHistoria(Historia historia)
        {
            var historiaAdicionado = _appContext.Historias.Add(historia);
            _appContext.SaveChanges();
            return historiaAdicionado.Entity;
        }

        public void DeleteHistoria(int idHistoria)
        {
            var historiaEncontrado = _appContext.Historias.FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrado == null)
                return;
            _appContext.Historias.Remove(historiaEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Historia> GetAllHistorias()
        {
            return _appContext.Historias; 
        }

        IEnumerable<VisitaPyP> IRepositorioHistoria.GetVisitasHistoria(int idHistoria)
        {
            var historia = _appContext.Historias.Where(h => h.Id == idHistoria)
                                                .Include(h => h.VisitasPyP)
                                                .FirstOrDefault();
            return historia.VisitasPyP;
        }

        public Historia GetHistoria(int idHistoria)
        {
            return _appContext.Historias.Include(a => a.VisitasPyP).FirstOrDefault(d => d.Id == idHistoria);
        }

        public Historia UpdateHistoria(int idVisitaPyP, int idHistoria)
        {
            var historiaEncontrado = _appContext.Historias.Include("VisitasPyP").FirstOrDefault(d => d.Id == idHistoria);
            if (historiaEncontrado != null)
            {
                if (historiaEncontrado.VisitasPyP !=null)
                {
                    historiaEncontrado.VisitasPyP.Add(_repoVisitaPyP.GetVisitaPyP(idVisitaPyP));
                    _appContext.SaveChanges();
                }
                else
                {
                    historiaEncontrado.VisitasPyP = new List<VisitaPyP>();
                    historiaEncontrado.VisitasPyP.Add (_repoVisitaPyP.GetVisitaPyP(idVisitaPyP));
                    _appContext.SaveChanges();
                }

                _appContext.SaveChanges();
            }
            return historiaEncontrado;
        }     

    }
    
}
