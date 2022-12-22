using examen_rcc.Models;

namespace examen_rcc.Data
{
    public class ProductoDAL : IProductoDAL
    {
        private static ProductoDAL _instance;

        SingletonDAL datastore = SingletonDAL.GetInstance();
        
        public static ProductoDAL GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductoDAL();
            }
            return _instance;
        }

        public void save(Producto newItem)
        {
            List<Producto> data = datastore.getRepository();
            data.Add(newItem);
        }

        public List<Producto> getall() {
            List<Producto> data = datastore.getRepository();
            return data;
        }

        public Producto? getOne(int id)
        {
            List<Producto> data = datastore.getRepository();
            Producto result = data.Find( r => r.rowid == id );
            return result;
        }

        public Producto updOne(int rowId, Producto itemToUpd)
        {
            List<Producto> data = datastore.getRepository();            
            int index = data.FindIndex(r => r.rowid == rowId);

            data[index] = itemToUpd;
            
            return itemToUpd;
        }

        public Boolean delOne(int id)
        {
            List<Producto> data = datastore.getRepository();
            Producto ItemtoDelete = data.Find(r => r.rowid == id);
            
            return data.Remove(ItemtoDelete);
        }


    }
}
