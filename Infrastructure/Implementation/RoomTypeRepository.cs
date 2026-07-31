using Application.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Implementation
{
    public class RoomTypeRepository(HotelDbContext context) : IRoomTypeRepository
    {
        public async Task AddAsync(RoomType roomType)
        {
            await context.RoomTypes.AddAsync(roomType);
        }

        public void DeleteAsync(Guid id)
        {
            var roomtype = context.RoomTypes.FirstOrDefault(r => r.Id == id);
            if (roomtype != null)
            {
                context.RoomTypes.Remove(roomtype);
                context.SaveChanges();
            }
        }

        public async Task<ICollection<RoomType>> GetAllRoomTypeAsync()
        {
            return await context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType> GetRoomTypeAsync(Guid id)
        {
            return await context.RoomTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(RoomType roomType)
        {
            context.RoomTypes.Update(roomType);
            context.SaveChanges();
        }
    }
}
