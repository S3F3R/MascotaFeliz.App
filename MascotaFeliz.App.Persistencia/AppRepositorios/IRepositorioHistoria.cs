using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;

namespace MascotaFeliz.App.Persistencia
{
    public interface IRepositorioHistoria
    {
        IEnumerable<Historia> GetAllHistorias();
        Historia AddHistoria(Historia historia);
        Historia UpdateHistoria(int idVisitaPyP, int idHistoria);
        void DeleteHistoria(int idHistoria);
        Historia GetHistoria(int idHistoria);
        IEnumerable<VisitaPyP> GetVisitasHistoria(int idHistoria);
        
    }
}