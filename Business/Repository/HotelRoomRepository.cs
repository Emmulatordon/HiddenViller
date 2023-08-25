using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using DataAcesss.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class HotelRoomRepository : IHotelRoomRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                HotelRoom hotelRoom = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO);
                hotelRoom.CreatedDate = DateTime.Now;
                hotelRoom.CreatedBy = string.Empty;
                var addedHotelRoom = await _db.HotelRooms.AddAsync(hotelRoom);
                await _db.SaveChangesAsync();
                return _mapper.Map<HotelRoom, HotelRoomDTO>(addedHotelRoom.Entity);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<int> DeleteHotelRoom(int roomId)
        {
            var roomToDelete = await _db.HotelRooms.FindAsync(roomId);
            if (roomToDelete!=null)
            {
                _db.HotelRooms.Remove(roomToDelete);
                return await _db.SaveChangesAsync();
            }
            return 0;
 
        }
        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms()
        {
            try
            {

                IEnumerable<HotelRoomDTO> hotelRoomDTOs =
                    _mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDTO>>(_db.HotelRooms);
                return hotelRoomDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<HotelRoomDTO> GetHotelRoom(int roomId)
        {
            try
            {
                HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Id == roomId));
                return hotelRoom;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<HotelRoomDTO> IsRoomUnique(string name,int roomId = 0)
        {
            try
            {
                if (roomId==0)
                {
                    HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
                    return hotelRoom;
                }
                else
                {
                    HotelRoomDTO hotelRoom = _mapper.Map<HotelRoom, HotelRoomDTO>(
                    await _db.HotelRooms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower() && x.Id!=roomId));
                    return hotelRoom;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<HotelRoomDTO> UpdateHotelRoom(int roomId, HotelRoomDTO hotelRoomDTO)
        {
            try
            {
                if (roomId == hotelRoomDTO.Id)
                {
                    HotelRoom roomDetails = await _db.HotelRooms.FindAsync(roomId);
                    HotelRoom room = _mapper.Map<HotelRoomDTO, HotelRoom>(hotelRoomDTO, roomDetails);
                    room.UpdatedBy = string.Empty;
                    room.UpdatedDate = DateTime.Now;
                    var updatedRoom = _db.HotelRooms.Update(room);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<HotelRoom, HotelRoomDTO>(updatedRoom.Entity);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
