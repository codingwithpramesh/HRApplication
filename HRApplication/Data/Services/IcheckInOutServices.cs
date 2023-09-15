namespace HRApplication.Data.Services
{
    public interface IcheckInOutServices
    {

         void Checkin(int id);

         void Checkout(int id);

         bool Checkinoutstatus(int id);
    }
}
