using AccesoADatos.MotoresSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class BaseConexion
    {
        #region "Singleton"
        private static BaseConexion _objeto;

        private BaseConexion(Configuracion config)
        {
            this._conf = config;
        }

        public static BaseConexion GetConexion(Configuracion config)
        {
            if(_objeto == null)
            {
                _objeto = new BaseConexion(config);
            }

            return _objeto;
        }
        #endregion

        #region "Métodos estáticos"
        public static void InicializarConexion(Configuracion config)
        {
            BaseConexion obj = GetConexion(config);
        }

        public static IBaseDatos ObtenerBD()
        {
            IBaseDatos bd;
            //Crear una instancia del motor que corresponda
            switch (_objeto._conf.Motor)
            {
                case "MSSQL":
                    {
                        bd = new SQLServer(_objeto._conf);
                        break;
                    }
                default:
                    {
                        bd = null;
                        break;
                    }
            }

            return bd;
        }

        #endregion

        #region "Atributos"
        
        private bool _testing;
        private Configuracion _conf;

        #endregion
        #region "Propiedades"

        #endregion

        #region "Métodos y Funciones"

        #endregion
    }
}
