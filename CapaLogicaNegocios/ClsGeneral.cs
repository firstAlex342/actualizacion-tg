using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class ClsGeneral
    {

        ClsManejador M = new ClsManejador();
       public static Socket miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public string Servidor()
        {
            string idSocio="";
                
            miPrimerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // paso 2 - creamos el socket

            IPEndPoint miDireccion = new IPEndPoint(IPAddress.Any, 1234);
                byte[] ByRec;
            //paso 3 -IPAddress.Any significa que va a escuchar al cliente en toda la red

            try
            {


                // paso 4

                miPrimerSocket.Bind(miDireccion); // Asociamos el socket a miDireccion

                miPrimerSocket.Listen(1); // Lo ponemos a escucha

                Socket Escuchar = miPrimerSocket.Accept();

                //creamos el nuevo socket, para comenzar a trabajar con él

                //La aplicación queda en reposo hasta que el socket se conecte a el cliente

                //Una vez conectado, la aplicación sigue su camino 

                Console.WriteLine("Conectado con exito");
                

                ByRec = new byte[255];
                int a = Escuchar.Receive(ByRec, 0, ByRec.Length, 0);
                Array.Resize(ref ByRec, a);
                //MessageBox.Show(Encoding.Default.GetString(ByRec));
                idSocio = Convert.ToString(Encoding.Default.GetString(ByRec));
                miPrimerSocket.Close(); //Luego lo cerramos



            }

            catch (Exception error)
            {
                throw error;
                //Console.WriteLine("Error: {0}", error.ToString());
            }
            return idSocio;

        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try

            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " CON " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return res;
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "CERO";
            else if (value == 1) Num2Text = "UNO";
            else if (value == 2) Num2Text = "DOS";
            else if (value == 3) Num2Text = "TRES";
            else if (value == 4) Num2Text = "CUATRO";
            else if (value == 5) Num2Text = "CINCO";
            else if (value == 6) Num2Text = "SEIS";
            else if (value == 7) Num2Text = "SIETE";
            else if (value == 8) Num2Text = "OCHO";
            else if (value == 9) Num2Text = "NUEVE";
            else if (value == 10) Num2Text = "DIEZ";
            else if (value == 11) Num2Text = "ONCE";
            else if (value == 12) Num2Text = "DOCE";
            else if (value == 13) Num2Text = "TRECE";
            else if (value == 14) Num2Text = "CATORCE";
            else if (value == 15) Num2Text = "QUINCE";
            else if (value < 20) Num2Text = "DIECI" + toText(value - 10);
            else if (value == 20) Num2Text = "VEINTE";
            else if (value < 30) Num2Text = "VEINTI" + toText(value - 20);
            else if (value == 30) Num2Text = "TREINTA";
            else if (value == 40) Num2Text = "CUARENTA";
            else if (value == 50) Num2Text = "CINCUENTA";
            else if (value == 60) Num2Text = "SESENTA";
            else if (value == 70) Num2Text = "SETENTA";
            else if (value == 80) Num2Text = "OCHENTA";
            else if (value == 90) Num2Text = "NOVENTA";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "CIEN";
            else if (value < 200) Num2Text = "CIENTO " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "CIENTOS";
            else if (value == 500) Num2Text = "QUINIENTOS";
            else if (value == 700) Num2Text = "SETECIENTOS";
            else if (value == 900) Num2Text = "NOVECIENTOS";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "MIL";
            else if (value < 2000) Num2Text = "MIL " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " MIL";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "UN MILLON";
            else if (value < 2000000) Num2Text = "UN MILLON " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " MILLONES ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "UN BILLON";
            else if (value < 2000000000000) Num2Text = "UN BILLON " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " BILLONES";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;

        }

        public string enviarSMS(string numCelular, string textoSMS)
        {
            string respuesta = "";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://www.altiria.net");
            //Establecemos el TimeOut para obtener la respuesta del servidor
            client.Timeout = TimeSpan.FromSeconds(60);
            //Se compone el mensaje a enviar
            // XX, YY y ZZ se corresponden con los valores de identificaci´on del usuario en el sistema.
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("cmd", "sendsms"));
            postData.Add(new KeyValuePair<string, string>("domainId", "test"));
            postData.Add(new KeyValuePair<string, string>("login", "pablodelhip"));
            postData.Add(new KeyValuePair<string, string>("passwd", "qxq8rmtx"));
            postData.Add(new KeyValuePair<string, string>("dest", "52"+numCelular));

            postData.Add(new KeyValuePair<string, string>("msg",textoSMS));
            //Remitente autorizado por Altiria al dar de alta el servicio.
            //Omitir el parametro si no se cuenta con ninguno.
            //postData.Add(new KeyValuePair<string, string>("senderId", "remitente"));
            HttpContent content = new FormUrlEncodedContent(postData);
            String err = "";
            String resp = "";
            try
            {
                //Como ejemplo la petici´on se env´ıa a www.altiria.net/sustituirPOSTsms
                //Se debe reemplazar la cadena ’/sustituirPOSTsms’ por la parte correspondiente
                //de la URL suministrada por Altiria al dar de alta el servicio
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/api/http");
                request.Content = content;
                content.Headers.ContentType.CharSet = "UTF-8";
                request.Content.Headers.ContentType =
                new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = client.SendAsync(request).Result;
                var responseString = response.Content.ReadAsStringAsync();
                resp = responseString.Result;
            }
            catch (Exception e)
            {
                err = e.Message;

            }
            finally
            {
                if (err != "")
                {
                    Console.WriteLine(err);
                    respuesta = err;
                }

                else
                {
                    Console.WriteLine(resp);
                    respuesta = resp;
                }
            }

            return respuesta;
        }



        public string EnviarCorreo(ArrayList correos, string textoCorreo,string asunto,string respuestaEmail)
        {
            string respuesta = "";

            try
            {
                System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();

                //Direccion de correo electronico a la que queremos enviar el mensaje
                foreach (string lista in correos)
                {
                    mmsg.To.Add(lista);
                }

                //Nota: La propiedad To es una colección que permite enviar el mensaje a más de un destinatario

                //Asunto
                mmsg.Subject = asunto;
                mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

                //Direccion de correo electronico que queremos que reciba una copia del mensaje
                // mmsg.Bcc.Add("destinatariocopia@servidordominio.com"); //Opcional

                //Cuerpo del Mensaje
                mmsg.Body = textoCorreo;
                mmsg.BodyEncoding = System.Text.Encoding.UTF8;
                mmsg.IsBodyHtml = true; //Si no queremos que se envíe como HTML

                //Correo electronico desde la que enviamos el mensaje
                mmsg.From = new System.Net.Mail.MailAddress("pablo@inttesi.com.mx", "Total Gym", System.Text.Encoding.UTF8);


                /*-------------------------CLIENTE DE CORREO----------------------*/

                //Creamos un objeto de cliente de correo
                System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                //Hay que crear las credenciales del correo emisor
                cliente.Credentials =
                    new System.Net.NetworkCredential("pablo@inttesi.com.mx", "Inttesi#2018");

                //Lo siguiente es obligatorio si enviamos el mensaje desde Gmail

                cliente.Port = 587;
                cliente.EnableSsl = true;
                


                cliente.Host = "mail.inttesi.com.mx"; //Para Gmail "smtp.gmail.com";
                //Enviamos el mensaje      
                cliente.Send(mmsg);
                respuesta = respuestaEmail;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                //Aquí gestionamos los errores al intentar enviar el correo
                respuesta = ex.ToString();
            }

            return respuesta;
        }

        public bool CambiardatosConexion(string usuario, string password, string bd, string servidor)
        {

            return M.cambiarDatosConexion(usuario,password,bd,servidor);  
        }

        public string[] verDatosConexion()
        {
            return M.verDatosConexion();
        }

        public bool validarConexion()
        {
            return M.validarConexion();
        }
    }
}
