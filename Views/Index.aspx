<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Examen.Views.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eliminar/Editar/Ver</title>
    <!-- Enlaza a la hoja de estilos CSS -->
    <link href="StyleSheet.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Contenedor principal -->
        <div class="Contenedor">

            <h1 class="Titulo">Formulario de Actualizar/Eliminar</h1>
            <!-- Campo para ingresar o resivir el nombre del producto -->
            <label class="Etiqueta">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="Campo"></asp:TextBox>

            <!-- Validador para asegurar que el campo Nombre no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar un nombre para el producto"
                ControlToValidate="txtNombre"
                runat="server"
                ID="rfvNombre"
                CssClass="Error" />

            <!-- Campo para ingresar o resivir la descripción del producto-->
            <label class="Etiqueta">Descripción</label>
            <asp:TextBox runat="server" ID="txtDescripcion" CssClass="Campo"></asp:TextBox>

            <!-- Validador para asegurar que el campo Descripción no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de ingresar una descripción para el producto"
                ControlToValidate="txtDescripcion"
                runat="server"
                ID="rfvDescripcion"
                CssClass="Error" />
            <!-- Campo para ingresar o resivir el precio del producto -->
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

            <!-- Campo para ingresar o resivir la cantidad en stock del producto -->
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

            <!-- Campo para seleccionar o resivir la categoría del producto -->
            <!-- Se utiliza un DropDownList para mostrar las categorías disponibles -->
            <label class="Etiqueta">Categoría</label>
            <!-- Opciones del DropDownList -->
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

            <!-- Validador para asegurar que se seleccione una categoría -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de seleccionar una categoría"
                ControlToValidate="ddlCategorias"
                InitialValue=""
                runat="server"
                ID="rfvCategoria"
                CssClass="Error" />

            <!-- Campo para ingresar o resivir el ID del producto -->
            <label class="Etiqueta">ID Producto</label>
            <asp:TextBox runat="server" ID="txtID" CssClass="Campo"></asp:TextBox>

            <!-- Validadores para el campo ID -->
            <!-- Validador para asegurar que el campo ID no esté vacío -->
            <asp:RequiredFieldValidator
                ErrorMessage="Debe de seleccionar un produto o ingresar su ID"
                ControlToValidate="txtID"
                runat="server"
                ID="rfvID"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo ID sea un número entero -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un ID adecuado "
                ControlToValidate="txtID"
                runat="server"
                ID="cvIDTipo"
                Operator="DataTypeCheck"
                Type="Integer"
                CssClass="Error" />

            <!-- Validador para asegurar que el campo ID sea mayor a -1 -->
            <asp:CompareValidator
                ErrorMessage="Debe de ingresar un ID mayor a -1"
                ControlToValidate="txtID"
                runat="server"
                ID="cvIDValor"
                ValueToCompare="-1"
                Operator="GreaterThan"
                Type="Integer"
                CssClass="Error" />

            <!-- Botones para las acciones de actualizar, eliminar, consultar y limpiar -->
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
            <!-- Mensaje para mostrar resultados de las operaciones -->
            <div>
                <asp:Label ID="lblMensaje" runat="server" CssClass="Mensaje"></asp:Label>
            </div>
            <div class="Contenedor">
                <h1 class="Titulo">Productos</h1>
                <!-- Tabla para mostrar los productos -->
                <asp:GridView runat="server"
                    ID="gvProductos"
                    DataKeyNames="ProductoID"
                    AutoGenerateColumns="false"
                    OnSelectedIndexChanged="gvProductos_SelectedIndexChanged"
                    CssClass="Tabla">
                    <!-- Definición de las columnas de la tabla -->
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
