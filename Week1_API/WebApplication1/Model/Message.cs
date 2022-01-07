namespace WebApplication1.Model
{
    public class Message
    {
       
       public int status { get; set; }

       public string? message { get; set; }
       
        public List<Planes>? planesList { get; set; } 
    }
}
