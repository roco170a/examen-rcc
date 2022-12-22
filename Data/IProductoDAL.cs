using examen_rcc.Models;

namespace examen_rcc.Data
{
    public interface IProductoDAL
    {        
        void save(Producto newItem);
        public List<Producto> getall();
        public Producto? getOne(int id);
        public Boolean delOne(int id);
        public Producto updOne(int rowId, Producto itemToUpd);
    }
}
