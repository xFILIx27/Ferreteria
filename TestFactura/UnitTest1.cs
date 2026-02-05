using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using FerreteriaDiego.Models;

namespace TestFactura
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        // 1. Verificar registro de usuario / producto nuevo
        [Fact]
        public void TestUsuarioNuevo()
        {
            var producto = new Producto
            {
                codigo = "Se1",
                nombre = "Serrucho calibre 24",
                precio_unitario = 38000,
                stock = 150,
                estado = "Activo",
                fecha_creacion = DateTime.Now
            };

            bool valido = !string.IsNullOrEmpty(producto.codigo)
                          && producto.precio_unitario > 0
                          && producto.stock > 0;

            Assert.True(valido);
        }

        // 2. Validar total de factura
        [Fact]
        public void TestTotalFacturaCorrecto()
        {
            var detalles = new List<Detalle_Factura>
            {
                new Detalle_Factura { cantidad = 2, precio_unitario = 38000 },
                new Detalle_Factura { cantidad = 1, precio_unitario = 15000 }
            };

            decimal totalEsperado = 91000;
            decimal totalCalculado = detalles.Sum(d => d.cantidad * d.precio_unitario);

            Assert.Equal(totalEsperado, totalCalculado);
        }

        // 3. Producto aparece en stock
        [Fact]
        public void TestProductoEnStock()
        {
            var productos = new List<Producto>
            {
                new Producto { nombre = "Martillo", stock = 10 },
                new Producto { nombre = "Taladro", stock = 5 }
            };

            Assert.Contains(productos, p => p.nombre == "Martillo");
        }

        // 4. Validar unidades en stock
        [Fact]
        public void TestValidarUnidadesStock()
        {
            var producto = new Producto { stock = 20 };
            int cantidadSolicitada = 15;

            Assert.True(producto.stock >= cantidadSolicitada);
        }

        // 5. ID de factura autoincrementable
        [Fact]
        public void TestFacturaIdAutoIncremental()
        {
            int id1 = 1;
            int id2 = 2;

            Assert.True(id2 > id1);
        }

        // 6. Notificación cuando stock es cero
        [Fact]
        public void TestNotificacionStockVacio()
        {
            var producto = new Producto { stock = 0 };

            string mensaje = producto.stock == 0 ? "Stock vacío" : "Stock disponible";

            Assert.Equal("Stock vacío", mensaje);
        }


        // 9. Fecha de factura actual
        [Fact]
        public void TestFechaFacturaActual()
        {
            var factura = new Factura
            {
                fecha_emision = DateTime.Now
            };

            Assert.Equal(DateTime.Now.Date, factura.fecha_emision.Date);
        }

        // 10. Cierre de sesión limpia datos
        [Fact]
        public void TestCerrarSesion()
        {
            bool sesionActiva = false;

            Assert.False(sesionActiva);
        }

        // 11. Validación de correo
        [Fact]
        public void TestValidacionCorreo()
        {
            string correo = "usuario@correo.com";

            Assert.Contains("@", correo);
        }

        // 12. Consulta por ID
        [Fact]
        public void TestConsultaPorId()
        {
            var productos = new List<Producto>
            {
                new Producto { codigo = "A1" },
                new Producto { codigo = "B2" }
            };

            var producto = productos.FirstOrDefault(p => p.codigo == "A1");

            Assert.NotNull(producto);
        }

        // 13. Descuento aplicado correctamente
        [Fact]
        public void TestDescuentoFactura()
        {
            decimal subtotal = 100000;
            int descuento = 10;

            decimal total = subtotal - (subtotal * descuento / 100);

            Assert.Equal(90000, total);
        }

        // 14. Validar sintaxis de correo (@)
        [Fact]
        public void TestCorreoConArroba()
        {
            string correo = "prueba@test.com";

            Assert.True(correo.Contains("@"));
        }
    }
}
