using examen_rcc.Models;

namespace examen_rcc.Data
{
    public sealed class SingletonDAL
    {
        private List<Producto> dataListProduct = new List<Producto>();
        private SingletonDAL() { }

        private static SingletonDAL _instance;

        public static SingletonDAL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SingletonDAL();
            }
            return _instance;
        }

        public List<Producto> getRepository()
        {
            return dataListProduct;
        }
    }
}
