/*
 * Creado por SharpDevelop.
 * Usuario: David Calles
 * Fecha: 17/4/2026
 * Hora: 2:16 p. m.
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.IO;

namespace PersitenciaWAsa01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Epa Chamo qlq este es el taller seccion B");
			
			// directorio
			
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DatosIujo");
			
			string rutaReportes = Path.Combine(rutaRaiz, "REPORTES");
			
			Console.Write(rutaRaiz);
			Console.WriteLine(rutaReportes);
			
			if(!Directory.Exists(rutaReportes)){
			   	Directory.CreateDirectory(rutaReportes);
			   	Console.WriteLine("Directorio Creado Correctamente");
			   }
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}