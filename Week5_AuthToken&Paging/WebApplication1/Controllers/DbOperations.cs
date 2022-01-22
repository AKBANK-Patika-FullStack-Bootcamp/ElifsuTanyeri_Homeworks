using DAL.Model;
using Entities;

namespace WebApplication1.Controllers
{


    public class DbOperations
    {
        public PlanesContext _context = new PlanesContext();
        List<Planes> Inventory = new List<Planes>();
        List<PlaneMaintanance> Maintanancequery = new List<PlaneMaintanance>();
        

        /// <summary>
        /// GetPlanes function will be used to list all plane inventory.
        /// </summary>
        /// <returns></returns>
        public List<Planes> GetPlanes()
        {
            Inventory = _context.Planes.OrderBy(x => x.Id).ToList();
            return Inventory;
        }



        /// <summary>
        /// To post, update or delete a plane from the inventory, we are first using the FindPlane function, in order to check if the plane already exists in the inventory.
        /// </summary>
      
        public Planes FindPlane(string ModelFamily ="", string Brand ="", int Id=0)
        {
            Planes? plane = new Planes();


            if (!string.IsNullOrEmpty(ModelFamily) && !string.IsNullOrEmpty(Brand))
            {
                plane = _context.Planes.FirstOrDefault(x => x.ModelFamily == ModelFamily && x.Brand == Brand) ;
            }
            else if (Id > 0)
            {
                plane = _context.Planes.FirstOrDefault(z => z.Id == Id);
            }
   
            return plane;
        }


        /// <summary>
        /// AddModel function will add the requested plane to the inventory. Will be used in Controllers.
        /// </summary>
        /// <param name="newPlane"></param>
        public bool AddModel(Planes newPlane)
        {
            try
            {
                _context.Planes.Add(newPlane);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
           

        }


        /// <summary>
        /// DeleteModel function will delete the plane, by searching its Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteModel(int Id)
        {
            try
            {
                _context.Planes.Remove(FindPlane("", "", Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                
                return false;
            }
        }
        public bool UpdateModel(Planes updatedPlane)
        {
            try
            {

                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }



            

        ///<summary>
        ///Login function for authentication (token)
        /// </summary>
        public void CreateLogin(APIAuthority loginUser )
        {
            _context.APIAuthority.Add(loginUser);
            _context.SaveChanges();
        }

        public APIAuthority GetLogin(APIAuthority loginUser)
    {
        APIAuthority? user = null;
            System.Diagnostics.Debug.WriteLine("--------");
            System.Diagnostics.Debug.WriteLine(loginUser.UserName);
            System.Diagnostics.Debug.WriteLine(loginUser.Password);

            if (!string.IsNullOrEmpty(loginUser.UserName) && !string.IsNullOrEmpty(loginUser.Password))
        {
                //Console./*WriteLine("=====");
                /*List < APIAuthority > users = _context.APIAuthority.Where(m => m.UserName == loginUser.UserName && m.Password == loginUser.Password).ToList();
                    if (users.Count > 0)
                    {
                        user = users.Single();
                    }*/
                user = _context.APIAuthority.SingleOrDefault(m => m.UserName == loginUser.UserName && m.Password == loginUser.Password);
                System.Diagnostics.Debug.WriteLine(loginUser.UserName);
                System.Diagnostics.Debug.WriteLine(loginUser.Password);
                System.Diagnostics.Debug.WriteLine(user);
            }

        return user;

    }


}

}

