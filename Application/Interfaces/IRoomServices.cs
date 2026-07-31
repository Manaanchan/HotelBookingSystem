using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRoomService
    {
        Task<BaseResponse<RoomResponseModel>> AddRoom(RoomRequestModel request);
        Task<BaseResponse<RoomResponseModel>> GetRoom(Guid id);
        Task<BaseResponse<ICollection<RoomResponseModel>>> GetAllRooms();
        Task<BaseResponse<ICollection<RoomResponseModel>>> GetAvailableRooms();
        Task<BaseResponse<RoomResponseModel>>UpdateRoom(RoomRequestModel request);
        Task<BaseResponse<RoomResponseModel>> DeleteRoom(Guid id);
    }
}
