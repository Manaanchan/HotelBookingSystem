using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{
    public interface IRoomTypeRepository
    {
        Task AddAsync(RoomType roomType);
        Task<RoomType> GetRoomTypeAsync(Guid id);
        Task<ICollection<RoomType>> GetAllRoomTypeAsync();
        void DeleteAsync(Guid id);
        void Update(RoomType roomType);
    }
}