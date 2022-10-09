using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeVenta
{
    class main
    {
        static void Main(string[] args)
       {
        int op1 = 0;
        Console.ReadLine();
        herramienta control = new herramienta();
        
        Console.WriteLine("Bienvenido al sistema de gestion de Casas");
        Console.WriteLine("1. Ingresar como Administrador");
        Console.WriteLine("2. Ingresar como Cliente");
        Console.WriteLine("3. Salir");
        Console.WriteLine("Ingrese una opcion");
        op1 = int.Parse(Console.ReadLine());
        switch (op1)
        {
            case 1:
            {
                Console.WriteLine("Accediendo al menu de administrador");
                control.menuAdmin();
                break;
            }
            case 2:
            {
                Console.WriteLine("Accediendo al menu de cliente");
                control.menuCliente();
                break;
            }
            case 3:
            {
                Console.WriteLine("Saliendo del sistema");
                break;
            }
        }

        while (op1 != 3)
        {
           Console.ReadLine();
        }
    } 
}
}