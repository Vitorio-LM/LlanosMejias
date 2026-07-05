using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LlanosMejias
{
    public partial class Registros : System.Web.UI.Page
    {
        private readonly OperacionesMotorAlumnos motorDatos = new OperacionesMotorAlumnos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRut.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtNombre.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtNota1.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtNota2.Text.Trim()) ||
                string.IsNullOrWhiteSpace(txtNota3.Text.Trim()))
            {
                lblStatus.Text = "Faltan datos por ingresar, verifique antes de Continuar.";
                lblStatus.CssClass = "text-danger d-block text-center";
                return;
            }
            string rut = txtRut.Text.Trim();
            string nombre = txtNombre.Text.Trim();

            if (rut.Length > 12)
            {
                lblStatus.Text = "El RUT ingresado es demasiado largo. Máximo 12 caracteres (ej: 11.222.333-4).";
                lblStatus.CssClass = "text-danger d-block text-center";
                return;
            }

            if (motorDatos.ComprobarExistenciaRut(rut))
            {
                lblStatus.Text = "El RUT ya se encuentra registrado en el sistema.";
                lblStatus.CssClass = "text-danger d-block text-center";
                return;
            }

            double n1 = 0, n2 = 0, n3 = 0;
            bool conversionExitosa = false;
            try
            {
                n1 = Convert.ToDouble(txtNota1.Text.Replace('.', ','));
                n2 = Convert.ToDouble(txtNota2.Text.Replace('.', ','));
                n3 = Convert.ToDouble(txtNota3.Text.Replace('.', ','));
                conversionExitosa = true;
            }
            catch
            {
                lblStatus.Text = "El valor Ingresado no corresponde a un número Válido.";
                lblStatus.CssClass = "text-danger d-block text-center";
                return;
            }
            if (conversionExitosa)
            {
                if (n1 > 7 || n1 < 1 || n2 > 7 || n2 < 1 || n3 > 7 || n3 < 1)
                {
                    lblStatus.Text = "El valor Ingresado está fuera del rango de notas, entre 1 y 7.";
                    lblStatus.CssClass = "text-danger d-block text-center";
                    return;
                }
            }
            double promedio = Math.Round((n1 + n2 + n3) / 3, 1);
            bool completado = motorDatos.RegistrarNuevoAlumno(rut, nombre, n1, n2, n3, promedio);

            if (completado)
            {
                lblStatus.Text = "Alumno registrado correctamente.";
                lblStatus.CssClass = "text-success d-block text-center";

                DataTable dtAlumnoReciente = new DataTable();
                dtAlumnoReciente.Columns.Add("Rut");
                dtAlumnoReciente.Columns.Add("Nombre");
                dtAlumnoReciente.Columns.Add("Nota1");
                dtAlumnoReciente.Columns.Add("Nota2");
                dtAlumnoReciente.Columns.Add("Nota3");
                dtAlumnoReciente.Columns.Add("Promedio");
                dtAlumnoReciente.Rows.Add(rut, nombre, n1, n2, n3, promedio);
                gvAlumnos.DataSource = dtAlumnoReciente;
                gvAlumnos.DataBind();
                Limpiar();
            }
            else
            {
                lblStatus.Text = "Error: No se pudo procesar la inserción en la base de datos.";
                lblStatus.CssClass = "text-danger d-block text-center";
            }
        }
        private void Limpiar()
        {
            txtRut.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNota1.Text = string.Empty;
            txtNota2.Text = string.Empty;
            txtNota3.Text = string.Empty;
        }
    }
}