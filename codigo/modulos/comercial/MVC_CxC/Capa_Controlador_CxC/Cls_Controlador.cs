using System;
using System.Data;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Capa_Modelo_CxC;

namespace Capa_Controlador_CxC
{
    public class Cls_Controlador
    {
        // ==== REPO ====
        private readonly Cls_IRepositorioCxC _repo;

        public Cls_Controlador() : this(new Cls_RepositorioSqlCxC()) { }
        public Cls_Controlador(Cls_IRepositorioCxC repo) { _repo = repo; }

        // =========================================================================================
        //  FACTURAS -> DataTable para Vista (filtro por cliente y rango de fechas)
        // =========================================================================================
        public DataTable ObtenerFacturasDT(string cliente, DateTime? desde, DateTime? hasta)
        {
            BindingList<FacturaPendiente> list = _repo.ListarFacturas(cliente, desde, hasta);

            var dt = new DataTable();
            dt.Columns.Add("Factura", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Total", typeof(decimal));
            dt.Columns.Add("Saldo", typeof(decimal));
            dt.Columns.Add("IdCliente", typeof(int));
            dt.Columns.Add("IdDocumento", typeof(int));

            foreach (var f in list)
                dt.Rows.Add(f.Numero, f.Fecha, f.Cliente, f.Total, f.Saldo, f.IdCliente, f.Id);

            return dt;
        }

        // =========================================================================================
        //  RECIBOS -> DataTable para Vista (lista lateral)
        // =========================================================================================
        public DataTable ObtenerRecibosDT()
        {
            BindingList<Recibo> list = _repo.ListarRecibos();

            var dt = new DataTable();
            dt.Columns.Add("Recibo", typeof(int));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("Observaciones", typeof(string));

            foreach (var r in list)
                dt.Rows.Add(r.Id, r.Fecha, r.Cliente ?? "", r.Monto, r.Observaciones ?? "");

            return dt;
        }

        // Antigüedad usando nombre de cliente (compatibilidad)
        public DataTable ObtenerAntiguedadDT(DateTime corte, string cli)
        {
            int? idCliente = null;

            if (!string.IsNullOrWhiteSpace(cli))
            {
                var dtCli = _repo.ClientesDT();
                foreach (DataRow row in dtCli.Rows)
                {
                    string nombre = Convert.ToString(row["Cmp_Nombre_Cliente"]);
                    if (string.Equals(nombre, cli, StringComparison.OrdinalIgnoreCase))
                    {
                        idCliente = Convert.ToInt32(row["Id_Cliente"]);
                        break;
                    }
                }
            }

            return _repo.AntiguedadDT(corte, idCliente);
        }

        // =========================================================================================
        //  BUFFER "APLICAR PAGO"
        // =========================================================================================
        private class PagoDetalleVM
        {
            public string Factura { get; set; }
            public string Cliente { get; set; }
            public decimal Saldo { get; set; }
            public decimal Monto { get; set; }
            public int IdMetodo { get; set; }
            public string Metodo { get; set; }
            public string Referencia { get; set; }
            public int IdDocumento { get; set; }
            public int IdCliente { get; set; }
        }

        private readonly BindingList<PagoDetalleVM> _bufferPago = new BindingList<PagoDetalleVM>();

        public DataTable ObtenerLineasPagoDT()
        {
            var dt = new DataTable();
            dt.Columns.Add("Factura", typeof(string));
            dt.Columns.Add("Cliente", typeof(string));
            dt.Columns.Add("Saldo", typeof(decimal));
            dt.Columns.Add("Monto", typeof(decimal));
            dt.Columns.Add("Metodo", typeof(string));
            dt.Columns.Add("Referencia", typeof(string));
            dt.Columns.Add("IdDocumento", typeof(int));
            dt.Columns.Add("IdCliente", typeof(int));
            dt.Columns.Add("IdMetodo", typeof(int));

            foreach (var x in _bufferPago)
                dt.Rows.Add(x.Factura, x.Cliente, x.Saldo, x.Monto, x.Metodo, x.Referencia, x.IdDocumento, x.IdCliente, x.IdMetodo);

            return dt;
        }

        // Crear recibo "simple" reutilizando la lógica de GuardarPagoAplicado
        public int CrearRecibo(DateTime date, string cliente, decimal monto, string text)
        {
            if (_bufferPago.Count == 0)
                throw new InvalidOperationException("No hay líneas de pago para crear el recibo.");

            int idCliente = _bufferPago.First().IdCliente;
            return GuardarPagoAplicado(date, idCliente, text);
        }

        public decimal TotalLineasPago()
        {
            return _bufferPago.Sum(x => x.Monto);
        }

        // Firma completa (con 'referencia')
        public void AgregarLineaPago(string factura, string cliente, decimal saldo, decimal monto,
                                     int idMetodo, string metodo, string referencia,
                                     int idDocumento, int idCliente)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");
            if (monto > saldo) throw new ArgumentException("El monto no puede superar el saldo del documento.");
            if (idDocumento <= 0) throw new ArgumentException("Documento inválido.");
            if (idCliente <= 0) throw new ArgumentException("Cliente inválido.");

            _bufferPago.Add(new PagoDetalleVM
            {
                Factura = factura ?? "",
                Cliente = cliente ?? "",
                Saldo = saldo,
                Monto = monto,
                IdMetodo = idMetodo,
                Metodo = metodo ?? "",
                Referencia = referencia ?? "",
                IdDocumento = idDocumento,
                IdCliente = idCliente
            });
        }

