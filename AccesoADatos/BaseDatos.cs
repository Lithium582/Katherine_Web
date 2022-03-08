using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public abstract class BaseDatos : IBaseDatos
    {
        #region "Atributos"
        private string _servidor;
        private string _base;
        private string _usuario;
        private string _pass;
        #endregion

        #region "Propiedades"
        protected string Servidor
        {
            get
            {
                return this._servidor;
            }
            set
            {
                this._servidor = value;
            }
        }

        protected string Base
        {
            get
            {
                return this._base;
            }
            set
            {
                this._base = value;
            }
        }

        protected string Usuario
        {
            get
            {
                return this._usuario;
            }
            set
            {
                this._usuario = value;
            }
        }

        protected string Pass
        {
            get
            {
                return this._pass;
            }
            set
            {
                this._pass = value;
            }
        }
        #endregion

        #region "Constructor"
        public BaseDatos(Configuracion config)
        {
            this._servidor = config.Server;
            this._base = config.Base;
            this._usuario = config.Usuario;
            this._pass = config.Pass;
        }

        #endregion

        #region "Métodos y Funciones"
        public abstract void IniciarComandoStoredProcedure(string pNombreSP);

        #endregion

        #region "Métodos de Ejecución"
        public abstract DataTable EjecutarQuery();
        public abstract int EjecutarRetorno();

        public abstract int EjecutarEscalar();
        protected abstract SqlParameter ObtenerValorParametroRetorno();

        #endregion

        #region "Manejo de parámetros"
        public abstract void AgregarParametro(string pNombre, string pValor);
        public abstract void AgregarParametro(string pNombre, int pValor);
        public abstract void AgregarParametro(string pNombre, bool pValor);
        public abstract void AgregarParametro(string pNombre, DateTime pValor);
        public abstract void AgregarParametro(string pNombre, decimal pValor);
        public abstract void AgregarParametro(string pNombre, float pValor);
        public abstract void AgregarParametro(string pNombre, double pValor);
        public abstract void AgregarParametro(string pNombre, long pValor);
        public abstract void AgregarParametro(string pNombre, char pValor);

        public abstract void AgregarParametroNulo(string pNombre);

        public abstract SqlParameter AgregarParametroRetorno(string pNombre);
        #endregion
    }
}
