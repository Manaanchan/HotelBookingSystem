using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository
{

    public interface IRoomRepository
    {
        Task AddRoom(Room room);
        Task<Room> GetRoomByIdAsync(Guid id);
        Task<ICollection<Room>> GetAllRoomAsync();
        Task<ICollection<Room>> GetAvailableRooms();
        Task Update(Room room);
        Task Delete(Guid id);
    }

}