        // Versión antigua sin ids: solo agrega al buffer (no se recomienda usarla)
        public void AgregarLineaPago(string factura, string cliente, decimal saldo, decimal monto, string metodo, string referencia)
        {
            if (monto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");
            if (monto > saldo) throw new ArgumentException("El monto no puede superar el saldo del documento.");

            _bufferPago.Add(new PagoDetalleVM
            {
                Factura = factura ?? "",
                Cliente = cliente ?? "",
                Saldo = saldo,
                Monto = monto,
                Metodo = metodo ?? "",
                Referencia = referencia ?? "",
                IdMetodo = 0,
                IdDocumento = 0,
                IdCliente = 0
            });
        }

        // Overload que usan a veces en la vista (sin 'referencia')
        public void AgregarLineaPago(string factura, string cliente, decimal saldo, decimal monto,
                                     int idMetodo, string metodo, int idDocumento, int idCliente)
        {
            AgregarLineaPago(factura, cliente, saldo, monto, idMetodo, metodo, null, idDocumento, idCliente);
        }

        // Edición "real"
        public void EditarLineaPago(int index, decimal nuevoMonto, int idMetodo, string metodo, string referencia)
        {
            if (index < 0 || index >= _bufferPago.Count) throw new ArgumentOutOfRangeException("Índice inválido.");
            if (nuevoMonto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");

            var row = _bufferPago[index];
            if (nuevoMonto > row.Saldo) throw new ArgumentException("El monto no puede superar el saldo del documento.");

            row.Monto = nuevoMonto;
            row.IdMetodo = idMetodo;
            row.Metodo = metodo ?? "";
            row.Referencia = referencia ?? "";
        }

        // Editar encabezado de recibo (se actualiza fecha y observaciones)
        public void EditarRecibo(int id, DateTime date, string nuevoCliente, decimal nuevoMonto, string nuevasObs)
        {
            var r = new Recibo
            {
                Id = id,
                Fecha = date,
                Observaciones = nuevasObs ?? ""
            };
            _repo.EditarRecibo(r);
        }

        // Overload de compatibilidad (firma que suele venir desde la Vista)
        public void EditarLineaPago(int index,
                                    string factura, string cliente, decimal saldo,
                                    decimal nuevoMonto, int idMetodo, string metodo)
        {
            if (nuevoMonto > saldo) throw new ArgumentException("El monto no puede superar el saldo del documento.");
            EditarLineaPago(index, nuevoMonto, idMetodo, metodo, null);
        }

        // Versión con "id" (lo tratamos como índice dentro del buffer)
        public void EditarLineaPago(int id, string factura, string cliente, decimal nSaldo, decimal nMonto, string metodo, string referencia)
        {
            if (id < 0 || id >= _bufferPago.Count) throw new ArgumentOutOfRangeException("id");
            if (nMonto <= 0) throw new ArgumentException("El monto debe ser mayor a 0.");
            if (nMonto > nSaldo) throw new ArgumentException("El monto no puede superar el saldo del documento.");

            var row = _bufferPago[id];
            row.Factura = factura ?? row.Factura;
            row.Cliente = cliente ?? row.Cliente;
            row.Saldo = nSaldo;
            row.Monto = nMonto;
            row.Metodo = metodo ?? row.Metodo;
            row.Referencia = referencia ?? row.Referencia;
        }

        public void AnularRecibo(int id)
        {
            _repo.AnularRecibo(id);
        }

        public void EliminarLineaPago(int index)
        {
            if (index < 0 || index >= _bufferPago.Count) throw new ArgumentOutOfRangeException("Índice inválido.");
            _bufferPago.RemoveAt(index);
        }

        public void LimpiarLineasPago()
        {
            _bufferPago.Clear();
        }

        /// <summary>
        /// Guarda el pago: crea RECIBO (tbl_recibo), inserta detalles (tbl_recibo_det)
        /// y aplica a documentos (tbl_recibo_aplicacion).
        /// </summary>
        public int GuardarPagoAplicado(DateTime fecha, int idCliente, string observaciones)
        {
            if (_bufferPago.Count == 0)
                throw new InvalidOperationException("No hay líneas de pago.");

            var clientes = _bufferPago.Select(x => x.IdCliente).Distinct().ToList();
            if (clientes.Count != 1 || (clientes[0] != 0 && clientes[0] != idCliente))
                throw new InvalidOperationException("Todas las líneas deben pertenecer al mismo cliente seleccionado.");

            var total = _bufferPago.Sum(x => x.Monto);

            var r = new Recibo
            {
                Fecha = fecha,
                IdCliente = idCliente,
                Cliente = _bufferPago.First().Cliente, // informativo
                Monto = total,
                Observaciones = (observaciones ?? "").Trim(),
                IdUsuario = 1 // TODO: usuario real
            };

            var detalles = _bufferPago.Select(x => new LineaPago
            {
                IdMetodoPago = x.IdMetodo,
                Monto = x.Monto
            }).ToArray();

            var apps = _bufferPago.Select(x => new AplicacionPago
            {
                IdDocumento = x.IdDocumento,
                MontoAplicado = x.Monto
            }).ToArray();

            var creado = _repo.CrearRecibo(r, detalles, apps);

            _bufferPago.Clear();
            return creado.Id;
        }

        // Versión de compatibilidad con firma (fecha, cliente, metodo, referencia)
        // Versión de compatibilidad (fecha, cliente, metodo, referencia)
        public int GuardarPagoAplicado(DateTime date, string cliente, string metodo, string referencia)
        {
            if (_bufferPago.Count == 0)
                throw new InvalidOperationException("No hay líneas de pago.");

            // Tomamos el cliente desde las líneas
            int idCliente = _bufferPago.First().IdCliente;
            string obs = $"{metodo} {referencia}".Trim();

            return GuardarPagoAplicado(date, idCliente, obs);
        }


        // Overload de compatibilidad si la Vista manda (fecha, idCliente, totalIgnorado, obs)
        public int GuardarPagoAplicado(DateTime fecha, int idCliente, decimal totalIgnorado, string observaciones)
        {
            return GuardarPagoAplicado(fecha, idCliente, observaciones);
        }

        // =========================================================================================
        //  REPORTES
        // =========================================================================================
        public DataTable ObtenerClientes()
        {
            return _repo.ClientesDT();
        }

        public DataTable ObtenerAntiguedadDT(DateTime fechaCorte, int? idCliente)
        {
            return _repo.AntiguedadDT(fechaCorte, idCliente);
        }

        public DataTable ObtenerCajaDiaDT(DateTime fecha, out decimal totalDia)
        {
            return _repo.CajaDiaDT(fecha, out totalDia);
        }
    }
}
