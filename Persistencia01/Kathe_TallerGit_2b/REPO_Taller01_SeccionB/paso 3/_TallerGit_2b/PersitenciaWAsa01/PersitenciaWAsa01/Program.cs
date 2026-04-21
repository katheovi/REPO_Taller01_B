/*
 * Creado por SharpDevelop.
 * Usuario: Katherin oviedo
 * Fecha: 17/4/2026
 */
using System;
using System.IO;

namespace PersitenciaWAsa01
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Repositorio");
			
			// --- CONFIGURACIÓN DE RUTAS ---
			string rutaRaiz = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DatosIujo");
			string rutaReportes = Path.Combine(rutaRaiz, "REPORTES");
			
			if(!Directory.Exists(rutaReportes)){
				Directory.CreateDirectory(rutaReportes);
				Console.WriteLine("Directorio Creado");
			}

			// --- DESAFÍO 1: EL VALIDADOR DE SEGURIDAD ---
			// Paso 1: Recibir la cadena
			string entradaUsuario = "admin;clave1234"; 
			
			// Paso 2: Usar .Split(';') como dice la ayuda
			string[] partes = entradaUsuario.Split(';');
			string clave = partes[1];
			
			// Paso 3: Verificar si contiene "123"
			if (clave.Contains("1234")) {
				// IMPORTANTE: Definimos la ruta del ARCHIVO, no de la carpeta
				string rutaArchivoSeguridad = Path.Combine(rutaReportes, "seguridad.txt");
				
				using (StreamWriter sw = new StreamWriter(rutaArchivoSeguridad, true)) {
					sw.WriteLine("Clave Débil");
				}
				Console.WriteLine("> Desafío 1: Alerta de seguridad guardada.");
			}

			// --- DESAFÍO 2: EL CLONADOR DE IMÁGENES (FileStream) ---
			string origenImg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "avatar.jpg");
			string destinoImg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "respaldo.jpg");

			// Solo se hacemos si el avatar existe
			if (File.Exists(origenImg)) {
				using (FileStream fsOrigen = new FileStream(origenImg, FileMode.Open, FileAccess.Read))
				using (FileStream fsDestino = new FileStream(destinoImg, FileMode.Create, FileAccess.Write)) {
					
					byte[] buffer = new byte[1024]; // El buffer de 1KB que pide el PDF
					int bytesLeidos;
					
					// Bucle while para leer hasta que no queden bytes
					while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0) {
						fsDestino.Write(buffer, 0, bytesLeidos);
					}
				}
				Console.WriteLine("> Desafío 2: Imagen clonada exitosamente.");
			} else {
				Console.WriteLine("> Desafío 2: No se encontró avatar.jpg para copiar.");
			}

			// --- DESAFÍO 3: EL BUSCADOR DE ARCHIVOS PESADOS ---
			Console.WriteLine("> Desafío 3: Buscando archivos pesados...");
			
			// Listar todos los archivos de la carpeta REPORTES
			string[] archivosEncontrados = Directory.GetFiles(rutaReportes);
			
			foreach (string ruta in archivosEncontrados) {
				// Crear el Inspector (FileInfo)
				FileInfo info = new FileInfo(ruta);
				
				// 5KB son 5120 bytes (5 * 1024)
				if (info.Length > 5120) {
					Console.WriteLine("Borrando " + info.Name + " por superar los 5KB.");
					info.Delete(); 
				}
			}

			Console.WriteLine("\n=== PROCESO FINALIZADO. ===");
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
} 