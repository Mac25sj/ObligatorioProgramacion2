using Dominio;
using System;
using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Sistema
{

private List<Equipo> _equipos = new List<Equipo>();
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Pago> _pagos = new List<Pago>();
   private List<TipoDeGasto> _gastos = new List<TipoDeGasto>();
    public Sistema()
    {
        precargaDeEquipos();
        precargaDeUsuarios();
        precargaDeTiposDeGastos();
        precargaDePagos();


    }

    private void precargaDeEquipos()
    {
        string[] nombresEquipos = { "Ventas", "Marketing", "RRHH", "Desarrollo" };
        foreach (var nombre in nombresEquipos)
        {
            altaEquipo(nombre);
        }
    }

    private void precargaDeUsuarios()
    {
        altaUsuario("Juan", "Pérez", "pass01", "Ventas", new DateTime(2025, 01, 10));
        altaUsuario("María", "Gómez", "pass02", "Marketing", new DateTime(2025, 02, 15));
        altaUsuario("Luis", "Rodríguez", "pass03", "RRHH", new DateTime(2025, 03, 20));
        altaUsuario("Ana", "Fernández", "pass04", "Desarrollo", new DateTime(2025, 04, 25));
        altaUsuario("Carlos", "López", "pass05", "Ventas", new DateTime(2025, 05, 30));
        altaUsuario("Laura", "Martínez", "pass06", "Marketing", new DateTime(2025, 06, 05));
        altaUsuario("Diego", "Sánchez", "pass07", "RRHH", new DateTime(2025, 07, 10));
        altaUsuario("Sofía", "Ramírez", "pass08", "Desarrollo", new DateTime(2025, 08, 15));
        altaUsuario("Pedro", "Torres", "pass09", "Ventas", new DateTime(2025, 09, 20));
        altaUsuario("Valentina", "Flores", "pass10", "Marketing", new DateTime(2025, 09, 30));
        altaUsuario("Martín", "Silva", "pass11", "RRHH", new DateTime(2025, 09, 30));
        altaUsuario("Camila", "Castro", "pass12", "Desarrollo", new DateTime(2025, 09, 30));
        altaUsuario("Joaquín", "Ramos", "pass13", "Ventas", new DateTime(2025, 01, 10));
        altaUsuario("Lucía", "Vega", "pass14", "Marketing", new DateTime(2025, 02, 15));
        altaUsuario("Federico", "Molina", "pass15", "RRHH", new DateTime(2025, 03, 20));
        altaUsuario("Julieta", "Acosta", "pass16", "Desarrollo", new DateTime(2025, 04, 25));
        altaUsuario("Tomás", "Reyes", "pass17", "Ventas", new DateTime(2025, 05, 30));
        altaUsuario("Agustina", "Cabrera", "pass18", "Marketing", new DateTime(2025, 06, 05));
        altaUsuario("Emiliano", "Suárez", "pass19", "RRHH", new DateTime(2025, 07, 10));
        altaUsuario("Bianca", "Morales", "pass20", "Desarrollo", new DateTime(2025, 08, 15));
        altaUsuario("Mateo", "Navarro", "pass21", "Ventas", new DateTime(2025, 09, 20));
        altaUsuario("Isabella", "Ortega", "pass22", "Marketing", new DateTime(2025, 09, 30));


    }

    private void precargaDePagos()
    {
        altaPagoUnico(new Unico(new DateTime(2025, 01, 10), 1001, TipoDePago.CREDITO, _gastos[1], 1150, _usuarios[1])); 
        altaPagoUnico(new Unico(new DateTime(2025, 02, 15), 1002, TipoDePago.DEBITO, _gastos[6], 1300, _usuarios[2])); 
        altaPagoUnico(new Unico(new DateTime(2025, 03, 20), 1003, TipoDePago.EFECTIVO, _gastos[11], 1450, _usuarios[3])); 
        altaPagoUnico(new Unico(new DateTime(2025, 04, 25), 1004, TipoDePago.CREDITO, _gastos[16], 1600, _usuarios[4])); 
        altaPagoUnico(new Unico(new DateTime(2025, 05, 30), 1005, TipoDePago.DEBITO, _gastos[2], 1750, _usuarios[5])); 
        altaPagoUnico(new Unico(new DateTime(2025, 06, 05), 1006, TipoDePago.EFECTIVO, _gastos[7], 1900, _usuarios[6])); 
        altaPagoUnico(new Unico(new DateTime(2025, 07, 10), 1007, TipoDePago.CREDITO, _gastos[12], 2050, _usuarios[7])); 
        altaPagoUnico(new Unico(new DateTime(2025, 08, 15), 1008, TipoDePago.DEBITO, _gastos[17], 2200, _usuarios[8])); 
        altaPagoUnico(new Unico(new DateTime(2025, 09, 20), 1009, TipoDePago.EFECTIVO, _gastos[3], 2350, _usuarios[9]));
        altaPagoUnico(new Unico(new DateTime(2025, 09, 30), 1010, TipoDePago.CREDITO, _gastos[8], 2500, _usuarios[10])); 
        altaPagoUnico(new Unico(new DateTime(2025, 09, 30), 1011, TipoDePago.DEBITO, _gastos[13], 2650, _usuarios[11])); 
        altaPagoUnico(new Unico(new DateTime(2025, 09, 01), 1012, TipoDePago.EFECTIVO, _gastos[14], 10300, _usuarios[1]));
        altaPagoUnico(new Unico(new DateTime(2025, 09, 02), 1013, TipoDePago.CREDITO, _gastos[15], 10450, _usuarios[2]));
        altaPagoUnico(new Unico(new DateTime(2025, 09, 03), 1014, TipoDePago.DEBITO, _gastos[16], 10600, _usuarios[3]));
        altaPagoUnico(new Unico(new DateTime(2025, 09, 04), 1015, TipoDePago.EFECTIVO, _gastos[17], 10750, _usuarios[4]));
        altaPagoUnico(new Unico(new DateTime(2025, 09, 05), 1016, TipoDePago.CREDITO, _gastos[18], 10900, _usuarios[5]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 06, 01), new DateTime(2025, 09, 01), TipoDePago.EFECTIVO, _gastos[18], 2800, _usuarios[12])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 06, 15), new DateTime(2025, 09, 05), TipoDePago.CREDITO, _gastos[4], 2950, _usuarios[13])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 07, 01), new DateTime(2025, 09, 06), TipoDePago.DEBITO, _gastos[9], 3100, _usuarios[14])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 07, 15), new DateTime(2025, 09, 07), TipoDePago.EFECTIVO, _gastos[14], 3250, _usuarios[15]));  
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 08, 01), new DateTime(2025, 09, 08), TipoDePago.CREDITO, _gastos[19], 3400, _usuarios[16]));  
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 06), new DateTime(2025, 12, 06), TipoDePago.DEBITO, _gastos[5], 3550, _usuarios[17])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 07), new DateTime(2025, 12, 07), TipoDePago.EFECTIVO, _gastos[10], 3700, _usuarios[18])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 08), new DateTime(2025, 12, 08), TipoDePago.CREDITO, _gastos[15], 3850, _usuarios[19])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 09), new DateTime(2025, 12, 09), TipoDePago.DEBITO, _gastos[20], 4000, _usuarios[20])); 
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 06, 01), new DateTime(2025, 09, 01), TipoDePago.CREDITO, _gastos[21], 7400, _usuarios[1]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 06, 15), new DateTime(2025, 09, 05), TipoDePago.DEBITO, _gastos[22], 7550, _usuarios[2]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 07, 01), new DateTime(2025, 09, 06), TipoDePago.EFECTIVO, _gastos[23], 7700, _usuarios[3]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 07, 15), new DateTime(2025, 09, 07), TipoDePago.CREDITO, _gastos[24], 7850, _usuarios[4]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 08, 01), new DateTime(2025, 09, 08), TipoDePago.DEBITO, _gastos[25], 8000, _usuarios[5]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 08, 15), new DateTime(2025, 09, 09), TipoDePago.EFECTIVO, _gastos[26], 8150, _usuarios[6]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 08, 20), new DateTime(2025, 09, 10), TipoDePago.CREDITO, _gastos[27], 8300, _usuarios[7]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 11), new DateTime(2025, 12, 11), TipoDePago.DEBITO, _gastos[28], 8450, _usuarios[8]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 12), new DateTime(2025, 12, 12), TipoDePago.EFECTIVO, _gastos[29], 8600, _usuarios[9]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 13), new DateTime(2025, 12, 13), TipoDePago.CREDITO, _gastos[1], 8750, _usuarios[10]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 14), new DateTime(2025, 12, 14), TipoDePago.DEBITO, _gastos[2], 8900, _usuarios[11]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 15), new DateTime(2025, 12, 15), TipoDePago.EFECTIVO, _gastos[3], 9050, _usuarios[12]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 16), new DateTime(2025, 12, 16), TipoDePago.CREDITO, _gastos[4], 9200, _usuarios[13]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 17), new DateTime(2025, 12, 17), TipoDePago.DEBITO, _gastos[5], 9350, _usuarios[14]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 18), new DateTime(2025, 12, 18), TipoDePago.EFECTIVO, _gastos[6], 9500, _usuarios[15]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 19), new DateTime(2025, 12, 19), TipoDePago.CREDITO, _gastos[7], 9650, _usuarios[16]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 20), new DateTime(2025, 12, 20), TipoDePago.DEBITO, _gastos[8], 9800, _usuarios[17]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 21), new DateTime(2025, 12, 21), TipoDePago.EFECTIVO, _gastos[9], 9950, _usuarios[18]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 22), new DateTime(2025, 12, 22), TipoDePago.CREDITO, _gastos[10], 10100, _usuarios[19]));
        altaPagoRecurrente(new Recurrente(new DateTime(2025, 09, 23), new DateTime(2025, 12, 23), TipoDePago.DEBITO, _gastos[11], 10250, _usuarios[20]));

    }


    private void precargaDeTiposDeGastos() { 
        AltaGastosTipo("Alimentación", "Gastos relacionados con comidas y bebidas");
        AltaGastosTipo("Transporte", "Gastos relacionados con desplazamientos y transporte");
        AltaGastosTipo("Alojamiento", "Gastos relacionados con hospedaje y estadías");
        AltaGastosTipo("Entretenimiento", "Gastos relacionados con actividades recreativas y de ocio");
        AltaGastosTipo("Oficina", "Gastos relacionados con suministros y servicios de oficina");
        AltaGastosTipo("Tecnología", "Gastos relacionados con dispositivos y software tecnológico");
        AltaGastosTipo("Salud", "Gastos relacionados con servicios médicos y bienestar");
        AltaGastosTipo("Educación", "Gastos relacionados con formación y desarrollo profesional");
        AltaGastosTipo("Viajes", "Gastos relacionados con desplazamientos laborales o personales");
        AltaGastosTipo("Otros", "Gastos diversos no categorizados en otras áreas");
        AltaGastosTipo("Vestimenta", "Gastos relacionados con ropa, calzado y accesorios");
        AltaGastosTipo("Mascotas", "Gastos relacionados con el cuidado y alimentación de animales domésticos");
        AltaGastosTipo("Regalos", "Gastos relacionados con obsequios y celebraciones");
        AltaGastosTipo("Impuestos", "Gastos relacionados con tributos, tasas y contribuciones");
        AltaGastosTipo("Servicios públicos", "Gastos relacionados con agua, luz, gas y otros servicios esenciales");
        AltaGastosTipo("Mantenimiento", "Gastos relacionados con reparaciones y conservación de bienes");
        AltaGastosTipo("Hogar", "Gastos relacionados con artículos y servicios para el hogar");
        AltaGastosTipo("Seguros", "Gastos relacionados con pólizas de seguros personales o laborales");
        AltaGastosTipo("Legal", "Gastos relacionados con asesoramiento y trámites jurídicos");
        AltaGastosTipo("Financieros", "Gastos relacionados con comisiones bancarias y servicios financieros");
        AltaGastosTipo("Publicidad", "Gastos relacionados con promoción y marketing");
        AltaGastosTipo("Consultoría", "Gastos relacionados con asesoramiento profesional externo");
        AltaGastosTipo("Eventos", "Gastos relacionados con organización y participación en eventos");
        AltaGastosTipo("Donaciones", "Gastos relacionados con aportes voluntarios a organizaciones o causas");
        AltaGastosTipo("Electrodomésticos", "Gastos relacionados con compra y reparación de electrodomésticos");
        AltaGastosTipo("Recreación infantil", "Gastos relacionados con actividades y productos para niños");
        AltaGastosTipo("Suscripciones", "Gastos relacionados con servicios periódicos como revistas, plataformas digitales, etc.");
        AltaGastosTipo("Papelería", "Gastos relacionados con materiales de escritura y oficina");
        AltaGastosTipo("Comunicaciones", "Gastos relacionados con telefonía, internet y servicios de comunicación");
        AltaGastosTipo("Emergencias", "Gastos imprevistos por situaciones urgentes o excepcionales");
    }

    //Nota la nueva lista no se modifica en el sistema, solo en la copia
    public List <Usuario> Usuarios { get { return new List<Usuario>(_usuarios); } }


    //Inicio Alta Usuario
    public void altaUsuario(string nombre, string apellido, string contrasena, string pertenece, DateTime incorporacionEmpresa)
    {
        if (nombre == null ||apellido == null ||contrasena == null || pertenece == null || incorporacionEmpresa == DateTime.MinValue || !_equipos.Contains(EncontrarUnEquipo(pertenece)))
            {
            throw new Exception("Campo vacio detectado");

        }
        string email = crearEmail(nombre, apellido, pertenece);
    
        Usuario nuevoUsuario = new Usuario(nombre, apellido, contrasena, email, EncontrarUnEquipo (pertenece), incorporacionEmpresa);
        if (_usuarios.Contains(nuevoUsuario))
        {
            int posicion = nuevoUsuario.Email.IndexOf("@") ;
            nuevoUsuario.Email = nuevoUsuario.Email.Insert(posicion, "7");
        }

        _usuarios.Add(nuevoUsuario);
    }


    public void AltaGastosTipo(string nombre, string descripcion)
    {
        if (nombre == null)
        {
            throw new Exception("El nombre no puede ser nulo");
        }
        if (descripcion == null)
        {
            throw new Exception("La descriçión no puede ser nula");
        }
        TipoDeGasto nuevoTipoDeGasto = new TipoDeGasto(nombre, descripcion);
     
        _gastos.Add(nuevoTipoDeGasto);
    }


    public Equipo EncontrarUnEquipo(string Nombre)
    {
        foreach (Equipo unEquipo in _equipos)
        {
            if (unEquipo.Nombre == Nombre)
            {
                return unEquipo;
            }
        }

        return null;
        //throw new Exception("No se encontró el equipo ⚠️⚠️⚠️⚠️");


    }


    //Alta de Pago Inicio Fin 



    //Listar Pagos Inicio

    public List <Pago> ListarGastosEnElMes()
    {
        List<Pago> resultado = new List<Pago>();

        foreach (Pago unPago in _pagos)
        {
           if (unPago is Unico)
            {
                Unico pagoUnico = (Unico)unPago;
                if (pagoEsteMes(pagoUnico.FechaDePago))
                {
                    resultado.Add(pagoUnico);
                }

            }else
            {
                resultado.Add(unPago);  
            }
        }
        return resultado;
    }

    //Listar Pagos 
    public void AltaDePago(Pago unPago)
    {
        unPago.Validar();  
        _pagos.Add(unPago);
    }

       
    //Alta de Usuario


    public void altaEquipo(string nombre)
    {
        if (nombre == null)
        {
            throw new Exception("El nombre no puede ser nulo");
        }
        Equipo nuevoEquipo = new Equipo(nombre);
     
        _equipos.Add(nuevoEquipo);
    }

    //Alta de Usuario Fin


    //Altas de Pagos
    public void altaPagoUnico(Unico pagoUnico)
    {
        if (pagoUnico == null)
        {
            throw new Exception("El pago no puede ser nulo");

        }
        pagoUnico.Validar();
        _pagos.Add(pagoUnico);


    }
    public void altaPagoRecurrente(Recurrente pagoRecurrente)
    {
        if (pagoRecurrente == null)
        {
            throw new Exception("El pago no puede ser nulo");

        }
        pagoRecurrente.Validar();
        _pagos.Add(pagoRecurrente);

    }



    //Crear Email
    private string crearEmail(string nombre, string apellido, string nombreEquipo)
    {
        string resultado = "";
        for (int i = 0; i < 3; i++)
        {
            if (nombre.Length >= i)
            {
                resultado += nombre[i];
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (apellido.Length >= i)
            {
                resultado += apellido[i];
            }
        }
        resultado += $"@{nombreEquipo}";

        return resultado.ToLower();
    }
    //Crear Email Fin





    //Auxiliar


    //Chequear si el pago es de este mes
    public bool pagoEsteMes(DateTime unaFecha)
    {
        if (unaFecha > DateTime.Now.AddMonths(-1))
        {
            return true;
        }
        return false;
    }
    public List<Pago> comprasPorEmail(string email)
    {
        List<Pago> resultado = new List<Pago>();
        foreach (Pago unPago in _pagos)
        {
            if (unPago.esMiMail(email))
            {
                resultado.Add(unPago);
            }

        }
        return resultado;
    }


    public List<Usuario> EsMiEquipo (string nombreDeEquipo)
 
    {

        List<Usuario> resultado = new List<Usuario>();
        foreach (Usuario unUsuario in _usuarios)
        {
            if (unUsuario.Pertenece.Nombre == nombreDeEquipo)
            {
                resultado.Add(unUsuario);
            }
        }
        return resultado;

    }





}
