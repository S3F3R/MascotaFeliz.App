using System;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using System.Collections.Generic;

namespace MascotaFeliz.App.Consola
{
    class Program
    {

        private static IRepositorioDueno _repoDueno = new RepositorioDueno(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hola amigos vamos a empezar a trabajar con las tablas");
                       
            //ListarDuenosFiltro();      
            //AddDueno();
            //BuscarDueno(2);

            ListarVeterinariosFiltro();
            //AddVeterinario();
            //BuscarVeterinario(1);
            

        }

        private static void AddDueno()
        {
            var dueno = new Dueno
            {
                Nombres = "Luis Felipe",
                Apellidos = "Fadul", 
                Direccion = "Calle 1 # 1-15",
                Telefono = "4564564566",
                Correo = "fadulitomenor@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

         private static void AddVeterinario()
        {
            var veterinario = new Veterinario
            {
                Nombres = "Peter",
                Apellidos = "Pan", 
                Direccion = "Transversal 9 # 17A-155",
                Telefono = "3363365858",
                TarjetaProfesional = "TP52546"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void BuscarDueno(int idDueno)
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void BuscarVeterinario(int idVeterinario)
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void ListarDuenosFiltro()
        {
            var duenosM = _repoDueno.GetDuenosPorFiltro("Fel");
            foreach (Dueno p in duenosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }

        private static void ListarVeterinariosFiltro()
        {
            var veterinariosM = _repoVeterinario.GetVeterinariosPorFiltro("e");
            foreach (Veterinario p in veterinariosM)
            {
                Console.WriteLine(p.Nombres + " " + p.Apellidos);
            }

        }


        
        
    }
}
