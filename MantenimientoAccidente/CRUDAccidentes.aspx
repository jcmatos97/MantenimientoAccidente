<%@ Page Title="CRUD Accidentes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDAccidentes.aspx.cs" Inherits="MantenimientoAccidente.CRUDAccidentes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 runat="server" id="AccionTitle">Hear me roar!!</h1>
        <div class="container-fluid">
            <div class="row">
                <input type="text" class="form-control" id="id" name="id" placeholder="Id" autocomplete="off" runat="server" style="display:none">
                <div class="form-group">
                    <label for="nombre">Nombre</label>
                    <input type="text" class="form-control" id="nombre" name="nombre" placeholder="Nombre" autocomplete="off" runat="server">
                </div>
                <div class="form-group">
                    <label for="apellido">Apellido</label>
                    <input type="text" class="form-control" id="apellido" name="apellido" placeholder="Apellido" autocomplete="off" runat="server">
                </div>
                <div class="form-group">
                    <label for="edad">Edad</label>
                    <input type="number" class="form-control" id="edad" name="edad" placeholder="Edad" autocomplete="off" runat="server">
                </div>
                <div class="form-group">
                    <label for="">Sexo</label><br />
                    <label class="radio-inline"><input type="radio" name="sexo" id="sexo1" value="1" checked runat="server">Masculino</label>
                    <label class="radio-inline"><input type="radio" name="sexo" id="sexo2" value="0" runat="server">Femenino</label>
                </div>
                <div class="form-group">
                    <label for="fecha">Fecha</label>
                    <input type="date" class="form-control" id="fecha" name="fecha" placeholder="Fecha" runat="server">
                </div>
                <div class="form-group">
                    <label for="">Estado</label><br />
                    <select class="form-control" id="estado" name="estado" runat="server">
                        <option value="1" checked runat="server">Vivo</option>
                        <option value="0" runat="server">Muerto</option>
                    </select>
                </div>
                <div class="form-group">
                    <label for="foto">Foto</label>
                    <asp:FileUpload id="foto" class="form-control" runat="server" />  
                    <p class="help-block">Suba una foto del accidente.</p>
                </div>
                <div class="form-group">
                    <label for="">Tipo de Lesión</label>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="quemadura" name="quemadura" value="1" runat="server">
                            Quemadura
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="fractura" name="fractura" value="1" runat="server">
                            Fractura
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="cortadura" name="cortadura" value="1" runat="server">
                            Cortadura
                        </label>
                    </div>
                    <div class="checkbox">
                        <label>
                            <input type="checkbox" id="armafuego" name="armafuego" value="1" runat="server">
                            Arma de Fuego
                        </label>
                    </div>
                </div>

                 <div class="form-group">
                    <label for="direccion">Direccion</label>
                    <input type="text" class="form-control" id="direccion" name="direccion" placeholder="Direccion" autocomplete="off" runat="server">
                </div>
                 <div class="form-group">
                    <label for="detalle">Detalle</label>
                     <textarea class="form-control" rows="3" id="detalle" name="detalle" style="resize : none;" runat="server"></textarea>
                </div>
                <asp:Button ID="botonSendForm" type="submit" runat="server" OnClick="sendForm" Text="Guardar" class="btn btn-primary"/>
            </div>
            <br />
            <br />
            <div class="row">   
                <table class="table table-striped table-bordered">
                    <thead>
                        <tr>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Edad</th>
                            <th>Sexo</th>
                            <th>Fecha</th>
                            <th>Estado</th>
                            <th>Foto</th>
                            <th>Tipo de Lesion</th>
                            <th>Direccion</th>
                            <th>Detalle</th>
                            <th>Accion</th>
                        </tr>
                    </thead>
                    <tbody id="contentTable" runat="server">
                    </tbody>
                </table>
            </div>
        </div>

</asp:Content>
