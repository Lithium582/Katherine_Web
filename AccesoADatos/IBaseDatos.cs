using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public interface IBaseDatos
    {
        void IniciarComandoStoredProcedure(string pNombreSP);

        DataTable EjecutarQuery();
        int EjecutarEscalar();
        int EjecutarRetorno();



        void AgregarParametro(string pNombre, string pValor);
        void AgregarParametro(string pNombre, int pValor);
        void AgregarParametro(string pNombre, bool pValor);
        void AgregarParametro(string pNombre, DateTime pValor);
        void AgregarParametro(string pNombre, decimal pValor);
        void AgregarParametro(string pNombre, float pValor);
        void AgregarParametro(string pNombre, double pValor);
        void AgregarParametro(string pNombre, long pValor);
        void AgregarParametro(string pNombre, char pValor);
        void AgregarParametroNulo(string pNombre);

        SqlParameter AgregarParametroRetorno(string pNombre);
    }
}