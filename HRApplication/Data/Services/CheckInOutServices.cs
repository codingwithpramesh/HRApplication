using HRApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HRApplication.Data.Services
{
    public class CheckInOutServices : IcheckInOutServices
    {
        private readonly ApplicationDbContext _context;
        public CheckInOutServices( ApplicationDbContext context) 
        {
            _context = context;
        }

        public void Checkin(int id )
        {

            var data  =  _context.Users.FirstOrDefault( a => a.EmployeeId == id );
            if ( data != null ) 
            {
                EmployeeAttendence attendence = new EmployeeAttendence
                {
                    EmployeeId = data.EmployeeId,
                    CheckinTime = DateTime.Now,
                    Status =  false
                };

                _context.EmployeeAttendence.Add( attendence );
                _context.SaveChanges();
            }
        }

        public bool Checkinoutstatus(int id)
        {
            throw new NotImplementedException();
        }

        public void Checkout(int id)
        {

            var data = _context.Users.FirstOrDefault(a => a.EmployeeId == id);
            if (data != null)
            {
                EmployeeAttendence attendence = new EmployeeAttendence
                {
                    EmployeeId = data.EmployeeId,
                    CheckoutTime = DateTime.Now,
                    Status = true
                };

                _context.EmployeeAttendence.Add(attendence);
                _context.SaveChanges();
            }
        }


       /* public bool Checkinoutstatus( int id)
        {

            var data = _context.EmployeeAttendence.FirstOrDefault(x => x.Id == id);
            return data.Status;           
        }*/
    }
}
