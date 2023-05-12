using Grade.Models.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grade.Services.Data
{
    public interface IGradeNomImageRepository
    {
        IEnumerable<GradeNomImage> GetGradeNomImages();
    }
}
