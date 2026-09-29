using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea_1_con_ciclo_Progra_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tarea 2 Joxan Vivas
            // Primero declarar las variables
            string cedula = string.Empty;
            string nombre = string.Empty;
            string tipoempnombre = string.Empty;
            byte tipoemp = 0;
            int cantidahoras = 0;
            double preciohora = 0.0;
            double salarioordinario = 0.0; //cantidad de horas * precio por hora
            double salariobruto = 0.0; //salario ordinario + aumento
            double aumentoBase = 0.0;
            double deduccion = 0.0; //deduccion CCSS
            const double leyCCSS = 0.0917;
            double salarioneto = 0.0; //Salario bruto - leyCCSS
            char continuar = 's';

            //Proceso y entrada de datos
            //Ciclo do - while para evaluar despues de ejecutar
            do
            {
                Console.WriteLine("Ingrese la cedula del empleado: ");
                cedula = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del empleado: ");
                nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el tipo de empleado (1-3): ");
                Console.WriteLine("(1.Operario) (2.Tecnico) (3.Profesional)");
                tipoemp = byte.TryParse(Console.ReadLine(), out byte tipo) ? tipo : (byte)0;
                //Evaluar el tipo de empleado y asignar el aumento correspondiente
                switch (tipoemp)
                {
                    case 1:
                        aumentoBase = 0.15;
                        tipoempnombre = "Operario";
                        break;
                    case 2:
                        aumentoBase = 0.10;
                        tipoempnombre = "Tecnico";
                        break;
                    case 3:
                        aumentoBase = 0.05;
                        tipoempnombre = "Profesional";
                        break;
                    default:
                        Console.WriteLine("Tipo de empleado no válido.");
                        break;
                }

                Console.WriteLine("Ingrese la cantidad de horas trabajadas: ");
                cantidahoras = int.TryParse(Console.ReadLine(), out int horas) ? horas : 0;
                Console.WriteLine("Ingrese el precio por hora: ");
                preciohora = double.TryParse(Console.ReadLine(), out double precio) ? precio : 0;

                if (((cantidahoras > 0 && preciohora > 0) && (tipoemp >= 1 && tipoemp <= 3)) && (!string.IsNullOrEmpty(cedula) && !string.IsNullOrEmpty(nombre)))
                {
                    //Calcular salario ordinario
                    salarioordinario = cantidahoras * preciohora;
                    //Calcular salario bruto
                    salariobruto = salarioordinario + (salarioordinario * aumentoBase);
                    //deduccion CCSS
                    deduccion = salariobruto * (double)leyCCSS;
                    //Calcular salario neto
                    salarioneto = salariobruto - deduccion;

                    //Salida de datos
                    Console.WriteLine("----------------Resultados----------------");
                    Console.WriteLine($"Cédula: {cedula}");
                    Console.WriteLine($"Nombre: {nombre}");
                    Console.WriteLine($"Tipo de empleado: {tipoempnombre}");
                    Console.WriteLine($"Salario por horas: {preciohora}");
                    Console.WriteLine($"Horas trabajadas: {cantidahoras}");
                    Console.WriteLine($"Salario ordinario: {salarioordinario}");
                    Console.WriteLine($"Aumento: {aumentoBase * 100} %");
                    Console.WriteLine($"Salario bruto: {salariobruto}");
                    Console.WriteLine($"Deducción CCSS: {deduccion}");
                    Console.WriteLine($"Salario neto: {salarioneto}");

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Datos ingresados no válidos.");
                    
                }

                Console.WriteLine("");
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Desea continuar? (s/n)");
                continuar = char.Parse(Console.ReadLine());

            } while (continuar == 's' || continuar == 'S');

            //Lo hice devuelta desde 0 pero aplicando lo explicado en la clase 2, le agradezco su expliacion profe
            //eso me llevo a hacer un codigo mejor estructurado y entendible, espero sea de su total agrado, Saludos!
        }
    }
}
