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
        private static IRepositorioMascota _repoMascota = new RepositorioMascota(new Persistencia.AppContext());
        private static IRepositorioHistoria _repoHistoria = new RepositorioHistoria(new Persistencia.AppContext());
        private static IRepositorioVisitaPyP _repoVisitaPyP = new RepositorioVisitaPyP(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Procesado!");

            //AddDueno();               // Método para agregar un dueño
            //BuscarDueno(1);        // Método para buscar un dueño
            //ListarDuenos();       // Método para listar un dueño

            //AddVeterinario();             // Método para agregar un Veterinario
            //BuscarVeterinario();        // Método para buscar un Veterinario
            //ListarVeterinarios();       // Método para listar un Veterinario

            //AddMascota();           // Método para agregar una Mascota
            //BuscarMascota(2);        // Método para buscar una Mascota
            //ListarMascotas();       // Método para listar una Mascota
            //AsignarVeterinario();      // Método para asignar un Veterinario a una Mascota
            //AsignarDueno();            // Método para asignar un Dueño a una Mascota
            AsignarHistoria();         // Método para asignar una Historia clínica a una Mascota

            //AddHistoria();
            //AddVisitaPyP();
            //
        }

        //----------------------------- DUEÑO -----------------------------------------//

        private static void AddDueno()      // AGREGAR UN NUEVO DUEÑO
        {
            var dueno = new Dueno
            {
                //Cedula = "1212",
                Nombres = "Walter",
                Apellidos = "White",
                Direccion = "308 Negro Arroyo Lane",
                Telefono = "61051142",
                Correo = "wwbbbcs@gmail.com"
            };
            _repoDueno.AddDueno(dueno);
        }

        private static void BuscarDueno(int idDueno)    // BUSCAR UN DUEÑO
        {
            var dueno = _repoDueno.GetDueno(idDueno);
            Console.WriteLine(dueno.Id + " " + dueno.Nombres + " " + dueno.Apellidos + " " + dueno.Direccion + " " + dueno.Telefono + " " + dueno.Correo);
        }

        private static void ListarDuenos()          // LISTAR DUEÑOS
        {
            var duenos = _repoDueno.GetAllDuenos();
            foreach (Dueno d in duenos)
            {
                Console.WriteLine(d.Nombres + " " + d.Apellidos);
            }
        }


        //----------------------------- VETERINARIO -----------------------------------------//

        private static void AddVeterinario()            // AGREGAR UN NUEVO VETERINARIO
        {
            var veterinario = new Veterinario
            {
                //Cedula = "1212",
                Nombres = "Jesus",
                Apellidos = "Ariza",
                Direccion = "Calle Falsa 123456",
                Telefono = "3454584",
                TarjetaProfesional = "T454500"
            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        private static void BuscarVeterinario(int idVeterinario)    // BUSCAR UN VETERINARIO
        {
            var veterinario = _repoVeterinario.GetVeterinario(idVeterinario);
            Console.WriteLine(veterinario.Id + " " + veterinario.Nombres + " " + veterinario.Apellidos + " " + veterinario.Direccion + " " + veterinario.Telefono + " " + veterinario.TarjetaProfesional);
        }

        private static void ListarVeterinarios()          // LISTAR VETERINARIOS
        {
            var veterinarios = _repoVeterinario.GetAllVeterinarios();
            foreach (Veterinario v in veterinarios)
            {
                Console.WriteLine(v.Nombres + " " + v.Apellidos);
            }
        }


                //----------------------------- MASCOTA -----------------------------------------//

        private static void AddMascota()                // AGREGAR UNA NUEVA MASCOTA
        {
            var mascota = new Mascota
            {
                //Cedula = "1212",
                Nombre = "Leo",
                Color = "Negro-Amarillo",
                Especie = "Canina",
                Raza = "Pastor Aleman",
            };
            _repoMascota.AddMascota(mascota);
        }

        private static void BuscarMascota(int idMascota)    // BUSCAR UNA MASCOTA
        {
            var mascota = _repoMascota.GetMascota(idMascota);
            Console.WriteLine(mascota.Nombre + " " + mascota.Color + " " + mascota.Especie + " " + mascota.Raza);
        }

        private static void ListarMascotas()          // LISTAR MASCOTAS
        {
            var mascotas = _repoMascota.GetAllMascotas();
            foreach (Mascota m in mascotas)
            {
                Console.WriteLine("Nombre: " + m.Nombre + "  " + "Color: " + m.Color + "  " + "Especie: " + m.Especie + "  " + "Raza: " + m.Raza);
            }
        }

        private static void AsignarVeterinario()        // ASIGNAR UN VETERINARIO A UNA MASCOTA
        {
            var veterinario = _repoMascota.AsignarVeterinario(1, 7);
            Console.WriteLine(veterinario.Nombres + " " + veterinario.Apellidos);
        }

        private static void AsignarDueno()        // ASIGNAR UN DUENO A UNA MASCOTA
        {
            var dueno = _repoMascota.AsignarDueno(1, 5);
            Console.WriteLine(dueno.Nombres + " " + dueno.Apellidos);
        }

        private static void AsignarHistoria()        // ASIGNAR UNA HISTORIA A UNA MASCOTA
        {
            var historia = _repoMascota.AsignarHistoria(3, 3);
            Console.WriteLine(historia.Id + " " + historia.FechaInicial);
        }


                //----------------------------- HISTORIA -----------------------------------------//

        private static void AddHistoria()                       // AGREGAR UNA NUEVA HISTORIA
        {
            var historia = new Historia
            {
                FechaInicial = new DateTime(2022, 08, 23)
            };
            _repoHistoria.AddHistoria(historia);
        }
        
        private static void AsignarVisitaPyP(int idHistoria)    // ASIGNAR UNA VISITA A UNA HISTORIA CLÍNICA
        {
            var historia = _repoHistoria.GetHistoria(idHistoria);
            if (historia != null)
            {
                if (historia.VisitasPyP != null)
                {
                    historia.VisitasPyP.Add(new VisitaPyP { FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", Recomendaciones = "Dieta extrema"});
                }
                else
                {
                    historia.VisitasPyP = new List<VisitaPyP>{
                        new VisitaPyP{FechaVisita = new DateTime(2020, 01, 01), Temperatura = 38.0F, Peso = 30.0F, FrecuenciaRespiratoria = 71.0F, FrecuenciaCardiaca = 71.0F, EstadoAnimo = "Muy cansón", Recomendaciones = "Dieta extrema" }
                    };
                }
                _repoHistoria.UpdateHistoria(historia);
            }
        }


                //----------------------------- VISITAPYP -----------------------------------------//

        private static void AddVisitaPyP()                       // AGREGAR UNA NUEVA VISITA PYP
        {
            var visitaPyP = new VisitaPyP
            {
                FechaVisita = new DateTime(2022, 01, 01),
                Temperatura = 30.4F,
                Peso = 84F,
                FrecuenciaRespiratoria = 112F,
                FrecuenciaCardiaca = 64F,
                EstadoAnimo = "Contento",
                IdVeterinario = 4545,
                Recomendaciones = "Comer pollito"
            };
            _repoVisitaPyP.AddVisitaPyP(visitaPyP);
        }   

        
    }
}
