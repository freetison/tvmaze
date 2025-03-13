namespace TvMaze.ShareCommon.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class NotNullAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckNotNullAttribute : Attribute
    {
        public void OnBeforeExecute()
        {
            // Código que deseas ejecutar antes del método
            Console.WriteLine("Ejecutando antes del método...");
        }
    }
}