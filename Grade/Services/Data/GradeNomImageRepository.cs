using Grade.Models.Metier;
using Microsoft.Extensions.Configuration;

namespace Grade.Services.Data
{
    public class GradeNomImageRepository : IGradeNomImageRepository
    {
        private readonly IConfiguration _configuration;

        public GradeNomImageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<GradeNomImage> GetGradeNomImages()
        {
            return _configuration.GetRequiredSection("GradeNomImage").Get<IEnumerable<GradeNomImage>>();
        }
    }
}
