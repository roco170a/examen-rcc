using examen_rcc.Data;
using examen_rcc.Models;
using Microsoft.AspNetCore.Mvc;
using static examen_rcc.Controllers.ProductoController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace examen_rcc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        IProductoDAL _store;

        public ProductoController(IProductoDAL param1)
        {
            this._store = param1;
        }

        // GET: api/<ProductosController1>
        [HttpGet]
        public DataRespListProducto<Producto> Get()
        {
            DataRespListProducto<Producto> resp = new DataRespListProducto<Producto>();
            resp.data = this._store.getall();
            resp.entityName = this.GetType().Name;
            resp.message = "ok";
            resp.iserror = false;
            return resp;
        }

        // GET api/<ProductosController1>/5
        [HttpGet("{id}")]
        public DataRespValueProducto<Producto> Get(int id)
        {
            DataRespValueProducto<Producto> resp = new DataRespValueProducto<Producto>();
            resp.data = this._store.getOne(id);
            resp.entityName = this.GetType().Name;
            resp.message = "ok";
            resp.iserror = false;
            return resp;
        }

        // POST api/<ProductosController1>
        [HttpPost]
        public DataRespValueProducto<Producto> Post([FromBody] Producto value)
        {
            _store.save(value);
            DataRespValueProducto<Producto> resp = new DataRespValueProducto<Producto>();
            resp.data = value;
            resp.entityName = this.GetType().Name;
            resp.message = "ok";
            resp.iserror = false;
            return resp;
        }

        // PUT api/<ProductosController1>/5
        [HttpPut("{id}")]
        public DataRespValueProducto<Producto> Put(int id, [FromBody] Producto value)
        {
            DataRespValueProducto<Producto> resp = new DataRespValueProducto<Producto>();
            resp.data = _store.updOne(id, value); ;
            resp.entityName = this.GetType().Name;
            resp.message = "ok";
            resp.iserror = false;
            return resp;
        }

        // DELETE api/<ProductosController1>/5
        [HttpDelete("{id}")]
        public DataRespValueProducto<Boolean> Delete(int id)
        {
            DataRespValueProducto<Boolean> resp = new DataRespValueProducto<Boolean>();
            resp.data = _store.delOne(id); 
            resp.entityName = this.GetType().Name;
            resp.message = "ok";
            resp.iserror = false;
            return resp;
            
        }

        public class DataRespValueProducto<T>
        {
            public string entityName { get; set; }
            public T? data { get; set; }
            public string message { get; set; }
            public Boolean iserror { get; set; }
        }

        public class DataRespListProducto<T>
        {
            public string entityName { get; set; }
            public List<T> data { get; set; }
            public string message { get; set; }
            public Boolean iserror { get; set; }
        }

    }
}
