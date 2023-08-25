namespace Api_Chave
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
    public class Retorno
    {
        public string? ret { get; set; }
    }
    public class Entrada
    {
        public string? chave { get; set; }
    }
}