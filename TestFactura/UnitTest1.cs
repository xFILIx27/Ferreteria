using FerreteriaDiego.Controllers;
using FerreteriaDiego.Models;

namespace TestFactura
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public void TestUsuarioNuevo()
        {
                var controller = new Productos1Controller();

            var Producto = new Producto
            {
                codigo = "Se1",
                nombre = "Serrucho calibre 24",
                descripcion = "Serrucho de alta calidad para trabajos de carpintería.",
                precio_unitario =38000,
                iva_porcentaje = 19,
                categoria = "Herramientas",
                stock = 150,
                estado = "Activo",
                fecha_creacion = DateTime.Now

            };

        }
    }
} 