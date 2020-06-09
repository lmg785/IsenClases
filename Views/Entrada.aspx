<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrada.aspx.cs" Inherits="IsenClases.Views.Entrada" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
        <div>
             Hola <%= usuario.Nombre %> <%= usuario.Apellidos %>
        </div>
        <div>
            <% if ("E".Equals(usuario.Rol))
            { %>  <h2>Clases Disponibles</h2>
            <% } else { %>
            <h2>Clases programadas</h2>
            <% } %>

            <% foreach (IsenClases.Model.Clases cls in clases) { %>
            <div>
                Asignatura: <%= cls.Asignatura.Titulo %> <br />
                <% if ("E".Equals(usuario.Rol))
                   { %>
                Fecha: <%= cls.Fecha %> <br />
                Hora: <%= cls.Hora %> <br />
                Asistencia: <input type="checkbox" value="<%= ((IsenClases.Model.Alumno)usuario).isUsuarioRegistrado(cls) %>" />
                <%} else { %>
                        <form id="claseProgramada_<%=cls.IdClase%>">
                        Fecha: <input type="text" name="fechaClase" value="<%= cls.Fecha %>" /> <br />
                        Hora: <input type="text" name="horaClase" value="<%= cls.Hora %>" /> <br />
                        Alumnos que han confirmado (<%= cls.ListaAlumnos.Count %>): <br />
                        <%foreach (IsenClases.Model.Alumno alumno in cls.ListaAlumnos ) { %>
                        -<%= alumno.Nombre %> <%=alumno.Apellidos %> (DNI: <%= alumno.Dni %>)<br />
                        </form>
                    <% } %>
                    
                <% } %>
                <br />
            </div>
            
            <% } %>

            <% if ("P".Equals(usuario.Rol)){ %>
                <h2>Nueva clase</h2>
                <form id="addClase">
                <fieldset>Seleccione asignatura <select id="AsignaturaType" name="AsignaturaType">
                <%foreach(IsenClases.Model.Asignatura a in usuario.ListaAsignaturas ){ %>
                   <option value="<%= a.IdAsignatura %>"><%= a.Titulo %></option>
                <%} %>
                </select>
                <br />
                Fecha: <input type="text" name="fechaClase" value="" /> <br />
                Hora: <input type="text" name="horaClase" value="" /> <br />
                <p><input type="submit" value="Submit" /> </p>
                </fieldset>
                </form>
            <% } %>
        </div>
  
</body>
</html>
