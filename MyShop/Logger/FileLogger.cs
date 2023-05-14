namespace MyShop.Logger
{
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            var str = File.ReadAllLines("log.txt").ToList();
            str.Add(message);
            File.WriteAllLines("log.txt", str);
        }
    }
}
