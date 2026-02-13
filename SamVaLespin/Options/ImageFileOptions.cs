namespace SamVaLespin.Options
{
    public sealed record ImageFileOptions
    {
        public const string ConfigurationSection = "ImageFiles";

        public required string DirectoryPath { get; init; } = "img";
        public required string DayBeforePath { get; init; }
        public required string WeekBeforePath { get; init; }
        public required string RestOfYearPath { get; init; }
    }
}
