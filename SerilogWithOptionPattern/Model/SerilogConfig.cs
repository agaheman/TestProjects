namespace SerilogWithOptionPattern.Model
{
    public class SerilogConfig
    {
        public bool IsEnable { get; set; }
        public string[] Using { get; set; }
        public Minimumlevel MinimumLevel { get; set; }
        public WriteTo[] WriteTo { get; set; }
        public string[] Enrich { get; set; }
        public Properties Properties { get; set; }
    }

    public class Minimumlevel
    {
        public string Default { get; set; }
        public MinimumLevelOverride Override { get; set; }
    }

    public class MinimumLevelOverride
    {
        public string Microsoft { get; set; }
        public string MicrosoftEntityFrameworkCore { get; set; }
        public string System { get; set; }
    }

    public class Properties
    {
        public string Application { get; set; }
        public string Environment { get; set; }
    }

    public class WriteTo
    {
        public bool IsEnable { get; set; }
        public string Name { get; set; }
        public Args Args { get; set; }
    }

    public class Args
    {
        public string Path { get; set; }
        public string ServerUrl { get; set; }
        public string ApiKey { get; set; }
        public string RestrictedToMinimumLevel { get; set; }
    }

}
