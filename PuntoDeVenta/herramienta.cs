using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PuntoDeVenta
{
    class herramienta
    {
        
        List<Casa> casas = new List<Casa>();
        int cont;
        public void cargarCasas()
        {
            string linea;
            StreamReader archivo = new StreamReader(@"C:\\Users\\ghost\\Downloads\\casas.txt");
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] datos = linea.Split(',');
                casas.Add(new Casa(Int32.Parse(datos[0]),datos[1], Int32.Parse(datos[2]), Int32.Parse(datos[3]), Double.Parse(datos[4]), datos[5], Double.Parse(datos[6]), Double.Parse(datos[7]), true));
            }
            archivo.Close();
        }

        public void guardarCasas()
        {
            try {
                StreamWriter archivo = new StreamWriter(@"C:\\Users\\ghost\\Downloads\\casas.txt");
                for (int i = 0; i < casas.Count; i++)
                {
                    String venta = "0";
                    if (casas.ElementAt(i).isEnVenta()) { venta = "1"; }
                    archivo.WriteLine(casas.ElementAt(i).getIdCasa() + "," + casas.ElementAt(i).getTipoCasa() + "," + casas.ElementAt(i).getNumCuartos() + "," + casas.ElementAt(i).getNumBanos() + "," + casas.ElementAt(i).getCosto() + "," + casas.ElementAt(i).getUbicacion() + "," + casas.ElementAt(i).getAreaConstruida() + "," + casas.ElementAt(i).getAreaTerreno() + "," + venta);
                    archivo.WriteLine("\n");
                }
                archivo.Close();
            }catch (Exception error)
        {
            Console.WriteLine("Error al guardar los datos");
        }
        }
        

    

         public void AgregarCasa()
        {
            int numCuartos, numBanos;
            String tipoCasa, ubicacion;
            double costo, areaConstruida, areaTerreno;
            cont++;

            Console.WriteLine("Ingrese el tipo de casa");
            tipoCasa = Console.ReadLine();
            Console.WriteLine("Ingrese el numero de cuartos");
            numCuartos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el numero de banos");
            numBanos = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el costo");
            costo = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese la ubicacion");
            ubicacion = Console.ReadLine();
            Console.WriteLine("Ingrese el area construida");
            areaConstruida = double.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el area terreno");
            areaTerreno = double.Parse(Console.ReadLine());

            casas.Add(new Casa(cont+1, tipoCasa, numCuartos, numBanos, costo, ubicacion, areaConstruida, areaTerreno, true));
            Console.WriteLine(" ");
            Console.WriteLine("Casa agregada");
            Console.WriteLine(casas.ElementAt(cont).ToString());
             
        }

        public void listarCasas()
        {
            for (int i = 0; i < casas.Count; i++)
            {
                Console.WriteLine(casas.ElementAt(i).ToString());
            }
        }

        public int buscarCasa(int idCasa)
        {
        int pos = -1;
        for (int i = 0; i < casas.Count; i++)
        {
            if (casas.ElementAt(i).getIdCasa() == idCasa)
            {
                pos = i;
                break;
            }
        }
        return pos;
        }

        public void modificarCasa(int casa)
        {
            int id = buscarCasa(casa);
            if (id != -1)
            {
                Console.WriteLine("Ingrese el nuevo tipo de casa");
                casas.ElementAt(id).setTipoCasa(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo numero de cuartos");
                casas.ElementAt(id).setNumCuartos(int.Parse(Console.ReadLine()));
                Console.WriteLine("Ingrese el nuevo numero de banos");
                casas.ElementAt(id).setNumBanos(int.Parse(Console.ReadLine()));
                Console.WriteLine("Ingrese el nuevo costo");
                casas.ElementAt(id).setCosto(double.Parse(Console.ReadLine()));
                Console.WriteLine("Ingrese la nueva ubicacion");
                casas.ElementAt(id).setUbicacion(Console.ReadLine());
                Console.WriteLine("Ingrese el nuevo area construida");
                casas.ElementAt(id).setAreaConstruida(double.Parse(Console.ReadLine()));
                Console.WriteLine("Ingrese el nuevo area terreno");
                casas.ElementAt(id).setAreaTerreno(double.Parse(Console.ReadLine()));
                Console.WriteLine("Modifique el estado de la casa: 1.En venta 2.Vendida");
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    casas.ElementAt(id).setEnVenta(true);
                }
                else
                {
                    casas.ElementAt(id).setEnVenta(false);
                }
                Console.WriteLine(" ");
                Console.WriteLine("Casa modificada");
                Console.WriteLine(casas.ElementAt(id).ToString());


            }
            else
            {
                Console.WriteLine("No se encontro la casa");
            }

        }
            public void eliminarCasa(int casa)
            {
                int id = buscarCasa(casa);
                if (id != -1)
                {
                    casas.Remove(casas.ElementAt(id));
                    Console.WriteLine(" ");
                    Console.WriteLine("Casa eliminada");
                }
                else
                {
                    Console.WriteLine("No se encontro la casa");
                }


    }

            public void infoCasa(int tipo, String value)
            {
                switch(tipo)
                {
                    case 1:
                    {
                        int id = Int32.Parse(value);
                        int idCasa= buscarCasa(id);
                        if (idCasa != -1)
                        {
                            Console.WriteLine("");
                            Console.WriteLine(casas.ElementAt(idCasa).ToString());
                        }
                        else
                        {
                            Console.WriteLine("No se encontro la casa");
                        }
                        break;
                    }

                    case 2:
                    {
                        for (int i = 0; i < casas.Count; i++)
                        {
                            if (casas.ElementAt(i).getTipoCasa().Equals(value))
                            {
                                Console.WriteLine("");
                                Console.WriteLine(casas.ElementAt(i).ToString());
                            }
                        }
                        break;
                    }
                    case 3:
                    {
                        for (int i = 0; i < casas.Count; i++)
                        {
                            if (casas.ElementAt(i).getUbicacion().Equals(value))
                            {
                                Console.WriteLine("");
                                Console.WriteLine(casas.ElementAt(i).ToString());
                            }
                        }
                        break;
                    }
                }
            }
            

            public void menuAdmin()
            {
                cargarCasas();
                int opc=0;
                do
                {
                    Console.WriteLine(" MENU DE OPCIONES ADMIN");
                    Console.WriteLine("1. Agregar Casa");
                    Console.WriteLine("2. Eliminar Casa");
                    Console.WriteLine("3. Modificar Casa");
                    Console.WriteLine("4. Listar Casas");
                    Console.WriteLine("5. Salir");
                    Console.WriteLine("Ingrese una opcion");
                    opc = int.Parse(Console.ReadLine());

                    switch(opc)
                    {
                        case 1:
                        {
                            AgregarCasa();
                            break;
                        }
                        case 2:
                        {
                            Console.WriteLine("Ingrese el id de la casa a eliminar");
                            int casa = int.Parse(Console.ReadLine());
                            if (buscarCasa(casa) != -1)
                            {
                                eliminarCasa(casa);
                            }
                            else
                            {
                                Console.WriteLine("La casa no existe");
                            }
                            break;

                }

                case 3:
                {
                    Console.WriteLine("Ingrese el id de la casa a modificar");
                    int casa = int.Parse(Console.ReadLine());
                    if (buscarCasa(casa) != -1)
                    {
                        modificarCasa(casa);
                    }
                    else
                    {
                        Console.WriteLine("La casa no existe");
                    }
                    break;

                }

                    case 4: 
                {
                    listarCasas();
                    for (int i = 0; i < casas.Count(); i++)
                    {
                    Console.WriteLine(casas.ElementAt(i).ToString());
                    }
                        break;
                }

                case 5:
                {
                    Console.WriteLine("Saliendo...");
                    break;
                }
                

            }
        }while (opc != 5);
    }

    public void menuCliente()
    {
        cargarCasas();
        int opc = 0;
        do
        {
        Console.WriteLine("MENU DE OPCIONES CLIENTE");
        Console.WriteLine("1. Buscar Casas");
        Console.WriteLine("2. Comprar Casas");
        Console.WriteLine("3. Salir");
        Console.WriteLine("Ingrese una opcion");
        opc = int.Parse(Console.ReadLine());

        switch (opc)
        {
            case 1:
            {
                int opc2=0;
                do
                {
                    Console.WriteLine("MENU DE BUSQUEDA");
                    Console.WriteLine("1. Buscar por ID");
                    Console.WriteLine("2. Buscar por ubicacion");
                    Console.WriteLine("3. Buscar por precio");
                    Console.WriteLine("4. Salir");
                    Console.WriteLine("Ingrese una opcion");
                    opc2= int.Parse(Console.ReadLine());

                    switch(opc2)
                    {
                        case 1:
                        {
                            Console.WriteLine("Ingrese el id de la casa a buscar");
                            int casa = int.Parse(Console.ReadLine());
                            infoCasa(1, casas.ElementAt(casa).ToString());
                            break;
                        }

                        case 2:
                        {
                            Console.WriteLine("Ingrese la ubicacion de la casa a buscar");
                            String ubicacion = Console.ReadLine();
                            infoCasa(2, ubicacion);
                            break;
                        }

                        case 3:
                        {
                            Console.WriteLine("Ingrese el precio de la casa a buscar");
                            double precio = double.Parse(Console.ReadLine());
                            infoCasa(3, precio.ToString());
                            break;
                        }    

                }
            } while (opc2 < 4);
                break;
            }

            case 2:
            {
                Console.WriteLine("ingrese el id de la casa a comprar");
                int casa = int.Parse(Console.ReadLine());
                if(buscarCasa(casa) != -1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("INGRESE EL TOTAL DEL PAGO");
                    int pago = int.Parse(Console.ReadLine());
                    if (pago > 0)
                    {
                        if(pago >= casas.ElementAt(buscarCasa(casa)).getCosto())
                        {
                            Console.WriteLine("");
                            casas.ElementAt(buscarCasa(casa)).setEnVenta(false);
                            Console.WriteLine("");
                            Console.WriteLine("ID " + casas.ElementAt(buscarCasa(casa)).getIdCasa());
                            Console.WriteLine("Tipo de Casa " + casas.ElementAt(buscarCasa(casa)).getTipoCasa());
                            Console.WriteLine("Numero de cuartos " + casas.ElementAt(buscarCasa(casa)).getNumCuartos());
                            Console.WriteLine("Numero de baños " + casas.ElementAt(buscarCasa(casa)).getNumBanos());
                            Console.WriteLine("Costo " + casas.ElementAt(buscarCasa(casa)).getCosto());
                            Console.WriteLine("Area Construida " + casas.ElementAt(buscarCasa(casa)).getAreaConstruida());
                            Console.WriteLine("Area del terreno " + casas.ElementAt(buscarCasa(casa)).getAreaTerreno());
                            Console.WriteLine("Cambio " + (pago - casas.ElementAt(buscarCasa(casa)).getCosto()));
                            Console.WriteLine("");
                            Console.WriteLine("LA CASA HA SIDO COMPRADAAA!!!");
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("EL PAGO NO ES SUFICIENTE");
                        }
                        
                    } else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("EL PAGO NO ES SUFICIENTE");
                    }
                } else
                {
                    Console.WriteLine("");
                    Console.WriteLine("LA CASA NO EXISTE");
                }
                break;
            }
            case 3:
            {
                Console.WriteLine("Saliendo...");
                guardarCasas();
                break;
            }
        }

        }while(opc != 3);

        
    }
}
}
