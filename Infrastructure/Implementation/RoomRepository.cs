using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class RoomRepository(HotelDbContext context) : IRoomRepository
    {
        public async Task AddRoom(Room room)
        {
            await context.Rooms.AddAsync(room);
        }

        public async Task Delete(Guid id)
        {
            var room = context.Rooms.FirstOrDefault(r => r.Id == id);
            if (room != null)
            {
                context.Rooms.Remove(room);
                context.SaveChanges();
            }
        }

        public async Task<ICollection<Room>> GetAllRoomAsync()
        {
            return await context.Rooms.ToListAsync();
        }

        public async Task<ICollection<Room>> GetAvailableRooms()
        {
            return await context.Rooms.Where(r => r.IsAvailable).ToListAsync();
        }

        public async Task<Room> GetRoomById(Guid id)
        {
            return await context.Rooms.FirstOrDefaultAsync(r => r.Id == id);
        }

        public Task<Room> GetRoomByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Room room)
        {
            context.Rooms.Update(room);
            context.SaveChanges();
        }
    }
}
