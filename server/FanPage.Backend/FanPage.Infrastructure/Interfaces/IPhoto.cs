using FanPage.Application.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanPage.Infrastructure.Interfaces
{
    public interface IPhoto
    {
        Task Create(PhotoDto createPhoto);

        Task Delete(int id);

        Task Update(int id, PhotoDto updatePhoto);
    }
}