<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Examen.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eliminar/Editar/Ver</title>
    <link href="StyleSheet.css" type="text/css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="Contenedor">
            <h1 class="Titulo">Formulario de Actualizar/Eliminar</h1>
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
            <asp:DropDownList runat="server" ID="ddlCategorias">
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

            <label class="Etiqueta">ID Producto</label>
            <asp:TextBox runat="server" ID="txtID" CssClass="Campo"></asp:TextBox>
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de seleccionar un produto o ingresar su ID"
                ControlToValidate="txtID"
                runat="server"
                ID="rfvID"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un ID adecuado "
                ControlToValidate="txtID"
                runat="server"
                ID="cvIDTipo"
                Operator="DataTypeCheck"
                Type="Integer"
                CssClass="Error" />

            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un ID mayor a -1"
                ControlToValidate="txtID"
                runat="server"
                ID="cvIDValor"
                ValueToCompare="-1"
                Operator="GreaterThan"
                Type="Integer"
                CssClass="Error" />

            <asp:Button
                runat="server"
                ID="btnActualizar"
                Text="Actualizar"
                OnClick="btnActualizar_Click"
                CssClass="BotonActualizar" />

            <asp:Button runat="server"
                ID="btnEliminar"
                Text="Eliminar"
                OnClick="btnEliminar_Click"
                CssClass="BotonEliminar" />

            <asp:Button runat="server"
                ID="btnConsultar"
                Text="Consultar"
                OnClick="btnConsultar_Click"
                CssClass="BotonConsultar" />

            <asp:Button runat="server"
                ID="bntLimpiar"
                Text="Limpiar"
                OnClick="btnLimpiar_Click"
                CssClass="BotonLimpiar" />
            <div>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Mensaje"></asp:Label>
            </div>
            <div class="Contenedor">
                <h1 class="Titulo">Productos</h1>
                <asp:GridView runat="server"
                    ID="gvProductos"
                    DataKeyNames="ProductoID"
                    AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvProductos_SelectedIndexChanged"
                    CssClass="Tabla">
                    <Columns>
                        <asp:BoundField DataField="ProductoID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="CantidadStock" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                        <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Seleccionar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
