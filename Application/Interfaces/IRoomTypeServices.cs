using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IRoomTypeService
    {
        Task<BaseResponse<RoomTypeResponseModel>> AddRoomType(RoomTypeRequestModel request);
        Task<BaseResponse<RoomTypeResponseModel>> GetRoomType(Guid id);
        Task<BaseResponse<ICollection<RoomTypeResponseModel>>> GetAllRoomTypes();
        Task<BaseResponse<RoomTypeResponseModel>> UpdateRoomType(RoomTypeRequestModel request);
        Task<BaseResponse<RoomTypeResponseModel>> DeleteRoomType(Guid id);
    }
}
