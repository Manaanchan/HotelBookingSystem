using Application.DTO;
using Application.Interfaces;
using Application.Repository;
using Domain;

namespace Application.Services
{
    public class RoomTypeServices(IRoomTypeRepository roomTypeRepository) : IRoomTypeService
    {
        public async Task<BaseResponse<RoomTypeResponseModel>> AddRoomType(RoomTypeRequestModel request)
        {
            var exist = await roomTypeRepository.GetRoomTypeAsync(request.Id);

            if (exist != null)
            {
                return new BaseResponse<RoomTypeResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room type already exists."
                };
            }

            var roomType = new RoomType
            {
                Name = request.Name,
                Description = request.Description
            };

            await roomTypeRepository.AddAsync(roomType);

            return new BaseResponse<RoomTypeResponseModel>
            {
                IsSuccessful = true,
                Message = "Room type created successfully.",
                Data = new RoomTypeResponseModel
                {
                    Id = roomType.Id,
                    Name = roomType.Name,
                    Description = roomType.Description
                }
            };
        }

        public async Task<BaseResponse<RoomTypeResponseModel>> DeleteRoomType(Guid id)
        {
            var roomType = await roomTypeRepository.GetRoomTypeAsync(id);

            if (roomType == null)
            {
                return new BaseResponse<RoomTypeResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room type not found."
                };
            }

             roomTypeRepository.DeleteAsync(id);

            return new BaseResponse<RoomTypeResponseModel>
            {
                IsSuccessful = true,
                Message = "Room type deleted successfully."
            };
        }

        public async Task<BaseResponse<ICollection<RoomTypeResponseModel>>> GetAllRoomTypes()
        {
            var roomTypes = await roomTypeRepository.GetAllRoomTypeAsync();

            var response = roomTypes.Select(r => new RoomTypeResponseModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description
            }).ToList();

            return new BaseResponse<ICollection<RoomTypeResponseModel>>
            {
                IsSuccessful = true,
                Data = response
            };
        }

        public async Task<BaseResponse<RoomTypeResponseModel>> GetRoomType(Guid id)
        {
            var roomType = await roomTypeRepository.GetRoomTypeAsync(id);

            if (roomType == null)
            {
                return new BaseResponse<RoomTypeResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room type not found."
                };
            }

            return new BaseResponse<RoomTypeResponseModel>
            {
                IsSuccessful = true,
                Data = new RoomTypeResponseModel
                {
                    Id = roomType.Id,
                    Name = roomType.Name,
                    Description = roomType.Description
                }
            };
        }

        public async Task<BaseResponse<RoomTypeResponseModel>> UpdateRoomType(RoomTypeRequestModel request)
        {
            var roomType = await roomTypeRepository.GetRoomTypeAsync(request.Id);

            if (roomType == null)
            {
                return new BaseResponse<RoomTypeResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room type not found."
                };
            }

            roomType.Name = request.Name;
            roomType.Description = request.Description;

             roomTypeRepository.Update(roomType);

            return new BaseResponse<RoomTypeResponseModel>
            {
                IsSuccessful = true,
                Message = "Room type updated successfully.",
                Data = new RoomTypeResponseModel
                {
                    Id = roomType.Id,
                    Name = roomType.Name,
                    Description = roomType.Description
                }
            };
        }

        }
    }