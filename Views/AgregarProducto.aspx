<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="Examen.Views.AgregarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Agregar Productos</title>
    <!-- Se vincula la hoja de estilos a la vista -->
    <link href="StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor principal del formulario -->
        <div class="Contenedor">
            <h1 class="Titulo">Formulario AgregarProductos</h1>

            <!-- Campo para ingresar el nombre del producto -->
            <label class="Etiqueta">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="Campo"></asp:TextBox>

            <!-- Validador para asegurar que el campo Nombre no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar un nombre para el producto"
                ControlToValidate="txtNombre"
                runat="server"
                ID="rfvNombre"
                CssClass="Error" />

            <!-- Campo para ingresar la descripción del producto-->
            <label class="Etiqueta">Descripción</label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="Campo"></asp:TextBox>

            <!-- Validador para asegurar que el campo Descripción no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar una descripción para el producto"
                ControlToValidate="txtDescripcion"
                runat="server"
                ID="rfvDescripcion"
                CssClass="Error" />

            <!-- Campo para ingresar el precio del producto -->
            <label class="Etiqueta">Precio</label>
            <asp:TextBox runat="server" ID="txtPrecio" CssClass="Campo"></asp:TextBox>

            <!-- Validadores para el campo Precio -->
            <!-- Validador para asegurar que el campo Precio no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar un precio para el producto"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="rfvPrecio"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo Precio sea un número decimal -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un precio adecuado"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="cvPrecioTipo"
                Operator="DataTypeCheck"
                Type="Double"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo Precio sea mayor a 0 -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un precio mayor a 0"
                ControlToValidate="txtPrecio"
                runat="server"
                ID="cvPrecioValor"
                ValueToCompare="0"
                Operator="GreaterThan"
                Type="Double"
                CssClass="Error" />

            <!-- Campo para ingresar la cantidad del producto -->
            <label class="Etiqueta">Cantidad</label>
            <asp:TextBox runat="server" ID="txtCantidad" CssClass="Campo"></asp:TextBox>

            <!-- Validadores para el campo Cantidad -->
            <!-- Validador para asegurar que el campo Cantidad no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar una cantidad adecuada"
                ControlToValidate="txtCantidad"
                runat="server"
                ID="rfvCantidad"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo Cantidad sea un número entero -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar una cantidad "
                ControlToValidate="txtCantidad"
                runat="server"
                ID="cvCantidadTipo"
                Operator="DataTypeCheck"
                Type="Integer"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo Cantidad sea mayor a -1 -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar una cantidad mayor a -1"
                ControlToValidate="txtCantidad"
                runat="server"
                ID="cvCantidadValor"
                ValueToCompare="-1"
                Operator="GreaterThan"
                Type="Double"
                CssClass="Error" />

            <!-- Campo para seleccionar la categoría del producto -->
            <!-- Se utiliza un DropDownList para mostrar las categorías disponibles -->
            <label class="Etiqueta">Categoría</label>
            <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="Desplegable">
                <!-- Opciones del DropDownList -->
                <asp:ListItem Value="" Text="Seleccione una categoría" />
                <asp:ListItem Value="Ropa" Text="Ropa" />
                <asp:ListItem Value="Electrónica" Text="Electrónica" />
                <asp:ListItem Value="Hogar" Text="Hogar" />
                <asp:ListItem Value="Juguetes" Text="Juguetes" />
                <asp:ListItem Value="Libros" Text="Libros" />
                <asp:ListItem Value="Deportes" Text="Deportes" />
                <asp:ListItem Value="Salud y Belleza" Text="Salud y Belleza" />
            </asp:DropDownList>

            <!-- Validador para asegurar que se seleccione una categoría -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de seleccionar una categoría"
                ControlToValidate="ddlCategorias"
                InitialValue=""
                runat="server"
                ID="rfvCategoria"
                CssClass="Error" />
            <!-- Botones para agregar, limpiar y volver -->
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

            <!-- Etiqueta para mostrar mensajes al usuario -->
            <div>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Mensaje"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
