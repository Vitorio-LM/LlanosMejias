using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LlanosMejias.Configuracion; 


namespace LlanosMejias
{
    public partial class MostrarAlumno : System.Web.UI.Page
    {
        private readonly OperacionesMotorAlumnos motorDatos = new OperacionesMotorAlumnos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTodosLosAlumnos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string rutBuscar = txtBuscarRut.Text.Trim();
            if (string.IsNullOrEmpty(rutBuscar))
            {
                lblEstadoAlumno.Visible = true;
                lblEstadoAlumno.Text = "Por favor, ingrese un RUT para realizar la búsqueda.";
                lblStatusClase(lblEstadoAlumno, "alert-warning");
                return;
            }
            DataTable dtFiltrado = BuscarAlumnoPorRut(rutBuscar);

            if (dtFiltrado.Rows.Count > 0)
            {
                gvTodosAlumnos.DataSource = dtFiltrado;
                gvAlumnosDataBind();
                double promedio = Convert.ToDouble(dtFiltrado.Rows[0]["Promedio"]);
                lblEstadoAlumno.Visible = true;
                if (promedio >= 1.0 && promedio <= 3.9)
                {
                    lblEstadoAlumno.Text = "Estado: REPROBADO (Promedio: " + promedio.ToString("F1") + ")";
                    lblStatusClase(lblEstadoAlumno, "alert-danger");
                }
                else if (promedio >= 4.0 && promedio <= 7.0)
                {
                    lblEstadoAlumno.Text = "Estado: APROBADO (Promedio: " + promedio.ToString("F1") + ")";
                    lblStatusClase(lblEstadoAlumno, "alert-success");
                }
            }
            else
            {
                gvTodosAlumnos.DataSource = null;
                gvAlumnosDataBind();
                lblEstadoAlumno.Visible = true;
                lblEstadoAlumno.Text = "El RUT ingresado no existe en los registros.";
                lblStatusClase(lblEstadoAlumno, "alert-danger");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarRut.Text = string.Empty;
            lblEstadoAlumno.Text = string.Empty;
            lblEstadoAlumno.Visible = false;
            CargarTodosLosAlumnos();
        }

        private void CargarTodosLosAlumnos()
        {
            DataTable dtTodos = motorDatos.ObtenerColeccionAlumnos();
            gvTodosAlumnos.DataSource = dtTodos;
            gvAlumnosDataBind();
        }
        private DataTable BuscarAlumnoPorRut(string rut)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            {
                string query = "SELECT Rut, Nombre, Nota1, Nota2, Nota3, Promedio FROM Alumnos WHERE Rut = @rut";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rut", rut);
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(dt);
                    }
                }
            }
            return dt;
        }
        private void lblStatusClase(System.Web.UI.WebControls.Label label, string claseBootstrap)
        {
            label.CssClass = "fw-bold small d-block text-center p-2 rounded alert " + claseBootstrap;
        }

        private void gvAlumnosDataBind()
        {
            gvTodosAlumnos.DataBind();
        }
    }
}