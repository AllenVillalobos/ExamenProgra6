<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="Examen.Views.AgregarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar Productos</title>
    <link href="StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Contenedor">
            <h1 class="Titulo">Formulario AgregarProductos</h1>
            <label class="Etiqueta">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="Campo"></asp:TextBox>

            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar un nombre para el producto"
                ControlToValidate="txtNombre"
                runat="server"
                ID="rfvNombre"
                CssClass="Error" />

            <label class="Etiqueta">Descripción</label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="Campo"></asp:TextBox>

            <label class="Etiqueta">Precio</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="Campo"></asp:TextBox>

            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar un precio para el producto"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="rfvPrecio"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un precio adecuado"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="cvPrecioTipo"
                Operator="DataTypeCheck"
                Type="Double"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un precio mayor a 0"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="cvPrecioValor"
                ValueToCompare="0"
                Operator="GreaterThan"
                Type="Double"
                CssClass="Error" />

            <label class="Etiqueta">Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="Campo"></asp:TextBox>

            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar una cantidad adecuada"
                ControlToValidate="txtCantidad"
                runat="server"
                ID="rfvCantidad"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar una cantidad "
                ControlToValidate="txtCantidad"
                runat="server"
                ID="cvCantidadTipo"
                Operator="DataTypeCheck"
                Type="Double"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar una cantidad mayor a -1"
                ControlToValidate="txtCantidad"
                runat="server"
                ID="cvCantidadValor"
                ValueToCompare="-1"
                Operator="GreaterThan"
                Type="Double"
                CssClass="Error" />

            <label class="Etiqueta">Categoría</label>
            <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="Desplegable">
                <asp:ListItem Value="" Text="Seleccione una categoría" />
                <asp:ListItem Value="Ropa" Text="Ropa" />
                <asp:ListItem Value="Electrónica" Text="Electrónica" />
                <asp:ListItem Value="Hogar" Text="Hogar" />
                <asp:ListItem Value="Juguetes" Text="Juguetes" />
                <asp:ListItem Value="Libros" Text="Libros" />
                <asp:ListItem Value="Deportes" Text="Deportes" />
                <asp:ListItem Value="Salud y Belleza" Text="Salud y Belleza" />
            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ErrorMessage="Debe de seleccionar una categoría"
                ControlToValidate="ddlCategorias"
                InitialValue=""
                runat="server"
                ID="rfvCategoria"
                CssClass="Error" />

            <asp:Button
                runat="server"
                ID="btnAgregar"
                Text="Agregar"
                OnClick="btnAgregar_Click"
                CssClass="BotonAgregar" />

            <asp:Button runat="server"
                ID="bntLimpiar"
                Text="Limpiar"
                OnClick="btnLimpiar_Click"
                CssClass="BotonLimpiar" />
            <asp:Button runat="server"
                ID="btnVolver"
                Text="Volver"
                OnClick="btnVolver_Click"
                CssClass="BotonVolver" />
            <div>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Mensaje"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
