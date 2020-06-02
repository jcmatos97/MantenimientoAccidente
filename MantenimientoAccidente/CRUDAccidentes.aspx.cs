using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MantenimientoAccidente;

namespace MantenimientoAccidente
{
    public partial class CRUDAccidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AccionTitle.InnerHtml = "Agregar Registro";

            #region TablaConDatos
            DatabaseOPS OPSdatabase = new DatabaseOPS(new Conexion());
            var accidentesLIST = OPSdatabase.Read();
            if(!(accidentesLIST.Count < 1))
            {
                string contentHTML = ""; 
                foreach (var item in accidentesLIST)
                {
                    var sexoHTML = (item.sexo == 1) ? "Masculino" : "Femenino";
                    var estadoHTML = (item.estado == 1) ? "Vivo" : "Muerto";
                    List<string> lesionHTML = new List<string>();

                    if (item.lesion[0] == '1')
                        lesionHTML.Add("Quemadura");
                    if (item.lesion[1] == '1')
                        lesionHTML.Add("Fractura");
                    if (item.lesion[2] == '1')
                        lesionHTML.Add("Cortadura");
                    if (item.lesion[3] == '1')
                        lesionHTML.Add("Arma de Fuego");

                    var lesionFixedHTML =  string.Join(", ", lesionHTML);
                    contentHTML += "<tr>" +
                            "<td>"+item.nombre+ "</td>" +
                            "<td>" + item.apellido+ "</td>" +
                            "<td>" + item.edad+ "</td>" +
                            "<td>" + sexoHTML + "</td>" +
                            "<td>" + Convert.ToDateTime(item.accidente).ToString("yyyy-MM-dd")+ "</td>" +
                            "<td>" + estadoHTML+ "</td>" +
                            "<td><img src='/Imagenes/" + item.foto+ "' alt='45x45' class='img-thumbnail'></td>" +
                            "<td>" + lesionFixedHTML+ "</td>" +
                            "<td>" + item.direccion+ "</td>" +
                            "<td>" + item.detalle+ "</td>" +
                            "<td HorizontalAlign='Center'>" +
                                "<a class='btn btn-warning' href='/CRUDAccidentes?id="+item.id+"'>Actualizar</a><p></p>" +
                                "<a class='btn btn-danger' href='CRUDAccidentes?delete="+item.id+"'>Eliminar</a>" +
                            "</td>" +
                            "</tr>";
                }
                contentTable.InnerHtml = contentHTML;
            }
            #endregion

            #region CargarRegistroFormularioParaActualizar
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                AccionTitle.InnerHtml = "Actualizar Registro";
                int searchTerm = int.Parse(Request.QueryString["id"]);
               
                DatabaseOPS databaseOPS = new DatabaseOPS(new Conexion());
                var accidente = databaseOPS.Read(searchTerm);

