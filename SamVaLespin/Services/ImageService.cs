using Microsoft.Extensions.Options;
using SamVaLespin.Options;

namespace SamVaLespin.Services
{
    public class ImageService
    {
        private byte[][] _images;
        private readonly ImageFileOptions _configuration;
        private readonly TimeService _timeService;

        public byte[] DayBeforePicture { get; private set; }
        public byte[] WeekBeforePicture { get; private set; }
        public byte[] YearRoundPicture { get; private set; }

        public ImageService(IOptions<ImageFileOptions> configuration, TimeService timeService)
        {
            _configuration = configuration.Value;
            _timeService = timeService;
            Initialise();
        }

        private void Initialise()
        {
            var tempImages = new List<byte[]>();
            var filenames = Directory.GetFiles(_configuration.DirectoryPath);
            foreach (var filename in filenames)
            {
                tempImages.Add(File.ReadAllBytes(filename));
            }
            _images = tempImages.ToArray();

            DayBeforePicture = File.ReadAllBytes(_configuration.DayBeforePath);
            WeekBeforePicture = File.ReadAllBytes(_configuration.WeekBeforePath);
            YearRoundPicture = File.ReadAllBytes(_configuration.RestOfYearPath);
        }

        private byte[] GetRandomPicture() => Random.Shared.GetItems(_images, 1).FirstOrDefault();

        public byte[] GetPicture() => GetPictureBytes(_timeService.GetSamValenTime());

        private byte[] GetPictureBytes(DateTime date) => (date.Month, date.Day) switch
        {
            (2, 14) => GetRandomPicture(),
            (2, 13) => DayBeforePicture,
            (2, > 7 and < 13) => WeekBeforePicture,
            _ => YearRoundPicture
        };
    }
}
