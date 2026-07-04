<%@ Page Title="Inscripción de Alumnos" Language="C#" MasterPageFile="~/Genesis.Master" AutoEventWireup="true" CodeBehind="Registros.aspx.cs" Inherits="LlanosMejias.Registros" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mt-4">
        <div class="col-md-5 mb-4">
            <div class="custom-card shadow-sm">
                <div class="card-header-primary p-3">
                    <h5 class="mb-0"><i class="bi bi-person-fill-add me-2"></i>Ingresar Registro Escolar</h5>
                </div>
                <div class="card-body p-4">                    
                    <div class="mb-3">
                        <label class="form-label fw-bold">RUT Alumno</label>
                        <asp:TextBox ID="txtRut" runat="server" class="form-control" placeholder="12345678-K"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label class="form-label fw-bold">Nombre del Estudiante</label>
                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Ej: Víctor Llanos Mejías"></asp:TextBox>
                    </div>
                    <div class="row">
                        <div class="col-md-4 mb-3">
                            <label class="form-label small fw-bold">Nota 1</label>
                            <asp:TextBox ID="txtNota1" runat="server" class="form-control text-center" placeholder="1,0"></asp:TextBox>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label class="form-label small fw-bold">Nota 2</label>
                            <asp:TextBox ID="txtNota2" runat="server" class="form-control text-center" placeholder="1,0"></asp:TextBox>
                        </div>
                        <div class="col-md-4 mb-3">
                            <label class="form-label small fw-bold">Nota 3</label>
                            <asp:TextBox ID="txtNota3" runat="server" class="form-control text-center" placeholder="1,0"></asp:TextBox>
                        </div>
                    </div>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Calificaciones" class="btn-custom-success w-100 mt-3" OnClick="btnGuardar_Click" />                    
                    <div class="mt-3">
                        <asp:Label ID="lblStatus" runat="server" class="fw-bold small d-block text-center p-2 rounded"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="custom-card shadow-sm">
                <div class="card-header-secondary p-3">
                    <h5 class="mb-0"><i class="bi bi-grid-3x3-gap-fill me-2"></i>Alumno ingresado a base de datos</h5>
                </div>
                <div class="card-body p-0">
                    <asp:GridView ID="gvAlumnos" runat="server" AutoGenerateColumns="False" class="custom-grid table mb-0 text-center">
                        <Columns>
                            <asp:BoundField DataField="Rut" HeaderText="RUT" ItemStyle-CssClass="text-start ps-3" HeaderStyle-CssClass="text-start ps-3" />
                            <asp:BoundField DataField="Nombre" HeaderText="Alumno" ItemStyle-CssClass="text-start" HeaderStyle-CssClass="text-start" />
                            <asp:BoundField DataField="Nota1" HeaderText="N1" />
                            <asp:BoundField DataField="Nota2" HeaderText="N2" />
                            <asp:BoundField DataField="Nota3" HeaderText="N3" />
                            <asp:BoundField DataField="Promedio" HeaderText="Promedio Final" ItemStyle-Font-Bold="true" ItemStyle-CssClass="text-primary fw-bold" />
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="p-4 text-muted text-center">Sin alumnos registrados en la base PRUEBA4.</div>
                        </EmptyDataTemplate>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>