using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Printing;

namespace CapaLogicaNegocios
{
    // es la clase que genera el ticket de venta
    public class ClsCrearTicket
    {
        //creamos un objeto de la clase stringbuilder al cual le agregaremos las lineas del ticket
        StringBuilder linea = new StringBuilder();
        //creamos una variable para almacenar el maximo de caracteres que permitiremos en el ticket y una para cortar el papel
        int maxCar = 40, cortar; 
        public string lineasGuion()
        {
            string lineasGuion = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasGuion += "-";//agregara un guion hasta llegar al numero maximo de caracteres
            }
            return linea.AppendLine(lineasGuion).ToString();//devolvemos la linea guion
        }
        //metodo para dibujar una linea con asteriscos
        public string lineasAsterisco()
        {
            string lineasAsterisco = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasAsterisco += "*";//agregara un asterisco hasta llegar al numero maximo de caracteres
            }
            return linea.AppendLine(lineasAsterisco).ToString();//devolvemos la linea asterisco
        }
        //metodo para dibujar una linea con signo igual
        public string lineasIgual()
        {
            string lineasIgual = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasIgual += "=";//agregara un signo igual hasta llegar al numero maximo de caracteres
            }
            return linea.AppendLine(lineasIgual).ToString();//devolvemos la linea igual
        }
        //encabezado
        public void encabezado()
        {
            linea.AppendLine("Hola soy un ticket del gimnasio de 40 car");
        }
        //metodo para poner el texto a la izquierda
        public void textoIzquierda(string texto)
        {
            //si la longitud del texto es mayor al numero de caracteres permitidos, realizara el siguiente procedimiento
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;//indica en que caracter se quedo al bajar ala sigueinte linea
                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //agregamos los fragmentos que salgan del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //agregamos el fragmento restante
                linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                //si no es mayor solo agregarlo
                linea.AppendLine(texto);
            }
        }
        //metodo para poner el texto a la derecha
        public void textoDerecha(string texto)
        {
            //si la longitud del texto es mayor al numero de caracteres permitidos, realizara el siguiente procedimiento
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;//indica en que caracter se quedo al bajar ala sigueinte linea
                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //agregamos los fragmentos que salgan del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //variable para poner espacios restantes
                string espacios = "";
                //obtenemos la longitud del texto restante
                for (int i = 0; i < (maxCar-texto.Substring(caracterActual,texto.Length-caracterActual).Length); i++)
                {
                    espacios += " ";//agrega espacios para alinear ala derecha
                }
                //agregamos el fragmento restante
                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                //obtenemos la longitud del texto restante
                for (int i = 0; i < (maxCar - texto.Length); i++)
                {
                    espacios += " ";//agrega espacios para alinear ala derecha
                }
                //agregamos el fragmento restante
                linea.AppendLine(espacios + texto);
            }
        }
        //metodo para centrar el texto
        public void textoCentrado(string texto)
        {
            //si la longitud del texto es mayor al numero de caracteres permitidos, realizara el siguiente procedimiento
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;//indica en que caracter se quedo al bajar ala sigueinte linea
                for (int longitudTexto = texto.Length; longitudTexto > maxCar; longitudTexto -= maxCar)
                {
                    //agregamos los fragmentos que salgan del texto
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                //variable para poner espacios restantes
                string espacios = "";
                int centrar = (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2;
                //obtenemos la longitud del texto restante
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";//agrega espacios para centrar
                }
                //agregamos el fragmento restante
                linea.AppendLine(espacios + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                //obtenemos la longitud del texto restante
                int centrar = (maxCar - texto.Length) / 2;
                for (int i = 0; i < centrar; i++)
                {
                    espacios += " ";//agrega espacios para centrar
                }
                //agregamos el fragmento restante
                linea.AppendLine(espacios + texto);
            }
        }
        //metodo para poner texto a los extremos
        public void textoExtremos(string textoIzquierdo, string textoDerecho)
        {
            //variables a usar
            string textoIzq, textoDer, textoCompleto = "", espacios = "";
            //si el texto ala isquierda es mayor a 18 cortamos el texto
            if (textoIzquierdo.Length > 18)
            {
                cortar = textoIzquierdo.Length - 18;
                textoIzq = textoIzquierdo.Remove(18, cortar);
            }
            else
            {
                textoIzq = textoIzquierdo;
            }
            textoCompleto = textoIzq;

            if (textoDerecho.Length > 20)
            {
                cortar = textoDerecho.Length - 20;
                textoDer = textoDerecho.Remove(20, cortar);
            }
            else
            {
                textoDer = textoDerecho;
            }
            int nroEspacios = maxCar - (textoIzq.Length + textoDer.Length);
            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";
            }
            textoCompleto += espacios + textoDerecho;
            linea.AppendLine(textoCompleto);
        }
        //metodo para enviar la secuencia de escape a la impresora
        public void cortarTicket()
        {
            linea.AppendLine("\x1B" + "m");//caracteres de corte, varian segun el tipo de impresora
            linea.AppendLine("\x1B" + "d" + "\x09");//avanza 9 renglones, tambien varia
        }
        public void abreCajon()
        {
            //estos tambien varian, checar el manual de la impresora para poner los correctos
            linea.AppendLine("\x1B" + "p" + "\x00" + "\x0F" + "\x96");//caracteres de apertura caja 0
            //linea.AppendLine("\x1B" + "p" + "\x01" + "\x0F" + "\x96");//caracteres de apertura caja 1
        }
        public void imprimirTicket(string impresora)
        {
            RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString());
            linea.Clear();
        }
    }
    //clase para mandar a imprimir texto plano a la impresora
    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "Ticket de venta";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
}
