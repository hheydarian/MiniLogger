namespace Personal_Logging_System
{
    public class Program
    {
        private static readonly Logger _logger = new();
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Aplication ...");

            try
            {
                ProcessData();
            }
            catch(Exception ex) 
            {
                await _logger.LogError(ex.Message);
                Console.WriteLine("Error logged. Check app.log");
            }
        }
        static void ProcessData()
        {
            throw new Exception("Something went wrong in ProcessData!");
        }
    }
}
