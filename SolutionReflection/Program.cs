using System.Reflection;

namespace SolutionReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type rectangleType = typeof(Rectangle);

            //Récupération du constructeur
            ConstructorInfo constructor = rectangleType.GetConstructors().Single();

            //Instanciation via le constructeur récupéré
            Rectangle rectangle = (Rectangle)constructor.Invoke(new object[] { 5, 7 });

            //Affichage des propriétés
            foreach(PropertyInfo property in rectangleType.GetProperties())
            {
                //Affichage du nom de la propriété et des la valeur associé à l'instance de la variable rectangle
                Console.WriteLine($"{property.Name} : {property.GetMethod?.Invoke(rectangle, null)}");
            }

            //Affichage du Périmètre
            //MethodInfo? perimetreMethod = rectangleType.GetMethod("GetPerimetre");
            
            ////if(perimetreMethod != null)
            //if (perimetreMethod is not null)
            //{
            //    Console.WriteLine($"Perimetre : {perimetreMethod.Invoke(rectangle, null)}");
            //}

            ////Affichage de la surface
            //MethodInfo? surfaceMethod = rectangleType.GetMethod("GetSurface");
                        
            //if (surfaceMethod is not null)
            //{
            //    Console.WriteLine($"Surface : {surfaceMethod.Invoke(rectangle, null)}");
            //}

            foreach(MethodInfo method in rectangleType.GetMethods().Where(m => m.DeclaringType == rectangleType && !m.IsSpecialName))
            {
                Console.WriteLine($"{method.Name.Replace("Get", "")} : {method.Invoke(rectangle, null)}");
            }
        }
    }

    class Rectangle
    {
        public int Longueur { get; init; }
        public int Largeur { get; init; }

        public Rectangle(int longueur, int largeur)
        {
            Longueur = longueur;
            Largeur = largeur;
        }

        public int GetPerimetre()
        {
            return (Longueur + Largeur) * 2;
        }

        public int GetSurface()
        {
            return Longueur * Largeur;
        }

    }
}