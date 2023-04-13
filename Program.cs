using System.Security.Cryptography.X509Certificates;

internal class BooksDatabase
{
    public static void Main(string[] args)
    {
        BooksDatabase biblioteca = new BooksDatabase();
        biblioteca.MenuPrincipal();       
    }

    public string[,] libros = new string[1000, 2]; // uso [,] (y no [][]) para tener todos los datos de los libros
    public int n = 0; // libros almacenados

    public void MenuPrincipal()
    {
        Console.WriteLine("BIBLIOTECA");
        Console.WriteLine("Menú principal:");
        Console.WriteLine("1) Agregar un libro");
        Console.WriteLine("2) Mostrar todos los libros");
        Console.WriteLine("3) Buscar un libro");
        Console.WriteLine("4) Eliminar un libro en una posición concreta");
        Console.WriteLine("5) Salir del programa");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                AgregarLibro();
                break;
            case "2":
                MostrarLibros();
                break;
            case "3":
                BuscarLibro();
                break;
            case "4":
                EliminarLibro();
                break;
            case "5":
                break;
            default:
                Console.WriteLine("Opción no válida, prueba de nuevo");
                return;
        }
    }

    public void AgregarLibro()
    {
        if (n < 1000)
        {
            Console.WriteLine("Ingresa el título del libro: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Ingresa el autor del libro: ");
            string autor = Console.ReadLine();
            libros[n, 0] = titulo;
            libros[n, 1] = autor;
            n++;

            Console.WriteLine("Ingresa 1 para volver al menú principal, 2 para repetir la operación u otro carácter para salir: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPrincipal();
                    break;
                case "2":
                    AgregarLibro();
                    break;
                default:
                    break;
            }
        }
        else
        {
            Console.WriteLine("Almacenamiento lleno. Debes borrar un libro para ingresar uno nuevo");
            Console.WriteLine("Ingresa 1 para volver al menú principal u otro carácter para salir: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPrincipal();
                    break;
                default:
                    break;
            }
        }
    }

    public void MostrarLibros()
    {
        if (n != 0)
        {
            Console.WriteLine("Lista de los libros almacenados en la biblioteca:");
            Console.WriteLine("Formato: Posición) Título. Autor");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{(i+1)}) {libros[i,0]}. {libros[i,1]}");
            }
            Console.WriteLine("Fin");
        }
        else
        {
            Console.WriteLine("No hay libros en la biblioteca actualmente");
        }

        Console.WriteLine("Ingresa 1 para volver al menú principal u otro carácter para salir: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                MenuPrincipal();
                break;
            default:
                break;
        }
    }

    public void BuscarLibro()
    {

        if (n != 0)
        {
            Console.WriteLine("¿Cómo quieres buscar el libro?");
            Console.WriteLine("1) Por la posición");
            Console.WriteLine("2) Por el título");
            Console.WriteLine("3) Por el autor");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    BuscarPosicion();
                    break;
                case "2":
                    BuscarTitulo();
                    break;
                case "3":
                    BuscarAutor();
                    break;
                default:
                    Console.WriteLine("Opción no válida, prueba de nuevo");
                    BuscarLibro();
                    break;
            }

            Console.WriteLine("Ingresa 1 para volver al menú principal, 2 para repetir la operación u otro carácter para salir: ");
            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPrincipal();
                    break;
                case "2":
                    BuscarLibro();
                    break;
                default:
                    break;
            }
        }
        else
        {
            Console.WriteLine("No hay libros en la biblioteca actualmente");

            Console.WriteLine("Ingresa 1 para volver al menú principal u otro carácter para salir: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPrincipal();
                    break;
                default:
                    break;
            }       
        }
    }

    public void BuscarPosicion()
    {
        Console.WriteLine("Ingresa una posición para conocer qué libro la ocupa: ");
        int posicion;

        if (int.TryParse(Console.ReadLine(), out posicion))
        {
            if (posicion > 0 && posicion <= 1000)
            {
                Console.WriteLine($"{(posicion)}) {libros[posicion-1, 0]}. {libros[posicion-1, 1]}");
            }
            else
            {
                Console.WriteLine("Ingresa un número entre 0 y 1000");
                BuscarPosicion();
            }
        }
        else
        {
            Console.WriteLine("Error. Ingresa un número");
            BuscarPosicion();
        }

        Console.WriteLine("Ingresa 1 para volver al menú principal, 2 para repetir la operación u otro carácter para salir: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                MenuPrincipal();
                break;
            case "2":
                BuscarLibro();
                break;
            default:
                break;
        }
    }

    public void BuscarTitulo()
    {
        Console.WriteLine("Ingresa un título: ");
        string titulo = Console.ReadLine();

        bool existe = false;
        for (int i = 0; i < n; i++)
        {
            if (libros[i,0] == titulo)
            {
                existe = true;
                Console.WriteLine("${i+1}) {libros[i, 0]}. {libros[i, 1]}");
            }
        }

        if (!existe)
        {
            Console.WriteLine("No existen libros con ese título");
        }

        Console.WriteLine("Ingresa 1 para volver al menú principal, 2 para repetir la operación u otro carácter para salir: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                MenuPrincipal();
                break;
            case "2":
                BuscarLibro();
                break;
            default:
                break;
        }

    }

    public void BuscarAutor()
    {
        Console.WriteLine("Ingresa un autor: ");
        string autor = Console.ReadLine();

        bool existe = false;
        for (int i = 0; i < n; i++)
        {
            if (libros[i, 1] == autor)
            {
                existe = true;
                Console.WriteLine("${i+1}) {libros[i, 0]}. {libros[i, 1]}");
            }
        }

        if (!existe)
        {
            Console.WriteLine("No existen libros con ese autor");
        }

        Console.WriteLine("Ingresa 1 para volver al menú principal, 2 para repetir la operación u otro carácter para salir: ");
        string opcion = Console.ReadLine();

        switch (opcion)
        {
            case "1":
                MenuPrincipal();
                break;
            case "2":
                BuscarLibro();
                break;
            default:
                break;
        }
    }

    public void EliminarLibro()
    {
        if (n != 0)
        {
            Console.WriteLine("¿Sabes en qué posición se encuentra el libro que quieres eliminar? Ingresa si o no:");
            string continuar = Console.ReadLine();


            if (continuar == "si")
            {
                Console.WriteLine("Ingresa la posición del libro que quieres eliminar");
                int posicion;

                if (int.TryParse(Console.ReadLine(), out posicion))
                {
                    if (posicion > 0 && posicion <= n)
                    {
                        for (int i = posicion-1; i < n-1; i++)
                        {
                            libros[i, 0] = libros[i+1, 0];
                            libros[i, 1] = libros[i+1, 1];
                        }

                        n--;

                        Console.WriteLine($"El libro se ha eliminado");
                    }
                    else
                    {
                        Console.WriteLine("Ingresa un número válido");
                        EliminarLibro();
                    }
                }
                else
                {
                    Console.WriteLine("Error. Ingresa un número");
                    EliminarLibro();
                }
            }
            else if(continuar == "no")
            {
                Console.WriteLine("Necesitas conocer en qué posición se encuentra el libro para poder eliminarlo");
                Console.WriteLine("Ingresa 1 para mostrar la lista completa de libros almacenados");
                Console.WriteLine("Ingresa 2 para buscar un libro por posición, título o autor");
                Console.WriteLine("Ingresa cualquier otro carácter para salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MostrarLibros();
                        break;
                    case "2":
                        BuscarLibro();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Error. Escribe si o no");
                EliminarLibro();
            }
        }
        else
        {
            Console.WriteLine("No hay libros en la biblioteca actualmente");

            Console.WriteLine("Ingresa 1 para volver al menú principal u otro carácter para salir: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    MenuPrincipal();
                    break;
                default:
                    break;
            }
        }
    }
}
