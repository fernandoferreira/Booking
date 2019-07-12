using System;
using System.Collections.Generic;
using System.Linq;
using FF.MinhaReserva.Domain.Interfaces;
using FF.MinhaReserva.Domain.Models;
using FF.MinhaReserva.Infra.Data.Context;

namespace FF.MinhaReserva.Infra.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(MinhaReservaContext context) : base(context) { }

        //public IEnumerable<Room> GetAll()
        //{
        //    var sql = @"Select * from Room r
        //                   Where r.IsActive = 1 ";

        //    return Db.Database.Connection.Query<Room>(sql);
        //    //return SearchBy(r => r.IsActive);
        //}

        public Room GetByName(string name)
        {
            return SearchBy(r => r.Name == name).FirstOrDefault();
        }

        public override void Remove(Guid id)
        {
            var room = GetById(id);
            room.Delete();
            Update(room);
        }

        public override IEnumerable<Room> GetAll()
        {
            return SearchBy(r => !r.IsDeleted);
        }
    }
}