                if(!(accidente == null))
                {
                    id.Value = accidente.id.ToString();
                    nombre.Value = accidente.nombre;
                    apellido.Value = accidente.apellido;
                    edad.Value = accidente.edad.ToString();
                    //Sexo Masculino o Femenino
                    sexo1.Checked = (accidente.sexo == 1) ? true : false;
                    sexo2.Checked = (accidente.sexo == 0) ? true : false;
                    fecha.Value = Convert.ToDateTime(accidente.accidente).ToString("yyyy-MM-dd");
                    //Estado Vivo o Muerto
                    ListItem li = estado.Items.FindByValue(accidente.estado.ToString());
                    li.Selected = true;
                    //Tipos de Lesiones            
                    quemadura.Checked = (accidente.lesion[0] == '1') ? true : false;
                    fractura.Checked = (accidente.lesion[1] == '1') ? true : false;
                    cortadura.Checked = (accidente.lesion[2] == '1') ? true : false;
                    armafuego.Checked = (accidente.lesion[3] == '1') ? true : false;
                    direccion.Value = accidente.direccion;
                    detalle.Value = accidente.detalle;
                    Response.StatusCode = 200;
                }                
                else
                {
                    Response.StatusCode = 404;
                    Response.Write("Registro no encontrado!!");
                }
            }
            #endregion

            #region EliminarRegistroPorId
            else if (!string.IsNullOrEmpty(Request.QueryString["delete"]))
            {
                DatabaseOPS databaseOPSX = new DatabaseOPS(new Conexion());
                databaseOPSX.Delete(int.Parse(Request.QueryString["delete"].ToString()));
                Response.Redirect("/CRUDAccidentes");
            }
            #endregion
        }

        protected void sendForm(object sender, EventArgs e)
        {
            #region SubmitActualizarRegistro
            if (!string.IsNullOrEmpty(Request.QueryString["id"]) && !string.IsNullOrEmpty(Request["id"]))
            {
                if(Request.QueryString["id"].ToString() == Request["id"].ToString())
                {
                    Accidente accidente = new Accidente();
                    if (foto.HasFile)
                    {
                        string date = DateTime.Now.ToString("yyyyMMddTHHmmss");
                        Debug.WriteLine(date);
                        string direccionruta = Server.MapPath("Imagenes\\");
                        Debug.WriteLine(date);
                        Debug.WriteLine(direccionruta + date + foto.FileName);
                        foto.SaveAs(direccionruta + date + foto.FileName);
                        accidente.foto = date + foto.FileName;
                    }
                    else if(!foto.HasFile)
                    {
                        DatabaseOPS databaseOPSX = new DatabaseOPS(new Conexion());
                        var accidentex = databaseOPSX.Read(int.Parse(Request["ctl00$MainContent$id"].ToString()));
                        accidente.foto = accidentex.foto;
                    }

                    #region TipoLesion
                    string quemadura1, fractura1, cortadura1, armafuego1;
                    quemadura1 = (!string.IsNullOrEmpty(Request["ctl00$MainContent$quemadura"])) ? "1" : "0";
                    fractura1 = (!string.IsNullOrEmpty(Request["ctl00$MainContent$fractura"])) ? "1" : "0"; 
                    cortadura1 = (!string.IsNullOrEmpty(Request["ctl00$MainContent$cortadura"])) ? "1" : "0";
                    armafuego1 = (!string.IsNullOrEmpty(Request["ctl00$MainContent$armafuego"])) ? "1" : "0";
                    #endregion

                    accidente.id = int.Parse(Request["ctl00$MainContent$id"].ToString());
                    accidente.nombre = Request["ctl00$MainContent$nombre"].ToString();
                    accidente.apellido = Request["ctl00$MainContent$apellido"].ToString();
                    accidente.edad = int.Parse(Request["ctl00$MainContent$edad"].ToString());
                    accidente.sexo = int.Parse(Request["ctl00$MainContent$sexo"].ToString());
                    accidente.accidente = Request["ctl00$MainContent$fecha"].ToString(); 
                    accidente.estado = int.Parse(Request["ctl00$MainContent$estado"].ToString());
                    
                    accidente.lesion = quemadura1 + fractura1 + cortadura1 + armafuego1;
                    accidente.direccion = Request["ctl00$MainContent$direccion"].ToString();
                    accidente.detalle = Request["ctl00$MainContent$detalle"].ToString(); 
                   

                    DatabaseOPS databaseOPS = new DatabaseOPS(new Conexion());
                    databaseOPS.Update(accidente);
                    Response.Redirect("/CRUDAccidentes");
                }
                else
                {
                    Response.StatusCode = 400;
                    Response.Write("Ha ocurrido un error");
                    Response.Redirect("/CRUDAccidentes");
                }
            }
            #endregion

            #region SubmitAgregarRegistro
            else if (string.IsNullOrEmpty(Request.QueryString["id"]) && string.IsNullOrEmpty(Request["id"]))
            {
                string date = DateTime.Now.ToString("yyyyMMddTHHmmss");
                Debug.WriteLine(date);
                string direccionruta = Server.MapPath("Imagenes\\");
                Debug.WriteLine(date);
                Debug.WriteLine(direccionruta + date + foto.FileName);
                foto.SaveAs(direccionruta + date + foto.FileName);

                #region TipoLesion
                string quemadura1, fractura1, cortadura1, armafuego1;
                quemadura1 = (quemadura.Checked) ? "1" : "0";
                fractura1 = (fractura.Checked) ? "1" : "0";
                cortadura1 = (cortadura.Checked) ? "1" : "0";
                armafuego1 = (armafuego.Checked) ? "1" : "0";
                #endregion
                Accidente accidente = new Accidente();

                accidente.nombre = nombre.Value.ToString();
                accidente.apellido = apellido.Value.ToString();
                accidente.edad = int.Parse(edad.Value.ToString());
                accidente.sexo = (sexo1.Checked) ? 1 : 0;
                accidente.accidente = fecha.Value.ToString();
                accidente.estado = (estado.Value == "1") ? 1 : 0;
                accidente.foto = date + foto.FileName;
                accidente.lesion = quemadura1 + fractura1 + cortadura1 + armafuego1;
                accidente.direccion = direccion.Value.ToString();
                accidente.detalle = detalle.Value.ToString();


                DatabaseOPS databaseOPS = new DatabaseOPS(new Conexion());
                databaseOPS.Create(accidente);
                Response.Redirect("/CRUDAccidentes");
            }
            #endregion
            else
            {
                Response.StatusCode = 400;
                Response.Write("Ha ocurrido un error");
                Response.Redirect("/CRUDAccidentes");
            }           
        }
    }
}