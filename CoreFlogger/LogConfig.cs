namespace CoreFlogger
{
    public class LogConfig
    {
        public static LogConfig Current;

        public LogConfig()
        {
            Current = this;
        }

        public string ConnectionString { get; set; }
    }
}
