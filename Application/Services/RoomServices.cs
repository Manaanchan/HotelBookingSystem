using Application.DTO;
using Application.Interfaces;
using Application.Repository;
using Application.Services;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class RoomServices(IRoomRepository roomRepository, IRoomTypeRepository roomTypeRepository) : IRoomService
    {
            public async Task<BaseResponse<RoomResponseModel>> AddRoom(RoomRequestModel request)
            {
                var roomExist = await roomRepository.GetRoomByIdAsync(r => r.RoomNumber == request.RoomNumber);

                if (roomExist != null)
                {
                    return new BaseResponse<RoomResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Room already exists."
                    };
                }

                var roomType = await roomTypeRepository.GetRoomTypeAsync(request.RoomTypeId);

                if (roomType == null)
                {
                    return new BaseResponse<RoomResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Room type not found."
                    };
                }

                var room = new Room
                {
                    RoomNumber = request.RoomNumber,
                    RoomTypeId = request.RoomTypeId,
                    Price = request.Price,
                    Capacity = request.Capacity,
                    PricePerNight = request.PricePerNight,
                    IsAvailable = request.IsAvailable
                };

                await roomRepository.AddRoom(room);

                return new BaseResponse<RoomResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Room created successfully.",
                    Data = new RoomResponseModel
                    {
                        Id = room.Id,
                        RoomNumber = room.RoomNumber,
                        RoomTypeId = room.RoomTypeId,
                        Price = room.Price,
                        Capacity = room.Capacity,
                        PricePerNight = room.PricePerNight,
                        IsAvailable = room.IsAvailable
                    }
                };
            }

            public async Task<BaseResponse<RoomResponseModel>> DeleteRoom(Guid id)
            {
                var room = await roomRepository.GetRoomByIdAsync(id);

                if (room == null)
                {
                    return new BaseResponse<RoomResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Room not found."
                    };
                }

                await roomRepository.Delete(room);

                return new BaseResponse<RoomResponseModel>
                {
                    IsSuccessful = true,
                    Message = "Room deleted successfully."
                };
            }

            public async Task<BaseResponse<ICollection<RoomResponseModel>>> GetAllRooms()
            {
                var rooms = await roomRepository.GetAllRoomAsync();

                var response = rooms.Select(r => new RoomResponseModel
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomTypeId = r.RoomTypeId,
                    Price = r.Price,
                    Capacity = r.Capacity,
                    PricePerNight = r.PricePerNight,
                    IsAvailable = r.IsAvailable
                }).ToList();

                return new BaseResponse<ICollection<RoomResponseModel>>
                {
                    IsSuccessful = true,
                    Data = response
                };
            }

            public async Task<BaseResponse<ICollection<RoomResponseModel>>> GetAvailableRooms()
            {
                var rooms = await roomRepository.GetAllRoomAsync();

                var availableRooms = rooms
                    .Where(r => r.IsAvailable)
                    .Select(r => new RoomResponseModel
                    {
                        Id = r.Id,
                        RoomNumber = r.RoomNumber,
                        RoomTypeId = r.RoomTypeId,
                        Price = r.Price,
                        Capacity = r.Capacity,
                        PricePerNight = r.PricePerNight,
                        IsAvailable = r.IsAvailable
                    })
                    .ToList();

                if (!availableRooms.Any())
                {
                    return new BaseResponse<ICollection<RoomResponseModel>>
                    {
                        IsSuccessful = false,
                        Message = "No available rooms found.",
                        Data = new List<RoomResponseModel>()
                    };
                }

                return new BaseResponse<ICollection<RoomResponseModel>>
                {
                    IsSuccessful = true,
                    Message = "Available rooms retrieved successfully.",
                    Data = availableRooms
                };
            }

            public async Task<BaseResponse<RoomResponseModel>> GetRoom(Guid id)
            {
                var room = await roomRepository.GetRoomByIdAsync(id);

                if (room == null)
                {
                    return new BaseResponse<RoomResponseModel>
                    {
                        IsSuccessful = false,
                        Message = "Room not found."
                    };
                }

                return new BaseResponse<RoomResponseModel>
                {
                    IsSuccessful = true,
                    Data = new RoomResponseModel
                    {
                        Id = room.Id,
                        RoomNumber = room.RoomNumber,
                        RoomTypeId = room.RoomTypeId,
                        Price = room.Price,
                        Capacity = room.Capacity,
                        PricePerNight = room.PricePerNight,
                        IsAvailable = room.IsAvailable
                    }
                };
            }

        public async Task<BaseResponse<RoomResponseModel>> UpdateRoom(RoomRequestModel request)
        {
            var room = await roomRepository.GetRoomByIdAsync(request.RoomTypeId);

            if (room == null)
            {
                return new BaseResponse<RoomResponseModel>
                {
                    IsSuccessful = false,
                    Message = "Room not found."
                };
            }

            room.RoomNumber = request.RoomNumber;
            room.RoomTypeId = request.RoomTypeId;
            room.Price = request.Price;
            room.Capacity = request.Capacity;
            room.PricePerNight = request.PricePerNight;
            room.IsAvailable = request.IsAvailable;

            await roomRepository.Update(room);

            return new BaseResponse<RoomResponseModel>
            {
                IsSuccessful = true,
                Message = "Room updated successfully.",
                Data = new RoomResponseModel
                {
                    Id = room.Id,
                    RoomNumber = room.RoomNumber,
                    RoomTypeId = room.RoomTypeId,
                    Price = room.Price,
                    Capacity = room.Capacity,
                    PricePerNight = room.PricePerNight,
                    IsAvailable = room.IsAvailable
                }
            };
        }
    }
}

