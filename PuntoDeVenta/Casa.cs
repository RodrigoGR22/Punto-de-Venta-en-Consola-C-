using System;
using System.Collections.Generic;
using System.Text;

namespace PuntoDeVenta
{
    class Casa
    {
        private int idCasa;
        private string tipoCasa;
        private int numCuartos;
        private int numBanos;
        private double costo;
        private string ubicacion;
        private double areaConstruida;
        private double areaTerreno;
        private bool enVenta;

        public Casa()
        {
        }

        public Casa(int idCasa, string tipoCasa, int numCuartos, int numBanos, double costo, string ubicacion, double areaConstruida, double areaTerreno, bool enVenta)
        {
            this.idCasa = idCasa;
            this.tipoCasa = tipoCasa;
            this.numCuartos = numCuartos;
            this.numBanos = numBanos;
            this.costo = costo;
            this.ubicacion = ubicacion;
            this.areaConstruida = areaConstruida;
            this.areaTerreno = areaTerreno;
            this.enVenta = enVenta;
        }

        public int getIdCasa()
        {
            return idCasa;
        }

        public void setIdCasa(int idCasa)
        {
            this.idCasa = idCasa;
        }

        public String getTipoCasa()
        {
            return tipoCasa;
        }

        public void setTipoCasa(String tipoCasa)
        {
            this.tipoCasa = tipoCasa;
        }

        public int getNumCuartos()
        {
            return numCuartos;
        }

        public void setNumCuartos(int numCuartos)
        {
            this.numCuartos = numCuartos;
        }

        public int getNumBanos()
        {
            return numBanos;
        }

        public void setNumBanos(int numBanos)
        {
            this.numBanos = numBanos;
        }

        public double getCosto()
        {
            return costo;
        }

        public void setCosto(double costo)
        {
            this.costo = costo;
        }

        public String getUbicacion()
        {
            return ubicacion;
        }

        public void setUbicacion(String ubicacion)
        {
            this.ubicacion = ubicacion;
        }

        public double getAreaConstruida()
        {
            return areaConstruida;
        }

        public void setAreaConstruida(double areaConstruida)
        {
            this.areaConstruida = areaConstruida;
        }

        public double getAreaTerreno()
        {
            return areaTerreno;
        }

        public void setAreaTerreno(double areaTerreno)
        {
            this.areaTerreno = areaTerreno;
        }

        public bool isEnVenta()
        {
            return enVenta;
        }

        public void setEnVenta(bool enVenta)
        {
            this.enVenta = enVenta;
        }

        
    public override string ToString()
        {
            string str = "====================================\n"
                    + "ID Casa: " + idCasa + "\n"
                    + "Tipo de Casa: " + tipoCasa + "\n"
                    + "Numero de cuartos: " + numCuartos + "\n"
                    + "Numero de banos: " + numBanos + "\n"
                    + "Costo: " + costo + "\n"
                    + "Area Construida: " + areaConstruida + "\n"
                    + "Area Terreno: " + areaTerreno + "\n"
                    + (enVenta ? "En Venta!" : "No esta en venta.") + "\n";
            return str;
        }
    }
}

