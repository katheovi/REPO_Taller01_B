/*
 * Creado por SharpDevelop.
 * Usuario: kathe
 * Fecha: 17/4/2026
 * Hora: 2:16 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace Persistencia01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("====taller seccion b====");
			
			// directorio 
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"datosIUJO");
			
			string rutaReportes = Path.Combine(rutaRaiz,"REPORTES");
			
			Console.WriteLine(rutaRaiz);
			Console.WriteLine(rutaReportes);
			
			if(!Directory.Exists(rutaReportes)){
				//crear el directorio reportes
				Directory.CreateDirectory (rutaReportes);
				Console.WriteLine("directorio creado correctamente");
			   	
			   }
			
			
			//

			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}