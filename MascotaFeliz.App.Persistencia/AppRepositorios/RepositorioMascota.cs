using System;
using System.Collections.Generic;
using System.Linq;
using MascotaFeliz.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace MascotaFeliz.App.Persistencia
{
    public class RepositorioMascota : IRepositorioMascota
    {
        /// <summary>
        /// Referencia al contexto de Dueno
        /// </summary>
        private readonly AppContext _appContext;
        /// <summary>
        /// Metodo Constructor Utiiza 
        /// Inyeccion de dependencias para indicar el contexto a utilizar
        /// </summary>
        /// <param name="appContext"></param>//
        public RepositorioMascota(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Mascota AddMascota(Mascota mascota)
        {
            var macotaAdicionada = _appContext.Mascotas.Add(mascota);
            _appContext.SaveChanges();
            return macotaAdicionada.Entity;
        }

        public void DeleteMascota(int idMascota)
        {
            var MascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
            if (MascotaEncontrada == null)
                return;
            _appContext.Mascotas.Remove(MascotaEncontrada);
            _appContext.SaveChanges();
        }

       public IEnumerable<Mascota> GetAllMascotas()
        {
            return GetAllMascotas_();
        }

        public IEnumerable<Mascota> GetMascotasPorFiltro(string filtro)
        {
            var mascotas = GetAllMascotas(); // Obtiene todos los saludos
            if (mascotas != null)  //Si se tienen saludos
            {
                if (!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algun valor
                {
                    mascotas = mascotas.Where(s => s.Nombre.Contains(filtro));
                }
            }
            return mascotas;
        }

        public IEnumerable<Mascota> GetAllMascotas_()
        {
            return _appContext.Mascotas;
        }

        public Mascota GetMascota(int idMascota)
        {
            return _appContext.Mascotas.FirstOrDefault(d => d.Id == idMascota);
        }

        public Mascota UpdateMascota(Mascota mascota)
        {
            var MascotaEncontrada = _appContext.Mascotas.FirstOrDefault(d => d.Id == mascota.Id);
            if (MascotaEncontrada != null)
            {
                MascotaEncontrada.Nombre = mascota.Nombre;
                MascotaEncontrada.Color = mascota.Color;
                MascotaEncontrada.Especie = mascota.Especie;
                MascotaEncontrada.Raza = mascota.Raza;
                _appContext.SaveChanges();
            }
            return MascotaEncontrada;
        }     
    }
}