<%@ Page Title="Consulta de Alumnos" Language="C#" MasterPageFile="~/Genesis.Master" AutoEventWireup="true" CodeBehind="MostrarAlumno.aspx.cs" Inherits="LlanosMejias.MostrarAlumno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-12 mb-4">
                <div class="custom-card shadow-sm">
                    <div class="card-header-primary p-3">
                        <h5 class="mb-0"><i class="bi bi-search me-2"></i>Consultar Alumno por RUT</h5>
                    </div>
                    <div class="card-body p-4">
                        <div class="row align-items-end">
                            <div class="col-md-4 mb-2">
                                <label class="form-label fw-bold">Ingrese RUT a buscar</label>
                                <asp:TextBox ID="txtBuscarRut" runat="server" class="form-control" placeholder="12345678-K"></asp:TextBox>
                            </div>
                            <div class="col-md-4 mb-2">
                                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-primary fw-bold me-2 px-4" OnClick="btnBuscar_Click" />
                                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" class="btn btn-secondary fw-bold px-4" OnClick="btnLimpiar_Click" />
                            </div>
                            <div class="col-md-4 mb-2">
                                <asp:Label ID="lblEstadoAlumno" runat="server" class="fw-bold small d-block text-center p-2 rounded" Visible="false"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="custom-card shadow-sm">
                    <div class="card-header-secondary p-3">
                        <h5 class="mb-0"><i class="bi bi-grid-3x3-gap-fill me-2"></i>Listado General de Alumnos</h5>
                    </div>
                    <div class="card-body p-0">
                        <asp:GridView ID="gvTodosAlumnos" runat="server" AutoGenerateColumns="False" class="custom-grid table mb-0 text-center">
                            <Columns>
                                <asp:BoundField DataField="Rut" HeaderText="RUT" ItemStyle-CssClass="text-start ps-3" HeaderStyle-CssClass="text-start ps-3" />
                                <asp:BoundField DataField="Nombre" HeaderText="Alumno" ItemStyle-CssClass="text-start" HeaderStyle-CssClass="text-start" />
                                <asp:BoundField DataField="Nota1" HeaderText="N1" />
                                <asp:BoundField DataField="Nota2" HeaderText="N2" />
                                <asp:BoundField DataField="Nota3" HeaderText="N3" />
                                <asp:BoundField DataField="Promedio" HeaderText="Promedio Final" ItemStyle-Font-Bold="true" ItemStyle-CssClass="fw-bold" />
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="p-4 text-muted text-center">No existen alumnos registrados en el sistema.</div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>